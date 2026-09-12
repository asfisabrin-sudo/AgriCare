// This form allows a farmer to submit a rating and review for the doctor who handled their requestusing System;
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

    public partial class DoctorRatingForm : Form
    {
        private string connectionString =
           @"Data Source=KOOKIE80\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";

        private int requestID;
        private string farmerID;
        private string doctorID;
        private string animalName;

        private Label lblTitle;
        private Label lblDoctor;
        private Label lblAnimal;
        private Label lblRating;

        private ComboBox cmbRating;

        private Button btnSubmit;
        private Button btnCancel;
        public DoctorRatingForm(int requestID,
            string farmerID,
            string doctorID,
            string animalName)
        {
            this.requestID = requestID;
            this.farmerID = farmerID;
            this.doctorID = doctorID;
            this.animalName = animalName;

            CreateUI();
        }
        private void DoctorRatingForm_Load(object sender, EventArgs e)
        {
            //aikhan a nothing required 
        }
        // CREATE RATING UI
        private void CreateUI()
        {
            this.Text = "Rate Doctor";

            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // TITLE
            lblTitle = new Label();
            lblTitle.Text = "★ Rate Your Doctor";
            lblTitle.Font = new Font(
                "Segoe UI",
                20,
                FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(120, 40);

            // DOCTOR
            lblDoctor = new Label();
            lblDoctor.Text = "Doctor: " + doctorID;
            lblDoctor.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Regular);
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(80, 110);
            lblTitle = new Label();
            // ANIMAL
            lblAnimal = new Label();
            lblAnimal.Text = "Animal: " + animalName;
            lblAnimal.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Regular);
            lblAnimal.AutoSize = true;
            lblAnimal.Location = new Point(80, 150);

            // RATING LABEL
            lblRating = new Label();
            lblRating.Text = "Select Rating:";
            lblRating.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Regular);
            lblRating.AutoSize = true;
            lblRating.Location = new Point(80, 200);

            // RATING COMBOBOX
            cmbRating = new ComboBox();
            cmbRating.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbRating.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Regular);

            cmbRating.Size = new Size(180, 30);

            cmbRating.Location =
               new Point(200, 195);

            cmbRating.Items.Add("★ 1 Star");
            cmbRating.Items.Add("★★ 2 Stars");
            cmbRating.Items.Add("★★★ 3 Stars");
            cmbRating.Items.Add("★★★★ 4 Stars");
            cmbRating.Items.Add("★★★★★ 5 Stars");

            cmbRating.SelectedIndex = 4;

            // SUBMIT BUTTON
            btnSubmit = new Button();
            btnSubmit.Text = "Submit Rating";
            btnSubmit.Size = new Size(145, 40);
            btnSubmit.Location = new Point(100, 270);

            btnSubmit.Click +=
                new EventHandler(btnSubmit_Click);

            // CANCEL BUTTON
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.Location = new Point(270, 270);

            btnCancel.Click +=
                new EventHandler(btnCancel_Click);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblDoctor);
            this.Controls.Add(lblAnimal);
            this.Controls.Add(lblRating);
            this.Controls.Add(cmbRating);
            this.Controls.Add(btnSubmit);
            this.Controls.Add(btnCancel);
        }
       

           
        // SUBMIT RATING
        // ==========================================
        private void btnSubmit_Click(
            object sender,
            EventArgs e)
        {
            if(cmbRating.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a rating.",
                    "Rating",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int rating =
                cmbRating.SelectedIndex + 1;


            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlTransaction transaction =
                        con.BeginTransaction();

                    try
                    {
                        // =====================================
                        // 1. CHECK ALREADY RATED
                        // =====================================


                        // 1. CHECK ALREADY RATED


                        string checkQuery = @"
SELECT COUNT(*)
FROM dbo.DoctorReviews
WHERE RequestID = @RequestID";
                        using (SqlCommand checkCmd =
                            new SqlCommand(
                                checkQuery,
                                con,
                                transaction))
                        {
                            checkCmd.Parameters.Add(
                                "@RequestID",
                                SqlDbType.Int).Value =
                                requestID;

                            int alreadyRated =
                                Convert.ToInt32(
                                    checkCmd.ExecuteScalar());

                            if (alreadyRated > 0)
                            {
                                transaction.Rollback();

                                MessageBox.Show(
                                    "You have already rated this request.",
                                    "Already Rated",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                return;
                            }
                        }
                        // 2. INSERT REVIEW
                        // ==========================================

                        string insertReviewQuery = @"
INSERT INTO dbo.DoctorReviews
(
    RequestID,
    FarmerID,
    DoctorID,
    Rating,
    ReviewDate
)
VALUES
(
    @RequestID,
    @FarmerID,
    @DoctorID,
    @Rating,
    GETDATE()
)";
                        using (SqlCommand reviewCmd =
                            new SqlCommand(
                                insertReviewQuery,
                                con,
                                transaction))
                        {
                            reviewCmd.Parameters.Add(
                                "@RequestID",
                                SqlDbType.Int).Value =
                                requestID;

                            reviewCmd.Parameters.Add(
                                "@FarmerID",
                                SqlDbType.VarChar,
                                50).Value =
                                farmerID;

                            reviewCmd.Parameters.Add(
                                "@DoctorID",
                                SqlDbType.VarChar,
                                50).Value =
                                doctorID;
                            reviewCmd.Parameters.Add(
                               "@Rating",
                               SqlDbType.Int).Value =
                               rating;

                            reviewCmd.ExecuteNonQuery();
                        }
                        // 3. UPDATE DOCTOR RATING


                        string profileCheckQuery = @"
SELECT COUNT(*)
FROM dbo.DoctorProfile
WHERE DoctorID = @DoctorID";

                        int profileExists;

                        using (SqlCommand profileCheckCmd =
                            new SqlCommand(
                                profileCheckQuery,
                                con,
                                transaction))
                        {
                            profileCheckCmd.Parameters.Add(
                                "@DoctorID",
                                SqlDbType.VarChar,
                                50).Value =
                                doctorID;

                            profileExists =
                                Convert.ToInt32(
                                    profileCheckCmd.ExecuteScalar());
                        }
                        // 4. CREATE PROFILE IF NOT EXISTS

                        if (profileExists == 0)
                        {
                            string createProfileQuery = @"
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
    0,
    0,
    0,
    0
)"; 
                            using (SqlCommand createProfileCmd =
                                new SqlCommand(
                                    createProfileQuery,
                                    con,
                                    transaction))
                            {
                                createProfileCmd.Parameters.Add(
                                    "@DoctorID",
                                    SqlDbType.VarChar,
                                    50).Value =
                                    doctorID;

                                createProfileCmd.ExecuteNonQuery();
                            }
                        }
                        // 5. UPDATE DOCTOR RATING
                        string updateRatingQuery = @"
UPDATE dbo.DoctorProfile
SET
    Rating =
    (
        SELECT CAST(AVG(CAST(Rating AS DECIMAL(10,2)))
        AS DECIMAL(10,2))
        FROM dbo.DoctorReviews
        WHERE DoctorID = @DoctorID
    ),

    TotalReviews =
    (
        SELECT COUNT(*)
        FROM dbo.DoctorReviews
        WHERE DoctorID = @DoctorID
    )

WHERE DoctorID = @DoctorID";
                        using (SqlCommand updateCmd =
                            new SqlCommand(
                                updateRatingQuery,
                                con,
                                transaction))
                        {
                            updateCmd.Parameters.Add(
                                "@DoctorID",
                                SqlDbType.VarChar,
                                50).Value =
                                doctorID;

                            updateCmd.ExecuteNonQuery();
                        }

                        // 6. COMMIT EVERYTHING

                        transaction.Commit();

                        MessageBox.Show(
                            "Rating submitted successfully! ⭐\n\n" +
                            "Doctor: " + doctorID + "\n" +
                            "Rating: " + rating + " Star(s)",
                            "Rating Submitted",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult =
                            DialogResult.OK;

                        this.Close();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error submitting rating:\n\n" +
                    ex.Message,
                    "Rating Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CANCEL
        // ==========================================
        private void btnCancel_Click(
    object sender,
    EventArgs e)
        {
            this.DialogResult =
                DialogResult.Cancel;

            this.Close();
        }
    }
}
