using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class CategoriesPageForm : Form
    {
        private FlowLayoutPanel productGrid;

        public CategoriesPageForm()
        {
            InitializeComponent();
            SetupCategoryUI();
        }

        private void SetupCategoryUI()
        {
            Panel pnlCategories = new Panel() { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };

            string[] categories = { "Baby Care", "Personal Care", "Make Up", "Medicine", "Fragrance" };
            int leftOffset = 10;

            foreach (string cat in categories)
            {
                Button btnCat = new Button()
                {
                    Text = cat,
                    Location = new Point(leftOffset, 12),
                    Size = new Size(130, 35),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(0, 161, 155),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Tag = cat
                };
                btnCat.FlatAppearance.BorderSize = 0;
                btnCat.Click += CategoryButton_Click;
                pnlCategories.Controls.Add(btnCat);
                leftOffset += 140;
            }

            productGrid = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(245, 247, 248)
            };

            this.Controls.Add(productGrid);
            this.Controls.Add(pnlCategories);

            DisplayCategoryProducts("Baby Care");
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string selectedCategory = clickedButton.Tag.ToString();
            DisplayCategoryProducts(selectedCategory);
        }

        private void DisplayCategoryProducts(string categoryName)
        {
            productGrid.Controls.Clear();

            var filteredProducts = DataEngine.Products
                .Where(p => p.Category.Equals(categoryName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var prod in filteredProducts)
            {
                // Shorter card height since there's no picture box now!
                Panel card = new Panel()
                {
                    Size = new Size(220, 160),
                    BackColor = Color.White,
                    Margin = new Padding(10)
                };

                Label lblName = new Label()
                {
                    Text = prod.Name,
                    Location = new Point(10, 15),
                    Size = new Size(200, 40),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(40, 40, 40)
                };

                Label lblPrice = new Label()
                {
                    Text = $"₱{prod.Price:N2}",
                    Location = new Point(10, 65),
                    Size = new Size(100, 20),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 161, 155)
                };

                Label lblStock = new Label()
                {
                    Text = $"Stock: {prod.Stock}",
                    Location = new Point(110, 67),
                    Size = new Size(100, 20),
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.TopRight
                };

                Button btnAddToCart = new Button()
                {
                    Text = "Add to Cart",
                    Location = new Point(10, 105),
                    Size = new Size(200, 35),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Orange,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Tag = prod
                };
                btnAddToCart.FlatAppearance.BorderSize = 0;
                btnAddToCart.Click += AddToCart_Click;

                card.Controls.Add(lblName);
                card.Controls.Add(lblPrice);
                card.Controls.Add(lblStock);
                card.Controls.Add(btnAddToCart);

                productGrid.Controls.Add(card);
            }
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Product selectedProduct = (Product)btn.Tag;
            MessageBox.Show($"{selectedProduct.Name} added to your cart!", "Cart Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}