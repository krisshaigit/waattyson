using System;
using System.Data.SQLite; // <-- MAKE SURE TO ADD THIS AT THE TOP OF PROGRAM.CS
using System.Windows.Forms;

namespace adminstaffff
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ?? ADD STEP 1 RIGHT HERE: Updates your DB file before any screens open!
            string dbConnectionPath = "Data Source=watson_shop.db;Version=3;";
            using (var connection = new SQLiteConnection(dbConnectionPath))
            {
                try
                {
                    connection.Open();
                    // This safely injects the missing column into your database file
                    using (var command = new SQLiteCommand("ALTER TABLE Orders ADD COLUMN Address TEXT;", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    // If the column already exists, SQLite throws an error code 1.
                    // We catch it and do nothing because your DB is already updated perfectly!
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database setup notice: {ex.Message}");
                }
            }

            // Your normal application launch lines stay down here:
            Application.Run(new LoginForm());
        }
    }
}