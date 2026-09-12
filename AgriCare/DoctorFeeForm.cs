// This form sets the online advice fee and farm visit fee for a newly approved doctorusing System;
using System.Drawing;
using System.Windows.Forms;

namespace AgriCare
{
    public class DoctorFeeForm : Form
    {
        private Label lblTitle;
        private Label lblOnline;
        private Label lblFarm;

        private NumericUpDown nudOnlineFee;
        private NumericUpDown nudFarmFee;

        private Button btnSave;
        private Button btnCancel;

        public decimal OnlineAdviceFee
        {
            get { return nudOnlineFee.Value; }
        }

        public decimal FarmVisitFee
        {
            get { return nudFarmFee.Value; }
        }

        public DoctorFeeForm(string doctorName)
        {
            Text = "Doctor Service Fees";
            Size = new Size(430, 330);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // =========================
            // TITLE
            // =========================
            lblTitle = new Label();
            lblTitle.Text = "Set Service Fees";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(125, 25);

            // =========================
            // DOCTOR NAME
            // =========================
            Label lblDoctor = new Label();
            lblDoctor.Text = "Doctor: " + doctorName;
            lblDoctor.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(30, 70);

            // =========================
            // ONLINE ADVICE
            // =========================
            lblOnline = new Label();
            lblOnline.Text = "Online Advice Fee:";
            lblOnline.AutoSize = true;
            lblOnline.Location = new Point(30, 115);

            nudOnlineFee = new NumericUpDown();
            nudOnlineFee.Location = new Point(210, 110);
            nudOnlineFee.Size = new Size(150, 30);
            nudOnlineFee.Minimum = 1;
            nudOnlineFee.Maximum = 1000000;
            nudOnlineFee.DecimalPlaces = 2;
            nudOnlineFee.Increment = 50;
            nudOnlineFee.Value = 500;

            // =========================
            // FARM VISIT
            // =========================
            lblFarm = new Label();
            lblFarm.Text = "Farm Visit Fee:";
            lblFarm.AutoSize = true;
            lblFarm.Location = new Point(30, 160);

            nudFarmFee = new NumericUpDown();
            nudFarmFee.Location = new Point(210, 155);
            nudFarmFee.Size = new Size(150, 30);
            nudFarmFee.Minimum = 1;
            nudFarmFee.Maximum = 1000000;
            nudFarmFee.DecimalPlaces = 2;
            nudFarmFee.Increment = 50;
            nudFarmFee.Value = 1000;

            // =========================
            // SAVE BUTTON
            // =========================
            btnSave = new Button();
            btnSave.Text = "Save & Approve";
            btnSave.Size = new Size(140, 40);
            btnSave.Location = new Point(70, 215);
            btnSave.BackColor = Color.SeaGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;

            btnSave.Click += BtnSave_Click;

            // =========================
            // CANCEL BUTTON
            // =========================
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.Location = new Point(235, 215);
            btnCancel.FlatStyle = FlatStyle.Flat;

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            // =========================
            // ADD CONTROLS
            // =========================
            Controls.Add(lblTitle);
            Controls.Add(lblDoctor);

            Controls.Add(lblOnline);
            Controls.Add(nudOnlineFee);

            Controls.Add(lblFarm);
            Controls.Add(nudFarmFee);

            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (nudOnlineFee.Value <= 0)
            {
                MessageBox.Show(
                    "Online Advice Fee must be greater than 0.",
                    "Invalid Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (nudFarmFee.Value <= 0)
            {
                MessageBox.Show(
                    "Farm Visit Fee must be greater than 0.",
                    "Invalid Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
