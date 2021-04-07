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
    public partial class Basket : Form
    {
        List<BookEntry> books;
        displayBooks parent;
        const int PANELHEIGHT = 20;
        const int PANELWIDTH = 1000;
        const int TITLEWIDTH = 200;
        const int QUANTITYWIDTH = 150;
        const int PRICEWIDTH = 200;
        int line = 0;
        float totalPrice = 0;
        int totalQuantity = 0;

        public Basket(List<BookEntry> books, displayBooks parent)
        {
            this.books = books;
            this.parent = parent;
            this.Text = "Basket";
            this.StartPosition = FormStartPosition.CenterScreen;
            if (books.Count == 0) displayBasketEmpty();
            InitializeComponent();
            mergeBookEntries();
            createPageElements();
            addFooter();
            addClearButton();
            addBuyButton();

        }
        private void displayBasketEmpty()
        {
            Label emptyBasket = new Label();
            emptyBasket.Text = "Basket is empty";
            emptyBasket.Font = new Font("Arial", 26, FontStyle.Bold);
            emptyBasket.AutoSize = false;
            emptyBasket.TextAlign = ContentAlignment.MiddleCenter;
            emptyBasket.Dock = DockStyle.Fill;
            Controls.Add(emptyBasket);            
        }
        // Add up quantities of books that have the same title (same book)
        private void mergeBookEntries()
        {

            System.Diagnostics.Debug.Write("----------------------------------New Call-----------------------------------\n");
            foreach (BookEntry book in books)
            {
                System.Diagnostics.Debug.Write(book.ToString() + '\n');
            }
            System.Diagnostics.Debug.Write("\n\n");

            books.Sort();
            for (int i = 0; i < books.Count - 1; i++) 
            {
                while (i < books.Count -1  && books[i].addQuantities(books[i + 1]))
                    books.RemoveAt(i + 1);
            }
            foreach (BookEntry book in books)
            {
                System.Diagnostics.Debug.Write(book.ToString() + '\n');
            }
        }

        private void createPageElements()
        {
            foreach (BookEntry book in books) 
            {
                FlowLayoutPanel panel = createPanel(book, false);
                panel.Location = new Point(10, 10 + PANELHEIGHT * line);
                Controls.Add(panel);
                line++;
            }
        }

        private FlowLayoutPanel createPanel(BookEntry book, bool isFooter)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.Height = PANELHEIGHT;
            panel.Width = PANELWIDTH;

            Label title = new Label();
            title.Width = TITLEWIDTH;
            if (!isFooter) title.Text = "Title: ";
            title.Text += book.getTitle();

            title.Anchor = AnchorStyles.Left;
            panel.Controls.Add(title);


            Label quantity = new Label();
            quantity.Width = QUANTITYWIDTH;
            if (isFooter) quantity.Text = "Total quantity is: ";
                else quantity.Text = "Quantity: ";
            quantity.Text += book.getQuantity().ToString();

            quantity.Anchor = AnchorStyles.Left;
            panel.Controls.Add(quantity);
            totalQuantity += book.getQuantity();


            Label price = new Label();
            price.Width = PRICEWIDTH;
            if (isFooter) price.Text = "Total price is: ";
                else price.Text = "Price: ";
            price.Text += (book.getPrice() * book.getQuantity()).ToString();

            price.Anchor = AnchorStyles.Left;
            panel.Controls.Add(price);
            totalPrice += book.getPrice();

            return panel;
        }
        private void addFooter() 
        {
            Panel panel = createPanel(new BookEntry("Basket totals: ", totalQuantity, totalPrice), true);
            panel.Location = new Point(10, 10 + PANELHEIGHT * line);
            Controls.Add(panel);
            line++;
        }
        private void addClearButton()
        {
            int formWidth = this.Width;

            Button button = new Button();
            button.Text = "Clear Basket";
            button.Location = new Point((formWidth / 4), 10 + PANELHEIGHT * line);
            button.Click += new EventHandler(clearButton_Click);
            Controls.Add(button);
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            books.Clear();
            this.Controls.Clear();
            displayBasketEmpty();
            parent.redraw(parent.lastSortBy);

        }
        private void addBuyButton()
        {
            int formWidth = this.Width;

            Button button = new Button();
            button.Text = "Buy books";
            button.Location = new Point(2 * (formWidth/4), 10 + PANELHEIGHT * line);
            button.Click += new EventHandler(buyButton_Click);
            Controls.Add(button);
            line++;
        }
        private void buyButton_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Database.mdf;Integrated Security=True;User Instance=True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            foreach (BookEntry book in books)
            {
                string sql = @"UPDATE Books SET Stock = Stock - " + book.getQuantity() + "WHERE Title = '" + book.getTitle() + "'";
                            
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
            }
            con.Close();
            MessageBox.Show("Books bought successfully!");
            parent.redraw(parent.lastSortBy);
            this.Close();
        }
    }
}
