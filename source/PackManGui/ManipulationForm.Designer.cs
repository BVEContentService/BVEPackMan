
namespace Zbx1425.PackManGui
{
	partial class ManipulationForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Zbx1425.PackManGui.PackageListBox localPackageListBox;
		private System.Windows.Forms.Panel contextActionPanel;
		private System.Windows.Forms.Button btnUninstallPack;
		private System.Windows.Forms.Button btnUpgradeDowngrade;
		private System.Windows.Forms.FlowLayoutPanel filterLayoutPanel;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.ComboBox comboCategory;
		private System.Windows.Forms.Label labelKeyword;
		private System.Windows.Forms.TextBox textKeyword;
		private System.Windows.Forms.Button btnApplyFilter;
		private System.Windows.Forms.Button btnInstallPack;
		private System.Windows.Forms.Button btnCheckUpgrade;
		
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
			this.localPackageListBox = new Zbx1425.PackManGui.PackageListBox();
			this.contextActionPanel = new System.Windows.Forms.Panel();
			this.btnUninstallPack = new System.Windows.Forms.Button();
			this.btnUpgradeDowngrade = new System.Windows.Forms.Button();
			this.filterLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.labelCategory = new System.Windows.Forms.Label();
			this.comboCategory = new System.Windows.Forms.ComboBox();
			this.labelKeyword = new System.Windows.Forms.Label();
			this.textKeyword = new System.Windows.Forms.TextBox();
			this.btnApplyFilter = new System.Windows.Forms.Button();
			this.btnInstallPack = new System.Windows.Forms.Button();
			this.btnCheckUpgrade = new System.Windows.Forms.Button();
			this.contextActionPanel.SuspendLayout();
			this.filterLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// localPackageListBox
			// 
			this.localPackageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.localPackageListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(57)))), ((int)(((byte)(46)))));
			this.localPackageListBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(86)))));
			this.localPackageListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.localPackageListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.localPackageListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.localPackageListBox.IDColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
			this.localPackageListBox.ItemHeight = 12;
			this.localPackageListBox.Location = new System.Drawing.Point(13, 77);
			this.localPackageListBox.Name = "localPackageListBox";
			this.localPackageListBox.SealBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			this.localPackageListBox.SealCenter = 203;
			this.localPackageListBox.SealColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(205)))), ((int)(((byte)(206)))));
			this.localPackageListBox.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
			this.localPackageListBox.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(77)))), ((int)(((byte)(66)))));
			this.localPackageListBox.ShowSeal = true;
			this.localPackageListBox.Size = new System.Drawing.Size(659, 322);
			this.localPackageListBox.TabIndex = 1;
			this.localPackageListBox.WarnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(79)))));
			this.localPackageListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LocalPackageListBoxDrawItem);
			this.localPackageListBox.SelectedIndexChanged += new System.EventHandler(this.LocalPackageListBoxSelectedIndexChanged);
			// 
			// contextActionPanel
			// 
			this.contextActionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(205)))), ((int)(((byte)(206)))));
			this.contextActionPanel.Controls.Add(this.btnUninstallPack);
			this.contextActionPanel.Controls.Add(this.btnUpgradeDowngrade);
			this.contextActionPanel.ForeColor = System.Drawing.Color.Black;
			this.contextActionPanel.Location = new System.Drawing.Point(13, 77);
			this.contextActionPanel.Name = "contextActionPanel";
			this.contextActionPanel.Size = new System.Drawing.Size(370, 42);
			this.contextActionPanel.TabIndex = 2;
			this.contextActionPanel.Visible = false;
			this.contextActionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ContextActionPanelPaint);
			// 
			// btnUninstallPack
			// 
			this.btnUninstallPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnUninstallPack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnUninstallPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUninstallPack.Location = new System.Drawing.Point(200, 6);
			this.btnUninstallPack.Name = "btnUninstallPack";
			this.btnUninstallPack.Size = new System.Drawing.Size(160, 26);
			this.btnUninstallPack.TabIndex = 2;
			this.btnUninstallPack.Text = "Uninstall Pack";
			this.btnUninstallPack.UseVisualStyleBackColor = false;
			this.btnUninstallPack.Click += new System.EventHandler(this.BtnUninstallPackClick);
			// 
			// btnUpgradeDowngrade
			// 
			this.btnUpgradeDowngrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnUpgradeDowngrade.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnUpgradeDowngrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpgradeDowngrade.Location = new System.Drawing.Point(7, 6);
			this.btnUpgradeDowngrade.Name = "btnUpgradeDowngrade";
			this.btnUpgradeDowngrade.Size = new System.Drawing.Size(160, 26);
			this.btnUpgradeDowngrade.TabIndex = 1;
			this.btnUpgradeDowngrade.Text = "Upgrade / Downgrade";
			this.btnUpgradeDowngrade.UseVisualStyleBackColor = false;
			this.btnUpgradeDowngrade.Click += new System.EventHandler(this.BtnUpgradeDowngradeClick);
			// 
			// filterLayoutPanel
			// 
			this.filterLayoutPanel.Controls.Add(this.labelCategory);
			this.filterLayoutPanel.Controls.Add(this.comboCategory);
			this.filterLayoutPanel.Controls.Add(this.labelKeyword);
			this.filterLayoutPanel.Controls.Add(this.textKeyword);
			this.filterLayoutPanel.Controls.Add(this.btnApplyFilter);
			this.filterLayoutPanel.Location = new System.Drawing.Point(13, 45);
			this.filterLayoutPanel.Name = "filterLayoutPanel";
			this.filterLayoutPanel.Size = new System.Drawing.Size(659, 26);
			this.filterLayoutPanel.TabIndex = 3;
			// 
			// labelCategory
			// 
			this.labelCategory.AutoSize = true;
			this.labelCategory.Location = new System.Drawing.Point(3, 6);
			this.labelCategory.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new System.Drawing.Size(101, 12);
			this.labelCategory.TabIndex = 0;
			this.labelCategory.Text = "Filter: Category";
			// 
			// comboCategory
			// 
			this.comboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboCategory.FormattingEnabled = true;
			this.comboCategory.Location = new System.Drawing.Point(110, 3);
			this.comboCategory.Name = "comboCategory";
			this.comboCategory.Size = new System.Drawing.Size(121, 20);
			this.comboCategory.TabIndex = 1;
			this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.BtnApplyFilterClick);
			// 
			// labelKeyword
			// 
			this.labelKeyword.AutoSize = true;
			this.labelKeyword.Location = new System.Drawing.Point(249, 6);
			this.labelKeyword.Margin = new System.Windows.Forms.Padding(15, 6, 3, 0);
			this.labelKeyword.Name = "labelKeyword";
			this.labelKeyword.Size = new System.Drawing.Size(47, 12);
			this.labelKeyword.TabIndex = 2;
			this.labelKeyword.Text = "Keyword";
			// 
			// textKeyword
			// 
			this.textKeyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textKeyword.Location = new System.Drawing.Point(302, 3);
			this.textKeyword.Name = "textKeyword";
			this.textKeyword.Size = new System.Drawing.Size(200, 21);
			this.textKeyword.TabIndex = 3;
			this.textKeyword.TextChanged += new System.EventHandler(this.BtnApplyFilterClick);
			// 
			// btnApplyFilter
			// 
			this.btnApplyFilter.AutoSize = true;
			this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnApplyFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnApplyFilter.ForeColor = System.Drawing.Color.Black;
			this.btnApplyFilter.Location = new System.Drawing.Point(525, 3);
			this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
			this.btnApplyFilter.MinimumSize = new System.Drawing.Size(26, 26);
			this.btnApplyFilter.Name = "btnApplyFilter";
			this.btnApplyFilter.Size = new System.Drawing.Size(120, 26);
			this.btnApplyFilter.TabIndex = 6;
			this.btnApplyFilter.Text = "Apply Filter";
			this.btnApplyFilter.UseVisualStyleBackColor = false;
			this.btnApplyFilter.Visible = false;
			this.btnApplyFilter.Click += new System.EventHandler(this.BtnApplyFilterClick);
			// 
			// btnInstallPack
			// 
			this.btnInstallPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnInstallPack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnInstallPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInstallPack.ForeColor = System.Drawing.Color.Black;
			this.btnInstallPack.Location = new System.Drawing.Point(12, 12);
			this.btnInstallPack.Name = "btnInstallPack";
			this.btnInstallPack.Size = new System.Drawing.Size(160, 26);
			this.btnInstallPack.TabIndex = 4;
			this.btnInstallPack.Text = "Install new Pack";
			this.btnInstallPack.UseVisualStyleBackColor = false;
			this.btnInstallPack.Click += new System.EventHandler(this.BtnInstallPackClick);
			// 
			// btnCheckUpgrade
			// 
			this.btnCheckUpgrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnCheckUpgrade.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnCheckUpgrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCheckUpgrade.ForeColor = System.Drawing.Color.Black;
			this.btnCheckUpgrade.Location = new System.Drawing.Point(178, 12);
			this.btnCheckUpgrade.Name = "btnCheckUpgrade";
			this.btnCheckUpgrade.Size = new System.Drawing.Size(160, 26);
			this.btnCheckUpgrade.TabIndex = 5;
			this.btnCheckUpgrade.Text = "Check for Updates";
			this.btnCheckUpgrade.UseVisualStyleBackColor = false;
			this.btnCheckUpgrade.Click += new System.EventHandler(this.BtnCheckUpgradeClick);
			// 
			// ManipulationForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(26)))));
			this.ClientSize = new System.Drawing.Size(684, 411);
			this.Controls.Add(this.contextActionPanel);
			this.Controls.Add(this.btnCheckUpgrade);
			this.Controls.Add(this.btnInstallPack);
			this.Controls.Add(this.filterLayoutPanel);
			this.Controls.Add(this.localPackageListBox);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.MinimumSize = new System.Drawing.Size(700, 450);
			this.Name = "ManipulationForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Manipulation";
			this.Shown += new System.EventHandler(this.ManipulationFormShown);
			this.ResizeBegin += new System.EventHandler(this.ManipulationFormResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.ManipulationFormmResizeEnd);
			this.contextActionPanel.ResumeLayout(false);
			this.filterLayoutPanel.ResumeLayout(false);
			this.filterLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
