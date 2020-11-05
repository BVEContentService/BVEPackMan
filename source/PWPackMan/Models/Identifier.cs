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
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj) {
			return (obj is Identifier) && Equals((Identifier)obj);
		}

		public bool Equals(Identifier other) {
			return this.HasGuid == other.HasGuid && this.Guid == other.Guid && this.HasName == other.HasName && this.Name == other.Name;
		}

		public override int GetHashCode() {
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * HasGuid.GetHashCode();
				hashCode += 1000000009 * Guid.GetHashCode();
				hashCode += 1000000021 * HasName.GetHashCode();
				if (Name != null)
					hashCode += 1000000033 * Name.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(Identifier lhs, Identifier rhs) {
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Identifier lhs, Identifier rhs) {
			return !(lhs == rhs);
		}

		#endregion

	}
}
