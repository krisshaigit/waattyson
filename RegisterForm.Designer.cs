using adminstaffff;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace adminstaffff
{
    partial class RegisterForm
    {
        private IContainer components = null;

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblBranchId;
        private TextBox txtBranchId;
        private Label lblAccessCode;
        private TextBox txtAccessCode;
        private Button btnRegister;
        private Button btnCancel;

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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblBranchId = new Label();
            txtBranchId = new TextBox();
            lblAccessCode = new Label();
            txtAccessCode = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            ((ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = SystemColors.ButtonHighlight;
            lblUsername.Location = new Point(18, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(138, 46);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(475, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = SystemColors.ButtonHighlight;
            lblPassword.Location = new Point(18, 86);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(138, 82);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(475, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.ForeColor = SystemColors.ButtonHighlight;
            lblRole.Location = new Point(18, 122);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(39, 20);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "User", "Driver" });
            cmbRole.Location = new Point(138, 118);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(475, 28);
            cmbRole.TabIndex = 5;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.ForeColor = SystemColors.ButtonHighlight;
            lblFullName.Location = new Point(18, 158);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 6;
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(138, 154);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(475, 27);
            txtFullName.TabIndex = 7;
            // 
            // lblBranchId
            // 
            lblBranchId.AutoSize = true;
            lblBranchId.ForeColor = SystemColors.ButtonHighlight;
            lblBranchId.Location = new Point(18, 194);
            lblBranchId.Name = "lblBranchId";
            lblBranchId.Size = new Size(73, 20);
            lblBranchId.TabIndex = 8;
            lblBranchId.Text = "Branch ID";
            // 
            // txtBranchId
            // 
            txtBranchId.Location = new Point(138, 190);
            txtBranchId.Name = "txtBranchId";
            txtBranchId.Size = new Size(160, 27);
            txtBranchId.TabIndex = 9;
            txtBranchId.TextChanged += txtBranchId_TextChanged;
            // 
            // lblAccessCode
            // 
            lblAccessCode.AutoSize = true;
            lblAccessCode.ForeColor = SystemColors.ButtonHighlight;
            lblAccessCode.Location = new Point(473, 211);
            lblAccessCode.Name = "lblAccessCode";
            lblAccessCode.Size = new Size(92, 20);
            lblAccessCode.TabIndex = 10;
            lblAccessCode.Text = "Access Code";
            // 
            // txtAccessCode
            // 
            txtAccessCode.Location = new Point(473, 233);
            txtAccessCode.Name = "txtAccessCode";
            txtAccessCode.Size = new Size(140, 27);
            txtAccessCode.TabIndex = 11;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.DarkSlateGray;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = SystemColors.ButtonHighlight;
            btnRegister.Location = new Point(218, 292);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(110, 32);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkSlateGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(378, 292);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 32);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Watsons_logotype1;
            pictureBox2.Location = new Point(115, -31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(450, 175);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(lblFullName);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(lblBranchId);
            panel1.Controls.Add(txtBranchId);
            panel1.Controls.Add(lblAccessCode);
            panel1.Controls.Add(txtAccessCode);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(btnCancel);
            panel1.Location = new Point(-1, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 390);
            panel1.TabIndex = 15;
            // 
            // RegisterForm
            // 
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(671, 495);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register";
            Load += RegisterForm_Load;
            ((ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox2;
        private Panel panel1;
    }
}