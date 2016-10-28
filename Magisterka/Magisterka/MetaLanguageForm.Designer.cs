namespace Magisterka
{
    partial class MetaLanguageForm
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
            this.metaQueryBut = new System.Windows.Forms.Button();
            this.clearBut = new System.Windows.Forms.Button();
            this.metaQueryTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // metaQueryBut
            // 
            this.metaQueryBut.Location = new System.Drawing.Point(47, 359);
            this.metaQueryBut.Name = "metaQueryBut";
            this.metaQueryBut.Size = new System.Drawing.Size(134, 45);
            this.metaQueryBut.TabIndex = 0;
            this.metaQueryBut.Text = "Execute query";
            this.metaQueryBut.UseVisualStyleBackColor = true;
            this.metaQueryBut.Click += new System.EventHandler(this.metaQueryBut_Click);
            // 
            // clearBut
            // 
            this.clearBut.Location = new System.Drawing.Point(423, 359);
            this.clearBut.Name = "clearBut";
            this.clearBut.Size = new System.Drawing.Size(110, 48);
            this.clearBut.TabIndex = 1;
            this.clearBut.Text = "Clear text";
            this.clearBut.UseVisualStyleBackColor = true;
            this.clearBut.Click += new System.EventHandler(this.clearBut_Click);
            // 
            // metaQueryTextBox
            // 
            this.metaQueryTextBox.DetectUrls = false;
            this.metaQueryTextBox.Location = new System.Drawing.Point(47, 58);
            this.metaQueryTextBox.Name = "metaQueryTextBox";
            this.metaQueryTextBox.Size = new System.Drawing.Size(486, 264);
            this.metaQueryTextBox.TabIndex = 2;
            this.metaQueryTextBox.Text = "";
            // 
            // MetaLanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 430);
            this.Controls.Add(this.metaQueryTextBox);
            this.Controls.Add(this.clearBut);
            this.Controls.Add(this.metaQueryBut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MetaLanguageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Type meta language query";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button metaQueryBut;
        private System.Windows.Forms.Button clearBut;
        private System.Windows.Forms.RichTextBox metaQueryTextBox;
    }
}