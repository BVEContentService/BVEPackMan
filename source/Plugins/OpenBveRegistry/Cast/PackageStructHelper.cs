using System;
using System.Linq;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using OpenBveApi.Packages;

namespace Zbx1425.OpenBveRegistry {
  
	internal static class PackageStructHelper {
  
		public static LocalPackageInfo ToPWPackage(Package obPackage) {
			return new LocalPackageInfo {
				ID = new Identifier(new Guid(obPackage.GUID)),
				PlainName = obPackage.Name,
				Version = obPackage.PackageVersion,
				Category = obPackage.PackageType.ToString(),
				AuthorName = obPackage.Author,
				Website = obPackage.Website,
				Description = obPackage.Description,
				Dependencies = obPackage.Dependancies.Concat(obPackage.Reccomendations)
					.ToDictionary<Package, Identifier, VersionRange>(
						pack => new Identifier(new Guid(pack.GUID)),
						pack => new VersionRange(pack.MinimumVersion, pack.MaximumVersion)
				)
			};
		}
	}
}
