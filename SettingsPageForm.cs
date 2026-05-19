using System;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class SettingsPageForm : Form
    {
        private TextBox txtNewPassword;

        public SettingsPageForm()
        {
            Label lblP = new Label() { Text = "New Password:", Location = new System.Drawing.Point(30, 30), Width = 120 };
            txtNewPassword = new TextBox() { Location = new System.Drawing.Point(160, 25), Width = 200, PasswordChar = '●' };

            CheckBox chkNotif = new CheckBox() { Text = "Enable App Promotions & Alerts Notifications", Location = new System.Drawing.Point(30, 80), Checked = true, Width = 350 };

            Label lblLang = new Label() { Text = "App Language:", Location = new System.Drawing.Point(30, 130) };
            ComboBox cbLang = new ComboBox() { Location = new System.Drawing.Point(160, 125) };
            cbLang.Items.AddRange(new[] { "English", "Tagalog" });
            cbLang.SelectedIndex = 0;

            Button btnSavePass = new Button() { Text = "Apply Adjustments", Location = new System.Drawing.Point(160, 180), Size = new System.Drawing.Size(150, 35), BackColor = System.Drawing.Color.FromArgb(0, 161, 155), ForeColor = System.Drawing.Color.White };
            btnSavePass.Click += UpdateSettings;

            this.Controls.AddRange(new Control[] { lblP, txtNewPassword, chkNotif, lblLang, cbLang, btnSavePass });
        }

        private void UpdateSettings(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                if (txtNewPassword.Text.Length < 6) { MessageBox.Show("Password too weak!"); return; }
                DataEngine.CurrentUser.Password = txtNewPassword.Text;
                DataEngine.SaveUsers();
            }
            MessageBox.Show("Configuration modifications saved.");
        }
    }
}