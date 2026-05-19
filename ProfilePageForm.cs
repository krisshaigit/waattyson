using System;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class ProfilePageForm : Form
    {
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtContact;

        public ProfilePageForm()
        {
            // Set up all controls inside the constructor explicitly
            Label lblN = new Label() { Text = "Name:", Location = new Point(30, 30) };
            txtName = new TextBox() { Location = new Point(150, 25), Width = 250, Text = DataEngine.CurrentUser?.Name ?? "" };

            Label lblA = new Label() { Text = "Address:", Location = new Point(30, 80) };
            txtAddress = new TextBox() { Location = new Point(150, 75), Width = 250, Multiline = true, Height = 60, Text = DataEngine.CurrentUser?.Address ?? "" };

            Label lblC = new Label() { Text = "Contact Number:", Location = new Point(30, 160) };
            txtContact = new TextBox() { Location = new Point(150, 155), Width = 250, Text = DataEngine.CurrentUser?.ContactNumber ?? "" };

            Button btnUpdate = new Button() { Text = "Save Changes", Location = new Point(150, 230), Size = new Size(120, 35), BackColor = Color.FromArgb(0, 161, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnUpdate.Click += UpdateProfile;

            this.Controls.AddRange(new Control[] { lblN, txtName, lblA, txtAddress, lblC, txtContact, btnUpdate });
        }

        private void UpdateProfile(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataEngine.CurrentUser != null)
            {
                DataEngine.CurrentUser.Name = txtName.Text;
                DataEngine.CurrentUser.Address = txtAddress.Text;
                DataEngine.CurrentUser.ContactNumber = txtContact.Text;

                DataEngine.SaveUsers();
                MessageBox.Show("Profile successfully updated!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}