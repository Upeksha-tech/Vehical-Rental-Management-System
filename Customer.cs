using System;

namespace Vehical_Rental_Management_System
{
    // =====================================================================
    // DATA TIER: Customer Entity Model
    // =====================================================================
    public class Customer
    {
        public int      CustomerID     { get; set; }
        public string   FullName       { get; set; } = string.Empty;
        public string   NIC            { get; set; } = string.Empty;
        public string   Phone          { get; set; } = string.Empty;
        public string   LicenseNo      { get; set; } = string.Empty;
        public string   Address        { get; set; } = string.Empty;
        public DateTime DateRegistered { get; set; } = DateTime.Today;
        public int      ActiveRentals  { get; set; } = 0;
    }
}
