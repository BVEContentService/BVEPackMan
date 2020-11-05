
namespace Zbx1425.OpenBveRegistry
{
	partial class ConfigDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox grpDatabase;
		private System.Windows.Forms.Label lblDatabaseHint;
		private System.Windows.Forms.TextBox textDatabase;
		private System.Windows.Forms.Button btnDatabase;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.GroupBox grpInsDir;
		private System.Windows.Forms.Label lblRailway;
		private System.Windows.Forms.TextBox textRailway;
		private System.Windows.Forms.Button btnRailway;
		private System.Windows.Forms.Label lblInsDirHint1;
		private System.Windows.Forms.Label lblTrain;
		private System.Windows.Forms.TextBox textTrain;
		private System.Windows.Forms.Button btnTrain;
		private System.Windows.Forms.Label lblInsDirHint2;
		private System.Windows.Forms.Label lblLoksim;
		private System.Windows.Forms.Label lblOther;
		private System.Windows.Forms.TextBox textLoksim;
		private System.Windows.Forms.Button btnLoksim;
		private System.Windows.Forms.TextBox textOther;
		private System.Windows.Forms.Button btnOther;
		
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpDatabase = new System.Windows.Forms.GroupBox();
			this.lblLocation = new System.Windows.Forms.Label();
			this.textDatabase = new System.Windows.Forms.TextBox();
			this.btnDatabase = new System.Windows.Forms.Button();
			this.lblDatabaseHint = new System.Windows.Forms.Label();
			this.grpInsDir = new System.Windows.Forms.GroupBox();
			this.lblInsDirHint2 = new System.Windows.Forms.Label();
			this.lblLoksim = new System.Windows.Forms.Label();
			this.lblTrain = new System.Windows.Forms.Label();
			this.lblOther = new System.Windows.Forms.Label();
			this.lblRailway = new System.Windows.Forms.Label();
			this.textLoksim = new System.Windows.Forms.TextBox();
			this.textTrain = new System.Windows.Forms.TextBox();
			this.btnLoksim = new System.Windows.Forms.Button();
			this.btnTrain = new System.Windows.Forms.Button();
			this.textOther = new System.Windows.Forms.TextBox();
			this.btnOther = new System.Windows.Forms.Button();
			this.textRailway = new System.Windows.Forms.TextBox();
			this.btnRailway = new System.Windows.Forms.Button();
			this.lblInsDirHint1 = new System.Windows.Forms.Label();
			this.grpDatabase.SuspendLayout();
			this.grpInsDir.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.ForeColor = System.Drawing.Color.Black;
			this.btnCancel.Location = new System.Drawing.Point(448, 347);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(74, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Tag = "cancel";
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.ForeColor = System.Drawing.Color.Black;
			this.btnOK.Location = new System.Drawing.Point(366, 347);
			this.btnOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(74, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Tag = "ok";
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// grpDatabase
			// 
			this.grpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpDatabase.Controls.Add(this.lblLocation);
			this.grpDatabase.Controls.Add(this.textDatabase);
			this.grpDatabase.Controls.Add(this.btnDatabase);
			this.grpDatabase.Controls.Add(this.lblDatabaseHint);
			this.grpDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(205)))), ((int)(((byte)(206)))));
			this.grpDatabase.Location = new System.Drawing.Point(13, 13);
			this.grpDatabase.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.grpDatabase.Name = "grpDatabase";
			this.grpDatabase.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.grpDatabase.Size = new System.Drawing.Size(510, 95);
			this.grpDatabase.TabIndex = 2;
			this.grpDatabase.TabStop = false;
			this.grpDatabase.Tag = "database";
			this.grpDatabase.Text = "Database";
			// 
			// lblLocation
			// 
			this.lblLocation.Location = new System.Drawing.Point(6, 62);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(67, 21);
			this.lblLocation.TabIndex = 2;
			this.lblLocation.Tag = "location";
			this.lblLocation.Text = "Location";
			this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textDatabase
			// 
			this.textDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textDatabase.Location = new System.Drawing.Point(78, 62);
			this.textDatabase.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textDatabase.Name = "textDatabase";
			this.textDatabase.Size = new System.Drawing.Size(344, 23);
			this.textDatabase.TabIndex = 1;
			this.textDatabase.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
			// 
			// btnDatabase
			// 
			this.btnDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnDatabase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDatabase.ForeColor = System.Drawing.Color.Black;
			this.btnDatabase.Location = new System.Drawing.Point(426, 62);
			this.btnDatabase.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnDatabase.Name = "btnDatabase";
			this.btnDatabase.Size = new System.Drawing.Size(74, 23);
			this.btnDatabase.TabIndex = 1;
			this.btnDatabase.Tag = "browse";
			this.btnDatabase.Text = "Browse";
			this.btnDatabase.UseVisualStyleBackColor = false;
			this.btnDatabase.Click += new System.EventHandler(this.BtnDatabaseClick);
			// 
			// lblDatabaseHint
			// 
			this.lblDatabaseHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDatabaseHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.lblDatabaseHint.Location = new System.Drawing.Point(6, 17);
			this.lblDatabaseHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDatabaseHint.Name = "lblDatabaseHint";
			this.lblDatabaseHint.Size = new System.Drawing.Size(500, 40);
			this.lblDatabaseHint.TabIndex = 0;
			this.lblDatabaseHint.Tag = "databasehint";
			this.lblDatabaseHint.Text = "Normally, the default value will work if you installed OpenBve in a normal way.";
			// 
			// grpInsDir
			// 
			this.grpInsDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpInsDir.Controls.Add(this.lblInsDirHint2);
			this.grpInsDir.Controls.Add(this.lblLoksim);
			this.grpInsDir.Controls.Add(this.lblTrain);
			this.grpInsDir.Controls.Add(this.lblOther);
			this.grpInsDir.Controls.Add(this.lblRailway);
			this.grpInsDir.Controls.Add(this.textLoksim);
			this.grpInsDir.Controls.Add(this.textTrain);
			this.grpInsDir.Controls.Add(this.btnLoksim);
			this.grpInsDir.Controls.Add(this.btnTrain);
			this.grpInsDir.Controls.Add(this.textOther);
			this.grpInsDir.Controls.Add(this.btnOther);
			this.grpInsDir.Controls.Add(this.textRailway);
			this.grpInsDir.Controls.Add(this.btnRailway);
			this.grpInsDir.Controls.Add(this.lblInsDirHint1);
			this.grpInsDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(205)))), ((int)(((byte)(206)))));
			this.grpInsDir.Location = new System.Drawing.Point(13, 114);
			this.grpInsDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.grpInsDir.Name = "grpInsDir";
			this.grpInsDir.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.grpInsDir.Size = new System.Drawing.Size(510, 227);
			this.grpInsDir.TabIndex = 2;
			this.grpInsDir.TabStop = false;
			this.grpInsDir.Tag = "installdir";
			this.grpInsDir.Text = "Installation Directories";
			// 
			// lblInsDirHint2
			// 
			this.lblInsDirHint2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblInsDirHint2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.lblInsDirHint2.Location = new System.Drawing.Point(6, 122);
			this.lblInsDirHint2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblInsDirHint2.Name = "lblInsDirHint2";
			this.lblInsDirHint2.Size = new System.Drawing.Size(500, 40);
			this.lblInsDirHint2.TabIndex = 3;
			this.lblInsDirHint2.Tag = "installdirhint2";
			this.lblInsDirHint2.Text = "You can leave these two below at their default value if you are not sure. Seldom " +
	"does a package refer to these locations.";
			// 
			// lblLoksim
			// 
			this.lblLoksim.Location = new System.Drawing.Point(6, 192);
			this.lblLoksim.Name = "lblLoksim";
			this.lblLoksim.Size = new System.Drawing.Size(67, 21);
			this.lblLoksim.TabIndex = 2;
			this.lblLoksim.Tag = "loksim";
			this.lblLoksim.Text = "Loksim";
			this.lblLoksim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTrain
			// 
			this.lblTrain.Location = new System.Drawing.Point(6, 87);
			this.lblTrain.Name = "lblTrain";
			this.lblTrain.Size = new System.Drawing.Size(67, 21);
			this.lblTrain.TabIndex = 2;
			this.lblTrain.Tag = "train";
			this.lblTrain.Text = "Train";
			this.lblTrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOther
			// 
			this.lblOther.Location = new System.Drawing.Point(6, 165);
			this.lblOther.Name = "lblOther";
			this.lblOther.Size = new System.Drawing.Size(67, 21);
			this.lblOther.TabIndex = 2;
			this.lblOther.Tag = "other";
			this.lblOther.Text = "Other";
			this.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRailway
			// 
			this.lblRailway.Location = new System.Drawing.Point(6, 60);
			this.lblRailway.Name = "lblRailway";
			this.lblRailway.Size = new System.Drawing.Size(67, 21);
			this.lblRailway.TabIndex = 2;
			this.lblRailway.Tag = "railway";
			this.lblRailway.Text = "Railway";
			this.lblRailway.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textLoksim
			// 
			this.textLoksim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textLoksim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textLoksim.Location = new System.Drawing.Point(78, 192);
			this.textLoksim.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textLoksim.Name = "textLoksim";
			this.textLoksim.Size = new System.Drawing.Size(344, 23);
			this.textLoksim.TabIndex = 1;
			this.textLoksim.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
			// 
			// textTrain
			// 
			this.textTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textTrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textTrain.Location = new System.Drawing.Point(78, 87);
			this.textTrain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textTrain.Name = "textTrain";
			this.textTrain.Size = new System.Drawing.Size(344, 23);
			this.textTrain.TabIndex = 1;
			this.textTrain.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
			// 
			// btnLoksim
			// 
			this.btnLoksim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoksim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnLoksim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnLoksim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoksim.ForeColor = System.Drawing.Color.Black;
			this.btnLoksim.Location = new System.Drawing.Point(426, 192);
			this.btnLoksim.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnLoksim.Name = "btnLoksim";
			this.btnLoksim.Size = new System.Drawing.Size(74, 23);
			this.btnLoksim.TabIndex = 1;
			this.btnLoksim.Tag = "browse";
			this.btnLoksim.Text = "Browse";
			this.btnLoksim.UseVisualStyleBackColor = false;
			this.btnLoksim.Click += new System.EventHandler(this.BrowseBtnClick);
			// 
			// btnTrain
			// 
			this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnTrain.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTrain.ForeColor = System.Drawing.Color.Black;
			this.btnTrain.Location = new System.Drawing.Point(426, 87);
			this.btnTrain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnTrain.Name = "btnTrain";
			this.btnTrain.Size = new System.Drawing.Size(74, 23);
			this.btnTrain.TabIndex = 1;
			this.btnTrain.Tag = "browse";
			this.btnTrain.Text = "Browse";
			this.btnTrain.UseVisualStyleBackColor = false;
			this.btnTrain.Click += new System.EventHandler(this.BrowseBtnClick);
			// 
			// textOther
			// 
			this.textOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textOther.Location = new System.Drawing.Point(78, 165);
			this.textOther.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textOther.Name = "textOther";
			this.textOther.Size = new System.Drawing.Size(344, 23);
			this.textOther.TabIndex = 1;
			this.textOther.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
			// 
			// btnOther
			// 
			this.btnOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnOther.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOther.ForeColor = System.Drawing.Color.Black;
			this.btnOther.Location = new System.Drawing.Point(426, 165);
			this.btnOther.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnOther.Name = "btnOther";
			this.btnOther.Size = new System.Drawing.Size(74, 23);
			this.btnOther.TabIndex = 1;
			this.btnOther.Tag = "browse";
			this.btnOther.Text = "Browse";
			this.btnOther.UseVisualStyleBackColor = false;
			this.btnOther.Click += new System.EventHandler(this.BrowseBtnClick);
			// 
			// textRailway
			// 
			this.textRailway.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textRailway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.textRailway.Location = new System.Drawing.Point(78, 60);
			this.textRailway.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.textRailway.Name = "textRailway";
			this.textRailway.Size = new System.Drawing.Size(344, 23);
			this.textRailway.TabIndex = 1;
			this.textRailway.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
			// 
			// btnRailway
			// 
			this.btnRailway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRailway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(205)))));
			this.btnRailway.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
			this.btnRailway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRailway.ForeColor = System.Drawing.Color.Black;
			this.btnRailway.Location = new System.Drawing.Point(426, 60);
			this.btnRailway.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnRailway.Name = "btnRailway";
			this.btnRailway.Size = new System.Drawing.Size(74, 23);
			this.btnRailway.TabIndex = 1;
			this.btnRailway.Tag = "browse";
			this.btnRailway.Text = "Browse";
			this.btnRailway.UseVisualStyleBackColor = false;
			this.btnRailway.Click += new System.EventHandler(this.BrowseBtnClick);
			// 
			// lblInsDirHint1
			// 
			this.lblInsDirHint1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblInsDirHint1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.lblInsDirHint1.Location = new System.Drawing.Point(6, 17);
			this.lblInsDirHint1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblInsDirHint1.Name = "lblInsDirHint1";
			this.lblInsDirHint1.Size = new System.Drawing.Size(500, 40);
			this.lblInsDirHint1.TabIndex = 0;
			this.lblInsDirHint1.Tag = "installdirhint1";
			this.lblInsDirHint1.Text = "Specify the \"Railway\" and \"Train\" folders at your preference.\r\nNOTE: On Windows, " +
	"DO NOT USE folders inside Program Files!";
			// 
			// ConfigDialog
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(26)))));
			this.ClientSize = new System.Drawing.Size(534, 381);
			this.Controls.Add(this.grpInsDir);
			this.Controls.Add(this.grpDatabase);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(10000, 420);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(450, 420);
			this.Name = "ConfigDialog";
			this.ShowIcon = false;
			this.Text = "Set up OpenBve Registry";
			this.grpDatabase.ResumeLayout(false);
			this.grpDatabase.PerformLayout();
			this.grpInsDir.ResumeLayout(false);
			this.grpInsDir.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
