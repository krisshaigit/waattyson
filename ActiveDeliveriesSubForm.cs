using System;

using System.Collections.Generic;

using System.Drawing;

using System.IO;

using System.Windows.Forms;



namespace adminstaffff

{

    public partial class ActiveDeliveriesSubForm : Form

    {

        private DriverForm parent;

        private DataGridView dgvActive;

        private TextBox txtSearch;

        private Button btnOutForDelivery, btnDeliveredTransition, btnRefresh;

        private List<Delivery> deliveriesList = new List<Delivery>();



        public ActiveDeliveriesSubForm(DriverForm mainForm)

        {

            parent = mainForm;

            InitializeComponent(); // Runs the hidden designer file smoothly

            SetupCustomLayout();    // Runs our custom UI elements safely

            LoadDeliveries();

        }



        private void SetupCustomLayout()

        {

            this.Size = new System.Drawing.Size(810, 650);

            this.BackColor = System.Drawing.Color.White;



            Label title = new Label { Text = "Current Dispatch Orders", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 15), Size = new Size(300, 30) };



            txtSearch = new TextBox { Location = new Point(20, 55), Size = new Size(250, 30) };

            txtSearch.TextChanged += (s, e) => LoadDeliveries(txtSearch.Text);



            btnRefresh = new Button { Text = "Refresh", Location = new Point(280, 53), Size = new Size(90, 28), BackColor = Color.LightGray };

            btnRefresh.Click += (s, e) => LoadDeliveries();



            dgvActive = new DataGridView { Location = new Point(20, 95), Size = new Size(760, 420), AutoGenerateColumns = false, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };



            dgvActive.Columns.Add(new DataGridViewTextBoxColumn { Name = "OrderID", DataPropertyName = "OrderID", HeaderText = "Order ID", Width = 90 });

            dgvActive.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerName", DataPropertyName = "CustomerName", HeaderText = "Customer Name", Width = 140 });

            dgvActive.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", DataPropertyName = "Address", HeaderText = "Delivery Address", Width = 220 });

            dgvActive.Columns.Add(new DataGridViewTextBoxColumn { Name = "ContactNumber", DataPropertyName = "ContactNumber", HeaderText = "Contact #", Width = 110 });

            dgvActive.Columns.Add(new DataGridViewTextBoxColumn { Name = "OrderedItems", DataPropertyName = "OrderedItems", HeaderText = "Items", Width = 200 });

            dgvActive.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status", Width = 100 });



            btnOutForDelivery = new Button { Text = "Mark Out for Delivery", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.Orange, ForeColor = Color.White, Location = new Point(20, 535), Size = new Size(180, 45), FlatStyle = FlatStyle.Flat };

            btnOutForDelivery.Click += ChangeStatus_Click;



            btnDeliveredTransition = new Button { Text = "Proceed to Confirm", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.SeaGreen, ForeColor = Color.White, Location = new Point(210, 535), Size = new Size(180, 45), FlatStyle = FlatStyle.Flat };

            btnDeliveredTransition.Click += (s, e) => parent.OpenSubPage(new ConfirmationSubForm(parent));



            this.Controls.AddRange(new Control[] { title, txtSearch, btnRefresh, dgvActive, btnOutForDelivery, btnDeliveredTransition });

        }



        private void LoadDeliveries(string filter = "")

        {

            deliveriesList.Clear();

            if (!File.Exists(parent.ActiveDeliveriesFile)) return;



            string[] lines = File.ReadAllLines(parent.ActiveDeliveriesFile);

            var bindingList = new List<Delivery>();



            foreach (var line in lines)

            {

                var parts = line.Split('|');

                if (parts.Length < 7) continue;



                var d = new Delivery

                {

                    OrderID = parts[0],

                    CustomerName = parts[1],

                    Address = parts[2],

                    ContactNumber = parts[3],

                    OrderedItems = parts[4],

                    Status = parts[5],

                    AssignedDate = parts[6],

                    VerificationCode = parts.Length > 7 ? parts[7] : ""

                };



                if (string.IsNullOrEmpty(filter) || d.CustomerName.ToLower().Contains(filter.ToLower()) || d.OrderID.ToLower().Contains(filter.ToLower()))

                {

                    bindingList.Add(d);

                }

                deliveriesList.Add(d);

            }

            dgvActive.DataSource = null;

            dgvActive.DataSource = bindingList;

        }



        private void ChangeStatus_Click(object sender, EventArgs e)

        {

            if (dgvActive.CurrentRow == null) return;

            string selectedId = dgvActive.CurrentRow.Cells["OrderID"].Value.ToString();



            var newLines = new List<string>();

            foreach (var d in deliveriesList)

            {

                if (d.OrderID == selectedId && d.Status == "Assigned") d.Status = "Out For Delivery";

                newLines.Add($"{d.OrderID}|{d.CustomerName}|{d.Address}|{d.ContactNumber}|{d.OrderedItems}|{d.Status}|{d.AssignedDate}|{d.VerificationCode}|");

            }



            File.WriteAllLines(parent.ActiveDeliveriesFile, newLines);

            LoadDeliveries();

            MessageBox.Show("Order state has changed to Out For Delivery.", "Status updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ActiveDeliveriesSubForm_Load(object sender, EventArgs e) { }

    }



}