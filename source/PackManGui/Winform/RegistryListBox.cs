using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Zbx1425.PWPackMan;

namespace Zbx1425.PackManGui {
  
	public class LocalRegistryListBox : ListBox {
		
		private const double VMajorPadding = 0.3;
		private const double VMinorPadding = 0.1;
		private const double HPadding = 0.5;
		private const double BigFontSize = 1.5;
		
		private const int fieldNameWidth = 200;
		private const int sealCenter = 295;
		
		public LocalRegistryListBox()
			: base() {
			DrawMode = DrawMode.OwnerDrawVariable;
		}
		
		#region Properties
		
		protected override void OnLayout(LayoutEventArgs levent) {
			bigFont = new Font(Font.FontFamily, Font.Size * 1.5f, FontStyle.Bold, Font.Unit);
			this.ForeColor = ForeColor;
			this.BackColor = BackColor;
			this.BorderColor = BorderColor;
			this.SealBorderColor = SealBorderColor;
			this.SealColor = SealColor;
			this.SecondaryColor = SecondaryColor;
			this.SelectedColor = SelectedColor;
			this.IDColor = IDColor;
			this.WarnColor = WarnColor;
			base.OnLayout(levent);
		}
		
		private Font bigFont;
		
		private SolidBrush textBrush;
		private Pen backPen;
		private SolidBrush backBrush;
		
		private Color borderColor = Color.Black;
		private Pen borderPen;
		private Color sealBorderColor = Color.Black;
		private Pen sealBorderPen;
		private Color sealColor = Color.AliceBlue;
		private Pen sealPen;
		private SolidBrush sealBrush;
		private Color secondaryColor = Color.DarkGray;
		private SolidBrush secondaryBrush;
		private Color selectedColor = Color.AliceBlue;
		private SolidBrush selectedBrush;
		private Color idColor = Color.Blue;
		private SolidBrush idBrush;
		private Color warnColor = Color.Goldenrod;
		private SolidBrush warnBrush;
		
		public override Color ForeColor {
			get {
				return base.ForeColor;
			}
			set {
				base.ForeColor = value;
				textBrush = new SolidBrush(base.ForeColor);
			}
		} 
		
		public override Color BackColor {
			get {
				return base.BackColor;
			}
			set {
				base.BackColor = value;
				backPen = new Pen(base.BackColor);
				backBrush = new SolidBrush(base.BackColor);
			}
		}
		
		public override Font Font {
			get {
				return base.Font;
			}
			set {
				base.Font = value;
				bigFont = new Font(value.FontFamily, value.Size * (float)BigFontSize, FontStyle.Bold, value.Unit);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color BorderColor {
			get {
				return borderColor;
			}
			set {
				borderColor = value;
				borderPen = new Pen(borderColor);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color SealBorderColor {
			get {
				return sealBorderColor;
			}
			set {
				sealBorderColor = value;
				sealBorderPen = new Pen(sealBorderColor, 2);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color SealColor {
			get {
				return sealColor;
			}
			set {
				sealColor = value;
				sealPen = new Pen(sealColor);
				sealBrush = new SolidBrush(sealColor);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color SecondaryColor {
			get {
				return secondaryColor;
			}
			set {
				secondaryColor = value;
				secondaryBrush = new SolidBrush(secondaryColor);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color SelectedColor {
			get {
				return selectedColor;
			}
			set {
				selectedColor = value;
				selectedBrush = new SolidBrush(selectedColor);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color IDColor {
			get {
				return idColor;
			}
			set {
				idColor = value;
				idBrush = new SolidBrush(idColor);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color WarnColor {
			get {
				return warnColor;
			}
			set {
				warnColor = value;
				warnBrush = new SolidBrush(warnColor);
			}
		}
		
		#endregion
		
		private Tuple<string, string>[] getObjProps(object obj) {
			string[] hiddenProps = { "PlatformName", "IsFromAutoDetect" };
			return obj.GetType().GetProperties()
				.Where(p => !hiddenProps.Contains(p.Name))
				//.Select(p => new Tuple<string, string>(p.Name, 
                //   "The End Is Never The End Is Never The End Is Never The End Is Never The End")) Testing
				.Select(p => new Tuple<string, string>(p.Name, p.GetValue(obj) == null ? "(NULL)" :  p.GetValue(obj).ToString()))
				.ToArray();
		}
		
		protected override void OnMeasureItem(MeasureItemEventArgs e) {
			if (e.Index >= this.Items.Count)
				return;
			if (e.Index < 0)
				return;
			var props = getObjProps(this.Items[e.Index]);
			e.ItemWidth = this.Width - 6;
			if ((e.Index > 0 &&
			    !((IRegistry)this.Items[e.Index - 1]).IsFromAutoDetect &&
			    ((IRegistry)this.Items[e.Index]).IsFromAutoDetect) ||
			    (e.Index == 0 && ((IRegistry)this.Items[e.Index]).IsFromAutoDetect)) {
				e.ItemHeight = Convert.ToInt32((props.Length + (props.Length - 1) * VMinorPadding + 4 * VMajorPadding + BigFontSize + 1) * FontHeight);
			} else {
				e.ItemHeight = Convert.ToInt32((props.Length + (props.Length - 1) * VMinorPadding + 3 * VMajorPadding + BigFontSize) * FontHeight);
			}
			base.OnMeasureItem(e);
		}
		
		protected override void OnDrawItem(DrawItemEventArgs e) {
			if (e.Index >= this.Items.Count)
				return;
			if (e.Index < 0)
				return;
			bool atSplitPosition = (e.Index > 0 &&
			                       !((IRegistry)this.Items[e.Index - 1]).IsFromAutoDetect &&
			                       ((IRegistry)this.Items[e.Index]).IsFromAutoDetect) ||
			                       (e.Index == 0 && ((IRegistry)this.Items[e.Index]).IsFromAutoDetect);
			var item = this.Items[e.Index] as IRegistry;
			var props = getObjProps(item);
			if (atSplitPosition)
				e.Graphics.TranslateTransform(0, Convert.ToInt32((VMajorPadding + 1) * FontHeight));
			if (e.State.HasFlag(DrawItemState.Selected)) {
				e.Graphics.ResetTransform();
				e.Graphics.FillRectangle(selectedBrush, e.Bounds);
				e.Graphics.DrawRectangle(borderPen, e.Bounds);
				if (atSplitPosition)
					e.Graphics.TranslateTransform(0, Convert.ToInt32((VMajorPadding + 1) * FontHeight));
				Point[] triangle = {
					new Point(sealCenter - 10, e.Bounds.Y), 
					new Point(sealCenter, e.Bounds.Y + 15), 
					new Point(sealCenter + 10, e.Bounds.Y)
				};
				e.Graphics.FillPolygon(sealBrush, triangle);
				e.Graphics.DrawPolygon(sealBorderPen, triangle);
				e.Graphics.DrawLine(sealPen, 
					sealCenter - 10, e.Bounds.Y,
					sealCenter + 10, e.Bounds.Y
				);
			} else {
				e.Graphics.ResetTransform();
				e.Graphics.FillRectangle(backBrush, e.Bounds);
				e.Graphics.DrawRectangle(borderPen, e.Bounds);
				if (atSplitPosition)
					e.Graphics.TranslateTransform(0, Convert.ToInt32((VMajorPadding + 1) * FontHeight));
			}
			e.Graphics.FillRectangle(idBrush, 
				Convert.ToInt32(e.Bounds.X + HPadding * FontHeight),
				Convert.ToInt32(e.Bounds.Y + (VMajorPadding + BigFontSize) * FontHeight),
				e.Bounds.Width,
				2
			);
			var stringFormatA = new StringFormat(StringFormatFlags.NoWrap) {
				LineAlignment = StringAlignment.Center,
				Trimming = StringTrimming.EllipsisCharacter
			};
			var stringFormatB = new StringFormat(StringFormatFlags.NoWrap) { 
				LineAlignment = StringAlignment.Far,
				Trimming = StringTrimming.EllipsisCharacter 
			};
			var stringFormatC = new StringFormat(StringFormatFlags.NoWrap) { 
				LineAlignment = StringAlignment.Far,
				Alignment = StringAlignment.Far,
				Trimming = StringTrimming.EllipsisCharacter 
			};
			var friendlyPlatformName = I._("bpmplugin_" + item.PlatformName + "_friendlyname");
			 e.Graphics.DrawString(friendlyPlatformName, bigFont, textBrush,
			//   e.Graphics.DrawString("Test", bigFont, textBrush, // Testing
				new Rectangle(
					Convert.ToInt32(e.Bounds.X + HPadding * FontHeight),
					Convert.ToInt32(e.Bounds.Y + VMajorPadding * FontHeight),
					Convert.ToInt32(e.Bounds.Width - 2 * HPadding * FontHeight),
					Convert.ToInt32(FontHeight * BigFontSize)
				), stringFormatA
			);
			var titleOffsetA = e.Graphics.MeasureString(friendlyPlatformName, bigFont).Width;
			// var titleOffsetA = e.Graphics.MeasureString("Test", bigFont).Width;
			e.Graphics.DrawString(item.GetHashCode().ToString("X8"), bigFont, secondaryBrush,
				new Rectangle(
					Convert.ToInt32(e.Bounds.X + HPadding * 2 * FontHeight + titleOffsetA),
					Convert.ToInt32(e.Bounds.Y + VMajorPadding * FontHeight),
					Convert.ToInt32(e.Bounds.Width - 2 * HPadding * FontHeight - titleOffsetA),
					Convert.ToInt32(FontHeight * BigFontSize)
				), stringFormatA
			);
			if (item.IsFromAutoDetect) {
				var titleOffsetB = e.Graphics.MeasureString(item.GetHashCode().ToString("X8"), bigFont).Width;
				e.Graphics.DrawString(I._("bpmgui_reglistbox_warnautodet"), Font, warnBrush,
					new Rectangle(
						Convert.ToInt32(e.Bounds.X + HPadding * 3 * FontHeight + titleOffsetA + titleOffsetB),
						Convert.ToInt32(e.Bounds.Y + VMajorPadding * FontHeight),
						Convert.ToInt32(e.Bounds.Width - 4 * HPadding * FontHeight - titleOffsetA - titleOffsetB),
						Convert.ToInt32(FontHeight * BigFontSize)
					), stringFormatC
				);
			}
			for (int i = 0; i < props.Length; i++) {
				e.Graphics.DrawString(props[i].Item1, Font, secondaryBrush, 
					new Rectangle(
						Convert.ToInt32(e.Bounds.X + HPadding * FontHeight),
						Convert.ToInt32(e.Bounds.Y + (VMajorPadding * 2 + BigFontSize + (VMinorPadding + 1) * i) * FontHeight),
						fieldNameWidth,
						FontHeight
					), stringFormatA
				);
				e.Graphics.DrawString(props[i].Item2, Font, secondaryBrush, 
					new Rectangle(
						Convert.ToInt32(e.Bounds.X + HPadding * 2 * FontHeight + fieldNameWidth),
						Convert.ToInt32(e.Bounds.Y + (VMajorPadding * 2 + BigFontSize + (VMinorPadding + 1) * i) * FontHeight),
						Convert.ToInt32((e.Bounds.Width - 3 * HPadding * FontHeight) - fieldNameWidth),
						FontHeight
					), stringFormatA
				);                                  
			}
			if (atSplitPosition) {
				e.Graphics.ResetTransform();
				e.Graphics.FillRectangle(idBrush,
					new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, Convert.ToInt32((VMajorPadding + 1) * FontHeight))
				);
				e.Graphics.DrawRectangle(borderPen,
					new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, Convert.ToInt32((VMajorPadding + 1) * FontHeight))
				);
				e.Graphics.DrawString(I._("bpmgui_reglistbox_headerautodet"), Font, textBrush,
					new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, FontHeight), stringFormatA
				);
				if (e.State.HasFlag(DrawItemState.Selected)) {
					e.Graphics.FillRectangle(sealBrush, 
						new Rectangle(sealCenter - 10, e.Bounds.Y, 20, Convert.ToInt32((VMajorPadding + 1) * FontHeight))
					);
					e.Graphics.DrawLine(sealPen, 
						sealCenter - 10, Convert.ToInt32(e.Bounds.Y + (VMajorPadding + 1) * FontHeight),
						sealCenter + 10, Convert.ToInt32(e.Bounds.Y + (VMajorPadding + 1) * FontHeight)
					);
					e.Graphics.DrawLine(sealBorderPen, 
						sealCenter - 10, e.Bounds.Y,
						sealCenter - 10, Convert.ToInt32(e.Bounds.Y + (VMajorPadding + 1) * FontHeight)
					);
					e.Graphics.DrawLine(sealBorderPen, 
						sealCenter + 10, e.Bounds.Y,
						sealCenter + 10, Convert.ToInt32(e.Bounds.Y + (VMajorPadding + 1) * FontHeight)
					);
				}
			}
			base.OnDrawItem(e);
		}
		
		/*
	  	[System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "SendMessage")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		*/
		
		public void ForceMeasure() {
			this.RecreateHandle();
			/*
			var dc = this.CreateGraphics();
			for (int i = 0; i < Items.Count; i++) {
				MeasureItemEventArgs eArgs = new MeasureItemEventArgs(dc, i);
				OnMeasureItem(eArgs);
				SendMessage(this.Handle, 0x01A0, i, eArgs.ItemHeight);
			}
			Refresh();
			*/
		}
		
		protected override void OnResize(EventArgs e) {
			// How can I support dirty region?
			// Text rendering cannot support dirty region, since you cannot cut a char in half.
			// Although - it is actually possible, I don't want to display text like that.
			// Plus, right-aligned text and ellipsis also won't work under the default dirty region
			// redraw policy, for the apparant and same reason.
			// I will force a total refresh, as a workaround.
			// zbx1425 2020/10/31
			this.Invalidate();
			
			base.OnResize(e);
		}
	}
}
