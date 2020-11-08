using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public class PreferenceConfig {
  
		public IRemoteRegistry RemoteRegistry;
		
		public ITranslation Translation;
		
		public static PreferenceConfig FromFile(string file) {
			var configSerializer = new DataContractSerializer(typeof(PreferenceConfig), PluginManager.AllPlugins);
			var wrapper = new StringReader(File.ReadAllText(file));
			var xmlReader = new XmlTextReader(wrapper);
			return (PreferenceConfig)configSerializer.ReadObject(xmlReader);
		}
		
		public void Save(string file) {
			var configSerializer = new DataContractSerializer(typeof(PreferenceConfig), PluginManager.AllPlugins);
			using (var writer = new StreamWriter(file)) 
			using (var xmlWriter = new XmlTextWriter(writer)){
				configSerializer.WriteObject(xmlWriter, this);
			}
		}
	}
}
