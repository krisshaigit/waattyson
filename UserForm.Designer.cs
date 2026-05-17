using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    partial class UserForm
    {
        private IContainer components = null;
        private Label lblWelcome;
        private Label lblRole;
        private Label lblInfo;
        private Button btnLogout;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
            lblInfo = new Label();
            btnLogout = new Button();

            // 
            // UserForm
            // 
            this.Text = "User Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(420, 220);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserForm";

            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(200, 20);
            lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWelcome.Text = "Welcome, [FullName]";

            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 52);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(80, 15);
            lblRole.Text = "Role: User";

            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(20, 80);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(360, 60);
            lblInfo.Text = "This is the User (Customer) dashboard.\r\nAdd user-specific features here (orders, profile, etc.).";

            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(300, 170);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 30);
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Add controls
            this.Controls.Add(lblWelcome);
            this.Controls.Add(lblRole);
            this.Controls.Add(lblInfo);
            this.Controls.Add(btnLogout);
        }

        #endregion
    }
}