using System;

namespace Zbx1425.PWPackMan {
	
	public interface ITranslation : IRegistry {
		
		string Translate(string id);
		
		string Translate(string id, params object[] args);
		
	}
}
