using System;
using System.Collections.Generic;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan.Models {
	
	public class RemotePackageInfo : PackageInfoBase {
		
		public virtual SerializableSortedDictionary<Version, string> AvailableVersions { get; set; }
		
		public virtual bool ForcePopup { get; set; }
		
		public RemotePackageInfo() {
			AvailableVersions = new SerializableSortedDictionary<Version, string>();
		}
	}
}
