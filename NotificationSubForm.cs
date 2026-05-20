using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class NotificationSubForm : Form
    {
        private DriverForm parent;
        private ListBox lbNotifications;

        public NotificationSubForm(DriverForm mainForm)
        {
            parent = mainForm;
            InitializeComponent();
            SetupCustomLayout();
            FetchNotifications();
        }

        private void SetupCustomLayout()
        {
            this.Size = new System.Drawing.Size(810, 650);
            this.BackColor = System.Drawing.Color.White;

            Label title = new Label { Text = "Operational Notifications Ledger Feed", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 15), Size = new Size(400, 30) };
            lbNotifications = new ListBox { Location = new Point(20, 65), Size = new Size(760, 540), Font = new Font("Segoe UI", 10) };

            this.Controls.AddRange(new Control[] { title, lbNotifications });
        }

        private void FetchNotifications()
        {
            lbNotifications.Items.Clear();
            if (!File.Exists(parent.NotificationsFile)) return;

            string[] lines = File.ReadAllLines(parent.NotificationsFile);
            if (lines.Length == 0)
            {
                lbNotifications.Items.Add("No active notification items recorded.");
                return;
            }

            foreach (var line in lines)
            {
                var p = line.Split('|');
                if (p.Length < 4) continue;
                lbNotifications.Items.Add($"[{p[2]} - {p[3]}] {p[1]}");
            }
        }
        private void NotificationSubForm_Load(object sender, EventArgs e) { }
    }
    
}