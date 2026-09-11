namespace AgriCare
{
    partial class DoctorSelectionForm
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
            this.dgbdoctorselection = new System.Windows.Forms.DataGridView();
            this.btnselectdoctor = new System.Windows.Forms.Button();
            this.btnbackdoctorselection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgbdoctorselection)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Doctor";
            // 
            // dgbdoctorselection
            // 
            this.dgbdoctorselection.BackgroundColor = System.Drawing.Color.White;
            this.dgbdoctorselection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbdoctorselection.Location = new System.Drawing.Point(111, 107);
            this.dgbdoctorselection.Name = "dgbdoctorselection";
            this.dgbdoctorselection.RowHeadersWidth = 51;
            this.dgbdoctorselection.RowTemplate.Height = 24;
            this.dgbdoctorselection.Size = new System.Drawing.Size(586, 208);
            this.dgbdoctorselection.TabIndex = 1;
            // 
            // btnselectdoctor
            // 
            this.btnselectdoctor.Location = new System.Drawing.Point(208, 351);
            this.btnselectdoctor.Name = "btnselectdoctor";
            this.btnselectdoctor.Size = new System.Drawing.Size(124, 23);
            this.btnselectdoctor.TabIndex = 2;
            this.btnselectdoctor.Text = "Select Doctor";
            this.btnselectdoctor.UseVisualStyleBackColor = true;
            this.btnselectdoctor.Click += new System.EventHandler(this.btnselectdoctor_Click_1);
            // 
            // btnbackdoctorselection
            // 
            this.btnbackdoctorselection.Location = new System.Drawing.Point(382, 350);
            this.btnbackdoctorselection.Name = "btnbackdoctorselection";
            this.btnbackdoctorselection.Size = new System.Drawing.Size(130, 23);
            this.btnbackdoctorselection.TabIndex = 3;
            this.btnbackdoctorselection.Text = "Back";
            this.btnbackdoctorselection.UseVisualStyleBackColor = true;
            this.btnbackdoctorselection.Click += new System.EventHandler(this.btnbackdoctorselection_Click);
            // 
            // DoctorSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgriCare.Properties.Resources.Farmer_deshboard_deshboard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnbackdoctorselection);
            this.Controls.Add(this.btnselectdoctor);
            this.Controls.Add(this.dgbdoctorselection);
            this.Controls.Add(this.label1);
            this.Name = "DoctorSelectionForm";
            this.Text = "DoctorSelectionForm";
            this.Load += new System.EventHandler(this.DoctorSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbdoctorselection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgbdoctorselection;
        private System.Windows.Forms.Button btnselectdoctor;
        private System.Windows.Forms.Button btnbackdoctorselection;
    }
}