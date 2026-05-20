using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class HistorySubForm : Form
    {
        private DriverForm parent;
        private DataGridView dgvHistory;

        public HistorySubForm(DriverForm mainForm)
        {
            parent = mainForm;
            InitializeComponent();
            SetupCustomLayout();
            LoadHistoricalData();
        }

        private void SetupCustomLayout()
        {
            this.Size = new System.Drawing.Size(810, 650);
            this.BackColor = System.Drawing.Color.White;

            Label title = new Label { Text = "Completed Deliveries Ledger", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 15), Size = new Size(350, 30) };
            dgvHistory = new DataGridView { Location = new Point(20, 65), Size = new Size(760, 540), AutoGenerateColumns = true, AllowUserToAddRows = false, ReadOnly = true };

            this.Controls.AddRange(new Control[] { title, dgvHistory });
        }

        private void LoadHistoricalData()
        {
            if (!File.Exists(parent.DeliveryHistoryFile)) return;
            string[] lines = File.ReadAllLines(parent.DeliveryHistoryFile);
            var items = new List<object>();

            foreach (var line in lines)
            {
                var p = line.Split('|');
                if (p.Length < 6) continue;
                items.Add(new { OrderID = p[0], Customer = p[1], Destination = p[2], Timestamp = p[3], Notes = p[4], MetricState = p[5] });
            }

            dgvHistory.DataSource = null;
            dgvHistory.DataSource = items;
        }
        private void HistorySubForm_Load(object sender, EventArgs e) { }
    }

}