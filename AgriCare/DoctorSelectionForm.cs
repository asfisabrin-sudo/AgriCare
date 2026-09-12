// This form lets a farmer browse and select a doctor along with the applicable fee before submitting a request
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgriCare
{
    public partial class DoctorSelectionForm : Form
    {
        private string farmerID;
        private string animalName;
        private string animalType;
        private string problemDescription;
        private string serviceType;
        private string farmAddress;

        public string SelectedDoctorID { get; private set; }
        public string SelectedDoctorName { get; private set; }
        public decimal SelectedFee { get; private set; }


        private string connectionString =
            @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";


        public DoctorSelectionForm(
            string farmerID,
    string animalName,
    string animalType,
    string problemDescription,
    string serviceType,
    string farmAddress)
        {
            InitializeComponent();

            this.farmerID = farmerID;
            this.animalName = animalName;
            this.animalType = animalType;
            this.problemDescription = problemDescription;
            this.serviceType = serviceType;
            this.farmAddress = farmAddress;


            LoadDoctors();
        }
        private void LoadDoctors()
        {
            
        
            string connectionString =
                @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

            string query = @"
SELECT
    U.UserID AS DoctorID,
    U.Name AS DoctorName,
    ISNULL(DP.Specialization, 'General Animal Doctor') AS Specialization,
    ISNULL(DP.Experience, 0) AS Experience,
    ISNULL(DP.OnlineAdviceFee, 0) AS OnlineAdviceFee,
    ISNULL(DP.FarmVisitFee, 0) AS FarmVisitFee,
    ISNULL(DP.Rating, 0) AS Rating,
    ISNULL(DP.TotalReviews, 0) AS TotalReviews
FROM dbo.Users U
LEFT JOIN dbo.DoctorProfile DP
    ON U.UserID = DP.DoctorID
WHERE U.Role = 'Doctor'
  AND U.Status = 'Active'
ORDER BY U.Name;";
            

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgbdoctorselection.DataSource = dt;
                }
            }
        }

        private void btnSelectDoctor_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }
        private void DoctorSelectionForm_Load(object sender, EventArgs e)
        {
         //  MessageBox.Show(
     // "Doctor selected successfully!",
     //"AgriCare",
     // MessageBoxButtons.OK,
    // MessageBoxIcon.Information
  // );

            // আপাতত Doctor Selection Form বন্ধ হবে
            //this.Close();
        }

        private void btnselectdoctor_Click_1(object sender, EventArgs e)
        {
            if (dgbdoctorselection.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a doctor first.",
                    "Select Doctor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow row = dgbdoctorselection.SelectedRows[0];

            SelectedDoctorID =
                row.Cells["DoctorID"].Value.ToString();

            SelectedDoctorName =
                row.Cells["DoctorName"].Value.ToString();

            if (serviceType == "Online Advice")
            {
                SelectedFee =
                    Convert.ToDecimal(
                        row.Cells["OnlineAdviceFee"].Value);
            }
            else
            {
                SelectedFee =
                    Convert.ToDecimal(
                        row.Cells["FarmVisitFee"].Value);
            }

            PaymentForm paymentForm = new PaymentForm(
    farmerID,
    SelectedDoctorID,
    SelectedDoctorName,
    animalName,
    animalType,
    problemDescription,
    serviceType,
    farmAddress,
    SelectedFee
);

            DialogResult result = paymentForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbackdoctorselection_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
