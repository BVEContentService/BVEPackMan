﻿
namespace Zbx1425.PackManGui
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private LocalRegistryListBox localRegistryListBox;
		private System.Windows.Forms.Panel contextActionPanel;
		private System.Windows.Forms.Button btnUninstallPack;
		private System.Windows.Forms.Button btnInstallPack;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnMoveDown;
		private System.Windows.Forms.Button btnMoveUp;
		private System.Windows.Forms.Button btnConfig;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuAddRegistry;
		private System.Windows.Forms.ToolStripMenuItem menuSettings;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.localRegistryListBox = new Zbx1425.PackManGui.LocalRegistryListBox();
			this.contextActionPanel = new System.Windows.Forms.Panel();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnMoveDown = new System.Windows.Forms.Button();
			this.btnMoveUp = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.btnUninstallPack = new System.Windows.Forms.Button();
			this.btnInstallPack = new System.Windows.Forms.Button();
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.menuAddRegistry = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.contextActionPanel.SuspendLayout();
			this.mainMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// localRegistryListBox
			// 
			this.localRegistryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.localRegistryListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
			this.localRegistryListBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
			this.localRegistryListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.localRegistryListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.localRegistryListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.localRegistryListBox.FormattingEnabled = true;
			this.localRegistryListBox.IDColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
			this.localRegistryListBox.ItemHeight = 12;
			this.localRegistryListBox.Location = new System.Drawing.Point(13, 73);
			this.localRegistryListBox.Name = "localRegistryListBox";
			this.localRegistryListBox.SealBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
			this.localRegistryListBox.SealColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
			this.localRegistryListBox.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.localRegistryListBox.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
			this.localRegistryListBox.Size = new System.Drawing.Size(658, 282);
			this.localRegistryListBox.TabIndex = 0;
			this.localRegistryListBox.WarnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(79)))));
			this.localRegistryListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LocalRegistryListBox1DrawItem);
			this.localRegistryListBox.SelectedValueChanged += new System.EventHandler(this.LocalRegistryListBoxSelectedValueChanged);
			// 
			// contextActionPanel
			// 
			this.contextActionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
			this.contextActionPanel.Controls.Add(this.btnRemove);
			this.contextActionPanel.Controls.Add(this.btnMoveDown);
			this.contextActionPanel.Controls.Add(this.btnMoveUp);
			this.contextActionPanel.Controls.Add(this.btnConfig);
			this.contextActionPanel.Controls.Add(this.btnUninstallPack);
			this.contextActionPanel.Controls.Add(this.btnInstallPack);
			this.contextActionPanel.ForeColor = System.Drawing.Color.Black;
			this.contextActionPanel.Location = new System.Drawing.Point(13, 73);
			this.contextActionPanel.Name = "contextActionPanel";
			this.contextActionPanel.Size = new System.Drawing.Size(522, 42);
			this.contextActionPanel.TabIndex = 1;
			this.contextActionPanel.Visible = false;
			this.contextActionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ContextActionPanelPaint);
			// 
			// btnRemove
			// 
			this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
			this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.Location = new System.Drawing.Point(444, 8);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(70, 26);
			this.btnRemove.TabIndex = 6;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
			// 
			// btnMoveDown
			// 
			this.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
			this.btnMoveDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMoveDown.Location = new System.Drawing.Point(407, 8);
			this.btnMoveDown.Name = "btnMoveDown";
			this.btnMoveDown.Size = new System.Drawing.Size(30, 26);
			this.btnMoveDown.TabIndex = 5;
			this.btnMoveDown.Text = "▼";
			this.btnMoveDown.UseVisualStyleBackColor = false;
			this.btnMoveDown.Click += new System.EventHandler(this.BtnMoveDownClick);
			// 
			// btnMoveUp
			// 
			this.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
			this.btnMoveUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMoveUp.Location = new System.Drawing.Point(371, 8);
			this.btnMoveUp.Name = "btnMoveUp";
			this.btnMoveUp.Size = new System.Drawing.Size(30, 26);
			this.btnMoveUp.TabIndex = 4;
			this.btnMoveUp.Text = "▲";
			this.btnMoveUp.UseVisualStyleBackColor = false;
			this.btnMoveUp.Click += new System.EventHandler(this.BtnMoveUpClick);
			// 
			// btnConfig
			// 
			this.btnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
			this.btnConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfig.Location = new System.Drawing.Point(295, 8);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(70, 26);
			this.btnConfig.TabIndex = 3;
			this.btnConfig.Text = "Config";
			this.btnConfig.UseVisualStyleBackColor = false;
			this.btnConfig.Click += new System.EventHandler(this.BtnConfigClick);
			// 
			// btnUninstallPack
			// 
			this.btnUninstallPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
			this.btnUninstallPack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnUninstallPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUninstallPack.Location = new System.Drawing.Point(135, 8);
			this.btnUninstallPack.Name = "btnUninstallPack";
			this.btnUninstallPack.Size = new System.Drawing.Size(120, 26);
			this.btnUninstallPack.TabIndex = 2;
			this.btnUninstallPack.Text = "Uninstall Pack";
			this.btnUninstallPack.UseVisualStyleBackColor = false;
			// 
			// btnInstallPack
			// 
			this.btnInstallPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
			this.btnInstallPack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnInstallPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInstallPack.Location = new System.Drawing.Point(9, 8);
			this.btnInstallPack.Name = "btnInstallPack";
			this.btnInstallPack.Size = new System.Drawing.Size(120, 26);
			this.btnInstallPack.TabIndex = 1;
			this.btnInstallPack.Text = "Install Pack";
			this.btnInstallPack.UseVisualStyleBackColor = false;
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuAddRegistry,
			this.menuSettings});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(683, 25);
			this.mainMenuStrip.TabIndex = 2;
			this.mainMenuStrip.Text = "mainMenuStrip";
			// 
			// menuAddRegistry
			// 
			this.menuAddRegistry.Name = "menuAddRegistry";
			this.menuAddRegistry.Size = new System.Drawing.Size(125, 21);
			this.menuAddRegistry.Text = "Add New Registry";
			// 
			// menuSettings
			// 
			this.menuSettings.Name = "menuSettings";
			this.menuSettings.Size = new System.Drawing.Size(66, 21);
			this.menuSettings.Text = "Settings";
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.ClientSize = new System.Drawing.Size(683, 371);
			this.Controls.Add(this.contextActionPanel);
			this.Controls.Add(this.localRegistryListBox);
			this.Controls.Add(this.mainMenuStrip);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.MainMenuStrip = this.mainMenuStrip;
			this.Name = "MainForm";
			this.Text = "GUI";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResizeBegin += new System.EventHandler(this.MainFormResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
			this.contextActionPanel.ResumeLayout(false);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}