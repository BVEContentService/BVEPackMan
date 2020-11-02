using System;
using System.Threading.Tasks;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan.IO {
	
	internal static class DownloadManager {
		
		public static async Task<string> AcquirePackage(Context ctx, Identifier packageID, Version ver,
        	string srcUrl, ProgressHandler callback) {
			if (CacheManager.IsCached(ctx, packageID, ver)) {
				return CacheManager.GetCacheFileName(ctx, packageID, ver);
			}
			var client = new HttpDownload(srcUrl, CacheManager.GetDownloadTempFile(ctx, packageID, ver));
			if (callback != null) client.ProgressChanged += callback;
			await client.StartDownload();
			return CacheManager.SubmitDownloadTempFile(ctx, packageID, ver);
		}
	}
}
