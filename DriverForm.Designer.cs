
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    partial class DriverForm
    {
        private IContainer components = null;
        private Label lblWelcome;
        private Label lblRole;
        private Label lblAssigned;
        private ListBox lstDeliveries;
        private Button btnRefresh;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();

            lblWelcome = new Label();
            lblRole = new Label();
            lblAssigned = new Label();
            lstDeliveries = new ListBox();
            btnRefresh = new Button();
            btnLogout = new Button();

            // 
            // DriverForm
            // 
            this.Text = "Driver Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(520, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DriverForm";

            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(20, 18);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(240, 20);
            lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWelcome.Text = "Welcome, [FullName]";

            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 48);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(90, 15);
            lblRole.Text = "Role: Driver";

            // 
            // lblAssigned
            // 
            lblAssigned.AutoSize = true;
            lblAssigned.Location = new Point(20, 78);
            lblAssigned.Name = "lblAssigned";
            lblAssigned.Size = new Size(160, 15);
            lblAssigned.Text = "Assigned Deliveries:";

            // 
            // lstDeliveries
            // 
            lstDeliveries.Location = new Point(20, 100);
            lstDeliveries.Name = "lstDeliveries";
            lstDeliveries.Size = new Size(480, 160);

            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(20, 270);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(95, 30);
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(405, 270);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 30);
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Add controls
            this.Controls.Add(lblWelcome);
            this.Controls.Add(lblRole);
            this.Controls.Add(lblAssigned);
            this.Controls.Add(lstDeliveries);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnLogout);
        }

        #endregion
    }
}