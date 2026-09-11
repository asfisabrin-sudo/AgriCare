namespace AgriCare
{
    partial class DoctorDeshboard
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
            this.lblwelcomeddesh = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btntransferddesh = new System.Windows.Forms.Button();
            this.btnlogoutddeshp1 = new System.Windows.Forms.Button();
            this.btncompleteddeshp1 = new System.Windows.Forms.Button();
            this.btnassignedddeshp1 = new System.Windows.Forms.Button();
            this.dgvassignedproblem = new System.Windows.Forms.DataGridView();
            this.reportid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.farmername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.problemdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvassignedproblem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblwelcomeddesh
            // 
            this.lblwelcomeddesh.AutoSize = true;
            this.lblwelcomeddesh.BackColor = System.Drawing.Color.Transparent;
            this.lblwelcomeddesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwelcomeddesh.Location = new System.Drawing.Point(351, 32);
            this.lblwelcomeddesh.Name = "lblwelcomeddesh";
            this.lblwelcomeddesh.Size = new System.Drawing.Size(230, 32);
            this.lblwelcomeddesh.TabIndex = 0;
            this.lblwelcomeddesh.Text = "Welcome, Doctor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btntransferddesh);
            this.panel1.Controls.Add(this.btnlogoutddeshp1);
            this.panel1.Controls.Add(this.btncompleteddeshp1);
            this.panel1.Controls.Add(this.btnassignedddeshp1);
            this.panel1.Location = new System.Drawing.Point(12, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 387);
            this.panel1.TabIndex = 1;
            // 
            // btntransferddesh
            // 
            this.btntransferddesh.Location = new System.Drawing.Point(55, 229);
            this.btntransferddesh.Name = "btntransferddesh";
            this.btntransferddesh.Size = new System.Drawing.Size(200, 33);
            this.btntransferddesh.TabIndex = 5;
            this.btntransferddesh.Text = "Transfer";
            this.btntransferddesh.UseVisualStyleBackColor = true;
            this.btntransferddesh.Click += new System.EventHandler(this.btntransferddesh_Click);
            // 
            // btnlogoutddeshp1
            // 
            this.btnlogoutddeshp1.Location = new System.Drawing.Point(101, 307);
            this.btnlogoutddeshp1.Name = "btnlogoutddeshp1";
            this.btnlogoutddeshp1.Size = new System.Drawing.Size(100, 30);
            this.btnlogoutddeshp1.TabIndex = 4;
            this.btnlogoutddeshp1.Text = "Log Out";
            this.btnlogoutddeshp1.UseVisualStyleBackColor = true;
            this.btnlogoutddeshp1.Click += new System.EventHandler(this.btnlogoutddeshp1_Click);
            // 
            // btncompleteddeshp1
            // 
            this.btncompleteddeshp1.Location = new System.Drawing.Point(55, 149);
            this.btncompleteddeshp1.Name = "btncompleteddeshp1";
            this.btncompleteddeshp1.Size = new System.Drawing.Size(200, 30);
            this.btncompleteddeshp1.TabIndex = 3;
            this.btncompleteddeshp1.Text = "Complete Report";
            this.btncompleteddeshp1.UseVisualStyleBackColor = true;
            this.btncompleteddeshp1.Click += new System.EventHandler(this.btncompleteddeshp1_Click);
            // 
            // btnassignedddeshp1
            // 
            this.btnassignedddeshp1.Location = new System.Drawing.Point(55, 63);
            this.btnassignedddeshp1.Name = "btnassignedddeshp1";
            this.btnassignedddeshp1.Size = new System.Drawing.Size(200, 30);
            this.btnassignedddeshp1.TabIndex = 1;
            this.btnassignedddeshp1.Text = "Assigned";
            this.btnassignedddeshp1.UseVisualStyleBackColor = true;
            this.btnassignedddeshp1.Click += new System.EventHandler(this.btnassignedddeshp1_Click);
            // 
            // dgvassignedproblem
            // 
            this.dgvassignedproblem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvassignedproblem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reportid,
            this.farmername,
            this.animalname,
            this.problemdescription,
            this.reportdate});
            this.dgvassignedproblem.Location = new System.Drawing.Point(347, 85);
            this.dgvassignedproblem.Name = "dgvassignedproblem";
            this.dgvassignedproblem.RowHeadersWidth = 51;
            this.dgvassignedproblem.RowTemplate.Height = 24;
            this.dgvassignedproblem.Size = new System.Drawing.Size(578, 337);
            this.dgvassignedproblem.TabIndex = 3;
            // 
            // reportid
            // 
            this.reportid.HeaderText = "Report ID";
            this.reportid.MinimumWidth = 6;
            this.reportid.Name = "reportid";
            this.reportid.Width = 125;
            // 
            // farmername
            // 
            this.farmername.HeaderText = "Farmer";
            this.farmername.MinimumWidth = 6;
            this.farmername.Name = "farmername";
            this.farmername.Width = 125;
            // 
            // animalname
            // 
            this.animalname.HeaderText = "Animal ";
            this.animalname.MinimumWidth = 6;
            this.animalname.Name = "animalname";
            this.animalname.Width = 125;
            // 
            // problemdescription
            // 
            this.problemdescription.HeaderText = "Problem";
            this.problemdescription.MinimumWidth = 6;
            this.problemdescription.Name = "problemdescription";
            this.problemdescription.Width = 125;
            // 
            // reportdate
            // 
            this.reportdate.HeaderText = "Report";
            this.reportdate.MinimumWidth = 6;
            this.reportdate.Name = "reportdate";
            this.reportdate.Width = 125;
            // 
            // DoctorDeshboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgriCare.Properties.Resources.Doctor_deshboard_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.dgvassignedproblem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblwelcomeddesh);
            this.Name = "DoctorDeshboard";
            this.Text = "DoctorDeshboard";
            this.Load += new System.EventHandler(this.DoctorDeshboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvassignedproblem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblwelcomeddesh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnassignedddeshp1;
        private System.Windows.Forms.Button btnlogoutddeshp1;
        private System.Windows.Forms.Button btncompleteddeshp1;
        private System.Windows.Forms.DataGridView dgvassignedproblem;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportid;
        private System.Windows.Forms.DataGridViewTextBoxColumn farmername;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalname;
        private System.Windows.Forms.DataGridViewTextBoxColumn problemdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportdate;
        private System.Windows.Forms.Button btntransferddesh;
    }
}