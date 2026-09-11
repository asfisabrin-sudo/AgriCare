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
    public partial class PaymentManagementForm : Form
    {
        private string connectionString =
            @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";


        public PaymentManagementForm()
        {
            InitializeComponent();
            LoadPayments();

        }
        private void LoadPayments()
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
    ServiceType,
    Amount,
    PaymentStatus,
    RequestStatus,
    RequestDate
FROM ServiceRequests
ORDER BY RequestDate DESC";

                    using (SqlDataAdapter da =
                       new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvpayment.DataSource = dt;
                    }
                }
                dgvpayment.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvpayment.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvpayment.MultiSelect = false;

                dgvpayment.ReadOnly = true;

                dgvpayment.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load payment information.\n\n" +
                    ex.Message,
                    "Payment Management Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void PaymentManagementForm_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpayment.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a Doctor's request first.",
                    "Doctor Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            try
            {
                string doctorID =
                    dgvpayment.SelectedRows[0]
                    .Cells["DoctorID"]
                    .Value
                    .ToString();

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    COUNT(*) AS TotalAnimals,
    ISNULL(SUM(Amount), 0) AS TotalAmount
FROM ServiceRequests
WHERE DoctorID = @DoctorID
AND PaymentStatus = 'Paid'
AND RequestStatus = 'Completed'";
                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DoctorID",
                            doctorID);

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalAnimals =
                                    Convert.ToInt32(
                                        reader["TotalAnimals"]);

                                decimal totalAmount =
                                    Convert.ToDecimal(
                                        reader["TotalAmount"]);
                                if (totalAnimals == 0)
                                {
                                    MessageBox.Show(
                                        "This doctor has no completed paid animal requests yet.",
                                        "Doctor Payment",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    return;

                                }
                                DialogResult result =
                                   MessageBox.Show(
                                       "Doctor ID: " + doctorID +
                                       "\n\n" +
                                       "Total Animals: " +
                                       totalAnimals +
                                       "\n" +
                                       "Total Payment: ৳" +
                                       totalAmount.ToString("0.00") +
                                       "\n\n" +
                                       "Do you want to pay this amount to the doctor?",
                                       "Doctor Payment",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    MessageBox.Show(
                                        "Doctor payment completed successfully.\n\n" +
                                        "Doctor ID: " + doctorID +
                                        "\n" +
                                        "Animals: " + totalAnimals +
                                        "\n" +
                                        "Payment: ৳" +
                                        totalAmount.ToString("0.00"),
                                        "Payment Successful",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not calculate doctor payment.\n\n" +
                    ex.Message,
                    "Doctor Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        // ==========================================
        // DOCTOR PAYMENT
        //
        private void btndoctorpaymenet_Click(object sender, EventArgs e)
        {
            if (dgvpayment.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a Doctor's request first.",
                    "Doctor Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string doctorID =
                    dgvpayment.SelectedRows[0]
                    .Cells["DoctorID"]
                    .Value
                    .ToString();
                CalculateDoctorPayment(doctorID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not process doctor payment.\n\n" +
                    ex.Message,
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        // ==========================================
        // CALCULATE DOCTOR PAYMENT
        // ==========================================
        private void CalculateDoctorPayment(string doctorID)
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
SELECT
    COUNT(*) AS TotalAnimals,
    ISNULL(SUM(sr.Amount), 0) AS TotalAmount
FROM ServiceRequests sr
WHERE sr.DoctorID = @DoctorID
AND sr.PaymentStatus = 'Paid'
AND sr.RequestStatus = 'Completed'
AND NOT EXISTS
(
    SELECT 1
    FROM DoctorPayments dp
    WHERE dp.DoctorID = sr.DoctorID
    AND dp.PaymentDate >= sr.RequestDate
)";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@DoctorID",
                        doctorID);

                    con.Open();
                    using (SqlDataReader reader =
                       cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalAnimals =
                                Convert.ToInt32(
                                    reader["TotalAnimals"]);

                            decimal totalAmount =
                                Convert.ToDecimal(
                                    reader["TotalAmount"]);

                            if (totalAnimals == 0)
                            {
                                MessageBox.Show(
                                    "There are no unpaid completed services for this doctor.",
                                    "Doctor Payment",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                return;
                            }
                            DialogResult result =
                                MessageBox.Show(
                                    "Doctor ID: " +
                                    doctorID +
                                    "\n\n" +

                                    "Completed Animals: " +
                                    totalAnimals +
                                    "\n" +

                                    "Total Payment: ৳" +
                                    totalAmount.ToString("0.00") +
                                    "\n\n" +

                                    "Do you want to pay this amount to the doctor?",

                                    "Confirm Doctor Payment",

                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                reader.Close();

                                SaveDoctorPayment(
                                    doctorID,
                                    totalAnimals,
                                    totalAmount);
                            }
                        }
                    }
                }
            }
        }
        // ==========================================
        // SAVE DOCTOR PAYMENT
        // ==========================================
        private void SaveDoctorPayment(
            string doctorID,
            int totalAnimals,
            decimal totalAmount)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {

                    string query = @"
INSERT INTO DoctorPayments
(
    DoctorID,
    TotalAnimals,
    TotalAmount,
    PaymentDate
)
VALUES
(
    @DoctorID,
    @TotalAnimals,
    @TotalAmount,
    GETDATE()
)";
                    using (SqlCommand cmd =
                       new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@DoctorID",
                            SqlDbType.NVarChar,
                            50).Value = doctorID;

                        cmd.Parameters.Add(
                            "@TotalAnimals",
                            SqlDbType.Int).Value =
                            totalAnimals;

                        cmd.Parameters.Add(
                            "@TotalAmount",
                            SqlDbType.Decimal).Value =
                            totalAmount;

                        cmd.Parameters[
                            "@TotalAmount"].Precision = 10;

                        cmd.Parameters[
                            "@TotalAmount"].Scale = 2;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Doctor payment completed successfully!\n\n" +
                    "Doctor ID: " + doctorID + "\n" +
                    "Animals: " + totalAnimals + "\n" +
                    "Payment: ৳" +
                    totalAmount.ToString("0.00"),

                    "Payment Successful",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not save doctor payment.\n\n" +
                    ex.Message,
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
