using System;
using System.Windows.Forms;

namespace adminstaffff
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize WinForms for .NET 8
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}