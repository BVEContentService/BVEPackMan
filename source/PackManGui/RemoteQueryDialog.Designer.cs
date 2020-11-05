
namespace Zbx1425.PackManGui
{
	partial class RemoteQueryDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage tabPageWarning;
		private System.Windows.Forms.TabPage tabPageInfo;
		private System.Windows.Forms.TabPage tabPageVerSel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.TableLayoutPanel infoPanel;
		private System.Windows.Forms.TextBox textWarn;
		public System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.FlowLayoutPanel versionPanel;
		private System.Windows.Forms.Panel infoHolderPanel;
		
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
			this.tabPageWarning = new System.Windows.Forms.TabPage();
			this.textWarn = new System.Windows.Forms.TextBox();
			this.tabPageInfo = new System.Windows.Forms.TabPage();
			this.infoHolderPanel = new System.Windows.Forms.Panel();
			this.infoPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tabPageVerSel = new System.Windows.Forms.TabPage();
			this.versionPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textName = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.mainTabControl.SuspendLayout();
			this.tabPageWarning.SuspendLayout();
			this.tabPageInfo.SuspendLayout();
			this.infoHolderPanel.SuspendLayout();
			this.tabPageVerSel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.tabPageWarning);
			this.mainTabControl.Controls.Add(this.tabPageInfo);
			this.mainTabControl.Controls.Add(this.tabPageVerSel);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.ItemSize = new System.Drawing.Size(100, 25);
			this.mainTabControl.Location = new System.Drawing.Point(0, 40);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(684, 341);
			this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.mainTabControl.TabIndex = 0;
			// 
			// tabPageWarning
			// 
			this.tabPageWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(26)))));
			this.tabPageWarning.Controls.Add(this.textWarn);
			this.tabPageWarning.Location = new System.Drawing.Point(4, 29);
			this.tabPageWarning.Name = "tabPageWarning";
			this.tabPageWarning.Padding = new System.Windows.Forms.Padding(10);
			this.tabPageWarning.Size = new System.Drawing.Size(676, 308);
			this.tabPageWarning.TabIndex = 0;
			this.tabPageWarning.Text = "Warning";
			// 
			// textWarn
			// 
			this.textWarn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(57)))), ((int)(((byte)(46)))));
			this.textWarn.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textWarn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textWarn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.textWarn.Location = new System.Drawing.Point(10, 10);
			this.textWarn.Multiline = true;
			this.textWarn.Name = "textWarn";
			this.textWarn.ReadOnly = true;
			this.textWarn.Size = new System.Drawing.Size(656, 288);
			this.textWarn.TabIndex = 0;
			// 
			// tabPageInfo
			// 
			this.tabPageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(26)))));
			this.tabPageInfo.Controls.Add(this.infoHolderPanel);
			this.tabPageInfo.Location = new System.Drawing.Point(4, 29);
			this.tabPageInfo.Name = "tabPageInfo";
			this.tabPageInfo.Padding = new System.Windows.Forms.Padding(10);
			this.tabPageInfo.Size = new System.Drawing.Size(676, 308);
			this.tabPageInfo.TabIndex = 1;
			this.tabPageInfo.Text = "Information";
			// 
			// infoHolderPanel
			// 
			this.infoHolderPanel.AutoScroll = true;
			this.infoHolderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(57)))), ((int)(((byte)(46)))));
			this.infoHolderPanel.Controls.Add(this.infoPanel);
			this.infoHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoHolderPanel.Location = new System.Drawing.Point(10, 10);
			this.infoHolderPanel.Margin = new System.Windows.Forms.Padding(10);
			this.infoHolderPanel.Name = "infoHolderPanel";
			this.infoHolderPanel.Size = new System.Drawing.Size(656, 288);
			this.infoHolderPanel.TabIndex = 0;
			// 
			// infoPanel
			// 
			this.infoPanel.AutoSize = true;
			this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(57)))), ((int)(((byte)(46)))));
			this.infoPanel.ColumnCount = 2;
			this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.infoPanel.Location = new System.Drawing.Point(0, 0);
			this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
			this.infoPanel.Name = "infoPanel";
			this.infoPanel.RowCount = 1;
			this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.infoPanel.Size = new System.Drawing.Size(656, 0);
			this.infoPanel.TabIndex = 1;
			this.infoPanel.SizeChanged += new System.EventHandler(this.InfoPanelResize);
			// 
			// tabPageVerSel
			// 
			this.tabPageVerSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(26)))));
			this.tabPageVerSel.Controls.Add(this.versionPanel);
			this.tabPageVerSel.Location = new System.Drawing.Point(4, 29);
			this.tabPageVerSel.Name = "tabPageVerSel";
			this.tabPageVerSel.Padding = new System.Windows.Forms.Padding(10);
			this.tabPageVerSel.Size = new System.Drawing.Size(676, 308);
			this.tabPageVerSel.TabIndex = 2;
			this.tabPageVerSel.Text = "Other Versions";
			// 
			// versionPanel
			// 
			this.versionPanel.AutoScroll = true;
			this.versionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(57)))), ((int)(((byte)(46)))));
			this.versionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.versionPanel.Location = new System.Drawing.Point(10, 10);
			this.versionPanel.Name = "versionPanel";
			this.versionPanel.Size = new System.Drawing.Size(656, 288);
			this.versionPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textName);
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(7);
			this.panel1.Size = new System.Drawing.Size(684, 40);
			this.panel1.TabIndex = 1;
			// 
			// textName
			// 
			this.textName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
			this.textName.ForeColor = System.Drawing.Color.Black;
			this.textName.Location = new System.Drawing.Point(7, 7);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(595, 25);
			this.textName.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearch.ForeColor = System.Drawing.Color.Black;
			this.btnSearch.Location = new System.Drawing.Point(602, 7);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 26);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Controls.Add(this.btnOK);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 381);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(684, 30);
			this.panel2.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.ForeColor = System.Drawing.Color.Black;
			this.btnCancel.Location = new System.Drawing.Point(511, 2);
			this.btnCancel.MaximumSize = new System.Drawing.Size(80, 30);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 25);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.ForeColor = System.Drawing.Color.Black;
			this.btnOK.Location = new System.Drawing.Point(597, 2);
			this.btnOK.MaximumSize = new System.Drawing.Size(80, 30);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 25);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// RemoteQueryDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(26)))));
			this.ClientSize = new System.Drawing.Size(684, 411);
			this.Controls.Add(this.mainTabControl);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.Name = "RemoteQueryDialog";
			this.Text = "Select Package to Install";
			this.mainTabControl.ResumeLayout(false);
			this.tabPageWarning.ResumeLayout(false);
			this.tabPageWarning.PerformLayout();
			this.tabPageInfo.ResumeLayout(false);
			this.infoHolderPanel.ResumeLayout(false);
			this.infoHolderPanel.PerformLayout();
			this.tabPageVerSel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
