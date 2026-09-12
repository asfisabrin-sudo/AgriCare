// This form loads and displays the list of doctors who are currently marked as available in the database﻿using System;
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
    public partial class AvailableDoctorsForm : Form
    {
        private string connectionString =
           @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

        public AvailableDoctorsForm()
        {
            InitializeComponent();
            LoadDoctors();
        }
        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            U.UserID AS [Doctor ID],
                            U.Name AS [Doctor Name],
                            ISNULL(DP.Specialization, 'General Animal Doctor') AS [Specialization],
                            ISNULL(DP.Experience, 0) AS [Experience],
                            ISNULL(DP.Rating, 0) AS [Rating],
                            ISNULL(DP.TotalReviews, 0) AS [Total Reviews]
                        FROM dbo.Users U
                        LEFT JOIN dbo.DoctorProfile DP
                            ON U.UserID = DP.DoctorID
                        WHERE U.Role = 'Doctor'
                        AND U.Status = 'Active'
                        ORDER BY U.Name";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvdoctors.DataSource = table;

                    if (dgvdoctors.Columns.Contains("Rating"))
                    {
                        dgvdoctors.Columns["Rating"].HeaderText = "Rating ⭐";
                    }

                    if (dgvdoctors.Columns.Contains("Total Reviews"))
                    {
                        dgvdoctors.Columns["Total Reviews"].HeaderText = "Reviews";
                    }

                    dgvdoctors.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvdoctors.ReadOnly = true;

                    dgvdoctors.AllowUserToAddRows = false;

                    dgvdoctors.AllowUserToDeleteRows = false;

                    dgvdoctors.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dgvdoctors.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading doctors:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void AvailableDoctorsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnbaack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
