using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Bookshop
{
    // Used to map Buttons to Books
    public class Book
    {
        string title;
        TextBox quantity;
        Label stock;
        float price;

        internal Book(String title, TextBox quantity, Label stock, String price)
        {
            this.title = title;
            this.quantity = quantity;
            this.stock = stock;
            this.price = float.Parse(price);
        }

        public override string ToString()
        {
            return ("Title: " + title + "\nQuantity: " + quantity.Text + "\nPrice " + price.ToString());
        }
        public bool TextBoxEmpty()
        {
            return quantity.Text == "";
        }
        public string GetTitle()
        {
            return this.title;
        }
        public int GetQuantity()
        {
            if (quantity.Text == "")
            {
                MessageBox.Show("Please enter a value in the Text Box");
                return 0;
            }
            return Int32.Parse(quantity.Text);
        }
        public int GetStock()
        {
            return Int32.Parse(stock.Text.Remove(0, 6));
        }
        public float GetPrice()
        {
            return price;
        }
        public void ClearTextBox() 
        {
            quantity.Text = "";
        }
        public void subtractStock(int value)
        {
            int stockInt = Int32.Parse(stock.Text.Remove(0, 6));
            if (stockInt >= value)
            stock.Text = "Stock: " + (stockInt - value);
        }
    }
}
