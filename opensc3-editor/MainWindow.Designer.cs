namespace opensc3editor {
    partial class MainWindow {
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSepMenu = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNewMenu,
            this.fileOpenMenu,
            this.fileSepMenu,
            this.fileExitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileNewMenu
            // 
            this.fileNewMenu.Enabled = false;
            this.fileNewMenu.Name = "fileNewMenu";
            this.fileNewMenu.Size = new System.Drawing.Size(152, 22);
            this.fileNewMenu.Text = "New";
            // 
            // fileOpenMenu
            // 
            this.fileOpenMenu.Name = "fileOpenMenu";
            this.fileOpenMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenu.Size = new System.Drawing.Size(152, 22);
            this.fileOpenMenu.Text = "Open";
            this.fileOpenMenu.Click += new System.EventHandler(this.fileOpenMenu_Click);
            // 
            // fileSepMenu
            // 
            this.fileSepMenu.Name = "fileSepMenu";
            this.fileSepMenu.Size = new System.Drawing.Size(149, 6);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            this.fileExitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.fileExitMenu.Size = new System.Drawing.Size(152, 22);
            this.fileExitMenu.Text = "Exit";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "OpenSC3 Editor";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileNewMenu;
        private System.Windows.Forms.ToolStripSeparator fileSepMenu;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenu;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenu;
    }
}