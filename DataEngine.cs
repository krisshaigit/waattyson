using System;
using System.Collections.Generic;
using System.IO;

namespace adminstaffff
{
    public static class DataEngine
    {
        // Global runtime memory storage
        public static User CurrentUser;
        public static List<Product> Products = new List<Product>();
        public static List<Order> Orders = new List<Order>();
        public static List<Notification> Notifications = new List<Notification>();
        public static List<CartItem> Cart = new List<CartItem>();

        // Text File paths
        private static readonly string UsersFile = "users.txt";
        private static readonly string ProductsFile = "products.txt";
        private static readonly string OrdersFile = "orders.txt";
        private static readonly string NotificationsFile = "notifications.txt";

        public static void InitializeDatabase()
        {
            try
            {
                // Ensure files exist and seed them with mock retail data if empty
                if (!File.Exists(UsersFile)) File.WriteAllLines(UsersFile, new[] { "customer1,password123,Customer,Jane Doe,123 Main St Manila,09171234567" });

                if (!File.Exists(ProductsFile))
                {
                    File.WriteAllLines(ProductsFile, new[] {
                        // Format: ProductId, Name, Category, Price, Stock
                        // FRAGRANCE (7 Items)
                        "F001,Penshoppe Signature Body Spray,Fragrance,150.00,45",
                        "F002,Jo Malone English Pear & Freesia,Fragrance,4500.00,12",
                        "F003,Victoria's Secret Bombshell EDP,Fragrance,3200.00,15",
                        "F004,Bench Daily Scent Nine to Mine,Fragrance,85.00,60",
                        "F005,Versace Bright Crystal EDT,Fragrance,4000.00,10",
                        "F006,Dior Sauvage Eau de Parfum,Fragrance,6500.00,8",
                        "F007,Chanel No. 5 Eau de Parfum,Fragrance,7500.00,5",

                        // BABY CARE (7 Items)
                        "B001,Baby Care Plus+ Baby Shampoo,Baby Care,220.00,30",
                        "B002,Tender Care Baby Powder Pink Soft,Baby Care,95.00,120",
                        "B003,Tender Care Classic Baby Wash,Baby Care,160.00,80",
                        "B004,Avon Care Baby Moisturizing Lotion,Baby Care,185.00,65",
                        "B005,Johnson's Baby Skincare Wipes,Baby Care,120.00,90",
                        "B006,Johnson's Baby Oil Classic,Baby Care,140.00,75",
                        "B007,Desitin Diaper Rash Ointment,Baby Care,350.00,40",

                        // MEDICINE (7 Items)
                        "M001,Decolgen Forte Cold Relief Tablet,Medicine,8.00,500",
                        "M002,Advil Ibuprofen 200mg Softgel,Medicine,12.00,350",
                        "M003,Biogesic Paracetamol 500mg,Medicine,6.00,600",
                        "M004,Neozep Forte Cold Tablet,Medicine,7.00,450",
                        "M005,Solmux Carbocisteine 500mg,Medicine,11.00,300",
                        "M006,Gaviscon Double Action Sachet,Medicine,35.00,150",
                        "M007,Vitamin B-Complex Bextran Tablet,Medicine,10.00,400",

                        // PERSONAL CARE (7 Items)
                        "P001,Colgate Total Toothpaste,Personal Care,145.00,110",
                        "P002,Safeguard Pure White Bar Soap,Personal Care,48.00,200",
                        "P003,Cream Silk Hair Conditioner 180ml,Personal Care,180.00,85",
                        "P004,Head & Shoulders Shampoo 330ml,Personal Care,250.00,70",
                        "P005,Nivea Extra White Body Lotion,Personal Care,290.00,55",
                        "P006,Rexona Men Ice Cool Spray,Personal Care,190.00,95",
                        "P007,Biore Facial Foam Deep Cleanse,Personal Care,210.00,65",

                        // MAKE UP (7 Items)
                        "U001,Maybelline Hypercurl Mascara,Make Up,299.00,50",
                        "U002,Maybelline Fit Me Foundation,Make Up,449.00,35",
                        "U003,Ever Bilena Matte Lipstick,Make Up,185.00,80",
                        "U004,Careline Graph-Ink Eyeliner,Make Up,220.00,65",
                        "U005,Vice Cosmetics Aura Blush,Make Up,195.00,70",
                        "U006,BLK Cosmetics Skin Tint,Make Up,499.00,25",
                        "U007,Detail Cosmetics Lip Oil,Make Up,249.00,40"
                    });
                }

                if (!File.Exists(OrdersFile)) File.WriteAllText(OrdersFile, "");
                if (!File.Exists(NotificationsFile)) File.WriteAllLines(NotificationsFile, new[] {
                    "customer1,Welcome to Watsons! Enjoy 10% off your first checkout.,Promotion,2026-05-18"
                });

                // Load database files directly into memory lists
                LoadData();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Database Initialization Error: {ex.Message}");
            }
        }

        public static void LoadData()
        {
            Products.Clear();
            foreach (var line in File.ReadAllLines(ProductsFile))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    Products.Add(new Product
                    {
                        ProductId = parts[0].Trim(),
                        Name = parts[1].Trim(),
                        Category = parts[2].Trim(),
                        Price = decimal.Parse(parts[3]),
                        Stock = int.Parse(parts[4])
                    });
                }
            }

            Orders.Clear();
            foreach (var line in File.ReadAllLines(OrdersFile))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length >= 6)
                    Orders.Add(new Order { OrderId = parts[0], Username = parts[1], Items = parts[2], Total = decimal.Parse(parts[3]), Status = parts[4], Date = parts[5] });
            }

            Notifications.Clear();
            foreach (var line in File.ReadAllLines(NotificationsFile))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length >= 4)
                    Notifications.Add(new Notification { Username = parts[0], Message = parts[1], Type = parts[2], Date = parts[3] });
            }
        }

        public static void SaveUsers()
        {
            if (CurrentUser != null)
            {
                string line = $"{CurrentUser.Username},{CurrentUser.Password},{CurrentUser.Role},{CurrentUser.Name},{CurrentUser.Address},{CurrentUser.ContactNumber}";
                File.WriteAllLines(UsersFile, new[] { line });
            }
        }

        public static void SaveOrders()
        {
            List<string> lines = new List<string>();
            foreach (var o in Orders)
            {
                lines.Add($"{o.OrderId},{o.Username},{o.Items},{o.Total},{o.Status},{o.Date}");
            }
            File.WriteAllLines(OrdersFile, lines);
        }

        public static void SaveProducts()
        {
            List<string> lines = new List<string>();
            foreach (var p in Products)
            {
                lines.Add($"{p.ProductId},{p.Name},{p.Category},{p.Price},{p.Stock}");
            }
            File.WriteAllLines(ProductsFile, lines);
        }
    }
}