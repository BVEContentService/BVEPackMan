using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using Zbx1425.PWPackMan.Exceptions;

namespace Zbx1425.PWPackMan {
	
	internal static class DependencyHelper {
		
		internal static Tuple<Version, string> GetSuitableVersion(Context ctx, RemotePackageInfo remotePack,
			string dependant, VersionRange range) {
			var rangeMap = new Dictionary<VersionRange, HashSet<string>>(); // Value is for blaming packages
			rangeMap.Add(range, new HashSet<string>());
			rangeMap[range].Add(dependant);
			
			// Collect version requirements of other installed packages
			foreach (LocalPackageInfo localPack in ctx.LocalRegistry.ListPackages(ctx)) {
				if (localPack.Dependencies.ContainsKey(remotePack.ID)) {
					if (!rangeMap.ContainsKey(localPack.Dependencies[remotePack.ID])) {
						rangeMap.Add(localPack.Dependencies[remotePack.ID], new HashSet<string>());
					}
					rangeMap[localPack.Dependencies[remotePack.ID]].Add(localPack.PlainName);
				}
			}
			Tuple<VersionRange, string[]>[] rangeMapArray = rangeMap
				.OrderBy(pair => pair.Value.Count)
				.Select(pair => new Tuple<VersionRange, string[]>(pair.Key, pair.Value.ToArray()))
		        .ToArray();
			
			// Narrower the allowed range, from least common range to most common
			var allowedRange = new VersionRange(null, null);
			var rangesToBlame = new List<Tuple<VersionRange, string[]>>();
			for (int i = 0; i < rangeMapArray.Length; i++) {
				Tuple<VersionRange, string[]> rangeItem = rangeMapArray[i];
				var narrowResult = NarrowerRange(allowedRange, rangeItem.Item1);
				if (narrowResult.Item2) {
					allowedRange = narrowResult.Item1;
					rangesToBlame.Add(rangeItem);
					// Minimum greater than Maximum, or there is not a downloadable package sitting between the bounds
					if (!narrowResult.Item3 || !GetVersionInRange(remotePack.AvailableVersions, allowedRange).Item2) {
						throw new DependencyException(ctx, remotePack.PlainName, dependant, new RangeNotSatisfiableException(ctx, allowedRange, rangesToBlame));
					}
				}
			}
			return GetVersionInRange(remotePack.AvailableVersions, allowedRange).Item1;
		}
		
		internal static void CheckCanRemove(Context ctx, Identifier id) {
			var installedPack = ctx.LocalRegistry.QueryInstalledPackage(ctx, id);
			if (installedPack == null)
				throw new PackageNotFoundException(ctx, id);
			var packagesToBlame = new List<string>();
			foreach (LocalPackageInfo localPack in ctx.LocalRegistry.ListPackages(ctx)) {
				if (localPack.Dependencies.ContainsKey(id)) {
					packagesToBlame.Add(localPack.PlainName);
				}
			}
			if (packagesToBlame.Count > 0) {
				throw new DependencyException(ctx, id.ToString(), "", new DependentExistException(ctx, packagesToBlame));
			}
		}
		
		private static Tuple<VersionRange, bool, bool> NarrowerRange(VersionRange a, VersionRange b) {
			bool narrowed = false;
			VersionRange result = a;
			if ((a.Minimum == null && b.Minimum != null) ||
			    (a.Minimum != null && b.Minimum != null && a.Minimum < b.Minimum)) {
				narrowed = true;
				result.Minimum = b.Minimum;
			}
			if ((a.Maximum == null && b.Maximum != null) ||
			    (a.Minimum != null && b.Minimum != null && a.Maximum > b.Maximum)) {
				narrowed = true;
				result.Maximum = b.Maximum;
			}
			// Result, IsNarrowed, IsValid
			return new Tuple<VersionRange, bool, bool>(result, narrowed, 
				!(result.Minimum != null && result.Maximum != null && result.Minimum > result.Maximum));
		}
		
		private static Tuple<Tuple<Version, string>, bool> 
			GetVersionInRange(SortedDictionary<Version, string> availableVersions, VersionRange range) {
			for (int i = availableVersions.Count - 1; i >= 0; i--) {
				foreach (KeyValuePair<Version, string> pair in availableVersions.Reverse()) {
					if (range.MatchVersion(pair.Key)) {
						return new Tuple<Tuple<Version, string>, bool>(new Tuple<Version, string>(pair.Key, pair.Value), true);
					}
				}
			}
			// Result, Found
			return new Tuple<Tuple<Version, string>, bool>(default(Tuple<Version, string>), false);
		}
	}
}
