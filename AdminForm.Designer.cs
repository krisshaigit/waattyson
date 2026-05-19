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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelSidebar = new Panel();
            lblLogo = new Label();
            btnDashboard = new Button();
            btnUserMgmt = new Button();
            btnInventory = new Button();
            btnOrders = new Button();
            btnProfile = new Button();
            btnLogout = new Button();
            btnProducts = new Button();
            panelMainContainer = new Panel();
            panelProductMgmt = new Panel();
            dgvProducts = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            txtSearchProduct = new TextBox();
            txtProdName = new TextBox();
            txtProdDesc = new TextBox();
            txtProdPrice = new TextBox();
            txtProdStock = new TextBox();
            txtProdCategory = new TextBox();
            txtProdImagePath = new TextBox();
            cmbProdStatus = new ComboBox();
            btnProdClear = new Button();
            btnProdBrowseImage = new Button();
            picProductPreview = new PictureBox();
            lblSearchLabel = new Label();
            lblN = new Label();
            lblD = new Label();
            lblP = new Label();
            lblS = new Label();
            lblC = new Label();
            lblI = new Label();
            lblSt = new Label();
            panelUserMgmt = new Panel();
            dgvUsers = new DataGridView();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
            btnOpenAdd = new Button();
            btnOpenEdit = new Button();
            btnDeleteUser = new Button();
            btnBanUser = new Button();
            numBanHours = new NumericUpDown();
            lblBanHrs = new Label();
            grpAddUser = new GroupBox();
            lblAddU = new Label();
            lblAddP = new Label();
            lblAddF = new Label();
            txtAddUsername = new TextBox();
            txtAddPassword = new TextBox();
            txtAddFullName = new TextBox();
            cmbAddRole = new ComboBox();
            btnConfirmAdd = new Button();
            btnCancelAdd = new Button();
            grpEditUser = new GroupBox();
            lblEditU = new Label();
            lblEditP = new Label();
            lblEditR = new Label();
            lblEditS = new Label();
            txtEditUsername = new TextBox();
            txtEditPassword = new TextBox();
            cmbEditRole = new ComboBox();
            cmbEditStatus = new ComboBox();
            btnConfirmEdit = new Button();
            btnCancelEdit = new Button();
            panelDashboard = new Panel();
            lblAdminName = new Label();
            pnlStat1 = new Panel();
            lblTotalUsersTitle = new Label();
            lblTotalUsersVal = new Label();
            panelInventory = new Panel();
            dgvInventory = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            numInventoryStock = new NumericUpDown();
            cmbInventoryStatus = new ComboBox();
            btnUpdateInventory = new Button();
            btnProdAdd = new Button();
            btnProdUpdate = new Button();
            btnProdDelete = new Button();
            lblInvSelectedName = new Label();
            picInventoryPreview = new PictureBox();
            lblInvStockLabel = new Label();
            lblInvAvLabel = new Label();
            panelOrders = new Panel();
            dgvOrders = new DataGridView();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            lstOrderItemsView = new ListBox();
            cmbOrderStatus = new ComboBox();
            btnUpdateOrderStatus = new Button();
            lblOrderSelectedTrack = new Label();
            lblLineItems = new Label();
            lblStatusTransition = new Label();
            panelProfile = new Panel();
            lblP1 = new Label();
            lblP2 = new Label();
            lblP3 = new Label();
            lblP4 = new Label();
            txtProfUsername = new TextBox();
            txtProfFullName = new TextBox();
            txtProfRole = new TextBox();
            txtProfPassword = new TextBox();
            btnSaveProfile = new Button();
            colUser = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            panelSidebar.SuspendLayout();
            panelMainContainer.SuspendLayout();
            panelProductMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductPreview).BeginInit();
            panelUserMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBanHours).BeginInit();
            grpAddUser.SuspendLayout();
            grpEditUser.SuspendLayout();
            panelDashboard.SuspendLayout();
            pnlStat1.SuspendLayout();
            panelInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInventoryStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picInventoryPreview).BeginInit();
            panelOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            panelProfile.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(47, 79, 79);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Controls.Add(btnUserMgmt);
            panelSidebar.Controls.Add(btnInventory);
            panelSidebar.Controls.Add(btnOrders);
            panelSidebar.Controls.Add(btnProfile);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnProducts);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 812);
            panelSidebar.TabIndex = 1;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(12, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(196, 44);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "ADMIN SUITE";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 88);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(220, 56);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnUserMgmt
            // 
            btnUserMgmt.FlatAppearance.BorderSize = 0;
            btnUserMgmt.FlatStyle = FlatStyle.Flat;
            btnUserMgmt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUserMgmt.ForeColor = Color.White;
            btnUserMgmt.Location = new Point(0, 148);
            btnUserMgmt.Margin = new Padding(3, 4, 3, 4);
            btnUserMgmt.Name = "btnUserMgmt";
            btnUserMgmt.Padding = new Padding(15, 0, 0, 0);
            btnUserMgmt.Size = new Size(220, 56);
            btnUserMgmt.TabIndex = 2;
            btnUserMgmt.Text = "User Management";
            btnUserMgmt.TextAlign = ContentAlignment.MiddleLeft;
            btnUserMgmt.Click += btnUserMgmt_Click;
            // 
            // btnInventory
            // 
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnInventory.ForeColor = Color.White;
            btnInventory.Location = new Point(0, 200);
            btnInventory.Margin = new Padding(3, 4, 3, 4);
            btnInventory.Name = "btnInventory";
            btnInventory.Padding = new Padding(15, 0, 0, 0);
            btnInventory.Size = new Size(220, 56);
            btnInventory.TabIndex = 4;
            btnInventory.Text = "Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnOrders
            // 
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(0, 253);
            btnOrders.Margin = new Padding(3, 4, 3, 4);
            btnOrders.Name = "btnOrders";
            btnOrders.Padding = new Padding(15, 0, 0, 0);
            btnOrders.Size = new Size(220, 56);
            btnOrders.TabIndex = 5;
            btnOrders.Text = "Orders";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnProfile
            // 
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(0, 312);
            btnProfile.Margin = new Padding(3, 4, 3, 4);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(15, 0, 0, 0);
            btnProfile.Size = new Size(220, 56);
            btnProfile.TabIndex = 6;
            btnProfile.Text = "Profile Settings";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 725);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(220, 56);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnProducts
            // 
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(3, 200);
            btnProducts.Margin = new Padding(3, 4, 3, 4);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(15, 0, 0, 0);
            btnProducts.Size = new Size(220, 56);
            btnProducts.TabIndex = 3;
            btnProducts.Text = "Product Management";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.Click += btnProducts_Click;
            // 
            // panelMainContainer
            // 
            panelMainContainer.Controls.Add(panelDashboard);
            panelMainContainer.Controls.Add(panelUserMgmt);
            panelMainContainer.Controls.Add(panelInventory);
            panelMainContainer.Controls.Add(panelOrders);
            panelMainContainer.Controls.Add(panelProfile);
            panelMainContainer.Dock = DockStyle.Fill;
            panelMainContainer.Location = new Point(220, 0);
            panelMainContainer.Margin = new Padding(3, 4, 3, 4);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new Size(814, 812);
            panelMainContainer.TabIndex = 0;
            // 
            // panelProductMgmt
            // 
            panelProductMgmt.BackColor = Color.White;
            panelProductMgmt.Controls.Add(dgvProducts);
            panelProductMgmt.Controls.Add(txtSearchProduct);
            panelProductMgmt.Controls.Add(txtProdName);
            panelProductMgmt.Controls.Add(txtProdDesc);
            panelProductMgmt.Controls.Add(txtProdPrice);
            panelProductMgmt.Controls.Add(txtProdStock);
            panelProductMgmt.Controls.Add(txtProdCategory);
            panelProductMgmt.Controls.Add(txtProdImagePath);
            panelProductMgmt.Controls.Add(cmbProdStatus);
            panelProductMgmt.Controls.Add(btnProdClear);
            panelProductMgmt.Controls.Add(btnProdBrowseImage);
            panelProductMgmt.Controls.Add(picProductPreview);
            panelProductMgmt.Controls.Add(lblSearchLabel);
            panelProductMgmt.Controls.Add(lblN);
            panelProductMgmt.Controls.Add(lblD);
            panelProductMgmt.Controls.Add(lblP);
            panelProductMgmt.Controls.Add(lblS);
            panelProductMgmt.Controls.Add(lblC);
            panelProductMgmt.Controls.Add(lblI);
            panelProductMgmt.Controls.Add(lblSt);
            panelProductMgmt.Dock = DockStyle.Fill;
            panelProductMgmt.Location = new Point(0, 0);
            panelProductMgmt.Margin = new Padding(3, 4, 3, 4);
            panelProductMgmt.Name = "panelProductMgmt";
            panelProductMgmt.Size = new Size(814, 812);
            panelProductMgmt.TabIndex = 2;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvProducts.Location = new Point(20, 88);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(460, 525);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(20, 31);
            txtSearchProduct.Margin = new Padding(3, 4, 3, 4);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(460, 27);
            txtSearchProduct.TabIndex = 1;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // txtProdName
            // 
            txtProdName.Location = new Point(500, 88);
            txtProdName.Margin = new Padding(3, 4, 3, 4);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(280, 27);
            txtProdName.TabIndex = 2;
            // 
            // txtProdDesc
            // 
            txtProdDesc.Location = new Point(500, 88);
            txtProdDesc.Margin = new Padding(3, 4, 3, 4);
            txtProdDesc.Name = "txtProdDesc";
            txtProdDesc.Size = new Size(280, 27);
            txtProdDesc.TabIndex = 3;
            // 
            // txtProdPrice
            // 
            txtProdPrice.Location = new Point(500, 88);
            txtProdPrice.Margin = new Padding(3, 4, 3, 4);
            txtProdPrice.Name = "txtProdPrice";
            txtProdPrice.Size = new Size(130, 27);
            txtProdPrice.TabIndex = 4;
            // 
            // txtProdStock
            // 
            txtProdStock.Location = new Point(500, 88);
            txtProdStock.Margin = new Padding(3, 4, 3, 4);
            txtProdStock.Name = "txtProdStock";
            txtProdStock.Size = new Size(130, 27);
            txtProdStock.TabIndex = 5;
            // 
            // txtProdCategory
            // 
            txtProdCategory.Location = new Point(500, 88);
            txtProdCategory.Margin = new Padding(3, 4, 3, 4);
            txtProdCategory.Name = "txtProdCategory";
            txtProdCategory.Size = new Size(280, 27);
            txtProdCategory.TabIndex = 6;
            // 
            // txtProdImagePath
            // 
            txtProdImagePath.Location = new Point(500, 88);
            txtProdImagePath.Margin = new Padding(3, 4, 3, 4);
            txtProdImagePath.Name = "txtProdImagePath";
            txtProdImagePath.Size = new Size(190, 27);
            txtProdImagePath.TabIndex = 7;
            // 
            // cmbProdStatus
            // 
            cmbProdStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdStatus.Items.AddRange(new object[] { "Available", "Unavailable" });
            cmbProdStatus.Location = new Point(500, 88);
            cmbProdStatus.Margin = new Padding(3, 4, 3, 4);
            cmbProdStatus.Name = "cmbProdStatus";
            cmbProdStatus.Size = new Size(280, 28);
            cmbProdStatus.TabIndex = 8;
            // 
            // btnProdClear
            // 
            btnProdClear.BackColor = Color.Gray;
            btnProdClear.FlatStyle = FlatStyle.Flat;
            btnProdClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProdClear.ForeColor = Color.White;
            btnProdClear.Location = new Point(415, 350);
            btnProdClear.Margin = new Padding(3, 4, 3, 4);
            btnProdClear.Name = "btnProdClear";
            btnProdClear.Size = new Size(120, 44);
            btnProdClear.TabIndex = 12;
            btnProdClear.Text = "Clear Fields";
            btnProdClear.UseVisualStyleBackColor = false;
            btnProdClear.Click += btnProdClear_Click;
            // 
            // btnProdBrowseImage
            // 
            btnProdBrowseImage.Location = new Point(500, 88);
            btnProdBrowseImage.Margin = new Padding(3, 4, 3, 4);
            btnProdBrowseImage.Name = "btnProdBrowseImage";
            btnProdBrowseImage.Size = new Size(80, 32);
            btnProdBrowseImage.TabIndex = 13;
            btnProdBrowseImage.Text = "Browse";
            btnProdBrowseImage.Click += btnProdBrowseImage_Click;
            // 
            // picProductPreview
            // 
            picProductPreview.BorderStyle = BorderStyle.FixedSingle;
            picProductPreview.Location = new Point(500, 425);
            picProductPreview.Margin = new Padding(3, 4, 3, 4);
            picProductPreview.Name = "picProductPreview";
            picProductPreview.Size = new Size(280, 187);
            picProductPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picProductPreview.TabIndex = 14;
            picProductPreview.TabStop = false;
            // 
            // lblSearchLabel
            // 
            lblSearchLabel.Location = new Point(0, 0);
            lblSearchLabel.Name = "lblSearchLabel";
            lblSearchLabel.Size = new Size(100, 29);
            lblSearchLabel.TabIndex = 15;
            // 
            // lblN
            // 
            lblN.Location = new Point(0, 0);
            lblN.Name = "lblN";
            lblN.Size = new Size(100, 29);
            lblN.TabIndex = 16;
            // 
            // lblD
            // 
            lblD.Location = new Point(0, 0);
            lblD.Name = "lblD";
            lblD.Size = new Size(100, 29);
            lblD.TabIndex = 17;
            // 
            // lblP
            // 
            lblP.Location = new Point(0, 0);
            lblP.Name = "lblP";
            lblP.Size = new Size(100, 29);
            lblP.TabIndex = 18;
            // 
            // lblS
            // 
            lblS.Location = new Point(0, 0);
            lblS.Name = "lblS";
            lblS.Size = new Size(100, 29);
            lblS.TabIndex = 19;
            // 
            // lblC
            // 
            lblC.Location = new Point(0, 0);
            lblC.Name = "lblC";
            lblC.Size = new Size(100, 29);
            lblC.TabIndex = 20;
            // 
            // lblI
            // 
            lblI.Location = new Point(0, 0);
            lblI.Name = "lblI";
            lblI.Size = new Size(100, 29);
            lblI.TabIndex = 21;
            // 
            // lblSt
            // 
            lblSt.Location = new Point(0, 0);
            lblSt.Name = "lblSt";
            lblSt.Size = new Size(100, 29);
            lblSt.TabIndex = 22;
            // 
            // panelUserMgmt
            // 
            panelUserMgmt.BackColor = Color.White;
            panelUserMgmt.Controls.Add(dgvUsers);
            panelUserMgmt.Controls.Add(btnOpenAdd);
            panelUserMgmt.Controls.Add(btnOpenEdit);
            panelUserMgmt.Controls.Add(btnDeleteUser);
            panelUserMgmt.Controls.Add(btnBanUser);
            panelUserMgmt.Controls.Add(numBanHours);
            panelUserMgmt.Controls.Add(lblBanHrs);
            panelUserMgmt.Controls.Add(grpAddUser);
            panelUserMgmt.Controls.Add(grpEditUser);
            panelUserMgmt.Dock = DockStyle.Fill;
            panelUserMgmt.Location = new Point(0, 0);
            panelUserMgmt.Margin = new Padding(3, 4, 3, 4);
            panelUserMgmt.Name = "panelUserMgmt";
            panelUserMgmt.Size = new Size(814, 812);
            panelUserMgmt.TabIndex = 1;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17, dataGridViewTextBoxColumn18, dataGridViewTextBoxColumn19 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.Location = new Point(25, 31);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(760, 300);
            dgvUsers.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.HeaderText = "Username";
            dataGridViewTextBoxColumn16.MinimumWidth = 6;
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.Width = 125;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.HeaderText = "Role";
            dataGridViewTextBoxColumn17.MinimumWidth = 6;
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.Width = 125;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.HeaderText = "Full Name";
            dataGridViewTextBoxColumn18.MinimumWidth = 6;
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            dataGridViewTextBoxColumn18.Width = 125;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewTextBoxColumn19.HeaderText = "Status";
            dataGridViewTextBoxColumn19.MinimumWidth = 6;
            dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            dataGridViewTextBoxColumn19.Width = 125;
            // 
            // btnOpenAdd
            // 
            btnOpenAdd.BackColor = Color.FromArgb(0, 128, 128);
            btnOpenAdd.FlatStyle = FlatStyle.Flat;
            btnOpenAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOpenAdd.ForeColor = Color.White;
            btnOpenAdd.Location = new Point(25, 350);
            btnOpenAdd.Margin = new Padding(3, 4, 3, 4);
            btnOpenAdd.Name = "btnOpenAdd";
            btnOpenAdd.Size = new Size(120, 44);
            btnOpenAdd.TabIndex = 1;
            btnOpenAdd.Text = "Add User";
            btnOpenAdd.UseVisualStyleBackColor = false;
            btnOpenAdd.Click += btnOpenAdd_Click;
            // 
            // btnOpenEdit
            // 
            btnOpenEdit.BackColor = Color.FromArgb(0, 128, 128);
            btnOpenEdit.FlatStyle = FlatStyle.Flat;
            btnOpenEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOpenEdit.ForeColor = Color.White;
            btnOpenEdit.Location = new Point(155, 350);
            btnOpenEdit.Margin = new Padding(3, 4, 3, 4);
            btnOpenEdit.Name = "btnOpenEdit";
            btnOpenEdit.Size = new Size(120, 44);
            btnOpenEdit.TabIndex = 2;
            btnOpenEdit.Text = "Edit User";
            btnOpenEdit.UseVisualStyleBackColor = false;
            btnOpenEdit.Click += btnOpenEdit_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.Firebrick;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(285, 350);
            btnDeleteUser.Margin = new Padding(3, 4, 3, 4);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(120, 44);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnBanUser
            // 
            btnBanUser.BackColor = Color.FromArgb(0, 128, 128);
            btnBanUser.FlatStyle = FlatStyle.Flat;
            btnBanUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBanUser.ForeColor = Color.White;
            btnBanUser.Location = new Point(665, 350);
            btnBanUser.Margin = new Padding(3, 4, 3, 4);
            btnBanUser.Name = "btnBanUser";
            btnBanUser.Size = new Size(120, 44);
            btnBanUser.TabIndex = 4;
            btnBanUser.Text = "Apply Ban";
            btnBanUser.UseVisualStyleBackColor = false;
            btnBanUser.Click += btnBanUser_Click;
            // 
            // numBanHours
            // 
            numBanHours.Location = new Point(585, 356);
            numBanHours.Margin = new Padding(3, 4, 3, 4);
            numBanHours.Maximum = new decimal(new int[] { 8760, 0, 0, 0 });
            numBanHours.Name = "numBanHours";
            numBanHours.Size = new Size(70, 27);
            numBanHours.TabIndex = 5;
            numBanHours.Value = new decimal(new int[] { 24, 0, 0, 0 });
            // 
            // lblBanHrs
            // 
            lblBanHrs.Location = new Point(545, 362);
            lblBanHrs.Name = "lblBanHrs";
            lblBanHrs.Size = new Size(35, 25);
            lblBanHrs.TabIndex = 6;
            lblBanHrs.Text = "Hrs:";
            // 
            // grpAddUser
            // 
            grpAddUser.Controls.Add(lblAddU);
            grpAddUser.Controls.Add(lblAddP);
            grpAddUser.Controls.Add(lblAddF);
            grpAddUser.Controls.Add(txtAddUsername);
            grpAddUser.Controls.Add(txtAddPassword);
            grpAddUser.Controls.Add(txtAddFullName);
            grpAddUser.Controls.Add(cmbAddRole);
            grpAddUser.Controls.Add(btnConfirmAdd);
            grpAddUser.Controls.Add(btnCancelAdd);
            grpAddUser.Location = new Point(25, 412);
            grpAddUser.Margin = new Padding(3, 4, 3, 4);
            grpAddUser.Name = "grpAddUser";
            grpAddUser.Padding = new Padding(3, 4, 3, 4);
            grpAddUser.Size = new Size(360, 362);
            grpAddUser.TabIndex = 7;
            grpAddUser.TabStop = false;
            grpAddUser.Text = "Create System User";
            // 
            // lblAddU
            // 
            lblAddU.Location = new Point(20, 31);
            lblAddU.Name = "lblAddU";
            lblAddU.Size = new Size(100, 29);
            lblAddU.TabIndex = 0;
            lblAddU.Text = "Username:";
            // 
            // lblAddP
            // 
            lblAddP.Location = new Point(20, 94);
            lblAddP.Name = "lblAddP";
            lblAddP.Size = new Size(100, 29);
            lblAddP.TabIndex = 1;
            lblAddP.Text = "Password:";
            // 
            // lblAddF
            // 
            lblAddF.Location = new Point(20, 156);
            lblAddF.Name = "lblAddF";
            lblAddF.Size = new Size(100, 29);
            lblAddF.TabIndex = 2;
            lblAddF.Text = "Full Name:";
            // 
            // txtAddUsername
            // 
            txtAddUsername.Location = new Point(20, 56);
            txtAddUsername.Margin = new Padding(3, 4, 3, 4);
            txtAddUsername.Name = "txtAddUsername";
            txtAddUsername.Size = new Size(310, 27);
            txtAddUsername.TabIndex = 3;
            // 
            // txtAddPassword
            // 
            txtAddPassword.Location = new Point(20, 119);
            txtAddPassword.Margin = new Padding(3, 4, 3, 4);
            txtAddPassword.Name = "txtAddPassword";
            txtAddPassword.Size = new Size(310, 27);
            txtAddPassword.TabIndex = 4;
            // 
            // txtAddFullName
            // 
            txtAddFullName.Location = new Point(20, 181);
            txtAddFullName.Margin = new Padding(3, 4, 3, 4);
            txtAddFullName.Name = "txtAddFullName";
            txtAddFullName.Size = new Size(310, 27);
            txtAddFullName.TabIndex = 5;
            // 
            // cmbAddRole
            // 
            cmbAddRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddRole.Location = new Point(20, 231);
            cmbAddRole.Margin = new Padding(3, 4, 3, 4);
            cmbAddRole.Name = "cmbAddRole";
            cmbAddRole.Size = new Size(310, 28);
            cmbAddRole.TabIndex = 6;
            // 
            // btnConfirmAdd
            // 
            btnConfirmAdd.BackColor = Color.FromArgb(0, 128, 128);
            btnConfirmAdd.FlatStyle = FlatStyle.Flat;
            btnConfirmAdd.ForeColor = Color.White;
            btnConfirmAdd.Location = new Point(20, 288);
            btnConfirmAdd.Margin = new Padding(3, 4, 3, 4);
            btnConfirmAdd.Name = "btnConfirmAdd";
            btnConfirmAdd.Size = new Size(140, 44);
            btnConfirmAdd.TabIndex = 7;
            btnConfirmAdd.Text = "Save User";
            btnConfirmAdd.UseVisualStyleBackColor = false;
            btnConfirmAdd.Click += btnConfirmAdd_Click_1;
            // 
            // btnCancelAdd
            // 
            btnCancelAdd.FlatStyle = FlatStyle.Flat;
            btnCancelAdd.Location = new Point(190, 288);
            btnCancelAdd.Margin = new Padding(3, 4, 3, 4);
            btnCancelAdd.Name = "btnCancelAdd";
            btnCancelAdd.Size = new Size(140, 44);
            btnCancelAdd.TabIndex = 8;
            btnCancelAdd.Text = "Cancel";
            // 
            // grpEditUser
            // 
            grpEditUser.Controls.Add(lblEditU);
            grpEditUser.Controls.Add(lblEditP);
            grpEditUser.Controls.Add(lblEditR);
            grpEditUser.Controls.Add(lblEditS);
            grpEditUser.Controls.Add(txtEditUsername);
            grpEditUser.Controls.Add(txtEditPassword);
            grpEditUser.Controls.Add(cmbEditRole);
            grpEditUser.Controls.Add(cmbEditStatus);
            grpEditUser.Controls.Add(btnConfirmEdit);
            grpEditUser.Controls.Add(btnCancelEdit);
            grpEditUser.Location = new Point(425, 412);
            grpEditUser.Margin = new Padding(3, 4, 3, 4);
            grpEditUser.Name = "grpEditUser";
            grpEditUser.Padding = new Padding(3, 4, 3, 4);
            grpEditUser.Size = new Size(360, 362);
            grpEditUser.TabIndex = 8;
            grpEditUser.TabStop = false;
            grpEditUser.Text = "Modify User Account";
            // 
            // lblEditU
            // 
            lblEditU.Location = new Point(20, 31);
            lblEditU.Name = "lblEditU";
            lblEditU.Size = new Size(100, 29);
            lblEditU.TabIndex = 0;
            lblEditU.Text = "Username:";
            // 
            // lblEditP
            // 
            lblEditP.Location = new Point(20, 94);
            lblEditP.Name = "lblEditP";
            lblEditP.Size = new Size(100, 29);
            lblEditP.TabIndex = 1;
            lblEditP.Text = "Password:";
            // 
            // lblEditR
            // 
            lblEditR.Location = new Point(20, 156);
            lblEditR.Name = "lblEditR";
            lblEditR.Size = new Size(100, 29);
            lblEditR.TabIndex = 2;
            lblEditR.Text = "Role:";
            // 
            // lblEditS
            // 
            lblEditS.Location = new Point(20, 219);
            lblEditS.Name = "lblEditS";
            lblEditS.Size = new Size(100, 29);
            lblEditS.TabIndex = 3;
            lblEditS.Text = "Status:";
            // 
            // txtEditUsername
            // 
            txtEditUsername.Location = new Point(20, 56);
            txtEditUsername.Margin = new Padding(3, 4, 3, 4);
            txtEditUsername.Name = "txtEditUsername";
            txtEditUsername.Size = new Size(310, 27);
            txtEditUsername.TabIndex = 4;
            // 
            // txtEditPassword
            // 
            txtEditPassword.Location = new Point(20, 119);
            txtEditPassword.Margin = new Padding(3, 4, 3, 4);
            txtEditPassword.Name = "txtEditPassword";
            txtEditPassword.Size = new Size(310, 27);
            txtEditPassword.TabIndex = 5;
            // 
            // cmbEditRole
            // 
            cmbEditRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditRole.Location = new Point(20, 181);
            cmbEditRole.Margin = new Padding(3, 4, 3, 4);
            cmbEditRole.Name = "cmbEditRole";
            cmbEditRole.Size = new Size(310, 28);
            cmbEditRole.TabIndex = 6;
            // 
            // cmbEditStatus
            // 
            cmbEditStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditStatus.Location = new Point(20, 244);
            cmbEditStatus.Margin = new Padding(3, 4, 3, 4);
            cmbEditStatus.Name = "cmbEditStatus";
            cmbEditStatus.Size = new Size(310, 28);
            cmbEditStatus.TabIndex = 7;
            // 
            // btnConfirmEdit
            // 
            btnConfirmEdit.BackColor = Color.FromArgb(0, 128, 128);
            btnConfirmEdit.FlatStyle = FlatStyle.Flat;
            btnConfirmEdit.ForeColor = Color.White;
            btnConfirmEdit.Location = new Point(20, 294);
            btnConfirmEdit.Margin = new Padding(3, 4, 3, 4);
            btnConfirmEdit.Name = "btnConfirmEdit";
            btnConfirmEdit.Size = new Size(140, 44);
            btnConfirmEdit.TabIndex = 8;
            btnConfirmEdit.Text = "Update Account";
            btnConfirmEdit.UseVisualStyleBackColor = false;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.FlatStyle = FlatStyle.Flat;
            btnCancelEdit.Location = new Point(190, 294);
            btnCancelEdit.Margin = new Padding(3, 4, 3, 4);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(140, 44);
            btnCancelEdit.TabIndex = 9;
            btnCancelEdit.Text = "Cancel";
            // 
            // panelDashboard
            // 
            panelDashboard.BackColor = Color.White;
            panelDashboard.Controls.Add(lblAdminName);
            panelDashboard.Controls.Add(pnlStat1);
            panelDashboard.Dock = DockStyle.Fill;
            panelDashboard.Location = new Point(0, 0);
            panelDashboard.Margin = new Padding(3, 4, 3, 4);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Size = new Size(814, 812);
            panelDashboard.TabIndex = 0;
            // 
            // lblAdminName
            // 
            lblAdminName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAdminName.ForeColor = Color.FromArgb(47, 79, 79);
            lblAdminName.Location = new Point(30, 38);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(500, 50);
            lblAdminName.TabIndex = 0;
            // 
            // pnlStat1
            // 
            pnlStat1.BackColor = Color.FromArgb(0, 128, 128);
            pnlStat1.Controls.Add(lblTotalUsersTitle);
            pnlStat1.Controls.Add(lblTotalUsersVal);
            pnlStat1.Location = new Point(35, 138);
            pnlStat1.Margin = new Padding(3, 4, 3, 4);
            pnlStat1.Name = "pnlStat1";
            pnlStat1.Size = new Size(220, 150);
            pnlStat1.TabIndex = 1;
            // 
            // lblTotalUsersTitle
            // 
            lblTotalUsersTitle.Font = new Font("Segoe UI", 11F);
            lblTotalUsersTitle.ForeColor = Color.White;
            lblTotalUsersTitle.Location = new Point(10, 19);
            lblTotalUsersTitle.Name = "lblTotalUsersTitle";
            lblTotalUsersTitle.Size = new Size(200, 31);
            lblTotalUsersTitle.TabIndex = 0;
            lblTotalUsersTitle.Text = "Total Registered Users";
            // 
            // lblTotalUsersVal
            // 
            lblTotalUsersVal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTotalUsersVal.ForeColor = Color.White;
            lblTotalUsersVal.Location = new Point(10, 62);
            lblTotalUsersVal.Name = "lblTotalUsersVal";
            lblTotalUsersVal.Size = new Size(200, 62);
            lblTotalUsersVal.TabIndex = 1;
            lblTotalUsersVal.Text = "0";
            // 
            // panelInventory
            // 
            panelInventory.BackColor = Color.White;
            panelInventory.Controls.Add(dgvInventory);
            panelInventory.Controls.Add(numInventoryStock);
            panelInventory.Controls.Add(cmbInventoryStatus);
            panelInventory.Controls.Add(btnUpdateInventory);
            panelInventory.Controls.Add(btnProdAdd);
            panelInventory.Controls.Add(btnProdUpdate);
            panelInventory.Controls.Add(btnProdDelete);
            panelInventory.Controls.Add(lblInvSelectedName);
            panelInventory.Controls.Add(picInventoryPreview);
            panelInventory.Controls.Add(lblInvStockLabel);
            panelInventory.Controls.Add(lblInvAvLabel);
            panelInventory.Dock = DockStyle.Fill;
            panelInventory.Location = new Point(0, 0);
            panelInventory.Margin = new Padding(3, 4, 3, 4);
            panelInventory.Name = "panelInventory";
            panelInventory.Size = new Size(814, 812);
            panelInventory.TabIndex = 3;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.ColumnHeadersHeight = 29;
            dgvInventory.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11 });
            dgvInventory.Location = new Point(25, 31);
            dgvInventory.Margin = new Padding(3, 4, 3, 4);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(480, 625);
            dgvInventory.TabIndex = 0;
            dgvInventory.CellClick += dgvInventory_CellClick;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Width = 125;
            // 
            // numInventoryStock
            // 
            numInventoryStock.Location = new Point(530, 106);
            numInventoryStock.Margin = new Padding(3, 4, 3, 4);
            numInventoryStock.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numInventoryStock.Name = "numInventoryStock";
            numInventoryStock.Size = new Size(250, 27);
            numInventoryStock.TabIndex = 1;
            // 
            // cmbInventoryStatus
            // 
            cmbInventoryStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInventoryStatus.Items.AddRange(new object[] { "Available", "Unavailable" });
            cmbInventoryStatus.Location = new Point(530, 181);
            cmbInventoryStatus.Margin = new Padding(3, 4, 3, 4);
            cmbInventoryStatus.Name = "cmbInventoryStatus";
            cmbInventoryStatus.Size = new Size(250, 28);
            cmbInventoryStatus.TabIndex = 2;
            // 
            // btnUpdateInventory
            // 
            btnUpdateInventory.BackColor = Color.FromArgb(0, 128, 128);
            btnUpdateInventory.FlatStyle = FlatStyle.Flat;
            btnUpdateInventory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdateInventory.ForeColor = Color.White;
            btnUpdateInventory.Location = new Point(530, 445);
            btnUpdateInventory.Margin = new Padding(3, 4, 3, 4);
            btnUpdateInventory.Name = "btnUpdateInventory";
            btnUpdateInventory.Size = new Size(250, 45);
            btnUpdateInventory.TabIndex = 3;
            btnUpdateInventory.Text = "Save Records";
            btnUpdateInventory.UseVisualStyleBackColor = false;
            btnUpdateInventory.Click += btnUpdateInventory_Click;
            // 
            // btnProdAdd
            // 
            btnProdAdd.BackColor = Color.FromArgb(0, 128, 128);
            btnProdAdd.FlatStyle = FlatStyle.Flat;
            btnProdAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProdAdd.ForeColor = Color.White;
            btnProdAdd.Location = new Point(530, 500);
            btnProdAdd.Margin = new Padding(3, 4, 3, 4);
            btnProdAdd.Name = "btnProdAdd";
            btnProdAdd.Size = new Size(250, 45);
            btnProdAdd.TabIndex = 8;
            btnProdAdd.Text = "Add Product";
            btnProdAdd.UseVisualStyleBackColor = false;
            btnProdAdd.Click += btnProdAdd_Click;
            // 
            // btnProdUpdate
            // 
            btnProdUpdate.BackColor = Color.FromArgb(0, 128, 128);
            btnProdUpdate.FlatStyle = FlatStyle.Flat;
            btnProdUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProdUpdate.ForeColor = Color.White;
            btnProdUpdate.Location = new Point(530, 555);
            btnProdUpdate.Margin = new Padding(3, 4, 3, 4);
            btnProdUpdate.Name = "btnProdUpdate";
            btnProdUpdate.Size = new Size(250, 45);
            btnProdUpdate.TabIndex = 9;
            btnProdUpdate.Text = "Edit Product";
            btnProdUpdate.UseVisualStyleBackColor = false;
            btnProdUpdate.Click += btnProdUpdate_Click;
            // 
            // btnProdDelete
            // 
            btnProdDelete.BackColor = Color.Firebrick;
            btnProdDelete.FlatStyle = FlatStyle.Flat;
            btnProdDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProdDelete.ForeColor = Color.White;
            btnProdDelete.Location = new Point(530, 610);
            btnProdDelete.Margin = new Padding(3, 4, 3, 4);
            btnProdDelete.Name = "btnProdDelete";
            btnProdDelete.Size = new Size(250, 45);
            btnProdDelete.TabIndex = 10;
            btnProdDelete.Text = "Delete Product";
            btnProdDelete.UseVisualStyleBackColor = false;
            btnProdDelete.Click += btnProdDelete_Click;
            // 
            // lblInvSelectedName
            // 
            lblInvSelectedName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInvSelectedName.Location = new Point(530, 31);
            lblInvSelectedName.Name = "lblInvSelectedName";
            lblInvSelectedName.Size = new Size(260, 31);
            lblInvSelectedName.TabIndex = 4;
            lblInvSelectedName.Text = "Selected Item: None";
            // 
            // picInventoryPreview
            // 
            picInventoryPreview.BorderStyle = BorderStyle.FixedSingle;
            picInventoryPreview.Location = new Point(530, 238);
            picInventoryPreview.Margin = new Padding(3, 4, 3, 4);
            picInventoryPreview.Name = "picInventoryPreview";
            picInventoryPreview.Size = new Size(250, 187);
            picInventoryPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picInventoryPreview.TabIndex = 5;
            picInventoryPreview.TabStop = false;
            // 
            // lblInvStockLabel
            // 
            lblInvStockLabel.Location = new Point(530, 78);
            lblInvStockLabel.Name = "lblInvStockLabel";
            lblInvStockLabel.Size = new Size(120, 25);
            lblInvStockLabel.TabIndex = 6;
            lblInvStockLabel.Text = "Stock Level:";
            // 
            // lblInvAvLabel
            // 
            lblInvAvLabel.Location = new Point(530, 153);
            lblInvAvLabel.Name = "lblInvAvLabel";
            lblInvAvLabel.Size = new Size(120, 25);
            lblInvAvLabel.TabIndex = 7;
            lblInvAvLabel.Text = "Status:";
            // 
            // panelOrders
            // 
            panelOrders.BackColor = Color.White;
            panelOrders.Controls.Add(dgvOrders);
            panelOrders.Controls.Add(lstOrderItemsView);
            panelOrders.Controls.Add(cmbOrderStatus);
            panelOrders.Controls.Add(btnUpdateOrderStatus);
            panelOrders.Controls.Add(lblOrderSelectedTrack);
            panelOrders.Controls.Add(lblLineItems);
            panelOrders.Controls.Add(lblStatusTransition);
            panelOrders.Dock = DockStyle.Fill;
            panelOrders.Location = new Point(0, 0);
            panelOrders.Margin = new Padding(3, 4, 3, 4);
            panelOrders.Name = "panelOrders";
            panelOrders.Size = new Size(814, 812);
            panelOrders.TabIndex = 4;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.ColumnHeadersHeight = 29;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15 });
            dgvOrders.Location = new Point(25, 31);
            dgvOrders.Margin = new Padding(3, 4, 3, 4);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(460, 625);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Width = 125;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Width = 125;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.MinimumWidth = 6;
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.Width = 125;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.MinimumWidth = 6;
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.Width = 125;
            // 
            // lstOrderItemsView
            // 
            lstOrderItemsView.Location = new Point(505, 106);
            lstOrderItemsView.Margin = new Padding(3, 4, 3, 4);
            lstOrderItemsView.Name = "lstOrderItemsView";
            lstOrderItemsView.Size = new Size(280, 244);
            lstOrderItemsView.TabIndex = 1;
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrderStatus.Items.AddRange(new object[] { "Pending", "Preparing", "Packed", "Out for Delivery", "Completed", "Cancelled" });
            cmbOrderStatus.Location = new Point(505, 406);
            cmbOrderStatus.Margin = new Padding(3, 4, 3, 4);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(280, 28);
            cmbOrderStatus.TabIndex = 2;
            // 
            // btnUpdateOrderStatus
            // 
            btnUpdateOrderStatus.BackColor = Color.FromArgb(0, 128, 128);
            btnUpdateOrderStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateOrderStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdateOrderStatus.ForeColor = Color.White;
            btnUpdateOrderStatus.Location = new Point(505, 462);
            btnUpdateOrderStatus.Margin = new Padding(3, 4, 3, 4);
            btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
            btnUpdateOrderStatus.Size = new Size(280, 52);
            btnUpdateOrderStatus.TabIndex = 3;
            btnUpdateOrderStatus.Text = "Update Order Matrix";
            btnUpdateOrderStatus.UseVisualStyleBackColor = false;
            btnUpdateOrderStatus.Click += btnUpdateOrderStatus_Click;
            // 
            // lblOrderSelectedTrack
            // 
            lblOrderSelectedTrack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrderSelectedTrack.Location = new Point(505, 31);
            lblOrderSelectedTrack.Name = "lblOrderSelectedTrack";
            lblOrderSelectedTrack.Size = new Size(280, 31);
            lblOrderSelectedTrack.TabIndex = 4;
            lblOrderSelectedTrack.Text = "Tracking vector: None Selected";
            // 
            // lblLineItems
            // 
            lblLineItems.Location = new Point(0, 0);
            lblLineItems.Name = "lblLineItems";
            lblLineItems.Size = new Size(100, 29);
            lblLineItems.TabIndex = 5;
            // 
            // lblStatusTransition
            // 
            lblStatusTransition.Location = new Point(0, 0);
            lblStatusTransition.Name = "lblStatusTransition";
            lblStatusTransition.Size = new Size(100, 29);
            lblStatusTransition.TabIndex = 6;
            // 
            // panelProfile
            // 
            panelProfile.BackColor = Color.White;
            panelProfile.Controls.Add(panelProductMgmt);
            panelProfile.Controls.Add(lblP1);
            panelProfile.Controls.Add(lblP2);
            panelProfile.Controls.Add(lblP3);
            panelProfile.Controls.Add(lblP4);
            panelProfile.Controls.Add(txtProfUsername);
            panelProfile.Controls.Add(txtProfFullName);
            panelProfile.Controls.Add(txtProfRole);
            panelProfile.Controls.Add(txtProfPassword);
            panelProfile.Controls.Add(btnSaveProfile);
            panelProfile.Dock = DockStyle.Fill;
            panelProfile.Location = new Point(0, 0);
            panelProfile.Margin = new Padding(3, 4, 3, 4);
            panelProfile.Name = "panelProfile";
            panelProfile.Size = new Size(814, 812);
            panelProfile.TabIndex = 5;
            // 
            // lblP1
            // 
            lblP1.Location = new Point(40, 50);
            lblP1.Name = "lblP1";
            lblP1.Size = new Size(300, 25);
            lblP1.TabIndex = 0;
            lblP1.Text = "Account Username (Editable)";
            // 
            // lblP2
            // 
            lblP2.Location = new Point(40, 144);
            lblP2.Name = "lblP2";
            lblP2.Size = new Size(300, 25);
            lblP2.TabIndex = 1;
            lblP2.Text = "Administrative Role (Read-Only)";
            // 
            // lblP3
            // 
            lblP3.Location = new Point(40, 238);
            lblP3.Name = "lblP3";
            lblP3.Size = new Size(300, 25);
            lblP3.TabIndex = 2;
            lblP3.Text = "Display Full Name (Read-Only)";
            // 
            // lblP4
            // 
            lblP4.Location = new Point(40, 331);
            lblP4.Name = "lblP4";
            lblP4.Size = new Size(300, 25);
            lblP4.TabIndex = 3;
            lblP4.Text = "Update Security Password (Editable)";
            // 
            // txtProfUsername
            // 
            txtProfUsername.Location = new Point(40, 81);
            txtProfUsername.Margin = new Padding(3, 4, 3, 4);
            txtProfUsername.Name = "txtProfUsername";
            txtProfUsername.Size = new Size(400, 27);
            txtProfUsername.TabIndex = 4;
            // 
            // txtProfFullName
            // 
            txtProfFullName.Location = new Point(40, 269);
            txtProfFullName.Margin = new Padding(3, 4, 3, 4);
            txtProfFullName.Name = "txtProfFullName";
            txtProfFullName.ReadOnly = true;
            txtProfFullName.Size = new Size(400, 27);
            txtProfFullName.TabIndex = 5;
            // 
            // txtProfRole
            // 
            txtProfRole.Location = new Point(40, 175);
            txtProfRole.Margin = new Padding(3, 4, 3, 4);
            txtProfRole.Name = "txtProfRole";
            txtProfRole.ReadOnly = true;
            txtProfRole.Size = new Size(400, 27);
            txtProfRole.TabIndex = 6;
            // 
            // txtProfPassword
            // 
            txtProfPassword.Location = new Point(40, 362);
            txtProfPassword.Margin = new Padding(3, 4, 3, 4);
            txtProfPassword.Name = "txtProfPassword";
            txtProfPassword.Size = new Size(400, 27);
            txtProfPassword.TabIndex = 7;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.BackColor = Color.FromArgb(0, 128, 128);
            btnSaveProfile.FlatStyle = FlatStyle.Flat;
            btnSaveProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveProfile.ForeColor = Color.White;
            btnSaveProfile.Location = new Point(40, 438);
            btnSaveProfile.Margin = new Padding(3, 4, 3, 4);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(180, 50);
            btnSaveProfile.TabIndex = 8;
            btnSaveProfile.Text = "Save Changes";
            btnSaveProfile.UseVisualStyleBackColor = false;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // colUser
            // 
            colUser.MinimumWidth = 6;
            colUser.Name = "colUser";
            colUser.Width = 125;
            // 
            // colRole
            // 
            colRole.MinimumWidth = 6;
            colRole.Name = "colRole";
            colRole.Width = 125;
            // 
            // colName
            // 
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.Width = 125;
            // 
            // colStatus
            // 
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.Width = 125;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 812);
            Controls.Add(panelMainContainer);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Management Console Workspace";
            Load += AdminForm_Load;
            panelSidebar.ResumeLayout(false);
            panelMainContainer.ResumeLayout(false);
            panelProductMgmt.ResumeLayout(false);
            panelProductMgmt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductPreview).EndInit();
            panelUserMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBanHours).EndInit();
            grpAddUser.ResumeLayout(false);
            grpAddUser.PerformLayout();
            grpEditUser.ResumeLayout(false);
            grpEditUser.PerformLayout();
            panelDashboard.ResumeLayout(false);
            pnlStat1.ResumeLayout(false);
            panelInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInventoryStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picInventoryPreview).EndInit();
            panelOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelProfile.ResumeLayout(false);
            panelProfile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUserMgmt;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Label lblTotalUsersTitle;
        private System.Windows.Forms.Label lblTotalUsersVal;
        private System.Windows.Forms.Panel panelUserMgmt;
        private System.Windows.Forms.DataGridView dgvUsers;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;

        // New Submodule Canvas Forms UI Control Mappings
        private System.Windows.Forms.Panel panelProductMgmt;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.TextBox txtProdStock;
        private System.Windows.Forms.TextBox txtProdCategory;
        private System.Windows.Forms.TextBox txtProdImagePath;
        private System.Windows.Forms.ComboBox cmbProdStatus;
        private System.Windows.Forms.Button btnProdAdd;
        private System.Windows.Forms.Button btnProdUpdate;
        private System.Windows.Forms.Button btnProdDelete;
        private System.Windows.Forms.Button btnProdClear;
        private System.Windows.Forms.Button btnProdBrowseImage;
        private System.Windows.Forms.PictureBox picProductPreview;

        private System.Windows.Forms.Panel panelInventory;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.NumericUpDown numInventoryStock;
        private System.Windows.Forms.ComboBox cmbInventoryStatus;
        private System.Windows.Forms.Button btnUpdateInventory;
        private System.Windows.Forms.Label lblInvSelectedName;
        private System.Windows.Forms.PictureBox picInventoryPreview;

        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ListBox lstOrderItemsView;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Button btnUpdateOrderStatus;
        private System.Windows.Forms.Label lblOrderSelectedTrack;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Label lblSearchLabel;
        private Label lblN;
        private Label lblD;
        private Label lblP;
        private Label lblS;
        private Label lblC;
        private Label lblI;
        private Label lblSt;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private Label lblInvStockLabel;
        private Label lblInvAvLabel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private Label lblLineItems;
        private Label lblStatusTransition;
    }
}