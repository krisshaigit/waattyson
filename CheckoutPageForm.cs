using System;
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

            Order newOrder = new Order
            {
                OrderId = "TRK-" + new Random().Next(1000, 9999).ToString("X"),

                // Fallback if CurrentUser is null
                Username = $"{(DataEngine.CurrentUser != null ? DataEngine.CurrentUser.Username : "Guest")}|Address:{txtAddress.Text}",

                // Fallback if Product details are missing from products.txt
                Items = string.Join(Environment.NewLine, DataEngine.Cart.Select(c =>
                    c.Product != null
                        ? $"{c.Quantity}x|{c.Product.ProductId}|{c.Product.Name}|₱{c.Product.Price:N2}"
                        : $"{c.Quantity}x|UNKNOWN_ID|Unknown Product Name|₱0.00"
    )),

                Total = DataEngine.Cart.Sum(c => c.TotalPrice),
                Status = "Pending",
                Date = DateTime.Now.ToString("yyyy-MM-dd")
            };

            DataEngine.Orders.Add(newOrder);
            DataEngine.SaveOrders();
            DataEngine.SaveProducts();
            DataEngine.Cart.Clear();

            MessageBox.Show($"Order processed successfully!\nTracking ID: {newOrder.OrderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshCartDisplay();
        }

        private void CheckoutPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
