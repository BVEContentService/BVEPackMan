using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan {
	
	public interface ILocalRegistry : IRegistry {

        LocalPackageInfo[] ListPackages(Context ctx);
		
		LocalPackageInfo QueryExternalPackage(Context ctx, string path);
		
		LocalPackageInfo QueryInstalledPackage(Context ctx, Identifier id);
		
		Task DoInstall(Context ctx, string path, LogHandler logCallback, ProgressHandler progressCallback);
		
		Task DoRemove(Context ctx, Identifier id, LogHandler logCallback, ProgressHandler progressCallback);
	}
}
