using System;
using System.Windows.Forms;

namespace AgriCare
{
    public partial class ReportProblemForm : Form
    {
        private string farmerID;
        public ReportProblemForm(string farmerID)
        {
            InitializeComponent();

            this.farmerID = farmerID;

            // Service Type
            comboservicetype.Items.Clear();
            comboservicetype.Items.Add("Online Advice");
            comboservicetype.Items.Add("Farm Visit");

            // Animal Type
            comboanimaltype.Items.Clear();
            comboanimaltype.Items.Add("Cow");
            comboanimaltype.Items.Add("Goat");
            comboanimaltype.Items.Add("Buffalo");
            comboanimaltype.Items.Add("Sheep");
            comboanimaltype.Items.Add("Chicken");
            comboanimaltype.Items.Add("Duck");
            comboanimaltype.Items.Add("Other");

            comboservicetype.SelectedIndexChanged +=
                comboservicetype_SelectedIndexChanged;
            
        }
        
        private void ReportProblemForm_Load(object sender, EventArgs e)
        {
            comboanimaltype.SelectedIndex = 0;
            comboservicetype.SelectedIndex = 0;

            txtfarmaddress.Enabled = false;
        }
        private void comboservicetype_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (comboservicetype.SelectedItem != null &&
                comboservicetype.SelectedItem.ToString() == "Farm Visit")
            {
                txtfarmaddress.Enabled = true;
            }
            else
            {
                txtfarmaddress.Enabled = false;
                txtfarmaddress.Clear();
            }
        }

       

        

        private void btnselectdoctor_Click(object sender, EventArgs e)
        {
            // Animal name validation
            if (string.IsNullOrWhiteSpace(txtanimalname.Text))
            {
                MessageBox.Show(
                    "Please enter animal name.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtanimalname.Focus();
                return;
            }

            // Problem description validation
            if (string.IsNullOrWhiteSpace(txtproblemdescription.Text))
            {
                MessageBox.Show(
                    "Please describe the animal problem.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtproblemdescription.Focus();
                return;
            }

            // Farm Visit হলে address লাগবে
            if (comboservicetype.SelectedItem != null &&
                comboservicetype.SelectedItem.ToString() == "Farm Visit" &&
                string.IsNullOrWhiteSpace(txtfarmaddress.Text))
            {
                MessageBox.Show(
                    "Please enter farm address for farm visit.",
                    "Warning",
                   MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtfarmaddress.Focus();
                return;
            }

            string animalName = txtanimalname.Text.Trim();
            string animalType = comboanimaltype.SelectedItem.ToString();
            string problemDescription = txtproblemdescription.Text.Trim();
            string serviceType = comboservicetype.SelectedItem.ToString();
            string farmAddress = txtfarmaddress.Text.Trim();

            // Open Doctor Selection Form
            DoctorSelectionForm doctorForm =
                new DoctorSelectionForm(
                    farmerID,
                    animalName,
                    animalType,
                    problemDescription,
                    serviceType,
                    farmAddress
                );

            doctorForm.ShowDialog();
        }

        private void btncancelselectdoctor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}