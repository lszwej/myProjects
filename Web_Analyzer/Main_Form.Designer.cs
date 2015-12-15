namespace Łukasz_Szwej_Projekt
{
    partial class Main_Form
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
            this.addr_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.analy_but = new System.Windows.Forms.Button();
            this.save_but = new System.Windows.Forms.Button();
            this.reset_but = new System.Windows.Forms.Button();
            this.tags_choose = new System.Windows.Forms.CheckedListBox();
            this.sel_but = new System.Windows.Forms.Button();
            this.desel_but = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.res_gridview = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.save_dialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.res_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // addr_txt
            // 
            this.addr_txt.Location = new System.Drawing.Point(780, 28);
            this.addr_txt.Name = "addr_txt";
            this.addr_txt.Size = new System.Drawing.Size(237, 22);
            this.addr_txt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(540, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a website address";
            // 
            // analy_but
            // 
            this.analy_but.Location = new System.Drawing.Point(1046, 18);
            this.analy_but.Name = "analy_but";
            this.analy_but.Size = new System.Drawing.Size(169, 43);
            this.analy_but.TabIndex = 2;
            this.analy_but.Text = "Analyze";
            this.analy_but.UseVisualStyleBackColor = true;
            this.analy_but.Click += new System.EventHandler(this.analy_but_Click);
            // 
            // save_but
            // 
            this.save_but.Location = new System.Drawing.Point(203, 379);
            this.save_but.Name = "save_but";
            this.save_but.Size = new System.Drawing.Size(148, 42);
            this.save_but.TabIndex = 3;
            this.save_but.Text = "Save to file";
            this.save_but.UseVisualStyleBackColor = true;
            this.save_but.Click += new System.EventHandler(this.save_but_Click);
            // 
            // reset_but
            // 
            this.reset_but.Location = new System.Drawing.Point(390, 379);
            this.reset_but.Name = "reset_but";
            this.reset_but.Size = new System.Drawing.Size(156, 42);
            this.reset_but.TabIndex = 4;
            this.reset_but.Text = "Reset";
            this.reset_but.UseVisualStyleBackColor = true;
            this.reset_but.Click += new System.EventHandler(this.reset_but_Click);
            // 
            // tags_choose
            // 
            this.tags_choose.FormattingEnabled = true;
            this.tags_choose.Items.AddRange(new object[] {
            "doctype",
            "language",
            "charset",
            "keyword",
            "title",
            "script",
            "css",
            "css-inline",
            "image",
            "header",
            "form",
            "input",
            "link"});
            this.tags_choose.Location = new System.Drawing.Point(876, 139);
            this.tags_choose.Name = "tags_choose";
            this.tags_choose.Size = new System.Drawing.Size(321, 225);
            this.tags_choose.TabIndex = 7;
            // 
            // sel_but
            // 
            this.sel_but.Location = new System.Drawing.Point(904, 380);
            this.sel_but.Name = "sel_but";
            this.sel_but.Size = new System.Drawing.Size(111, 46);
            this.sel_but.TabIndex = 8;
            this.sel_but.Text = "Select all";
            this.sel_but.UseVisualStyleBackColor = true;
            this.sel_but.Click += new System.EventHandler(this.sel_but_Click);
            // 
            // desel_but
            // 
            this.desel_but.Location = new System.Drawing.Point(1057, 379);
            this.desel_but.Name = "desel_but";
            this.desel_but.Size = new System.Drawing.Size(96, 47);
            this.desel_but.TabIndex = 9;
            this.desel_but.Text = "Deselect ";
            this.desel_but.UseVisualStyleBackColor = true;
            this.desel_but.Click += new System.EventHandler(this.desel_but_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(874, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Select attributes/tags to the analysis";
            // 
            // res_gridview
            // 
            this.res_gridview.AllowUserToAddRows = false;
            this.res_gridview.AllowUserToDeleteRows = false;
            this.res_gridview.AllowUserToOrderColumns = true;
            this.res_gridview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.res_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.res_gridview.Location = new System.Drawing.Point(22, 139);
            this.res_gridview.Name = "res_gridview";
            this.res_gridview.ReadOnly = true;
            this.res_gridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.res_gridview.RowTemplate.Height = 24;
            this.res_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.res_gridview.Size = new System.Drawing.Size(817, 225);
            this.res_gridview.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(327, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Results of the analysis";
            // 
            // save_dialog
            // 
            this.save_dialog.DefaultExt = "*.txt";
            this.save_dialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 467);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.res_gridview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.desel_but);
            this.Controls.Add(this.sel_but);
            this.Controls.Add(this.tags_choose);
            this.Controls.Add(this.reset_but);
            this.Controls.Add(this.save_but);
            this.Controls.Add(this.analy_but);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addr_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main_Form";
            this.Text = "Web Analyzer 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.res_gridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addr_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button analy_but;
        private System.Windows.Forms.Button save_but;
        private System.Windows.Forms.Button reset_but;
        private System.Windows.Forms.Button sel_but;
        private System.Windows.Forms.Button desel_but;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView res_gridview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog save_dialog;
        private System.Windows.Forms.CheckedListBox tags_choose;
    }
}

