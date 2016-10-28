namespace Magisterka
{
    partial class InsertForm
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
            this.insertGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.executeBut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.insertGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertGridView
            // 
            this.insertGridView.AllowUserToAddRows = false;
            this.insertGridView.AllowUserToDeleteRows = false;
            this.insertGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insertGridView.Location = new System.Drawing.Point(18, 38);
            this.insertGridView.Name = "insertGridView";
            this.insertGridView.RowTemplate.Height = 24;
            this.insertGridView.Size = new System.Drawing.Size(501, 244);
            this.insertGridView.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enter values";
            // 
            // executeBut
            // 
            this.executeBut.Location = new System.Drawing.Point(198, 308);
            this.executeBut.Name = "executeBut";
            this.executeBut.Size = new System.Drawing.Size(133, 36);
            this.executeBut.TabIndex = 12;
            this.executeBut.Text = "Execute query";
            this.executeBut.UseVisualStyleBackColor = true;
            this.executeBut.Click += new System.EventHandler(this.executeBut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.executeBut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.insertGridView);
            this.panel1.Location = new System.Drawing.Point(39, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 352);
            this.panel1.TabIndex = 13;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 385);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "InsertForm";
            this.Text = "Insert record";
            ((System.ComponentModel.ISupportInitialize)(this.insertGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView insertGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button executeBut;
        private System.Windows.Forms.Panel panel1;
    }
}