using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class RegisterForm : Form
    {
        private readonly string usersFile = "users.txt";
        private readonly string branchesFile = "branches.txt";
        private const string ADMIN_ACCESS_CODE = "ADMIN-2026";
        private const string STAFF_ACCESS_CODE = "STAFF-2026";

        public RegisterForm()
        {
            InitializeComponent();

            // Ensure roles in dropdown (designer may fill them)
            if (cmbRole.Items.Count == 0)
                cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "User", "Driver" });

            cmbRole.SelectedIndex = cmbRole.SelectedIndex >= 0 ? cmbRole.SelectedIndex : 1; // default Staff
            UpdateFieldsForRole();
        }

        // Designer-loaded stub
        private void RegisterForm_Load(object sender, EventArgs e) { /* no-op */ }

        // Show/hide fields according to selected role
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldsForRole();
        }

        // Show branch ID & access code for Staff/Admin
        private void UpdateFieldsForRole()
        {
            var role = cmbRole.SelectedItem?.ToString() ?? "Staff";
            bool isStaff = string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase);
            bool isAdmin = string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);

            // Branch ID only for Staff
            lblBranchId.Visible = txtBranchId.Visible = isStaff;

            // Access code for Admin and Staff
            lblAccessCode.Visible = txtAccessCode.Visible = (isAdmin || isStaff);

            // Full name visible for all roles
            lblFullName.Visible = txtFullName.Visible = true;
        }

        // Designer text-changed stubs (if wired)
        private void txtBranchId_TextChanged(object sender, EventArgs e) { /* no-op */ }

        // Register button: apply validations, access code checks, save to users.txt
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var role = cmbRole.SelectedItem?.ToString() ?? "User";
            var fullName = txtFullName.Text.Trim();
            var branchId = txtBranchId.Text.Trim().ToUpper();
            var accessCode = txtAccessCode.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill Username, Password and Role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please enter Full Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullName.Focus();
                return;
            }

            // Role-specific validations
            if (string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(branchId))
                {
                    MessageBox.Show("Staff requires Branch ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBranchId.Focus();
                    return;
                }
                if (!branchId.StartsWith("WB-", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Branch ID must start with 'WB-'.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBranchId.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(accessCode))
                {
                    MessageBox.Show("Staff registration requires access code.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccessCode.Focus();
                    return;
                }

                if (!IsAccessCodeValid(role, accessCode))
                {
                    MessageBox.Show("Invalid staff access code. Registration blocked.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAccessCode.Clear();
                    txtAccessCode.Focus();
                    return;
                }
            }
            else if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(accessCode))
                {
                    MessageBox.Show("Admin registration requires access code.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccessCode.Focus();
                    return;
                }

                if (!IsAccessCodeValid(role, accessCode))
                {
                    MessageBox.Show("Invalid admin access code. Registration blocked.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAccessCode.Clear();
                    txtAccessCode.Focus();
                    return;
                }
            }
            else
            {
                // Users and Drivers: clear any access/branch values
                branchId = string.Empty;
                accessCode = string.Empty;
            }

            // Password policy
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters and include at least 1 uppercase, 1 lowercase and 1 number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            try
            {
                EnsureFileExists(usersFile);

                var existingUsernames = File.ReadAllLines(usersFile)
                    .Select(l => l.Split(','))
                    .Where(p => p.Length >= 1)
                    .Select(p => p[0].Trim())
                    .ToList();

                if (existingUsernames.Any(u => string.Equals(u, username, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Username already exists. Choose a different username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Save to users.txt: username,password,role,fullname,extra
                // For Staff extra = BranchID, otherwise empty
                var extra = string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase) ? branchId : string.Empty;
                var line = $"{username},{password},{role},{fullName},{extra}{Environment.NewLine}";
                File.AppendAllText(usersFile, line);

                // If staff, ensure branch recorded (branch name left empty)
                if (string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase))
                {
                    EnsureFileExists(branchesFile);
                    var branches = File.ReadAllLines(branchesFile)
                                      .Select(l => l.Split(','))
                                      .Where(p => p.Length >= 1)
                                      .Select(p => p[0].Trim())
                                      .ToList();
                    if (!branches.Any(b => string.Equals(b, branchId, StringComparison.OrdinalIgnoreCase)))
                    {
                        var bLine = $"{branchId},{Environment.NewLine}";
                        File.AppendAllText(branchesFile, bLine);
                    }
                }

                MessageBox.Show("Account Registered Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAllFields();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validate access codes for Admin/Staff (compare to constants)
        private bool IsAccessCodeValid(string role, string code)
        {
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, ADMIN_ACCESS_CODE, StringComparison.Ordinal);
            if (string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, STAFF_ACCESS_CODE, StringComparison.Ordinal);
            return true;
        }

        private bool IsValidPassword(string pw)
        {
            if (string.IsNullOrEmpty(pw) || pw.Length < 8) return false;
            if (!pw.Any(char.IsUpper)) return false;
            if (!pw.Any(char.IsLower)) return false;
            if (!pw.Any(char.IsDigit)) return false;
            return true;
        }

        private void EnsureFileExists(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }
        }

        private void ClearAllFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtBranchId.Clear();
            txtAccessCode.Clear();
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 1; // Staff default
        }

        // Cancel handler
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}