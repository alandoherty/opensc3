using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using opensc3lib;

namespace opensc3editor {
    public partial class PackageEditor : Form {
		#region Fields
		private PAK _pak;
		private string _current;
		#endregion

		#region Methods
		/// <summary>
		/// Select a file for editing.
		/// </summary>
		/// <param name="file">File.</param>
		public void Select(string file) {
			data.Text = string.Join (Environment.NewLine, _pak.Entries [file].Values);
			_current = file;
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="opensc3editor.PackageEditor"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		public PackageEditor(string path) {
			// initialize
            InitializeComponent();

			// load
			_pak = new PAK (path);

			// create tree
			foreach (KeyValuePair<string,PAKEntry> kv in _pak.Entries) {
				TreeNode node = new TreeNode (kv.Key);
				node.Tag = kv.Key;
				tree.Nodes.Add (node);
			}
        }
		#endregion

		#region Events
        private void tree_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e) {
            Select((string)e.Node.Tag);
        }
		#endregion
    }
}
