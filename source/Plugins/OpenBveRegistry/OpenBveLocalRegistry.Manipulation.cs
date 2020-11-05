using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBveApi.Packages;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using Zbx1425.PWPackMan.Exceptions;
using Zbx1425.OpenBveRegistry.Exceptions;

namespace Zbx1425.OpenBveRegistry {
  
	public partial class OpenBveLocalRegistry {
		
		public async Task DoInstall(Context ctx, string path, LogHandler logCallback, ProgressHandler progressCallback) {
			SwitchToDatabase();
			var currentPackage = Manipulation.ReadPackage(path);
			if (currentPackage == null)
				throw new MalformedPackageException(ctx);
			
			// Double-check with OpenBVE Package Manager
			List<Package> Dependancies = Database.checkDependsReccomends(currentPackage.Dependancies.ToList());
			List<Package> Recommendations = Database.checkDependsReccomends(currentPackage.Reccomendations.ToList());
			if (Dependancies != null)
				throw new MissingDependencyException(ctx, Dependancies);
			if (Recommendations != null)
				throw new MissingDependencyException(ctx, Recommendations);
			
			// Remove the older one for upgrade/downgrade
			VersionInformation Info;
			Package oldPackage = null;
			switch (currentPackage.PackageType) {
				case PackageType.Route:
					Info = Information.CheckVersion(currentPackage, Database.currentDatabase.InstalledRoutes, ref oldPackage);
					break;
				case PackageType.Train:
					Info = Information.CheckVersion(currentPackage, Database.currentDatabase.InstalledTrains, ref oldPackage);
					break;
				default:
					Info = Information.CheckVersion(currentPackage, Database.currentDatabase.InstalledOther, ref oldPackage);
					break;
			}
			if (Info != VersionInformation.NotFound) {
				// No need for dependency check there, since this is an upgrade.
				// Might break packages with version requirements, but PWPackMan should handle that
				await UncheckedRemove(oldPackage, logCallback, progressCallback);
			}
			await UncheckedInstall(currentPackage, logCallback, progressCallback);
		}

		public async Task DoRemove(Context ctx, Identifier id, LogHandler logCallback, ProgressHandler progressCallback) {
			SwitchToDatabase(); 
			var currentPackage = Database.currentDatabase.InstalledRoutes
				.Concat(Database.currentDatabase.InstalledTrains)
				.Concat(Database.currentDatabase.InstalledOther)
				.FirstOrDefault(pack => new Guid(pack.GUID) == id.Guid);
			if (currentPackage == null)
				throw new PackageNotFoundException(ctx, id);
			
			// Double-check with OpenBVE Package Manager
			List<Package> brokenDependancies = Database.CheckUninstallDependancies(currentPackage.Dependancies.ToList());
			if (brokenDependancies.Count != 0)
				throw new BrokenDependencyException(ctx, brokenDependancies);
			await UncheckedRemove(currentPackage, logCallback, progressCallback);
		}
  
		private async Task UncheckedInstall(Package currentPackage, LogHandler logCallback, ProgressHandler progressCallback) {
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
		
		private async Task UncheckedRemove(Package packageToUninstall, LogHandler logCallback, ProgressHandler progressCallback) {
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
	}
}
