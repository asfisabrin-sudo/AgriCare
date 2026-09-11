namespace AgriCare
{
    partial class PaymentForm
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
            this.lblpaymenttitle = new System.Windows.Forms.Label();
            this.lbldoctorpay = new System.Windows.Forms.Label();
            this.lblservicepay = new System.Windows.Forms.Label();
            this.lblamountpay = new System.Windows.Forms.Label();
            this.btnpaynow = new System.Windows.Forms.Button();
            this.btncancelpay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblpaymenttitle
            // 
            this.lblpaymenttitle.AutoSize = true;
            this.lblpaymenttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaymenttitle.Location = new System.Drawing.Point(330, 63);
            this.lblpaymenttitle.Name = "lblpaymenttitle";
            this.lblpaymenttitle.Size = new System.Drawing.Size(89, 25);
            this.lblpaymenttitle.TabIndex = 0;
            this.lblpaymenttitle.Text = "Payment";
            // 
            // lbldoctorpay
            // 
            this.lbldoctorpay.AutoSize = true;
            this.lbldoctorpay.Location = new System.Drawing.Point(89, 135);
            this.lbldoctorpay.Name = "lbldoctorpay";
            this.lbldoctorpay.Size = new System.Drawing.Size(47, 16);
            this.lbldoctorpay.TabIndex = 1;
            this.lbldoctorpay.Text = "Doctor";
            // 
            // lblservicepay
            // 
            this.lblservicepay.AutoSize = true;
            this.lblservicepay.Location = new System.Drawing.Point(92, 177);
            this.lblservicepay.Name = "lblservicepay";
            this.lblservicepay.Size = new System.Drawing.Size(53, 16);
            this.lblservicepay.TabIndex = 2;
            this.lblservicepay.Text = "Service";
            // 
            // lblamountpay
            // 
            this.lblamountpay.AutoSize = true;
            this.lblamountpay.Location = new System.Drawing.Point(92, 220);
            this.lblamountpay.Name = "lblamountpay";
            this.lblamountpay.Size = new System.Drawing.Size(52, 16);
            this.lblamountpay.TabIndex = 3;
            this.lblamountpay.Text = "Amount";
            // 
            // btnpaynow
            // 
            this.btnpaynow.Location = new System.Drawing.Point(212, 333);
            this.btnpaynow.Name = "btnpaynow";
            this.btnpaynow.Size = new System.Drawing.Size(115, 23);
            this.btnpaynow.TabIndex = 4;
            this.btnpaynow.Text = "Pay Now";
            this.btnpaynow.UseVisualStyleBackColor = true;
            this.btnpaynow.Click += new System.EventHandler(this.btnpaynow_Click);
            // 
            // btncancelpay
            // 
            this.btncancelpay.Location = new System.Drawing.Point(423, 333);
            this.btncancelpay.Name = "btncancelpay";
            this.btncancelpay.Size = new System.Drawing.Size(75, 23);
            this.btncancelpay.TabIndex = 5;
            this.btncancelpay.Text = "cancel";
            this.btncancelpay.UseVisualStyleBackColor = true;
            this.btncancelpay.Click += new System.EventHandler(this.btncancelpay_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncancelpay);
            this.Controls.Add(this.btnpaynow);
            this.Controls.Add(this.lblamountpay);
            this.Controls.Add(this.lblservicepay);
            this.Controls.Add(this.lbldoctorpay);
            this.Controls.Add(this.lblpaymenttitle);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblpaymenttitle;
        private System.Windows.Forms.Label lbldoctorpay;
        private System.Windows.Forms.Label lblservicepay;
        private System.Windows.Forms.Label lblamountpay;
        private System.Windows.Forms.Button btnpaynow;
        private System.Windows.Forms.Button btncancelpay;
    }
}