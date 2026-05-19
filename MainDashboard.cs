using adminstaffff;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;

        public MainDashboard(string? foundFullName)
        {
            InitializeComponent();

            try
            {
                DataEngine.InitializeDatabase();
                OpenChildForm(new BrowsePageForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard failed loading landing view: " + ex.Message, "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMainContainer.Controls.Clear();
            pnlMainContainer.Controls.Add(childForm);
            pnlMainContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnBrowse_Click(object sender, EventArgs e) => OpenChildForm(new BrowsePageForm());
        private void btnCategories_Click(object sender, EventArgs e) => OpenChildForm(new CategoriesPageForm());
        private void btnCheckout_Click(object sender, EventArgs e) => OpenChildForm(new CheckoutPageForm());
        private void btnHistory_Click(object sender, EventArgs e) => OpenChildForm(new HistoryPageForm());
        private void btnProfile_Click(object sender, EventArgs e) => OpenChildForm(new ProfilePageForm());
        private void btnSettings_Click(object sender, EventArgs e) => OpenChildForm(new SettingsPageForm());
    }
}