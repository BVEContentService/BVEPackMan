using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	internal static class RegistryManager {
		
		public static PluginConfig Config;
		
		// Translations are specially treated, because they cannot be configured
		public static List<ITranslation> Translations = new List<ITranslation>();
		
		public static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Zbx1425.PWPackMan", "PackManGui", "PluginConfig.xml");
  
		public static void LoadConfig() {
			if (File.Exists(ConfigPath)) {
				Config = PluginConfig.FromFile(ConfigPath);
			} else {
				Config = new PluginConfig();
				Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
				Config.Save(ConfigPath);
			}
			Config.LocalRegisteries = Config.LocalRegisteries
				.Where(entry => !entry.IsFromAutoDetect && entry.CheckConfig() &&
				       !Config.LocalRegisteryInhibitions.Contains(entry))
				.ToList();
			Config.RemoteRegisteries = Config.RemoteRegisteries
				.Where(entry => !entry.IsFromAutoDetect && entry.CheckConfig())
				.ToList();
			AutoDetect();
			Config.LocalRegisteries = Config.LocalRegisteries
				.Where(entry => entry.CheckConfig() && 
				       !Config.LocalRegisteryInhibitions.Contains(entry))
				.ToList();
		}
		
		private static Type FindRegistryType(string fullName) {
			return PluginManager.LocalRegistryPlugins
				.Concat(PluginManager.RemoteRegistryPlugins)
				.FirstOrDefault(t => t.FullName == fullName);
		}
		
		public static void AutoDetect() {
			foreach (var plugin in PluginManager.LocalRegistryPlugins) {
				var tempInstance = (ILocalRegistry)Activator.CreateInstance(plugin);
				Config.LocalRegisteries.AddRange(
					tempInstance.AutoDetect()
                    .Where(r => !Config.LocalRegisteryInhibitions.Contains(r))
                    .Select(r => (ILocalRegistry)r)
				);
			}
			foreach (var plugin in PluginManager.RemoteRegistryPlugins) {
				var tempInstance = (IRemoteRegistry)Activator.CreateInstance(plugin);
				Config.RemoteRegisteries.AddRange(
					tempInstance.AutoDetect()
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
			Config.LocalRegisteries = Config.LocalRegisteries.Distinct().ToList();
			Config.RemoteRegisteries = Config.RemoteRegisteries.Distinct().ToList();
			Translations = Translations.Distinct().ToList();
		}
		
		public static void SaveConfig() {
			Config.Save(ConfigPath);
		}
	}
}
