using System.ComponentModel;
using System.Windows.Forms;

namespace adminstaffff
{
    partial class AdminForm
    {
        private IContainer components = null;
        private Label lblWelcome;
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
            components = new Container();
            lblWelcome = new Label();
            btnLogout = new Button();

            // Form
            this.Text = "Admin Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new System.Drawing.Point(20, 20);
            lblWelcome.Text = "Welcome";

            // btnLogout
            btnLogout.Location = new System.Drawing.Point(20, 60);
            btnLogout.Size = new System.Drawing.Size(100, 28);
            btnLogout.Text = "Logout";
            btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.Controls.Add(lblWelcome);
            this.Controls.Add(btnLogout);
        }
    }
}