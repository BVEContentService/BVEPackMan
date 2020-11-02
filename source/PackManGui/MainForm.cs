﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zbx1425.PWPackMan;
using Zbx1425.PackManGui.Plugin;

namespace Zbx1425.PackManGui {
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form {
		
		public MainForm() {
			InitializeComponent();
			btnInstallPack.Text = I._("bpmgui_mainform_btninstallpack");
			btnUninstallPack.Text = I._("bpmgui_mainform_btnuninstallpack");
			btnConfig.Text = I._("bpmgui_mainform_btnconfig");
			btnRemove.Text = I._("bpmgui_mainform_btnremove");
		}
		
		void MainFormLoad(object sender, EventArgs e) {
			// localRegistryListBox.DataSource = RegistryManager.LocalRegisteries;
			foreach (var r in RegistryManager.LocalRegisteries) {
				localRegistryListBox.Items.Add(r);
			}
			AssertListSync();
		}
		
		private Color[] btnColors = {Color.FromArgb(59, 68, 88), Color.FromArgb(159, 168, 218)};
		
		void LocalRegistryListBoxSelectedValueChanged(object sender, EventArgs e) {
			var item = (IRegistry)localRegistryListBox.SelectedItem;
			var nextItem = (IRegistry)(localRegistryListBox.SelectedIndex >= localRegistryListBox.Items.Count - 1 ?
               null : localRegistryListBox.Items[localRegistryListBox.SelectedIndex + 1]);
			var prevItem = (IRegistry)(localRegistryListBox.SelectedIndex <= 0 ?
				null : localRegistryListBox.Items[localRegistryListBox.SelectedIndex - 1]);
			if (item == null) {
				contextActionPanel.Hide();
				return;
			}
			btnMoveDown.Enabled = nextItem != null && !nextItem.IsFromAutoDetect;
			btnMoveUp.Enabled = prevItem != null && !prevItem.IsFromAutoDetect;
			if (item.IsFromAutoDetect) {
				btnConfig.Text = I._("bpmgui_mainform_btnconfiga");
				btnRemove.Text = I._("bpmgui_mainform_btnremovea");
				btnMoveDown.Enabled = btnMoveUp.Enabled = false;
			} else {
				btnConfig.Text = I._("bpmgui_mainform_btnconfig");
				btnRemove.Text = I._("bpmgui_mainform_btnremove");
			}
			btnMoveUp.BackColor = btnColors[btnMoveUp.Enabled?1:0];
			btnMoveDown.BackColor = btnColors[btnMoveDown.Enabled?1:0];
		}
		
		void LocalRegistryListBox1DrawItem(object sender, DrawItemEventArgs e) {
			if (e.Index >= localRegistryListBox.Items.Count)
				return;
			if (e.Index < 0)
				return;
			if (e.State.HasFlag(DrawItemState.Selected)) {
				if (e.Bounds.Y < 0 || e.Bounds.Y > localRegistryListBox.Height) {
					contextActionPanel.Hide();
				} else {
					contextActionPanel.Location = e.Bounds.Location + new Size(localRegistryListBox.Location)
					+ new Size(20, -contextActionPanel.Height);
					contextActionPanel.Show();
				}
			}
		}
		private Pen capBorderPen = new Pen(Color.FromArgb(159, 168, 218));
		private Pen capSealPen = new Pen(Color.FromArgb(92, 107, 192));
		void ContextActionPanelPaint(object sender, PaintEventArgs e) {
			e.Graphics.DrawRectangle(capBorderPen, 0, 0, contextActionPanel.Width - 1, contextActionPanel.Height - 1);
			e.Graphics.DrawLine(capSealPen, 266, contextActionPanel.Height - 1, 284, contextActionPanel.Height - 1);
		}
		void MainFormResizeBegin(object sender, EventArgs e) {
			// Dirty workaround to reduce flickering.
			localRegistryListBox.BeginUpdate();
		}
		void MainFormResizeEnd(object sender, EventArgs e) {
			localRegistryListBox.EndUpdate();
		}
		
		void AssertListSync() {
			if (localRegistryListBox.Items.Count != RegistryManager.LocalRegisteries.Count) {
				throw new Exception(I._("bpmgui_debug_regmanoutofsync"));
			}
			for (int i = 0; i < localRegistryListBox.Items.Count; i++) {
				if (localRegistryListBox.Items[i] != RegistryManager.LocalRegisteries[i]) {
					throw new Exception(I._("bpmgui_debug_regmanoutofsync"));
				}
			}
		}
		
		void BtnMoveUpClick(object sender, EventArgs e) {
			if (localRegistryListBox.SelectedItem == null ||
			    ((IRegistry)localRegistryListBox.SelectedItem).IsFromAutoDetect)
				return;
			var prevItem = (IRegistry)(localRegistryListBox.SelectedIndex <= 0 ?
				null : localRegistryListBox.Items[localRegistryListBox.SelectedIndex - 1]);
			if (prevItem == null || prevItem.IsFromAutoDetect)
				return;
			var sid = localRegistryListBox.SelectedIndex;
			
			// I heard that using BindingList is the correct way to do such operations
			// But I can never get it to work...
			RegistryManager.LocalRegisteries.Reverse(sid - 1, 2);
			var temp = localRegistryListBox.Items[sid - 1];
			localRegistryListBox.Items[sid - 1] = localRegistryListBox.Items[sid];
			localRegistryListBox.Items[sid] = temp;
			localRegistryListBox.SelectedIndex = sid - 1;
			localRegistryListBox.Invalidate();
			AssertListSync();
		}
		void BtnMoveDownClick(object sender, EventArgs e) {
			if (localRegistryListBox.SelectedItem == null ||
			    ((IRegistry)localRegistryListBox.SelectedItem).IsFromAutoDetect)
				return;
			var nextItem = (IRegistry)(localRegistryListBox.SelectedIndex >= localRegistryListBox.Items.Count - 1 ?
               null : localRegistryListBox.Items[localRegistryListBox.SelectedIndex + 1]);
			if (nextItem == null || nextItem.IsFromAutoDetect)
				return;
			var sid = localRegistryListBox.SelectedIndex;
			
			// I heard that using BindingList is the correct way to do such operations
			// But I can never get it to work...
			RegistryManager.LocalRegisteries.Reverse(sid, 2);
			var temp = localRegistryListBox.Items[sid + 1];
			localRegistryListBox.Items[sid + 1] = localRegistryListBox.Items[sid];
			localRegistryListBox.Items[sid] = temp;
			localRegistryListBox.SelectedIndex = sid + 1;
			localRegistryListBox.Invalidate();
			AssertListSync();
		}
		void BtnRemoveClick(object sender, EventArgs e) {
			if (localRegistryListBox.SelectedItem == null)
				return;
			var item = (ILocalRegistry)localRegistryListBox.SelectedItem;
			if (item.IsFromAutoDetect) {
				if (MessageBox.Show(I._("bpmgui_msg_disableautodet"), I._("bpmgui_msg_warn"),
					    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2
				    ) == DialogResult.Yes) {
					localRegistryListBox.Items.Remove(item);
					RegistryManager.LocalRegisteries.Remove(item);
					RegistryManager.Config.LocalRegisteryInhibitions.Add(new PluginConfigEntry(item));
					localRegistryListBox.SelectedIndex = -1;
					localRegistryListBox.ForceMeasure();
					AssertListSync();
				}
			} else {
				if (MessageBox.Show(I._("bpmgui_msg_removereg"), I._("bpmgui_msg_warn"),
					    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2
				    ) == DialogResult.Yes) {
					localRegistryListBox.Items.Remove(item);
					RegistryManager.LocalRegisteries.Remove(item);
					localRegistryListBox.SelectedIndex = -1;
					RegistryManager.AutoDetect();
					foreach (var r in RegistryManager.LocalRegisteries) {
						if (!localRegistryListBox.Items.Contains(r))
							localRegistryListBox.Items.Add(r);
					}
					AssertListSync();
				}
			}
		}
		
		void BtnConfigClick(object sender, EventArgs e) {
			if (localRegistryListBox.SelectedItem == null)
				return;
			var item = (ILocalRegistry)localRegistryListBox.SelectedItem;
			if (item.IsFromAutoDetect) {
				if (MessageBox.Show(I._("bpmgui_msg_approvereg"), I._("bpmgui_msg_warn"),
					    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2
				    ) == DialogResult.Yes) {
					localRegistryListBox.Items.Remove(item);
					RegistryManager.LocalRegisteries.Remove(item);
					var firstAutoIndex = 0;
					while (firstAutoIndex <= localRegistryListBox.Items.Count - 2 &&
					       !((IRegistry)localRegistryListBox.Items[firstAutoIndex]).IsFromAutoDetect) {
						firstAutoIndex++;
					}
					item.IsFromAutoDetect = false;
					localRegistryListBox.Items.Insert(firstAutoIndex + 1, item);
					RegistryManager.LocalRegisteries.Insert(firstAutoIndex + 1, item);
					localRegistryListBox.SelectedIndex = firstAutoIndex + 1;
					localRegistryListBox.ForceMeasure();
					AssertListSync();
				}
			} else {
				item.ShowConfigWindow(this);
				localRegistryListBox.Invalidate();
				AssertListSync();
			}
		}
	}
}