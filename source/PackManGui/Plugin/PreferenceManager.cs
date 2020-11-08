using System;
using System.IO;
using System.Linq;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	internal static class PreferenceManager {
		
		public static PreferenceConfig Config;
		
		public static readonly string ConfigPath = Path.Combine(
			                                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			                                            "Zbx1425.PWPackMan", "PackManGui", "Preference.xml");
  		
		public static void LoadConfig() {
			Config = File.Exists(ConfigPath) ? PreferenceConfig.FromFile(ConfigPath) : new PreferenceConfig();
			if (Config.RemoteRegistry == null ||
			    !RegistryManager.Config.RemoteRegisteries.Contains(Config.RemoteRegistry)) {
				if (RegistryManager.Config.RemoteRegisteries.Count < 1) {
					throw new Exception("Fatal: No remote registry available!");
				}
				Config.RemoteRegistry = RegistryManager.Config.RemoteRegisteries[0];
			}
			if (Config.Translation == null ||
			 	!RegistryManager.Translations.Contains(Config.Translation)) {
				if (RegistryManager.Translations.Count < 1) {
					throw new Exception("Fatal: No translation available!");
				}
				Config.Translation = RegistryManager.Translations[0];
			}
			if (!File.Exists(ConfigPath)) {
				Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
				Config.Save(ConfigPath);
			}
		}
		
		public static void SaveConfig() {
			Config.Save(ConfigPath);
		}
		
	}
}
