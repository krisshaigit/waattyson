using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class AdminForm : Form
    {
        // State Properties
        private string currentAdminUsername;
        private string currentAdminRole;

        private List<UserItem> usersList = new List<UserItem>();
        private List<ProductItem> productsList = new List<ProductItem>();
        private List<OrderGroupItem> ordersList = new List<OrderGroupItem>();

        private UserItem selectedUserForEdit = null;
        private ProductItem selectedProduct = null;
        private OrderGroupItem selectedOrderGroup = null;

        // Constructor accepting the logged-in admin credentials
        public AdminForm(string adminUsername, string adminRole)
        {
            InitializeComponent();
            this.currentAdminUsername = adminUsername;
            this.currentAdminRole = adminRole;

            // Populate the Add User role drop-down safely
            if (cmbAddRole.Items.Count == 0)
            {
                cmbAddRole.Items.Add("Admin");   // Index 0
                cmbAddRole.Items.Add("User");    // Index 1
                cmbAddRole.Items.Add("Driver");  // Index 2
            }

            // Populate the Edit User role drop-down safely too
            if (cmbEditRole.Items.Count == 0)
            {
                cmbEditRole.Items.Add("Admin");
                cmbEditRole.Items.Add("User");
                cmbEditRole.Items.Add("Driver");
            }

            // Populate the Edit User status drop-down safely
            if (cmbEditStatus.Items.Count == 0)
            {
                cmbEditStatus.Items.Add("Active");
                cmbEditStatus.Items.Add("Suspended");
            }
     
          
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            InitializeFileSystem();

            // Load all text databases
            LoadUsers();
            LoadProducts();
            LoadOrders();

            // Refresh presentation elements
            RefreshUserGrid();
            RefreshProductGrid("");
            RefreshInventoryGrid();
            RefreshOrderGrid();
            LoadAdminProfileData();

            // Setup default visual panel states
            ShowPanel(panelDashboard);
            grpAddUser.Visible = false;
            grpEditUser.Visible = false;

            UpdateDashboardStats();

            // Apply Role-Based Security Locks for Staff Members
            if (this.currentAdminRole.Equals("Staff", StringComparison.OrdinalIgnoreCase))
            {
                lblLogo.Text = "STAFF PORTAL";
                this.Text = "System Staff Workspace Console";

                btnDeleteUser.Visible = false;
                btnBanUser.Visible = false;
                numBanHours.Visible = false;
                lblBanHrs.Visible = false;

                // Inventory/Product staff limits can be configured here if necessary
                btnProdDelete.Visible = false;
            }
        }

        #region FILE HANDLING (HELPER ENGINE)

        private void InitializeFileSystem()
        {
            try
            {
                if (!File.Exists("users.txt"))
                {
                    File.WriteAllLines("users.txt", new string[] { "1|admin01|Admin123!|Main Admin|Admin||Active" });
                }
                if (!File.Exists("products.txt"))
                {
                    File.WriteAllLines("products.txt", new string[] {
                        "1|Laptop|Gaming Laptop RTX 4060|55000|10|Electronics|images/laptop.jpg|Available",
                        "2|Mouse|Wireless Mouse RGB|1200|25|Accessories|images/mouse.jpg|Available"
                    });
                }
                if (!File.Exists("orders.txt"))
                {
                    // Create base placeholder format template if orders are missing
                    string defaultOrder =
                        "Order|2026-05-18T12:06:55.4049536+08:00|Tracking:TRK-14DF0F2D37|Status:Pending|FirstName:Juan|LastName:Dela Cruz|Address:Philippines\n" +
                        "1x|1|Laptop|55000|pending\n" +
                        "EndOrder";
                    File.WriteAllText("orders.txt", defaultOrder);
                }

                // Ensure default local system asset path directory folder exists
                if (!Directory.Exists("images"))
                {
                    Directory.CreateDirectory("images");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing filesystem paths: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            usersList.Clear();
            if (!File.Exists("users.txt")) return;

            string[] lines = File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length >= 5)
                {
                    usersList.Add(new UserItem
                    {
                        Id = parts[0],
                        Username = parts[1],
                        Password = parts[2],
                        FullName = parts[3],
                        Role = parts[4],
                        Extra = parts.Length > 5 ? parts[5] : "",
                        Status = parts.Length > 6 ? parts[6] : "Active"
                    });
                }
            }
        }

        private void SaveUsers()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var u in usersList)
                {
                    lines.Add($"{u.Id}|{u.Username}|{u.Password}|{u.FullName}|{u.Role}|{u.Extra}|{u.Status}");
                }
                File.WriteAllLines("users.txt", lines.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing user records: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            productsList.Clear();
            if (!File.Exists("products.txt")) return;

            string[] lines = File.ReadAllLines("products.txt");
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length >= 8)
                {
                    productsList.Add(new ProductItem
                    {
                        Id = parts[0],
                        Name = parts[1],
                        Description = parts[2],
                        Price = double.TryParse(parts[3], out double pr) ? pr : 0.0,
                        Stock = int.TryParse(parts[4], out int st) ? st : 0,
                        Category = parts[5],
                        ImagePath = parts[6],
                        Availability = parts[7]
                    });
                }
            }
        }

        private void SaveProducts()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var p in productsList)
                {
                    lines.Add($"{p.Id}|{p.Name}|{p.Description}|{p.Price}|{p.Stock}|{p.Category}|{p.ImagePath}|{p.Availability}");
                }
                File.WriteAllLines("products.txt", lines.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing product catalog database: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            ordersList.Clear();
            if (!File.Exists("orders.txt")) return;

            string[] lines = File.ReadAllLines("orders.txt");
            OrderGroupItem activeGroup = null;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                if (line.StartsWith("Order|"))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 7)
                    {
                        activeGroup = new OrderGroupItem
                        {
                            Timestamp = parts[1],
                            TrackingId = parts[2].Replace("Tracking:", ""),
                            Status = parts[3].Replace("Status:", ""),
                            CustomerFirstName = parts[4].Replace("FirstName:", ""),
                            CustomerLastName = parts[5].Replace("LastName:", ""),
                            Address = parts[6].Replace("Address:", ""),
                            LineItems = new List<OrderItem>()
                        };
                    }
                }
                else if (line.Equals("EndOrder", StringComparison.OrdinalIgnoreCase))
                {
                    if (activeGroup != null)
                    {
                        ordersList.Add(activeGroup);
                        activeGroup = null;
                    }
                }
                else if (!line.StartsWith("CartAdd|") && activeGroup != null)
                {
                    string[] itemParts = line.Split('|');
                    if (itemParts.Length >= 5)
                    {
                        activeGroup.LineItems.Add(new OrderItem
                        {
                            QuantityString = itemParts[0],
                            ProductId = itemParts[1],
                            ProductName = itemParts[2],
                            PriceString = itemParts[3],
                            ItemStatus = itemParts[4]
                        });
                    }
                }
            }
        }

        private void SaveOrders()
        {
            try
            {
                List<string> output = new List<string>();
                foreach (var og in ordersList)
                {
                    output.Add($"Order|{og.Timestamp}|Tracking:{og.TrackingId}|Status:{og.Status}|FirstName:{og.CustomerFirstName}|LastName:{og.CustomerLastName}|Address:{og.Address}");
                    foreach (var li in og.LineItems)
                    {
                        output.Add($"{li.QuantityString}|{li.ProductId}|{li.ProductName}|{li.PriceString}|{li.ItemStatus}");
                    }
                    output.Add("EndOrder");
                }
                File.WriteAllLines("orders.txt", output.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing order registers: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region UTILITIES & GRID REFRESH CONTROLLERS

        public bool ValidatePassword(string password)
        {
            if (password.Length < 8) return false;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
            }
            return hasUpper && hasLower && hasDigit;
        }

        private void RefreshUserGrid()
        {
            dgvUsers.Rows.Clear();
            foreach (var u in usersList)
            {
                dgvUsers.Rows.Add(u.Username, u.Role, u.FullName, u.Status);
            }
        }

        private void RefreshProductGrid(string filterText)
        {
            dgvProducts.Rows.Clear();
            foreach (var p in productsList)
            {
                if (string.IsNullOrEmpty(filterText) || p.Name.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0 || p.Category.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    dgvProducts.Rows.Add(p.Id, p.Name, p.Category, p.Price.ToString("F2"), p.Stock, p.Availability);
                }
            }
        }

        private void RefreshInventoryGrid()
        {
            dgvInventory.Rows.Clear();
            foreach (var p in productsList)
            {
                string warning = p.Stock <= 5 ? "LOW STOCK" : "OK";
                dgvInventory.Rows.Add(p.Id, p.Name, p.Stock, p.Availability, warning);
            }
        }

        private void RefreshOrderGrid()
        {
            dgvOrders.Rows.Clear();
            foreach (var o in ordersList)
            {
                string customerName = $"{o.CustomerFirstName} {o.CustomerLastName}";
                dgvOrders.Rows.Add(o.TrackingId, o.Timestamp, customerName, o.Status);
            }
        }

        private void UpdateDashboardStats()
        {
            lblTotalUsersVal.Text = usersList.Count.ToString();
            lblAdminName.Text = $"Welcome, {currentAdminUsername} ({currentAdminRole})!";
        }

        private void LoadAdminProfileData()
        {
            UserItem admin = usersList.Find(u => u.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase));
            if (admin != null)
            {
                txtProfUsername.Text = admin.Username;
                txtProfPassword.Text = admin.Password;
                txtProfFullName.Text = admin.FullName;
                txtProfRole.Text = admin.Role;
            }
        }

        private void SetProductImage(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    picProductPreview.Image = Image.FromFile(path);
                    picInventoryPreview.Image = Image.FromFile(path);
                }
                else
                {
                    picProductPreview.Image = null;
                    picInventoryPreview.Image = null;
                }
            }
            catch
            {
                picProductPreview.Image = null;
                picInventoryPreview.Image = null;
            }
        }

        #endregion

        #region NAVIGATION SYSTEM LAYER

        private void ShowPanel(Panel targetPanel)
        {
            panelDashboard.Visible = false;
            panelUserMgmt.Visible = false;
            panelProfile.Visible = false;
            panelProductMgmt.Visible = false;
            panelInventory.Visible = false;
            panelOrders.Visible = false;

            targetPanel.Visible = true;
            UpdateDashboardStats();
        }

        private void btnDashboard_Click(object sender, EventArgs e) => ShowPanel(panelDashboard);
        private void btnUserMgmt_Click(object sender, EventArgs e) => ShowPanel(panelUserMgmt);
        private void btnProducts_Click(object sender, EventArgs e) => ShowPanel(panelProductMgmt);
        private void btnInventory_Click(object sender, EventArgs e) => ShowPanel(panelInventory);
        private void btnOrders_Click(object sender, EventArgs e) => ShowPanel(panelOrders);
        private void btnProfile_Click(object sender, EventArgs e) => ShowPanel(panelProfile);

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out of the console application context workspace session?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        #region MODULE 1: USER MANAGEMENT CONTROL LAYER

        private void btnOpenAdd_Click(object sender, EventArgs e)
        {
            grpEditUser.Visible = false;
            grpAddUser.Visible = true;
            txtAddUsername.Clear();
            txtAddPassword.Clear();
            txtAddFullName.Clear();

            // Check if the ComboBox actually has items before setting the index
            if (cmbAddRole.Items.Count > 2)
            {
                cmbAddRole.SelectedIndex = 2; // Safely sets to the 3rd item (e.g., Driver)
            }
            else if (cmbAddRole.Items.Count > 0)
            {
                cmbAddRole.SelectedIndex = 0;
            }
            else
            {

                cmbAddRole.SelectedIndex = -1;
                cmbAddRole.Items.Add("User");
                cmbAddRole.SelectedIndex = 0;
            }
        }

        private void btnConfirmAdd_Click(object sender, EventArgs e)
        {
            string username = txtAddUsername.Text.Trim();
            string password = txtAddPassword.Text.Trim();
            string fullname = txtAddFullName.Text.Trim();
            string role = cmbAddRole.SelectedItem?.ToString() ?? "User";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullname))
            {
                MessageBox.Show("All basic user context definition fields are strictly mandatory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usersList.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Account identity variant signature collision: Username already registered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePassword(password))
            {
                MessageBox.Show("Security credential threshold violation: Passwords require 8+ characters matching combined alphanumeric attributes.", "Security Threshold Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maxId = 0;
            foreach (var u in usersList)
            {
                if (int.TryParse(u.Id, out int id) && id > maxId) maxId = id;
            }

            usersList.Add(new UserItem
            {
                Id = (maxId + 1).ToString(),
                Username = username,
                Password = password,
                FullName = fullname,
                Role = role,
                Extra = "",
                Status = "Active"
            });

            SaveUsers();
            RefreshUserGrid();
            grpAddUser.Visible = false;
            MessageBox.Show("User added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Select an account register index element vector to open parameters panel.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetUsername = dgvUsers.CurrentRow.Cells[0].Value?.ToString();
            selectedUserForEdit = usersList.Find(u => u.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase));

            if (selectedUserForEdit != null)
            {
                grpAddUser.Visible = false;
                grpEditUser.Visible = true;
                txtEditUsername.Text = selectedUserForEdit.Username;
                txtEditPassword.Text = selectedUserForEdit.Password;
                cmbEditRole.SelectedItem = selectedUserForEdit.Role;
                cmbEditStatus.SelectedItem = selectedUserForEdit.Status;
            }
        }

        private void btnConfirmAdd_Click_1(object sender, EventArgs e)
        {
            if (selectedUserForEdit == null) return;

            string newUsername = txtEditUsername.Text.Trim();
            string newPassword = txtEditPassword.Text.Trim();
            string newRole = cmbEditRole.SelectedItem?.ToString();
            string newStatus = cmbEditStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Mandatory identity configuration parameters cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!newUsername.Equals(selectedUserForEdit.Username, StringComparison.OrdinalIgnoreCase) && usersList.Exists(u => u.Username.Equals(newUsername, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Collision error: Destination identifier path string signature vector already taken.", "Conflict Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePassword(newPassword))
            {
                MessageBox.Show("Security credential threshold checking violation.", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedUserForEdit.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase) && !newStatus.Equals("Active", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Self-deactivation restriction validation exception rule triggered.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            bool editingSelf = selectedUserForEdit.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase);

            selectedUserForEdit.Username = newUsername;
            selectedUserForEdit.Password = newPassword;
            selectedUserForEdit.Role = newRole;
            selectedUserForEdit.Status = newStatus;

            SaveUsers();

            if (editingSelf)
            {
                currentAdminUsername = newUsername;
                LoadAdminProfileData();
            }

            RefreshUserGrid();
            grpEditUser.Visible = false;
            selectedUserForEdit = null;
            MessageBox.Show("Account modifications stored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            string targetUsername = dgvUsers.CurrentRow.Cells[0].Value?.ToString();

            if (targetUsername.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Destruction engine operation exception: Self target deletion restricted.", "Access Control Violation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            UserItem targetUser = usersList.Find(u => u.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase));
            if (targetUser != null)
            {
                if (targetUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) && usersList.FindAll(u => u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)).Count <= 1)
                {
                    MessageBox.Show("Root master failure prevention: System requires at least one operating runtime root Admin.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Purge entry {targetUsername} data tree vectors?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    usersList.Remove(targetUser);
                    SaveUsers();
                    RefreshUserGrid();
                }
            }
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            string targetUsername = dgvUsers.CurrentRow.Cells[0].Value?.ToString();

            if (targetUsername.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Banning the currently active session operator matrix configuration is disallowed.", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            UserItem targetUser = usersList.Find(u => u.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase));
            if (targetUser != null)
            {
                targetUser.Status = $"Banned ({numBanHours.Value} Hours)";
                SaveUsers();
                RefreshUserGrid();
                MessageBox.Show("Account restriction vector stored successfully.", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelAdd_Click(object sender, EventArgs e) => grpAddUser.Visible = false;
        private void btnCancelEdit_Click(object sender, EventArgs e) => grpEditUser.Visible = false;

        #endregion

        #region MODULE 2: PRODUCT MANAGEMENT MODULE

        private void btnProdBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = Path.GetFileName(ofd.FileName);
                    string targetPath = Path.Combine("images", filename);

                    try
                    {
                        if (!File.Exists(targetPath))
                        {
                            File.Copy(ofd.FileName, targetPath, true);
                        }
                        txtProdImagePath.Text = targetPath;
                        SetProductImage(targetPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"File asset staging IO error: {ex.Message}");
                    }
                }
            }
        }

        private void btnProdAdd_Click(object sender, EventArgs e)
        {
            string name = txtProdName.Text.Trim();
            string desc = txtProdDesc.Text.Trim();
            string cat = txtProdCategory.Text.Trim();
            string img = txtProdImagePath.Text.Trim();

            if (string.IsNullOrEmpty(name) || !double.TryParse(txtProdPrice.Text, out double pr) || !int.TryParse(txtProdStock.Text, out int st))
            {
                MessageBox.Show("Product definition parameters parse mismatch error.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maxId = 0;
            foreach (var p in productsList)
            {
                if (int.TryParse(p.Id, out int id) && id > maxId) maxId = id;
            }

            productsList.Add(new ProductItem
            {
                Id = (maxId + 1).ToString(),
                Name = name,
                Description = desc,
                Price = pr,
                Stock = st,
                Category = cat,
                ImagePath = string.IsNullOrEmpty(img) ? "images/placeholder.jpg" : img,
                Availability = cmbProdStatus.SelectedItem?.ToString() ?? "Available"
            });

            SaveProducts();
            RefreshProductGrid("");
            RefreshInventoryGrid();
            ClearProductForm();
            MessageBox.Show("Catalog modifications stored successfully.");
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            string id = dgvProducts.CurrentRow.Cells[0].Value?.ToString();
            selectedProduct = productsList.Find(p => p.Id == id);

            if (selectedProduct != null)
            {
                txtProdName.Text = selectedProduct.Name;
                txtProdDesc.Text = selectedProduct.Description;
                txtProdPrice.Text = selectedProduct.Price.ToString();
                txtProdStock.Text = selectedProduct.Stock.ToString();
                txtProdCategory.Text = selectedProduct.Category;
                txtProdImagePath.Text = selectedProduct.ImagePath;
                cmbProdStatus.SelectedItem = selectedProduct.Availability;
                SetProductImage(selectedProduct.ImagePath);
            }
        }

        private void btnProdUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a catalog item element row target first.");
                return;
            }

            selectedProduct.Name = txtProdName.Text.Trim();
            selectedProduct.Description = txtProdDesc.Text.Trim();
            selectedProduct.Category = txtProdCategory.Text.Trim();
            selectedProduct.ImagePath = txtProdImagePath.Text.Trim();
            selectedProduct.Availability = cmbProdStatus.SelectedItem?.ToString() ?? "Available";

            if (double.TryParse(txtProdPrice.Text, out double pr)) selectedProduct.Price = pr;
            if (int.TryParse(txtProdStock.Text, out int st)) selectedProduct.Stock = st;

            SaveProducts();
            RefreshProductGrid("");
            RefreshInventoryGrid();
            ClearProductForm();
            MessageBox.Show("Product configurations saved.");
        }

        private void btnProdDelete_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null) return;
            if (MessageBox.Show("Purge entry?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                productsList.Remove(selectedProduct);
                SaveProducts();
                RefreshProductGrid("");
                RefreshInventoryGrid();
                ClearProductForm();
            }
        }

        private void btnProdClear_Click(object sender, EventArgs e) => ClearProductForm();

        private void ClearProductForm()
        {
            selectedProduct = null;
            txtProdName.Clear();
            txtProdDesc.Clear();
            txtProdPrice.Clear();
            txtProdStock.Clear();
            txtProdCategory.Clear();
            txtProdImagePath.Clear();
            cmbProdStatus.SelectedIndex = 0;
            picProductPreview.Image = null;
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            RefreshProductGrid(txtSearchProduct.Text.Trim());
        }

        #endregion

        #region MODULE 3: INVENTORY MANAGEMENT MODULE

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventory.CurrentRow == null) return;
            string id = dgvInventory.CurrentRow.Cells[0].Value?.ToString();
            selectedProduct = productsList.Find(p => p.Id == id);

            if (selectedProduct != null)
            {
                lblInvSelectedName.Text = "Selected: " + selectedProduct.Name;
                numInventoryStock.Value = selectedProduct.Stock;
                cmbInventoryStatus.SelectedItem = selectedProduct.Availability;
                SetProductImage(selectedProduct.ImagePath);
            }
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null) return;

            selectedProduct.Stock = (int)numInventoryStock.Value;
            selectedProduct.Availability = cmbInventoryStatus.SelectedItem?.ToString() ?? "Available";

            SaveProducts();
            RefreshProductGrid("");
            RefreshInventoryGrid();
            MessageBox.Show("Inventory control parameters recorded cleanly.");
        }

        #endregion

        #region MODULE 4: ORDER PROCESSING QUEUE LAYERS

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            string trackingId = dgvOrders.CurrentRow.Cells[0].Value?.ToString();
            selectedOrderGroup = ordersList.Find(o => o.TrackingId == trackingId);

            if (selectedOrderGroup != null)
            {
                lblOrderSelectedTrack.Text = "Order: " + selectedOrderGroup.TrackingId;
                cmbOrderStatus.SelectedItem = selectedOrderGroup.Status;

                lstOrderItemsView.Items.Clear();
                foreach (var li in selectedOrderGroup.LineItems)
                {
                    lstOrderItemsView.Items.Add($"{li.QuantityString} x {li.ProductName} [{li.PriceString}] - {li.ItemStatus}");
                }
            }
        }

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            if (selectedOrderGroup == null) return;

            string targetStatus = cmbOrderStatus.SelectedItem?.ToString();
            string oldStatus = selectedOrderGroup.Status;
            selectedOrderGroup.Status = targetStatus;

            // Automation rule tracking constraint setup
            // Deduct inventory when status updates to Preparing from Pending
            if (targetStatus.Equals("Preparing", StringComparison.OrdinalIgnoreCase) &&
                !oldStatus.Equals("Preparing", StringComparison.OrdinalIgnoreCase) &&
                !oldStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var li in selectedOrderGroup.LineItems)
                {
                    ProductItem catalogProd = productsList.Find(p => p.Id == li.ProductId || p.Name.Equals(li.ProductName, StringComparison.OrdinalIgnoreCase));
                    if (catalogProd != null)
                    {
                        // Clean numeric quantities parse extraction
                        int qty = 1;
                        string cleanQty = li.QuantityString.Replace("x", "").Replace("Qty", "").Trim();
                        if (int.TryParse(cleanQty, out int parsedQty)) qty = parsedQty;

                        catalogProd.Stock = Math.Max(0, catalogProd.Stock - qty);
                        li.ItemStatus = "preparing";
                    }
                }
                SaveProducts();
                RefreshProductGrid("");
                RefreshInventoryGrid();
            }

            // Sync specific item status logs natively if tracking individual states
            if (targetStatus.Equals("Packed", StringComparison.OrdinalIgnoreCase))
                foreach (var li in selectedOrderGroup.LineItems) li.ItemStatus = "packed";
            if (targetStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                foreach (var li in selectedOrderGroup.LineItems) li.ItemStatus = "completed";

            SaveOrders();
            RefreshOrderGrid();
            MessageBox.Show("Order processing queue status matrix recorded successfully.");
        }

        #endregion

        #region PROFILE SETTINGS PROCESSORS

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string newUsername = txtProfUsername.Text.Trim();
            string newPassword = txtProfPassword.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Profile parameter definition strings cannot be null.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidatePassword(newPassword))
            {
                MessageBox.Show("Alphanumeric complexity failure metrics exception.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserItem admin = usersList.Find(u => u.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase));
            if (admin != null)
            {
                if (!newUsername.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase) && usersList.Exists(u => u.Username.Equals(newUsername, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Collision constraint violation error.", "Conflict Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                admin.Username = newUsername;
                admin.Password = newPassword;
                SaveUsers();

                currentAdminUsername = newUsername;
                RefreshUserGrid();
                UpdateDashboardStats();

                MessageBox.Show("Profile attributes written successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

       
    }

    #region UNIFIED ENTITY DEFINITIONS DATA LAYERS

    public class UserItem
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Extra { get; set; }
        public string Status { get; set; }
    }

    public class ProductItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public string Availability { get; set; }
    }

    public class OrderGroupItem
    {
        public string Timestamp { get; set; }
        public string TrackingId { get; set; }
        public string Status { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Address { get; set; }
        public List<OrderItem> LineItems { get; set; }
    }

    public class OrderItem
    {
        public string QuantityString { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PriceString { get; set; }
        public string ItemStatus { get; set; }
    }

    #endregion
}