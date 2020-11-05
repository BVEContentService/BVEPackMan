using System;

namespace Zbx1425.BveCSRegistry.Models {
	
	[Serializable]
	public class Developer {
		
		public TripleString Name { get; set; }
		
        public string Email { get; set; }
        
        public string Homepage { get; set; }
        
		public override string ToString() {
        	string result = Name.ToString();
        	if (!string.IsNullOrEmpty(Email)) result += Environment.NewLine + Email;
        	if (!string.IsNullOrEmpty(Homepage)) result += Environment.NewLine + Homepage;
        	return result;
		}

        
	}
}
