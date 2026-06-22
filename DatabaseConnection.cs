namespace Vehical_Rental_Management_System
{
    /// <summary>
    /// Shared XAMPP MySQL connection settings for the whole application.
    /// Server: localhost:3306 | Database: VehicleRentalDB | User: root (default XAMPP)
    /// </summary>
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
