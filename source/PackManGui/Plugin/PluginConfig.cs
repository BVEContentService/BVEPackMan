using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui.Plugin {
  
	public class PluginConfig {
		
		public List<PluginConfigEntry> RemoteRegisteries = new List<PluginConfigEntry>();
		
		public List<PluginConfigEntry> LocalRegisteries = new List<PluginConfigEntry>();
		
		public List<PluginConfigEntry> LocalRegisteryInhibitions = new List<PluginConfigEntry>();
		
		public static PluginConfig FromFile(string file) {
			var configSerializer = new XmlSerializer(typeof(PluginConfig));
			var wrapper = new StringReader(File.ReadAllText(file));
			return (PluginConfig)configSerializer.Deserialize(wrapper);
		}
		
		public void Save(string file) {
			var configSerializer = new XmlSerializer(typeof(PluginConfig));
			var writer = new StreamWriter(file);
			configSerializer.Serialize(writer, this);
		}
	}
	
	public struct PluginConfigEntry : IEquatable<PluginConfigEntry> {
			
		public PluginConfigEntry(IRegistry registry)
			: this() {
			TypeName = registry.GetType().FullName;
			ConfigString = registry.WriteConfig();
		}
			
		public string TypeName { get; set; }
			
		public string ConfigString { get; set; }

		#region Equals and GetHashCode implementation
		public override bool Equals(object obj) {
			return (obj is PluginConfigEntry) && Equals((PluginConfigEntry)obj);
		}

		public bool Equals(PluginConfigEntry other) {
			return this.TypeName == other.TypeName && this.ConfigString == other.ConfigString;
		}

		public override int GetHashCode() {
			int hashCode = 0;
			unchecked {
				if (TypeName != null)
					hashCode += 1000000007 * TypeName.GetHashCode();
				if (ConfigString != null)
					hashCode += 1000000009 * ConfigString.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(PluginConfigEntry lhs, PluginConfigEntry rhs) {
			return lhs.Equals(rhs);
		}

		public static bool operator !=(PluginConfigEntry lhs, PluginConfigEntry rhs) {
			return !(lhs == rhs);
		}

		#endregion
	}
}
