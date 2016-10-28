namespace Magisterka
{
    partial class DeleteForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.negateBox = new System.Windows.Forms.CheckBox();
            this.valueBut = new System.Windows.Forms.Button();
            this.addCondBut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.queryOperCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valueText = new System.Windows.Forms.TextBox();
            this.columnCombo = new System.Windows.Forms.ComboBox();
            this.compareOperCombo = new System.Windows.Forms.ComboBox();
            this.executeBut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.valueText);
            this.panel1.Controls.Add(this.columnCombo);
            this.panel1.Controls.Add(this.compareOperCombo);
            this.panel1.Location = new System.Drawing.Point(56, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 155);
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
            this.valueBut.Location = new System.Drawing.Point(549, 98);
            this.valueBut.Name = "valueBut";
            this.valueBut.Size = new System.Drawing.Size(110, 35);
            this.valueBut.TabIndex = 20;
            this.valueBut.Text = "Add value";
            this.valueBut.UseVisualStyleBackColor = true;
            this.valueBut.Click += new System.EventHandler(this.valueBut_Click);
            // 
            // addCondBut
            // 
            this.addCondBut.Location = new System.Drawing.Point(283, 98);
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
            this.label5.Location = new System.Drawing.Point(589, 22);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Column";
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
            // executeBut
            // 
            this.executeBut.Location = new System.Drawing.Point(348, 237);
            this.executeBut.Name = "executeBut";
            this.executeBut.Size = new System.Drawing.Size(133, 36);
            this.executeBut.TabIndex = 16;
            this.executeBut.Text = "Execute query";
            this.executeBut.UseVisualStyleBackColor = true;
            this.executeBut.Click += new System.EventHandler(this.executeBut_Click);
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 292);
            this.Controls.Add(this.executeBut);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DeleteForm";
            this.Text = "Delete records";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addCondBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox queryOperCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox valueText;
        private System.Windows.Forms.ComboBox columnCombo;
        private System.Windows.Forms.ComboBox compareOperCombo;
        private System.Windows.Forms.Button executeBut;
        private System.Windows.Forms.Button valueBut;
        private System.Windows.Forms.CheckBox negateBox;
    }
}