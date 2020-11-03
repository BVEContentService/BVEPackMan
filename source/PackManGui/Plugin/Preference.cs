using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public class Preference {
  
		public IRemoteRegistry RemoteRegistry;
		
		public ITranslation Translation;
		
		public static Preference FromFile(string file) {
			var configSerializer = new DataContractSerializer(typeof(Preference), PluginManager.AllPlugins);
			var wrapper = new StringReader(File.ReadAllText(file));
			var xmlReader = new XmlTextReader(wrapper);
			return (Preference)configSerializer.ReadObject(xmlReader);
		}
		
		public void Save(string file) {
			var configSerializer = new DataContractSerializer(typeof(Preference), PluginManager.AllPlugins);
			using (var writer = new StreamWriter(file)) 
			using (var xmlWriter = new XmlTextWriter(writer)){
				configSerializer.WriteObject(xmlWriter, this);
			}
		}
	}
}
