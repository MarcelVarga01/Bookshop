namespace Bookshop
{
    partial class AddBooks
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
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.Label();
            this.PagesTextBox = new System.Windows.Forms.TextBox();
            this.Pages = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.Label();
            this.StockTextBox = new System.Windows.Forms.TextBox();
            this.Stock = new System.Windows.Forms.Label();
            this.CoverImageTextBox = new System.Windows.Forms.TextBox();
            this.CoverImage = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "Add New Book to the Database";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(151, 86);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(39, 17);
            this.Title.TabIndex = 8;
            this.Title.Text = "Title:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(196, 86);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(170, 22);
            this.TitleTextBox.TabIndex = 0;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(196, 116);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(170, 22);
            this.AuthorTextBox.TabIndex = 1;
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(136, 116);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(54, 17);
            this.Author.TabIndex = 9;
            this.Author.Text = "Author:";
            // 
            // PagesTextBox
            // 
            this.PagesTextBox.Location = new System.Drawing.Point(196, 146);
            this.PagesTextBox.Name = "PagesTextBox";
            this.PagesTextBox.Size = new System.Drawing.Size(170, 22);
            this.PagesTextBox.TabIndex = 2;
            // 
            // Pages
            // 
            this.Pages.AutoSize = true;
            this.Pages.Location = new System.Drawing.Point(138, 146);
            this.Pages.Name = "Pages";
            this.Pages.Size = new System.Drawing.Size(52, 17);
            this.Pages.TabIndex = 10;
            this.Pages.Text = "Pages:";
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(196, 176);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(170, 22);
            this.PriceTextBox.TabIndex = 3;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(146, 176);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(44, 17);
            this.Price.TabIndex = 11;
            this.Price.Text = "Price:";
            // 
            // StockTextBox
            // 
            this.StockTextBox.Location = new System.Drawing.Point(196, 206);
            this.StockTextBox.Name = "StockTextBox";
            this.StockTextBox.Size = new System.Drawing.Size(170, 22);
            this.StockTextBox.TabIndex = 4;
            // 
            // Stock
            // 
            this.Stock.AutoSize = true;
            this.Stock.Location = new System.Drawing.Point(143, 206);
            this.Stock.Name = "Stock";
            this.Stock.Size = new System.Drawing.Size(47, 17);
            this.Stock.TabIndex = 12;
            this.Stock.Text = "Stock:";
            // 
            // CoverImageTextBox
            // 
            this.CoverImageTextBox.AllowDrop = true;
            this.CoverImageTextBox.Location = new System.Drawing.Point(196, 236);
            this.CoverImageTextBox.Name = "CoverImageTextBox";
            this.CoverImageTextBox.Size = new System.Drawing.Size(170, 22);
            this.CoverImageTextBox.TabIndex = 5;
            this.CoverImageTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.CoverImageTextBox_DragDrop);
            this.CoverImageTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.CoverImageTextBox_DragEnter);
            this.CoverImageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoverImageTextBox_KeyDown);
            // 
            // CoverImage
            // 
            this.CoverImage.AutoSize = true;
            this.CoverImage.Location = new System.Drawing.Point(66, 236);
            this.CoverImage.Name = "CoverImage";
            this.CoverImage.Size = new System.Drawing.Size(124, 17);
            this.CoverImage.TabIndex = 13;
            this.CoverImage.Text = "Cover Image Path:";
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(207, 265);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(113, 40);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 317);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CoverImageTextBox);
            this.Controls.Add(this.CoverImage);
            this.Controls.Add(this.StockTextBox);
            this.Controls.Add(this.Stock);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.PagesTextBox);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label1);
            this.Name = "AddBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.TextBox PagesTextBox;
        private System.Windows.Forms.Label Pages;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.TextBox StockTextBox;
        private System.Windows.Forms.Label Stock;
        private System.Windows.Forms.TextBox CoverImageTextBox;
        private System.Windows.Forms.Label CoverImage;
        private System.Windows.Forms.Button AddButton;
    }
}