using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public class RegistryConfig {
		
		public List<IRemoteRegistry> RemoteRegisteries { get; set; }
		
		public List<ILocalRegistry> LocalRegisteries { get; set; }
		
		public List<ILocalRegistry> LocalRegisteryInhibitions { get; set; }
		
		public RegistryConfig() {
			RemoteRegisteries = new List<IRemoteRegistry>();
			LocalRegisteries = new List<ILocalRegistry>();
			LocalRegisteryInhibitions = new List<ILocalRegistry>();
		}
		
		public static RegistryConfig FromFile(string file) {
			var configSerializer = new DataContractSerializer(typeof(RegistryConfig), PluginManager.AllPlugins);
			var wrapper = new StringReader(File.ReadAllText(file));
			var xmlReader = new XmlTextReader(wrapper);
			return (RegistryConfig)configSerializer.ReadObject(xmlReader);
		}
		
		public RegistryConfig ShallowClone() {
			return new RegistryConfig() {
				RemoteRegisteries = this.RemoteRegisteries.ToList(),
				LocalRegisteries = this.LocalRegisteries.ToList(),
				LocalRegisteryInhibitions = this.LocalRegisteryInhibitions.ToList()
			};
		}
		
		public void Save(string file) {
			var configSerializer = new DataContractSerializer(typeof(RegistryConfig), PluginManager.AllPlugins);
			using (var writer = new StreamWriter(file)) 
			using (var xmlWriter = new XmlTextWriter(writer)){
				configSerializer.WriteObject(xmlWriter, this);
			}
		}
	}
}
