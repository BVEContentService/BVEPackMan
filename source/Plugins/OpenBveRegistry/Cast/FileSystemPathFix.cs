using System;
using OpenBveApi.FileSystem;
using System.IO;
using System.Reflection;
using System.Text;

namespace Zbx1425.OpenBveRegistry {
  
	internal static class FileSystemPathFix {

		public static FileSystem FromConfigurationFile(string file, string assemblyFile) {
			string assemblyFolder = System.IO.Path.GetDirectoryName(assemblyFile);
			FileSystem system = FileSystem.FromCommandLineArgs(new[] {"/filesystem=" + file});
			try {
				string[] lines = File.ReadAllLines(file, Encoding.UTF8);
				foreach (string line in lines) {
					int equals = line.IndexOf('=');
					if (equals >= 0) {
						string key = line.Substring(0, equals).Trim(new char[] { }).ToLowerInvariant();
						string value = line.Substring(equals + 1).Trim(new char[] { });
						switch (key) {
							case "data":

								system.DataFolder = GetAbsolutePath(value, assemblyFile, true);
								if (!Directory.Exists(system.DataFolder)) {
									system.DataFolder = OpenBveApi.Path.CombineDirectory(assemblyFolder, "Data");
									if (!Directory.Exists(system.DataFolder)) {
										//If we are unable to find the data folder, this is a critical error, as it contains all sorts of essential stuff.....
										Environment.Exit(0);
									}
								}
								break;
							case "managedcontent":
								/* system.ManagedContentFolders = value.Split(new char[] { ',' });
								for (int i = 0; i < system.ManagedContentFolders.Length; i++) {
									system.ManagedContentFolders[i] = GetAbsolutePath(system.ManagedContentFolders[i].Trim(new char[] { }), true);
								} */
								break;
							case "version":
								int v;
								if (!int.TryParse(value, out v)) {
									system.AppendToLogFile("WARNING: Invalid filesystem.cfg version detected.");
								}
								/* if (v <= 1) {
									//Silently upgrade to the current config version
									system.Version = 1;
									break;
								}
								if (v > 1) {
									system.AppendToLogFile("WARNING: A newer filesystem.cfg version " + v + " was detected. The current version is 1.");
									system.Version = v;
								} */
								break;
							case "settings":
								system.SettingsFolder = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "initialroute":
								system.InitialRouteFolder = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "initialtrain":
								system.InitialTrainFolder = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "restartprocess":
								system.RestartProcess = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "restartarguments":
								system.RestartArguments = GetAbsolutePath(value, assemblyFile, false);
								break;
							case "routepackageinstall":
								system.RouteInstallationDirectory = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "trainpackageinstall":
								system.TrainInstallationDirectory = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "otherpackageinstall":
								system.OtherInstallationDirectory = GetAbsolutePath(value, assemblyFile, true);
								break;
							case "loksimpackageinstall":
								system.LoksimPackageInstallationDirectory = GetAbsolutePath(value, assemblyFile, true);
								break;
							default:
								/* if (system.NotUnderstoodLines == null) {
									system.NotUnderstoodLines = new string[0];
								}
								int l = system.NotUnderstoodLines.Length;
								Array.Resize(ref system.NotUnderstoodLines, system.NotUnderstoodLines.Length + 1);
								system.NotUnderstoodLines[l] = line; */
								system.AppendToLogFile("WARNING: Unrecognised key " + key + " detected in filesystem.cfg");
								break;
						}
					}
				}
			// disable once EmptyGeneralCatchClause
			} catch {
			}
			return system;
		}
		
		private static string GetAbsolutePath(string folder, string assemblyFile, bool checkIfRooted) {
			string originalFolder = folder;
			if (checkIfRooted) {
				folder = folder.Replace('/', System.IO.Path.DirectorySeparatorChar);
				folder = folder.Replace('\\', System.IO.Path.DirectorySeparatorChar);
			}
			folder = folder.Replace("$[AssemblyFile]", assemblyFile);
			folder = folder.Replace("$[AssemblyFolder]", System.IO.Path.GetDirectoryName(assemblyFile));
			folder = folder.Replace("$[ApplicationData]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			folder = folder.Replace("$[CommonApplicationData]", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
			folder = folder.Replace("$[Personal]", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
			if (checkIfRooted && !System.IO.Path.IsPathRooted(folder)) {
				throw new InvalidDataException("The folder " + originalFolder + " does not produce an absolute path.");
			}
			return folder;
		}
	}
}
