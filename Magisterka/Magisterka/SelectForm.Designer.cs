namespace Magisterka
{
    partial class SelectForm
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
            this.columnsCheckBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.executeBut = new System.Windows.Forms.Button();
            this.selectAllCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.compareOperCombo = new System.Windows.Forms.ComboBox();
            this.columnCombo = new System.Windows.Forms.ComboBox();
            this.valueText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.limitText = new System.Windows.Forms.NumericUpDown();
            this.negateBox = new System.Windows.Forms.CheckBox();
            this.subqueryBut = new System.Windows.Forms.Button();
            this.valueBut = new System.Windows.Forms.Button();
            this.addCondBut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.queryOperCombo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addColSortBut = new System.Windows.Forms.Button();
            this.columnSortCombo = new System.Windows.Forms.ComboBox();
            this.dscRadio = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.addColumnsBut = new System.Windows.Forms.Button();
            this.addJoinBut = new System.Windows.Forms.Button();
            this.joinColBox = new System.Windows.Forms.ListBox();
            this.baseColBox = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableCombo = new System.Windows.Forms.ComboBox();
            this.joinCombo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limitText)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnsCheckBox
            // 
            this.columnsCheckBox.FormattingEnabled = true;
            this.columnsCheckBox.Location = new System.Drawing.Point(34, 50);
            this.columnsCheckBox.Name = "columnsCheckBox";
            this.columnsCheckBox.Size = new System.Drawing.Size(261, 191);
            this.columnsCheckBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose columns to show";
            // 
            // executeBut
            // 
            this.executeBut.Location = new System.Drawing.Point(129, 506);
            this.executeBut.Name = "executeBut";
            this.executeBut.Size = new System.Drawing.Size(133, 36);
            this.executeBut.TabIndex = 2;
            this.executeBut.Text = "Execute query";
            this.executeBut.UseVisualStyleBackColor = true;
            this.executeBut.Click += new System.EventHandler(this.executeBut_Click);
            // 
            // selectAllCheck
            // 
            this.selectAllCheck.AutoSize = true;
            this.selectAllCheck.Location = new System.Drawing.Point(49, 247);
            this.selectAllCheck.Name = "selectAllCheck";
            this.selectAllCheck.Size = new System.Drawing.Size(87, 21);
            this.selectAllCheck.TabIndex = 5;
            this.selectAllCheck.Text = "Select all";
            this.selectAllCheck.UseVisualStyleBackColor = true;
            this.selectAllCheck.CheckedChanged += new System.EventHandler(this.selectAllCheck_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Limit of displayed records";
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
            // columnCombo
            // 
            this.columnCombo.FormattingEnabled = true;
            this.columnCombo.Location = new System.Drawing.Point(274, 48);
            this.columnCombo.Name = "columnCombo";
            this.columnCombo.Size = new System.Drawing.Size(121, 24);
            this.columnCombo.TabIndex = 9;
            // 
            // valueText
            // 
            this.valueText.Location = new System.Drawing.Point(549, 48);
            this.valueText.Name = "valueText";
            this.valueText.Size = new System.Drawing.Size(110, 22);
            this.valueText.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Column";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(578, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.limitText);
            this.panel1.Controls.Add(this.negateBox);
            this.panel1.Controls.Add(this.subqueryBut);
            this.panel1.Controls.Add(this.valueBut);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.addCondBut);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.queryOperCombo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.valueText);
            this.panel1.Controls.Add(this.columnCombo);
            this.panel1.Controls.Add(this.compareOperCombo);
            this.panel1.Location = new System.Drawing.Point(358, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 197);
            this.panel1.TabIndex = 14;
            // 
            // limitText
            // 
            this.limitText.Location = new System.Drawing.Point(351, 154);
            this.limitText.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.limitText.Name = "limitText";
            this.limitText.Size = new System.Drawing.Size(120, 22);
            this.limitText.TabIndex = 23;
            // 
            // negateBox
            // 
            this.negateBox.AutoSize = true;
            this.negateBox.Location = new System.Drawing.Point(150, 49);
            this.negateBox.Name = "negateBox";
            this.negateBox.Size = new System.Drawing.Size(116, 21);
            this.negateBox.TabIndex = 22;
            this.negateBox.Text = "Negate query";
            this.negateBox.UseVisualStyleBackColor = true;
            // 
            // subqueryBut
            // 
            this.subqueryBut.Location = new System.Drawing.Point(682, 40);
            this.subqueryBut.Name = "subqueryBut";
            this.subqueryBut.Size = new System.Drawing.Size(161, 32);
            this.subqueryBut.TabIndex = 21;
            this.subqueryBut.Text = "Create subquery";
            this.subqueryBut.UseVisualStyleBackColor = true;
            this.subqueryBut.Click += new System.EventHandler(this.subqueryBut_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.addColSortBut);
            this.panel2.Controls.Add(this.columnSortCombo);
            this.panel2.Controls.Add(this.dscRadio);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.selectAllCheck);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.columnsCheckBox);
            this.panel2.Location = new System.Drawing.Point(15, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 468);
            this.panel2.TabIndex = 15;
            // 
            // addColSortBut
            // 
            this.addColSortBut.Location = new System.Drawing.Point(60, 415);
            this.addColSortBut.Name = "addColSortBut";
            this.addColSortBut.Size = new System.Drawing.Size(146, 32);
            this.addColSortBut.TabIndex = 21;
            this.addColSortBut.Text = "Add column to sort";
            this.addColSortBut.UseVisualStyleBackColor = true;
            this.addColSortBut.Click += new System.EventHandler(this.addColSortBut_Click);
            // 
            // columnSortCombo
            // 
            this.columnSortCombo.FormattingEnabled = true;
            this.columnSortCombo.Location = new System.Drawing.Point(60, 334);
            this.columnSortCombo.Name = "columnSortCombo";
            this.columnSortCombo.Size = new System.Drawing.Size(121, 24);
            this.columnSortCombo.TabIndex = 19;
            // 
            // dscRadio
            // 
            this.dscRadio.AutoSize = true;
            this.dscRadio.Location = new System.Drawing.Point(198, 337);
            this.dscRadio.Name = "dscRadio";
            this.dscRadio.Size = new System.Drawing.Size(80, 21);
            this.dscRadio.TabIndex = 18;
            this.dscRadio.TabStop = true;
            this.dscRadio.Text = "is DESC";
            this.dscRadio.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Choose columns to sort";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.addColumnsBut);
            this.panel3.Controls.Add(this.addJoinBut);
            this.panel3.Controls.Add(this.joinColBox);
            this.panel3.Controls.Add(this.baseColBox);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.tableCombo);
            this.panel3.Controls.Add(this.joinCombo);
            this.panel3.Location = new System.Drawing.Point(358, 271);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(677, 262);
            this.panel3.TabIndex = 16;
            // 
            // addColumnsBut
            // 
            this.addColumnsBut.Location = new System.Drawing.Point(345, 214);
            this.addColumnsBut.Name = "addColumnsBut";
            this.addColumnsBut.Size = new System.Drawing.Size(188, 37);
            this.addColumnsBut.TabIndex = 13;
            this.addColumnsBut.Text = "Accept column to join";
            this.addColumnsBut.UseVisualStyleBackColor = true;
            this.addColumnsBut.Click += new System.EventHandler(this.addColumnsBut_Click);
            // 
            // addJoinBut
            // 
            this.addJoinBut.Location = new System.Drawing.Point(203, 214);
            this.addJoinBut.Name = "addJoinBut";
            this.addJoinBut.Size = new System.Drawing.Size(128, 35);
            this.addJoinBut.TabIndex = 12;
            this.addJoinBut.Text = "Add join";
            this.addJoinBut.UseVisualStyleBackColor = true;
            this.addJoinBut.Click += new System.EventHandler(this.addJoinBut_Click);
            // 
            // joinColBox
            // 
            this.joinColBox.FormattingEnabled = true;
            this.joinColBox.ItemHeight = 16;
            this.joinColBox.Location = new System.Drawing.Point(543, 39);
            this.joinColBox.Name = "joinColBox";
            this.joinColBox.Size = new System.Drawing.Size(116, 212);
            this.joinColBox.TabIndex = 11;
            // 
            // baseColBox
            // 
            this.baseColBox.FormattingEnabled = true;
            this.baseColBox.ItemHeight = 16;
            this.baseColBox.Location = new System.Drawing.Point(77, 37);
            this.baseColBox.Name = "baseColBox";
            this.baseColBox.Size = new System.Drawing.Size(120, 212);
            this.baseColBox.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(546, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Column name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(440, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "Table";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Join type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Column name";
            // 
            // tableCombo
            // 
            this.tableCombo.FormattingEnabled = true;
            this.tableCombo.Location = new System.Drawing.Point(390, 39);
            this.tableCombo.Name = "tableCombo";
            this.tableCombo.Size = new System.Drawing.Size(121, 24);
            this.tableCombo.TabIndex = 3;
            this.tableCombo.SelectedIndexChanged += new System.EventHandler(this.tableCombo_SelectedIndexChanged);
            // 
            // joinCombo
            // 
            this.joinCombo.FormattingEnabled = true;
            this.joinCombo.Items.AddRange(new object[] {
            "INNER JOIN",
            "LEFT JOIN",
            "RIGHT JOIN"});
            this.joinCombo.Location = new System.Drawing.Point(234, 39);
            this.joinCombo.Name = "joinCombo";
            this.joinCombo.Size = new System.Drawing.Size(121, 24);
            this.joinCombo.TabIndex = 1;
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 554);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.executeBut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SelectForm";
            this.Text = "Select specified records";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limitText)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox columnsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button executeBut;
        private System.Windows.Forms.CheckBox selectAllCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox compareOperCombo;
        private System.Windows.Forms.ComboBox columnCombo;
        private System.Windows.Forms.TextBox valueText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox queryOperCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addCondBut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tableCombo;
        private System.Windows.Forms.ComboBox joinCombo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button addJoinBut;
        private System.Windows.Forms.ListBox joinColBox;
        private System.Windows.Forms.ListBox baseColBox;
        private System.Windows.Forms.Button valueBut;
        private System.Windows.Forms.Button subqueryBut;
        private System.Windows.Forms.CheckBox negateBox;
        private System.Windows.Forms.Button addColumnsBut;
        private System.Windows.Forms.ComboBox columnSortCombo;
        private System.Windows.Forms.RadioButton dscRadio;
        private System.Windows.Forms.Button addColSortBut;
        private System.Windows.Forms.NumericUpDown limitText;
    }
}