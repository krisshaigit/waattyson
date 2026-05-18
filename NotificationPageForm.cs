using System.Linq;
using System.Windows.Forms;

namespace adminstaffff
{
    public partial class NotificationPageForm : Form
    {
        public NotificationPageForm()
        {
            DataGridView dgvNotifications = new DataGridView() { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(740, 500), ReadOnly = true };
            this.Controls.Add(dgvNotifications);

            // Fetch generic logs alongside targeted customer metrics records
            dgvNotifications.DataSource = DataEngine.Notifications
                .Where(n => n.Username == DataEngine.CurrentUser.Username)
                .ToList();
        }
    }
}