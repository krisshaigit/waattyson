namespace adminstaffff
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnUserMgmt = new System.Windows.Forms.Button();
            this.btnComplaints = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.lblTotalUsersTitle = new System.Windows.Forms.Label();
            this.lblTotalUsersVal = new System.Windows.Forms.Label();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.lblTotalComplaintsTitle = new System.Windows.Forms.Label();
            this.lblTotalComplaintsVal = new System.Windows.Forms.Label();
            this.panelUserMgmt = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpenAdd = new System.Windows.Forms.Button();
            this.btnOpenEdit = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnBanUser = new System.Windows.Forms.Button();
            this.numBanHours = new System.Windows.Forms.NumericUpDown();
            this.lblBanHrs = new System.Windows.Forms.Label();
            this.grpAddUser = new System.Windows.Forms.GroupBox();
            this.lblAddU = new System.Windows.Forms.Label();
            this.lblAddP = new System.Windows.Forms.Label();
            this.lblAddF = new System.Windows.Forms.Label();
            this.txtAddUsername = new System.Windows.Forms.TextBox();
            this.txtAddPassword = new System.Windows.Forms.TextBox();
            this.txtAddFullName = new System.Windows.Forms.TextBox();
            this.cmbAddRole = new System.Windows.Forms.ComboBox();
            this.btnConfirmAdd = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.grpEditUser = new System.Windows.Forms.GroupBox();
            this.lblEditU = new System.Windows.Forms.Label();
            this.lblEditP = new System.Windows.Forms.Label();
            this.lblEditR = new System.Windows.Forms.Label();
            this.lblEditS = new System.Windows.Forms.Label();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.cmbEditRole = new System.Windows.Forms.ComboBox();
            this.cmbEditStatus = new System.Windows.Forms.ComboBox();
            this.btnConfirmEdit = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.panelComplaints = new System.Windows.Forms.Panel();
            this.dgvComplaints = new System.Windows.Forms.DataGridView();
            this.colCmpUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmpMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmpStat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCmpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshComplaints = new System.Windows.Forms.Button();
            this.btnResolveComplaint = new System.Windows.Forms.Button();
            this.btnDeleteComplaint = new System.Windows.Forms.Button();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP3 = new System.Windows.Forms.Label();
            this.lblP4 = new System.Windows.Forms.Label();
            this.txtProfUsername = new System.Windows.Forms.TextBox();
            this.txtProfFullName = new System.Windows.Forms.TextBox();
            this.txtProfRole = new System.Windows.Forms.TextBox();
            this.txtProfPassword = new System.Windows.Forms.TextBox();
            this.btnSaveProfile = new System.Windows.Forms.Button();

            this.panelSidebar.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.panelUserMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBanHours)).BeginInit();
            this.grpAddUser.SuspendLayout();
            this.grpEditUser.SuspendLayout();
            this.panelComplaints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).BeginInit();
            this.panelProfile.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelSidebar (Dark Slate Grey Theme)
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnUserMgmt);
            this.panelSidebar.Controls.Add(this.btnComplaints);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Size = new System.Drawing.Size(220, 650);

            // lblLogo
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(12, 20);
            this.lblLogo.Size = new System.Drawing.Size(196, 40);
            this.lblLogo.Text = "ADMIN SUITE";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnDashboard
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.Size = new System.Drawing.Size(220, 50);
            this.btnDashboard.Location = new System.Drawing.Point(0, 100);
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);

            // btnUserMgmt
            this.btnUserMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserMgmt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUserMgmt.ForeColor = System.Drawing.Color.White;
            this.btnUserMgmt.FlatAppearance.BorderSize = 0;
            this.btnUserMgmt.Size = new System.Drawing.Size(220, 50);
            this.btnUserMgmt.Location = new System.Drawing.Point(0, 155);
            this.btnUserMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserMgmt.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUserMgmt.Text = "User Management";
            this.btnUserMgmt.Click += new System.EventHandler(this.btnUserMgmt_Click);

            // btnComplaints
            this.btnComplaints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplaints.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComplaints.ForeColor = System.Drawing.Color.White;
            this.btnComplaints.FlatAppearance.BorderSize = 0;
            this.btnComplaints.Size = new System.Drawing.Size(220, 50);
            this.btnComplaints.Location = new System.Drawing.Point(0, 210);
            this.btnComplaints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComplaints.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnComplaints.Text = "Manage Complaints";
            this.btnComplaints.Click += new System.EventHandler(this.btnComplaints_Click);

            // btnProfile
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Size = new System.Drawing.Size(220, 50);
            this.btnProfile.Location = new System.Drawing.Point(0, 265);
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProfile.Text = "Profile Settings";
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnLogout
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Size = new System.Drawing.Size(220, 50);
            this.btnLogout.Location = new System.Drawing.Point(0, 550);
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.panelDashboard);
            this.panelMainContainer.Controls.Add(this.panelUserMgmt);
            this.panelMainContainer.Controls.Add(this.panelComplaints);
            this.panelMainContainer.Controls.Add(this.panelProfile);
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(220, 0);
            this.panelMainContainer.Size = new System.Drawing.Size(814, 650);

            // 
            // panelDashboard Page
            // 
            this.panelDashboard.BackColor = System.Drawing.Color.White;
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Controls.Add(this.lblAdminName);
            this.panelDashboard.Controls.Add(this.pnlStat1);
            this.panelDashboard.Controls.Add(this.pnlStat2);
            this.panelDashboard.Location = new System.Drawing.Point(0, 0);
            this.panelDashboard.Size = new System.Drawing.Size(814, 650);

            this.lblAdminName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAdminName.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.lblAdminName.Location = new System.Drawing.Point(30, 30);
            this.lblAdminName.Size = new System.Drawing.Size(500, 40);

            // Cards
            Color color = System.Drawing.Color.FromArgb(0, 128, 128);
            this.pnlStat1.BackColor = color;
            this.pnlStat1.Controls.Add(this.lblTotalUsersTitle);
            this.pnlStat1.Controls.Add(this.lblTotalUsersVal);
            this.pnlStat1.Location = new System.Drawing.Point(35, 110);
            this.pnlStat1.Size = new System.Drawing.Size(220, 120);

            this.lblTotalUsersTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsersTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalUsersTitle.Text = "Total Registered Users";
            this.lblTotalUsersTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTotalUsersTitle.Size = new System.Drawing.Size(200, 25);

            this.lblTotalUsersVal.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsersVal.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalUsersVal.Text = "0";
            this.lblTotalUsersVal.Location = new System.Drawing.Point(10, 50);
            this.lblTotalUsersVal.Size = new System.Drawing.Size(200, 50);

            this.pnlStat2.BackColor = color;
            this.pnlStat2.Controls.Add(this.lblTotalComplaintsTitle);
            this.pnlStat2.Controls.Add(this.lblTotalComplaintsVal);
            this.pnlStat2.Location = new System.Drawing.Point(290, 110);
            this.pnlStat2.Size = new System.Drawing.Size(220, 120);

            this.lblTotalComplaintsTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalComplaintsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalComplaintsTitle.Text = "System Complaints";
            this.lblTotalComplaintsTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTotalComplaintsTitle.Size = new System.Drawing.Size(200, 25);

            this.lblTotalComplaintsVal.ForeColor = System.Drawing.Color.White;
            this.lblTotalComplaintsVal.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalComplaintsVal.Text = "0";
            this.lblTotalComplaintsVal.Location = new System.Drawing.Point(10, 50);
            this.lblTotalComplaintsVal.Size = new System.Drawing.Size(200, 50);

            // 
            // panelUserMgmt Page
            // 
            this.panelUserMgmt.BackColor = System.Drawing.Color.White;
            this.panelUserMgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserMgmt.Controls.Add(this.dgvUsers);
            this.panelUserMgmt.Controls.Add(this.btnOpenAdd);
            this.panelUserMgmt.Controls.Add(this.btnOpenEdit);
            this.panelUserMgmt.Controls.Add(this.btnDeleteUser);
            this.panelUserMgmt.Controls.Add(this.btnBanUser);
            this.panelUserMgmt.Controls.Add(this.numBanHours);
            this.panelUserMgmt.Controls.Add(this.lblBanHrs);
            this.panelUserMgmt.Controls.Add(this.grpAddUser);
            this.panelUserMgmt.Controls.Add(this.grpEditUser);
            this.panelUserMgmt.Location = new System.Drawing.Point(0, 0);
            this.panelUserMgmt.Size = new System.Drawing.Size(814, 650);

            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colUser, this.colRole, this.colName, this.colStatus });
            this.dgvUsers.Location = new System.Drawing.Point(25, 25);
            this.dgvUsers.Size = new System.Drawing.Size(760, 240);
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;

            this.colUser.HeaderText = "Username"; this.colUser.Width = 140;
            this.colRole.HeaderText = "Role"; this.colRole.Width = 110;
            this.colName.HeaderText = "Full Name"; this.colName.Width = 220;
            this.colStatus.HeaderText = "Status"; this.colStatus.Width = 140;

            // Management Action Buttons
            this.btnOpenAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAdd.BackColor = color;
            this.btnOpenAdd.ForeColor = System.Drawing.Color.White;
            this.btnOpenAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenAdd.Size = new System.Drawing.Size(120, 35);
            this.btnOpenAdd.Location = new System.Drawing.Point(25, 280);
            this.btnOpenAdd.Text = "Add User";
            this.btnOpenAdd.Click += new System.EventHandler(this.btnOpenAdd_Click);

            this.btnOpenEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenEdit.BackColor = color;
            this.btnOpenEdit.ForeColor = System.Drawing.Color.White;
            this.btnOpenEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenEdit.Size = new System.Drawing.Size(120, 35);
            this.btnOpenEdit.Location = new System.Drawing.Point(155, 280);
            this.btnOpenEdit.Text = "Edit User";
            this.btnOpenEdit.Click += new System.EventHandler(this.btnOpenEdit_Click);

            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteUser.Location = new System.Drawing.Point(285, 280);
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            this.btnBanUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanUser.BackColor = color;
            this.btnBanUser.ForeColor = System.Drawing.Color.White;
            this.btnBanUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBanUser.Size = new System.Drawing.Size(120, 35);
            this.btnBanUser.Location = new System.Drawing.Point(665, 280);
            this.btnBanUser.Text = "Apply Ban";
            this.btnBanUser.Click += new System.EventHandler(this.btnBanUser_Click);

            this.lblBanHrs.Text = "Hrs:";
            this.lblBanHrs.Location = new System.Drawing.Point(545, 290);
            this.lblBanHrs.Size = new System.Drawing.Size(35, 20);

            this.numBanHours.Location = new System.Drawing.Point(585, 285);
            this.numBanHours.Size = new System.Drawing.Size(70, 22);
            this.numBanHours.Maximum = new decimal(new int[] { 8760, 0, 0, 0 });
            this.numBanHours.Value = new decimal(new int[] { 24, 0, 0, 0 });

            // 
            // grpAddUser Box
            // 
            this.grpAddUser.Text = "Create System User";
            this.grpAddUser.Location = new System.Drawing.Point(25, 330);
            this.grpAddUser.Size = new System.Drawing.Size(360, 290);
            this.grpAddUser.Controls.Add(this.lblAddU);
            this.grpAddUser.Controls.Add(this.lblAddP);
            this.grpAddUser.Controls.Add(this.lblAddF);
            this.grpAddUser.Controls.Add(this.txtAddUsername);
            this.grpAddUser.Controls.Add(this.txtAddPassword);
            this.grpAddUser.Controls.Add(this.txtAddFullName);
            this.grpAddUser.Controls.Add(this.cmbAddRole);
            this.grpAddUser.Controls.Add(this.btnConfirmAdd);
            this.grpAddUser.Controls.Add(this.btnCancelAdd);

            this.lblAddU.Text = "Username:"; this.lblAddU.Location = new System.Drawing.Point(20, 25); this.lblAddU.Size = new System.Drawing.Size(100, 20);
            this.txtAddUsername.Location = new System.Drawing.Point(20, 45); this.txtAddUsername.Size = new System.Drawing.Size(310, 22);

            this.lblAddP.Text = "Password:"; this.lblAddP.Location = new System.Drawing.Point(20, 75); this.lblAddP.Size = new System.Drawing.Size(100, 20);
            this.txtAddPassword.Location = new System.Drawing.Point(20, 95); this.txtAddPassword.Size = new System.Drawing.Size(310, 22);

            this.lblAddF.Text = "Full Name:"; this.lblAddF.Location = new System.Drawing.Point(20, 125); this.lblAddF.Size = new System.Drawing.Size(100, 20);
            this.txtAddFullName.Location = new System.Drawing.Point(20, 145); this.txtAddFullName.Size = new System.Drawing.Size(310, 22);

            this.cmbAddRole.Location = new System.Drawing.Point(20, 185);
            this.cmbAddRole.Size = new System.Drawing.Size(310, 22);
            this.cmbAddRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddRole.Items.AddRange(new object[] { "Admin", "Staff", "User", "Driver" });

            this.btnConfirmAdd.Text = "Finish"; this.btnConfirmAdd.Location = new System.Drawing.Point(20, 230);
            this.btnConfirmAdd.Size = new System.Drawing.Size(140, 35);
            this.btnConfirmAdd.BackColor = color;
            this.btnConfirmAdd.ForeColor = System.Drawing.Color.White;
            this.btnConfirmAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAdd.Click += new System.EventHandler(this.btnConfirmAdd_Click);

            this.btnCancelAdd.Text = "Cancel"; this.btnCancelAdd.Location = new System.Drawing.Point(190, 230);
            this.btnCancelAdd.Size = new System.Drawing.Size(140, 35);
            this.btnCancelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);

            // 
            // grpEditUser Box
            // 
            this.grpEditUser.Text = "Modify User Account";
            this.grpEditUser.Location = new System.Drawing.Point(425, 330);
            this.grpEditUser.Size = new System.Drawing.Size(360, 290);
            this.grpEditUser.Controls.Add(this.lblEditU);
            this.grpEditUser.Controls.Add(this.lblEditP);
            this.grpEditUser.Controls.Add(this.lblEditR);
            this.grpEditUser.Controls.Add(this.lblEditS);
            this.grpEditUser.Controls.Add(this.txtEditUsername);
            this.grpEditUser.Controls.Add(this.txtEditPassword);
            this.grpEditUser.Controls.Add(this.cmbEditRole);
            this.grpEditUser.Controls.Add(this.cmbEditStatus);
            this.grpEditUser.Controls.Add(this.btnConfirmEdit);
            this.grpEditUser.Controls.Add(this.btnCancelEdit);

            this.lblEditU.Text = "Username:"; this.lblEditU.Location = new System.Drawing.Point(20, 25); this.lblEditU.Size = new System.Drawing.Size(100, 20);
            this.txtEditUsername.Location = new System.Drawing.Point(20, 45); this.txtEditUsername.Size = new System.Drawing.Size(310, 22);

            this.lblEditP.Text = "Password:"; this.lblEditP.Location = new System.Drawing.Point(20, 75); this.lblEditP.Size = new System.Drawing.Size(100, 20);
            this.txtEditPassword.Location = new System.Drawing.Point(20, 95); this.txtEditPassword.Size = new System.Drawing.Size(310, 22);

            this.lblEditR.Text = "Role:"; this.lblEditR.Location = new System.Drawing.Point(20, 125); this.lblEditR.Size = new System.Drawing.Size(100, 20);
            this.cmbEditRole.Location = new System.Drawing.Point(20, 145);
            this.cmbEditRole.Size = new System.Drawing.Size(310, 22);
            this.cmbEditRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditRole.Items.AddRange(new object[] { "Admin", "Staff", "User", "Driver" });

            this.lblEditS.Text = "Status:"; this.lblEditS.Location = new System.Drawing.Point(20, 175); this.lblEditS.Size = new System.Drawing.Size(100, 20);
            this.cmbEditStatus.Location = new System.Drawing.Point(20, 195);
            this.cmbEditStatus.Size = new System.Drawing.Size(310, 22);
            this.cmbEditStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditStatus.Items.AddRange(new object[] { "Active", "Inactive" });

            this.btnConfirmEdit.Text = "Save"; this.btnConfirmEdit.Location = new System.Drawing.Point(20, 235);
            this.btnConfirmEdit.Size = new System.Drawing.Size(140, 35);
            this.btnConfirmEdit.BackColor = color;
            this.btnConfirmEdit.ForeColor = System.Drawing.Color.White;
            this.btnConfirmEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmEdit.Click += new System.EventHandler(this.btnConfirmEdit_Click);

            this.btnCancelEdit.Text = "Cancel"; this.btnCancelEdit.Location = new System.Drawing.Point(190, 235);
            this.btnCancelEdit.Size = new System.Drawing.Size(140, 35);
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);

            // 
            // panelComplaints Page
            // 
            this.panelComplaints.BackColor = System.Drawing.Color.White;
            this.panelComplaints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelComplaints.Controls.Add(this.dgvComplaints);
            this.panelComplaints.Controls.Add(this.btnRefreshComplaints);
            this.panelComplaints.Controls.Add(this.btnResolveComplaint);
            this.panelComplaints.Controls.Add(this.btnDeleteComplaint);
            this.panelComplaints.Location = new System.Drawing.Point(0, 0);
            this.panelComplaints.Size = new System.Drawing.Size(814, 650);

            // dgvComplaints
            this.dgvComplaints.AllowUserToAddRows = false;
            this.dgvComplaints.BackgroundColor = System.Drawing.Color.White;
            this.dgvComplaints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colCmpUser, this.colCmpMsg, this.colCmpStat, this.colCmpDate });
            this.dgvComplaints.Location = new System.Drawing.Point(25, 25);
            this.dgvComplaints.Size = new System.Drawing.Size(760, 450);
            this.dgvComplaints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.colCmpUser.HeaderText = "Filer Username"; this.colCmpUser.Width = 140;
            this.colCmpMsg.HeaderText = "Complaint Message"; this.colCmpMsg.Width = 320;
            this.colCmpStat.HeaderText = "Status"; this.colCmpStat.Width = 120;
            this.colCmpDate.HeaderText = "Filing Date"; this.colCmpDate.Width = 130;

            // Complaint Actions
            this.btnRefreshComplaints.Text = "Refresh List"; this.btnRefreshComplaints.Location = new System.Drawing.Point(25, 500);
            this.btnRefreshComplaints.Size = new System.Drawing.Size(140, 40);
            this.btnRefreshComplaints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshComplaints.BackColor = color;
            this.btnRefreshComplaints.ForeColor = System.Drawing.Color.White;
            this.btnRefreshComplaints.Click += new System.EventHandler(this.btnRefreshComplaints_Click);

            this.btnResolveComplaint.Text = "Mark Resolved"; this.btnResolveComplaint.Location = new System.Drawing.Point(185, 500);
            this.btnResolveComplaint.Size = new System.Drawing.Size(140, 40);
            this.btnResolveComplaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolveComplaint.BackColor = color;
            this.btnResolveComplaint.ForeColor = System.Drawing.Color.White;
            this.btnResolveComplaint.Click += new System.EventHandler(this.btnResolveComplaint_Click);

            this.btnDeleteComplaint.Text = "Delete Log"; this.btnDeleteComplaint.Location = new System.Drawing.Point(645, 500);
            this.btnDeleteComplaint.Size = new System.Drawing.Size(140, 40);
            this.btnDeleteComplaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteComplaint.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteComplaint.ForeColor = System.Drawing.Color.White;
            this.btnDeleteComplaint.Click += new System.EventHandler(this.btnDeleteComplaint_Click);

            // 
            // panelProfile Page
            // 
            this.panelProfile.BackColor = System.Drawing.Color.White;
            this.panelProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProfile.Controls.Add(this.lblP1);
            this.panelProfile.Controls.Add(this.lblP2);
            this.panelProfile.Controls.Add(this.lblP3);
            this.panelProfile.Controls.Add(this.lblP4);
            this.panelProfile.Controls.Add(this.txtProfUsername);
            this.panelProfile.Controls.Add(this.txtProfFullName);
            this.panelProfile.Controls.Add(this.txtProfRole);
            this.panelProfile.Controls.Add(this.txtProfPassword);
            this.panelProfile.Controls.Add(this.btnSaveProfile);
            this.panelProfile.Location = new System.Drawing.Point(0, 0);
            this.panelProfile.Size = new System.Drawing.Size(814, 650);

            this.lblP1.Text = "Account Username (Static)"; this.lblP1.Location = new System.Drawing.Point(40, 40); this.lblP1.Size = new System.Drawing.Size(300, 20);
            this.txtProfUsername.Location = new System.Drawing.Point(40, 65); this.txtProfUsername.Size = new System.Drawing.Size(400, 22); this.txtProfUsername.ReadOnly = true;

            this.lblP2.Text = "Administrative Role"; this.lblP2.Location = new System.Drawing.Point(40, 115); this.lblP2.Size = new System.Drawing.Size(300, 20);
            this.txtProfRole.Location = new System.Drawing.Point(40, 140); this.txtProfRole.Size = new System.Drawing.Size(400, 22); this.txtProfRole.ReadOnly = true;

            this.lblP3.Text = "Display Full Name"; this.lblP3.Location = new System.Drawing.Point(40, 190); this.lblP3.Size = new System.Drawing.Size(300, 20);
            this.txtProfFullName.Location = new System.Drawing.Point(40, 215); this.txtProfFullName.Size = new System.Drawing.Size(400, 22);

            this.lblP4.Text = "Update Security Password"; this.lblP4.Location = new System.Drawing.Point(40, 265); this.lblP4.Size = new System.Drawing.Size(300, 20);
            this.txtProfPassword.Location = new System.Drawing.Point(40, 290); this.txtProfPassword.Size = new System.Drawing.Size(400, 22);

            this.btnSaveProfile.Text = "Save Changes"; this.btnSaveProfile.Location = new System.Drawing.Point(40, 350);
            this.btnSaveProfile.Size = new System.Drawing.Size(180, 40);
            this.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfile.BackColor = color;
            this.btnSaveProfile.ForeColor = System.Drawing.Color.White;
            this.btnSaveProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);

            // 
            // AdminForm General Form Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 650);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Management Console";
            this.Load += new System.EventHandler(this.AdminForm_Load);

            this.panelSidebar.ResumeLayout(false);
            this.panelMainContainer.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat2.ResumeLayout(false);
            this.panelUserMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBanHours)).EndInit();
            this.grpAddUser.ResumeLayout(false);
            this.grpAddUser.PerformLayout();
            this.grpEditUser.ResumeLayout(false);
            this.grpEditUser.PerformLayout();
            this.panelComplaints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).EndInit();
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUserMgmt;
        private System.Windows.Forms.Button btnComplaints;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Label lblTotalUsersTitle;
        private System.Windows.Forms.Label lblTotalUsersVal;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Label lblTotalComplaintsTitle;
        private System.Windows.Forms.Label lblTotalComplaintsVal;
        private System.Windows.Forms.Panel panelUserMgmt;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnOpenAdd;
        private System.Windows.Forms.Button btnOpenEdit;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnBanUser;
        private System.Windows.Forms.NumericUpDown numBanHours;
        private System.Windows.Forms.Label lblBanHrs;
        private System.Windows.Forms.GroupBox grpAddUser;
        private System.Windows.Forms.Label lblAddU;
        private System.Windows.Forms.Label lblAddP;
        private System.Windows.Forms.Label lblAddF;
        private System.Windows.Forms.TextBox txtAddUsername;
        private System.Windows.Forms.TextBox txtAddPassword;
        private System.Windows.Forms.TextBox txtAddFullName;
        private System.Windows.Forms.ComboBox cmbAddRole;
        private System.Windows.Forms.Button btnConfirmAdd;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.GroupBox grpEditUser;
        private System.Windows.Forms.Label lblEditU;
        private System.Windows.Forms.Label lblEditP;
        private System.Windows.Forms.Label lblEditR;
        private System.Windows.Forms.Label lblEditS;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.ComboBox cmbEditRole;
        private System.Windows.Forms.ComboBox cmbEditStatus;
        private System.Windows.Forms.Button btnConfirmEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Panel panelComplaints;
        private System.Windows.Forms.DataGridView dgvComplaints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmpUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmpMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmpStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCmpDate;
        private System.Windows.Forms.Button btnRefreshComplaints;
        private System.Windows.Forms.Button btnResolveComplaint;
        private System.Windows.Forms.Button btnDeleteComplaint;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP3;
        private System.Windows.Forms.Label lblP4;
        private System.Windows.Forms.TextBox txtProfUsername;
        private System.Windows.Forms.TextBox txtProfFullName;
        private System.Windows.Forms.TextBox txtProfRole;
        private System.Windows.Forms.TextBox txtProfPassword;
        private System.Windows.Forms.Button btnSaveProfile;
    }
}