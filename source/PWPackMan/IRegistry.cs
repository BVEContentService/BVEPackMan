using System;
using System.Windows.Forms;

namespace Zbx1425.PWPackMan {
	
	public interface IRegistry {
		
		string PlatformName { get; }
		
		bool IsFromAutoDetect { get; set; }
		
		bool CheckConfig();
		
		bool ShowConfigWindow(IWin32Window owner, ITranslation i18n);
		
		IRegistry[] AutoDetect();
		
	}
}
