using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using System.IO;
using OpenBveApi.FileSystem;
using OpenBveApi.Packages;
using System.Runtime.Serialization;

[assembly: ContractNamespaceAttribute("http://www.zbx1425.tk/bve", ClrNamespace = "Zbx1425.OpenBveRegistry")]
namespace Zbx1425.OpenBveRegistry {
	
	public partial class OpenBveLocalRegistry : ILocalRegistry {

		public string PlatformName { get { return "openbve"; } }
		
		public bool IsFromAutoDetect { get; set; }
		
		public string DatabaseFolder { get; set; }
		public string RouteInstallationDirectory { get; set; }
		public string TrainInstallationDirectory { get; set; }
		public string OtherInstallationDirectory { get; set; }
		public string LoksimPackageInstallationDirectory { get; set; }

		public OpenBveLocalRegistry() {
			var obveCfgPath = Path.Combine(
				                  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				                  "openBVE"
			                  );
			DatabaseFolder = Path.Combine(obveCfgPath, "UserData", "Settings", "PackageDatabase");
			RouteInstallationDirectory = Path.Combine(obveCfgPath, "LegacyContent", "Railway");
			TrainInstallationDirectory = Path.Combine(obveCfgPath, "LegacyContent", "Train");
			OtherInstallationDirectory = Path.Combine(obveCfgPath, "LegacyContent", "Other");
			LoksimPackageInstallationDirectory = Path.Combine(obveCfgPath, "ManagedContent", "Loksim3D");
		}

		public OpenBveLocalRegistry(string configFile, string assemblyFile) {
			var fileSystem = FileSystemPathFix.FromConfigurationFile(configFile, assemblyFile);
			DatabaseFolder = OpenBveApi.Path.CombineDirectory(fileSystem.SettingsFolder, "PackageDatabase");
			RouteInstallationDirectory = fileSystem.RouteInstallationDirectory;
			TrainInstallationDirectory = fileSystem.TrainInstallationDirectory;
			OtherInstallationDirectory = fileSystem.OtherInstallationDirectory;
			LoksimPackageInstallationDirectory = fileSystem.LoksimPackageInstallationDirectory;
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

		public bool ShowConfigWindow(System.Windows.Forms.IWin32Window owner, ITranslation i18n) {
			var dialog = new ConfigDialog(i18n, this);
			return dialog.ShowDialog(owner) == System.Windows.Forms.DialogResult.OK;
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
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj) {
			OpenBveLocalRegistry other = obj as OpenBveLocalRegistry;
			if (other == null)
				return false;
			return this.DatabaseFolder == other.DatabaseFolder && this.RouteInstallationDirectory == other.RouteInstallationDirectory && this.TrainInstallationDirectory == other.TrainInstallationDirectory && this.OtherInstallationDirectory == other.OtherInstallationDirectory && this.LoksimPackageInstallationDirectory == other.LoksimPackageInstallationDirectory;
		}

		public override int GetHashCode() {
			int hashCode = 0;
			unchecked {
				if (DatabaseFolder != null)
					hashCode += 1000000009 * DatabaseFolder.GetHashCode();
				if (RouteInstallationDirectory != null)
					hashCode += 1000000021 * RouteInstallationDirectory.GetHashCode();
				if (TrainInstallationDirectory != null)
					hashCode += 1000000033 * TrainInstallationDirectory.GetHashCode();
				if (OtherInstallationDirectory != null)
					hashCode += 1000000087 * OtherInstallationDirectory.GetHashCode();
				if (LoksimPackageInstallationDirectory != null)
					hashCode += 1000000093 * LoksimPackageInstallationDirectory.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(OpenBveLocalRegistry lhs, OpenBveLocalRegistry rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(OpenBveLocalRegistry lhs, OpenBveLocalRegistry rhs) {
			return !(lhs == rhs);
		}

		#endregion
	}
}
