using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zbx1425.PWPackMan;
using OpenBveApi.Interface;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;


[assembly: ContractNamespaceAttribute("http://www.zbx1425.tk/bve", ClrNamespace = "Zbx1425.XliffTranslation")]
namespace Zbx1425.XliffTranslation {
  
	public class XliffTranslation : ITranslation {
		
		public string LanguageCode { get; set; }
		
		private object availableLanguages {
			get {
				// HACK: Accessing private field, I hope Mr.leezer3 can make OpenBveApi more public...
				return typeof(Translations)
					.GetField("AvailableLanguages", BindingFlags.NonPublic | BindingFlags.Static)
					.GetValue(null);
			}
		}
  
		public XliffTranslation() {
			LanguageCode = "en-US";
			int languageCount = (int)(availableLanguages.GetType().GetProperty("Count").GetValue(availableLanguages));
			if (languageCount < 1) {
				Translations.LoadLanguageFiles("Data/Languages");
			}
			/* DEBUG
			using (FileStream stream = new FileStream("Data/Languages/zh-CN.xlf", FileMode.Open, FileAccess.Read))
			using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8)) {
				var langType = Type.GetType("OpenBveApi.Interface.Translations+Language, OpenBveApi");
				var ci = langType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
				var lang = ci.Invoke(new object[] {reader, "zh-CN"});
			}
			*/
			IsFromAutoDetect = true; // Manual config of language is not allowed
		}
		
		public XliffTranslation(string langCode)
			: this() {
			LanguageCode = langCode;
		}

		public string Translate(string id) {
			SwitchToLanguage();
			return AdaptNewLine(Translations.GetInterfaceString(id));
		}

		public string Translate(string id, params object[] args) {
			SwitchToLanguage();
			return string.Format(AdaptNewLine(Translations.GetInterfaceString(id)), args);
		}
		
		private string AdaptNewLine(string src) {
			return src.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
		}

		public bool ShowConfigWindow(IWin32Window owner, ITranslation i18n) {
			MessageBox.Show(owner, "There's nothing to be configured.", "XLiff",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
			return false;
		}
		
		public bool CheckConfig() {
			return File.Exists("Data/Languages/" + LanguageCode + ".xlf");
		}

		public IRegistry[] AutoDetect() {
			var languages = new List<XliffTranslation>();
			foreach (var lang in availableLanguages as IEnumerable) {
				string langCode = lang.GetType().GetField("LanguageCode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(lang) as string;
				languages.Add(new XliffTranslation(langCode));
			}
			var userLangName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
			var userLangName2 = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
			XliffTranslation matchingLanguage = 
				languages.FirstOrDefault(l => l.LanguageCode == userLangName) ??
				languages.FirstOrDefault(l => l.LanguageCode.StartsWith(userLangName2, StringComparison.OrdinalIgnoreCase)) ??
				languages.FirstOrDefault(l => l.LanguageCode == "en-US");
			if (matchingLanguage == null)
				throw new Exception("Fatal: No language available.");
			languages.Remove(matchingLanguage);
			languages.Insert(0, matchingLanguage);
			return languages.ToArray();
		}

		public string PlatformName { get { return "xliff"; } }

		public bool IsFromAutoDetect { get; set; }
		
		private void SwitchToLanguage() {
			if (Translations.CurrentLanguageCode != LanguageCode) {
				// OpenBveApi.Interface.Translations is static, so we should switch it over
				Translations.SetInGameLanguage(LanguageCode);
				Translations.CurrentLanguageCode = LanguageCode;
			}
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj) {
			XliffTranslation other = obj as XliffTranslation;
			if (other == null)
				return false;
			return this.LanguageCode == other.LanguageCode;
		}

		public override int GetHashCode() {
			int hashCode = 0;
			unchecked {
				if (LanguageCode != null)
					hashCode += LanguageCode.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(XliffTranslation lhs, XliffTranslation rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(XliffTranslation lhs, XliffTranslation rhs) {
			return !(lhs == rhs);
		}

		#endregion
		
		public override string ToString() {
			SwitchToLanguage();
			return Translate("bpmplugin_languagename");
		}
		
	}
}
