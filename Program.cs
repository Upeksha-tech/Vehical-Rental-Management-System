namespace Vehical_Rental_Management_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var login = new LoginForm())
                {
                    // Show login dialog
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break; // Exit application if user cancelled or closed login form
                    }

                    // Create and run the dashboard
                    using (var dashboard = new Form2(login.LoggedInUser, login.LoggedInRole))
                    {
                        Application.Run(dashboard);

                        // If user closed dashboard but set DialogResult to Retry (indicating logout), loop back to Login.
                        // Otherwise, exit the application.
                        if (dashboard.DialogResult != DialogResult.Retry)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}