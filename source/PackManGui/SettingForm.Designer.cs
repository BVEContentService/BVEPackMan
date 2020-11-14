
namespace Zbx1425.PackManGui
{
	partial class SettingForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage tabPageCommon;
		private System.Windows.Forms.TabPage tabPageAdvanced;
		private System.Windows.Forms.TableLayoutPanel commonTLP;
		private System.Windows.Forms.Label labelLanguage;
		private System.Windows.Forms.ComboBox comboLanguage;
		private System.Windows.Forms.Label labelRemoteRegistry;
		private System.Windows.Forms.ComboBox comboRemoteRegistry;
		private System.Windows.Forms.Button btnConfigRemote;
		
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
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.tabPageCommon = new System.Windows.Forms.TabPage();
			this.commonTLP = new System.Windows.Forms.TableLayoutPanel();
			this.comboRemoteRegistry = new System.Windows.Forms.ComboBox();
			this.labelLanguage = new System.Windows.Forms.Label();
			this.comboLanguage = new System.Windows.Forms.ComboBox();
			this.labelRemoteRegistry = new System.Windows.Forms.Label();
			this.btnConfigRemote = new System.Windows.Forms.Button();
			this.tabPageAdvanced = new System.Windows.Forms.TabPage();
			this.mainTabControl.SuspendLayout();
			this.tabPageCommon.SuspendLayout();
			this.commonTLP.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.tabPageCommon);
			this.mainTabControl.Controls.Add(this.tabPageAdvanced);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.ItemSize = new System.Drawing.Size(80, 25);
			this.mainTabControl.Location = new System.Drawing.Point(0, 0);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(453, 311);
			this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.mainTabControl.TabIndex = 0;
			// 
			// tabPageCommon
			// 
			this.tabPageCommon.Controls.Add(this.commonTLP);
			this.tabPageCommon.Location = new System.Drawing.Point(4, 29);
			this.tabPageCommon.Name = "tabPageCommon";
			this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCommon.Size = new System.Drawing.Size(445, 278);
			this.tabPageCommon.TabIndex = 0;
			this.tabPageCommon.Text = "Common";
			this.tabPageCommon.UseVisualStyleBackColor = true;
			// 
			// commonTLP
			// 
			this.commonTLP.ColumnCount = 3;
			this.commonTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.commonTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.commonTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.commonTLP.Controls.Add(this.comboRemoteRegistry, 1, 1);
			this.commonTLP.Controls.Add(this.labelLanguage, 0, 0);
			this.commonTLP.Controls.Add(this.comboLanguage, 1, 0);
			this.commonTLP.Controls.Add(this.labelRemoteRegistry, 0, 1);
			this.commonTLP.Controls.Add(this.btnConfigRemote, 2, 1);
			this.commonTLP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commonTLP.Location = new System.Drawing.Point(3, 3);
			this.commonTLP.Name = "commonTLP";
			this.commonTLP.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
			this.commonTLP.RowCount = 2;
			this.commonTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.commonTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.commonTLP.Size = new System.Drawing.Size(439, 272);
			this.commonTLP.TabIndex = 0;
			// 
			// comboRemoteRegistry
			// 
			this.comboRemoteRegistry.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboRemoteRegistry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboRemoteRegistry.FormattingEnabled = true;
			this.comboRemoteRegistry.Location = new System.Drawing.Point(109, 66);
			this.comboRemoteRegistry.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
			this.comboRemoteRegistry.Name = "comboRemoteRegistry";
			this.comboRemoteRegistry.Size = new System.Drawing.Size(227, 20);
			this.comboRemoteRegistry.TabIndex = 3;
			this.comboRemoteRegistry.SelectedIndexChanged += new System.EventHandler(this.ComboRemoteRegistrySelectedIndexChanged);
			// 
			// labelLanguage
			// 
			this.labelLanguage.AutoSize = true;
			this.labelLanguage.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelLanguage.Location = new System.Drawing.Point(8, 10);
			this.labelLanguage.Name = "labelLanguage";
			this.labelLanguage.Size = new System.Drawing.Size(95, 12);
			this.labelLanguage.TabIndex = 0;
			this.labelLanguage.Text = "Language";
			// 
			// comboLanguage
			// 
			this.comboLanguage.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLanguage.FormattingEnabled = true;
			this.comboLanguage.Location = new System.Drawing.Point(109, 13);
			this.comboLanguage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
			this.comboLanguage.Name = "comboLanguage";
			this.comboLanguage.Size = new System.Drawing.Size(227, 20);
			this.comboLanguage.TabIndex = 1;
			this.comboLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboLanguageSelectedIndexChanged);
			// 
			// labelRemoteRegistry
			// 
			this.labelRemoteRegistry.AutoSize = true;
			this.labelRemoteRegistry.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelRemoteRegistry.Location = new System.Drawing.Point(8, 63);
			this.labelRemoteRegistry.Name = "labelRemoteRegistry";
			this.labelRemoteRegistry.Size = new System.Drawing.Size(95, 12);
			this.labelRemoteRegistry.TabIndex = 2;
			this.labelRemoteRegistry.Text = "Remote Registry";
			// 
			// btnConfigRemote
			// 
			this.btnConfigRemote.AutoSize = true;
			this.btnConfigRemote.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnConfigRemote.Location = new System.Drawing.Point(342, 66);
			this.btnConfigRemote.Name = "btnConfigRemote";
			this.btnConfigRemote.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
			this.btnConfigRemote.Size = new System.Drawing.Size(89, 26);
			this.btnConfigRemote.TabIndex = 4;
			this.btnConfigRemote.Text = "Configure";
			this.btnConfigRemote.UseVisualStyleBackColor = true;
			this.btnConfigRemote.Click += new System.EventHandler(this.BtnConfigRemoteClick);
			// 
			// tabPageAdvanced
			// 
			this.tabPageAdvanced.Location = new System.Drawing.Point(4, 29);
			this.tabPageAdvanced.Name = "tabPageAdvanced";
			this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAdvanced.Size = new System.Drawing.Size(445, 278);
			this.tabPageAdvanced.TabIndex = 1;
			this.tabPageAdvanced.Text = "Advanced";
			this.tabPageAdvanced.UseVisualStyleBackColor = true;
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 311);
			this.Controls.Add(this.mainTabControl);
			this.Name = "SettingForm";
			this.Text = "Settings";
			this.mainTabControl.ResumeLayout(false);
			this.tabPageCommon.ResumeLayout(false);
			this.commonTLP.ResumeLayout(false);
			this.commonTLP.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
