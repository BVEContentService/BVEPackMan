
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PackManGui.Plugin;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PackManGui {
	
	public sealed partial class ManipulationForm : Form {
		
		private ILocalRegistry registry;
		
		private ProgressControl progCtrl;
		private LogHandler pushLog;
		private ProgressHandler pushProgress;
		
		private bool callInstallDlg;
		private Identifier idToInstall;
		
		public ManipulationForm(ILocalRegistry registry, bool callInstallDlg = false, Identifier idToInstall = default(Identifier)) {
			this.Font = new Font(SystemFonts.CaptionFont.FontFamily, 12F, FontStyle.Regular, GraphicsUnit.Pixel);
			InitializeComponent();
			this.registry = registry;
			
			var ctx = new Context(registry, PreferenceManager.Config.RemoteRegistry, 
				          PreferenceManager.Config.Translation);
			comboCategory.Items.Add("(ALL)"); // TODO: I18n
			foreach (var package in registry.ListPackages(ctx)) {
				if (!comboCategory.Items.Contains(package.Category))
					comboCategory.Items.Add(package.Category);
				localPackageListBox.Items.Add(package);
			}
			comboCategory.SelectedIndex = 0;
			
			progCtrl = new ProgressControl() {
				BoxColor = Color.FromArgb(55, 57, 46),
				BarFillColor = Color.FromArgb(80, 205, 206),
				ForeColor = Color.FromArgb(250, 250, 250),
				LogLevel = LogLevel.Debug,
				Dock = DockStyle.Fill
			};
			progCtrl.btnOK.Text = I._("bpmgui_mainform_ok");
			progCtrl.btnCancel.Text = I._("bpmgui_mainform_cancel");
			progCtrl.progressBar.TextColor = Color.Black;
			pushLog = (level, msg) => 
				Invoke((Action<LogLevel, string>)progCtrl.PushList, level, msg);
			pushProgress = (total, finished, ratio) => 
						BeginInvoke((Action<long?, long?, double?>)progCtrl.PushBar, 
				total, finished, ratio);
			
			this.callInstallDlg = callInstallDlg;
			this.idToInstall = idToInstall;
		}
		
		async void ManipulationFormShown(object sender, EventArgs e) {
			if (callInstallDlg) {
				var context = new Context(registry, PreferenceManager.Config.RemoteRegistry,
				              PreferenceManager.Config.Translation);
				var isd = new RemoteQueryDialog(context, idToInstall);
				if (isd.ShowDialog() != DialogResult.OK) {
					this.Close();
					return;
				}
				await installPackage(isd.SelectedIdentifier, isd.SelectedVersion);
			}
		}
		
		private Pen capBorderPen = new Pen(Color.FromArgb(10, 10, 10), 4);
		private Pen capSealPen = new Pen(Color.FromArgb(80, 205, 206), 4);
		void ContextActionPanelPaint(object sender, PaintEventArgs e) {
			e.Graphics.DrawRectangle(capBorderPen, -1, -2, contextActionPanel.Width, contextActionPanel.Height);
			e.Graphics.DrawLine(capSealPen, 174, contextActionPanel.Height - 2, 192, contextActionPanel.Height - 2);
		}
		
		void LocalPackageListBoxSelectedIndexChanged(object sender, EventArgs e) {
			var item = (LocalPackageInfo)localPackageListBox.SelectedItem;
			if (item == null) {
				contextActionPanel.Hide();
				return;
			}
		}
		
		void LocalPackageListBoxDrawItem(object sender, DrawItemEventArgs e) {
			if (e.Index >= localPackageListBox.Items.Count)
				return;
			if (e.Index < 0)
				return;
			if (e.State.HasFlag(DrawItemState.Selected)) {
				if (e.Bounds.Y < 0 || e.Bounds.Y > localPackageListBox.Height) {
					contextActionPanel.Hide();
				} else {
					contextActionPanel.Location = e.Bounds.Location + new Size(localPackageListBox.Location)
					+ new Size(20, -contextActionPanel.Height);
					contextActionPanel.Show();
				}
			}
		}
		void ManipulationFormResizeBegin(object sender, EventArgs e) {
			// Dirty workaround to reduce flickering.
			localPackageListBox.BeginUpdate();
		}
		void ManipulationFormmResizeEnd(object sender, EventArgs e) {
			localPackageListBox.EndUpdate();
		}
		
		void BtnApplyFilterClick(object sender, EventArgs e) {
			var ctx = new Context(registry, PreferenceManager.Config.RemoteRegistry, 
				          PreferenceManager.Config.Translation);
			localPackageListBox.Items.Clear();
			localPackageListBox.SelectedIndex = -1;
			localPackageListBox.SelectedItem = null;
			contextActionPanel.Hide();
			localPackageListBox.Items.AddRange(
				registry.ListPackages(ctx).Where(
					p => (textKeyword.Text == "" || p.PlainName.ToLowerInvariant().Contains(textKeyword.Text.ToLowerInvariant())) &&
					(comboCategory.SelectedIndex == 0 || p.Category == comboCategory.SelectedItem.ToString()))
               .ToArray()
			);
			localPackageListBox.Invalidate();
		}
		
		async Task installPackage(Identifier id, Version ver) {
			var context = new Context(registry, PreferenceManager.Config.RemoteRegistry,
				              PreferenceManager.Config.Translation);
			progCtrl.ResetUI();
			Controls.Add(progCtrl);
			progCtrl.BringToFront();
			try {
				var sequence = await context.DoFetch(id, new VersionRange(ver, ver),
					               pushLog, pushProgress);
				if (sequence.Any()) {
					pushLog(LogLevel.Info, I._("bpmgui_mainform_installconfirm",
						string.Join(Environment.NewLine, sequence.Select(
							t => "  " + t.Item1.ToString() + " " + t.Item2.ToString()
						).ToArray())));
					pushProgress(null, null, 200);
					progCtrl.progressBar.CustomText = I._("bpmgui_msg_info");
					bool shouldContinue = await progCtrl.ShowBtnChoice();
					if (shouldContinue) {
						progCtrl.PushBar(null, null, 0);
						progCtrl.progressBar.CustomText = "";
						await context.DoInstall(sequence, pushLog, pushProgress);
					} else {
						Controls.Remove(progCtrl);
						return;
					}
				}
				pushLog(LogLevel.Info, I._("bpmgui_msg_complete"));
				pushProgress(null, null, 200);
				progCtrl.BarFillColor = Color.LawnGreen;
				progCtrl.progressBar.CustomText = I._("bpmgui_msg_complete");
			} catch (Exception ex) {
				pushLog(LogLevel.Error, ex + Environment.NewLine + ex.Message);
				pushProgress(null, null, 200);
				progCtrl.BarFillColor = Color.Red;
				progCtrl.progressBar.CustomText = I._("bpmgui_msg_err");
				
			}
			await progCtrl.ShowBtnWait();
			Controls.Remove(progCtrl);
			BtnApplyFilterClick(null, null);
		}
		
		async void BtnInstallPackClick(object sender, EventArgs e) {
			var context = new Context(registry, PreferenceManager.Config.RemoteRegistry,
				              PreferenceManager.Config.Translation);
			var isd = new RemoteQueryDialog(context);
			if (isd.ShowDialog() != DialogResult.OK)
				return;
			await installPackage(isd.SelectedIdentifier, isd.SelectedVersion);
		}
		
		async void BtnUpgradeDowngradeClick(object sender, EventArgs e) {
			if (localPackageListBox.SelectedItem == null)
				return;
			var context = new Context(registry, PreferenceManager.Config.RemoteRegistry,
				              PreferenceManager.Config.Translation);
			var isd = new RemoteQueryDialog(context, (localPackageListBox.SelectedItem as LocalPackageInfo).ID, true);
			if (isd.ShowDialog() != DialogResult.OK)
				return;
			await installPackage(isd.SelectedIdentifier, isd.SelectedVersion);
		}
		
		async void BtnUninstallPackClick(object sender, EventArgs e) {
			if (localPackageListBox.SelectedItem == null)
				return;
			var context = new Context(registry, PreferenceManager.Config.RemoteRegistry,
				              PreferenceManager.Config.Translation);
			progCtrl.ResetUI();
			Controls.Add(progCtrl);
			progCtrl.BringToFront();
			try {
				await context.DoRemove((localPackageListBox.SelectedItem as LocalPackageInfo).ID,
						pushLog, pushProgress);
				pushLog(LogLevel.Info, I._("bpmgui_msg_complete"));
				pushProgress(null, null, 200);
				progCtrl.BarFillColor = Color.LawnGreen;
				progCtrl.progressBar.CustomText = I._("bpmgui_msg_complete");
			} catch (Exception ex) {
				pushLog(LogLevel.Error, ex + Environment.NewLine + ex.Message);
				pushProgress(null, null, 200);
				progCtrl.BarFillColor = Color.Red;
				progCtrl.progressBar.CustomText = I._("bpmgui_msg_err");
				
			}
			await progCtrl.ShowBtnWait();
			Controls.Remove(progCtrl);
			BtnApplyFilterClick(null, null);
		}
		
		async void BtnCheckUpgradeClick(object sender, EventArgs e) {
			var context = new Context(registry, PreferenceManager.Config.RemoteRegistry,
				              PreferenceManager.Config.Translation);
			progCtrl.ResetUI();
			Controls.Add(progCtrl);
			progCtrl.BringToFront();
			localPackageListBox.LatestVersions.Clear();
			try {
				var upgrades = new List<string>();
				var installed = registry.ListPackages(context);
				for (int i = 0; i < installed.Length; i++) {
					pushLog(LogLevel.Info, I._("bpmcore_context_downloadmetadata", installed[i].PlainName));
					pushProgress(installed.Length, i + 1, (i + 1) / installed.Length * 100);
					var remoteinfo = await context.CachedQueryRemotePackage(installed[i].ID);
					localPackageListBox.LatestVersions.Add(installed[i].ID, remoteinfo.AvailableVersions.Last().Key);
					if (remoteinfo.AvailableVersions.Last().Key > installed[i].Version) upgrades.Add(installed[i].PlainName);
				}
				if (upgrades.Count > 0) {
					//TODO: I18n
					MessageBox.Show(string.Format("{0} Packages can be upgraded.\n\n{1}", upgrades.Count, 
					                              string.Join(Environment.NewLine, upgrades)), "Info",
					               MessageBoxButtons.OK, MessageBoxIcon.Information);
				} else {
					MessageBox.Show("All packages are up to date.", "Info",
					               MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			} catch (Exception ex) {
				pushLog(LogLevel.Error, ex + Environment.NewLine + ex.Message);
				pushProgress(null, null, 200);
				progCtrl.BarFillColor = Color.Red;
				progCtrl.progressBar.CustomText = I._("bpmgui_msg_err");
			}
			Controls.Remove(progCtrl);
			BtnApplyFilterClick(null, null);
		}
	}
}
