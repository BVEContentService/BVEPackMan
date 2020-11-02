using System;

namespace Zbx1425.BveCSRegistry.Models {
	
	[Serializable]
	public class Developer {
		
		public TripleString Name { get; set; }
		
        public string Email { get; set; }
        
        public string Homepage { get; set; }
        
	}
}
