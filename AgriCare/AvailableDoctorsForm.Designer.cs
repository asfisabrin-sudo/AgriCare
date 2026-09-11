namespace AgriCare
{
    partial class AvailableDoctorsForm
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
            this.dgvdoctors = new System.Windows.Forms.DataGridView();
            this.btnbaack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Doctors";
            // 
            // dgvdoctors
            // 
            this.dgvdoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdoctors.Location = new System.Drawing.Point(87, 91);
            this.dgvdoctors.Name = "dgvdoctors";
            this.dgvdoctors.RowHeadersWidth = 51;
            this.dgvdoctors.RowTemplate.Height = 24;
            this.dgvdoctors.Size = new System.Drawing.Size(628, 211);
            this.dgvdoctors.TabIndex = 1;
            // 
            // btnbaack
            // 
            this.btnbaack.Location = new System.Drawing.Point(343, 352);
            this.btnbaack.Name = "btnbaack";
            this.btnbaack.Size = new System.Drawing.Size(75, 23);
            this.btnbaack.TabIndex = 2;
            this.btnbaack.Text = "Back";
            this.btnbaack.UseVisualStyleBackColor = true;
            this.btnbaack.Click += new System.EventHandler(this.btnbaack_Click);
            // 
            // AvailableDoctorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnbaack);
            this.Controls.Add(this.dgvdoctors);
            this.Controls.Add(this.label1);
            this.Name = "AvailableDoctorsForm";
            this.Text = "AvailableDoctorsForm";
            this.Load += new System.EventHandler(this.AvailableDoctorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvdoctors;
        private System.Windows.Forms.Button btnbaack;
    }
}