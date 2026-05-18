using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class BrowsePageForm : Form
    {
        // Define controls at the class level
        private DataGridView dgvProducts;
        private TextBox txtSearch;
        private ComboBox cbCategoryFilter;

        public BrowsePageForm()
        {
            // 1. Setup the UI layout directly here instead of using a conflicting method name
            this.txtSearch = new TextBox() { Location = new System.Drawing.Point(20, 20), Width = 250 };
            this.cbCategoryFilter = new ComboBox() { Location = new System.Drawing.Point(290, 20), Width = 150 };
            this.dgvProducts = new DataGridView() { Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(740, 420), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };

            Button btnAddToCart = new Button() { Text = "Add to Cart", Location = new System.Drawing.Point(20, 500), Size = new System.Drawing.Size(120, 35), BackColor = System.Drawing.Color.FromArgb(0, 161, 155), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };

            this.txtSearch.TextChanged += SearchOrFilter;
            this.cbCategoryFilter.SelectedIndexChanged += SearchOrFilter;
            btnAddToCart.Click += BtnAddToCart_Click;

            this.Controls.AddRange(new Control[] { txtSearch, cbCategoryFilter, dgvProducts, btnAddToCart });

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
    }
}