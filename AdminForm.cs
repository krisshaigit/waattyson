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
        private List<UserItem> usersList = new List<UserItem>();
        private List<ComplaintItem> complaintsList = new List<ComplaintItem>();
        private UserItem selectedUserForEdit = null;

        // Constructor accepting the logged-in admin's username
        public AdminForm(string adminUsername)
        {
            InitializeComponent();
            this.currentAdminUsername = adminUsername;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Ensure data stores are initialized
            InitializeFileSystem();

            // Load all database entities
            LoadUsers();
            LoadComplaints();

            // Setup display UI grids
            RefreshUserGrid();
            RefreshComplaintGrid();

            // Populate profile data view
            LoadAdminProfileData();

            // Initialize visual states
            ShowPanel(panelDashboard);
            grpAddUser.Visible = false;
            grpEditUser.Visible = false;

            // Update simple dashboard state counters
            UpdateDashboardStats();
        }

        #region FILE HANDLING (HELPER METHODS)

        private void InitializeFileSystem()
        {
            try
            {
                if (!File.Exists("users.txt"))
                {
                    // Create base default admin if file is missing entirely
                    File.WriteAllLines("users.txt", new string[] { "1|admin01|Admin123!|Main Admin|Admin||Active" });
                }
                if (!File.Exists("complaints.txt"))
                {
                    File.WriteAllLines("complaints.txt", new string[] { "user01,Delivery was late,Pending,2026-05-17" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing file paths: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error writing user data: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComplaints()
        {
            complaintsList.Clear();
            if (!File.Exists("complaints.txt")) return;

            string[] lines = File.ReadAllLines("complaints.txt");
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    complaintsList.Add(new ComplaintItem
                    {
                        Username = parts[0],
                        Message = parts[1],
                        Status = parts[2],
                        Date = parts[3]
                    });
                }
            }
        }

        private void SaveComplaints()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var c in complaintsList)
                {
                    lines.Add($"{c.Username},{c.Message},{c.Status},{c.Date}");
                }
                File.WriteAllLines("complaints.txt", lines.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing complaint records: {ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region VALIDATION & METRIC UTILITIES

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

        private void RefreshComplaintGrid()
        {
            dgvComplaints.Rows.Clear();
            foreach (var c in complaintsList)
            {
                dgvComplaints.Rows.Add(c.Username, c.Message, c.Status, c.Date);
            }
        }

        private void UpdateDashboardStats()
        {
            lblTotalUsersVal.Text = usersList.Count.ToString();
            lblTotalComplaintsVal.Text = complaintsList.Count.ToString();
            lblAdminName.Text = $"Welcome, {currentAdminUsername}!";
        }

        private void LoadAdminProfileData()
        {
            UserItem admin = usersList.Find(u => u.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase));
            if (admin != null)
            {
                txtProfUsername.Text = admin.Username;
                txtProfFullName.Text = admin.FullName;
                txtProfRole.Text = admin.Role;
                txtProfPassword.Text = admin.Password;
            }
        }

        #endregion

        #region SIDEBAR NAVIGATION SYSTEM

        private void ShowPanel(Panel targetPanel)
        {
            panelDashboard.Visible = false;
            panelUserMgmt.Visible = false;
            panelComplaints.Visible = false;
            panelProfile.Visible = false;

            targetPanel.Visible = true;
            UpdateDashboardStats();
        }

        private void btnDashboard_Click(object sender, EventArgs e) => ShowPanel(panelDashboard);
        private void btnUserMgmt_Click(object sender, EventArgs e) => ShowPanel(panelUserMgmt);
        private void btnComplaints_Click(object sender, EventArgs e) => ShowPanel(panelComplaints);
        private void btnProfile_Click(object sender, EventArgs e) => ShowPanel(panelProfile);

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close(); // Closes the form and returns processing context to the caller
            }
        }

        #endregion

        #region USER MANAGEMENT CONTROL LOGIC

        private void btnOpenAdd_Click(object sender, EventArgs e)
        {
            grpEditUser.Visible = false;
            grpAddUser.Visible = true;

            // Clear inputs
            txtAddUsername.Clear();
            txtAddPassword.Clear();
            txtAddFullName.Clear();
            cmbAddRole.SelectedIndex = 2; // Default to User
        }

        private void btnConfirmAdd_Click(object sender, EventArgs e)
        {
            string username = txtAddUsername.Text.Trim();
            string password = txtAddPassword.Text.Trim();
            string fullname = txtAddFullName.Text.Trim();
            string role = cmbAddRole.SelectedItem?.ToString() ?? "User";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullname))
            {
                MessageBox.Show("All input fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check duplicate validation rule
            if (usersList.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Username already exists.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password complex metric assessment
            if (!ValidatePassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long, containing uppercase, lowercase, and numeric characters.", "Security Rule Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate structural internal ID integer bound
            int maxId = 0;
            foreach (var u in usersList)
            {
                if (int.TryParse(u.Id, out int id) && id > maxId) maxId = id;
            }

            UserItem newUser = new UserItem
            {
                Id = (maxId + 1).ToString(),
                Username = username,
                Password = password,
                FullName = fullname,
                Role = role,
                Extra = "",
                Status = "Active"
            };

            usersList.Add(newUser);
            SaveUsers();
            RefreshUserGrid();
            grpAddUser.Visible = false;
            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user from the list view first.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            if (selectedUserForEdit == null) return;

            string newUsername = txtEditUsername.Text.Trim();
            string newPassword = txtEditPassword.Text.Trim();
            string newRole = cmbEditRole.SelectedItem?.ToString();
            string newStatus = cmbEditStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Username and Password fields cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Duplicate identifier checks
            if (!newUsername.Equals(selectedUserForEdit.Username, StringComparison.OrdinalIgnoreCase) &&
                usersList.Exists(u => u.Username.Equals(newUsername, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Username is already taken by another account.", "Conflict Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password metric check
            if (!ValidatePassword(newPassword))
            {
                MessageBox.Show("Password must be 8+ characters with uppercase, lowercase, and a number.", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Rule constraint: Self deactivation check
            if (selectedUserForEdit.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase) && !newStatus.Equals("Active", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot deactivate or ban the currently logged-in Admin account.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Mutate and persist entity modifications
            selectedUserForEdit.Username = newUsername;
            selectedUserForEdit.Password = newPassword;
            selectedUserForEdit.Role = newRole;
            selectedUserForEdit.Status = newStatus;

            SaveUsers();
            RefreshUserGrid();
            grpEditUser.Visible = false;
            selectedUserForEdit = null;
            MessageBox.Show("Account modifications stored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Select a user to execute destruction sequence.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetUsername = dgvUsers.CurrentRow.Cells[0].Value?.ToString();

            // Rule constraint: Prevent deleting self
            if (targetUsername.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Action denied. You cannot delete your own active session account.", "Access Control Violation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            UserItem targetUser = usersList.Find(u => u.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase));
            if (targetUser != null)
            {
                // Rule constraint: Prevent deleting the last admin
                if (targetUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    int adminCount = usersList.FindAll(u => u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)).Count;
                    if (adminCount <= 1)
                    {
                        MessageBox.Show("System safety constraint: Cannot delete the last remaining Admin account.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DialogResult dr = MessageBox.Show($"Are you sure you want to permanently delete {targetUsername}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    usersList.Remove(targetUser);
                    SaveUsers();
                    RefreshUserGrid();
                }
            }
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Select an account profile to apply a restriction lock.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetUsername = dgvUsers.CurrentRow.Cells[0].Value?.ToString();

            if (targetUsername.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot place access execution bans on your own profile.", "Operation Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            UserItem targetUser = usersList.Find(u => u.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase));
            if (targetUser != null)
            {
                int hours = (int)numBanHours.Value;
                targetUser.Status = $"Banned ({hours} Hours)";
                SaveUsers();
                RefreshUserGrid();
                MessageBox.Show($"User configuration modified to restricted state for {hours} hours.", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelAdd_Click(object sender, EventArgs e) => grpAddUser.Visible = false;
        private void btnCancelEdit_Click(object sender, EventArgs e) => grpEditUser.Visible = false;

        #endregion

        #region COMPLAINT SYSTEM PROCESSORS

        private void btnRefreshComplaints_Click(object sender, EventArgs e)
        {
            LoadComplaints();
            RefreshComplaintGrid();
        }

        private void btnResolveComplaint_Click(object sender, EventArgs e)
        {
            if (dgvComplaints.CurrentRow == null) return;
            int index = dgvComplaints.CurrentRow.Index;

            if (index >= 0 && index < complaintsList.Count)
            {
                complaintsList[index].Status = "Resolved";
                SaveComplaints();
                RefreshComplaintGrid();
            }
        }

        private void btnDeleteComplaint_Click(object sender, EventArgs e)
        {
            if (dgvComplaints.CurrentRow == null) return;
            int index = dgvComplaints.CurrentRow.Index;

            if (index >= 0 && index < complaintsList.Count)
            {
                complaintsList.RemoveAt(index);
                SaveComplaints();
                RefreshComplaintGrid();
            }
        }

        #endregion

        #region PROFILE SETTINGS PROCESSORS

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string newName = txtProfFullName.Text.Trim();
            string newPass = txtProfPassword.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Profile name data fields and access keys cannot be empty.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidatePassword(newPass))
            {
                MessageBox.Show("Password structural criteria evaluation failed. Minimum length must be 8+ characters including uppercase, lowercase, and numbers.", "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserItem admin = usersList.Find(u => u.Username.Equals(currentAdminUsername, StringComparison.OrdinalIgnoreCase));
            if (admin != null)
            {
                admin.FullName = newName;
                admin.Password = newPass;
                SaveUsers();
                MessageBox.Show("Admin configuration matrix updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }

    #region STRUCTURAL MODEL SCHEMAS

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

    public class ComplaintItem
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }

    #endregion
}