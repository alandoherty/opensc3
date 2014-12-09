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
        private string _pakPath = "";

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

            // update ui
            UpdateUI();
		}

        /// <summary>
        /// Adds a file.
        /// </summary>
        public void Add() {
            // new entry
            PackageEditorEntry entry = new PackageEditorEntry();

            if (entry.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                // check if already exists
                if (_pak.Exists(entry.Name)) {
                    MessageBox.Show("An entry already exists with the same name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // add to pak
                _pak.Add(entry.Name);

                // add to tree
                tree.Nodes.Add(new TreeNode() {
                    Text = entry.Name,
                    Tag = entry.Name
                });
            }
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        public void Delete() {
            if (tree.SelectedNode != null) {
                // get entry
                string entry = (string)tree.SelectedNode.Tag;

                // remove from pak
                _pak.Remove(entry);

                // remove from tree
                tree.Nodes.Remove(tree.SelectedNode);

                // select next available file
                if (_pak.Entries.Count > 0)
                    Select(_pak.Entries.First().Key);
            }
        }

        /// <summary>
        /// Updates the UI.
        /// </summary>
        public void UpdateUI() {
            // title
            Text = _current;
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
            try {
                _pak = new PAK(path);
            } catch (Exception ex) {
                Program.Fatal("Unable to open PAK file", ex);
            } finally {
                 _pakPath = path;
            }

			// create tree
			foreach (KeyValuePair<string,PAKEntry> kv in _pak.Entries) {
				TreeNode node = new TreeNode (kv.Key);
				node.Tag = kv.Key;
				tree.Nodes.Add (node);
			}

            // select first
            if (_pak.Entries.Count > 0)
                Select(_pak.Entries.First().Key);
        }
		#endregion

		#region Events
        private void tree_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e) {
            Select((string)e.Node.Tag);
        }

        private void button1_Click(object sender, EventArgs e) {
            Add();
        }

        private void data_TextChanged(object sender, EventArgs e) {
            // lines
            string[] lines = data.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // set as values
            _pak.Entries[_current].Values = new List<string>(lines);
        }

        private void buttonDel_Click(object sender, EventArgs e) {
            Delete();
        }
        #endregion
    }
}
