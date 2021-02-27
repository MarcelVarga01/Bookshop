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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Size = new Size(500, 500);
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.MDF;Integrated Security=True;User Instance=True";
            string sql = @"SELECT * FROM Books";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);

            //new.dt.Rows.Count;
            int i = 0;
            List<Label> lis = new List<Label>();
            foreach (DataRow Row in dt.Rows)
            {
                Label a = new Label();
                a.AutoSize = true;
                a.Text = Row["Title"].ToString();
                a.Location = new Point(i * 80, 20);
                Controls.Add(a);
                i++;
            }
            
            //picture 250 350
        }
    }
}
