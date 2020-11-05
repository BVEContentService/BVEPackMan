
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
		
		private Color accentColor = Color.FromArgb(80, 205, 206);
		
		private Label progressLabel;
		
		public Identifier SelectedIdentifier { get; private set; }
		
		public RemoteQueryDialog(Context ctx, Identifier id = default(Identifier)) {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.ctx = ctx;
			this.i18n = ctx.Translation;
			this.localReg = ctx.LocalRegistry;
			this.remoteReg = ctx.RemoteRegistry;
			this.SelectedIdentifier = id;
			
			if (SelectedIdentifier != default(Identifier)) {
				textName.Text = SelectedIdentifier.Name;
				btnSearch.Enabled = textName.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
				showProgress("TODO: Loading. Please wait...");
				Task.Run(async () => {
					await fetchPack(SelectedIdentifier.Name);
					this.Invoke(new Action(() => {
						btnCancel.Enabled = true;
					}));
				});
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
				if (Controls.Contains(mainTabControl)) Controls.Remove(mainTabControl);
				Controls.Add(progressLabel);
				progressLabel.BringToFront();
			}
		}
		
		private void showResult() {
			if (!Controls.Contains(mainTabControl)) {
				if (Controls.Contains(progressLabel)) Controls.Remove(progressLabel);
				Controls.Add(mainTabControl);
				mainTabControl.BringToFront();
			}
		}
		
		private void inflateUI(RemotePackageInfo pack) {
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
			foreach (var ver in pack.AvailableVersions) {
				var text = ver.Key.ToString();
				if (vernum == 0)
					text += " (Latest)";
				versionPanel.Controls.Add(new RadioButton() {
					Size = new Size(300, 30),
					Checked = vernum == 0,
					Font = biggerFont,
					Tag = ver.Key,
					Text = text
				});
				vernum++;
			}
			bool hasWarning = false;
			if (hasWarning) {
				if (!mainTabControl.TabPages.Contains(tabPageWarning))
					mainTabControl.TabPages.Insert(0, tabPageWarning);
			} else {
				if (mainTabControl.TabPages.Contains(tabPageWarning))
					mainTabControl.TabPages.Remove(tabPageWarning);
			}
		}
		
		async void BtnSearchClick(object sender, EventArgs e) {
			btnSearch.Enabled = textName.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
			showProgress("TODO: Loading. Please wait...");
			await fetchPack(textName.Text);
			btnSearch.Enabled = textName.Enabled = btnCancel.Enabled = true;
		}
		
		async Task fetchPack(string rawID) {
			var ctx = new Context(localReg, remoteReg, i18n);
			RemotePackageInfo pack = await remoteReg.QueryPackage(ctx, new Identifier(rawID));
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
