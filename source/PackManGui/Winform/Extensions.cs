using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Zbx1425.PackManGui {
  
	public static class Extensions {
  
		public static ButtonAwaiter GetAwaiter(this Button button) {
			return new ButtonAwaiter() {
				Button = button
			};
		}
	}
	
	public class ButtonAwaiter : INotifyCompletion {
		
		public bool IsCompleted {
			get { return false; }
		}

		public void GetResult() {

		}

		public Button Button { get; set; }

		public void OnCompleted(Action continuation) {
			EventHandler h = null;
			h = (o, e) => {
				Button.Click -= h;
				continuation();
			};
			Button.Click += h;
		}
	}
}
