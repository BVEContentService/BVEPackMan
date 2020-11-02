using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zbx1425.PWPackMan;
using OpenBveApi.Interface;
using System.Reflection;

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
			IsFromAutoDetect = true; // Manual config of language is not allowed
		}
		
		public XliffTranslation(string langCode) : this() {
			LanguageCode = langCode;
		}

		public string Translate(string id) {
			SwitchToLanguage();
			return Translations.GetInterfaceString(id);
		}

		public string Translate(string id, params object[] args) {
			SwitchToLanguage();
			return string.Format(Translations.GetInterfaceString(id), args);
		}

		public void ShowConfigWindow(IWin32Window owner) {
			MessageBox.Show(owner, "There's nothing to be configured.", "XLiff",
			                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		public string WriteConfig() {
			return LanguageCode;
		}

		public void ReadConfig(string config) {
			LanguageCode = config.Trim();
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
		
	}
}
