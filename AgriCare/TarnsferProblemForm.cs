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
    public partial class TarnsferProblemForm : Form
    {
        private string connectionString =
            @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

        private int problemId;
        private string currentDoctorId;
        public TarnsferProblemForm(int problemId, string currentDoctorId)
        {
            InitializeComponent();
            this.problemId = problemId;
            this.currentDoctorId = currentDoctorId;

            LoadDoctors();
        }
        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT UserID, Name
                        FROM dbo.Users
                        WHERE Role = 'Doctor'
                        AND Status = 'Active'
                        AND UserID <> @CurrentDoctorId
                        ORDER BY Name";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@CurrentDoctorId",
                        currentDoctorId
                    );

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    listBoxfortransfer.Items.Clear();

                    while (reader.Read())
                    {
                        string doctorId = reader["UserID"].ToString();
                        string doctorName = reader["Name"].ToString();

                        listBoxfortransfer.Items.Add(
                            new DoctorItem(doctorId, doctorName)
                        );
                    }

                    reader.Close();
                }

                if (listBoxfortransfer.Items.Count == 0)
                {
                    MessageBox.Show(
                        "No other active doctor is available.",
                        "Transfer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading doctors: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void TarnsferProblemForm_Load(object sender, EventArgs e)
        {

        }
        //Done Button
        private void btntransferdone_Click(object sender, EventArgs e)
        {
            if (listBoxfortransfer.SelectedItem == null)
            {

                MessageBox.Show(
                    "Please select a doctor.",
                    "Transfer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DoctorItem selectedDoctor =
                (DoctorItem)listBoxfortransfer.SelectedItem;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE dbo.AnimalProblems
                        SET DoctorId = @NewDoctorId
                        WHERE ProblemId = @ProblemId
                        AND DoctorId = @CurrentDoctorId
                        AND ProblemStatus = 'Assigned'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@NewDoctorId",
                        selectedDoctor.DoctorId
                    );

                    cmd.Parameters.AddWithValue(
                        "@ProblemId",
                        problemId
                    );

                    cmd.Parameters.AddWithValue(
                        "@CurrentDoctorId",
                        currentDoctorId
                    );

                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Problem transferred successfully.",
                            "Transfer Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Problem could not be transferred.",
                            "Transfer Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error transferring problem: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }


        private void btncanceltransfer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
        public class DoctorItem
        {
            public string DoctorId { get; set; }
            public string DoctorName { get; set; }

            public DoctorItem(string doctorId, string doctorName)
            {
                DoctorId = doctorId;
                DoctorName = doctorName;
            }

            public override string ToString()
            {
                return DoctorName + " (" + DoctorId + ")";
            }
        }
}
