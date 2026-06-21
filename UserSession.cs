namespace Vehical_Rental_Management_System
{
    /// <summary>
    /// Holds the currently logged-in user for the whole application session.
    /// Set by LoginForm after successful authentication.
    /// </summary>
    internal static class UserSession
    {
        public static string Username { get; private set; } = string.Empty;
        public static string Role     { get; private set; } = string.Empty;
        public static bool   IsLoggedIn => !string.IsNullOrEmpty(Username);

        public static void Set(string username, string role)
        {
            Username = username;
            Role     = role;
        }

        public static void Clear()
        {
            Username = string.Empty;
            Role     = string.Empty;
        }
    }
}
