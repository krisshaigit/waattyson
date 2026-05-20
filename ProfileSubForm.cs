using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class ProfileSubForm : Form
    {
        private DriverForm parent;
        private TextBox txtContact, txtAddress, txtPass;
        private Label lblId, lblName, lblUser;
        private Button btnSave;

        public ProfileSubForm(DriverForm mainForm)
        {
            parent = mainForm;
            InitializeComponent();
            SetupCustomLayout();
            LoadProfileContext();
        }

        private void SetupCustomLayout()
        {
            this.Size = new System.Drawing.Size(810, 650);
            this.BackColor = System.Drawing.Color.White;

            Label title = new Label { Text = "Rider Profile Configuration Controls", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(30, 20), Size = new Size(400, 30) };

            lblId = new Label { Location = new Point(30, 80), Size = new Size(300, 25), Font = new Font("Segoe UI", 10, FontStyle.Italic) };
            lblName = new Label { Location = new Point(30, 110), Size = new Size(300, 25), Font = new Font("Segoe UI", 11, FontStyle.Bold) };
            lblUser = new Label { Location = new Point(30, 140), Size = new Size(300, 25) };

            Label lblPhone = new Label { Text = "Contact Mobile Number:", Location = new Point(30, 190), Size = new Size(150, 20) };
            txtContact = new TextBox { Location = new Point(200, 187), Size = new Size(200, 25) };

            Label lblLoc = new Label { Text = "Residential Address:", Location = new Point(30, 230), Size = new Size(150, 20) };
            txtAddress = new TextBox { Location = new Point(200, 227), Size = new Size(350, 25) };

            Label lblSecret = new Label { Text = "Update Password Link:", Location = new Point(30, 270), Size = new Size(150, 20) };
            txtPass = new TextBox { Location = new Point(200, 267), Size = new Size(200, 25), UseSystemPasswordChar = true };

            btnSave = new Button { Text = "Save Account Information Changes", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.Teal, ForeColor = Color.White, Location = new Point(200, 320), Size = new Size(280, 45), FlatStyle = FlatStyle.Flat };
            btnSave.Click += UpdateProfile_Click;

            this.Controls.AddRange(new Control[] { title, lblId, lblName, lblUser, lblPhone, txtContact, lblLoc, txtAddress, lblSecret, txtPass, btnSave });
        }

        private void LoadProfileContext()
        {
            if (!File.Exists(parent.RidersFile)) return;
            var lines = File.ReadAllLines(parent.RidersFile);
            if (lines.Length == 0) return;
            var parts = lines[0].Split('|');
            if (parts.Length < 6) return;

            lblUser.Text = "Username System Identity: " + parts[0];
            txtPass.Text = parts[1];
            lblName.Text = "Rider Employee Name: " + parts[2];
            txtContact.Text = parts[3];
            txtAddress.Text = parts[4];
            lblId.Text = "System ID Hash Code Reference: " + parts[5];
        }

        private void UpdateProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContact.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Required information fields cannot be blank.", "Validation Catch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(parent.RidersFile)) return;
            var parts = File.ReadAllLines(parent.RidersFile)[0].Split('|');

            string updateLine = $"{parts[0]}|{txtPass.Text.Trim()}|{parts[2]}|{txtContact.Text.Trim()}|{txtAddress.Text.Trim()}|{parts[5]}";
            File.WriteAllText(parent.RidersFile, updateLine + Environment.NewLine);

            MessageBox.Show("Rider profile configuration updated successfully.", "Storage Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProfileContext();
        }
        private void ProfileSubForm_Load(object sender, EventArgs e) { }
    }
    
}