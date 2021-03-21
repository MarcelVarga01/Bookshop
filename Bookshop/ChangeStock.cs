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
    public partial class ChangeStock : Form
    {
        public ChangeStock()
        {
            InitializeComponent();
            this.Text = "Change Stock";
            UpdateBooksList();
        }
        private void UpdateBooksList()
        {
            //Create connection and store Table Data into a variable
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.MDF;Integrated Security=True;User Instance=True";
            string sql = @"Select Title FROM Books ORDER BY Title";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Populate BookList with book titles from the database
            foreach (DataRow Row in dt.Rows)
                BooksList.Items.Add(Row["Title"]);
        }

        private void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update stock label to match selected BookList item
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.MDF;Integrated Security=True;User Instance=True";
            string sql = @"Select Stock FROM Books WHERE Title = '" + BooksList.SelectedItem + "'";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            StockCount.Text = cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void button_Click(bool add)
        {
            if (BooksList.SelectedIndex == -1) return;
            // Find the value to which the Stock should be updated
            int currentStock = Int16.Parse(StockCount.Text);
            int updateStockBy = 0;
            if (quantity.Text != "")
                updateStockBy = Int16.Parse(quantity.Text);
            if (add == true) currentStock = currentStock + updateStockBy;
            else if(currentStock >= updateStockBy) currentStock = currentStock - updateStockBy;
                else currentStock = 0;

            // Change Book Stock value in the Database
            string SelectedBook = BooksList.GetItemText(BooksList.SelectedItem);

            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.mdf;Integrated Security=True;User Instance=True";
            string sql = @"UPDATE Books SET Stock ='" + currentStock.ToString() + "' WHERE Title = '" + SelectedBook + "'";
            SqlConnection con = new SqlConnection(conString); 
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteScalar();
            con.Close();

            StockCount.Text = currentStock.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // true == increase Stock value
            button_Click(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // false == decrease Stock value
            button_Click(false);
        }

    }
}
