using System;
using System.Collections.Generic;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan.Models {
	
	public class LocalPackageInfo : PackageInfoBase {
		
		public virtual Version Version { get; set; }
		
		public virtual Dictionary<Identifier, VersionRange> Dependencies { get; set; }
		
		public LocalPackageInfo() {
			Dependencies = new Dictionary<Identifier, VersionRange>();
		}
	}
}
