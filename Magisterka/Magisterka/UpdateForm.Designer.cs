namespace Magisterka
{
    partial class UpdateForm
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
            this.executeBut = new System.Windows.Forms.Button();
            this.updateGridView = new System.Windows.Forms.DataGridView();
            this.columnsCheckBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.choiceBut = new System.Windows.Forms.Button();
            this.selectAllCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.addCondBut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.queryOperCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.valueText = new System.Windows.Forms.TextBox();
            this.columnCombo = new System.Windows.Forms.ComboBox();
            this.compareOperCombo = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.valueBut = new System.Windows.Forms.Button();
            this.negateBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.updateGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // executeBut
            // 
            this.executeBut.Location = new System.Drawing.Point(772, 466);
            this.executeBut.Name = "executeBut";
            this.executeBut.Size = new System.Drawing.Size(133, 36);
            this.executeBut.TabIndex = 16;
            this.executeBut.Text = "Execute query";
            this.executeBut.UseVisualStyleBackColor = true;
            this.executeBut.Click += new System.EventHandler(this.executeBut_Click);
            // 
            // updateGridView
            // 
            this.updateGridView.AllowUserToAddRows = false;
            this.updateGridView.AllowUserToDeleteRows = false;
            this.updateGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateGridView.Location = new System.Drawing.Point(31, 40);
            this.updateGridView.Name = "updateGridView";
            this.updateGridView.RowTemplate.Height = 24;
            this.updateGridView.Size = new System.Drawing.Size(501, 244);
            this.updateGridView.TabIndex = 14;
            // 
            // columnsCheckBox
            // 
            this.columnsCheckBox.Location = new System.Drawing.Point(25, 45);
            this.columnsCheckBox.Name = "columnsCheckBox";
            this.columnsCheckBox.Size = new System.Drawing.Size(226, 174);
            this.columnsCheckBox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, -44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enter values";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.choiceBut);
            this.panel1.Controls.Add(this.selectAllCheck);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.columnsCheckBox);
            this.panel1.Location = new System.Drawing.Point(57, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 297);
            this.panel1.TabIndex = 18;
            // 
            // choiceBut
            // 
            this.choiceBut.Location = new System.Drawing.Point(112, 243);
            this.choiceBut.Name = "choiceBut";
            this.choiceBut.Size = new System.Drawing.Size(118, 33);
            this.choiceBut.TabIndex = 33;
            this.choiceBut.Text = "Accept choice";
            this.choiceBut.UseVisualStyleBackColor = true;
            this.choiceBut.Click += new System.EventHandler(this.choiceBut_Click);
            // 
            // selectAllCheck
            // 
            this.selectAllCheck.AutoSize = true;
            this.selectAllCheck.Location = new System.Drawing.Point(15, 250);
            this.selectAllCheck.Name = "selectAllCheck";
            this.selectAllCheck.Size = new System.Drawing.Size(87, 21);
            this.selectAllCheck.TabIndex = 8;
            this.selectAllCheck.Text = "Select all";
            this.selectAllCheck.UseVisualStyleBackColor = true;
            this.selectAllCheck.CheckedChanged += new System.EventHandler(this.selectAllCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose columns to update";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.updateGridView);
            this.panel2.Location = new System.Drawing.Point(373, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 352);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Enter values";
            // 
            // addCondBut
            // 
            this.addCondBut.Location = new System.Drawing.Point(291, 90);
            this.addCondBut.Name = "addCondBut";
            this.addCondBut.Size = new System.Drawing.Size(152, 35);
            this.addCondBut.TabIndex = 28;
            this.addCondBut.Text = "Add condition";
            this.addCondBut.UseVisualStyleBackColor = true;
            this.addCondBut.Click += new System.EventHandler(this.addCondBut_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Query operator";
            // 
            // queryOperCombo
            // 
            this.queryOperCombo.FormattingEnabled = true;
            this.queryOperCombo.Items.AddRange(new object[] {
            "WHERE",
            "AND",
            "OR"});
            this.queryOperCombo.Location = new System.Drawing.Point(12, 42);
            this.queryOperCombo.Name = "queryOperCombo";
            this.queryOperCombo.Size = new System.Drawing.Size(121, 24);
            this.queryOperCombo.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Compare operator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Column";
            // 
            // valueText
            // 
            this.valueText.Location = new System.Drawing.Point(547, 42);
            this.valueText.Name = "valueText";
            this.valueText.Size = new System.Drawing.Size(110, 22);
            this.valueText.TabIndex = 22;
            // 
            // columnCombo
            // 
            this.columnCombo.FormattingEnabled = true;
            this.columnCombo.Location = new System.Drawing.Point(273, 42);
            this.columnCombo.Name = "columnCombo";
            this.columnCombo.Size = new System.Drawing.Size(121, 24);
            this.columnCombo.TabIndex = 21;
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
            this.compareOperCombo.Location = new System.Drawing.Point(411, 42);
            this.compareOperCombo.Name = "compareOperCombo";
            this.compareOperCombo.Size = new System.Drawing.Size(121, 24);
            this.compareOperCombo.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.negateBox);
            this.panel3.Controls.Add(this.valueBut);
            this.panel3.Controls.Add(this.addCondBut);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.queryOperCombo);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.valueText);
            this.panel3.Controls.Add(this.columnCombo);
            this.panel3.Controls.Add(this.compareOperCombo);
            this.panel3.Location = new System.Drawing.Point(17, 405);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(682, 144);
            this.panel3.TabIndex = 31;
            // 
            // valueBut
            // 
            this.valueBut.Location = new System.Drawing.Point(547, 90);
            this.valueBut.Name = "valueBut";
            this.valueBut.Size = new System.Drawing.Size(110, 34);
            this.valueBut.TabIndex = 31;
            this.valueBut.Text = "Add value";
            this.valueBut.UseVisualStyleBackColor = true;
            this.valueBut.Click += new System.EventHandler(this.valueBut_Click);
            // 
            // negateBox
            // 
            this.negateBox.AutoSize = true;
            this.negateBox.Location = new System.Drawing.Point(139, 45);
            this.negateBox.Name = "negateBox";
            this.negateBox.Size = new System.Drawing.Size(116, 21);
            this.negateBox.TabIndex = 32;
            this.negateBox.Text = "Negate query";
            this.negateBox.UseVisualStyleBackColor = true;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 555);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.executeBut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.Text = "Update records";
            ((System.ComponentModel.ISupportInitialize)(this.updateGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button executeBut;
        private System.Windows.Forms.DataGridView updateGridView;
        private System.Windows.Forms.CheckedListBox columnsCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox selectAllCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addCondBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox queryOperCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox valueText;
        private System.Windows.Forms.ComboBox columnCombo;
        private System.Windows.Forms.ComboBox compareOperCombo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button choiceBut;
        private System.Windows.Forms.Button valueBut;
        private System.Windows.Forms.CheckBox negateBox;
    }
}