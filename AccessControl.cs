using System.Linq;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{
    internal enum AppModule
    {
        Vehicles,
        Customers,
        Booking,
        Return,
        Payments,
        Reports
    }

    internal enum AccessLevel
    {
        None,
        ReadOnly,
        Full
    }

    /// <summary>
    /// Role-based access control for all modules.
    /// Roles: Manager, Staff (must match login + MySQL users.role).
    /// Manager: Full access to all modules
    /// Staff: Access to Booking, Return, and Payments only
    /// </summary>
    internal static class AccessControl
    {
        public static AccessLevel GetAccess(AppModule module, string? role = null)
        {
            role ??= UserSession.Role;

            return (role, module) switch
            {
                ("Manager", _)                 => AccessLevel.Full,
                ("Staff",   AppModule.Booking) => AccessLevel.Full,
                ("Staff",   AppModule.Return)  => AccessLevel.Full,
                ("Staff",   AppModule.Payments)=> AccessLevel.Full,
                ("Staff",   _)                 => AccessLevel.None,
                _                              => AccessLevel.None
            };
        }

        public static bool CanOpen(AppModule module) =>
            GetAccess(module) != AccessLevel.None;

        public static bool CanModify(AppModule module) =>
            GetAccess(module) == AccessLevel.Full;

        public static void ShowDenied(AppModule module)
        {
            MessageBox.Show(
                $"Your role ({UserSession.Role}) does not have access to {module}.\n" +
                "Contact an administrator if you need permission.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Disables save/delete/action controls when the user has read-only access.
        /// </summary>
        public static void ApplyModulePermissions(Form form, AppModule module)
        {
            if (GetAccess(module) != AccessLevel.ReadOnly)
                return;

            switch (module)
            {
                case AppModule.Vehicles:
                    SetEnabled(form, false, "button6", "button3");
                    break;

                case AppModule.Customers:
                    SetEnabled(form, false, "btnAdd", "btnEdit", "btnDelete", "btnSave");
                    break;

                case AppModule.Booking:
                    SetEnabled(form, false, "btnSave", "btnClear");
                    break;

                case AppModule.Return:
                    SetEnabled(form, false, "btnReturn", "btnPay", "btnClear");
                    break;

                case AppModule.Payments:
                    SetEnabled(form, false,
                        "btnNewPayment", "btnProcessPayment", "btnRecalculate",
                        "btnClear", "btnLoad", "btnGo");
                    break;

                case AppModule.Reports:
                    SetEnabled(form, false, "button2", "button3");
                    break;
            }
        }

        private static void SetEnabled(Control root, bool enabled, params string[] names)
        {
            foreach (string name in names)
            {
                Control[] found = root.Controls.Find(name, true);
                if (found.Length > 0)
                    found[0].Enabled = enabled;
            }
        }
    }
}
