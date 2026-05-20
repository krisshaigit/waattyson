using adminstaffff;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;
        private string currentUsername = "Guest"; // <-- Added to hold the username globally in the dashboard

        // UPDATED CONSTRUCTOR: Now accepts both Full Name AND Username
        public MainDashboard(string? foundFullName, string username)
        {
            InitializeComponent();

            // Save the username to use when switching between side menu forms
            this.currentUsername = !string.IsNullOrEmpty(username) ? username : "Guest";

            try
            {
                DataEngine.InitializeDatabase();

                // Open Browse page on startup with the verified username
                OpenChildForm(new BrowsePageForm(this.currentUsername));
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

        // UPDATED BUTTON CLICKS: Now safely pass down the saved username to your content forms
        private void btnBrowse_Click(object sender, EventArgs e) => OpenChildForm(new BrowsePageForm(this.currentUsername));
        private void btnCategories_Click(object sender, EventArgs e) => OpenChildForm(new CategoriesPageForm(this.currentUsername));
        private void btnCheckout_Click(object sender, EventArgs e) => OpenChildForm(new CheckoutPageForm());

        private void btnHistory_Click(object sender, EventArgs e) =>
            OpenChildForm(new HistoryPageForm(this.currentUsername)); // <-- Uses dashboard context directly now!

        private void btnProfile_Click(object sender, EventArgs e) => OpenChildForm(new ProfilePageForm());
        private void btnSettings_Click(object sender, EventArgs e) => OpenChildForm(new SettingsPageForm());
    }
}