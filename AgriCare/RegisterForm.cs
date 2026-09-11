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
using System.Xml.Linq;

namespace AgriCare
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        private void CenterPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void btnregisterregi_Click(object sender, EventArgs e)
        {


            // Manager registration is not allowed
            if (rbmanagerregi.Checked)
            {
                MessageBox.Show(
                    "You are not allowed to register as Manager.",
                    "Registration Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string userId = txtuseridregi.Text.Trim();
            string name = txtnameregi.Text.Trim();
            string gmail = txtmailregi.Text.Trim();
            string password = txtpassregi.Text;
            string confirmPassword = txtconfirmpassregi.Text;

            string role = "";

            if (rbmanagerregi.Checked)
                role = "Manager";
            else if (rbdoctorregi.Checked)
                role = "Doctor";
            else if (rbfarmerregi.Checked)
                role = "Farmer";

            if (userId == "" || name == "" || gmail == "" ||
                password == "" || confirmPassword == "" || role == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string connectionString = @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.Users
                        (UserID, Name, Gmail, Password, Role, Status)
                        VALUES
                        (@UserID, @Name, @Gmail, @Password, @Role, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gmail", gmail);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    string status;

                    if (role == "Doctor")
                    {
                        status = "Pending";
                    }
                    else if (role == "Farmer")
                    {
                        status = "Active";
                    }
                    else
                    {
                        status = "Pending";
                    }

                    cmd.Parameters.AddWithValue("@Status", status);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                           "Registration successful!",
                            "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
);

                        AgriCare login = new AgriCare();
                        login.Show();
                        this.Close();

                        txtuseridregi.Clear();
                        txtnameregi.Clear();
                        txtmailregi.Clear();
                        txtpassregi.Clear();
                        txtconfirmpassregi.Clear();

                        rbmanagerregi.Checked = false;
                        rbdoctorregi.Checked = false;
                        rbfarmerregi.Checked = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void backtologin_Click(object sender, EventArgs e)
        {
            AgriCare login = new AgriCare();
            login.Show();

            this.Close();
        }
    }
}
