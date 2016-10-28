namespace Magisterka
{
    partial class ConnectForm
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
            this.engineCombo = new System.Windows.Forms.ComboBox();
            this.connectBut = new System.Windows.Forms.Button();
            this.cancelBut = new System.Windows.Forms.Button();
            this.userText = new System.Windows.Forms.TextBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.authCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.serverText = new System.Windows.Forms.TextBox();
            this.databaseText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // engineCombo
            // 
            this.engineCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engineCombo.FormattingEnabled = true;
            this.engineCombo.Items.AddRange(new object[] {
            "MYSQL",
            "SQLSERVER"});
            this.engineCombo.Location = new System.Drawing.Point(254, 59);
            this.engineCombo.Name = "engineCombo";
            this.engineCombo.Size = new System.Drawing.Size(121, 24);
            this.engineCombo.TabIndex = 0;
            // 
            // connectBut
            // 
            this.connectBut.Location = new System.Drawing.Point(220, 291);
            this.connectBut.Name = "connectBut";
            this.connectBut.Size = new System.Drawing.Size(90, 43);
            this.connectBut.TabIndex = 1;
            this.connectBut.Text = "Connect";
            this.connectBut.UseVisualStyleBackColor = true;
            this.connectBut.Click += new System.EventHandler(this.connectBut_Click);
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(359, 291);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(90, 43);
            this.cancelBut.TabIndex = 2;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(254, 157);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(121, 22);
            this.userText.TabIndex = 3;
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(254, 188);
            this.passText.Name = "passText";
            this.passText.PasswordChar = '*';
            this.passText.Size = new System.Drawing.Size(121, 22);
            this.passText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // authCheck
            // 
            this.authCheck.AutoSize = true;
            this.authCheck.Location = new System.Drawing.Point(254, 228);
            this.authCheck.Name = "authCheck";
            this.authCheck.Size = new System.Drawing.Size(179, 21);
            this.authCheck.TabIndex = 7;
            this.authCheck.Text = "Windows authentication";
            this.authCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select engine";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Server";
            // 
            // serverText
            // 
            this.serverText.Location = new System.Drawing.Point(254, 94);
            this.serverText.Name = "serverText";
            this.serverText.Size = new System.Drawing.Size(121, 22);
            this.serverText.TabIndex = 12;
            // 
            // databaseText
            // 
            this.databaseText.Location = new System.Drawing.Point(254, 124);
            this.databaseText.Name = "databaseText";
            this.databaseText.Size = new System.Drawing.Size(121, 22);
            this.databaseText.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(114, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 309);
            this.panel1.TabIndex = 14;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 429);
            this.Controls.Add(this.databaseText);
            this.Controls.Add(this.serverText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.authCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.connectBut);
            this.Controls.Add(this.engineCombo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox engineCombo;
        private System.Windows.Forms.Button connectBut;
        private System.Windows.Forms.Button cancelBut;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox authCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox serverText;
        private System.Windows.Forms.TextBox databaseText;
        private System.Windows.Forms.Panel panel1;
    }
}