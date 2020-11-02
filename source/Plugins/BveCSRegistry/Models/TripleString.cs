using System;

namespace Zbx1425.BveCSRegistry.Models {
	
	[Serializable]
	public struct TripleString : IEquatable<TripleString> {
		
		public string Local { get; set; }
		
		public string English { get; set; }
		
		public string Tag { get; set; }
		
		public override bool Equals(object obj) {
			if (obj is TripleString)
				return Equals((TripleString)obj);
			else
				return false;
		}
		
		public bool Equals(TripleString other) {
			return this.Local == other.Local && this.English == other.English && this.Tag == other.Tag;
		}
		
		public override int GetHashCode() {
			return Local.GetHashCode() ^ English.GetHashCode() ^ Tag.GetHashCode();
		}
		
		public static bool operator ==(TripleString left, TripleString right) {
			return left.Equals(right);
		}
		
		public static bool operator !=(TripleString left, TripleString right) {
			return !left.Equals(right);
		}

        public override string ToString() {
            if (string.IsNullOrEmpty(English)) {
                return Local;
            } else {
                return "[" + Local + ", " + English + "]";
            }
        }
    }
}
