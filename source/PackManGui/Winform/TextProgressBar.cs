using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ukushu {

	public class TextProgressBar : Control {
		[Description("Font of the text on ProgressBar"), Category("Additional Options")]
		public Font TextFont { get; set; }
		
		public TextProgressBar() {
			TextFont = new Font(SystemFonts.CaptionFont.FontFamily, 14, 
				FontStyle.Bold, GraphicsUnit.Pixel);
			FixComponentBlinking();
		}
        
		private SolidBrush _textColourBrush = (SolidBrush)Brushes.Black;
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public Color TextColor {
			get {
				return _textColourBrush.Color;
			}
			set {
				_textColourBrush.Dispose();
				_textColourBrush = new SolidBrush(value);
			}
		}

		private SolidBrush _progressColourBrush = (SolidBrush)Brushes.LightGreen;
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public Color ProgressColor {
			get {
				return _progressColourBrush.Color;
			}
			set {
				_progressColourBrush.Dispose();
				_progressColourBrush = new SolidBrush(value);
			}
		}

		private string _text = string.Empty;

		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public string CustomText {
			get {
				return _text;
			}
			set {
				_text = value;
				Invalidate(); //redraw component after change value from VS Properties section
			}
		}
		
		private long? _totalWork;
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public long? TotalWork {
			get { return _totalWork; }
			set {
				_totalWork = value;
				// Invalidate();
			}
		}
		
		private long? _finishedWork;
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public long? FinishedWork {
			get { return _finishedWork; }
			set {
				_finishedWork = value;
				// Invalidate();
			}
		}
		
		private double? _ratio;
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public double? Ratio {
			get { return _ratio; }
			set {
				_ratio = value;
				// Invalidate();
			}
		}

		private void FixComponentBlinking() {
			SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
            
			DrawProgressBar(g);

			DrawStringIfNeeded(g);
		}

		private void DrawProgressBar(Graphics g) {
			Rectangle rect = ClientRectangle;

			ProgressBarRenderer.DrawHorizontalBar(g, rect);

			rect.Inflate(-3, -3);

			if (Ratio.HasValue && Ratio > 0) {
				Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round((float)(Math.Min(Ratio.Value, 100) / 100 * rect.Width)), rect.Height);

				g.FillRectangle(_progressColourBrush, clip);
			}
		}
		
		private static string ToReadableUnit(long byteCount) {
			string[] suf = { "", "K", "M", "G", "T", "P", "E" }; //Longs run out around EB
			if (byteCount == 0)
				return "0" + suf[0];
			long bytes = Math.Abs(byteCount);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1000)));
			double num = Math.Round(bytes / Math.Pow(1000, place), 1);
			return (Math.Sign(byteCount) * num).ToString() + suf[place];
		}

		private void DrawStringIfNeeded(Graphics g) {
			string text = CustomText;
			if (FinishedWork.HasValue)
				text += ToReadableUnit(FinishedWork.Value);
			if (TotalWork.HasValue)
				text += " / " + ToReadableUnit(TotalWork.Value);
			if (Ratio.HasValue && Ratio >= 0 && Ratio <= 100)
				text += " " + (Ratio.Value / 100).ToString("P");

			SizeF len = g.MeasureString(text, TextFont);

			Point location = new Point(((Width / 2) - (int)len.Width / 2), ((Height / 2) - (int)len.Height / 2));
            
			g.DrawString(text, TextFont, (Brush)_textColourBrush, location);
		}
        
		public new void Dispose() {
			_textColourBrush.Dispose();
			_progressColourBrush.Dispose();
			base.Dispose();
		}
	}
}
