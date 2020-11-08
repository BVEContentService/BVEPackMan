using System;
using System.Linq;
using System.Collections.Generic;
using Zbx1425.PWPackMan.Models;

namespace Zbx1425.PackManGui {
  
	public class PackageListBox : PropertyListBox {
		
		public Dictionary<Identifier, Version> LatestVersions = new Dictionary<Identifier, Version>();
  
		protected override Tuple<string, string>[] getProperties(object obj) {
			string[] hiddenProps = { "PlainName", "Version", "Dependencies", "Category" };
			return obj.GetType().GetProperties()
				.Where(p => !hiddenProps.Contains(p.Name) && p.GetValue(obj) != null)
				.Select(p => new Tuple<string, string>(p.Name, p.GetValue(obj).ToString()))
				.ToArray();
		}
		
		protected override string getTitle(object obj) {
			return (obj as LocalPackageInfo).PlainName;
		}
		
		protected override string getSubtitle(object obj) {
			return (obj as LocalPackageInfo).Category + " " + (obj as LocalPackageInfo).Version.ToString();
		}
		
		protected override string getWarnText(object obj) {
			var objId = (obj as LocalPackageInfo).ID;
			if (LatestVersions.ContainsKey(objId) && LatestVersions[objId] > (obj as LocalPackageInfo).Version) {
				// TODO: I18n
				return string.Format("Upgrade Available: {0}", LatestVersions[objId].ToString());
			} else {
				return "";
			}
		}
		
		protected override bool isBelowHeader(object obj) {
			return false;
		}
		
		protected override string getHeaderText() {
			return "";
		}
	}
}
