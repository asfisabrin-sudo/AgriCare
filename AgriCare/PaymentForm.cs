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
    public partial class PaymentForm : Form
    {

        private string farmerID;
        private string doctorID;
        private string doctorName;

        private string animalName;
        private string animalType;
        private string problemDescription;
        private string serviceType;
        private string farmAddress;
        private decimal amount;

        private string connectionString =
            @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";



        public PaymentForm(
            string farmerID,
            string doctorID,
            string doctorName,
            string animalName,
            string animalType,
            string problemDescription,
            string serviceType,
            string farmAddress,
            decimal amount)
        {
            InitializeComponent();

            this.farmerID = farmerID;
            this.doctorID = doctorID;
            this.doctorName = doctorName;
            this.animalName = animalName;
            this.animalType = animalType;
            this.problemDescription = problemDescription;
            this.serviceType = serviceType;
            this.farmAddress = farmAddress;
            this.amount = amount;

            LoadPaymentDetails();
        }
        private void LoadPaymentDetails()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    OnlineAdviceFee,
    FarmVisitFee
FROM dbo.DoctorProfile
WHERE DoctorID = @DoctorID";

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
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Fee information for this doctor was not found.",
                                    "Payment Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                this.Close();
                                return;
                            }

                            decimal onlineAdviceFee =
                                reader["OnlineAdviceFee"] == DBNull.Value
                                ? 0
                                : Convert.ToDecimal(
                                    reader["OnlineAdviceFee"]);

                            decimal farmVisitFee =
                                reader["FarmVisitFee"] == DBNull.Value
                                ? 0
                                : Convert.ToDecimal(
                                    reader["FarmVisitFee"]);

                            // =====================================
                            // GET FEE ACCORDING TO SERVICE TYPE
                            // =====================================
                            if (serviceType == "Online Advice")
                            {
                                amount = onlineAdviceFee;
                            }
                            else if (serviceType == "Farm Visit")
                            {
                                amount = farmVisitFee;
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Invalid service type.",
                                    "Payment Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                this.Close();
                                return;
                            }
                        }
                    }
                }

                // =====================================
                // SHOW PAYMENT DETAILS
                // =====================================
                lbldoctorpay.Text =
                    "Doctor: " + doctorName;

                lblservicepay.Text =
                    "Service: " + serviceType;

                lblamountpay.Text =
                    "Amount: ৳" + amount.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load doctor fee.\n\n" +
                    ex.Message,
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnpaynow_Click(object sender, EventArgs e)
        {
            // Farmer ID check
            if (string.IsNullOrWhiteSpace(farmerID))
            {
                MessageBox.Show(
                    "Farmer ID is missing.\nPlease login again as Farmer.",
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Doctor ID check
            if (string.IsNullOrWhiteSpace(doctorID))
            {
                MessageBox.Show(
                    "Doctor ID is missing.",
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // Start Transaction
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. INSERT INTO ServiceRequests
                            string query = @"INSERT INTO ServiceRequests
(
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
)
VALUES
(
    @FarmerID,
    @DoctorID,
    @AnimalName,
    @AnimalType,
    @ProblemDescription,
    @ServiceType,
    @FarmAddress,
    @Amount,
    'Paid',
    'Pending',
    GETDATE()
);

SELECT CAST(SCOPE_IDENTITY() AS INT);";


                            int requestID;
                            using (SqlCommand cmd =
                                new SqlCommand(query, con, transaction))
                            {
                                cmd.Parameters.Add(
                                    "@FarmerID",
                                    SqlDbType.NVarChar,
                                    50).Value = farmerID;

                                cmd.Parameters.Add(
                                    "@DoctorID",
                                    SqlDbType.NVarChar,
                                    50).Value = doctorID;

                                cmd.Parameters.Add(
                                    "@AnimalName",
                                    SqlDbType.NVarChar,
                                    100).Value = animalName;

                                cmd.Parameters.Add(
                                    "@AnimalType",
                                    SqlDbType.NVarChar,
                                    50).Value = animalType;
                                cmd.Parameters.Add(
                                   "@ProblemDescription",
                                   SqlDbType.NVarChar,
                                   -1).Value = problemDescription;

                                cmd.Parameters.Add(
                                    "@ServiceType",
                                    SqlDbType.NVarChar,
                                    50).Value = serviceType;


                                if (string.IsNullOrWhiteSpace(farmAddress))
                                {
                                    cmd.Parameters.Add(
                                        "@FarmAddress",
                                        SqlDbType.NVarChar,
                                        300).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd.Parameters.Add(
                                        "@FarmAddress",
                                        SqlDbType.NVarChar,
                                        300).Value = farmAddress;
                                }


                                SqlParameter amountParameter =
                                    cmd.Parameters.Add(
                                        "@Amount",
                                        SqlDbType.Decimal);

                                amountParameter.Precision = 10;
                                amountParameter.Scale = 2;
                                amountParameter.Value = amount;
                                // Get newly created RequestID
                                requestID = Convert.ToInt32(
                                    cmd.ExecuteScalar());
                            }


                            // 2. INSERT INTO AnimalProblems
                            string problemQuery = @"
INSERT INTO AnimalProblems
(
    RequestID,
    FarmerId,
    AnimalName,
    AnimalType,
    ProblemDescription,
    PaymentAmount,
    PaymentStatus,
    ProblemStatus,
    DoctorId,
    ReportDate,
    ServiceType,
    FarmAddress
)
VALUES
(
    @RequestID,
    @FarmerId,
    @AnimalName,
    @AnimalType,
    @ProblemDescription,
    @Amount,
    'Paid',
    'Assigned',
    @DoctorId,
    GETDATE(),
    @ServiceType,
    @FarmAddress
)";
                            using (SqlCommand problemCmd =
                                                            new SqlCommand(
                                                                problemQuery,
                                                                con,
                                                                transaction))
                            {
                                problemCmd.Parameters.Add(
                                    "@RequestID",
                                    SqlDbType.Int).Value = requestID;

                                problemCmd.Parameters.Add(
                                    "@FarmerId",
                                    SqlDbType.NVarChar,
                                    50).Value = farmerID;

                                problemCmd.Parameters.Add(
                                    "@DoctorId",
                                    SqlDbType.NVarChar,
                                    50).Value = doctorID;

                                problemCmd.Parameters.Add(
                                    "@AnimalName",
                                    SqlDbType.NVarChar,
                                    100).Value = animalName;
                                problemCmd.Parameters.Add(
                                   "@AnimalType",
                                   SqlDbType.NVarChar,
                                   50).Value = animalType;

                                problemCmd.Parameters.Add(
                                    "@ProblemDescription",
                                    SqlDbType.NVarChar,
                                    -1).Value = problemDescription;

                                SqlParameter problemAmountParameter =
                                    problemCmd.Parameters.Add(
                                        "@Amount",
                                        SqlDbType.Decimal);

                                problemAmountParameter.Precision = 10;
                                problemAmountParameter.Scale = 2;
                                problemAmountParameter.Value = amount;
                                problemCmd.Parameters.Add(
                                    "@ServiceType",
                                    SqlDbType.NVarChar,
                                    50).Value = serviceType;


                                if (string.IsNullOrWhiteSpace(farmAddress))
                                {
                                    problemCmd.Parameters.Add(
                                        "@FarmAddress",
                                        SqlDbType.NVarChar,
                                        300).Value = DBNull.Value;
                                }
                                else
                                {
                                    problemCmd.Parameters.Add(
                                        "@FarmAddress",
                                        SqlDbType.NVarChar,
                                        300).Value = farmAddress;
                                }
                                problemCmd.ExecuteNonQuery();
                            }


                            // ==========================================
                            // 3. Commit Transaction
                            // ==========================================

                            transaction.Commit();
                        }
                        catch
                        {
                            // If anything fails, rollback everything
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                // ==========================================
                // 4. Payment Success Message
                // ==========================================

                MessageBox.Show(
                    "Payment successful!\n\n" +
                    "Doctor: " + doctorName + "\n" +
                    "Service: " + serviceType + "\n" +
                    "Amount: ৳" + amount.ToString("0.00") +
                    "\n\nYour request has been submitted.",
                    "Payment Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Payment failed.\n\n" + ex.Message,
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btncancelpay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
