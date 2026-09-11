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
    public partial class FarmerDashboard : Form
    {
        private string farmerID;
        public FarmerDashboard(string farmerID)
        {
            InitializeComponent();
            this.farmerID = farmerID;
        }

        private void FarmerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnreportprobfdesh_Click(object sender, EventArgs e)
        {
            ReportProblemForm form = new ReportProblemForm(farmerID);
            form.ShowDialog();
        }

        private void btnlogoutfdesh_Click(object sender, EventArgs e)
        {
            AgriCare login = new AgriCare();
            login.Show();
            this.Close();
        }

        private void btnrequestfdesh_Click(object sender, EventArgs e)
        {
            MyRequestsForm form = new MyRequestsForm(farmerID);
            form.ShowDialog();
        }

        private void btnavailabledoctorfdesh_Click(object sender, EventArgs e)
        {
            AvailableDoctorsForm form = new AvailableDoctorsForm();
            form.ShowDialog();
        }
    }
}
