using System;

namespace adminstaffff
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } = "Not Set";
        public string ContactNumber { get; set; } = "Not Set";
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class Order
    {
        public string OrderId { get; set; }
        public string Username { get; set; }

        public string Items { get; set; }
        public decimal Total { get; set; }

        public string Status { get; set; }
        public string Date { get; set; }

        // --- UI BINDING GLUE ---
        public string ItemDetails => Items ?? ""; // Prevents grid crashes if items are blank
        public decimal TotalPrice => Total;
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }

    public class Notification
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string Type { get; set; } // Order, Promotion, Alert
        public string Date { get; set; }
    }
}