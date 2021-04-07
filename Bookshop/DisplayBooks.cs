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
    
    public partial class displayBooks : Form
    {
        const int PICTUREHEIGHT = 280;
        const int PICTUREWIDTH = 200;
        const int PANELHEIGHT = PICTUREHEIGHT + 180;
        const int PANELWIDTH = PICTUREWIDTH;
        const int SPACING = 25;
        const int DEFAULT = 0, TITLE = 1, AUTHOR = 2, PAGES = 3, PRICE = 4 , STOCK = 5, TEXTBOX = 6, BUTTON = 7;
        public String lastSortBy = "";
        bool lastSortReversed = false;
        private List<FlowLayoutPanel> panels = new List<FlowLayoutPanel>();
        private Dictionary<Button, Book> buttonToBook = new Dictionary<Button, Book>();
        public List<BookEntry> booksToBeBought = new List<BookEntry>();
        private enum Indexes {X = 0, TITLE = 1, AUTHOR = 2, PAGES = 3, PRICE = 4 , STOCK = 5, TEXTBOX = 6, BUTTON = 7};
        public displayBooks()
        {
            InitializeComponent();
            Size = new Size(940,800);
            this.StartPosition = FormStartPosition.CenterScreen;
            //if (!Program.admin) administratorOptionsToolStripMenuItem.Visible = false;
        }

        public void DisplayBooks_Load(object sender, EventArgs e)
        {
            createPanels();
            drawPanels("");
        }

        //Create connection and return a Data Table
        public DataTable createDataTable()
        {
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.mdf;Integrated Security=True;User Instance=True";
            string sql = @"SELECT * FROM Books";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Create panels of labels and pictures using a Database
        private void createPanels()
        {
            DataTable dt = createDataTable();

            //Create a panel for each book and save labels / buttons into panels
            int i = 0;

            foreach (DataRow Row in dt.Rows)
            {
                //Create panel
                FlowLayoutPanel tempPanel = new FlowLayoutPanel();
                tempPanel.FlowDirection = FlowDirection.TopDown;
                tempPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                tempPanel.Height = PANELHEIGHT;
                tempPanel.Width = PANELWIDTH;

                //Add elements to the panel
                createPictureBox(Row["Title"].ToString(), tempPanel);
                createLabel("Title: " + Row["Title"].ToString(), tempPanel);
                createLabel("Author: " + Row["Author"].ToString(), tempPanel);
                createLabel("Pages: " + Row["Pages"].ToString(), tempPanel);
                createLabel("Price: " + Row["Price"].ToString(), tempPanel);
                Label stockLabel = createLabel("Stock: " + Row["Stock"].ToString(), tempPanel);
                TextBox tempTextBox = createTextBox(tempPanel);
                Button tempButton = createButton(tempPanel);
                buttonToBook.Add(tempButton, new Book(Row["Title"].ToString(), tempTextBox, stockLabel, Row["Price"].ToString()));
                panels.Add(tempPanel);
                i++;
            }
        }
        // Draw panels on the Form in a sorted manner
        private void drawPanels(String SortBy)
        {
            int intSortBy;
            switch (SortBy)
            {
                case "Title":
                    intSortBy = TITLE;
                    break;
                case "Author":
                    intSortBy = AUTHOR;
                    break;
                case "Pages":
                    intSortBy = PAGES;
                    break;
                case "Price":
                    intSortBy = PRICE;
                    break;
                case "Stock":
                    intSortBy = STOCK;
                    break;
                default:
                    intSortBy = DEFAULT;
                    break;
            }
            bool toReverse = false;
            if (lastSortBy == SortBy && !lastSortReversed) { toReverse = true; lastSortReversed = true; }
            else lastSortReversed = false;
            if (intSortBy != DEFAULT)
            {
                if (intSortBy != PRICE)
                {
                    if (!toReverse)
                        panels.Sort((p1, p2) => p1.Controls[intSortBy].Text.CompareTo(p2.Controls[intSortBy].Text));
                    else panels.Sort((p1, p2) => p2.Controls[intSortBy].Text.CompareTo(p1.Controls[intSortBy].Text));
                }
                else
                {
                    if (!toReverse)
                        panels.Sort((p1, p2) => float.Parse(p1.Controls[intSortBy].Text.Remove(0, 6)).CompareTo(float.Parse(p2.Controls[intSortBy].Text.Remove(0, 6))));
                    else
                        panels.Sort((p1, p2) => float.Parse(p2.Controls[intSortBy].Text.Remove(0, 6)).CompareTo(float.Parse(p1.Controls[intSortBy].Text.Remove(0, 6))));

                }
            }
            foreach (FlowLayoutPanel panel in panels)
                this.Controls.Remove(panel);
            int len = panels.Count;
            for (int i = 0; i < len; i++)
            {
                panels[i].Location = new Point(SPACING + (i % 4) * (PICTUREWIDTH + SPACING), SPACING + (i / 4) * (PANELHEIGHT + SPACING));
                this.Controls.Add(panels[i]);
            }
        }
        // Removes the panels from Control and from the array of panels
        private void clearPanels()
        {
            while (panels.Count() > 0)
            {
                Controls.Remove(panels[0]);
                panels.RemoveAt(0);
            }
        }

        // Updates the form to match the database
        public void redraw(String SortBy) 
        {
            clearPanels();
            createPanels();
            drawPanels(SortBy);
        }
        // ---------------------------------------------------------
        // Helper functions
        private Label createLabel(String text, FlowLayoutPanel panel)
        {
            Label newLabel = new Label();
            newLabel.Text = text;
            newLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(newLabel);
            return newLabel;
        }
        private Button createButton(FlowLayoutPanel panel)
        {
            Button button = new Button();
            button.Width += 20;
            button.Anchor = AnchorStyles.Top;
            button.Text = "Add to Basket";
            button.Click += new System.EventHandler(this.buttonClick);
            panel.Controls.Add(button);
            return button;
        }
        private PictureBox createPictureBox(String Title, FlowLayoutPanel panel)
        {
            PictureBox cover = new PictureBox();
            cover.Height = PICTUREHEIGHT; 
            cover.Width = PICTUREWIDTH;
            cover.SizeMode = PictureBoxSizeMode.Zoom;
            cover.ImageLocation = @Application.StartupPath + "\\Images\\" + Title + ".jpg";
            panel.Controls.Add(cover);
            return cover;
        }
        private TextBox createTextBox(FlowLayoutPanel panel)
        {
            TextBox textBox = new TextBox();
            textBox.Anchor = AnchorStyles.Top; 
            panel.Controls.Add(textBox);
            return textBox;
        }

        // ---------------------------------------------------------------------------
        // Event Handlers

        // Handle Sort By changes
        private void sortByToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            drawPanels(e.ClickedItem.Text);
            lastSortBy = e.ClickedItem.Text;
        }

        // Start the RemoveBooks Form
        private void removeBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveBooks removeBooks = new RemoveBooks();
            removeBooks.ShowDialog();
            lastSortReversed = !lastSortReversed;
            redraw(lastSortBy);
        }

        // Start the ChangeStock Form
        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStock changeStock = new ChangeStock();
            changeStock.ShowDialog();
            lastSortReversed = !lastSortReversed;
            redraw(lastSortBy);

        }

        // Start the AddBooks Form
        private void addBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddBooks addBooks = new AddBooks();
            addBooks.ShowDialog();
            lastSortReversed = !lastSortReversed;
            redraw(lastSortBy);

        }

        // Start the Basket Form
        private void basketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Basket basket = new Basket(booksToBeBought, this);
            basket.ShowDialog();
            //clearPanels();
            //createPanels();
            //drawPanels(lastSortBy);
        }

        // Used by each panel's button
        private void buttonClick(object sender, EventArgs e)
        {
            Book book = buttonToBook[(Button) sender];
            int stock = book.GetStock();
            int quantityToBuy = book.GetQuantity();
            if(quantityToBuy > 0)
            if (quantityToBuy > stock)
            {
                MessageBox.Show("Stock too small for the entered quantity");
                book.ClearTextBox();
                return;
            }
            else
            {
                //MessageBox.Show(book.ToString() + "\nHas been added to your basket!");
                booksToBeBought.Add(new BookEntry(book.GetTitle(), book.GetQuantity(), book.GetPrice()));
                book.subtractStock(quantityToBuy);
                book.ClearTextBox();
            }
            foreach (BookEntry book0 in booksToBeBought)
            {
                System.Diagnostics.Debug.Write(book0.ToString() + '\n');
            }
        }
    }
}
