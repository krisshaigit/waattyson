namespace adminstaffff
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblLogo = new Label();
            btnDashboard = new Button();
            btnUsers = new Button();
            btnInventory = new Button();
            btnOrders = new Button();
            btnProfile = new Button();
            pnlMain = new Panel();
            pnlUsers = new Panel();
            txtUserSearch = new TextBox();
            dgvUsers = new DataGridView();
            grpUserControls = new GroupBox();
            btnAddUser = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnBanUser = new Button();
            pnlInventory = new Panel();
            panel4 = new Panel();
            txtProdSearch = new TextBox();
            dgvInventory = new DataGridView();
            grpInvControls = new GroupBox();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            pnlDashboard = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            lblDashTitle = new Label();
            lblTotalUsers = new Label();
            lblTotalProducts = new Label();
            lblTotalOrders = new Label();
            pnlOrders = new Panel();
            dgvOrders = new DataGridView();
            txtOrderDetails = new TextBox();
            grpOrderControls = new GroupBox();
            cmbOrderStatus = new ComboBox();
            btnUpdateOrder = new Button();
            pnlProfile = new Panel();
            grpProfile = new GroupBox();
            lblProf1 = new Label();
            txtProfName = new TextBox();
            lblProf2 = new Label();
            txtProfPass = new TextBox();
            btnUpdateProfile = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            cmbRole = new ComboBox();
            txtProdName = new TextBox();
            txtProdCategory = new TextBox();
            txtProdPrice = new TextBox();
            txtProdStock = new TextBox();
            pnlUserPopup = new Panel();
            panel1 = new Panel();
            lblPopupTitle = new Label();
            lblBan = new Label();
            numBanHours = new NumericUpDown();
            btnPopupUserSave = new Button();
            btnPopupUserClose = new Button();
            pnlProdPopup = new Panel();
            panel2 = new Panel();
            lblProdPopupTitle = new Label();
            btnPopupProdSave = new Button();
            btnPopupProdClose = new Button();
            pnlSidebar.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            grpUserControls.SuspendLayout();
            pnlInventory.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            grpInvControls.SuspendLayout();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            grpOrderControls.SuspendLayout();
            pnlProfile.SuspendLayout();
            grpProfile.SuspendLayout();
            pnlUserPopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBanHours).BeginInit();
            pnlProdPopup.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.DarkSlateGray;
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(btnUsers);
            pnlSidebar.Controls.Add(btnInventory);
            pnlSidebar.Controls.Add(btnOrders);
            pnlSidebar.Controls.Add(btnProfile);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 600);
            pnlSidebar.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(220, 65);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SYSTEM CONSOLE";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Teal;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(10, 80);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += NavButton_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.Teal;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUsers.ForeColor = Color.White;
            btnUsers.Location = new Point(10, 135);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(200, 45);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "  User Management";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += NavButton_Click;
            // 
            // btnInventory
            // 
            btnInventory.BackColor = Color.Teal;
            btnInventory.Cursor = Cursors.Hand;
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInventory.ForeColor = Color.White;
            btnInventory.Location = new Point(10, 190);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(200, 45);
            btnInventory.TabIndex = 3;
            btnInventory.Text = "  Inventory Management";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.UseVisualStyleBackColor = false;
            btnInventory.Click += NavButton_Click;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.Teal;
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(10, 245);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(200, 45);
            btnOrders.TabIndex = 4;
            btnOrders.Text = "  Order Management";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += NavButton_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.Teal;
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(10, 300);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(200, 45);
            btnProfile.TabIndex = 5;
            btnProfile.Text = "  Profile Settings";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += NavButton_Click;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.LightGray;
            pnlMain.Controls.Add(pnlUsers);
            pnlMain.Controls.Add(pnlInventory);
            pnlMain.Controls.Add(pnlDashboard);
            pnlMain.Controls.Add(pnlOrders);
            pnlMain.Controls.Add(pnlProfile);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(220, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(780, 600);
            pnlMain.TabIndex = 2;
            // 
            // pnlUsers
            // 
            pnlUsers.BackColor = Color.CadetBlue;
            pnlUsers.Controls.Add(txtUserSearch);
            pnlUsers.Controls.Add(dgvUsers);
            pnlUsers.Controls.Add(grpUserControls);
            pnlUsers.Dock = DockStyle.Fill;
            pnlUsers.Location = new Point(0, 0);
            pnlUsers.Name = "pnlUsers";
            pnlUsers.Size = new Size(780, 600);
            pnlUsers.TabIndex = 1;
            // 
            // txtUserSearch
            // 
            txtUserSearch.Location = new Point(72, 20);
            txtUserSearch.Name = "txtUserSearch";
            txtUserSearch.PlaceholderText = "Search Users...";
            txtUserSearch.Size = new Size(300, 27);
            txtUserSearch.TabIndex = 0;
            txtUserSearch.TextChanged += txtUserSearch_TextChanged;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.BackgroundColor = Color.LightCyan;
            dgvUsers.ColumnHeadersHeight = 29;
            dgvUsers.GridColor = Color.DarkCyan;
            dgvUsers.Location = new Point(72, 56);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(644, 437);
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // grpUserControls
            // 
            grpUserControls.BackColor = Color.Teal;
            grpUserControls.Controls.Add(btnAddUser);
            grpUserControls.Controls.Add(btnEditUser);
            grpUserControls.Controls.Add(btnDeleteUser);
            grpUserControls.Controls.Add(btnBanUser);
            grpUserControls.Location = new Point(72, 446);
            grpUserControls.Name = "grpUserControls";
            grpUserControls.Size = new Size(644, 130);
            grpUserControls.TabIndex = 2;
            grpUserControls.TabStop = false;
            grpUserControls.Text = "Manage User";
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.DarkSlateGray;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.ForeColor = SystemColors.ButtonFace;
            btnAddUser.Location = new Point(6, 80);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(142, 30);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.DarkSlateGray;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.ForeColor = SystemColors.ButtonFace;
            btnEditUser.Location = new Point(161, 80);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(139, 30);
            btnEditUser.TabIndex = 5;
            btnEditUser.Text = "Edit";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.DarkSlateGray;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.ForeColor = SystemColors.ButtonFace;
            btnDeleteUser.Location = new Point(306, 80);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(142, 30);
            btnDeleteUser.TabIndex = 6;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnBanUser
            // 
            btnBanUser.BackColor = Color.DarkSlateGray;
            btnBanUser.FlatStyle = FlatStyle.Flat;
            btnBanUser.ForeColor = SystemColors.ButtonFace;
            btnBanUser.Location = new Point(487, 80);
            btnBanUser.Name = "btnBanUser";
            btnBanUser.Size = new Size(142, 30);
            btnBanUser.TabIndex = 7;
            btnBanUser.Text = "Ban (24 hrs)";
            btnBanUser.UseVisualStyleBackColor = false;
            btnBanUser.Click += btnBanUser_Click;
            // 
            // pnlInventory
            // 
            pnlInventory.Controls.Add(panel4);
            pnlInventory.Dock = DockStyle.Fill;
            pnlInventory.Location = new Point(0, 0);
            pnlInventory.Name = "pnlInventory";
            pnlInventory.Size = new Size(780, 600);
            pnlInventory.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkCyan;
            panel4.Controls.Add(txtProdSearch);
            panel4.Controls.Add(dgvInventory);
            panel4.Controls.Add(grpInvControls);
            panel4.Location = new Point(-4, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(792, 608);
            panel4.TabIndex = 3;
            // 
            // txtProdSearch
            // 
            txtProdSearch.Location = new Point(16, 17);
            txtProdSearch.Name = "txtProdSearch";
            txtProdSearch.PlaceholderText = "Search Products...";
            txtProdSearch.Size = new Size(300, 27);
            txtProdSearch.TabIndex = 0;
            txtProdSearch.TextChanged += txtProdSearch_TextChanged;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.BackgroundColor = Color.MintCream;
            dgvInventory.ColumnHeadersHeight = 29;
            dgvInventory.GridColor = Color.LightSeaGreen;
            dgvInventory.Location = new Point(107, 53);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(565, 460);
            dgvInventory.TabIndex = 1;
            dgvInventory.RowPrePaint += dgvInventory_RowPrePaint;
            dgvInventory.SelectionChanged += dgvInventory_SelectionChanged;
            // 
            // grpInvControls
            // 
            grpInvControls.BackColor = Color.LightSeaGreen;
            grpInvControls.Controls.Add(btnAddProduct);
            grpInvControls.Controls.Add(btnEditProduct);
            grpInvControls.Controls.Add(btnDeleteProduct);
            grpInvControls.Location = new Point(107, 455);
            grpInvControls.Name = "grpInvControls";
            grpInvControls.Size = new Size(565, 130);
            grpInvControls.TabIndex = 2;
            grpInvControls.TabStop = false;
            grpInvControls.Text = "Manage Product";
            grpInvControls.Enter += grpInvControls_Enter;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.DarkSlateGray;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.ForeColor = SystemColors.ButtonHighlight;
            btnAddProduct.Location = new Point(6, 88);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(166, 30);
            btnAddProduct.TabIndex = 4;
            btnAddProduct.Text = "Add";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.BackColor = Color.DarkSlateGray;
            btnEditProduct.FlatStyle = FlatStyle.Flat;
            btnEditProduct.ForeColor = SystemColors.ButtonHighlight;
            btnEditProduct.Location = new Point(195, 88);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(166, 30);
            btnEditProduct.TabIndex = 5;
            btnEditProduct.Text = "Edit";
            btnEditProduct.UseVisualStyleBackColor = false;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = Color.DarkSlateGray;
            btnDeleteProduct.FlatStyle = FlatStyle.Flat;
            btnDeleteProduct.ForeColor = SystemColors.ButtonHighlight;
            btnDeleteProduct.Location = new Point(386, 88);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(166, 30);
            btnDeleteProduct.TabIndex = 6;
            btnDeleteProduct.Text = "Delete";
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = SystemColors.ButtonHighlight;
            pnlDashboard.Controls.Add(label1);
            pnlDashboard.Controls.Add(panel3);
            pnlDashboard.Controls.Add(pictureBox1);
            pnlDashboard.Controls.Add(lblDashTitle);
            pnlDashboard.Controls.Add(lblTotalUsers);
            pnlDashboard.Controls.Add(lblTotalProducts);
            pnlDashboard.Controls.Add(lblTotalOrders);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(780, 600);
            pnlDashboard.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.LightSeaGreen;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(20, 167);
            label1.Name = "label1";
            label1.Size = new Size(124, 32);
            label1.TabIndex = 6;
            label1.Text = "Reports:";
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CadetBlue;
            panel3.Location = new Point(0, 521);
            panel3.Name = "panel3";
            panel3.Size = new Size(785, 80);
            panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Watsons_logotype2;
            pictureBox1.Location = new Point(200, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(385, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblDashTitle
            // 
            lblDashTitle.BackColor = Color.LightSeaGreen;
            lblDashTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDashTitle.ForeColor = SystemColors.ButtonHighlight;
            lblDashTitle.Location = new Point(247, 90);
            lblDashTitle.Name = "lblDashTitle";
            lblDashTitle.Size = new Size(283, 40);
            lblDashTitle.TabIndex = 0;
            lblDashTitle.Text = "Welcome Admin";
            lblDashTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDashTitle.Click += lblDashTitle_Click;
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.BackColor = Color.Teal;
            lblTotalUsers.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalUsers.ForeColor = Color.White;
            lblTotalUsers.Location = new Point(18, 216);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(246, 155);
            lblTotalUsers.TabIndex = 1;
            lblTotalUsers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.BackColor = Color.Teal;
            lblTotalProducts.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalProducts.ForeColor = Color.White;
            lblTotalProducts.Location = new Point(270, 216);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(250, 155);
            lblTotalProducts.TabIndex = 2;
            lblTotalProducts.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.BackColor = Color.Teal;
            lblTotalOrders.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(526, 216);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(250, 155);
            lblTotalOrders.TabIndex = 3;
            lblTotalOrders.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOrders
            // 
            pnlOrders.Controls.Add(dgvOrders);
            pnlOrders.Controls.Add(txtOrderDetails);
            pnlOrders.Controls.Add(grpOrderControls);
            pnlOrders.Dock = DockStyle.Fill;
            pnlOrders.Location = new Point(0, 0);
            pnlOrders.Name = "pnlOrders";
            pnlOrders.Size = new Size(780, 600);
            pnlOrders.TabIndex = 3;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.ColumnHeadersHeight = 29;
            dgvOrders.Location = new Point(20, 20);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(500, 250);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // txtOrderDetails
            // 
            txtOrderDetails.Location = new Point(540, 20);
            txtOrderDetails.Multiline = true;
            txtOrderDetails.Name = "txtOrderDetails";
            txtOrderDetails.ReadOnly = true;
            txtOrderDetails.ScrollBars = ScrollBars.Vertical;
            txtOrderDetails.Size = new Size(230, 250);
            txtOrderDetails.TabIndex = 1;
            // 
            // grpOrderControls
            // 
            grpOrderControls.Controls.Add(cmbOrderStatus);
            grpOrderControls.Controls.Add(btnUpdateOrder);
            grpOrderControls.Location = new Point(20, 290);
            grpOrderControls.Name = "grpOrderControls";
            grpOrderControls.Size = new Size(750, 80);
            grpOrderControls.TabIndex = 2;
            grpOrderControls.TabStop = false;
            grpOrderControls.Text = "Update Order Status";
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.Items.AddRange(new object[] { "Packed", "To Receive", "Cancelled", "Completed" });
            cmbOrderStatus.Location = new Point(20, 30);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(150, 28);
            cmbOrderStatus.TabIndex = 0;
            // 
            // btnUpdateOrder
            // 
            btnUpdateOrder.Location = new Point(180, 28);
            btnUpdateOrder.Name = "btnUpdateOrder";
            btnUpdateOrder.Size = new Size(120, 30);
            btnUpdateOrder.TabIndex = 1;
            btnUpdateOrder.Text = "Update Status";
            btnUpdateOrder.Click += btnUpdateOrder_Click;
            // 
            // pnlProfile
            // 
            pnlProfile.Controls.Add(grpProfile);
            pnlProfile.Dock = DockStyle.Fill;
            pnlProfile.Location = new Point(0, 0);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(780, 600);
            pnlProfile.TabIndex = 4;
            // 
            // grpProfile
            // 
            grpProfile.Controls.Add(lblProf1);
            grpProfile.Controls.Add(txtProfName);
            grpProfile.Controls.Add(lblProf2);
            grpProfile.Controls.Add(txtProfPass);
            grpProfile.Controls.Add(btnUpdateProfile);
            grpProfile.Location = new Point(20, 20);
            grpProfile.Name = "grpProfile";
            grpProfile.Size = new Size(400, 200);
            grpProfile.TabIndex = 0;
            grpProfile.TabStop = false;
            grpProfile.Text = "Admin Profile Settings";
            // 
            // lblProf1
            // 
            lblProf1.Location = new Point(20, 40);
            lblProf1.Name = "lblProf1";
            lblProf1.Size = new Size(100, 25);
            lblProf1.TabIndex = 0;
            // 
            // txtProfName
            // 
            txtProfName.Location = new Point(130, 40);
            txtProfName.Name = "txtProfName";
            txtProfName.Size = new Size(200, 27);
            txtProfName.TabIndex = 1;
            // 
            // lblProf2
            // 
            lblProf2.Location = new Point(20, 80);
            lblProf2.Name = "lblProf2";
            lblProf2.Size = new Size(100, 25);
            lblProf2.TabIndex = 2;
            // 
            // txtProfPass
            // 
            txtProfPass.Location = new Point(130, 80);
            txtProfPass.Name = "txtProfPass";
            txtProfPass.PasswordChar = '*';
            txtProfPass.Size = new Size(200, 27);
            txtProfPass.TabIndex = 3;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.BackColor = Color.Teal;
            btnUpdateProfile.FlatStyle = FlatStyle.Flat;
            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile.Location = new Point(130, 130);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.Size = new Size(150, 35);
            btnUpdateProfile.TabIndex = 4;
            btnUpdateProfile.Text = "Save Changes";
            btnUpdateProfile.UseVisualStyleBackColor = false;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(30, 99);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(340, 27);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(30, 142);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(340, 27);
            txtPassword.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(30, 189);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Full Name";
            txtFullName.Size = new Size(340, 27);
            txtFullName.TabIndex = 2;
            // 
            // cmbRole
            // 
            cmbRole.Items.AddRange(new object[] { "Admin", "User", "Driver" });
            cmbRole.Location = new Point(500, 30);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(120, 28);
            cmbRole.TabIndex = 3;
            // 
            // txtProdName
            // 
            txtProdName.Location = new Point(20, 56);
            txtProdName.Name = "txtProdName";
            txtProdName.PlaceholderText = "Product Name";
            txtProdName.Size = new Size(371, 27);
            txtProdName.TabIndex = 0;
            // 
            // txtProdCategory
            // 
            txtProdCategory.Location = new Point(20, 106);
            txtProdCategory.Name = "txtProdCategory";
            txtProdCategory.PlaceholderText = "Category";
            txtProdCategory.Size = new Size(371, 27);
            txtProdCategory.TabIndex = 1;
            // 
            // txtProdPrice
            // 
            txtProdPrice.Location = new Point(20, 161);
            txtProdPrice.Name = "txtProdPrice";
            txtProdPrice.PlaceholderText = "Price";
            txtProdPrice.Size = new Size(371, 27);
            txtProdPrice.TabIndex = 2;
            // 
            // txtProdStock
            // 
            txtProdStock.Location = new Point(480, 30);
            txtProdStock.Name = "txtProdStock";
            txtProdStock.PlaceholderText = "Stock";
            txtProdStock.Size = new Size(100, 27);
            txtProdStock.TabIndex = 3;
            // 
            // pnlUserPopup
            // 
            pnlUserPopup.BackColor = Color.White;
            pnlUserPopup.BorderStyle = BorderStyle.FixedSingle;
            pnlUserPopup.Controls.Add(panel1);
            pnlUserPopup.Controls.Add(lblPopupTitle);
            pnlUserPopup.Controls.Add(lblBan);
            pnlUserPopup.Controls.Add(numBanHours);
            pnlUserPopup.Controls.Add(txtUsername);
            pnlUserPopup.Controls.Add(txtPassword);
            pnlUserPopup.Controls.Add(txtFullName);
            pnlUserPopup.Controls.Add(cmbRole);
            pnlUserPopup.Controls.Add(btnPopupUserSave);
            pnlUserPopup.Controls.Add(btnPopupUserClose);
            pnlUserPopup.Location = new Point(166, 140);
            pnlUserPopup.Name = "pnlUserPopup";
            pnlUserPopup.Size = new Size(400, 380);
            pnlUserPopup.TabIndex = 0;
            pnlUserPopup.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 67);
            panel1.TabIndex = 6;
            // 
            // lblPopupTitle
            // 
            lblPopupTitle.Location = new Point(-1, 0);
            lblPopupTitle.Name = "lblPopupTitle";
            lblPopupTitle.Size = new Size(300, 30);
            lblPopupTitle.TabIndex = 0;
            // 
            // lblBan
            // 
            lblBan.Location = new Point(30, 255);
            lblBan.Name = "lblBan";
            lblBan.Size = new Size(150, 20);
            lblBan.TabIndex = 1;
            // 
            // numBanHours
            // 
            numBanHours.Location = new Point(180, 253);
            numBanHours.Name = "numBanHours";
            numBanHours.Size = new Size(190, 27);
            numBanHours.TabIndex = 2;
            // 
            // btnPopupUserSave
            // 
            btnPopupUserSave.BackColor = Color.DarkSlateGray;
            btnPopupUserSave.ForeColor = SystemColors.ButtonHighlight;
            btnPopupUserSave.Location = new Point(30, 310);
            btnPopupUserSave.Name = "btnPopupUserSave";
            btnPopupUserSave.Size = new Size(160, 40);
            btnPopupUserSave.TabIndex = 4;
            btnPopupUserSave.Text = "Confirm";
            btnPopupUserSave.UseVisualStyleBackColor = false;
            btnPopupUserSave.Click += btnPopupUserSave_Click;
            // 
            // btnPopupUserClose
            // 
            btnPopupUserClose.BackColor = Color.LightSeaGreen;
            btnPopupUserClose.ForeColor = SystemColors.ButtonFace;
            btnPopupUserClose.Location = new Point(210, 310);
            btnPopupUserClose.Name = "btnPopupUserClose";
            btnPopupUserClose.Size = new Size(160, 40);
            btnPopupUserClose.TabIndex = 5;
            btnPopupUserClose.Text = "Cancel";
            btnPopupUserClose.UseVisualStyleBackColor = false;
            btnPopupUserClose.Click += btnPopupUserClose_Click;
            // 
            // pnlProdPopup
            // 
            pnlProdPopup.BackColor = Color.White;
            pnlProdPopup.BorderStyle = BorderStyle.FixedSingle;
            pnlProdPopup.Controls.Add(panel2);
            pnlProdPopup.Controls.Add(lblProdPopupTitle);
            pnlProdPopup.Controls.Add(txtProdName);
            pnlProdPopup.Controls.Add(txtProdCategory);
            pnlProdPopup.Controls.Add(txtProdPrice);
            pnlProdPopup.Controls.Add(txtProdStock);
            pnlProdPopup.Controls.Add(btnPopupProdSave);
            pnlProdPopup.Controls.Add(btnPopupProdClose);
            pnlProdPopup.Location = new Point(169, 177);
            pnlProdPopup.Name = "pnlProdPopup";
            pnlProdPopup.Size = new Size(400, 320);
            pnlProdPopup.TabIndex = 1;
            pnlProdPopup.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Teal;
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 41);
            panel2.TabIndex = 6;
            // 
            // lblProdPopupTitle
            // 
            lblProdPopupTitle.Location = new Point(20, 15);
            lblProdPopupTitle.Name = "lblProdPopupTitle";
            lblProdPopupTitle.Size = new Size(300, 30);
            lblProdPopupTitle.TabIndex = 0;
            // 
            // btnPopupProdSave
            // 
            btnPopupProdSave.BackColor = Color.DarkSlateGray;
            btnPopupProdSave.ForeColor = SystemColors.ButtonFace;
            btnPopupProdSave.Location = new Point(30, 260);
            btnPopupProdSave.Name = "btnPopupProdSave";
            btnPopupProdSave.Size = new Size(160, 40);
            btnPopupProdSave.TabIndex = 4;
            btnPopupProdSave.Text = "Confirm";
            btnPopupProdSave.UseVisualStyleBackColor = false;
            btnPopupProdSave.Click += btnPopupProdSave_Click;
            // 
            // btnPopupProdClose
            // 
            btnPopupProdClose.BackColor = Color.LightSeaGreen;
            btnPopupProdClose.ForeColor = Color.Snow;
            btnPopupProdClose.Location = new Point(210, 260);
            btnPopupProdClose.Name = "btnPopupProdClose";
            btnPopupProdClose.Size = new Size(160, 40);
            btnPopupProdClose.TabIndex = 5;
            btnPopupProdClose.Text = "Cancel";
            btnPopupProdClose.UseVisualStyleBackColor = false;
            btnPopupProdClose.Click += btnPopupProdClose_Click;
            // 
            // AdminForm
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlUserPopup);
            Controls.Add(pnlProdPopup);
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Management Console";
            Load += AdminForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlUsers.ResumeLayout(false);
            pnlUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            grpUserControls.ResumeLayout(false);
            pnlInventory.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            grpInvControls.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlOrders.ResumeLayout(false);
            pnlOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            grpOrderControls.ResumeLayout(false);
            pnlProfile.ResumeLayout(false);
            grpProfile.ResumeLayout(false);
            grpProfile.PerformLayout();
            pnlUserPopup.ResumeLayout(false);
            pnlUserPopup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBanHours).EndInit();
            pnlProdPopup.ResumeLayout(false);
            pnlProdPopup.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        // Variable Declarations
        private System.Windows.Forms.Panel pnlSidebar, pnlMain, pnlDashboard, pnlUsers, pnlInventory, pnlOrders, pnlProfile;
        private System.Windows.Forms.Button btnDashboard, btnUsers, btnInventory, btnOrders, btnProfile;
        private System.Windows.Forms.Label lblLogo, lblDashTitle, lblTotalUsers, lblTotalProducts, lblTotalOrders;

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox txtUserSearch, txtUsername, txtPassword, txtFullName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.GroupBox grpUserControls;

        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TextBox txtProdSearch, txtProdName, txtProdCategory, txtProdPrice, txtProdStock;
        private System.Windows.Forms.Button btnAddProduct, btnEditProduct, btnDeleteProduct;
        private System.Windows.Forms.GroupBox grpInvControls;

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.GroupBox grpOrderControls;
        private System.Windows.Forms.TextBox txtOrderDetails;

        private System.Windows.Forms.TextBox txtProfName, txtProfPass;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.GroupBox grpProfile;
        private System.Windows.Forms.Panel pnlUserPopup;
        private System.Windows.Forms.Panel pnlProdPopup;
        private System.Windows.Forms.NumericUpDown numBanHours;
        private System.Windows.Forms.Label lblPopupTitle;
        private System.Windows.Forms.Label lblProdPopupTitle;
        private Label lblProf1;
        private Label lblProf2;
        private Button btnBanUser;
        private Label lblBan;
        private Button btnPopupUserSave;
        private Button btnPopupUserClose;
        private Button btnPopupProdSave;
        private Button btnPopupProdClose;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
    }
}