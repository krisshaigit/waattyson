using System;

namespace adminstaffff
{
    public class Rider
    {
        public string RiderID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }

    public class Delivery
    {
        public string OrderID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string OrderedItems { get; set; }
        public string Status { get; set; }
        public string AssignedDate { get; set; }
        public string VerificationCode { get; set; }
        public string DeliveryNotes { get; set; }
    }

    public class RiderNotification
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
    }
}