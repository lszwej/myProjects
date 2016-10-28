namespace Magisterka
{
    partial class SubqueryForm
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
            this.tableCombo = new System.Windows.Forms.ComboBox();
            this.columnsCheckBox = new System.Windows.Forms.CheckedListBox();
            this.selectAllCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.negateBox = new System.Windows.Forms.CheckBox();
            this.valueBut = new System.Windows.Forms.Button();
            this.addCondBut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.queryOperCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.valueText = new System.Windows.Forms.TextBox();
            this.columnCombo = new System.Windows.Forms.ComboBox();
            this.compareOperCombo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.generQueryBut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableCombo
            // 
            this.tableCombo.FormattingEnabled = true;
            this.tableCombo.Location = new System.Drawing.Point(17, 57);
            this.tableCombo.Name = "tableCombo";
            this.tableCombo.Size = new System.Drawing.Size(121, 24);
            this.tableCombo.TabIndex = 0;
            this.tableCombo.SelectedIndexChanged += new System.EventHandler(this.tableCombo_SelectedIndexChanged);
            // 
            // columnsCheckBox
            // 
            this.columnsCheckBox.FormattingEnabled = true;
            this.columnsCheckBox.Location = new System.Drawing.Point(186, 57);
            this.columnsCheckBox.Name = "columnsCheckBox";
            this.columnsCheckBox.Size = new System.Drawing.Size(180, 208);
            this.columnsCheckBox.TabIndex = 1;
            // 
            // selectAllCheck
            // 
            this.selectAllCheck.AutoSize = true;
            this.selectAllCheck.Location = new System.Drawing.Point(186, 285);
            this.selectAllCheck.Name = "selectAllCheck";
            this.selectAllCheck.Size = new System.Drawing.Size(87, 21);
            this.selectAllCheck.TabIndex = 2;
            this.selectAllCheck.Text = "Select all";
            this.selectAllCheck.UseVisualStyleBackColor = true;
            this.selectAllCheck.CheckedChanged += new System.EventHandler(this.selectAllCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select table";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.negateBox);
            this.panel1.Controls.Add(this.valueBut);
            this.panel1.Controls.Add(this.addCondBut);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.queryOperCombo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.valueText);
            this.panel1.Controls.Add(this.columnCombo);
            this.panel1.Controls.Add(this.compareOperCombo);
            this.panel1.Location = new System.Drawing.Point(418, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 197);
            this.panel1.TabIndex = 15;
            // 
            // negateBox
            // 
            this.negateBox.AutoSize = true;
            this.negateBox.Location = new System.Drawing.Point(152, 48);
            this.negateBox.Name = "negateBox";
            this.negateBox.Size = new System.Drawing.Size(116, 21);
            this.negateBox.TabIndex = 21;
            this.negateBox.Text = "Negate query";
            this.negateBox.UseVisualStyleBackColor = true;
            // 
            // valueBut
            // 
            this.valueBut.Location = new System.Drawing.Point(549, 92);
            this.valueBut.Name = "valueBut";
            this.valueBut.Size = new System.Drawing.Size(115, 36);
            this.valueBut.TabIndex = 20;
            this.valueBut.Text = "Add value";
            this.valueBut.UseVisualStyleBackColor = true;
            this.valueBut.Click += new System.EventHandler(this.valueBut_Click);
            // 
            // addCondBut
            // 
            this.addCondBut.Location = new System.Drawing.Point(304, 93);
            this.addCondBut.Name = "addCondBut";
            this.addCondBut.Size = new System.Drawing.Size(152, 35);
            this.addCondBut.TabIndex = 16;
            this.addCondBut.Text = "Add condition";
            this.addCondBut.UseVisualStyleBackColor = true;
            this.addCondBut.Click += new System.EventHandler(this.addCondBut_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Query operator";
            // 
            // queryOperCombo
            // 
            this.queryOperCombo.FormattingEnabled = true;
            this.queryOperCombo.Items.AddRange(new object[] {
            "WHERE",
            "AND",
            "OR"});
            this.queryOperCombo.Location = new System.Drawing.Point(13, 48);
            this.queryOperCombo.Name = "queryOperCombo";
            this.queryOperCombo.Size = new System.Drawing.Size(121, 24);
            this.queryOperCombo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(578, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Compare operator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Column";
            // 
            // valueText
            // 
            this.valueText.Location = new System.Drawing.Point(549, 48);
            this.valueText.Name = "valueText";
            this.valueText.Size = new System.Drawing.Size(110, 22);
            this.valueText.TabIndex = 10;
            // 
            // columnCombo
            // 
            this.columnCombo.FormattingEnabled = true;
            this.columnCombo.Location = new System.Drawing.Point(274, 48);
            this.columnCombo.Name = "columnCombo";
            this.columnCombo.Size = new System.Drawing.Size(121, 24);
            this.columnCombo.TabIndex = 9;
            // 
            // compareOperCombo
            // 
            this.compareOperCombo.FormattingEnabled = true;
            this.compareOperCombo.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            ">=",
            "<",
            "<=",
            "IS NULL",
            "IS NOT NULL",
            "LIKE",
            "BETWEEN",
            "EXISTS",
            "IN"});
            this.compareOperCombo.Location = new System.Drawing.Point(412, 48);
            this.compareOperCombo.Name = "compareOperCombo";
            this.compareOperCombo.Size = new System.Drawing.Size(121, 24);
            this.compareOperCombo.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectAllCheck);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.columnsCheckBox);
            this.panel2.Controls.Add(this.tableCombo);
            this.panel2.Location = new System.Drawing.Point(13, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 332);
            this.panel2.TabIndex = 16;
            // 
            // generQueryBut
            // 
            this.generQueryBut.Location = new System.Drawing.Point(722, 366);
            this.generQueryBut.Name = "generQueryBut";
            this.generQueryBut.Size = new System.Drawing.Size(152, 39);
            this.generQueryBut.TabIndex = 17;
            this.generQueryBut.Text = "Generate subquery";
            this.generQueryBut.UseVisualStyleBackColor = true;
            this.generQueryBut.Click += new System.EventHandler(this.generQueryBut_Click);
            // 
            // SubqueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 426);
            this.Controls.Add(this.generQueryBut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SubqueryForm";
            this.Text = "Build a subquery";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox tableCombo;
        private System.Windows.Forms.CheckedListBox columnsCheckBox;
        private System.Windows.Forms.CheckBox selectAllCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button valueBut;
        private System.Windows.Forms.Button addCondBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox queryOperCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox valueText;
        private System.Windows.Forms.ComboBox columnCombo;
        private System.Windows.Forms.ComboBox compareOperCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button generQueryBut;
        private System.Windows.Forms.CheckBox negateBox;
    }
}