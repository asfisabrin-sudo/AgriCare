using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgriCare
{
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            
        }

        

        private void btnusermandesh_Click(object sender, EventArgs e)
        {
            UserManagementForm form = new UserManagementForm();
            form.ShowDialog();
        }

        private void btnreportmandesh_Click(object sender, EventArgs e)
        {
            ReportManagementForm form =
        new ReportManagementForm();

            form.ShowDialog();
        }

        private void btnlogoutmandesh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnpaymentmanagemanagerdesh_Click(object sender, EventArgs e)
        {
            PaymentManagementForm form = new PaymentManagementForm();
            form.ShowDialog();
        }
    }
}
