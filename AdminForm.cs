using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class AdminForm : Form
    {
        // File paths (Will be created in the application debug/release folder)
        private readonly string usersFile = "users.txt";
        private readonly string productsFile = "products.txt";
        private readonly string ordersFile = "orders.txt";

        // Lists to hold our data in memory
        private List<User> usersList = new List<User>();
        private List<Product> productsList = new List<Product>();
        private List<Order> ordersList = new List<Order>();

        // Add these two properties at the top of your class fields
        private string loggedInUsername;
        private string loggedInRole;
        private string currentActionMode = ""; // Tracks "Add" vs "Edit"

        // Replace your old public AdminForm() constructor with this one:
        public AdminForm(string username, string role)
        {
            InitializeComponent();

            // Save the credentials passed from the login form
            loggedInUsername = username;
            loggedInRole = role;
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            EnsureFilesExist();
            LoadAllData();
            ShowPanel(pnlDashboard); // Show dashboard by default
        }

        #region --- FILE I/O & DATA LOADING ---

        private void EnsureFilesExist()
        {
            // Create dummy files if they don't exist
            if (!File.Exists(usersFile)) File.WriteAllText(usersFile, "1|admin01|admin123|Main Admin|Admin||Active\n");
            if (!File.Exists(productsFile)) File.WriteAllText(productsFile, "F001,Penshoppe Signature Body Spray,Fragrance,150.00,45\n");
            if (!File.Exists(ordersFile))
            {
                string dummyOrder = "Order|2026-05-18T12:06:55|Tracking:TRK-14DF0F2D37|Status:To Receive|FirstName:Juan|LastName:Dela Cruz|Address:Philippines\n" +
                                    "1x|P001|Advanced HA Serum|₱1,249.00\nEndOrder\n";
                File.WriteAllText(ordersFile, dummyOrder);
            }
        }

        private void LoadAllData()
        {
            LoadUsers();
            LoadProducts();
            LoadOrders();
            UpdateDashboardCounts();

            // Match the user by the username passed from the login form
            var currentAdmin = usersList.FirstOrDefault(u => u.Username.Equals(loggedInUsername, StringComparison.OrdinalIgnoreCase));
            if (currentAdmin != null)
            {
                txtProfName.Text = currentAdmin.FullName;
                txtProfPass.Text = currentAdmin.Password;
            }
        }

        private void UpdateDashboardCounts()
        {
            lblTotalUsers.Text = $"TOTAL USERS\n{usersList.Count}";
            lblTotalProducts.Text = $"TOTAL PRODUCTS\n{productsList.Count}";
            lblTotalOrders.Text = $"TOTAL ORDERS\n{ordersList.Count}";
        }

        #endregion

        #region --- NAVIGATION ---
        private void NavButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnDashboard) ShowPanel(pnlDashboard);
            else if (btn == btnUsers) ShowPanel(pnlUsers);
            else if (btn == btnInventory) ShowPanel(pnlInventory);
            else if (btn == btnOrders) ShowPanel(pnlOrders);
            else if (btn == btnProfile) ShowPanel(pnlProfile);
        }

        private void ShowPanel(Panel panelToShow)
        {
            pnlDashboard.Visible = false;
            pnlUsers.Visible = false;
            pnlInventory.Visible = false;
            pnlOrders.Visible = false;
            pnlProfile.Visible = false;

            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }
        #endregion

        #region --- USER MANAGEMENT ---
        private void LoadUsers()
        {
            usersList.Clear();
            bool requiresSave = false;

            using (StreamReader reader = new StreamReader(usersFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length >= 7)
                    {
                        var user = new User
                        {
                            Id = parts[0],
                            Username = parts[1],
                            Password = parts[2],
                            FullName = parts[3],
                            Role = parts[4],
                            BanExpiration = parts[5],
                            Status = parts[6]
                        };

                        // Auto unban logic
                        if (user.Status == "Banned" && DateTime.TryParse(user.BanExpiration, out DateTime banDate))
                        {
                            if (DateTime.Now >= banDate)
                            {
                                user.Status = "Active";
                                user.BanExpiration = "";
                                requiresSave = true;
                            }
                        }
                        usersList.Add(user);
                    }
                }
            }

            if (requiresSave) SaveUsersFile();
            RefreshUserGrid(usersList);
        }

        private void RefreshUserGrid(List<User> list)
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = list.Select(u => new { u.Id, u.Username, u.FullName, u.Role, u.Status, u.BanExpiration }).ToList();
        }

        private void SaveUsersFile()
        {
            using (StreamWriter writer = new StreamWriter(usersFile, false))
            {
                foreach (var u in usersList)
                {
                    writer.WriteLine($"{u.Id}|{u.Username}|{u.Password}|{u.FullName}|{u.Role}|{u.BanExpiration}|{u.Status}");
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            currentActionMode = "Add";
            lblPopupTitle.Text = "Register New User Matrix";

            // Clear old text values
            txtUsername.Text = ""; txtPassword.Text = ""; txtFullName.Text = ""; cmbRole.SelectedIndex = 1; numBanHours.Value = 0;
            txtUsername.ReadOnly = false;

            // FORCE-BIND TO POPUP PANEL TO PREVENT LAYOUT GLITCHES
            if (!pnlUserPopup.Controls.Contains(txtUsername))
            {
                pnlUserPopup.Controls.AddRange(new Control[] { txtUsername, txtPassword, txtFullName, cmbRole });
            }

            // Bring inputs to the absolute front of the white panel
            txtUsername.BringToFront();
            txtPassword.BringToFront();
            txtFullName.BringToFront();
            cmbRole.BringToFront();

            pnlUserPopup.Visible = true;
            pnlUserPopup.BringToFront();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) { MessageBox.Show("Please select a target user line first."); return; }
            currentActionMode = "Edit";
            lblPopupTitle.Text = "Edit Existing User Record";

            string id = dgvUsers.CurrentRow.Cells["Id"].Value.ToString();
            var user = usersList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                txtUsername.Text = user.Username;
                txtUsername.ReadOnly = true;
                txtPassword.Text = user.Password;
                txtFullName.Text = user.FullName;
                cmbRole.Text = user.Role;
                numBanHours.Value = 0;

                // FORCE-BIND TO POPUP PANEL TO PREVENT LAYOUT GLITCHES
                if (!pnlUserPopup.Controls.Contains(txtUsername))
                {
                    pnlUserPopup.Controls.AddRange(new Control[] { txtUsername, txtPassword, txtFullName, cmbRole });
                }

                // Bring inputs to the absolute front of the white panel
                txtUsername.BringToFront();
                txtPassword.BringToFront();
                txtFullName.BringToFront();
                cmbRole.BringToFront();

                pnlUserPopup.Visible = true;
                pnlUserPopup.BringToFront();
            }
        }

        private void btnPopupUserSave_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text.Trim();

            // STRICT PASSWORD SECURITY COMPLIANCE RULES CHECK
            if (pass.Length < 8 || !pass.Any(char.IsUpper) || !pass.Any(char.IsDigit) || !pass.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Security Matrix Error: Password requires an 8 character configuration minimum containing 1 uppercase letter, 1 digit, and 1 symbolic item descriptor.", "Weak Password Specified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentActionMode == "Add")
            {
                string newId = usersList.Count > 0 ? (int.Parse(usersList.Last().Id) + 1).ToString() : "1";
                string status = numBanHours.Value > 0 ? "Banned" : "Active";
                string expiration = numBanHours.Value > 0 ? DateTime.Now.AddHours((double)numBanHours.Value).ToString("yyyy-MM-dd HH:mm:ss") : "";

                usersList.Add(new User
                {
                    Id = newId,
                    Username = txtUsername.Text,
                    Password = pass,
                    FullName = txtFullName.Text,
                    Role = cmbRole.Text,
                    Status = status,
                    BanExpiration = expiration
                });
            }
            else if (currentActionMode == "Edit")
            {
                string id = dgvUsers.CurrentRow.Cells["Id"].Value.ToString();
                var user = usersList.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.Password = pass;
                    user.FullName = txtFullName.Text;
                    user.Role = cmbRole.Text;
                    if (numBanHours.Value > 0)
                    {
                        user.Status = "Banned";
                        user.BanExpiration = DateTime.Now.AddHours((double)numBanHours.Value).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }

            SaveUsersFile(); LoadUsers(); UpdateDashboardCounts();
            pnlUserPopup.Visible = false;
            MessageBox.Show("User configuration file base systematically saved!");
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            if (MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string id = dgvUsers.CurrentRow.Cells["Id"].Value.ToString();
                usersList.RemoveAll(u => u.Id == id);
                SaveUsersFile(); LoadUsers(); UpdateDashboardCounts();
            }
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            string id = dgvUsers.CurrentRow.Cells["Id"].Value.ToString();
            var user = usersList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Status = "Banned";
                user.BanExpiration = DateTime.Now.AddHours(24).ToString("yyyy-MM-dd HH:mm:ss");
                SaveUsersFile(); LoadUsers();
                MessageBox.Show("User Banned for 24 Hours!");
            }
        }

        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            var search = txtUserSearch.Text.ToLower();
            RefreshUserGrid(usersList.Where(u => u.Username.ToLower().Contains(search) || u.FullName.ToLower().Contains(search)).ToList());
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                string id = dgvUsers.CurrentRow.Cells["Id"].Value.ToString();
                var user = usersList.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    txtUsername.Text = user.Username;
                    txtPassword.Text = user.Password;
                    txtFullName.Text = user.FullName;
                    cmbRole.Text = user.Role;
                }
            }
        }
        #endregion

        #region --- INVENTORY MANAGEMENT ---
        private void LoadProducts()
        {
            productsList.Clear();
            using (StreamReader reader = new StreamReader(productsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length >= 5)
                    {
                        productsList.Add(new Product
                        {
                            Id = parts[0],
                            Name = parts[1],
                            Category = parts[2],
                            Price = decimal.Parse(parts[3]),
                            Stock = int.Parse(parts[4])
                        });
                    }
                }
            }
            RefreshProductGrid(productsList.OrderBy(p => p.Category).ToList());
        }

        private void RefreshProductGrid(List<Product> list)
        {
            dgvInventory.DataSource = null;
            dgvInventory.DataSource = list;
        }

        private void SaveProductsFile()
        {
            using (StreamWriter writer = new StreamWriter(productsFile, false))
            {
                foreach (var p in productsList)
                    writer.WriteLine($"{p.Id},{p.Name},{p.Category},{p.Price},{p.Stock}");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            currentActionMode = "Add";
            lblProdPopupTitle.Text = "Initialize New Product SKU";
            txtProdName.Text = ""; txtProdCategory.Text = ""; txtProdPrice.Text = ""; txtProdStock.Text = "";

            if (!pnlProdPopup.Controls.Contains(txtProdName))
            {
                pnlProdPopup.Controls.AddRange(new Control[] { txtProdName, txtProdCategory, txtProdPrice, txtProdStock });
            }

            txtProdName.BringToFront();
            txtProdCategory.BringToFront();
            txtProdPrice.BringToFront();
            txtProdStock.BringToFront();

            pnlProdPopup.Visible = true;
            pnlProdPopup.BringToFront();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null) { MessageBox.Show("Select a catalog item line to adjust."); return; }
            currentActionMode = "Edit";
            lblProdPopupTitle.Text = "Update Product Specifications";

            string id = dgvInventory.CurrentRow.Cells["Id"].Value.ToString();
            var prod = productsList.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                txtProdName.Text = prod.Name;
                txtProdCategory.Text = prod.Category;
                txtProdPrice.Text = prod.Price.ToString();
                txtProdStock.Text = prod.Stock.ToString();

                if (!pnlProdPopup.Controls.Contains(txtProdName))
                {
                    pnlProdPopup.Controls.AddRange(new Control[] { txtProdName, txtProdCategory, txtProdPrice, txtProdStock });
                }

                txtProdName.BringToFront();
                txtProdCategory.BringToFront();
                txtProdPrice.BringToFront();
                txtProdStock.BringToFront();

                pnlProdPopup.Visible = true;
                pnlProdPopup.BringToFront();
            }
        }
        private void btnPopupUserClose_Click(object sender, EventArgs e)
        {
            this.pnlUserPopup.Visible = false;
        }

        private void btnPopupProdClose_Click(object sender, EventArgs e)
        {
            this.pnlProdPopup.Visible = false;
        }

        private void btnPopupProdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProdName.Text)) return;

            decimal.TryParse(txtProdPrice.Text, out decimal targetPrice);
            int.TryParse(txtProdStock.Text, out int targetStock);

            if (currentActionMode == "Add")
            {
                string newId = "F" + (productsList.Count > 0 ? (int.Parse(productsList.Last().Id.Replace("F", "")) + 1).ToString("D3") : "001");
                productsList.Add(new Product { Id = newId, Name = txtProdName.Text, Category = txtProdCategory.Text, Price = targetPrice, Stock = targetStock });
            }
            else if (currentActionMode == "Edit")
            {
                string id = dgvInventory.CurrentRow.Cells["Id"].Value.ToString();
                var prod = productsList.FirstOrDefault(p => p.Id == id);
                if (prod != null)
                {
                    prod.Name = txtProdName.Text;
                    prod.Category = txtProdCategory.Text;
                    prod.Price = targetPrice;
                    prod.Stock = targetStock;
                }
            }

            SaveProductsFile(); LoadProducts(); UpdateDashboardCounts();
            pnlProdPopup.Visible = false;
            MessageBox.Show("Inventory catalog changes applied!");
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null) return;
            if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string id = dgvInventory.CurrentRow.Cells["Id"].Value.ToString();
                productsList.RemoveAll(p => p.Id == id);
                SaveProductsFile(); LoadProducts(); UpdateDashboardCounts();
            }
        }

        private void txtProdSearch_TextChanged(object sender, EventArgs e)
        {
            var search = txtProdSearch.Text.ToLower();
            RefreshProductGrid(productsList.Where(p => p.Name.ToLower().Contains(search) || p.Category.ToLower().Contains(search)).ToList());
        }

        private void dgvInventory_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["Stock"].Value) < 10)
            {
                dgvInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                dgvInventory.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow != null)
            {
                txtProdName.Text = dgvInventory.CurrentRow.Cells["Name"].Value.ToString();
                txtProdCategory.Text = dgvInventory.CurrentRow.Cells["Category"].Value.ToString();
                txtProdPrice.Text = dgvInventory.CurrentRow.Cells["Price"].Value.ToString();
                txtProdStock.Text = dgvInventory.CurrentRow.Cells["Stock"].Value.ToString();
            }
        }
        #endregion

        #region --- ORDER MANAGEMENT ---
        private void LoadOrders()
        {
            string dbConnectionString = "Data Source=watson_shop.db;Version=3;";
            // Pull real database column structures, matching your DataGridView headers via SQL Aliases
            string selectQuery = "SELECT OrderId AS Tracking, Username AS [Customer Name], Status, Date FROM Orders ORDER BY OrderId DESC;";

            try
            {
                using (var connection = new SQLiteConnection(dbConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(selectQuery, connection))
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvOrders.DataSource = null;
                        dgvOrders.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Admin Error reading orders: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            string dbConnectionString = "Data Source=watson_shop.db;Version=3;";
            try
            {
                // Pull tracking ID from the actively selected row
                string trackingId = dgvOrders.CurrentRow.Cells["Tracking"].Value.ToString();
                string query = "SELECT Username, Items, Status FROM Orders WHERE OrderId = @OrderId;";

                using (var connection = new SQLiteConnection(dbConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", trackingId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string customer = reader["Username"].ToString();
                                string items = reader["Items"].ToString();
                                string status = reader["Status"].ToString();

                                // Fill the layout UI text box inputs directly
                                txtOrderDetails.Text = $"Customer Account: {customer}\r\nTracking ID: {trackingId}\r\n\r\nItems Ordered:\r\n{items}";
                                cmbOrderStatus.Text = status;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null || string.IsNullOrEmpty(cmbOrderStatus.Text)) return;

            string dbConnectionString = "Data Source=watson_shop.db;Version=3;";
            string trackingToUpdate = dgvOrders.CurrentRow.Cells["Tracking"].Value.ToString();
            string newStatus = cmbOrderStatus.Text;

            string updateQuery = "UPDATE Orders SET Status = @Status WHERE OrderId = @OrderId;";

            try
            {
                using (var connection = new SQLiteConnection(dbConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@OrderId", trackingToUpdate);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Order Status Updated Successfully in Database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload table contents from SQLite
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update order status: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region --- PROFILE SETTINGS ---
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            // Match by the logged-in username
            var admin = usersList.FirstOrDefault(u => u.Username.Equals(loggedInUsername, StringComparison.OrdinalIgnoreCase));
            if (admin != null)
            {
                admin.FullName = txtProfName.Text;
                admin.Password = txtProfPass.Text;
                SaveUsersFile();
                LoadUsers();
                MessageBox.Show("Profile updated successfully!");
            }
        }
        #endregion

        #region --- DATA MODELS ---
        public class User
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public string Role { get; set; }
            public string BanExpiration { get; set; }
            public string Status { get; set; }
        }

        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        public class Order
        {
            public string Tracking { get; set; }
            public string Date { get; set; }
            public string Status { get; set; }
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public string Details { get; set; }
        }
        #endregion

        private void lblDashTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grpInvControls_Enter(object sender, EventArgs e)
        {

        }
    }
}