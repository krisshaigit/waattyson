using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class HistoryPageForm : Form
    {
        public HistoryPageForm()
        {
            DataGridView dgvHistory = new DataGridView() { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(740, 500), ReadOnly = true };
            this.Controls.Add(dgvHistory);

            // Filters data pipeline matching context records only
            dgvHistory.DataSource = DataEngine.Orders.Where(o => o.Username == DataEngine.CurrentUser.Username).ToList();
        }
    }
}