namespace Vehical_Rental_Management_System
{

    public sealed class PaymentRequest
    {
        public int     RentalID     { get; init; }
        public string  Customer     { get; init; } = string.Empty;
        public string  Vehicle      { get; init; } = string.Empty;
        public string  Period       { get; init; } = string.Empty;
        public decimal BaseAmount   { get; init; }
        public int     OverdueDays  { get; init; }
        public decimal PenaltyRate  { get; init; }
        public decimal LatePenalty  { get; init; }
        public decimal TotalDue     { get; init; }
        public decimal Discount     { get; init; }
        public decimal FinalAmount  { get; init; }
    }
}
