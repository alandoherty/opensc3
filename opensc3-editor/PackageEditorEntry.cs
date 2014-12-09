using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opensc3editor {
    public partial class PackageEditorEntry : Form {
        #region Properties        
        /// <summary>
        /// Gets the name of the entry.
        /// </summary>
        public string Name {
            get {
                return textName.Text;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageEditorEntry"/> class.
        /// </summary>
        public PackageEditorEntry() {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageEditorEntry"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PackageEditorEntry(string name) {
            InitializeComponent();

            // set text
            textName.Text = name;
        }
        #endregion

        #region Events
        private void buttonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonYes_Click(object sender, EventArgs e) {
            // check not empty
            if (textName.Text == "") {
                MessageBox.Show("The name entered is invalid");
                return;
            }

            // append ini if need be
            if (!textName.Text.ToLower().EndsWith(".ini")) {
                textName.Text = textName.Text + ".ini";
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        
    }
}
