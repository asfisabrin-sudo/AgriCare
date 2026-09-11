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
    public partial class UserManagementForm : Form
    {
        private string connectionString =
          @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

        public UserManagementForm()
        {
            InitializeComponent();
            // ComboBox items
            combousermangerule.Items.Clear();
            combousermangerule.Items.Add("Doctor");
            combousermangerule.Items.Add("Farmer");

            combousermangerule.SelectedIndex = 0;

            LoadUsers();
        }

        // LOAD USERS
        // ==========================================
        private void LoadUsers()
        {
            try
            {
                if (combousermangerule.SelectedItem == null)
                    return;

                string role = combousermangerule.SelectedItem.ToString();

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query;

                    // =====================================
                    // DOCTOR LIST
                    // =====================================
                    if (role == "Doctor")
                    {
                        query = @"
SELECT
    U.UserID,
    U.Name,
    U.Gmail,
    U.Password,
    U.Role,
    U.Status,
    ISNULL(DP.OnlineAdviceFee, 0) AS [Online Advice Fee],
    ISNULL(DP.FarmVisitFee, 0) AS [Farm Visit Fee],
    ISNULL(DP.Rating, 0) AS [Rating],
    ISNULL(DP.TotalReviews, 0) AS [Total Reviews]
FROM dbo.Users U
LEFT JOIN dbo.DoctorProfile DP
    ON U.UserID = DP.DoctorID
WHERE U.Role = 'Doctor'
ORDER BY U.UserID";
                    }
                    else
                    {
                        // =====================================
                        // FARMER LIST
                        // =====================================
                        query = @"
SELECT *
FROM dbo.Users
WHERE Role = @Role
ORDER BY UserID";
                    }

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        if (role != "Doctor")
                        {
                            cmd.Parameters.AddWithValue(
                                "@Role",
                                role);
                        }
                        SqlDataAdapter da =
                            new SqlDataAdapter(cmd);

                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        dgvuser.DataSource = dt;
                    }
                }
                // Grid design
                dgvuser.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvuser.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvuser.MultiSelect = false;

                dgvuser.ReadOnly = true;
                // Better column names for Doctor
                if (dgvuser.Columns.Contains("Rating"))
                {
                    dgvuser.Columns["Rating"].HeaderText =
                        "Rating ⭐";
                }

                if (dgvuser.Columns.Contains("Total Reviews"))
                {
                    dgvuser.Columns["Total Reviews"].HeaderText =
                        "Reviews";
                }
                if (dgvuser.Columns.Contains("Online Advice Fee"))
                {
                    dgvuser.Columns["Online Advice Fee"].HeaderText =
                        "Online Advice Fee (৳)";
                }

                if (dgvuser.Columns.Contains("Farm Visit Fee"))
                {
                    dgvuser.Columns["Farm Visit Fee"].HeaderText =
                        "Farm Visit Fee (৳)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load users.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // COMBOBOX CHANGE
        // ==========================================
        private void cmbUserType_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadUsers();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnapproveusermanage_Click(object sender, EventArgs e)
        {
            if (dgvuser.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "User Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string userID =
                    dgvuser.SelectedRows[0]
                    .Cells["UserID"]
                    .Value
                    .ToString();

                string name =
                    dgvuser.SelectedRows[0]
                    .Cells["Name"]
                    .Value
                    .ToString();

                string role =
                    dgvuser.SelectedRows[0]
                    .Cells["Role"]
                    .Value
                    .ToString();

                string status =
                    dgvuser.SelectedRows[0]
                    .Cells["Status"]
                    .Value
                    .ToString();

                if (status == "Active")
                {
                    MessageBox.Show(
                        "This user is already active.",
                        "User Management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                if (status == "Blocked")
                {
                    MessageBox.Show(
                        "This user is blocked.\nUnblock the user first.",
                        "User Management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // ================================
                // DOCTOR
                // ================================
                if (role == "Doctor")
                {
                    using (DoctorFeeForm feeForm =
                        new DoctorFeeForm(name))
                    {
                        DialogResult result =
                            feeForm.ShowDialog(this);

                        if (result != DialogResult.OK)
                            return;

                        ApproveDoctor(
                            userID,
                            feeForm.OnlineAdviceFee,
                            feeForm.FarmVisitFee);
                    }
                }
                else
                {
                    // ================================
                    // FARMER
                    // ================================
                    ApproveFarmer(userID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not approve user.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ApproveDoctor(
    string doctorID,
    decimal onlineAdviceFee,
    decimal farmVisitFee)
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                con.Open();

                SqlTransaction transaction =
                    con.BeginTransaction();

                try
                {
                    string checkQuery = @"
SELECT COUNT(*)
FROM dbo.DoctorProfile
WHERE DoctorID = @DoctorID";

                    bool profileExists;

                    using (SqlCommand cmd =
                        new SqlCommand(
                            checkQuery,
                            con,
                            transaction))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DoctorID",
                            doctorID);

                        profileExists =
                            Convert.ToInt32(
                                cmd.ExecuteScalar()) > 0;
                    }

                    if (profileExists)
                    {
                        string updateQuery = @"
UPDATE dbo.DoctorProfile
SET
    OnlineAdviceFee = @OnlineAdviceFee,
    FarmVisitFee = @FarmVisitFee
WHERE DoctorID = @DoctorID";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                updateQuery,
                                con,
                                transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@OnlineAdviceFee",
                                onlineAdviceFee);

                            cmd.Parameters.AddWithValue(
                                "@FarmVisitFee",
                                farmVisitFee);

                            cmd.Parameters.AddWithValue(
                                "@DoctorID",
                                doctorID);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = @"
INSERT INTO dbo.DoctorProfile
(
    DoctorID,
    Specialization,
    Experience,
    OnlineAdviceFee,
    FarmVisitFee,
    Rating,
    TotalReviews
)
VALUES
(
    @DoctorID,
    'General Animal Doctor',
    0,
    @OnlineAdviceFee,
    @FarmVisitFee,
    0,
    0
)";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                insertQuery,
                                con,
                                transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@DoctorID",
                                doctorID);

                            cmd.Parameters.AddWithValue(
                                "@OnlineAdviceFee",
                                onlineAdviceFee);

                            cmd.Parameters.AddWithValue(
                                "@FarmVisitFee",
                                farmVisitFee);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    string activateQuery = @"
UPDATE dbo.Users
SET Status = 'Active'
WHERE UserID = @UserID
AND Role = 'Doctor'
AND Status = 'Pending'";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            activateQuery,
                            con,
                            transaction))
                    {
                        cmd.Parameters.AddWithValue(
                            "@UserID",
                            doctorID);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show(
                        "Doctor approved successfully!\n\n" +
                        "Online Advice Fee: ৳" +
                        onlineAdviceFee.ToString("0.00") +
                        "\nFarm Visit Fee: ৳" +
                        farmVisitFee.ToString("0.00"),
                        "Doctor Approved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadUsers();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        private void ApproveFarmer(string farmerID)
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
UPDATE dbo.Users
SET Status = 'Active'
WHERE UserID = @UserID
AND Role = 'Farmer'
AND Status = 'Pending'";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@UserID",
                        farmerID);

                    con.Open();

                    int result =
                        cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Farmer approved successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadUsers();
                    }
                }
            }
        }
        private void btnblockusermanage_Click(object sender, EventArgs e)
        {
            if (dgvuser.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "User Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirm =
                MessageBox.Show(
                    "Are you sure you want to block this user?",
                    "Confirm Block",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;
            try
            {
                string userID =
                    dgvuser.SelectedRows[0]
                    .Cells["UserID"]
                    .Value
                    .ToString();

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
UPDATE Users
SET Status = 'Blocked'
WHERE UserID = @UserID";
                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@UserID", userID);

                        con.Open();

                        int result =
                            cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "User has been blocked.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadUsers();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not block user.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnrefreshusermanage_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnbackusermanage_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

