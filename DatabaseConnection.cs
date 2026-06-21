namespace Vehical_Rental_Management_System
{

    internal static class DatabaseConnection
    {
        public const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=VehicleRentalDB;" +
            "Uid=root;" +
            "Pwd=;" +
            "Connect Timeout=10;" +
            "SslMode=Disabled;";
    }
}
