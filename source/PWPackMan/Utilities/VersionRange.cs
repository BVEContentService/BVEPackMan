using System;

namespace Zbx1425.PWPackMan.Utilities {
	
	public struct VersionRange {
		
		public Version Minimum { get; set; }
		
		public Version Maximum { get; set; }
		
		public VersionRange(Version minimum = null, Version maximum = null) : this() {
			Minimum = minimum;
			Maximum = maximum;
		}
		
		public bool MatchVersion(Version version) {
			return (Minimum == null || version >= Minimum) && 
				(Maximum == null || version <= Maximum);
		}
		
		public override string ToString() {
			if (Minimum != null && Maximum != null) {
				return string.Format("[{0} - {1}]", Minimum, Maximum);
			} else if (Minimum != null) {
				return string.Format("[{0} &Above]", Minimum);
			} else if (Maximum != null) {
				return string.Format("[Below& {0}]", Maximum);
			} else {
				return "[All]";
			}
		}
		
		#region Equals and GetHashCode implementation
		public override int GetHashCode()
		{
			int hashCode = 0;
				unchecked {
					if (Minimum != null)
						hashCode += 1000000007 * Minimum.GetHashCode();
					if (Maximum != null)
						hashCode += 1000000009 * Maximum.GetHashCode();
				}
					return hashCode;
		}

		public override bool Equals(object obj)
		{
			return (obj is VersionRange) && Equals((VersionRange)obj);
		}

		public bool Equals(VersionRange other)
		{
			return object.Equals(this.Minimum, other.Minimum) && object.Equals(this.Maximum, other.Maximum);
		}

		public static bool operator ==(VersionRange lhs, VersionRange rhs) {
			return lhs.Equals(rhs);
		}

		public static bool operator !=(VersionRange lhs, VersionRange rhs) {
			return !(lhs == rhs);
		}

		#endregion

	}
}
