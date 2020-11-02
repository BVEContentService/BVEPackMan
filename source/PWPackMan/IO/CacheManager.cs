using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Zbx1425.PWPackMan.Models;

namespace Zbx1425.PWPackMan.IO {
	
	public static class CacheManager {
		
		public static string CachePath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			"Zbx1425.PWPackMan", "DownloadCache");
		
		private static SHA1 hashProvider = new SHA1CryptoServiceProvider();
		
		static CacheManager() {
			if (!Directory.Exists(CachePath)) Directory.CreateDirectory(CachePath);
		}
		
		private static string GetFileName(Context ctx, Identifier id, Version ver) {
			return string.Format("{0}.{1}.{2}.{3}",
                ctx.LocalRegistry.PlatformName, ctx.RemoteRegistry.PlatformName, 
                id.GuidOrName(), ver.ToString());
		}
		
		public static string GetCacheFileName(Context ctx, Identifier id, Version ver) {
			var name = GetFileName(ctx, id, ver);
			return Path.Combine(CachePath, name + ".zip");
		}
		
		public static bool IsCached(Context ctx, Identifier id, Version ver) {
			return File.Exists(GetCacheFileName(ctx, id, ver));
		}
		
		public static string GetDownloadTempFile(Context ctx, Identifier id, Version ver) {
			var name = GetFileName(ctx, id, ver);
			RevokeCacheFile(ctx, id, ver);
			return Path.Combine(CachePath, name + ".tmp");
		}
		
		public static string SubmitDownloadTempFile(Context ctx, Identifier id, Version ver) {
			var name = GetFileName(ctx, id, ver);
			File.Move(Path.Combine(CachePath, name + ".tmp"), Path.Combine(CachePath, name + ".zip"));
			return Path.Combine(CachePath, name + ".zip");
		}
		
		public static void RevokeCacheFile(Context ctx, Identifier id, Version ver) {
			var name = GetFileName(ctx, id, ver);
			if (File.Exists(Path.Combine(CachePath, name + ".tmp"))){
				File.Delete(Path.Combine(CachePath, name + ".tmp"));
			}
			if (File.Exists(Path.Combine(CachePath, name + ".zip"))){
				File.Delete(Path.Combine(CachePath, name + ".zip"));
			}
		}
		
		public static void RevokeAllCacheFiles(bool includingZip = false) {
			foreach (var file in Directory.GetFiles(CachePath)) {
				if (includingZip || Path.GetExtension(file).ToLowerInvariant() != ".zip") {
					File.Delete(file);
				}
			}
		}
	}
}
