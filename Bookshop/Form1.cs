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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Client");
            comboBox1.Items.Add("Administrator");
            label3.Visible = false;
            textBox1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) { label3.Visible = false; textBox1.Visible = false; }
            if (comboBox1.SelectedIndex == 1) { label3.Visible = true; textBox1.Visible = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0 && comboBox1.SelectedIndex != 1) label5.Visible = true;
            else CheckOK(comboBox1.SelectedIndex, textBox1.Text);
        }

        private void CheckOK(int index, String password)
        {
            label5.Visible = false;
            bool ok = false;
            if (index == 1)
            {
                if (password == Program.password)
                {
                    label4.Visible = false;
                    ok = true;
                    Program.admin = true;
                }
                else
                {
                    label4.Visible = true; 
                    ok = false; 
                }
            }
            if (comboBox1.SelectedIndex == 0) ok = true;
            if (ok == true)
            {
                Program.ok = true;
                this.Close();
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))

                CheckOK(comboBox1.SelectedIndex, textBox1.Text);
        }
    }
}
