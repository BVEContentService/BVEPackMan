
using System;
using System.Windows.Forms;
using Zbx1425.PackManGui.Plugin;

namespace Zbx1425.PackManGui
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			
			RegistryManager.SaveConfig();
			PreferenceManager.SaveConfig();
		}
		
	}
}
