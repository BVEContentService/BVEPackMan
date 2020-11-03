using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public static class PluginManager {
		
		private static readonly string[] pluginPath = {"Data/Plugins", "Data/BPMPlugins"};
		
		public static readonly List<Type> RemoteRegistryPlugins = new List<Type>();
		
		public static readonly List<Type> LocalRegistryPlugins = new List<Type>();
		
		public static readonly List<Type> TranslationPlugins = new List<Type>();
		
		public static Type[] AllPlugins {
			get {
				return RemoteRegistryPlugins.Concat(LocalRegistryPlugins).Concat(TranslationPlugins).ToArray();
			}
		}
		
		static PluginManager() {
			var pluginFiles = pluginPath
				.Where(Directory.Exists)
				.SelectMany(d => Directory.GetFiles(d, "*.dll"))
	            .Where(f => f.EndsWith("Registry.dll", StringComparison.OrdinalIgnoreCase) || 
				       f.EndsWith("Translation.dll", StringComparison.OrdinalIgnoreCase));
			foreach (var file in pluginFiles) {
				try {
					var assembly = Assembly.LoadFrom(Path.GetFullPath(file));
					foreach (var type in assembly.ExportedTypes) {
						if (typeof(IRemoteRegistry).IsAssignableFrom(type)) {
							RemoteRegistryPlugins.Add(type);
						} else if (typeof(ILocalRegistry).IsAssignableFrom(type)) {
							LocalRegistryPlugins.Add(type);
						} else if (typeof(ITranslation).IsAssignableFrom(type)) {
							TranslationPlugins.Add(type);
						}
					}
				// disable once EmptyGeneralCatchClause
				} catch {
				}
			}
		}
	}
}