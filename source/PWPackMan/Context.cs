using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using Zbx1425.PWPackMan.Exceptions;
using Zbx1425.PWPackMan.IO;

namespace Zbx1425.PWPackMan {
	
	public class Context {
		
		public ILocalRegistry LocalRegistry { get; set; }
		
		public IRemoteRegistry RemoteRegistry { get; set; }
		
		public ITranslation Translation { get; set; }
		
		public Context(ILocalRegistry localRegistry, IRemoteRegistry remoteRegistry, ITranslation translation = null)
			: base() {
			LocalRegistry = localRegistry;
			RemoteRegistry = remoteRegistry;
			Translation = translation;
		}
		
		private readonly Dictionary<Identifier, RemotePackageInfo> remotePackQueryCache = new Dictionary<Identifier, RemotePackageInfo>();
		
		public async Task DoInstall(Identifier id, VersionRange range, LogHandler logCallback, ProgressHandler progressCallback) {
			// TODO: Throw exception on circular reference
			
			var resolveQueue = new Queue<Tuple<Identifier, VersionRange, string>>();
			var revInstallSequence = new List<string>();
			resolveQueue.Enqueue(new Tuple<Identifier, VersionRange, string>(id, range, ""));
			while (resolveQueue.Count > 0) {
				var elem = resolveQueue.Dequeue();
				RemotePackageInfo remotePack = null;
				if (!elem.Item1.HasGuid || !elem.Item1.HasName) {
					// Get the full identifier first, so that installed package can be queried better
					logCallback(LogLevel.Info, Translation.Translate("bpmcore_context_downloadmetadata", elem.Item1));
					remotePack = await CachedQueryRemotePackage(elem.Item1);
					if (remotePack == null) {
						if (string.IsNullOrEmpty(elem.Item3)) {
							throw new PackageNotFoundException(this, elem.Item1);
						} else {
							throw new DependencyException(this, elem.Item1.ToString(), elem.Item3, new PackageNotFoundException(this, elem.Item1));
						}
					} else {
						var newIdentifier = elem.Item1;
						if (!newIdentifier.HasGuid && remotePack.ID.HasGuid) {
							newIdentifier.Guid = remotePack.ID.Guid;
							newIdentifier.HasGuid = true;
						}
						if (!newIdentifier.HasName && remotePack.ID.HasName) {
							newIdentifier.Name = remotePack.ID.Name;
							newIdentifier.HasName = true;
						}
						elem = new Tuple<Identifier, VersionRange, string>(newIdentifier, elem.Item2, elem.Item3);
					}
				}
				var installedPackInfo = LocalRegistry.QueryInstalledPackage(this, elem.Item1);
				
				// Skip if the dependency is already installed and the version satisfies the requirement
				if (installedPackInfo != null && elem.Item2.MatchVersion(installedPackInfo.Version)) {
					logCallback(LogLevel.Debug, Translation.Translate("bpmcore_context_alreadyinstalled", elem.Item1.ToString(), installedPackInfo.Version));
					continue;
				}
				
				// Get the remote metadata
				if (remotePack == null) {
					logCallback(LogLevel.Info, Translation.Translate("bpmcore_context_downloadmetadata", elem.Item1));
					remotePack = await CachedQueryRemotePackage(elem.Item1);
					if (remotePack == null) {
						if (string.IsNullOrEmpty(elem.Item3)) {
							throw new PackageNotFoundException(this, elem.Item1);
						} else {
							throw new DependencyException(this, elem.Item1.ToString(), elem.Item3, new PackageNotFoundException(this, elem.Item1));
						}
					}
				}
				// Check other dependncies for a highest suitable version
				var installable = DependencyHelper.GetSuitableVersion(this, remotePack, elem.Item3, elem.Item2);
				logCallback(LogLevel.Info, Translation.Translate("bpmcore_context_willinstall", elem.Item1, installable.Item1));
				if (installable.Item1 < remotePack.AvailableVersions.Keys.Last()) {
					logCallback(LogLevel.Warning, Translation.Translate("bpmcore_context_cannotlatest",
						remotePack.AvailableVersions.Keys.Last(), remotePack.ID));
				}
				
				// Download the file from internet
				logCallback(LogLevel.Info, Translation.Translate("bpmcore_context_downloading", installable.Item2));
				var tempFile = await DownloadManager.AcquirePackage(this, elem.Item1, installable.Item1, installable.Item2, progressCallback);
				// Push further dependencies into the queue
				var packInfo = LocalRegistry.QueryExternalPackage(this, tempFile);
				logCallback(LogLevel.Debug, Translation.Translate("bpmcore_context_requires", packInfo.ID, string.Join(",", packInfo.Dependencies.Select(t => t.Key.ToString() + t.Value))));
				foreach (var dependency in packInfo.Dependencies) {
					resolveQueue.Enqueue(new Tuple<Identifier, VersionRange, string>(dependency.Key, dependency.Value, packInfo.PlainName));
				}
				
				if (revInstallSequence.Contains(tempFile))
					revInstallSequence.Remove(tempFile);
				revInstallSequence.Add(tempFile);
			}

			revInstallSequence.Reverse();
			foreach (var tempFile in revInstallSequence) {
				// Let the LocalRegistry decide if removal is needed
				logCallback(LogLevel.Info, Translation.Translate("bpmcore_context_installing", tempFile));
				await LocalRegistry.DoInstall(this, tempFile, logCallback, progressCallback);
				System.IO.File.Delete(tempFile);
			}
		}
		
		public async Task DoRemove(Identifier id, LogHandler logCallback, ProgressHandler progressCallback) {
			var installedPackInfo = LocalRegistry.QueryInstalledPackage(this, id);
			DependencyHelper.CheckCanRemove(this, id);
			await LocalRegistry.DoRemove(this, id, logCallback, progressCallback);
		}
		
		public void ResetTransactionCache() {
			remotePackQueryCache.Clear();
		}
		
		public async Task<RemotePackageInfo> CachedQueryRemotePackage(Identifier id) {
			if (remotePackQueryCache.ContainsKey(id)) {
				return remotePackQueryCache[id];
			} else {
				var result = await RemoteRegistry.QueryPackage(this, id);
				remotePackQueryCache.Add(id, result);
				return result;
			}
		}
		
	}
}
