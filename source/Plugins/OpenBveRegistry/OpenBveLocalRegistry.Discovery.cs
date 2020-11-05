using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Zbx1425.PWPackMan;
using System.Reflection;
using System.Linq;
using System.IO;

namespace Zbx1425.OpenBveRegistry {
  
	public partial class OpenBveLocalRegistry {
  
		public IRegistry[] AutoDetect() {
			var registries = new List<OpenBveLocalRegistry>();
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
				var newRegistery = new OpenBveLocalRegistry(appDataConfigFile, Assembly.GetEntryAssembly().Location);
				newRegistery.IsFromAutoDetect = true;
				registries.Add(newRegistery);
			}
			return registries.ToArray();
		}
		
		internal static bool IsPathValid(string path) {
			try {
				var fi = new FileInfo(path);
				return fi != null && Path.IsPathRooted(path);
			} catch (ArgumentException) {
			} catch (PathTooLongException) {
			} catch (NotSupportedException) {
				return false;
			}
			return false;
		}
		
		
		
		public bool CheckConfig() {
			return Directory.Exists(DatabaseFolder) &&
			File.Exists(Path.Combine(DatabaseFolder, "packages.xml")) &&
			IsPathValid(RouteInstallationDirectory) &&
			IsPathValid(TrainInstallationDirectory) &&
			IsPathValid(OtherInstallationDirectory) &&
			IsPathValid(LoksimPackageInstallationDirectory);
		}
	}
}
