namespace AgriCare
{
    partial class MyRequestsForm
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
            this.dgvmyrequests = new System.Windows.Forms.DataGridView();
            this.btnback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmyrequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvmyrequests
            // 
            this.dgvmyrequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmyrequests.Location = new System.Drawing.Point(43, 96);
            this.dgvmyrequests.Name = "dgvmyrequests";
            this.dgvmyrequests.RowHeadersWidth = 51;
            this.dgvmyrequests.RowTemplate.Height = 24;
            this.dgvmyrequests.Size = new System.Drawing.Size(710, 240);
            this.dgvmyrequests.TabIndex = 0;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(349, 380);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "My Service Requests";
            // 
            // MyRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.dgvmyrequests);
            this.Name = "MyRequestsForm";
            this.Text = "MyRequestsForm";
            this.Load += new System.EventHandler(this.MyRequestsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmyrequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvmyrequests;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label1;
    }
}