using System;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;

        public MainDashboard()
        {
            InitializeComponent();
            DataEngine.InitializeDatabase();
            OpenChildForm(new BrowsePageForm());
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMainContainer.Controls.Add(childForm);
            pnlMainContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnBrowse_Click(object sender, EventArgs e) => OpenChildForm(new BrowsePageForm());

        // FIX: Removed '(this)' so it works with our updated CategoriesPageForm constructor
        private void btnCategories_Click(object sender, EventArgs e) => OpenChildForm(new CategoriesPageForm());

        private void btnCheckout_Click(object sender, EventArgs e) => OpenChildForm(new CheckoutPageForm());
        private void btnHistory_Click(object sender, EventArgs e) => OpenChildForm(new HistoryPageForm());
        private void btnProfile_Click(object sender, EventArgs e) => OpenChildForm(new ProfilePageForm());
        private void btnSettings_Click(object sender, EventArgs e) => OpenChildForm(new SettingsPageForm());
        private void btnNotifications_Click(object sender, EventArgs e) => OpenChildForm(new NotificationPageForm());
    }
}