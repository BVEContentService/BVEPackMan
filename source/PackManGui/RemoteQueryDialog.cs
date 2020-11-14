
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PackManGui.Plugin;

namespace Zbx1425.PackManGui {
	/// <summary>
	/// Description of RemoteQueryDialog.
	/// </summary>
	public partial class RemoteQueryDialog : Form {
		
		private readonly Context ctx;
		private readonly ITranslation i18n;
		private readonly ILocalRegistry localReg;
		private readonly IRemoteRegistry remoteReg;
		private readonly bool updowngrade;
		
		private Color accentColor = Color.FromArgb(80, 205, 206);
		
		private Label progressLabel;
		
		public Identifier SelectedIdentifier { get; private set; }
		
		public Version SelectedVersion { get; private set; }
		
		public RemoteQueryDialog(Context ctx, Identifier id = default(Identifier), bool updowngrade = false) {
			this.Font = new Font(SystemFonts.CaptionFont.FontFamily, 12F, FontStyle.Regular, GraphicsUnit.Pixel);
			InitializeComponent();
			
			this.ctx = ctx;
			this.i18n = ctx.Translation;
			this.localReg = ctx.LocalRegistry;
			this.remoteReg = ctx.RemoteRegistry;
			this.SelectedIdentifier = id;
			this.updowngrade = updowngrade;
		}
		
		async void RemoteQueryDialogLoad(object sender, EventArgs e) {
			if (SelectedIdentifier != default(Identifier)) {
				textName.Text = SelectedIdentifier.Name;
				btnSearch.Enabled = textName.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
				textName.Text = SelectedIdentifier.GuidOrName();
				showProgress("TODO: Loading. Please wait...");
				try {
					await fetchPack(SelectedIdentifier);
					if (updowngrade) {
						mainTabControl.SelectedTab = tabPageVerSel;
					}
				} catch (Exception ex) {
					showProgress(ex.ToString());
					btnSearch.Enabled = true;
				}
				btnCancel.Enabled = true;
			} else {
				btnOK.Enabled = false;
				showProgress("TODO: Please enter package identifier name and press 'Search'.");
			}
		}
		
		private void showProgress(string text) {
			if (progressLabel == null) {
				progressLabel = new Label() {
					Dock = DockStyle.Fill,
					AutoSize = false,
					Padding = new Padding(20),
					ForeColor = accentColor,
					Font = new Font(this.Font.FontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel),
				};
			}
			progressLabel.Text = text;
			if (!Controls.Contains(progressLabel)) {
				if (Controls.Contains(mainTabControl))
					Controls.Remove(mainTabControl);
				Controls.Add(progressLabel);
				progressLabel.BringToFront();
			}
		}
		
		private void showResult() {
			if (!Controls.Contains(mainTabControl)) {
				if (Controls.Contains(progressLabel))
					Controls.Remove(progressLabel);
				Controls.Add(mainTabControl);
				mainTabControl.BringToFront();
			}
		}
		
		private void inflateUI(RemotePackageInfo pack) {
			var rangeTuple = DependencyHelper.GetSuitableRange(ctx, pack);
			var suitableRange = rangeTuple.Item1;
			var packagesToBlame = rangeTuple.Item2;
			
			Font biggerFont = new Font(this.Font.FontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel);
			infoPanel.Controls.Clear();
			versionPanel.Controls.Clear();
			if (pack == null)
				return;
			int rownum = 0;
			string[] blacklist = new[] {
				"Files",
				"AvailableVersions",
				"ForcePopup"
			};
			infoPanel.SuspendLayout();
			foreach (var prop in pack.GetType().GetProperties()) {
				var value = prop.GetValue(pack);
				if (blacklist.Contains(prop.Name))
					continue;
				if (value == null)
					continue;
				infoPanel.Controls.Add(new Label() {
					Text = prop.Name,
					Font = biggerFont,
					ForeColor = accentColor,
					Margin = new Padding(3)
				}, 0, rownum);
				infoPanel.Controls.Add(new Label() {
					Text = value.ToString(),
					Font = biggerFont,
					Margin = new Padding(3)
				}, 1, rownum);
				rownum++;
			}
			infoPanel.ResumeLayout();
			int vernum = 0;
			bool foundLatestAvailableVersion = false;
			foreach (var ver in pack.AvailableVersions.Reverse()) {
				var text = ver.Key.ToString();
				if (vernum == 0)
					text += " (Latest)";
				bool versionValid = suitableRange.ContainsVersion(ver.Key);
				if (versionValid && !foundLatestAvailableVersion && vernum > 0) {
					text += " (Latest Installable)";
				}
				versionPanel.Controls.Add(new RadioButton() {
					Size = new Size(300, 30),
					Enabled = versionValid,
					Checked = versionValid && !foundLatestAvailableVersion,
					Font = biggerFont,
					Tag = ver.Key,
					Text = text
				});
				foundLatestAvailableVersion |= versionValid;
				vernum++;
			}
			btnOK.Enabled = foundLatestAvailableVersion;
			bool hasWarning = !foundLatestAvailableVersion || !suitableRange.ContainsVersion(pack.AvailableVersions.Last().Key);
			if (hasWarning) {
				if (!mainTabControl.TabPages.Contains(tabPageWarning))
					mainTabControl.TabPages.Insert(0, tabPageWarning);
				mainTabControl.SelectedIndex = 0;
				var sb = new System.Text.StringBuilder();
				if (foundLatestAvailableVersion) {
					sb.AppendLine(I._("bpmcore_context_cannotlatest",
						pack.AvailableVersions.Keys.Last(), pack.ID));
				} else {
					if (!suitableRange.NotEmpty) {
						sb.AppendLine(I._("bpmcore_exception_badrange1"));
					} else {
						sb.AppendLine(I._("bpmcore_exception_badrange2"));
					}
				}
				sb.AppendLine(I._("bpmcore_exception_blame"));
				foreach (var item in packagesToBlame) {
					sb.AppendLine(I._("bpmcore_exception_constraint", item.Item1.ToString(), 
						string.IsNullOrEmpty(item.Item2[0]) ? I._("bpmcore_exception_userconstraint") : item.Item2[0],
						item.Item2.Length > 1 ? "...(" + (item.Item2.Length - 1).ToString() + "+)" : ""));
				}
				textWarn.Font = biggerFont;
				textWarn.Text = sb.ToString();
			} else {
				if (mainTabControl.TabPages.Contains(tabPageWarning))
					mainTabControl.TabPages.Remove(tabPageWarning);
			}
		}
		
		async void BtnSearchClick(object sender, EventArgs e) {
			bool wasTextNameEnabled = textName.Enabled;
			btnSearch.Enabled = textName.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
			showProgress("TODO: Loading. Please wait...");
			Guid guid;
			try {
				if (Guid.TryParse(textName.Text, out guid)) {
					await fetchPack(new Identifier(guid));
				} else {
					await fetchPack(new Identifier(textName.Text));
				}
				btnSearch.Enabled = textName.Enabled = btnCancel.Enabled = true;
			} catch (Exception ex) {
				showProgress(ex.ToString());
				btnSearch.Enabled = btnCancel.Enabled = true;
				textName.Enabled = wasTextNameEnabled;
			}
		}
		
		async Task fetchPack(Identifier id) {
			var ctx = new Context(localReg, remoteReg, i18n);
			RemotePackageInfo pack = await remoteReg.QueryPackage(ctx, id);
			if (pack == null || pack.AvailableVersions.Count < 1) {
				SelectedIdentifier = default(Identifier);
				btnOK.Enabled = false;
				showProgress("TODO: Not Found");
			} else {
				SelectedIdentifier = pack.ID;
				btnOK.Enabled = true;
				showResult();
			}
			inflateUI(pack);
		}
		
		void BtnOKClick(object sender, EventArgs e) {
			// TODO: Force Popup
			foreach (var rbtn in versionPanel.Controls) {
				if ((rbtn as RadioButton).Checked) {
					SelectedVersion = (rbtn as RadioButton).Tag as Version;
				}
			}
			this.DialogResult = DialogResult.OK;
			Close();
		}
		
		void BtnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			Close();
		}
		void InfoPanelResize(object sender, EventArgs e) {
			if (infoPanel.Width == 0)
				return;
			float fWidth = infoPanel.Width - infoPanel.GetColumnWidths()[0];
			foreach (Control ctr in infoPanel.Controls) {
				if (ctr is Label) {
					// -6 for margins
					Size s = TextRenderer.MeasureText(ctr.Text, ctr.Font, new Size((int)fWidth - 6, 1000),
						         TextFormatFlags.VerticalCenter
						         | TextFormatFlags.Left
						         | TextFormatFlags.NoPadding
						         | TextFormatFlags.WordBreak);
					if (!ctr.Size.Equals(s))
						ctr.Size = new Size(s.Width, s.Height);
				}
			}
		}
	}
}
