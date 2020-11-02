using System;
using Zbx1425.PackManGui.Plugin;

namespace Zbx1425.PackManGui {
  	
	// Shorthand to handle translation
	
	internal static class I {
  		
		public static string _(string id) {
			return PreferenceManager.CurrentTranslation.Translate(id);
		}
		
		public static string _(string id, params object[] args) {
			return PreferenceManager.CurrentTranslation.Translate(id, args);
		}
	}
}
