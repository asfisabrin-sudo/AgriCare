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
    public partial class AgriCare : Form
    {
        public AgriCare()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsigninagri_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }

            this.Show();
        }

        private void btnloginagri_Click(object sender, EventArgs e)
        {
            string userId = txtuseridagri.Text.Trim();
            string password = txtpassagri.Text;

            if (userId == "" || password == "")
            {
                MessageBox.Show("Please enter User ID and Password.");
                return;
            }

            string connectionString = @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

            string query = @"SELECT Name, Role, Status
                     FROM dbo.Users
                     WHERE UserID = @UserID
                     AND Password = @Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string role = reader["Role"].ToString();
                            string status = reader["Status"].ToString();

                            if (status == "Pending")
                            {
                                MessageBox.Show(
                                    "Your request is pending.\nPlease wait for Manager approval.",
                                    "Account Pending",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                return;
                            }

                            if (status == "Blocked")
                            {
                                MessageBox.Show(
                                    "Your account is blocked.\nPlease contact the Manager.",
                                    "Account Blocked",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }

                            if (status != "Active")
                            {
                                MessageBox.Show(
                                    "Your account is not active.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }

                            /* MessageBox.Show(
                                               "Login Successful!\n\nWelcome, " + name +
                                                "\nRole: " + role
                                             );*/

                            if (role == "Manager")
                            {
                                this.Hide();

                                using (ManagerDashboard dashboard = new ManagerDashboard())
                                {
                                    dashboard.ShowDialog();
                                }

                                this.Show();
                            }
                            // Login successful
                            // Next step: open Dashboard according to Role
                            if (role == "Doctor")
                            {
                                DoctorDeshboard doctorDashboard = new DoctorDeshboard(userId);
                                doctorDashboard.Show();
                                this.Hide();
                            }
                            if (role == "Farmer")
                            {
                                FarmerDashboard dashboard = new FarmerDashboard(userId);
                                dashboard.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User ID or Password.");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void CenterPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
        private void AgriCare_Load(object sender, EventArgs e)
        {
            CenterPanel();
        
        }
    }
}
