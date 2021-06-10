using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bookshop
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Change Admin Password";
            PasswdNotMatching.Visible = false;
            IncorrectPasswd.Visible = false;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {   // Text boxes not empty
            if (prevPasswd.Text.Length != 0 && verifyPasswd.Text.Length != 0 && newPasswd.Text.Length != 0)
            {   // Old password incorrect
                if (!Program.hash(prevPasswd.Text).Equals(Program.password))
                {
                    PasswdNotMatching.Visible = false;
                    IncorrectPasswd.Visible = true;
                }
                else // Old password is correct
                {
                    if (newPasswd.Text.Equals(verifyPasswd.Text)) // Passwords match
                    {
                        Program.password = Program.hash(verifyPasswd.Text);
                        System.IO.File.WriteAllText(Application.StartupPath + "\\credentials.txt", Program.password);
                        PasswdNotMatching.Visible = false;
                        IncorrectPasswd.Visible = false;
                        MessageBox.Show("Password changed successfully");
                        this.Close();
                    }
                    else //Passwords don't match
                    {
                        PasswdNotMatching.Visible = true;
                        IncorrectPasswd.Visible = false;
                    }
                }
            }
            else 
            {
                MessageBox.Show("Text boxes can't be empty");
            }
        }

        private void PressEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
                Confirm_Click(sender, e);
        }
            
    }
}
