namespace Vehical_Rental_Management_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        ///  Flow: LoginForm → Dashboard (Form2) → module forms → logout → LoginForm
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using var login = new LoginForm();
                if (login.ShowDialog() != DialogResult.OK)
                    break;

                var dashboard = new Form2(login.LoggedInUser, login.LoggedInRole);
                Application.Run(dashboard);

                bool logout = dashboard.DialogResult == DialogResult.Retry;
                dashboard.Dispose();

                if (!logout)
                    break;
            }
        }
    }
}