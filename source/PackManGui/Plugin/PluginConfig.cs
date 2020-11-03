using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public class PluginConfig {
		
		public List<IRemoteRegistry> RemoteRegisteries { get; set; }
		
		public List<ILocalRegistry> LocalRegisteries { get; set; }
		
		public List<ILocalRegistry> LocalRegisteryInhibitions { get; set; }
		
		public PluginConfig() {
			RemoteRegisteries = new List<IRemoteRegistry>();
			LocalRegisteries = new List<ILocalRegistry>();
			LocalRegisteryInhibitions = new List<ILocalRegistry>();
		}
		
		public static PluginConfig FromFile(string file) {
			var configSerializer = new DataContractSerializer(typeof(PluginConfig), PluginManager.AllPlugins);
			var wrapper = new StringReader(File.ReadAllText(file));
			var xmlReader = new XmlTextReader(wrapper);
			return (PluginConfig)configSerializer.ReadObject(xmlReader);
		}
		
		public void Save(string file) {
			var configSerializer = new DataContractSerializer(typeof(PluginConfig), PluginManager.AllPlugins);
			using (var writer = new StreamWriter(file)) 
			using (var xmlWriter = new XmlTextWriter(writer)){
				configSerializer.WriteObject(xmlWriter, this);
			}
		}
	}
}
