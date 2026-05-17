using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class UserForm : Form
    {
        // Simple in-memory models for this UI
        private sealed record Product(string Id, string Name, decimal Price, string Category);
        private sealed record CartItem(Product Product, int Quantity);

        // Order model for structured history and status updates
        private sealed record Order(
            string Tracking,
            DateTime Timestamp,
            string Status,
            string FirstName,
            string LastName,
            string Address,
            List<string> Items);

        // Wrapper for ListBox display items (category/product list)
        private sealed class ListBoxItem
        {
            public string Text { get; }
            public object Value { get; }
            public ListBoxItem(string text, object value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }

        // In-memory collections
        private readonly List<Product> _products = new();
        private readonly List<CartItem> _cart = new();
        private readonly List<Order> _ordersHistory = new();
        private readonly string _ordersFile = "orders.txt";
        private readonly string _productsFile = "products.txt";
        private readonly string _profileFile = "profile.txt";

        // Runtime-created controls for richer history UI
        private DataGridView? dgvHistory;
        private ContextMenuStrip? ctxHistory;

        // Category / product list control (designer may not have added it)
        private ListBox? listBox2;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(string fullName) : this()
        {
            var lblWelcomeCtl = Controls.Find("lblWelcome", true).FirstOrDefault() as Label;
            if (lblWelcomeCtl != null && !string.IsNullOrWhiteSpace(fullName))
                lblWelcomeCtl.Text = $"Welcome, {fullName}";
            var lblRoleCtl = Controls.Find("lblRole", true).FirstOrDefault() as Label;
            if (lblRoleCtl != null) lblRoleCtl.Text = "Role: User";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EnsureProductsFile();
            LoadProductsFromFile();
            LoadProfile();
            PopulateUI();
            WireEvents();
            LoadHistoryStructured(); // populate structured history and grid
            UpdateTotalsUI();
        }

        // ---------- products / UI / cart code (unchanged from prior) ----------
        private void EnsureProductsFile()
        {
            try
            {
                if (!File.Exists(_productsFile))
                {
                    var sample = new[]
                    {
                        "P001|Advanced HA Serum|1249.00|Skincare",
                        "P002|Radiance Infusion Oil|899.50|Skincare",
                        "P003|Mineral SPF 50+|749.75|Sun Care",
                        "P004|Ceramide Night Repair|1299.00|Skincare",
                        "P005|Hair Care Set|599.00|Hair Care",
                        "P006|Wellness Hydrator|399.00|Wellness"
                    };
                    File.WriteAllLines(_productsFile, sample);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to ensure products file: " + ex.Message, "IO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadProductsFromFile()
        {
            _products.Clear();
            try
            {
                if (!File.Exists(_productsFile)) return;
                var lines = File.ReadAllLines(_productsFile);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length < 4) continue;
                    if (!decimal.TryParse(parts[2], NumberStyles.Number, CultureInfo.InvariantCulture, out var price)) continue;
                    _products.Add(new Product(parts[0].Trim(), parts[1].Trim(), price, parts[3].Trim()));
                }
            }
            catch { /* ignore malformed product file */ }
        }

        private void PopulateUI()
        {
            // ensure category list exists before using it
            EnsureCategoryListBox();

            try { label1.Font = new Font(label1.Font, FontStyle.Bold); } catch { }
            try { label3.Font = new Font(label3.Font, FontStyle.Bold); } catch { }
            PopulateCategoriesListBox();
            UpdateFeaturedLabels();
            UpdateCartList();
        }

        // Ensure a ListBox named listBox2 exists (designer may not have added it)
        private void EnsureCategoryListBox()
        {
            if (listBox2 != null) return;
            var found = Controls.Find("listBox2", true).FirstOrDefault() as ListBox;
            if (found != null)
            {
                listBox2 = found;
                return;
            }

            // create a runtime ListBox and add to tabPage2
            listBox2 = new ListBox
            {
                Name = "listBox2",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            // wire event (will also be wired in WireEvents)
            listBox2.DoubleClick += listBox2_DoubleClick;

            try
            {
                tabPage2.Controls.Clear();
                tabPage2.Controls.Add(listBox2);
            }
            catch
            {
                Controls.Add(listBox2);
            }
        }

        private void PopulateCategoriesListBox()
        {
            if (listBox2 == null) EnsureCategoryListBox();
            listBox2!.Items.Clear();
            var categories = _products.Select(p => p.Category).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToArray();
            foreach (var c in categories) listBox2.Items.Add(new ListBoxItem(c, c));
            listBox2.Tag = "categories";
        }

        private void PopulateProductsListBox(string category)
        {
            if (listBox2 == null) EnsureCategoryListBox();
            listBox2!.Items.Clear();
            listBox2.Items.Add(new ListBoxItem(".. Back to Categories", "__back"));
            var items = _products.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase)).ToArray();
            foreach (var p in items) listBox2.Items.Add(new ListBoxItem($"{p.Name} - {FormatPrice(p.Price)}", p));
            listBox2.Tag = "products|" + category;
        }

        private void UpdateFeaturedLabels()
        {
            try { label4.Text = _products.ElementAtOrDefault(0)?.Name ?? string.Empty; } catch { }
            try { label5.Text = _products.ElementAtOrDefault(1)?.Name ?? string.Empty; } catch { }
            try { label6.Text = _products.ElementAtOrDefault(2)?.Name ?? string.Empty; } catch { }
            try { label7.Text = _products.ElementAtOrDefault(3)?.Name ?? string.Empty; } catch { }

            try { label13.Text = FormatPrice(_products.ElementAtOrDefault(0)?.Price); } catch { }
            try { label14.Text = FormatPrice(_products.ElementAtOrDefault(1)?.Price); } catch { }
            try { label15.Text = FormatPrice(_products.ElementAtOrDefault(2)?.Price); } catch { }
            try { label16.Text = FormatPrice(_products.ElementAtOrDefault(3)?.Price); } catch { }

            if (pictureBox8 != null) pictureBox8.Tag = _products.ElementAtOrDefault(0);
            if (pictureBox9 != null) pictureBox9.Tag = _products.ElementAtOrDefault(1);
            if (pictureBox10 != null) pictureBox10.Tag = _products.ElementAtOrDefault(2);
            if (pictureBox11 != null) pictureBox11.Tag = _products.ElementAtOrDefault(3);
        }

        private void WireEvents()
        {
            if (listBox2 != null) { listBox2.DoubleClick -= listBox2_DoubleClick; listBox2.DoubleClick += listBox2_DoubleClick; }
            if (listBoxCart != null) { listBoxCart.DoubleClick -= listBoxCart_DoubleClick; listBoxCart.DoubleClick += listBoxCart_DoubleClick; }
            if (button2 != null) { button2.Click -= button2_Click; button2.Click += button2_Click; }
            if (button1 != null) { button1.Click -= button1_Click; button1.Click += button1_Click; }
            if (button3 != null) { button3.Click -= button3_Click; button3.Click += button3_Click; }
            if (button4 != null) { button4.Click -= button4_Click; button4.Click += button4_Click; }

            if (pictureBox8 != null) { pictureBox8.Click -= pictureBox8_Click; pictureBox8.Click += pictureBox8_Click; }
            if (pictureBox9 != null) { pictureBox9.Click -= pictureBox9_Click; pictureBox9.Click += pictureBox9_Click; }
            if (pictureBox10 != null) { pictureBox10.Click -= pictureBox10_Click_1; pictureBox10.Click += pictureBox10_Click_1; }
            if (pictureBox11 != null) { pictureBox11.Click -= pictureBox11_Click; pictureBox11.Click += pictureBox11_Click; }

            if (linkLabel1 != null) { linkLabel1.Click -= linkLabel1_Click; linkLabel1.Click += linkLabel1_Click; }

            if (txtFirstName != null) { txtFirstName.Leave -= ShippingField_Leave; txtFirstName.Leave += ShippingField_Leave; }
            if (txtLastName != null) { txtLastName.Leave -= ShippingField_Leave; txtLastName.Leave += ShippingField_Leave; }
            if (txtAddress != null) { txtAddress.Leave -= ShippingField_Leave; txtAddress.Leave += ShippingField_Leave; }

            if (btnGcash != null) { btnGcash.Click -= BtnGcash_Click; btnGcash.Click += BtnGcash_Click; }
            if (btnConfirm != null) { btnConfirm.Click -= BtnConfirm_Click; btnConfirm.Click += BtnConfirm_Click; }
            if (btnCancelOrder != null) { btnCancelOrder.Click -= BtnCancelOrder_Click; btnCancelOrder.Click += BtnCancelOrder_Click; }
            if (btnNeedHelp != null) { btnNeedHelp.Click -= BtnNeedHelp_Click; btnNeedHelp.Click += BtnNeedHelp_Click; }

            // wire history grid if present (created in LoadHistoryStructured)
            if (dgvHistory != null) { dgvHistory.CellMouseDown -= DgvHistory_CellMouseDown; dgvHistory.CellMouseDown += DgvHistory_CellMouseDown; }
        }

        private static string FormatPrice(decimal? price) => price.HasValue ? $"₱{price.Value:N2}" : string.Empty;

        // allow null product (caller may pass ElementAtOrDefault)
        private void AddToCart(Product? product)
        {
            if (product == null) { MessageBox.Show("Product not available.", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var exists = _cart.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (exists is not null) { _cart.Remove(exists); _cart.Add(new CartItem(product, exists.Quantity + 1)); }
            else { _cart.Add(new CartItem(product, 1)); }

            try
            {
                var line = $"CartAdd|{DateTime.Now:O}|{product.Id}|{product.Name}|{FormatPrice(product.Price)}|Qty|1";
                File.AppendAllLines(_ordersFile, new[] { line });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write cart entry: " + ex.Message, "IO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            UpdateCartList();
            UpdateTotalsUI();
        }

        private void UpdateCartList()
        {
            if (listBoxCart == null) return;
            listBoxCart.Items.Clear();
            foreach (var ci in _cart) listBoxCart.Items.Add($"{ci.Quantity} x {ci.Product.Name} - {FormatPrice(ci.Product.Price)}");

            try
            {
                if (_cart.Count == 0) label2.Text = "Explore our specialized wellness departments ";
                else
                {
                    var total = _cart.Sum(c => c.Product.Price * c.Quantity);
                    label2.Text = $"Cart: {_cart.Sum(c => c.Quantity)} items • Total {FormatPrice(total)}";
                }
            }
            catch { }
        }

        private (decimal subtotal, decimal shipping, decimal tax, decimal total) ComputeTotals()
        {
            var subtotal = _cart.Sum(c => c.Product.Price * c.Quantity);
            var shipping = subtotal > 1000m || subtotal == 0m ? 0m : 50m;
            var tax = Math.Round(subtotal * 0.12m, 2);
            var total = subtotal + shipping + tax;
            return (subtotal, shipping, tax, total);
        }

        private void UpdateTotalsUI()
        {
            var (subtotal, shipping, tax, total) = ComputeTotals();
            if (lblSubtotal != null) lblSubtotal.Text = FormatPrice(subtotal);
            if (lblShipping != null) lblShipping.Text = FormatPrice(shipping);
            if (lblTax != null) lblTax.Text = FormatPrice(tax);
            if (lblTotal != null) lblTotal.Text = FormatPrice(total);
            if (lblOrderTotalBelow != null) lblOrderTotalBelow.Text = FormatPrice(total);
        }

        private void BtnConfirm_Click(object sender, EventArgs e) => ConfirmAndPlaceOrder();

        private void ConfirmAndPlaceOrder()
        {
            if (_cart.Count == 0) { MessageBox.Show("Your cart is empty.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var first = txtFirstName?.Text?.Trim() ?? string.Empty;
            var last = txtLastName?.Text?.Trim() ?? string.Empty;
            var address = txtAddress?.Text?.Trim() ?? string.Empty;

            var confirm = MessageBox.Show("Confirm payment and place order?", "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var tracking = "TRK-" + Guid.NewGuid().ToString("N").Substring(0, 10).ToUpperInvariant();
            var timestamp = DateTime.Now;

            try
            {
                using var sw = new StreamWriter(_ordersFile, append: true);
                sw.WriteLine($"Order|{timestamp:O}|Tracking:{tracking}|Status:Order Placed|FirstName:{first}|LastName:{last}|Address:{address}");
                foreach (var ci in _cart) sw.WriteLine($"{ci.Quantity}x|{ci.Product.Id}|{ci.Product.Name}|{FormatPrice(ci.Product.Price)}");
                sw.WriteLine("EndOrder");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save order: " + ex.Message, "IO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblOrderNumber != null) lblOrderNumber.Text = tracking;
            if (lblOrderStatus != null) { lblOrderStatus.Items.Clear(); lblOrderStatus.Items.Add("Order Placed"); }

            SaveProfile();
            LoadHistoryStructured();
            _cart.Clear();
            UpdateCartList();
            UpdateTotalsUI();

            MessageBox.Show($"Order placed. Tracking: {tracking}", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGcash_Click(object sender, EventArgs e)
        {
            try { var url = "https://www.gcash.com"; Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
            catch (Exception ex) { MessageBox.Show("Unable to open GCash: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) { MessageBox.Show("No active cart to cancel.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            var ok = MessageBox.Show("Cancel current cart (remove items)?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;
            _cart.Clear();
            UpdateCartList();
            UpdateTotalsUI();
            MessageBox.Show("Order cancelled (cart cleared).", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnNeedHelp_Click(object sender, EventArgs e)
        {
            try { var url = "https://www.watsons.com.ph/customer-support"; Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
            catch (Exception ex) { MessageBox.Show("Unable to open support page: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void SaveProfile()
        {
            try
            {
                var lines = new List<string>
                {
                    $"FirstName={txtFirstName?.Text?.Trim() ?? string.Empty}",
                    $"LastName={txtLastName?.Text?.Trim() ?? string.Empty}",
                    $"Address={txtAddress?.Text?.Trim() ?? string.Empty}"
                };
                File.WriteAllLines(_profileFile, lines);
            }
            catch { /* ignore */ }
        }

        private void LoadProfile()
        {
            try
            {
                if (!File.Exists(_profileFile)) return;
                var lines = File.ReadAllLines(_profileFile);
                var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var rawLine in lines)
                {
                    var idx = rawLine.IndexOf('=');
                    if (idx > 0) { var k = rawLine.Substring(0, idx).Trim(); var v = rawLine.Substring(idx + 1).Trim(); dict[k] = v; }
                }

                if (txtFirstName != null && dict.TryGetValue("FirstName", out var fn)) txtFirstName.Text = fn;
                if (txtLastName != null && dict.TryGetValue("LastName", out var lastNameVal)) txtLastName.Text = lastNameVal;
                if (txtAddress != null && dict.TryGetValue("Address", out var addrVal)) txtAddress.Text = addrVal;
            }
            catch { /* ignore */ }
        }

        private void ShippingField_Leave(object sender, EventArgs e) => SaveProfile();

        // ---------- History: structured parsing, grid, status update ----------
        private void LoadHistoryStructured()
        {
            _ordersHistory.Clear();

                // ensure runtime grid exists (create if designer doesn't have one)
            EnsureHistoryGrid();

            if (dgvHistory == null) return;
            dgvHistory.Rows.Clear();

            if (!File.Exists(_ordersFile)) return;

            var lines = File.ReadAllLines(_ordersFile);
            Order? current = null;
            List<string>? items = null;

            foreach (var raw in lines)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                var line = raw.Trim();

                if (line.StartsWith("Order|", StringComparison.Ordinal))
                {
                    // parse header tokens
                    var parts = line.Split('|', StringSplitOptions.None);
                    DateTime ts = DateTime.MinValue;
                    if (parts.Length >= 2) DateTime.TryParse(parts[1], out ts);

                    string tracking = "N/A", status = "Unknown", first = "", last = "", addr = "";
                    foreach (var token in parts.Skip(2))
                    {
                        if (token.StartsWith("Tracking:", StringComparison.OrdinalIgnoreCase)) tracking = token.Substring("Tracking:".Length);
                        else if (token.StartsWith("Status:", StringComparison.OrdinalIgnoreCase)) status = token.Substring("Status:".Length);
                        else if (token.StartsWith("FirstName:", StringComparison.OrdinalIgnoreCase)) first = token.Substring("FirstName:".Length);
                        else if (token.StartsWith("LastName:", StringComparison.OrdinalIgnoreCase)) last = token.Substring("LastName:".Length);
                        else if (token.StartsWith("Address:", StringComparison.OrdinalIgnoreCase)) addr = token.Substring("Address:".Length);
                    }

                    items = new List<string>();
                    current = new Order(tracking, ts == DateTime.MinValue ? DateTime.Now : ts, status, first, last, addr, items);
                    continue;
                }

                if (line == "EndOrder")
                {
                    if (current != null)
                    {
                        _ordersHistory.Add(current);
                        // add row to grid
                        var itemsSummary = string.Join(", ", current.Items.Take(3));
                        var total = ComputeOrderTotal(current);
                        dgvHistory.Rows.Add(current.Tracking, current.Timestamp.ToString("g"), current.Status, $"{current.FirstName} {current.LastName}".Trim(), current.Address, itemsSummary, FormatPrice(total));
                    }
                    current = null;
                    items = null;
                    continue;
                }

                if (current != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 4)
                    {
                        // store raw item line for later detail parsing
                        current.Items.Add(line);
                    }
                }
            }
        }

        // create DataGridView and context menu if designer doesn't include dgvHistory
        private void EnsureHistoryGrid()
        {
            if (dgvHistory != null) return;

            // try find existing by name first (designer might have it)
            var found = Controls.Find("dgvHistory", true).FirstOrDefault() as DataGridView;
            if (found != null) { dgvHistory = found; SetupHistoryGrid(); return; }

            // create at runtime and place into tabPage4
            dgvHistory = new DataGridView
            {
                Name = "dgvHistory",
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };

            dgvHistory.Columns.Add("colTracking", "Order#");
            dgvHistory.Columns.Add("colDate", "Date");
            dgvHistory.Columns.Add("colStatus", "Status");
            dgvHistory.Columns.Add("colName", "Name");
            dgvHistory.Columns.Add("colAddress", "Address");
            dgvHistory.Columns.Add("colItems", "Items");
            dgvHistory.Columns.Add("colTotal", "Total");

            // add grid to history tab (tabPage4 is designer field)
            try
            {
                tabPage4.Controls.Clear();
                tabPage4.Controls.Add(dgvHistory);
            }
            catch
            {
                // fallback: add to form root
                Controls.Add(dgvHistory);
            }

            SetupHistoryGrid();
        }

        private void SetupHistoryGrid()
        {
            // build context menu if missing
            ctxHistory ??= new ContextMenuStrip();
            ctxHistory.Items.Clear();
            ctxHistory.Items.Add("Mark Preparing").Click += (s, e) => UpdateSelectedOrderStatus("Preparing");
            ctxHistory.Items.Add("Mark In Transit").Click += (s, e) => UpdateSelectedOrderStatus("In Transit");
            ctxHistory.Items.Add("Mark Delivered").Click += (s, e) => UpdateSelectedOrderStatus("Delivered");
            ctxHistory.Items.Add("Cancel Order").Click += (s, e) => UpdateSelectedOrderStatus("Cancelled");

            dgvHistory.ContextMenuStrip = ctxHistory;
            dgvHistory.CellMouseDown -= DgvHistory_CellMouseDown;
            dgvHistory.CellMouseDown += DgvHistory_CellMouseDown;
        }

        // show context menu on right-click row
        private void DgvHistory_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.RowIndex < 0) return;
            dgvHistory?.ClearSelection();
            if (dgvHistory != null && e.RowIndex < dgvHistory.Rows.Count)
            {
                dgvHistory.Rows[e.RowIndex].Selected = true;
                dgvHistory.CurrentCell = dgvHistory.Rows[e.RowIndex].Cells[0];
            }
        }

        // update selected order status in memory and persist to file
        private void UpdateSelectedOrderStatus(string newStatus)
        {
            if (dgvHistory == null) return;
            if (dgvHistory.SelectedRows.Count == 0) return;
            var row = dgvHistory.SelectedRows[0];
            var tracking = row.Cells["colTracking"].Value?.ToString();
            if (string.IsNullOrEmpty(tracking)) return;

            // persist status change into orders.txt
            try
            {
                UpdateOrderStatusInFile(tracking, newStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update order status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // refresh structured history and grid
            LoadHistoryStructured();
        }

        // Replace or append Status token in the Order header line for the order with the given tracking id
        private void UpdateOrderStatusInFile(string tracking, string newStatus)
        {
            var lines = File.Exists(_ordersFile) ? File.ReadAllLines(_ordersFile).ToList() : new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if (!line.StartsWith("Order|", StringComparison.Ordinal)) continue;
                if (!line.Contains($"Tracking:{tracking}")) continue;

                // split tokens and replace or insert Status:
                var parts = line.Split('|').ToList();
                var statusIndex = parts.FindIndex(p => p.StartsWith("Status:", StringComparison.OrdinalIgnoreCase));
                var newToken = "Status:" + newStatus;
                if (statusIndex >= 0) parts[statusIndex] = newToken;
                else
                {
                    // insert after Tracking token if present
                    var trackIdx = parts.FindIndex(p => p.StartsWith("Tracking:", StringComparison.OrdinalIgnoreCase));
                    if (trackIdx >= 0) parts.Insert(trackIdx + 1, newToken);
                    else parts.Add(newToken);
                }

                lines[i] = string.Join("|", parts);
                // write back and return
                File.WriteAllLines(_ordersFile, lines);
                return;
            }

            // if we reach here, matching order header not found — nothing done
        }

        // compute total for an Order by parsing its item lines (items stored as "2x|id|name|₱123.45")
        private decimal ComputeOrderTotal(Order order)
        {
            decimal total = 0m;
            foreach (var raw in order.Items)
            {
                var parts = raw.Split('|');
                if (parts.Length < 4) continue;
                var qtyToken = parts[0]; // e.g., "2x"
                var priceToken = parts[3]; // e.g., "₱1249.00"
                int qty = 1;
                if (qtyToken.EndsWith("x", StringComparison.OrdinalIgnoreCase))
                    int.TryParse(qtyToken[0..^1], out qty);
                total += ParsePriceToken(priceToken) * qty;
            }
            return total;
        }

        private static decimal ParsePriceToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return 0m;
            var cleaned = token.Replace("₱", "").Replace(",", "").Trim();
            if (decimal.TryParse(cleaned, NumberStyles.Number | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var d))
                return d;
            return 0m;
        }

        // Keep existing browse/order handlers and no-op stubs unchanged below...
        private void label1_Click(object sender, EventArgs e) { if (listBox2 != null && listBox2.Items.Count > 0) tabControl1.SelectedTab = tabPage2; }
        private void linkLabel1_Click(object sender, EventArgs e) { tabControl1.SelectedTab = tabPage2; PopulateCategoriesListBox(); }
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2 == null) return;
            if (listBox2.SelectedItem is not ListBoxItem lbi) return;
            if (lbi.Value is string s && s == "__back") { PopulateCategoriesListBox(); return; }
            if (listBox2.Tag is string tag && tag.StartsWith("categories")) { if (lbi.Value is string category) PopulateProductsListBox(category); return; }
            if (listBox2.Tag is string ptag && ptag.StartsWith("products")) { if (lbi.Value is Product prod) { AddToCart(prod); MessageBox.Show($"Added {prod.Name} to cart.", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information); } }
        }

        private void pictureBox8_Click(object sender, EventArgs e) { PictureBoxClickHandler(sender); }
        private void pictureBox9_Click(object sender, EventArgs e) { PictureBoxClickHandler(sender); }
        private void pictureBox10_Click_1(object sender, EventArgs e) { PictureBoxClickHandler(sender); }
        private void pictureBox11_Click(object sender, EventArgs e) { PictureBoxClickHandler(sender); }
        private void PictureBoxClickHandler(object sender) { if (sender is PictureBox pb && pb.Tag is Product p) MessageBox.Show($"{p.Name}\nCategory: {p.Category}\nPrice: {FormatPrice(p.Price)}", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information); else MessageBox.Show("Product image clicked.", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void label13_Click(object sender, EventArgs e) { MessageBox.Show("Price information shown on hover. Use Add to Cart to purchase.", "Price", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void button2_Click(object sender, EventArgs e) { AddToCart(_products.ElementAtOrDefault(0)); }
        private void button1_Click(object sender, EventArgs e) { AddToCart(_products.ElementAtOrDefault(1)); }
        private void button3_Click(object sender, EventArgs e) { AddToCart(_products.ElementAtOrDefault(2)); }
        private void button4_Click(object sender, EventArgs e) { AddToCart(_products.ElementAtOrDefault(3)); }

        private void listBoxCart_DoubleClick(object sender, EventArgs e)
        {
            var idx = listBoxCart.SelectedIndex;
            if (idx >= 0 && idx < _cart.Count)
            {
                var ci = _cart[idx];
                var result = MessageBox.Show($"Change quantity or remove '{ci.Product.Name}'?\nYes = Increase, No = Decrease, Cancel = Remove", "Modify Cart", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { _cart.RemoveAt(idx); _cart.Insert(idx, new CartItem(ci.Product, ci.Quantity + 1)); }
                else if (result == DialogResult.No) { if (ci.Quantity > 1) { _cart.RemoveAt(idx); _cart.Insert(idx, new CartItem(ci.Product, ci.Quantity - 1)); } else _cart.RemoveAt(idx); }
                else _cart.RemoveAt(idx);
                UpdateCartList(); UpdateTotalsUI(); return;
            }
            ConfirmAndPlaceOrder();
        }

        // Remaining no-op designer stubs
        private void label3_Click(object sender, EventArgs e) { }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void label26_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void label31_Click(object sender, EventArgs e) { }
        private void label46_Click(object sender, EventArgs e) { }
        private void label62_Click(object sender, EventArgs e) { }
        private void label98_Click(object sender, EventArgs e) { }
        private void label99_Click(object sender, EventArgs e) { }
        private void label100_Click(object sender, EventArgs e) { }
    }
}
