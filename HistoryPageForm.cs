using System;
using System.Data;
using System.Data.SQLite; // <-- ADDED FOR SQLITE DATA READING
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class HistoryPageForm : Form
    {
        // Store the logged-in user's name locally
        private string loggedInUsername;

        // Constructor accepting the username from MainDashboard
        public HistoryPageForm(string currentUsername)
        {
            InitializeComponent();

            // Save the username passed from the main form
            this.loggedInUsername = currentUsername;

            // Safety check fallback: If the main form passed an empty string,
            // pull the name directly from your application's global state!
            if (string.IsNullOrEmpty(this.loggedInUsername) && DataEngine.CurrentUser != null)
            {
                this.loggedInUsername = DataEngine.CurrentUser.Username;
            }

            // Hook the form load sequence safely so the visual grid is ready
            this.Load += HistoryPageForm_Load;
        }

        private void HistoryPageForm_Load(object sender, EventArgs e)
        {
            LoadOrderHistoryFromDatabase();
        }

        private void LoadOrderHistoryFromDatabase()
        {
            if (string.IsNullOrEmpty(this.loggedInUsername))
            {
                MessageBox.Show("Error: No logged-in user detected. Cannot fetch history.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbConnectionPath = "Data Source=watson_shop.db;Version=3;";

            // 🚀 COUPLING FIX: Force lowercase matching so "Admin" and "admin" match up perfectly!
            string selectQuery = "SELECT OrderId, Items, Total, Status FROM Orders WHERE LOWER(Username) = LOWER(@Username) ORDER BY OrderId DESC;";

            try
            {
                using (var connection = new SQLiteConnection(dbConnectionPath))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", this.loggedInUsername.Trim());

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            // 🔍 DETECT YOUR VISUAL DESIGNER GRID DYNAMICALLY
                            DataGridView visualGrid = null;
                            foreach (Control ctrl in this.Controls)
                            {
                                if (ctrl is DataGridView dgv) { visualGrid = dgv; break; }
                                foreach (Control subCtrl in ctrl.Controls)
                                {
                                    if (subCtrl is DataGridView subDgv) { visualGrid = subDgv; break; }
                                }
                            }

                            // If we found your visual layout grid on screen, map the data directly to its columns!
                            if (visualGrid != null)
                            {
                                visualGrid.AutoGenerateColumns = false;

                                // Link your visual columns to the matching database fields by index order
                                if (visualGrid.Columns.Count >= 4)
                                {
                                    visualGrid.Columns[0].DataPropertyName = "OrderId";
                                    visualGrid.Columns[1].DataPropertyName = "Items";
                                    visualGrid.Columns[2].DataPropertyName = "Total";
                                    visualGrid.Columns[3].DataPropertyName = "Status";
                                }
                                else
                                {
                                    visualGrid.AutoGenerateColumns = true;
                                }

                                visualGrid.DataSource = table;
                                visualGrid.Refresh();
                            }
                            else
                            {
                                // Fallback: If your dashboard holds the grid inside an isolated panel container
                                MessageBox.Show("Grid mapping notice: Please ensure your DataGridView is placed directly inside the form layout.", "Layout Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading history from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HistoryPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}