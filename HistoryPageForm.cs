using System;
using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class HistoryPageForm : Form
    {
        // Add a field to store the logged-in user's name locally
        private string loggedInUsername;

        // Change the constructor to accept the username as a parameter
        public HistoryPageForm(string currentUsername)
        {
            InitializeComponent();

            // Save the username passed from the main form
            this.loggedInUsername = currentUsername;

            DataGridView dgvHistory = new DataGridView()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(740, 500),
                ReadOnly = true
            };
            this.Controls.Add(dgvHistory);

            // Safety check using the passed variable instead of DataEngine
            if (string.IsNullOrEmpty(loggedInUsername))
            {
                MessageBox.Show("Session error: No user identifier passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Filters matching records safely without crashing on null data rows
                dgvHistory.DataSource = DataEngine.Orders
                    .Where(o => o != null &&
                                o.Username != null &&
                                o.Username.Contains(loggedInUsername))
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading history: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}