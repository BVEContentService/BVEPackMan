
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zbx1425.OpenBveRegistry
{
	/// <summary>
	/// Description of ConfigDialog.
	/// </summary>
	public partial class ConfigDialog : Form
	{
		public ConfigDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnOKClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		void BtnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
