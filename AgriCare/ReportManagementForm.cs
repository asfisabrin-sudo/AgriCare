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
    public partial class ReportManagementForm : Form
    {
        private string connectionString =
            @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";


        public ReportManagementForm()
        {
            InitializeComponent();

            combostatus.Items.Clear();
            combostatus.Items.Add("All");
            combostatus.Items.Add("Pending");
            combostatus.Items.Add("Completed");
            combostatus.Items.Add("Failed");

            combostatus.SelectedIndex = 0;

            LoadReports();
        }
        // LOAD REPORTS
        // ==========================================
        private void LoadReports()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    RequestID,
    FarmerID,
    DoctorID,
    AnimalName,
    AnimalType,
    ProblemDescription,
    ServiceType,
    FarmAddress,
    Amount,
    PaymentStatus,
    RequestStatus,
    RequestDate
FROM ServiceRequests";

                    if (combostatus.SelectedItem != null &&
                        combostatus.SelectedItem.ToString() != "All")
                    {
                        query +=
                            " WHERE RequestStatus = @RequestStatus";
                    }

                    query += " ORDER BY RequestDate DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        if (combostatus.SelectedItem != null &&
                            combostatus.SelectedItem.ToString() != "All")
                        {
                            cmd.Parameters.AddWithValue(
                                "@RequestStatus",
                                combostatus.SelectedItem.ToString());
                        }
                        SqlDataAdapter da =
                            new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvreportmanagement.DataSource = dt;
                    }
                }
                dgvreportmanagement.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvreportmanagement.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvreportmanagement.MultiSelect = false;

                dgvreportmanagement.ReadOnly = true;

                dgvreportmanagement.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load reports.\n\n" +
                    ex.Message,
                    "Report Management Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ReportManagementForm_Load(object sender, EventArgs e)
        {

        }
        // STATUS FILTER
        // ==========================================
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnviewdetails_Click(object sender, EventArgs e)
        {
            if (dgvreportmanagement.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a report first.",
                    "View Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow row =
                dgvreportmanagement.SelectedRows[0];

            string details =
                "Request ID: " +
                row.Cells["RequestID"].Value + "\n\n" +

                "Farmer ID: " +
                row.Cells["FarmerID"].Value + "\n" +

                "Doctor ID: " +
                row.Cells["DoctorID"].Value + "\n\n" +

                "Animal Name: " +
                row.Cells["AnimalName"].Value + "\n" +

                "Animal Type: " +
                row.Cells["AnimalType"].Value + "\n\n" +

                "Problem:\n" +
                row.Cells["ProblemDescription"].Value + "\n\n" +

                "Service Type: " +
                row.Cells["ServiceType"].Value + "\n\n" +
                "Farm Address: " +
                (row.Cells["FarmAddress"].Value == DBNull.Value
                    ? "N/A"
                    : row.Cells["FarmAddress"].Value.ToString()) + "\n\n" +

                "Amount: ৳" +
                Convert.ToDecimal(
                    row.Cells["Amount"].Value)
                    .ToString("0.00") + "\n" +

                "Payment Status: " +
                row.Cells["PaymentStatus"].Value + "\n" +

                "Request Status: " +
                row.Cells["RequestStatus"].Value + "\n\n" +

                "Request Date: " +
                Convert.ToDateTime(
                    row.Cells["RequestDate"].Value)
                    .ToString("dd/MM/yyyy hh:mm tt");

            MessageBox.Show(
                details,
                "Report Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
