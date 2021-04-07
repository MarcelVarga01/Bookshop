using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookshop
{
    // Used for providing encapsulating books for the shopping basket
    public class BookEntry : IComparable
    {
        private string title;
        private int quantity;
        private float price;
        public BookEntry(string title, int quantity, float price)
        {
            this.title = title;
            this.quantity = quantity;
            this.price = price;
        }
        public override string ToString()
        {
            return ("Title: " + title + ", Quantity: " + quantity.ToString() + ", Price " + price.ToString());
        }
        public string getTitle()
        {
            return title;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public float getPrice()
        {
            return price;
        }
        // If the books have the same title, add their quantities and return true
        // Else return false
        public bool addQuantities(BookEntry book){
            if (!this.title.Equals(book.getTitle())) return false;
            this.quantity += book.getQuantity();
            return true;
        }

        public int CompareTo(object book)
        {
            return this.title.CompareTo(((BookEntry)book).getTitle());
        }
    }
}
