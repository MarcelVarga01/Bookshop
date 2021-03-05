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
    
    public partial class DisplayBooks : Form
    {
        const int PictureHeight = 280;
        const int PictureWidth = 200;
        const int PanelHeight = PictureHeight + 130;
        const int panelWidth = PictureWidth;
        const int SPACING = 25;
        String lastSortBy = "";
        public List<FlowLayoutPanel> panels = new List<FlowLayoutPanel>();
        public DisplayBooks()
        {
            InitializeComponent();
            Size = new Size(940,800);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void DisplayBooks_Load(object sender, EventArgs e)
        {
            CreatePanels();
            DrawBooks("");
        }

        //Create connection and store return Data Table
        public static DataTable CreateDt()
        {
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.mdf;Integrated Security=True;User Instance=True";
            string sql = "";
            sql = @"SELECT * FROM Books";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Create panels of labels and pictures using a Database
        private void CreatePanels()
        {
            DataTable dt = CreateDt();

            //Create a panel for each book and save labels / buttons into panels
            int i = 0;

            foreach (DataRow Row in dt.Rows)
            {
                //Create panel
                FlowLayoutPanel temp = new FlowLayoutPanel();
                temp.FlowDirection = FlowDirection.TopDown;
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

        // Draw Books on the Form in a sorted manner
        private void DrawBooks(String SortBy)
        {
            int intSortBy;
            switch (SortBy)
            {
                case "Title":
                    intSortBy = 1;
                    break;
                case "Author":
                    intSortBy = 2;
                    break;
                case "Pages":
                    intSortBy = 3;
                    break;
                case "Price":
                    intSortBy = 4;
                    break;
                case "Stock":
                    intSortBy = 5;
                    break;
                default:
                    intSortBy = 0;
                    break;
            }
            if (intSortBy != 0)
                panels.Sort((p1, p2) => p1.Controls[intSortBy].Text.CompareTo(p2.Controls[intSortBy].Text));
            foreach (FlowLayoutPanel panel in panels)
                this.Controls.Remove(panel);
            int len = panels.Count;
            for (int i = 0; i < len; i++)
            {
                panels[i].Location = new Point(SPACING + (i % 4) * (PictureWidth + SPACING), SPACING + (i / 4) * (PanelHeight + SPACING));
                this.Controls.Add(panels[i]);
            }
        }

        // Handle Sort By changes
        private void sortByToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DrawBooks(e.ClickedItem.Text);
            lastSortBy = e.ClickedItem.Text;
        }

        // Start the RemoveBooks Form
        private void removeBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveBooks removeBooks = new RemoveBooks(this);
            removeBooks.ShowDialog();
            DrawBooks(lastSortBy); 

        }

    }
}
