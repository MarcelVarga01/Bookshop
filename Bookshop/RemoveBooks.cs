using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Bookshop
{
    public partial class RemoveBooks : Form
    {
        DisplayBooks parent = null;
        public RemoveBooks(DisplayBooks parent)
        {
            this.parent = parent;
            InitializeComponent();

            this.Text = "Remove Books";
            //Create connection and store Table Data into a variable
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.MDF;Integrated Security=True;User Instance=True";
            string sql = @"Select Title FROM Books ORDER BY Title";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow Row in dt.Rows)
                BooksList.Items.Add(Row["Title"]);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (BooksList.SelectedIndex == -1) return;
            string SelectedBook = BooksList.GetItemText(BooksList.SelectedItem);
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.mdf;Integrated Security=True;User Instance=True";
            string sql = @"DELETE FROM Books WHERE Title='" + SelectedBook + "'";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteScalar();
            con.Close();
            int len = parent.panels.Count();
            bool removed = false;
            for (int i = 0; i < len && !removed; i++)  
                if (parent.panels[i].Controls[1].Text == "Title: " + SelectedBook)
                {
                    parent.Controls.Remove(parent.panels[i]);
                    parent.panels.RemoveAt(i);
                    removed = true;
               }
              
            //System.IO.File.Delete(@Application.StartupPath + "\\Images\\" + SelectedBook + ".jpg");
            BooksList.Items.Remove(BooksList.SelectedItem);
        }
    }
}
