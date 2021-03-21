namespace Bookshop
{
    partial class DisplayBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeStock = new System.Windows.Forms.ToolStripMenuItem();
            this.addBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByToolStripMenuItem,
            this.administratorOptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleToolStripMenuItem,
            this.authorToolStripMenuItem,
            this.pagesToolStripMenuItem,
            this.priceToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.sortByToolStripMenuItem.Text = "Sort By";
            this.sortByToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sortByToolStripMenuItem_DropDownItemClicked);
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.titleToolStripMenuItem.Text = "Title";
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.authorToolStripMenuItem.Text = "Author";
            // 
            // pagesToolStripMenuItem
            // 
            this.pagesToolStripMenuItem.Name = "pagesToolStripMenuItem";
            this.pagesToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.pagesToolStripMenuItem.Text = "Pages";
            // 
            // priceToolStripMenuItem
            // 
            this.priceToolStripMenuItem.Name = "priceToolStripMenuItem";
            this.priceToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.priceToolStripMenuItem.Text = "Price";
            // 
            // administratorOptionsToolStripMenuItem
            // 
            this.administratorOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeStock,
            this.addBooksToolStripMenuItem,
            this.removeBooksToolStripMenuItem});
            this.administratorOptionsToolStripMenuItem.Name = "administratorOptionsToolStripMenuItem";
            this.administratorOptionsToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.administratorOptionsToolStripMenuItem.Text = "Administrator Options";
            // 
            // removeBooksToolStripMenuItem
            // 
            this.removeBooksToolStripMenuItem.Name = "removeBooksToolStripMenuItem";
            this.removeBooksToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.removeBooksToolStripMenuItem.Text = "Remove Books";
            this.removeBooksToolStripMenuItem.Click += new System.EventHandler(this.removeBooksToolStripMenuItem_Click);
            // 
            // ChangeStock
            // 
            this.ChangeStock.Name = "ChangeStock";
            this.ChangeStock.Size = new System.Drawing.Size(176, 24);
            this.ChangeStock.Text = "Change Stock";
            this.ChangeStock.Click += new System.EventHandler(this.addBooksToolStripMenuItem_Click);
            // 
            // addBooksToolStripMenuItem
            // 
            this.addBooksToolStripMenuItem.Name = "addBooksToolStripMenuItem";
            this.addBooksToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.addBooksToolStripMenuItem.Text = "Add Books";
            this.addBooksToolStripMenuItem.Click += new System.EventHandler(this.addBooksToolStripMenuItem_Click_1);
            // 
            // DisplayBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(549, 295);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DisplayBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.DisplayBooks_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administratorOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeStock;
        private System.Windows.Forms.ToolStripMenuItem addBooksToolStripMenuItem;

    }
}