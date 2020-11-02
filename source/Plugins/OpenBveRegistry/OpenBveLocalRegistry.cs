using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using Zbx1425.PWPackMan.Exceptions;
using Microsoft.Win32;
using System.IO;
using OpenBveApi.FileSystem;
using OpenBveApi.Packages;

namespace Zbx1425.OpenBveRegistry {

	public class OpenBveLocalRegistry : ILocalRegistry {

		public string PlatformName { get { return "openbve"; } }
		
		public bool IsFromAutoDetect { get; set; }
		
		public string DatabaseFolder { get; set; }
		public string RouteInstallationDirectory { get; set; }
		public string TrainInstallationDirectory { get; set; }
		public string OtherInstallationDirectory { get; set; }
		public string LoksimPackageInstallationDirectory { get; set; }

		public OpenBveLocalRegistry() {

		}

		public OpenBveLocalRegistry(string configFile, string assemblyFile) {
			var fileSystem = FileSystemPathFix.FromConfigurationFile(configFile, assemblyFile);
			DatabaseFolder = OpenBveApi.Path.CombineDirectory(fileSystem.SettingsFolder, "PackageDatabase");
			RouteInstallationDirectory = fileSystem.RouteInstallationDirectory;
			TrainInstallationDirectory = fileSystem.TrainInstallationDirectory;
			OtherInstallationDirectory = fileSystem.OtherInstallationDirectory;
			LoksimPackageInstallationDirectory = fileSystem.LoksimPackageInstallationDirectory;
		}

		public IRegistry[] AutoDetect() {
			List<ILocalRegistry> registries = new List<ILocalRegistry>();
			switch (Environment.OSVersion.Platform) {
				case PlatformID.Win32NT:
				case PlatformID.Win32S:
				case PlatformID.Win32Windows:
				case PlatformID.WinCE:
				case PlatformID.Xbox:
					{
						const string InnoAppID = "{D617A45D-C2F6-44D1-A85C-CA7FFA91F7FC}_is1";
						string[] InstallLocations = new RegistryKey[] {
							Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" + InnoAppID),
							Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\" + InnoAppID),
							Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" + InnoAppID),
							Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\" + InnoAppID),
						}.Select(regKey => regKey != null ? regKey.GetValue("InstallLocation", null) : null).OfType<string>().Distinct().ToArray();
						foreach (string location in InstallLocations) {
							string assemblyFile = OpenBveApi.Path.CombineFile(location, "OpenBve.exe");
							if (!File.Exists(assemblyFile))
								continue;
							string programConfigFile = OpenBveApi.Path.CombineFile(OpenBveApi.Path.CombineDirectory(OpenBveApi.Path.CombineDirectory(location, "UserData"), "Settings"), "filesystem.cfg");
							if (File.Exists(programConfigFile)) {
								var newRegistery = new OpenBveLocalRegistry(programConfigFile, assemblyFile);
								newRegistery.IsFromAutoDetect = true;
								registries.Add(newRegistery);
							}
						}
						break;
					}
				case PlatformID.Unix:
				case PlatformID.MacOSX:
				case (PlatformID)128: // Earlier Mono
					{
						// TODO: Support them
						break;
					}
			}
			string appDataConfigFile = OpenBveApi.Path.CombineFile(OpenBveApi.Path.CombineDirectory(OpenBveApi.Path.CombineDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "openBVE"), "Settings"), "filesystem.cfg");
			if (File.Exists(appDataConfigFile)) {
				// HACK: There is no way to get the location of OpenBVE, I don't know if doing this is proper
				registries.Add(new OpenBveLocalRegistry(appDataConfigFile, Assembly.GetEntryAssembly().Location));
			}
			return registries.ToArray();
		}

		public async Task DoInstall(Context ctx, string path, LogHandler logCallback, ProgressHandler progressCallback) {
			SwitchToDatabase();
			var currentPackage = Manipulation.ReadPackage(path);
			// Double-check with OpenBVE Package Manager
			List<Package> Dependancies = Database.checkDependsReccomends(currentPackage.Dependancies.ToList());
			List<Package> Recommendations = Database.checkDependsReccomends(currentPackage.Reccomendations.ToList());
			// TODO: Exception Text
			if (Dependancies != null)
				throw new DependencyException();
			if (Recommendations != null)
				throw new DependencyException();
			EventHandler<ProgressReport> progressHandler = (object sender, ProgressReport e) => {
				progressCallback(null, null, e.Progress);
				logCallback(LogLevel.Verbose, string.Format("Extracted {0}", e.CurrentFile));
			};
			EventHandler<ProblemReport> problemHandler = (object sender, ProblemReport e) => {
				throw e.Exception;
			};
			Manipulation.ProgressChanged += progressHandler;
			Manipulation.ProblemReport += problemHandler;
			try {
				await Task.Run(delegate {
					string ExtractionDirectory;
					switch (currentPackage.PackageType) {
						case PackageType.Route:
							ExtractionDirectory = RouteInstallationDirectory;
							break;
						case PackageType.Train:
							ExtractionDirectory = TrainInstallationDirectory;
							break;
						case PackageType.Loksim3D:
							ExtractionDirectory = LoksimPackageInstallationDirectory;
							break;
						default:
							ExtractionDirectory = OtherInstallationDirectory;
							break;
					}
					string PackageFiles = "";
					Manipulation.ExtractPackage(currentPackage, ExtractionDirectory, currentDatabaseFolder, ref PackageFiles);
					if (PackageFiles != string.Empty) {
						switch (currentPackage.PackageType) {
							case PackageType.Route:
								for (int i = Database.currentDatabase.InstalledRoutes.Count; i > 0; i--) {
									if (Database.currentDatabase.InstalledRoutes[i - 1].GUID == currentPackage.GUID) {
										Database.currentDatabase.InstalledRoutes.Remove(Database.currentDatabase.InstalledRoutes[i - 1]);
									}
								}
								Database.currentDatabase.InstalledRoutes.Add(currentPackage);
								break;
							case PackageType.Train:
								for (int i = Database.currentDatabase.InstalledTrains.Count; i > 0; i--) {
									if (Database.currentDatabase.InstalledTrains[i - 1].GUID == currentPackage.GUID) {
										Database.currentDatabase.InstalledTrains.Remove(Database.currentDatabase.InstalledTrains[i - 1]);
									}
								}
								Database.currentDatabase.InstalledTrains.Add(currentPackage);
								break;
							default:
								for (int i = Database.currentDatabase.InstalledOther.Count; i > 0; i--) {
									if (Database.currentDatabase.InstalledOther[i - 1].GUID == currentPackage.GUID) {
										Database.currentDatabase.InstalledOther.Remove(Database.currentDatabase.InstalledOther[i - 1]);
									}
								}
								Database.currentDatabase.InstalledOther.Add(currentPackage);
								break;
						}
					}
				});
			} finally {
				Manipulation.ProgressChanged -= progressHandler;
				Manipulation.ProblemReport -= problemHandler;
			}
			Database.SaveDatabase();
		}

		public async Task DoRemove(Context ctx, Identifier id, LogHandler logCallback, ProgressHandler progressCallback) {
			SwitchToDatabase(); 
			var packageToUninstall = Database.currentDatabase.InstalledRoutes
				.Concat(Database.currentDatabase.InstalledTrains)
				.Concat(Database.currentDatabase.InstalledOther)
				.FirstOrDefault(pack => new Guid(pack.GUID) == id.Guid);
			if (packageToUninstall == null)
				throw new PackageNotFoundException(ctx, id);
			EventHandler<ProgressReport> progressHandler = (object sender, ProgressReport e) => {
				progressCallback(null, null, e.Progress);
				logCallback(LogLevel.Verbose, string.Format("Removed {0}", e.CurrentFile));
			};
			EventHandler<ProblemReport> problemHandler = (object sender, ProblemReport e) => {
				throw e.Exception;
			};
			Manipulation.ProgressChanged += progressHandler;
			Manipulation.ProblemReport += problemHandler;
			try {
				await Task.Run(delegate {
					string uninstallResults = "";
					List<Package> brokenDependancies = Database.CheckUninstallDependancies(packageToUninstall.Dependancies.ToList());
					// TODO: Exception Text
					if (brokenDependancies.Count != 0)
						throw new DependencyException();
					if (Manipulation.UninstallPackage(packageToUninstall, currentDatabaseFolder, ref uninstallResults)) {
						switch (packageToUninstall.PackageType) {
							case PackageType.Other:
								DatabaseFunctions.cleanDirectory(OtherInstallationDirectory, ref uninstallResults);
								break;
							case PackageType.Route:
								DatabaseFunctions.cleanDirectory(RouteInstallationDirectory, ref uninstallResults);
								break;
							case PackageType.Train:
								DatabaseFunctions.cleanDirectory(TrainInstallationDirectory, ref uninstallResults);
								break;
						}
						switch (packageToUninstall.PackageType) {
							case PackageType.Other:
								Database.currentDatabase.InstalledOther.Remove(packageToUninstall);
								break;
							case PackageType.Route:
								Database.currentDatabase.InstalledRoutes.Remove(packageToUninstall);
								break;
							case PackageType.Train:
								Database.currentDatabase.InstalledTrains.Remove(packageToUninstall);
								break;
						}
					}
				});
			} finally {
				Manipulation.ProgressChanged -= progressHandler;
				Manipulation.ProblemReport -= problemHandler;
			}
			Database.SaveDatabase();
		}

		public LocalPackageInfo[] ListPackages(Context ctx) {
			SwitchToDatabase();
			return Database.currentDatabase.InstalledRoutes
            	.Concat(Database.currentDatabase.InstalledTrains)
            	.Concat(Database.currentDatabase.InstalledOther)
            	.Select(pack => PackageStructHelper.ToPWPackage(pack))
            	.ToArray();
		}

		public LocalPackageInfo QueryExternalPackage(Context ctx, string path) {
			var obPackage = Manipulation.ReadPackage(path);
			if (obPackage == null)
				throw new InvalidDataException();
			return PackageStructHelper.ToPWPackage(obPackage);
		}

		public LocalPackageInfo QueryInstalledPackage(Context ctx, Identifier id) {
			SwitchToDatabase();
			var packageList = ListPackages(ctx);
			var matchingPackage = packageList.Where(pack => pack.ID.Guid == id.Guid);
			return matchingPackage.FirstOrDefault(); // Return null if none
		}

		public void ReadConfig(string config) {
			var tokens = config.Trim().Split('\n');
			DatabaseFolder = tokens[0].Trim();
			RouteInstallationDirectory = tokens[1].Trim();
			TrainInstallationDirectory = tokens[2].Trim();
			OtherInstallationDirectory = tokens[3].Trim();
			LoksimPackageInstallationDirectory = tokens[4].Trim();
		}

		public string WriteConfig() {
			return string.Join("\n", DatabaseFolder, 
				RouteInstallationDirectory, TrainInstallationDirectory, OtherInstallationDirectory, LoksimPackageInstallationDirectory);
		}

		public void ShowConfigWindow(System.Windows.Forms.IWin32Window owner) {
			var dialog = new ConfigDialog();
			dialog.ShowDialog(owner);
		}
        
		// HACK: Acquire private field
		private string currentDatabaseFolder {
			get {
				return typeof(Database).GetField("currentDatabaseFolder", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) as string;
			}
		}

		private void SwitchToDatabase() {
			if (string.IsNullOrEmpty(DatabaseFolder))
				throw new NullReferenceException(); // ConfigFile not loaded
			string databaseFile = OpenBveApi.Path.CombineFile(DatabaseFolder, "packages.xml");
			if (DatabaseFolder != currentDatabaseFolder) {
				// OpenBveApi.Packages.Database is static, so we should switch it over
				Database.LoadDatabase(DatabaseFolder, databaseFile);
			}
		}
	}
}
