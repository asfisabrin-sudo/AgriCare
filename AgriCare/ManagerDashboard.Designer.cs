namespace AgriCare
{
    partial class ManagerDashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblwantmandesh = new System.Windows.Forms.Label();
            this.btnusermandesh = new System.Windows.Forms.Button();
            this.btnreportmandesh = new System.Windows.Forms.Button();
            this.btnlogoutmandesh = new System.Windows.Forms.Button();
            this.btnpaymentmanagemanagerdesh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(305, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblwantmandesh
            // 
            this.lblwantmandesh.AutoSize = true;
            this.lblwantmandesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwantmandesh.Location = new System.Drawing.Point(311, 110);
            this.lblwantmandesh.Name = "lblwantmandesh";
            this.lblwantmandesh.Size = new System.Drawing.Size(298, 25);
            this.lblwantmandesh.TabIndex = 1;
            this.lblwantmandesh.Text = "What do you want now ,Manager";
            // 
            // btnusermandesh
            // 
            this.btnusermandesh.Location = new System.Drawing.Point(363, 178);
            this.btnusermandesh.Name = "btnusermandesh";
            this.btnusermandesh.Size = new System.Drawing.Size(200, 30);
            this.btnusermandesh.TabIndex = 4;
            this.btnusermandesh.Text = "User Management";
            this.btnusermandesh.UseVisualStyleBackColor = true;
            this.btnusermandesh.Click += new System.EventHandler(this.btnusermandesh_Click);
            // 
            // btnreportmandesh
            // 
            this.btnreportmandesh.Location = new System.Drawing.Point(363, 368);
            this.btnreportmandesh.Name = "btnreportmandesh";
            this.btnreportmandesh.Size = new System.Drawing.Size(200, 30);
            this.btnreportmandesh.TabIndex = 5;
            this.btnreportmandesh.Text = "Report Management";
            this.btnreportmandesh.UseVisualStyleBackColor = true;
            this.btnreportmandesh.Click += new System.EventHandler(this.btnreportmandesh_Click);
            // 
            // btnlogoutmandesh
            // 
            this.btnlogoutmandesh.Location = new System.Drawing.Point(388, 475);
            this.btnlogoutmandesh.Name = "btnlogoutmandesh";
            this.btnlogoutmandesh.Size = new System.Drawing.Size(100, 30);
            this.btnlogoutmandesh.TabIndex = 6;
            this.btnlogoutmandesh.Text = "Log Out";
            this.btnlogoutmandesh.UseVisualStyleBackColor = true;
            this.btnlogoutmandesh.Click += new System.EventHandler(this.btnlogoutmandesh_Click);
            // 
            // btnpaymentmanagemanagerdesh
            // 
            this.btnpaymentmanagemanagerdesh.Location = new System.Drawing.Point(363, 271);
            this.btnpaymentmanagemanagerdesh.Name = "btnpaymentmanagemanagerdesh";
            this.btnpaymentmanagemanagerdesh.Size = new System.Drawing.Size(200, 32);
            this.btnpaymentmanagemanagerdesh.TabIndex = 7;
            this.btnpaymentmanagemanagerdesh.Text = "Payment Management";
            this.btnpaymentmanagemanagerdesh.UseVisualStyleBackColor = true;
            this.btnpaymentmanagemanagerdesh.Click += new System.EventHandler(this.btnpaymentmanagemanagerdesh_Click);
            // 
            // ManagerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgriCare.Properties.Resources.managerdeshboard_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.btnpaymentmanagemanagerdesh);
            this.Controls.Add(this.btnlogoutmandesh);
            this.Controls.Add(this.btnreportmandesh);
            this.Controls.Add(this.btnusermandesh);
            this.Controls.Add(this.lblwantmandesh);
            this.Controls.Add(this.label1);
            this.Name = "ManagerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerDashboard";
            this.Load += new System.EventHandler(this.ManagerDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblwantmandesh;
        private System.Windows.Forms.Button btnusermandesh;
        private System.Windows.Forms.Button btnreportmandesh;
        private System.Windows.Forms.Button btnlogoutmandesh;
        private System.Windows.Forms.Button btnpaymentmanagemanagerdesh;
    }
}