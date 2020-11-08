
namespace Zbx1425.PackManGui
{
	partial class ProgressControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.RichTextBox progressBox;
		public Ukushu.TextProgressBar progressBar;
		public System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Button btnCancel;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.progressBar = new Ukushu.TextProgressBar();
			this.progressBox = new System.Windows.Forms.RichTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.CustomText = "";
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressBar.FinishedWork = null;
			this.progressBar.Location = new System.Drawing.Point(10, 10);
			this.progressBar.Name = "progressBar";
			this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(205)))), ((int)(((byte)(206)))));
			this.progressBar.Ratio = null;
			this.progressBar.Size = new System.Drawing.Size(280, 23);
			this.progressBar.TabIndex = 2;
			this.progressBar.Text = "textProgressBar1";
			this.progressBar.TextColor = System.Drawing.Color.Black;
			this.progressBar.TextFont = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.progressBar.TotalWork = null;
			// 
			// progressBox
			// 
			this.progressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.progressBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBox.HideSelection = false;
			this.progressBox.Location = new System.Drawing.Point(10, 33);
			this.progressBox.Name = "progressBox";
			this.progressBox.ReadOnly = true;
			this.progressBox.Size = new System.Drawing.Size(280, 227);
			this.progressBox.TabIndex = 4;
			this.progressBox.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(10, 260);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 30);
			this.panel1.TabIndex = 5;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.ForeColor = System.Drawing.Color.Black;
			this.btnCancel.Location = new System.Drawing.Point(111, 3);
			this.btnCancel.MaximumSize = new System.Drawing.Size(80, 30);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 25);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.ForeColor = System.Drawing.Color.Black;
			this.btnOK.Location = new System.Drawing.Point(197, 3);
			this.btnOK.MaximumSize = new System.Drawing.Size(80, 30);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 25);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Visible = false;
			// 
			// ProgressControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.progressBox);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.panel1);
			this.Name = "ProgressControl";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(300, 300);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
