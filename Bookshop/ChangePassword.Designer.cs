namespace Bookshop
{
    partial class ChangePassword
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
            this.PrevPasswdL = new System.Windows.Forms.Label();
            this.NewPasswdL = new System.Windows.Forms.Label();
            this.VerifyPasswdL = new System.Windows.Forms.Label();
            this.prevPasswd = new System.Windows.Forms.TextBox();
            this.newPasswd = new System.Windows.Forms.TextBox();
            this.verifyPasswd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswdNotMatching = new System.Windows.Forms.Label();
            this.IncorrectPasswd = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrevPasswdL
            // 
            this.PrevPasswdL.AutoSize = true;
            this.PrevPasswdL.Location = new System.Drawing.Point(89, 83);
            this.PrevPasswdL.Name = "PrevPasswdL";
            this.PrevPasswdL.Size = new System.Drawing.Size(132, 17);
            this.PrevPasswdL.TabIndex = 0;
            this.PrevPasswdL.Text = "Previous Password:";
            // 
            // NewPasswdL
            // 
            this.NewPasswdL.AutoSize = true;
            this.NewPasswdL.Location = new System.Drawing.Point(117, 129);
            this.NewPasswdL.Name = "NewPasswdL";
            this.NewPasswdL.Size = new System.Drawing.Size(104, 17);
            this.NewPasswdL.TabIndex = 1;
            this.NewPasswdL.Text = "New Password:";
            // 
            // VerifyPasswdL
            // 
            this.VerifyPasswdL.AutoSize = true;
            this.VerifyPasswdL.Location = new System.Drawing.Point(108, 175);
            this.VerifyPasswdL.Name = "VerifyPasswdL";
            this.VerifyPasswdL.Size = new System.Drawing.Size(113, 17);
            this.VerifyPasswdL.TabIndex = 2;
            this.VerifyPasswdL.Text = "Verify Password:";
            // 
            // prevPasswd
            // 
            this.prevPasswd.Location = new System.Drawing.Point(243, 81);
            this.prevPasswd.Name = "prevPasswd";
            this.prevPasswd.PasswordChar = '•';
            this.prevPasswd.Size = new System.Drawing.Size(164, 22);
            this.prevPasswd.TabIndex = 3;
            this.prevPasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressEnter);
            // 
            // newPasswd
            // 
            this.newPasswd.Location = new System.Drawing.Point(243, 127);
            this.newPasswd.Name = "newPasswd";
            this.newPasswd.PasswordChar = '•';
            this.newPasswd.Size = new System.Drawing.Size(164, 22);
            this.newPasswd.TabIndex = 4;
            this.newPasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressEnter);
            // 
            // verifyPasswd
            // 
            this.verifyPasswd.Location = new System.Drawing.Point(243, 173);
            this.verifyPasswd.Name = "verifyPasswd";
            this.verifyPasswd.PasswordChar = '•';
            this.verifyPasswd.Size = new System.Drawing.Size(164, 22);
            this.verifyPasswd.TabIndex = 5;
            this.verifyPasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Change Admin Password";
            // 
            // PasswdNotMatching
            // 
            this.PasswdNotMatching.AutoSize = true;
            this.PasswdNotMatching.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.55F, System.Drawing.FontStyle.Bold);
            this.PasswdNotMatching.ForeColor = System.Drawing.Color.Red;
            this.PasswdNotMatching.Location = new System.Drawing.Point(115, 208);
            this.PasswdNotMatching.Name = "PasswdNotMatching";
            this.PasswdNotMatching.Size = new System.Drawing.Size(261, 25);
            this.PasswdNotMatching.TabIndex = 12;
            this.PasswdNotMatching.Text = "Passwords don\'t match!";
            // 
            // IncorrectPasswd
            // 
            this.IncorrectPasswd.AutoSize = true;
            this.IncorrectPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.55F, System.Drawing.FontStyle.Bold);
            this.IncorrectPasswd.ForeColor = System.Drawing.Color.Red;
            this.IncorrectPasswd.Location = new System.Drawing.Point(115, 208);
            this.IncorrectPasswd.Name = "IncorrectPasswd";
            this.IncorrectPasswd.Size = new System.Drawing.Size(218, 25);
            this.IncorrectPasswd.TabIndex = 13;
            this.IncorrectPasswd.Text = "Incorrect password!";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(171, 244);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(123, 36);
            this.Confirm.TabIndex = 14;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 292);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.PasswdNotMatching);
            this.Controls.Add(this.IncorrectPasswd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verifyPasswd);
            this.Controls.Add(this.newPasswd);
            this.Controls.Add(this.prevPasswd);
            this.Controls.Add(this.VerifyPasswdL);
            this.Controls.Add(this.NewPasswdL);
            this.Controls.Add(this.PrevPasswdL);
            this.Name = "ChangePassword";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PrevPasswdL;
        private System.Windows.Forms.Label NewPasswdL;
        private System.Windows.Forms.Label VerifyPasswdL;
        private System.Windows.Forms.TextBox prevPasswd;
        private System.Windows.Forms.TextBox newPasswd;
        private System.Windows.Forms.TextBox verifyPasswd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PasswdNotMatching;
        private System.Windows.Forms.Label IncorrectPasswd;
        private System.Windows.Forms.Button Confirm;
    }
}