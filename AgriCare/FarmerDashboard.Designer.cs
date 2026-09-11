namespace AgriCare
{
    partial class FarmerDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblwelcomefdesh = new System.Windows.Forms.Label();
            this.btnreportprobfdesh = new System.Windows.Forms.Button();
            this.btnrequestfdesh = new System.Windows.Forms.Button();
            this.btnavailabledoctorfdesh = new System.Windows.Forms.Button();
            this.btnlogoutfdesh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblwelcomefdesh
            // 
            this.lblwelcomefdesh.AutoSize = true;
            this.lblwelcomefdesh.BackColor = System.Drawing.Color.Transparent;
            this.lblwelcomefdesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwelcomefdesh.Location = new System.Drawing.Point(307, 35);
            this.lblwelcomefdesh.Name = "lblwelcomefdesh";
            this.lblwelcomefdesh.Size = new System.Drawing.Size(162, 25);
            this.lblwelcomefdesh.TabIndex = 0;
            this.lblwelcomefdesh.Text = "Welcome Farmer";
            // 
            // btnreportprobfdesh
            // 
            this.btnreportprobfdesh.BackColor = System.Drawing.Color.Transparent;
            this.btnreportprobfdesh.Location = new System.Drawing.Point(280, 100);
            this.btnreportprobfdesh.Name = "btnreportprobfdesh";
            this.btnreportprobfdesh.Size = new System.Drawing.Size(203, 30);
            this.btnreportprobfdesh.TabIndex = 1;
            this.btnreportprobfdesh.Text = "Report Animal Problem";
            this.btnreportprobfdesh.UseVisualStyleBackColor = false;
            this.btnreportprobfdesh.Click += new System.EventHandler(this.btnreportprobfdesh_Click);
            // 
            // btnrequestfdesh
            // 
            this.btnrequestfdesh.BackColor = System.Drawing.Color.Transparent;
            this.btnrequestfdesh.Location = new System.Drawing.Point(280, 179);
            this.btnrequestfdesh.Name = "btnrequestfdesh";
            this.btnrequestfdesh.Size = new System.Drawing.Size(203, 29);
            this.btnrequestfdesh.TabIndex = 2;
            this.btnrequestfdesh.Text = "My Requests";
            this.btnrequestfdesh.UseVisualStyleBackColor = false;
            this.btnrequestfdesh.Click += new System.EventHandler(this.btnrequestfdesh_Click);
            // 
            // btnavailabledoctorfdesh
            // 
            this.btnavailabledoctorfdesh.Location = new System.Drawing.Point(280, 258);
            this.btnavailabledoctorfdesh.Name = "btnavailabledoctorfdesh";
            this.btnavailabledoctorfdesh.Size = new System.Drawing.Size(203, 31);
            this.btnavailabledoctorfdesh.TabIndex = 3;
            this.btnavailabledoctorfdesh.Text = "Available Doctors";
            this.btnavailabledoctorfdesh.UseVisualStyleBackColor = true;
            this.btnavailabledoctorfdesh.Click += new System.EventHandler(this.btnavailabledoctorfdesh_Click);
            // 
            // btnlogoutfdesh
            // 
            this.btnlogoutfdesh.BackColor = System.Drawing.Color.Transparent;
            this.btnlogoutfdesh.Location = new System.Drawing.Point(330, 342);
            this.btnlogoutfdesh.Name = "btnlogoutfdesh";
            this.btnlogoutfdesh.Size = new System.Drawing.Size(89, 34);
            this.btnlogoutfdesh.TabIndex = 4;
            this.btnlogoutfdesh.Text = "Logout";
            this.btnlogoutfdesh.UseVisualStyleBackColor = false;
            this.btnlogoutfdesh.Click += new System.EventHandler(this.btnlogoutfdesh_Click);
            // 
            // FarmerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgriCare.Properties.Resources.Farmer_deshboard_deshboard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnlogoutfdesh);
            this.Controls.Add(this.btnavailabledoctorfdesh);
            this.Controls.Add(this.btnrequestfdesh);
            this.Controls.Add(this.btnreportprobfdesh);
            this.Controls.Add(this.lblwelcomefdesh);
            this.Name = "FarmerDashboard";
            this.Text = "FarmerDashboard";
            this.Load += new System.EventHandler(this.FarmerDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblwelcomefdesh;
        private System.Windows.Forms.Button btnreportprobfdesh;
        private System.Windows.Forms.Button btnrequestfdesh;
        private System.Windows.Forms.Button btnavailabledoctorfdesh;
        private System.Windows.Forms.Button btnlogoutfdesh;
    }
}