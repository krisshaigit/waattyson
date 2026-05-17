
using System;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class DriverForm : Form
    {
        // Parameterless ctor for Designer
        public DriverForm()
        {
            InitializeComponent();
        }

        // Runtime ctor used by LoginForm to show driver's full name and optionally load deliveries
        public DriverForm(string fullName) : this()
        {
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                lblWelcome.Text = $"Welcome, {fullName}";
            }
            lblRole.Text = "Role: Driver";

            // Example placeholder: populate list with a sample
            lstDeliveries.Items.Clear();
            lstDeliveries.Items.Add("No assigned deliveries (sample)");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh delivery list placeholder
            lstDeliveries.Items.Clear();
            lstDeliveries.Items.Add("Refreshed: no deliveries found (sample)");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}