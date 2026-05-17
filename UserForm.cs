using System;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class UserForm : Form
    {
        // Parameterless ctor for Designer
        public UserForm()
        {
            InitializeComponent();
        }

        // Runtime ctor used by LoginForm to show user's full name
        public UserForm(string fullName) : this()
        {
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                lblWelcome.Text = $"Welcome, {fullName}";
            }
            lblRole.Text = "Role: User";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
