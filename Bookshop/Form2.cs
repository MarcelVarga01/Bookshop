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
        const int PictureHeight = 280;
        const int PictureWidth = 200;
        const int PanelHeight = PictureHeight + 130;
        const int panelWidth = PictureWidth;
        const int SPACING = 25;
        List<FlowLayoutPanel> panels = new List<FlowLayoutPanel>();
        public Form2()
        {
            InitializeComponent();
            Size = new Size(940,800);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //SortBy.this.Text = SortBy.TITLE;
            DrawBooks("");
        }

        private void DrawBooks(String SortBy)
        {
            //Create connection and store Table Data into a variable
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.MDF;Integrated Security=True;User Instance=True";
            string sql = "new";
            if (SortBy.Equals("")) sql = @"SELECT * FROM Books";
            else sql = @"SELECT * FROM Books ORDER BY " + SortBy;

            //string sql = @"SELECT * FROM Books";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Create a panel for each book and save labels / buttons into panels
            int i = 0;

            foreach (DataRow Row in dt.Rows)
            {
                //Create panel
                FlowLayoutPanel temp = new FlowLayoutPanel();
                temp.FlowDirection = FlowDirection.TopDown;
                temp.Location = new Point(SPACING + (i % 4) * (PictureWidth + SPACING), SPACING + (i / 4) * (PanelHeight + SPACING));
                temp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                temp.Height = PanelHeight;
                temp.Width = panelWidth;

                //Add elements to the panel
                CreatePictureBox(Row["Title"].ToString(), temp);
                CreateLabel("Title: " + Row["Title"].ToString(), temp);
                CreateLabel("Author: " + Row["Author"].ToString(), temp);
                CreateLabel("Pages: " + Row["Pages"].ToString(), temp);
                CreateLabel("Price: " + Row["Price"].ToString(), temp);
                CreateLabel("Stock: " + Row["Stock"].ToString(), temp);

                panels.Add(temp);
                this.Controls.Add(temp);
                i++;
            }
        }

        private void CreateLabel(String text, FlowLayoutPanel panel)
        {
            Label newLabel = new Label();
            newLabel.Text = text;
            newLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(newLabel);
        }

        private void CreatePictureBox(String Title, FlowLayoutPanel panel)
        {
            PictureBox cover = new PictureBox();
            cover.Height = PictureHeight; 
            cover.Width = PictureWidth;
            cover.SizeMode = PictureBoxSizeMode.Zoom;
            cover.ImageLocation = @Application.StartupPath + "\\Images\\" + Title + ".jpg";
            
            panel.Controls.Add(cover);
        }

        private void sortByToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (FlowLayoutPanel panel in panels)
                this.Controls.Remove(panel);
            this.Text = e.ClickedItem.Text;
            DrawBooks(e.ClickedItem.Text);
        }

    }
}
