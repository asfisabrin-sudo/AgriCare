// This dashboard shows a doctor their assigned problems and allows marking them complete or transferring
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace AgriCare
{
    public partial class DoctorDeshboard : Form
    {
        // যে Doctor login করেছে তার UserId
        private string doctorId;

        private string connectionString =
            @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";


        // Constructor
        public DoctorDeshboard(string userId)
        {
            InitializeComponent();

            doctorId = userId;
        }



        // SHOW ASSIGNED PROBLEMS
       
        private void ShowAssignedProblems()
        {
            dgvassignedproblem.Visible = true;
            dgvassignedproblem.Columns.Clear();

            string query = @"
SELECT 
    ProblemId AS [Report ID],
    RequestID AS [Request ID],
    FarmerId AS [Farmer],
    AnimalName AS [Animal],
    ProblemDescription AS [Problem]
FROM dbo.AnimalProblems
WHERE DoctorId = @DoctorId
  AND ProblemStatus = 'Assigned'
ORDER BY ReportDate DESC";

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(
                        "@DoctorId",
                        SqlDbType.NVarChar,
                        50).Value = doctorId;

                    SqlDataAdapter da =
                        new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvassignedproblem.DataSource = dt;
                }
            }
        }



        private void DoctorDeshboard_Load(object sender, EventArgs e)
        {
            ShowAssignedProblems();
        }

        private void btnassignedddeshp1_Click(object sender, EventArgs e)
        {
            ShowAssignedProblems();
        }

        

        private void btncompleteddeshp1_Click(object sender, EventArgs e)
        
        {
            if (dgvassignedproblem.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a problem first.",
                    "Complete Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Get selected row
            DataGridViewRow row =
                dgvassignedproblem.SelectedRows[0];


            // Get Problem ID
            int problemId = Convert.ToInt32(
                row.Cells["Report ID"].Value);


            // Get Request ID
            int requestId = Convert.ToInt32(
                row.Cells["Request ID"].Value);

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // Start Transaction
                    using (SqlTransaction transaction =
                        con.BeginTransaction())
                    {
                        try
                        {

                            // 1. COMPLETE ANIMAL PROBLEM
                            string problemQuery = @"
UPDATE dbo.AnimalProblems
SET ProblemStatus = 'Completed'
WHERE ProblemId = @ProblemId
AND DoctorId = @DoctorId
AND ProblemStatus = 'Assigned'";

                            using (SqlCommand cmd =
                                                           new SqlCommand(
                                                               problemQuery,
                                                               con,
                                                               transaction))
                            {
                                cmd.Parameters.Add(
                                    "@ProblemId",
                                    SqlDbType.Int).Value = problemId;

                                cmd.Parameters.Add(
                                    "@DoctorId",
                                    SqlDbType.NVarChar,
                                    50).Value = doctorId;


                                int result =
                                    cmd.ExecuteNonQuery();
                                if (result == 0)
                                {
                                    transaction.Rollback();

                                    MessageBox.Show(
                                        "Problem could not be completed.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }
                            }
                            // ==========================================
                            // 2. COMPLETE EXACT SERVICE REQUEST
                            // ==========================================

                            string requestQuery = @"
UPDATE dbo.ServiceRequests
SET RequestStatus = 'Completed'
WHERE RequestID = @RequestID
AND DoctorID = @DoctorID";


                            using (SqlCommand cmd =
                                new SqlCommand(
                                    requestQuery,
                                    con,
                                    transaction))
                            {
                                cmd.Parameters.Add(
                                    "@RequestID",
                                    SqlDbType.Int).Value = requestId;
                                cmd.Parameters.Add(
                                   "@DoctorID",
                                   SqlDbType.NVarChar,
                                   50).Value = doctorId;


                                cmd.ExecuteNonQuery();
                            }


                            // ==========================================
                            // 3. COMMIT BOTH CHANGES
                            // ==========================================

                            transaction.Commit();
                            MessageBox.Show(
                               "Problem completed successfully.",
                               "Complete Report",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);


                            // Refresh assigned problem list
                            ShowAssignedProblems();
                        }
                        catch
                        {
                            transaction.Rollback();

                            throw;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error completing problem:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnlogoutddeshp1_Click(object sender, EventArgs e)
        {
            AgriCare login = new AgriCare();
            login.Show();

            this.Close();
        }

        private void btntransferddesh_Click(object sender, EventArgs e)
        {
            // Check if a problem is selected
            if (dgvassignedproblem.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a problem first.",
                    "Transfer Problem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }
            // Get Problem ID
            int problemId = Convert.ToInt32(
                dgvassignedproblem
                .SelectedRows[0]
                .Cells["Report ID"]
                .Value);


            // Open Transfer Problem Form
            TarnsferProblemForm transferForm =
                new TarnsferProblemForm(
                    problemId,
                    doctorId);
            // Show transfer form
            if (transferForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh assigned problems after transfer
                ShowAssignedProblems();
            }
        }
    }
}
