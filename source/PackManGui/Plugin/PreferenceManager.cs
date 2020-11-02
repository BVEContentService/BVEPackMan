using System;
using System.IO;
using System.Linq;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public static class PreferenceManager {
		
		public static Preference Preference;
		
		public static IRemoteRegistry CurrentRemoteRegistry;
		
		public static ITranslation CurrentTranslation;
		
		private static readonly string ConfigPath = Path.Combine(
			                                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			                                            "Zbx1425.PWPackMan", "PackManGui", "Preference.xml");
  		
		static PreferenceManager() {
			Preference = File.Exists(ConfigPath) ? Preference.FromFile(ConfigPath) : new Preference();
			if (Preference.RemoteRegistry == default(PluginConfigEntry) ||
			    !RegistryManager.LocalRegisteries
			    .Select(r => new PluginConfigEntry(r))
			    .Contains(Preference.RemoteRegistry)) {
				if (RegistryManager.RemoteRegisteries.Count < 1) {
					throw new Exception("Fatal: No remote registry available!");
				}
				Preference.RemoteRegistry = new PluginConfigEntry(RegistryManager.RemoteRegisteries[0]);
			}
			if (Preference.Translation == default(PluginConfigEntry) ||
			 	!RegistryManager.Translations
			    .Select(r => new PluginConfigEntry(r))
			    .Contains(Preference.Translation)) {
				if (RegistryManager.Translations.Count < 1) {
					throw new Exception("Fatal: No translation available!");
				}
				Preference.Translation = new PluginConfigEntry(RegistryManager.Translations[0]);
			}
			CurrentRemoteRegistry = RegistryManager.RemoteRegisteries
				.FirstOrDefault(r => new PluginConfigEntry(r) == Preference.RemoteRegistry);
			CurrentTranslation = RegistryManager.Translations
				.FirstOrDefault(r => new PluginConfigEntry(r) == Preference.Translation);
			if (!File.Exists(ConfigPath)) {
				Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
				Preference.Save(ConfigPath);
			}
		}
		
		public static void SaveConfig() {
			Preference.RemoteRegistry = new PluginConfigEntry(CurrentRemoteRegistry);
			Preference.Translation = new PluginConfigEntry(CurrentTranslation);
			Preference.Save(ConfigPath);
		}
		
	}
}
