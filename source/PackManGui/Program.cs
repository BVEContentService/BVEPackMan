
using System;
using System.IO;
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
			try {
				RegistryManager.LoadConfig();
				PreferenceManager.LoadConfig();
			} catch (Exception ex) {
				File.Delete(RegistryManager.ConfigPath);
				File.Delete(PreferenceManager.ConfigPath);
				try {
					RegistryManager.LoadConfig();
					PreferenceManager.LoadConfig();
				} catch (Exception ex2) {
					MessageBox.Show("Failure during loading." + Environment.NewLine + ex2.ToString(), 
					                "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				MessageBox.Show(I._("bpmgui_msg_configautoreset", ex.ToString()), "Sorry",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			
			RegistryManager.SaveConfig();
			PreferenceManager.SaveConfig();
		}
		
	}
}
