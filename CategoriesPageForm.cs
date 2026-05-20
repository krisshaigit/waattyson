using System;
using System.Drawing;
using System.Data.SQLite; // <-- ADDED FOR SQLITE
using System.Linq;
using System.Text; // <-- ADDED FOR STRINGBUILDER
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class CategoriesPageForm : Form
    {
        private FlowLayoutPanel productGrid;
        private string loggedInUsername; // <-- ADDED TO TRACK WHO IS ORDERING

        // UPDATED CONSTRUCTOR: Now accepts the logged-in username
        public CategoriesPageForm(string username = "GuestUser")
        {
            InitializeComponent();
            this.loggedInUsername = username;
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

            // NEW CHECKOUT BUTTON Added to the right side of the category bar
            Button btnCheckout = new Button()
            {
                Text = "🛒 Checkout",
                Location = new Point(leftOffset + 20, 12),
                Size = new Size(130, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.Click += BtnCheckout_Click; // Link to our new SQLite method
            pnlCategories.Controls.Add(btnCheckout);

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

            if (selectedProduct.Stock <= 0)
            {
                MessageBox.Show("Sorry, this item is currently out of stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingCartItem = DataEngine.Cart.FirstOrDefault(c => c.Product.ProductId == selectedProduct.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
            }
            else
            {
                DataEngine.Cart.Add(new CartItem
                {
                    Product = selectedProduct,
                    Quantity = 1
                });
            }

            // Deduct the runtime stock value so the user can visually track it
            selectedProduct.Stock -= 1;

            // Refresh visual grid card numbers immediately
            Button clickedBtn = (Button)sender;
            string dynamicCategory = selectedProduct.Category;
            DisplayCategoryProducts(dynamicCategory);

            MessageBox.Show($"{selectedProduct.Name} added to your cart!", "Cart Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // NEW SQLITE CHECKOUT METHOD
        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (DataEngine.Cart == null || DataEngine.Cart.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomSuffix = new string(Enumerable.Repeat(chars, 4).Select(s => s[rand.Next(s.Length)]).ToArray());
            string generatedTrackingId = $"TRK-{randomSuffix}";

            StringBuilder detailsBuilder = new StringBuilder();
            double totalOrderPrice = 0;
            foreach (var item in DataEngine.Cart)
            {
                detailsBuilder.Append($"{item.Quantity}x {item.Product.Name}, ");
                totalOrderPrice += (double)(item.Product.Price * item.Quantity);
            }
            string finalItemDetails = detailsBuilder.ToString().TrimEnd(',', ' ');

            string dbConnectionPath = "Data Source=watson_shop.db;Version=3;";

            try
            {
                using (var connection = new SQLiteConnection(dbConnectionPath))
                {
                    connection.Open();

                    string insertOrderQuery = @"
                INSERT INTO Orders (OrderId, Username, ItemDetails, TotalPrice, Status) 
                VALUES (@OrderId, @Username, @ItemDetails, @TotalPrice, 'Pending');";

                    using (var command = new SQLiteCommand(insertOrderQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", generatedTrackingId);
                        command.Parameters.AddWithValue("@Username", this.loggedInUsername);
                        command.Parameters.AddWithValue("@ItemDetails", finalItemDetails);
                        command.Parameters.AddWithValue("@TotalPrice", totalOrderPrice);

                        command.ExecuteNonQuery();
                    }
                }

                DataEngine.Cart.Clear();
                MessageBox.Show($"Order processed successfully!\nTracking ID: {generatedTrackingId}\nTotal: ₱{totalOrderPrice:N2}", "Checkout Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayCategoryProducts("Baby Care");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SQL Save Failure: {ex.Message}", "Database Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}