using System;

namespace Zbx1425.PWPackMan.Models {
	
	public struct Identifier {
		
		public bool HasGuid { get; set; }
		
		public Guid Guid { get; set; }
		
		public bool HasName { get; set; }
		
		public string Name { get; set; }
		
		public Identifier(string name) : this() {
			HasGuid = false;
			Guid = Guid.Empty;
			HasName = true;
			Name = name;
		}
		
		public Identifier(Guid guid) : this() {
			HasGuid = true;
			Guid = guid;
			HasName = false;
			Name = "";
		}
		
		public Identifier(string name, Guid guid) : this() {
			HasGuid = true;
			Guid = guid;
			HasName = true;
			Name = name;
		}
		
		public override string ToString(){
			if (HasGuid && HasName) {
				return Name + "{" + Guid.ToString("N") + "}";
			} else if (HasGuid) {
				return Guid.ToString("N").ToLowerInvariant();
			} else if (HasName) {
				return Name;
			} else {
				return "";
			}
		}
		
		public string GuidOrName() {
			if (HasGuid) {
				return Guid.ToString("N").ToLowerInvariant();
			} else if (HasName) {
				return Name;
			} else {
				return "";
			}
		}

	}
}
