using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class CheckoutPageForm : Form
    {
        private ListBox lbCart;
        private TextBox txtAddress;
        private ComboBox cbPayment;
        private Label lblTotal;

        public CheckoutPageForm()
        {
            lbCart = new ListBox() { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(400, 300) };
            lblTotal = new Label() { Location = new System.Drawing.Point(20, 340), Size = new System.Drawing.Size(200, 25), Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold) };

            Label lblAdd = new Label() { Text = "Shipping Address:", Location = new System.Drawing.Point(450, 20) };
            txtAddress = new TextBox() { Location = new System.Drawing.Point(450, 45), Size = new System.Drawing.Size(280, 60), Multiline = true, Text = DataEngine.CurrentUser?.Address ?? "" };

            Label lblPay = new Label() { Text = "Payment Method:", Location = new System.Drawing.Point(450, 120) };
            cbPayment = new ComboBox() { Location = new System.Drawing.Point(450, 145), Width = 180 };
            cbPayment.Items.AddRange(new[] { "GCash" });
            cbPayment.SelectedIndex = 0;

            Button btnCheckout = new Button() { Text = "Place Order", Location = new System.Drawing.Point(450, 220), Size = new System.Drawing.Size(150, 40), BackColor = System.Drawing.Color.Green, ForeColor = System.Drawing.Color.White };
            btnCheckout.Click += PlaceOrderClick;

            this.Controls.AddRange(new Control[] { lbCart, lblTotal, lblAdd, txtAddress, lblPay, cbPayment, btnCheckout });
            RefreshCartDisplay();
        }

        private void RefreshCartDisplay()
        {
            lbCart.Items.Clear();
            foreach (var item in DataEngine.Cart)
            {
                lbCart.Items.Add($"{item.Product.Name} x{item.Quantity} - Php {item.TotalPrice:N2}");
            }
            lblTotal.Text = $"Total: Php {DataEngine.Cart.Sum(c => c.TotalPrice):N2}";
        }

        private void PlaceOrderClick(object sender, EventArgs e)
        {
            if (!DataEngine.Cart.Any()) { MessageBox.Show("Cart is empty."); return; }
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) { MessageBox.Show("Please provide a shipping address."); return; }

            // 1. Generate the values using your exact existing data objects
            string orderId = "TRK-" + new Random().Next(1000, 9999).ToString("X");

            // We isolate the username cleanly so your HistoryPageForm's WHERE clause can find it!
            string usernameOnly = DataEngine.CurrentUser != null ? DataEngine.CurrentUser.Username : "Guest";

            // Format the items text block exactly how you had it
            string itemsDetails = string.Join(Environment.NewLine, DataEngine.Cart.Select(c =>
                c.Product != null
                    ? $"{c.Quantity}x|{c.Product.ProductId}|{c.Product.Name}|₱{c.Product.Price:N2}"
                    : $"{c.Quantity}x|UNKNOWN_ID|Unknown Product Name|₱0.00"
            ));

            decimal totalAmount = DataEngine.Cart.Sum(c => c.TotalPrice);
            string status = "Pending";
            string dateStamp = DateTime.Now.ToString("yyyy-MM-dd");

            // Combine username and address for the in-memory object so your other pages don't break
            string formattedUsernameWithAddress = $"{usernameOnly}|Address:{txtAddress.Text}";

            // 2. Keep your runtime memory engine updated
            Order newOrder = new Order
            {
                OrderId = orderId,
                Username = usernameOnly, // Set to clean username for history mapping consistency
                Items = itemsDetails,
                Total = totalAmount,
                Status = status,
                Date = dateStamp
            };
            DataEngine.Orders.Add(newOrder);

            // 3. WRITE DIRECTLY TO SQLITE 
            string dbConnectionPath = "Data Source=watson_shop.db;Version=3;";
            string insertQuery = @"
        INSERT INTO Orders (OrderId, Username, Items, Total, Status, Date) 
        VALUES (@OrderId, @Username, @Items, @Total, @Status, @Date);";

            try
            {
                using (var connection = new SQLiteConnection(dbConnectionPath))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.Parameters.AddWithValue("@Username", usernameOnly); // Saved clean for user history lookups!
                        command.Parameters.AddWithValue("@Items", itemsDetails);
                        command.Parameters.AddWithValue("@Total", totalAmount);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@Date", dateStamp);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database save failed, but proceeding in-memory: {ex.Message}", "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 4. Run your remaining app state cleanup routines
            DataEngine.SaveOrders(); // Keeps your legacy backup files safe
            DataEngine.SaveProducts();
            DataEngine.Cart.Clear();

            MessageBox.Show($"Order processed successfully!\nTracking ID: {orderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshCartDisplay();
        }

        private void CheckoutPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}