using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace opensc3editor {
    public partial class MainWindow : Form 
	{
		#region Methods
		/// <summary>
		/// Opens a file.
		/// </summary>
		public void OpenFile() {
			// dialog
			OpenFileDialog ofd = new OpenFileDialog ();
			ofd.Title = "Open Data";
			ofd.Filter = "IXF Files|*.ixf|DAT Files|*.dat|PAK Files|*.pak";

			// show
			if (ofd.ShowDialog () != DialogResult.OK)
				return;

			// switch extension
			switch (Path.GetExtension(ofd.FileName).ToLower()) {
			case ".pak":
				// pak
				PackageEditor editor = new PackageEditor (ofd.FileName);
				editor.MdiParent = this;
				editor.Show ();
				break;
			default:
				// unknown
				Program.Fatal ("Unknown file extension " + Path.GetExtension(ofd.FileName));
				break;
            }
		}
		#endregion

        #region Constructors
        public MainWindow() {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void MainWindow_Load(object sender, EventArgs e) {
            // form icon
            try {
                // load bitmap and make transparent
                Bitmap icon = (Bitmap)Bitmap.FromFile("Res/icon.bmp");
                icon.MakeTransparent(Color.Magenta);

                // create icon from handle
                this.Icon = Icon.FromHandle(icon.GetHicon());
            } catch (Exception ex) {
                Program.Fatal("Unable to load icon, redownload resource folder", ex);
            }
        }

        private void fileOpenMenu_Click(object sender, EventArgs e) {
			OpenFile ();
        }
        #endregion
    }
}
