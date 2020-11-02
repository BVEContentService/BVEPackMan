using System;
using System.Windows.Forms;

namespace Zbx1425.PWPackMan {
	
	public interface IRegistry {
		
		string PlatformName { get; }
		
		bool IsFromAutoDetect { get; set; }
		
		void ShowConfigWindow(IWin32Window owner);
		
		IRegistry[] AutoDetect();

        string WriteConfig();

        void ReadConfig(string config);
		
	}
}
