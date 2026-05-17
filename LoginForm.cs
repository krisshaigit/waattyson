using adminstaffff;

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class LoginForm : Form
    {
        // Files
        private readonly string usersFile = "users.txt";
        private readonly string branchesFile = "branches.txt";

        // Access code constants (stored in code, not in files)
        private const string ADMIN_ACCESS_CODE = "ADMIN-2026";
        private const string STAFF_ACCESS_CODE = "STAFF-2026";

        public LoginForm()
        {
            InitializeComponent();
            EnsureFilesExist();
        }

        // Ensure users and branches files exist (create with sample data if missing)
        private void EnsureFilesExist()
        {
            try
            {
                if (!File.Exists(usersFile))
                {
                    var sample =
                        "admin01,admin123,Admin,Main Admin," + Environment.NewLine +
                        "staff01,staff123,Staff,John Cruz,WB-01" + Environment.NewLine +
                        "user01,user123,User,Juan Dela Cruz," + Environment.NewLine +
                        "driver01,driver123,Driver,Mark Reyes," + Environment.NewLine;
                    File.AppendAllText(usersFile, sample);
                }

                if (!File.Exists(branchesFile))
                {
                    File.AppendAllText(branchesFile, "WB-01," + Environment.NewLine); // name left empty
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring data files: " + ex.Message, "File IO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Login button handler - username + password only, then role + optional access code
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text; // do not trim password deliberately

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!File.Exists(usersFile))
                {
                    MessageBox.Show("No users file found. Please register an account first.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Find matching user line
                var lines = File.ReadAllLines(usersFile);
                string foundRole = null;
                string foundFullName = null;
                string foundExtra = null;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length < 4) continue; // require at least username,password,role,fullname

                    var fileUser = parts[0].Trim();
                    var filePass = parts[1];
                    if (!string.Equals(fileUser, username, StringComparison.OrdinalIgnoreCase)) continue;
                    if (filePass != password) continue;

                    foundRole = parts[2].Trim();
                    foundFullName = parts[3].Trim();
                    foundExtra = parts.Length > 4 ? parts[4].Trim() : string.Empty;
                    break;
                }

                if (foundRole == null)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If Admin or Staff, require access code before proceeding
                if (string.Equals(foundRole, "Admin", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(foundRole, "Staff", StringComparison.OrdinalIgnoreCase))
                {
                    var accessCode = PromptForAccessCode(foundRole);
                    if (accessCode == null) // user cancelled
                    {
                        return;
                    }

                    if (!IsAccessCodeValid(foundRole, accessCode))
                    {
                        MessageBox.Show("Incorrect access code. Login blocked.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // All checks passed — open appropriate dashboard (uses existing forms if present)
                switch (foundRole)
                {
                    case "Admin":
                        OpenFormByName("adminstaffff.AdminForm", new object[] { foundFullName });
                        break;

                    case "Staff":
                        var branchName = LookupBranchName(foundExtra) ?? foundExtra;
                        OpenFormByName("adminstaffff.StaffForm", new object[] { foundFullName, branchName });
                        break;

                    case "User":
                        if (!OpenFormByName("adminstaffff.UserForm", new object[] { foundFullName }))
                        {
                            MessageBox.Show($"Welcome, {foundFullName} (Role: User).", "Logged In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Driver":
                        if (!OpenFormByName("adminstaffff.DriverForm", new object[] { foundFullName }))
                        {
                            MessageBox.Show($"Welcome, {foundFullName} (Role: Driver).", "Logged In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    default:
                        MessageBox.Show($"Unknown role '{foundRole}'. Contact administrator.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Prompt the user for access code in a small modal dialog; returns null if cancelled
        private string PromptForAccessCode(string role)
        {
            using (var f = new Form())
            {
                f.Text = "Access Code Required";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new System.Drawing.Size(380, 110);
                f.MaximizeBox = false;
                f.MinimizeBox = false;

                var lbl = new Label() { Left = 10, Top = 10, Width = 360, Text = $"Enter access code for {role}:" };
                var txt = new TextBox() { Left = 10, Top = 35, Width = 360 };
                var btnOk = new Button() { Text = "OK", Left = 200, Width = 80, Top = 65, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "Cancel", Left = 290, Width = 80, Top = 65, DialogResult = DialogResult.Cancel };

                f.Controls.Add(lbl);
                f.Controls.Add(txt);
                f.Controls.Add(btnOk);
                f.Controls.Add(btnCancel);
                f.AcceptButton = btnOk;
                f.CancelButton = btnCancel;

                var result = f.ShowDialog(this);
                if (result != DialogResult.OK) return null;
                return txt.Text.Trim();
            }
        }

        // Validate given access code against constants
        private bool IsAccessCodeValid(string role, string code)
        {
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, ADMIN_ACCESS_CODE, StringComparison.Ordinal);
            if (string.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase))
                return string.Equals(code, STAFF_ACCESS_CODE, StringComparison.Ordinal);
            return true; // Users/Drivers do not require codes
        }

        // Lookup branch name by ID from branches.txt, return null if not found
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
                    if (p.Length < 1) continue;
                    if (string.Equals(p[0].Trim(), branchId, StringComparison.OrdinalIgnoreCase))
                        return p.Length > 1 ? p[1].Trim() : branchId;
                }
            }
            catch { /* ignore */ }
            return null;
        }

        // Try to open a Form by full type name via reflection. Returns true if shown.
        private bool OpenFormByName(string typeFullName, object[] ctorArgs)
        {
            try
            {
                var t = Type.GetType(typeFullName);
                if (t == null) return false;
                var ctorTypes = (ctorArgs ?? Array.Empty<object>()).Select(a => a?.GetType() ?? typeof(object)).ToArray();
                var ctor = t.GetConstructor(ctorTypes) ?? t.GetConstructors().FirstOrDefault();
                var instance = ctor != null ? ctor.Invoke(ctorArgs) as Form : Activator.CreateInstance(t) as Form;
                if (instance == null) return false;

                Hide();
                instance.FormClosed += (s, args) => Show();
                instance.Show();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        // Register button on Login — open RegisterForm
        private void btnRegister_Click(object sender, EventArgs e)
        {
            using var reg = new RegisterForm();
            if (reg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Account registered successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Designer-loaded event stub (if wired)
        private void LoginForm_Load(object sender, EventArgs e) { /* no-op */ }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}