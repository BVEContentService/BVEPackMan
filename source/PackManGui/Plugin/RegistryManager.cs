using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public static class RegistryManager {
		
		public static PluginConfig Config;
		
		public static readonly List<IRemoteRegistry> RemoteRegisteries = new List<IRemoteRegistry>();
		
		public static readonly List<ILocalRegistry> LocalRegisteries = new List<ILocalRegistry>();
		
		public static readonly List<ITranslation> Translations = new List<ITranslation>();
		
		private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Zbx1425.PWPackMan", "PackManGui", "PluginConfig.xml");
  
		static RegistryManager() {
			if (File.Exists(ConfigPath)) {
				Config = PluginConfig.FromFile(ConfigPath);
			} else {
				Config = new PluginConfig();
				Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
				Config.Save(ConfigPath);
			}
			foreach (var entry in Config.LocalRegisteries) {
				if (Config.LocalRegisteryInhibitions.Contains(entry))
					continue;
				try {
					var instance = (ILocalRegistry)Activator.CreateInstance(FindRegistryType(entry.TypeName));
					instance.ReadConfig(entry.ConfigString);
					LocalRegisteries.Add(instance);
					// disable once EmptyGeneralCatchClause
				} catch {
				}
			}
			foreach (var entry in Config.RemoteRegisteries) {
				try {
					var instance = (IRemoteRegistry)Activator.CreateInstance(FindRegistryType(entry.TypeName));
					instance.ReadConfig(entry.ConfigString);
					RemoteRegisteries.Add(instance);
					// disable once EmptyGeneralCatchClause
				} catch {
				}
			}
			AutoDetect();
		}
		
		private static Type FindRegistryType(string fullName) {
			return PluginManager.LocalRegistryPlugins
				.Concat(PluginManager.RemoteRegistryPlugins)
				.FirstOrDefault(t => t.FullName == fullName);
		}
		
		public static void AutoDetect() {
			var adLC = LocalRegisteries.Select(r => new PluginConfigEntry(r));
			var adRC = RemoteRegisteries.Select(r => new PluginConfigEntry(r));
			foreach (var plugin in PluginManager.LocalRegistryPlugins) {
				var tempInstance = (ILocalRegistry)Activator.CreateInstance(plugin);
				LocalRegisteries.AddRange(
					tempInstance.AutoDetect()
                    .Where(r => !Config.LocalRegisteryInhibitions.Contains(new PluginConfigEntry(r)))
                    .Where(r => !adLC.Contains(new PluginConfigEntry(r)))
                    .Select(r => (ILocalRegistry)r)
				);
			}
			foreach (var plugin in PluginManager.RemoteRegistryPlugins) {
				var tempInstance = (IRemoteRegistry)Activator.CreateInstance(plugin);
				RemoteRegisteries.AddRange(
					tempInstance.AutoDetect()
					.Where(r => !adRC.Contains(new PluginConfigEntry(r)))
					.Select(r => (IRemoteRegistry)r)
				);
			}
			foreach (var plugin in PluginManager.TranslationPlugins) {
				var tempInstance = (ITranslation)Activator.CreateInstance(plugin);
				Translations.AddRange(
					tempInstance.AutoDetect()
					.Select(r => (ITranslation)r)
				);
			}
		}
		
		public static void SaveConfig() {
			Config.RemoteRegisteries = RemoteRegisteries
				.Where(r => !r.IsFromAutoDetect)
				.Select(r => new PluginConfigEntry(r))
				.Distinct().ToList();
			Config.LocalRegisteries = LocalRegisteries
				.Where(r => !r.IsFromAutoDetect)
				.Select(r => new PluginConfigEntry(r))
				.Distinct().ToList();
			Config.LocalRegisteryInhibitions = Config.LocalRegisteryInhibitions.Distinct().ToList();
			Config.Save(ConfigPath);
		}
	}
}
