using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Windows.Forms;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using Zbx1425.BveCSRegistry.Models;
using Zbx1425.BveCSRegistry.Utilities;

namespace Zbx1425.BveCSRegistry {
	
	public class BCSRemoteRegistry : IRemoteRegistry {
		
        private static readonly HttpClient httpClient = new HttpClient();
		
		private string _apiBaseUrl;

		public bool IsFromAutoDetect { get; set; }
		
		public string ApiBaseUrl {
			get {
				return _apiBaseUrl;
			}
			set {
				_apiBaseUrl = value.TrimEnd('/');
			}
		}
	
		public BCSRemoteRegistry() {
			
		}
		
		public BCSRemoteRegistry(string apiBaseUrl) {
			_apiBaseUrl = apiBaseUrl;
		}

		public string PlatformName { get { return "bvecs"; } }
		
		public void ShowConfigWindow(IWin32Window owner) {
			
		}

		public IRegistry[] AutoDetect() {
			var defaultReg = new BCSRemoteRegistry("https://api.bvecs.tk/v1");
			defaultReg.IsFromAutoDetect = true;
			return new IRegistry[] { defaultReg };
		}
		
		public async Task<PartialArray<RemotePackageInfo>> ListPackages(Context ctx, 
			string keyword = "", string category = "", int offset = 0, int limit = 0) {
			var url = ApiBaseUrl + "/packages?platform=" + Uri.EscapeDataString(ctx.LocalRegistry.PlatformName);
			if (keyword != "")
				url += "&keyword=" + Uri.EscapeDataString(keyword);
			if (category != "")
				url += "&category=" + Uri.EscapeDataString(category);
			
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			if (offset != 0)
				request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(offset, offset + limit);
			
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)0x3ff0;
			HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
			if (!response.IsSuccessStatusCode)
				throw new HttpException((int)response.StatusCode + " " + response.ReasonPhrase);
			int totalLength = (int)response.Content.Headers.ContentRange.Length;
			string data = await response.Content.ReadAsStringAsync();
			XmlDocument dataDoc = new XmlDocument();
			dataDoc.LoadXml(data);
			
			var packageNodes = dataDoc.FirstChild.ChildNodes;
			var packageList = new List<RemotePackageInfo>();
            var packageSerializer = new ParamXmlSerializer(ctx.LocalRegistry.PlatformName, typeof(Package));
            foreach (var node in packageNodes) {
                var wrapper = new System.IO.StringReader(((XmlElement)node).OuterXml);
				packageList.Add((Package)packageSerializer.Deserialize(wrapper));
			}
			return new PartialArray<RemotePackageInfo>(packageList, totalLength);
		}
		
		public async Task<RemotePackageInfo> QueryPackage(Context ctx, Identifier id) {
            var url = ApiBaseUrl + "/packages/";
            if (id.HasGuid) {
                url += id.Guid.ToString("N").ToLowerInvariant();
            } else if (id.HasName) {
                url += Uri.EscapeDataString(id.Name);
            } else {
                throw new ArgumentNullException();
            }

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)0x3ff0;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) {
                if (response.StatusCode == HttpStatusCode.NotFound) {
                    return null;
                } else {
                    throw new HttpException((int)response.StatusCode + " " + response.ReasonPhrase);
                }
            }
            string data = await response.Content.ReadAsStringAsync();
       
            var packageSerializer = new ParamXmlSerializer(ctx.LocalRegistry.PlatformName, typeof(Package));
            var wrapper = new System.IO.StringReader(data);
            return (Package)packageSerializer.Deserialize(wrapper);
        }

        public string WriteConfig() {
            return ApiBaseUrl;
        }

        public void ReadConfig(string config) {
            ApiBaseUrl = config.Trim();
        }
    }
}
