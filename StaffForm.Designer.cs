using System.ComponentModel;
using System.Windows.Forms;

namespace adminstaffff
{
    partial class StaffForm
    {
        private IContainer components = null;
        private Label lblName;
        private Label lblBranch;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            lblBranch = new Label();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(87, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Staff Name:";
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(20, 50);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(57, 20);
            lblBranch.TabIndex = 1;
            lblBranch.Text = "Branch:";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(20, 90);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 28);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // StaffForm
            // 
            ClientSize = new Size(420, 180);
            Controls.Add(lblName);
            Controls.Add(lblBranch);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "StaffForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}