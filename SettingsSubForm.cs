using System;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class SettingsSubForm : Form
    {
        private DriverForm parent;
        private CheckBox chkAlerts;
        private Button btnApply;

        public SettingsSubForm(DriverForm mainForm)
        {
            parent = mainForm;
            InitializeComponent();
            SetupCustomLayout();
        }

        private void SetupCustomLayout()
        {
            this.Size = new System.Drawing.Size(810, 650);
            this.BackColor = System.Drawing.Color.White;

            Label title = new Label { Text = "Application Preference Control Center", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(30, 20), Size = new Size(450, 30) };

            chkAlerts = new CheckBox { Text = "Enable sound system background telemetry alerts", Checked = true, Location = new Point(35, 85), Size = new Size(400, 30), Font = new Font("Segoe UI", 10) };

            btnApply = new Button { Text = "Apply Preferences", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.Teal, ForeColor = Color.White, Location = new Point(35, 140), Size = new Size(180, 40), FlatStyle = FlatStyle.Flat };
            btnApply.Click += (s, e) => MessageBox.Show("Application operational metrics adjusted.", "Context Transferred", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Controls.AddRange(new Control[] { title, chkAlerts, btnApply });
        }
        private void SettingsSubForm_Load(object sender, EventArgs e) { }
    }
    
}