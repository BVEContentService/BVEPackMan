
using System;
using System.Drawing;
using System.Windows.Forms;
using Zbx1425.PWPackMan;
using Zbx1425.PackManGui.Plugin;

namespace Zbx1425.PackManGui
{
	/// <summary>
	/// Description of SettingForm.
	/// </summary>
	public partial class SettingForm : Form
	{
		public SettingForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			foreach (ITranslation trans in RegistryManager.Translations) {
				comboLanguage.Items.Add(trans.ToString());
			}
			comboLanguage.SelectedIndex = RegistryManager.Translations.IndexOf(PreferenceManager.Config.Translation);
			foreach (IRemoteRegistry registry in RegistryManager.Config.RemoteRegisteries) {
				comboRemoteRegistry.Items.Add(I._("bpmplugin_" + registry.PlatformName + "_friendlyname") + " " + registry.ToString());
			}
			comboRemoteRegistry.SelectedIndex = RegistryManager.Config.RemoteRegisteries.IndexOf(PreferenceManager.Config.RemoteRegistry);
		}
		void ComboLanguageSelectedIndexChanged(object sender, EventArgs e) {
			PreferenceManager.Config.Translation = RegistryManager.Translations[comboLanguage.SelectedIndex];
		}
		void ComboRemoteRegistrySelectedIndexChanged(object sender, EventArgs e) {
			PreferenceManager.Config.RemoteRegistry = RegistryManager.Config.RemoteRegisteries[comboRemoteRegistry.SelectedIndex];
		}
		void BtnConfigRemoteClick(object sender, EventArgs e) {
			RegistryManager.Config.RemoteRegisteries[comboLanguage.SelectedIndex].ShowConfigWindow(this, PreferenceManager.Config.Translation);
		}
	}
}
