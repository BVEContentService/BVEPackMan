
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PackManGui {
	/// <summary>
	/// Description of ProgressControl.
	/// </summary>
	public partial class ProgressControl : UserControl {
		public ProgressControl() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public override Color ForeColor {
			get {
				return base.ForeColor;
			}
			set {
				base.ForeColor = value;
				progressBox.ForeColor = value;
				progressBar.TextColor = value;
			}
		}
		
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public Color BarFillColor {
			get {
				return progressBar.ProgressColor;
			}
			set {
				progressBar.ProgressColor = value;
			}
		}
		
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public Color BoxColor {
			get {
				return progressBox.BackColor;
			}
			set {
				progressBox.BackColor = value;
			}
		}
		
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public LogLevel LogLevel { get; set; }
		
		public void PushBar(long? totalWork, long? finishedWork, double? ratio) {
			progressBar.TotalWork = totalWork;
			progressBar.FinishedWork = finishedWork;
			progressBar.Ratio = ratio;
			progressBar.Invalidate();
		}
		
		public void PushList(LogLevel level, string message) {
			if (level >= LogLevel) {
				progressBox.AppendText(message + Environment.NewLine);
			}
		}
		
		public void ResetBar() {
			progressBar.CustomText = "";
			progressBar.ProgressColor = Color.FromArgb(80, 205, 206);
			PushBar(null, null, null);
		}
		
		public void ResetList() {
			progressBox.Text = "";
		}
		
		public void ResetUI() {
			ResetBar();
			ResetList();
		}
		
		private async Task<Button> WaitBtn(Button btn) {
			await btn;
			return btn;
		}
		
		public async Task ShowBtnWait() {
			btnOK.Show();
			await btnOK;
			btnOK.Hide();
		}
		
		public async Task<bool> ShowBtnChoice() {
			btnOK.Show();
			btnCancel.Show();
			var result = await Task.WhenAny(WaitBtn(btnOK), WaitBtn(btnCancel));
			btnOK.Hide();
			btnCancel.Hide();
			return result.Result == btnOK;
		}
	}
}
