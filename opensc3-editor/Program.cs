using System;
using System.Windows.Forms;

namespace opensc3editor
{
	class Program
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		[STAThread]
		public static void Main (string[] args)
		{
			Application.EnableVisualStyles ();
			Application.Run (new MainWindow ());
		}

		/// <summary>
		/// Shows an error message and quits
		/// </summary>
		/// <param name="msg">Message.</param>
		/// <param name="ex">Ex.</param>
		public static void Fatal(string msg, Exception ex=null) {
			MessageBox.Show (msg + ((ex == null) ? "" : (Environment.NewLine + Environment.NewLine +
				"Exception: " + ex.Message)),
				"Error", MessageBoxButtons.OK, MessageBoxIcon.Error
			);

			Environment.Exit (0);
		}
	}
}
