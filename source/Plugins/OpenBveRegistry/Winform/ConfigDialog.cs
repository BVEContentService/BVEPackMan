
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Zbx1425.PWPackMan;

namespace Zbx1425.OpenBveRegistry {
	/// <summary>
	/// Description of ConfigDialog.
	/// </summary>
	public partial class ConfigDialog : Form {
		
		private OpenBveLocalRegistry registry;
		private OpenBveLocalRegistry checkRegistry = new OpenBveLocalRegistry();
		private ITranslation i18n;
		
		public ConfigDialog(ITranslation i18n, OpenBveLocalRegistry registry) {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			foreach (Control ctrl1 in Controls) {
				if (!string.IsNullOrEmpty(ctrl1.Tag as string))
					ctrl1.Text = i18n.Translate("bpmplugin_openbve_configform_" + ctrl1.Tag as string);
				foreach (Control ctrl2 in ctrl1.Controls) {
					if (!string.IsNullOrEmpty(ctrl2.Tag as string))
						ctrl2.Text = i18n.Translate("bpmplugin_openbve_configform_" + ctrl2.Tag as string);
				}
			}
			Text = i18n.Translate("bpmplugin_openbve_configform_title", registry.GetHashCode().ToString("X8"));
			
			this.registry = registry;
			this.i18n = i18n;
			textDatabase.Text = registry.DatabaseFolder;
			textRailway.Text = registry.RouteInstallationDirectory;
			textTrain.Text = registry.TrainInstallationDirectory;
			textOther.Text = registry.OtherInstallationDirectory;
			textLoksim.Text = registry.LoksimPackageInstallationDirectory;
		}
		
		private void ApplyToRegistry(ref OpenBveLocalRegistry reg) {
			reg.DatabaseFolder = textDatabase.Text;
			reg.RouteInstallationDirectory = textRailway.Text;
			reg.TrainInstallationDirectory = textTrain.Text;
			reg.OtherInstallationDirectory = textOther.Text;
			reg.LoksimPackageInstallationDirectory = textLoksim.Text;
		}
		
		void BtnOKClick(object sender, EventArgs e) {
			ApplyToRegistry(ref checkRegistry);
			if (checkRegistry.CheckConfig()) {
				ApplyToRegistry(ref registry);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		private Color[] btnColors = {
			Color.FromArgb(121, 121, 105),
			Color.FromArgb(221, 221, 205)
		};
		void TextBoxTextChanged(object sender, EventArgs e) {
			ApplyToRegistry(ref checkRegistry);
			var isValid = checkRegistry.CheckConfig();
			if (isValid) {
				Text = i18n.Translate("bpmplugin_openbve_configform_title", checkRegistry.GetHashCode().ToString("x8"));
			} else {
				Text = i18n.Translate("bpmplugin_openbve_configform_title", "Invalid!");
			}
			btnOK.Enabled = isValid;
			btnOK.BackColor = btnColors[isValid ? 1 : 0];
		}
		
		void BrowseBtnClick(object sender, EventArgs e) {
			var target = grpInsDir.Controls[(sender as Button).Name.Replace("btn", "text")] as TextBox;
			var fbd = new OpenBve.FolderSelectDialog();
			var dir = target.Text;
			if (!OpenBveLocalRegistry.IsPathValid(dir)) {
				dir = "";
			} else {
				while (!Directory.Exists(dir)){
					dir = dir == Path.GetDirectoryName(dir) ? "" : Path.GetDirectoryName(dir);
				}
			}
			fbd.InitialDirectory = dir;
			if (fbd.Show()) {
				target.Text = fbd.FileName;
			}
		}
		
		void BtnDatabaseClick(object sender, EventArgs e) {
			var dir = textDatabase.Text;
			if (!OpenBveLocalRegistry.IsPathValid(dir)) {
				dir = "";
			} else {
				while (!Directory.Exists(dir)){
					dir = dir == Path.GetDirectoryName(dir) ? "" : Path.GetDirectoryName(dir);
				}
			}
			var ofd = new OpenFileDialog() {
				Filter = "Packages.xml|packages.xml",
				InitialDirectory = dir
			};
			if (ofd.ShowDialog() == DialogResult.OK) {
				textDatabase.Text = Path.GetDirectoryName(ofd.FileName);
			}
		}
	}
}
