using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class DriverForm : Form
    {
        private Form activeSubForm = null;
        public string CurrentRiderName { get; private set; }

        // Core DB Text file variables
        public readonly string ActiveDeliveriesFile = "activeDeliveries.txt";
        public readonly string DeliveryHistoryFile = "deliveryHistory.txt";
        public readonly string NotificationsFile = "notifications.txt";
        public readonly string RidersFile = "riders.txt";

        public DriverForm(string riderName)
        {
            InitializeComponent();
            this.CurrentRiderName = riderName;
            this.Text = "Watsons Rider Logistics Hub";
            InitializeDataFiles();

            // Set default view context
            OpenSubPage(new ActiveDeliveriesSubForm(this));
        }

        private void InitializeDataFiles()
        {
            try
            {
                if (!File.Exists(ActiveDeliveriesFile) || new FileInfo(ActiveDeliveriesFile).Length == 0)
                {
                    File.WriteAllLines(ActiveDeliveriesFile, new string[] {
                        "WTS-901|Alice Guo|123 Bamboo St, Bamban|09171112222|Watsons Vitamin C 100pk, Isopropyl Alcohol 500ml|Assigned|2026-05-20|8819|",
                        "WTS-902|Juan Dela Cruz|456 Rizal Ave, Manila|09183334444|Biogesic 20 Tablets, Neozep 10 Tablets|Out For Delivery|2026-05-20|4102|"
                    });
                }
                if (!File.Exists(DeliveryHistoryFile)) File.Create(DeliveryHistoryFile).Close();
                if (!File.Exists(NotificationsFile)) File.Create(NotificationsFile).Close();
                if (!File.Exists(RidersFile) || new FileInfo(RidersFile).Length == 0)
                {
                    File.WriteAllText(RidersFile, "driver01|driver123|Mark Reyes|09198887766|789 Edsa Mand, NCR|DRV-2026-01\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialization error: " + ex.Message, "File System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenSubPage(Form subForm)
        {
            if (activeSubForm != null)
                activeSubForm.Close();

            activeSubForm = subForm;
            subForm.TopLevel = false;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;

            pnlDriverContainer.Controls.Clear();
            pnlDriverContainer.Controls.Add(subForm);
            pnlDriverContainer.Tag = subForm;
            subForm.BringToFront();
            subForm.Show();
        }

        private void btnActive_Click(object sender, EventArgs e) => OpenSubPage(new ActiveDeliveriesSubForm(this));
        private void btnConfirmPage_Click(object sender, EventArgs e) => OpenSubPage(new ConfirmationSubForm(this));
        private void btnHistory_Click(object sender, EventArgs e) => OpenSubPage(new HistorySubForm(this));
        private void btnProfile_Click(object sender, EventArgs e) => OpenSubPage(new ProfileSubForm(this));
        private void btnNotifications_Click(object sender, EventArgs e) => OpenSubPage(new NotificationSubForm(this));
        private void btnSettings_Click(object sender, EventArgs e) => OpenSubPage(new SettingsSubForm(this));
        private void btnLogout_Click(object sender, EventArgs e) => this.Close();
    }
}