using System;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class AdminForm : Form
    {
        public AdminForm(string fullName)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {fullName}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}