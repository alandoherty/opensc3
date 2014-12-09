namespace opensc3editor {
    partial class PackageEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.data = new System.Windows.Forms.RichTextBox();
            this.treeSplit = new System.Windows.Forms.SplitContainer();
            this.buttonIn = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeSplit)).BeginInit();
            this.treeSplit.Panel1.SuspendLayout();
            this.treeSplit.Panel2.SuspendLayout();
            this.treeSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.treeSplit);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.data);
            this.mainSplit.Size = new System.Drawing.Size(484, 461);
            this.mainSplit.SplitterDistance = 161;
            this.mainSplit.TabIndex = 0;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(161, 426);
            this.tree.TabIndex = 0;
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            // 
            // data
            // 
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.Location = new System.Drawing.Point(0, 0);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(319, 461);
            this.data.TabIndex = 0;
            this.data.Text = "";
            // 
            // treeSplit
            // 
            this.treeSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSplit.Location = new System.Drawing.Point(0, 0);
            this.treeSplit.Name = "treeSplit";
            this.treeSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // treeSplit.Panel1
            // 
            this.treeSplit.Panel1.Controls.Add(this.tree);
            // 
            // treeSplit.Panel2
            // 
            this.treeSplit.Panel2.Controls.Add(this.buttonDel);
            this.treeSplit.Panel2.Controls.Add(this.button1);
            this.treeSplit.Panel2.Controls.Add(this.buttonRename);
            this.treeSplit.Panel2.Controls.Add(this.buttonIn);
            this.treeSplit.Size = new System.Drawing.Size(161, 461);
            this.treeSplit.SplitterDistance = 426;
            this.treeSplit.TabIndex = 1;
            // 
            // buttonIn
            // 
            this.buttonIn.Location = new System.Drawing.Point(4, 4);
            this.buttonIn.Name = "buttonIn";
            this.buttonIn.Size = new System.Drawing.Size(36, 23);
            this.buttonIn.TabIndex = 0;
            this.buttonIn.Text = "In";
            this.buttonIn.UseVisualStyleBackColor = true;
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(43, 4);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(36, 23);
            this.buttonRename.TabIndex = 2;
            this.buttonRename.Text = "Out";
            this.buttonRename.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(121, 4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(36, 23);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Del";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // PackageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.mainSplit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PackageEditor";
            this.Text = "PAK";
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.treeSplit.Panel1.ResumeLayout(false);
            this.treeSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeSplit)).EndInit();
            this.treeSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        public System.Windows.Forms.RichTextBox data;
        public System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.SplitContainer treeSplit;
        private System.Windows.Forms.Button buttonIn;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRename;
    }
}