using System;

namespace Vehical_Rental_Management_System
{

    public class Payment
    {
        public int     PaymentID    { get; set; }
        public int     RentalID     { get; set; }
        public string  Customer     { get; set; } = string.Empty;
        public string  Vehicle      { get; set; } = string.Empty;
        public string  Period       { get; set; } = string.Empty;
        public decimal BaseAmount   { get; set; }
        public int     OverdueDays  { get; set; }
        public decimal PenaltyRate  { get; set; }
        public decimal LatePenalty  { get; set; }
        public decimal TotalDue     { get; set; }
        public decimal Discount     { get; set; }
        public decimal FinalAmount  { get; set; }
        public string  Method       { get; set; } = string.Empty;
        public DateTime PayDate     { get; set; } = DateTime.Today;
        public string  Reference    { get; set; } = string.Empty;
    }
}
