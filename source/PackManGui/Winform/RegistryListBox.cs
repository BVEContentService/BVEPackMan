using System;
using System.Linq;
using Zbx1425.PWPackMan;


namespace Zbx1425.PackManGui {
  
	public class RegistryListBox : PropertyListBox {
  		
		protected override Tuple<string, string>[] getProperties(object obj) {
			string[] hiddenProps = { "PlatformName", "IsFromAutoDetect" };
			return obj.GetType().GetProperties()
				.Where(p => !hiddenProps.Contains(p.Name))
				.Select(p => new Tuple<string, string>(p.Name, p.GetValue(obj) == null ? "(NULL)" :  p.GetValue(obj).ToString()))
				.ToArray();
		}
		
		protected override string getTitle(object obj) {
			return I._("bpmplugin_" + (obj as IRegistry).PlatformName + "_friendlyname");
		}
		
		protected override string getSubtitle(object obj) {
			return obj.GetHashCode().ToString("X8");
		}
		
		protected override string getWarnText(object obj) {
			return (obj as IRegistry).IsFromAutoDetect ? I._("bpmgui_reglistbox_warnautodet") : "";
		}
		
		protected override bool isBelowHeader(object obj) {
			return (obj as IRegistry).IsFromAutoDetect;
		}
		
		protected override string getHeaderText() {
			return I._("bpmgui_reglistbox_headerautodet");
		}
	}
}
