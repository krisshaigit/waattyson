
using System;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class StaffForm : Form
    {
        public StaffForm(string staffFullName, string branchName)
        {
            InitializeComponent();
            lblName.Text = $"Staff Name: {staffFullName}";
            lblBranch.Text = $"Branch: {branchName}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}