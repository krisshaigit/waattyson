namespace adminstaffff
{
    partial class DriverForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlDriverContainer;
        private System.Windows.Forms.Label lblHeaderLogo;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button btnConfirmPage;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblHeaderLogo = new System.Windows.Forms.Label();
            this.btnActive = new System.Windows.Forms.Button();
            this.btnConfirmPage = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlDriverContainer = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(0, 131, 143);
            this.pnlSidebar.Controls.Add(this.lblHeaderLogo);
            this.pnlSidebar.Controls.Add(this.btnActive);
            this.pnlSidebar.Controls.Add(this.btnConfirmPage);
            this.pnlSidebar.Controls.Add(this.btnHistory);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.btnNotifications);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(220, 650);
            // 
            // lblHeaderLogo
            // 
            this.lblHeaderLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLogo.ForeColor = System.Drawing.Color.White;
            this.lblHeaderLogo.Location = new System.Drawing.Point(10, 15);
            this.lblHeaderLogo.Size = new System.Drawing.Size(200, 45);
            this.lblHeaderLogo.Text = "watsons RIDER";
            this.lblHeaderLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActive
            // 
            this.ConfigureSidebarButton(this.btnActive, "Active Deliveries", 80);
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnConfirmPage
            // 
            this.ConfigureSidebarButton(this.btnConfirmPage, "Confirm Drop-off", 135);
            this.btnConfirmPage.Click += new System.EventHandler(this.btnConfirmPage_Click);
            // 
            // btnHistory
            // 
            this.ConfigureSidebarButton(this.btnHistory, "Delivery History", 190);
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnProfile
            // 
            this.ConfigureSidebarButton(this.btnProfile, "My Profile", 245);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnNotifications
            // 
            this.ConfigureSidebarButton(this.btnNotifications, "Notifications", 300);
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnSettings
            // 
            this.ConfigureSidebarButton(this.btnSettings, "Settings", 355);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.ConfigureSidebarButton(this.btnLogout, "Log Out", 580);
            this.btnLogout.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlDriverContainer
            // 
            this.pnlDriverContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverContainer.Location = new System.Drawing.Point(220, 0);
            this.pnlDriverContainer.Size = new System.Drawing.Size(810, 650);
            this.pnlDriverContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // DriverForm
            // 
            this.ClientSize = new System.Drawing.Size(1030, 650);
            this.Controls.Add(this.pnlDriverContainer);
            this.Controls.Add(this.pnlSidebar);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void ConfigureSidebarButton(System.Windows.Forms.Button btn, string text, int top)
        {
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = new System.Drawing.Point(10, top);
            btn.Size = new System.Drawing.Size(200, 45);
            btn.Text = text;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlSidebar.Controls.Add(btn);
        }
    }
}