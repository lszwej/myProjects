namespace ChatterBot
{
    partial class ChatterBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTxtBox = new System.Windows.Forms.RichTextBox();
            this.sendbut = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.clearbut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.soundMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTxtBox
            // 
            this.richTxtBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTxtBox.Location = new System.Drawing.Point(12, 34);
            this.richTxtBox.Name = "richTxtBox";
            this.richTxtBox.ReadOnly = true;
            this.richTxtBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTxtBox.ShowSelectionMargin = true;
            this.richTxtBox.Size = new System.Drawing.Size(536, 200);
            this.richTxtBox.TabIndex = 0;
            this.richTxtBox.Text = "";
            this.richTxtBox.WordWrap = false;
            // 
            // sendbut
            // 
            this.sendbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sendbut.Location = new System.Drawing.Point(328, 261);
            this.sendbut.Name = "sendbut";
            this.sendbut.Size = new System.Drawing.Size(108, 34);
            this.sendbut.TabIndex = 1;
            this.sendbut.Text = "Send";
            this.sendbut.UseVisualStyleBackColor = true;
            this.sendbut.Click += new System.EventHandler(this.sendbut_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(125, 269);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(197, 20);
            this.input.TabIndex = 2;
            this.input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // clearbut
            // 
            this.clearbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clearbut.Location = new System.Drawing.Point(442, 260);
            this.clearbut.Name = "clearbut";
            this.clearbut.Size = new System.Drawing.Size(108, 34);
            this.clearbut.TabIndex = 3;
            this.clearbut.Text = "Clear";
            this.clearbut.UseVisualStyleBackColor = true;
            this.clearbut.Click += new System.EventHandler(this.clearbut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.saveMenu,
            this.soundMenu,
            this.exitMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenu.Size = new System.Drawing.Size(146, 22);
            this.openMenu.Text = "Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenu.Size = new System.Drawing.Size(146, 22);
            this.saveMenu.Text = "Save";
            this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
            // 
            // soundMenu
            // 
            this.soundMenu.Name = "soundMenu";
            this.soundMenu.Size = new System.Drawing.Size(146, 22);
            this.soundMenu.Text = "Sound";
            this.soundMenu.Click += new System.EventHandler(this.soundMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(146, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type text here";
            // 
            // ChatterBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 329);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearbut);
            this.Controls.Add(this.input);
            this.Controls.Add(this.sendbut);
            this.Controls.Add(this.richTxtBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ChatterBot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatterBot ver 1.0";
            this.Load += new System.EventHandler(this.ChatterBot_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTxtBox;
        private System.Windows.Forms.Button sendbut;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button clearbut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem soundMenu;
        private System.Windows.Forms.Label label1;
    }
}

