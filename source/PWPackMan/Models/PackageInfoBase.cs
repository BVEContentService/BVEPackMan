using System;

namespace Zbx1425.PWPackMan.Models {
	
	public abstract class PackageInfoBase {
		
		public virtual Identifier ID { get; set; }
		
		public virtual string PlainName { get; set; }
		
		public virtual string Category { get; set; }
		
		public virtual string AuthorName { get; set; }
		
		public virtual string Website { get; set; }
		
		public virtual string Description { get; set; }
		
	}
}
