namespace AgriCare
{
    partial class PaymentManagementForm
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
            this.dgvpayment = new System.Windows.Forms.DataGridView();
            this.btndoctorpaymenet = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Management";
            // 
            // dgvpayment
            // 
            this.dgvpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpayment.Location = new System.Drawing.Point(34, 77);
            this.dgvpayment.Name = "dgvpayment";
            this.dgvpayment.RowHeadersWidth = 51;
            this.dgvpayment.RowTemplate.Height = 24;
            this.dgvpayment.Size = new System.Drawing.Size(708, 204);
            this.dgvpayment.TabIndex = 1;
            this.dgvpayment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btndoctorpaymenet
            // 
            this.btndoctorpaymenet.Location = new System.Drawing.Point(224, 316);
            this.btndoctorpaymenet.Name = "btndoctorpaymenet";
            this.btndoctorpaymenet.Size = new System.Drawing.Size(141, 32);
            this.btndoctorpaymenet.TabIndex = 2;
            this.btndoctorpaymenet.Text = "Doctor Payment";
            this.btndoctorpaymenet.UseVisualStyleBackColor = true;
            this.btndoctorpaymenet.Click += new System.EventHandler(this.btndoctorpaymenet_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(440, 316);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(139, 32);
            this.btnrefresh.TabIndex = 3;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(346, 379);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(108, 30);
            this.btnback.TabIndex = 4;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // PaymentManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btndoctorpaymenet);
            this.Controls.Add(this.dgvpayment);
            this.Controls.Add(this.label1);
            this.Name = "PaymentManagementForm";
            this.Text = "PaymentManagementForm";
            this.Load += new System.EventHandler(this.PaymentManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvpayment;
        private System.Windows.Forms.Button btndoctorpaymenet;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button btnback;
    }
}