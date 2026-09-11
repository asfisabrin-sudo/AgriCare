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
    public partial class MyRequestsForm : Form
    {
        private string connectionString =
               @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

        private string farmerID;
        private Button btnRateDoctor;

        public MyRequestsForm(string farmerID)
        {
            InitializeComponent();
            this.farmerID = farmerID;
            CreateRateButton();
            LoadMyRequests();
        }
        // CREATE RATE DOCTOR BUTTON
        // ==========================================
        private void CreateRateButton()
        {
            btnRateDoctor = new Button();

            btnRateDoctor.Name = "btnRateDoctor";

            btnRateDoctor.Text = "Rate Doctor ⭐";

            btnRateDoctor.Size = new Size(130, 35);

            btnRateDoctor.Location =
                new Point(450, 340);

            btnRateDoctor.Visible = false;

            btnRateDoctor.Click +=
                new EventHandler(btnRateDoctor_Click);

            this.Controls.Add(btnRateDoctor);

            btnRateDoctor.BringToFront();
        }

        private void LoadMyRequests()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    RequestID AS [Request ID],
    AnimalName AS [Animal],
    AnimalType AS [Animal Type],
    ProblemDescription AS [Problem],
    DoctorID AS [Doctor ID],
    ServiceType AS [Service Type],
    Amount AS [Amount],
    PaymentStatus AS [Payment],
    RequestStatus AS [Status],
    RequestDate AS [Request Date]
FROM dbo.ServiceRequests
WHERE FarmerID = @FarmerID
ORDER BY RequestDate DESC";

                    SqlDataAdapter adapter =
                       new SqlDataAdapter(query, con);


                    adapter.SelectCommand.Parameters.Add(
                        "@FarmerID",
                        SqlDbType.VarChar,
                        50).Value = farmerID;


                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvmyrequests.DataSource = table;
                    // DataGridView settings
                    dgvmyrequests.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvmyrequests.ReadOnly = true;

                    dgvmyrequests.AllowUserToAddRows = false;

                    dgvmyrequests.AllowUserToDeleteRows = false;

                    dgvmyrequests.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dgvmyrequests.MultiSelect = false;

                    // Check selected row
                    dgvmyrequests.SelectionChanged +=
                        dgvmyrequests_SelectionChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading your requests:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        // CHECK WHETHER RATE BUTTON SHOULD SHOW
        // ==========================================
        private void dgvmyrequests_SelectionChanged(
            object sender,
            EventArgs e)
        {
            btnRateDoctor.Visible = false;


            if (dgvmyrequests.SelectedRows.Count == 0)
            {
                return;
            }


            DataGridViewRow row =
                dgvmyrequests.SelectedRows[0];


            string status =
                row.Cells["Status"].Value?.ToString();
            // Rating is allowed ONLY when Completed
            if (status != "Completed")
            {
                return;
            }


            int requestID;

            if (!int.TryParse(
                row.Cells["Request ID"].Value?.ToString(),
                out requestID))
            {
                return;
            }
            // Check whether this request is already rated
            if (IsAlreadyRated(requestID))
            {
                btnRateDoctor.Visible = false;
                return;
            }


            btnRateDoctor.Visible = true;
            btnRateDoctor.BringToFront();
        }
        // CHECK ALREADY RATED
        // ==========================================
        private bool IsAlreadyRated(int requestID)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
SELECT COUNT(*)
FROM dbo.DoctorReviews
WHERE RequestID = @RequestID
AND FarmerID = @FarmerID";

                    using (SqlCommand cmd =
                                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@RequestID",
                            SqlDbType.Int).Value = requestID;

                        cmd.Parameters.Add(
                            "@FarmerID",
                            SqlDbType.VarChar,
                            50).Value = farmerID;


                        con.Open();


                        int count =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());


                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        // RATE DOCTOR BUTTON
        // ==========================================
        private void btnRateDoctor_Click(
            object sender,
            EventArgs e)
        {
            if (dgvmyrequests.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a completed request first.",
                    "Rate Doctor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            DataGridViewRow row =
                dgvmyrequests.SelectedRows[0];
            string status =
                row.Cells["Status"].Value?.ToString();


            // Only Completed request can be rated
            if (status != "Completed")
            {
                MessageBox.Show(
                    "You can rate a doctor only after the request is completed.",
                    "Rate Doctor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            int requestID =
               Convert.ToInt32(
                   row.Cells["Request ID"].Value);


            string doctorID =
                row.Cells["Doctor ID"].Value.ToString();


            string animalName =
                row.Cells["Animal"].Value.ToString();
            // Check again before opening rating form
            if (IsAlreadyRated(requestID))
            {
                MessageBox.Show(
                    "You have already rated this request.",
                    "Already Rated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnRateDoctor.Visible = false;

                return;
            }
            // Open Rating Form
            DoctorRatingForm ratingForm =
                new DoctorRatingForm(
                    requestID,
                    farmerID,
                    doctorID,
                    animalName);


            if (ratingForm.ShowDialog() ==
                DialogResult.OK)
            {
                MessageBox.Show(
                    "Thank you for rating the doctor! ⭐",
                    "Rating Submitted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // Refresh request list
                LoadMyRequests();

                btnRateDoctor.Visible = false;
            }
        }
        private void MyRequestsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
