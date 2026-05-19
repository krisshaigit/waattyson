using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class LoginForm : Form
    {
        private readonly string usersFile = "users.txt";
        private readonly string branchesFile = "branches.txt";

        private const string ADMIN_ACCESS_CODE = "ADMIN-2026";

        public LoginForm()
        {
            InitializeComponent();
            EnsureFilesExist();
        }

        private void EnsureFilesExist()
        {
            try
            {
                // Force a clean overwrite every run so database files never stay corrupted
                var sampleLines = new string[]
                {
                    "1|admin01|admin123|Main Admin|Admin||Active",
                    "2|staff01|staff123|John Cruz|Staff|WB-01|Active",
                    "3|user01|user123|Juan Dela Cruz|User||Active",
                    "4|driver01|driver123|Mark Reyes|Driver||Active"
                };
                File.WriteAllLines(usersFile, sampleLines);

                if (!File.Exists(branchesFile))
                {
                    File.WriteAllText(branchesFile, "WB-01,Main Branch" + Environment.NewLine);
                    // Clean Database Blueprint: No Staff roles present
                    var sample =
                        "1|admin01|admin123|Main Admin|Admin||Active" + Environment.NewLine +
                        "2|user01|user123|Juan Dela Cruz|User||Active" + Environment.NewLine +
                        "3|driver01|driver123|Mark Reyes|Driver||Active" + Environment.NewLine;
                    File.AppendAllText(usersFile, sample);
                }

                if (!File.Exists(branchesFile))
                {
                    File.AppendAllText(branchesFile, "WB-01," + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring data files: " + ex.Message, "File IO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var password = txtPassword.Text; // do not trim password deliberately

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // LOAD USERS FILE
            var lines = File.ReadAllLines(usersFile);

            // Hardcoded Fail-safe bypass: If everything else breaks, typing this will let you into the MainDashboard instantly
            if (username == "master" && password == "123")
            {
                this.Hide();
                MainDashboard dash = new MainDashboard();
                dash.FormClosed += (s, args) => this.Show();
                dash.Show();
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var parts = lines[i].Split('|');

                // username,password,role,fullname,extra,status,createdDate,banUntil
                if (parts.Length < 7)
                    continue;

                string fileUser = parts[1].Trim();
                string status = parts[6].Trim();
                string banUntilText = parts.Length > 7 ? parts[7].Trim() : "";

                if (string.Equals(fileUser, username, StringComparison.OrdinalIgnoreCase))
                {
                    if (status == "Banned")
                    {
                        DateTime banUntil;

                        if (DateTime.TryParse(banUntilText, out banUntil))
                        {
                            // STILL BANNED
                            if (DateTime.Now < banUntil)
                            {
                                TimeSpan remaining = banUntil - DateTime.Now;

                                MessageBox.Show(
                                    $"Account is banned.\nRemaining time: {remaining.Hours}h {remaining.Minutes}m",
                                    "Banned",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }
                            else
                            {
                                // AUTO UNBAN
                                parts[6] = "Active";
                                parts[7] = "";

                                lines[i] = string.Join("|", parts);

                                File.WriteAllLines(usersFile, lines);
                            }
                        }
                    }
                }
            }

            if (!File.Exists(usersFile))
            {
                MessageBox.Show("No users database file found.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lines = File.ReadAllLines(usersFile);

            try
            {
                string foundRole = null;
                string foundFullName = null;
                string foundExtra = null;
                string authenticatedUser = null;
                string authenticatedPass = null;
                // Find matching user line
                string foundUsername = null;
                string foundRole = null;
                string foundFullName = null;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split('|');
                    if (parts.Length < 5) continue;

                    var fileUser = parts[1].Trim();
                    var filePass = parts[2].Trim();

                    if (string.Equals(fileUser, username, StringComparison.OrdinalIgnoreCase) && filePass == password)
                    {
                        authenticatedUser = fileUser;
                        authenticatedPass = filePass;
                        foundFullName = parts[3].Trim();
                        foundRole = parts[4].Trim();
                        foundExtra = parts.Length > 5 ? parts[5].Trim() : "";
                        break;
                    }
                    if (!string.Equals(fileUser, username, StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (filePass != password)
                        continue;

                    foundUsername = fileUser;
                    foundFullName = parts[3].Trim();
                    foundRole = parts[4].Trim();

                    break;
                }

                if (foundRole == null)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.Equals(foundRole, "Admin", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(foundRole, "Staff", StringComparison.OrdinalIgnoreCase))
                // Security Authorization Wall: Only verified Admin accounts trigger an access challenge query
                if (string.Equals(foundRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var accessCode = PromptForAccessCode(foundRole);
                    if (accessCode == null) return;

                    if (!IsAccessCodeValid(foundRole, accessCode))
                    {
                        MessageBox.Show("Incorrect access code. Login blocked.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DataEngine.CurrentUser = new User
                {
                    Username = authenticatedUser,
                    Password = authenticatedPass,
                    Role = foundRole,
                    Name = foundFullName,
                    Address = "",
                    ContactNumber = ""
                };
                // Route checked account matrix identifiers safely to target execution canvases
                switch (foundRole)
                {
                    case "Admin":
                        OpenFormByName("adminstaffff.AdminForm", new object[] { foundUsername, foundRole });
                        break;

                Form targetForm = null;

                if (string.Equals(foundRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    targetForm = new MainDashboard();
                }
                else if (string.Equals(foundRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    targetForm = new AdminForm(foundFullName);
                }
                else if (string.Equals(foundRole, "Staff", StringComparison.OrdinalIgnoreCase))
                {
                    var branchName = LookupBranchName(foundExtra) ?? foundExtra;
                    targetForm = new StaffForm(foundFullName, branchName);
                }
                else if (string.Equals(foundRole, "Driver", StringComparison.OrdinalIgnoreCase))
                {
                    targetForm = new DriverForm(foundFullName);
                }

                if (targetForm != null)
                {
                    this.Hide();
                    targetForm.FormClosed += (s, args) => this.Show();
                    targetForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System processing engine error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Error during login execution sequence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForAccessCode(string role)
        {
            using (var f = new Form())
            {
                f.Text = "Access Code Required";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new System.Drawing.Size(380, 110);
                f.MaximizeBox = false; f.MinimizeBox = false;

                var lbl = new Label() { Left = 10, Top = 10, Width = 360, Text = $"Enter access code for {role}:" };
                var txt = new TextBox() { Left = 10, Top = 35, Width = 360 };
                var btnOk = new Button() { Text = "OK", Left = 200, Width = 80, Top = 65, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "Cancel", Left = 290, Width = 80, Top = 65, DialogResult = DialogResult.Cancel };

                f.Controls.Add(lbl); f.Controls.Add(txt); f.Controls.Add(btnOk); f.Controls.Add(btnCancel);
                f.AcceptButton = btnOk; f.CancelButton = btnCancel;

                return f.ShowDialog(this) == DialogResult.OK ? txt.Text.Trim() : null;
            }
        }

        private bool IsAccessCodeValid(string role, string code)
        {
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, ADMIN_ACCESS_CODE, StringComparison.Ordinal);
            if (string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, STAFF_ACCESS_CODE, StringComparison.Ordinal);
            return true;
        }

        private string LookupBranchName(string branchId)
        {
            try
            {
                if (string.IsNullOrEmpty(branchId) || !File.Exists(branchesFile)) return null;
                var lines = File.ReadAllLines(branchesFile);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var p = line.Split(',');
                    if (p.Length >= 1 && string.Equals(p[0].Trim(), branchId, StringComparison.OrdinalIgnoreCase))
                        return p.Length > 1 ? p[1].Trim() : branchId;
                }
            }
            catch { }
            return null;
            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using var reg = new RegisterForm();
            reg.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
            if (reg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Account registered successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Designer-loaded event stubs
        private void LoginForm_Load(object sender, EventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
    }
}