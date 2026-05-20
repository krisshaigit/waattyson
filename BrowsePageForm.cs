using System;
using System.Data;
using System.Data.SQLite; // <-- ADDED THIS FOR SQLITE
using System.Linq;
using System.Text; // <-- ADDED FOR STRINGBUILDER
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class BrowsePageForm : Form
    {
        // Define controls at the class level
        private DataGridView dgvProducts;
        private TextBox txtSearch;
        private ComboBox cbCategoryFilter;
        private string loggedInUsername; // <-- ADDED TO TRACK WHO IS ORDERING

        // UPDATED CONSTRUCTOR: Now accepts the logged-in username
        public BrowsePageForm(string username = "GuestUser")
        {
            this.loggedInUsername = username;

            // 1. Setup the UI layout directly here
            this.txtSearch = new TextBox() { Location = new System.Drawing.Point(20, 20), Width = 250 };
            this.cbCategoryFilter = new ComboBox() { Location = new System.Drawing.Point(290, 20), Width = 150 };
            this.dgvProducts = new DataGridView() { Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(740, 420), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };

            Button btnAddToCart = new Button() { Text = "Add to Cart", Location = new System.Drawing.Point(20, 500), Size = new System.Drawing.Size(120, 35), BackColor = System.Drawing.Color.FromArgb(0, 161, 155), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };

            // NEW CHECKOUT BUTTON FOR SQLITE
            Button btnCheckout = new Button() { Text = "Checkout & Order", Location = new System.Drawing.Point(160, 500), Size = new System.Drawing.Size(150, 35), BackColor = System.Drawing.Color.DarkOrange, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };

            this.txtSearch.TextChanged += SearchOrFilter;
            this.cbCategoryFilter.SelectedIndexChanged += SearchOrFilter;
            btnAddToCart.Click += BtnAddToCart_Click;
            btnCheckout.Click += BtnCheckout_Click; // <-- LINK THE CHECKOUT EVENT

            // Add all controls including the new Checkout button to the canvas
            this.Controls.AddRange(new Control[] { txtSearch, cbCategoryFilter, dgvProducts, btnAddToCart, btnCheckout });

            // 2. Load runtime components safely
            cbCategoryFilter.Items.Add("All Categories");
            if (DataEngine.Products != null)
            {
                cbCategoryFilter.Items.AddRange(DataEngine.Products.Select(p => p.Category).Distinct().ToArray());
            }
            cbCategoryFilter.SelectedIndex = 0;

            LoadProductData();
        }

        public void LoadProductData(string filterCategory = "All Categories")
        {
            var source = DataEngine.Products.AsEnumerable();
            if (filterCategory != "All Categories")
            {
                source = source.Where(p => p.Category == filterCategory);
                cbCategoryFilter.SelectedItem = filterCategory;
            }

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                source = source.Where(p => p.Name.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvProducts.DataSource = source.ToList();
        }

        private void SearchOrFilter(object sender, EventArgs e) => LoadProductData(cbCategoryFilter.SelectedItem?.ToString() ?? "All Categories");

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var targetProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
                if (targetProduct.Stock > 0)
                {
                    var existingItem = DataEngine.Cart.FirstOrDefault(c => c.Product.ProductId == targetProduct.ProductId);
                    if (existingItem != null) existingItem.Quantity++;
                    else DataEngine.Cart.Add(new CartItem { Product = targetProduct, Quantity = 1 });

                    targetProduct.Stock--;
                    MessageBox.Show($"{targetProduct.Name} added to cart!");
                    LoadProductData();
                }
                else MessageBox.Show("Item out of stock!");
            }
        }

        // NEW METHOD: Slices the Cart list and saves it directly to SQLite!
        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (DataEngine.Cart == null || DataEngine.Cart.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Generate a tracking ID that matches your exact format (e.g., TRK-ABCD)
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomSuffix = new string(Enumerable.Repeat(chars, 4).Select(s => s[rand.Next(s.Length)]).ToArray());
            string generatedTrackingId = $"TRK-{randomSuffix}";

            // 2. Build item details string
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

                    // This query inserts using the exact matching structural schema names
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

                // Clear out tracking data lists safely
                DataEngine.Cart.Clear();
                MessageBox.Show($"Order processed successfully!\nTracking ID: {generatedTrackingId}\nTotal: ₱{totalOrderPrice:N2}", "Checkout Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SQL Save Failure: {ex.Message}\n\nVerify that your table has columns named: OrderId, Username, ItemDetails, TotalPrice, Status", "Database Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}