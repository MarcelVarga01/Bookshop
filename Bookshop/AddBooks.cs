using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Bookshop
{
    public partial class AddBooks : Form
    {

        string coverImagePath;

        public AddBooks()
        {
            InitializeComponent();
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Check that all TextBoxes have text in them
            foreach (Control control in Controls)
                if (control is TextBox && control.Text.Length == 0)
                {
                    MessageBox.Show("Fields cannot be left empty!");
                    return;
                }
            if (!File.Exists(coverImagePath))
            {
                MessageBox.Show("Cover Image Path invalid!");
                return;
            }

            // Avoid exception when trying to copy to an already existing file
            if (File.Exists(Application.StartupPath + "\\Images\\" + TitleTextBox.Text + ".jpg"))
                System.IO.File.Delete(Application.StartupPath + "\\Images\\" + TitleTextBox.Text + ".jpg");
                // Copy from image path to Images folder in the application's startup path
            File.Copy(coverImagePath, Application.StartupPath + "\\Images\\" + TitleTextBox.Text + ".jpg");
            int pages, stock;
            float price;
            if (!int.TryParse(PagesTextBox.Text, out pages))
            {
                MessageBox.Show("Pages field should be an integer!");
                return;
            }
            if (!float.TryParse(PriceTextBox.Text, out price))
            {
                MessageBox.Show("Price field should be a decimal value!");
                return;
            }
            if (!int.TryParse(StockTextBox.Text, out stock))
            {
                MessageBox.Show("Stock field should be an integer!");
                return;
            }
            
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.mdf;Integrated Security=True;User Instance=True";
            string sql = @"INSERT INTO Books(Title, Author, Pages, Price, Stock) VALUES ('"
                + TitleTextBox.Text + "', '"
                + AuthorTextBox.Text + "', '"
                + pages + "', '"
                + price + "', '"
                + stock + "')";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteScalar();
            con.Close();
            MessageBox.Show("Book added succesfully!");
        }

        private void CoverImageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddButton_Click(sender, e);
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] imagePath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            coverImagePath = imagePath[0];
            pictureBox1.ImageLocation = imagePath[0];
            
        }

    }
}
