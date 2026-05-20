using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class ConfirmationSubForm : Form
    {
        private DriverForm parent;
        private ComboBox cbActiveOrders;
        private TextBox txtCode, txtNotes;
        private Button btnConfirm;

        public ConfirmationSubForm(DriverForm mainForm)
        {
            parent = mainForm;
            InitializeComponent();
            SetupCustomLayout();
            PopulateActiveDropdown();
        }

        private void SetupCustomLayout()
        {
            this.Size = new System.Drawing.Size(810, 650);
            this.BackColor = System.Drawing.Color.White;

            Label title = new Label { Text = "Delivery Drop-Off Settlement", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(30, 20), Size = new Size(400, 30) };

            Label lblSelect = new Label { Text = "Select Order ID:", Location = new Point(30, 75), Size = new Size(120, 20) };
            cbActiveOrders = new ComboBox { Location = new Point(160, 72), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblCode = new Label { Text = "Customer Secure PIN:", Location = new Point(30, 125), Size = new Size(120, 20) };
            txtCode = new TextBox { Location = new Point(160, 122), Size = new Size(220, 25) };

            Label lblNotes = new Label { Text = "Delivery Action Notes:", Location = new Point(30, 175), Size = new Size(120, 20) };
            txtNotes = new TextBox { Location = new Point(160, 172), Size = new Size(350, 80), Multiline = true };

            btnConfirm = new Button { Text = "Confirm Successful Completion", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = Color.Teal, ForeColor = Color.White, Location = new Point(160, 275), Size = new Size(250, 45), FlatStyle = FlatStyle.Flat };
            btnConfirm.Click += CompleteDeliveryPipeline_Click;

            this.Controls.AddRange(new Control[] { title, lblSelect, cbActiveOrders, lblCode, txtCode, lblNotes, txtNotes, btnConfirm });
        }

        private void PopulateActiveDropdown()
        {
            cbActiveOrders.Items.Clear();
            if (!File.Exists(parent.ActiveDeliveriesFile)) return;

            foreach (var line in File.ReadAllLines(parent.ActiveDeliveriesFile))
            {
                var parts = line.Split('|');
                if (parts.Length > 5 && parts[5] == "Out For Delivery")
                {
                    cbActiveOrders.Items.Add(parts[0]);
                }
            }
        }

        private void CompleteDeliveryPipeline_Click(object sender, EventArgs e)
        {
            if (cbActiveOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an active dispatch package out for delivery.", "Verification Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetId = cbActiveOrders.SelectedItem.ToString();
            string[] lines = File.ReadAllLines(parent.ActiveDeliveriesFile);
            var remainingLines = new List<string>();
            string completedRecord = "";
            bool verified = false;

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts[0] == targetId)
                {
                    string actualPin = parts[7].Trim();
                    if (actualPin == txtCode.Text.Trim())
                    {
                        verified = true;
                        completedRecord = $"{parts[0]}|{parts[1]}|{parts[2]}|{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}|{txtNotes.Text.Replace('|', ' ')}|Delivered";
                        continue;
                    }
                }
                remainingLines.Add(line);
            }

            if (!verified)
            {
                MessageBox.Show("Invalid verification security PIN code. Provide note context values to override authorization rules.", "Secure Checkstop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            File.WriteAllLines(parent.ActiveDeliveriesFile, remainingLines);
            File.AppendAllText(parent.DeliveryHistoryFile, completedRecord + Environment.NewLine);

            string msg = $"{parent.CurrentRiderName} drop-off fulfilled successfully for package {targetId}.";
            File.AppendAllText(parent.NotificationsFile, $"driver01|{msg}|{DateTime.Now.ToShortDateString()}|StatusUpdate" + Environment.NewLine);

            MessageBox.Show("Package payload settlement committed to permanent storage ledger files.", "Fulfillment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            parent.OpenSubPage(new ActiveDeliveriesSubForm(parent));
        }
        private void ConfirmationSubForm_Load(object sender, EventArgs e) { }
    }
    
}