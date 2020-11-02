using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Zbx1425.BveCSRegistry.Utilities {
  
	[Serializable]
	[XmlType("Version")]
	public class XmlVersion {
		public XmlVersion() {
			this.Version = null;
		}

		public XmlVersion(Version Version) {
			this.Version = Version;
		}

		[XmlIgnore]
		public Version Version { get; set; }

		[XmlText]
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string Value {
			get { return this.Version == null ? string.Empty : this.Version.ToString(); }
			set {
				Version temp;
				Version.TryParse(value, out temp);
				this.Version = temp;
			}
		}

		public static implicit operator Version(XmlVersion XmlVersion) {
			return XmlVersion.Version;
		}

		public static implicit operator XmlVersion(Version Version) {
			return new XmlVersion(Version);
		}

		public override string ToString() {
			return this.Value;
		}
	}
}
