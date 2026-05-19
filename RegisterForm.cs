using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class RegisterForm : Form
    {
        private readonly string usersFile = "users.txt";
        private const string ADMIN_ACCESS_CODE = "ADMIN-2026";

        public RegisterForm()
        {
            InitializeComponent();

            // Ensure roles in dropdown: Cleaned to eliminate Staff options completely
            if (cmbRole.Items.Count == 0)
                cmbRole.Items.AddRange(new object[] { "Admin", "User", "Driver" });

            // Default selection shifts securely to "User" index
            cmbRole.SelectedIndex = cmbRole.SelectedIndex >= 0 ? cmbRole.SelectedIndex : 1;
            UpdateFieldsForRole();
        }

        // Designer-loaded stub
        private void RegisterForm_Load(object sender, EventArgs e) { /* no-op */ }

        // Show/hide fields according to selected role
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldsForRole();
        }

        // Show access code inputs exclusively for Admin verification challenges
        private void UpdateFieldsForRole()
        {
            var role = cmbRole.SelectedItem?.ToString() ?? "User";
            bool isAdmin = string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);

            // Access code required only for newly registered Admin nodes
            lblAccessCode.Visible = txtAccessCode.Visible = isAdmin;

            // Full name visible for all valid platform roles
            lblFullName.Visible = txtFullName.Visible = true;


        }

        // Register button: apply validations, access code checks, save to users.txt
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var role = cmbRole.SelectedItem?.ToString() ?? "User";
            var fullName = txtFullName.Text.Trim();
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

            // Role-specific validation rules
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
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
                accessCode = string.Empty;
            }

            // Password complexity checker integration
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

                var lines = File.ReadAllLines(usersFile);
                var existingUsernames = new List<string>();
                int maxId = 0;

                // Safely parse pipe-delimited database files to enforce unique identities
                foreach (var lineItem in lines)
                {
                    if (string.IsNullOrWhiteSpace(lineItem)) continue;

                    var parts = lineItem.Split('|');
                    if (parts.Length >= 2)
                    {
                        existingUsernames.Add(parts[1].Trim());
                    }
                    if (parts.Length >= 1 && int.TryParse(parts[0].Trim(), out int id))
                    {
                        if (id > maxId) maxId = id;
                    }
                }

                if (existingUsernames.Any(u => string.Equals(u, username, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Username already exists. Choose a different username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                int nextId = maxId + 1;

                // Formulate row string layout configuration alignment matches (ID|Username|Password|FullName|Role|Extra|Status)
                var registrationLine = $"{nextId}|{username}|{password}|{fullName}|{role}||Active|{Environment.NewLine}";
                File.AppendAllText(usersFile, registrationLine);

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

        private bool IsAccessCodeValid(string role, string code)
        {
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, ADMIN_ACCESS_CODE, StringComparison.Ordinal);
            return false;
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
            txtAccessCode.Clear();
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 1; // Resets cleanly back to User default
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e) { /* no-op */ }
    }
}