using System;
using System.IO;
using System.Xml.Serialization;

namespace Zbx1425.PackManGui.Plugin {
  
	public class Preference {
  
		public PluginConfigEntry RemoteRegistry;
		
		public PluginConfigEntry Translation;
		
		public static Preference FromFile(string file) {
			var configSerializer = new XmlSerializer(typeof(Preference));
			var wrapper = new StringReader(File.ReadAllText(file));
			return (Preference)configSerializer.Deserialize(wrapper);
		}
		
		public void Save(string file) {
			var configSerializer = new XmlSerializer(typeof(Preference));
			var writer = new StreamWriter(file);
			configSerializer.Serialize(writer, this);
		}
	}
}
