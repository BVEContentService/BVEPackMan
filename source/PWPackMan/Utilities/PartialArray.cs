using System;
using System.Collections.Generic;

namespace Zbx1425.PWPackMan.Utilities {

	public class PartialArray<T> : List<T> {
		
		public int OverallLength { get; set; }
		
		public PartialArray() : base() {
			
		}
		
		public PartialArray(List<T> src) : base(src) {
			
		}
		
		public PartialArray(int overallLength) : this() {
			OverallLength = overallLength;
		}
		
		public PartialArray(List<T> src, int overallLength) : this(src) {
			OverallLength = overallLength;
		}
	}
}
