using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan {
	
	public interface IRemoteRegistry : IRegistry {
		
		Task<PartialArray<RemotePackageInfo>> ListPackages(Context ctx, 
             string keyword = "", string category = "", int offset = 0, int limit = 0);
		
		Task<RemotePackageInfo> QueryPackage(Context ctx, Identifier id);
		
	}
}
