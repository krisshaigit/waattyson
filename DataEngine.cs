using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

        // SQLite connection path definition
        private static readonly string DbConnectionPath = "Data Source=watson_shop.db;Version=3;";

        // Text File Fallbacks for initial migration
        private static readonly string UsersFile = "users.txt";
        private static readonly string ProductsFile = "products.txt";

        public static void InitializeDatabase()
        {
            try
            {
                // 1. Physically create the database file if it was deleted
                if (!File.Exists("watson_shop.db"))
                {
                    SQLiteConnection.CreateFile("watson_shop.db");
                }

                using (var connection = new SQLiteConnection(DbConnectionPath))
                {
                    connection.Open();

                    // 2. Fallback Drop & Recreate to guarantee the 'Items' column exists cleanly
                    string checkAndFixOrdersTable = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    OrderId TEXT PRIMARY KEY,
                    Username TEXT,
                    Items TEXT,
                    Total REAL,
                    Status TEXT,
                    Date TEXT
                );";

                    // If an old Orders table exists without 'Items', add it safely on the fly
                    using (var verifyCmd = new SQLiteCommand("PRAGMA table_info(Orders);", connection))
                    using (var reader = verifyCmd.ExecuteReader())
                    {
                        bool hasItemsColumn = false;
                        while (reader.Read())
                        {
                            if (reader["name"].ToString().Equals("Items", StringComparison.OrdinalIgnoreCase))
                            {
                                hasItemsColumn = true;
                                break;
                            }
                        }

                        // If table exists but lacks the column, drop it so it can recreate seamlessly
                        if (!hasItemsColumn)
                        {
                            using (var dropCmd = new SQLiteCommand("DROP TABLE IF EXISTS Orders;", connection))
                            {
                                dropCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    string createProductsTable = @"
                CREATE TABLE IF NOT EXISTS Products (
                    ProductId TEXT PRIMARY KEY,
                    Name TEXT,
                    Category TEXT,
                    Price REAL,
                    Stock INTEGER
                );";

                    string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Username TEXT PRIMARY KEY,
                    Password TEXT,
                    Role TEXT,
                    Name TEXT,
                    Address TEXT,
                    ContactNumber TEXT
                );";

                    using (var cmd = new SQLiteCommand(checkAndFixOrdersTable, connection)) { cmd.ExecuteNonQuery(); }
                    using (var cmd = new SQLiteCommand(createProductsTable, connection)) { cmd.ExecuteNonQuery(); }
                    using (var cmd = new SQLiteCommand(createUsersTable, connection)) { cmd.ExecuteNonQuery(); }

                    // 3. Populate empty tables via migrations
                    string productCountQuery = "SELECT COUNT(*) FROM Products;";
                    long productCount = 0;
                    using (var countCmd = new SQLiteCommand(productCountQuery, connection))
                    {
                        productCount = (long)countCmd.ExecuteScalar();
                    }

                    if (productCount == 0)
                    {
                        MigrateProductsFromTextFile(connection);
                    }

                    string userCountQuery = "SELECT COUNT(*) FROM Users;";
                    long userCount = 0;
                    using (var countCmd = new SQLiteCommand(userCountQuery, connection))
                    {
                        userCount = (long)countCmd.ExecuteScalar();
                    }

                    if (userCount == 0)
                    {
                        MigrateUsersFromTextFile(connection);
                    }
                }

                // Sync local cache lists from storage
                LoadData();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Database Initialization Error: {ex.Message}", "SQL Initializer Crash", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void LoadData()
        {
            try
            {
                using (var connection = new SQLiteConnection(DbConnectionPath))
                {
                    connection.Open();

                    // --- READ PRODUCTS ---
                    Products.Clear();
                    string readProducts = "SELECT ProductId, Name, Category, Price, Stock FROM Products;";
                    using (var cmd = new SQLiteCommand(readProducts, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products.Add(new Product
                            {
                                ProductId = reader["ProductId"].ToString(),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"])
                            });
                        }
                    }

                    // --- READ ORDERS ---
                    Orders.Clear();
                    string readOrders = "SELECT OrderId, Username, Items, Total, Status, Date FROM Orders;";
                    using (var cmd = new SQLiteCommand(readOrders, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders.Add(new Order
                            {
                                OrderId = reader["OrderId"].ToString(),
                                Username = reader["Username"].ToString(),
                                Items = reader["Items"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"]),
                                Status = reader["Status"].ToString(),
                                Date = reader["Date"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error loading records via SQLite: {ex.Message}");
            }
        }

        // Saves all runtime list orders into SQLite
        public static void SaveOrders()
        {
            try
            {
                using (var connection = new SQLiteConnection(DbConnectionPath))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (var o in Orders)
                        {
                            string insertOrReplaceQuery = @"
                                INSERT OR REPLACE INTO Orders (OrderId, Username, Items, Total, Status, Date)
                                VALUES (@OrderId, @Username, @Items, @Total, @Status, @Date);";

                            using (var cmd = new SQLiteCommand(insertOrReplaceQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", o.OrderId);
                                cmd.Parameters.AddWithValue("@Username", o.Username);
                                cmd.Parameters.AddWithValue("@Items", o.Items);
                                cmd.Parameters.AddWithValue("@Total", (double)o.Total);
                                cmd.Parameters.AddWithValue("@Status", o.Status);
                                cmd.Parameters.AddWithValue("@Date", o.Date);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"SQL Order Saving Failure: {ex.Message}");
            }
        }

        // Saves inventory data adjustments straight down to the SQL local file
        public static void SaveProducts()
        {
            try
            {
                using (var connection = new SQLiteConnection(DbConnectionPath))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (var p in Products)
                        {
                            string updateOrReplaceQuery = @"
                                INSERT OR REPLACE INTO Products (ProductId, Name, Category, Price, Stock)
                                VALUES (@ProductId, @Name, @Category, @Price, @Stock);";

                            using (var cmd = new SQLiteCommand(updateOrReplaceQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
                                cmd.Parameters.AddWithValue("@Name", p.Name);
                                cmd.Parameters.AddWithValue("@Category", p.Category);
                                cmd.Parameters.AddWithValue("@Price", (double)p.Price);
                                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"SQL Product Sync Failure: {ex.Message}");
            }
        }

        // NEW: Handles real-time User profile syncs safely to SQLite
        public static void SaveUsers()
        {
            try
            {
                if (CurrentUser == null) return;

                using (var connection = new SQLiteConnection(DbConnectionPath))
                {
                    connection.Open();
                    string insertOrReplaceUser = @"
                        INSERT OR REPLACE INTO Users (Username, Password, Role, Name, Address, ContactNumber)
                        VALUES (@Username, @Password, @Role, @Name, @Address, @ContactNumber);";

                    using (var cmd = new SQLiteCommand(insertOrReplaceUser, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", CurrentUser.Username);
                        cmd.Parameters.AddWithValue("@Password", CurrentUser.Password);
                        cmd.Parameters.AddWithValue("@Role", CurrentUser.Role);
                        cmd.Parameters.AddWithValue("@Name", CurrentUser.Name);
                        cmd.Parameters.AddWithValue("@Address", CurrentUser.Address);
                        cmd.Parameters.AddWithValue("@ContactNumber", CurrentUser.ContactNumber);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"SQL User Sync Failure: {ex.Message}");
            }
        }

        // --- MIGRATION SUB ROUTINES ---

        private static void MigrateProductsFromTextFile(SQLiteConnection connection)
        {
            if (!File.Exists(ProductsFile)) return;

            try
            {
                string[] lines = File.ReadAllLines(ProductsFile);
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split(',');
                        if (parts.Length >= 5)
                        {
                            string insertQuery = "INSERT OR IGNORE INTO Products (ProductId, Name, Category, Price, Stock) VALUES (@Id, @Name, @Cat, @Price, @Stock);";
                            using (var cmd = new SQLiteCommand(insertQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@Id", parts[0].Trim());
                                cmd.Parameters.AddWithValue("@Name", parts[1].Trim());
                                cmd.Parameters.AddWithValue("@Cat", parts[2].Trim());
                                cmd.Parameters.AddWithValue("@Price", double.Parse(parts[3].Trim()));
                                cmd.Parameters.AddWithValue("@Stock", int.Parse(parts[4].Trim()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error migrating products.txt data: {ex.Message}");
            }
        }

        private static void MigrateUsersFromTextFile(SQLiteConnection connection)
        {
            // Seed a fallback record if users.txt doesn't exist yet
            if (!File.Exists(UsersFile))
            {
                File.WriteAllLines(UsersFile, new[] { "customer1,password123,Customer,Jane Doe,123 Main St Manila,09171234567" });
            }

            try
            {
                string[] lines = File.ReadAllLines(UsersFile);
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split(',');
                        if (parts.Length >= 6)
                        {
                            string insertQuery = "INSERT OR IGNORE INTO Users (Username, Password, Role, Name, Address, ContactNumber) VALUES (@User, @Pass, @Role, @Name, @Address, @Contact);";
                            using (var cmd = new SQLiteCommand(insertQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@User", parts[0].Trim());
                                cmd.Parameters.AddWithValue("@Pass", parts[1].Trim());
                                cmd.Parameters.AddWithValue("@Role", parts[2].Trim());
                                cmd.Parameters.AddWithValue("@Name", parts[3].Trim());
                                cmd.Parameters.AddWithValue("@Address", parts[4].Trim());
                                cmd.Parameters.AddWithValue("@Contact", parts[5].Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error migrating users.txt data: {ex.Message}");
            }
        }
    }
}