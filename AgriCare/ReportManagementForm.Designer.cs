namespace AgriCare
{
    partial class ReportManagementForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.combostatus = new System.Windows.Forms.ComboBox();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.dgvreportmanagement = new System.Windows.Forms.DataGridView();
            this.btnviewdetails = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvreportmanagement)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filter By Status:";
            // 
            // combostatus
            // 
            this.combostatus.FormattingEnabled = true;
            this.combostatus.Items.AddRange(new object[] {
            "All ",
            "Pending ",
            "Completed ",
            "Failed"});
            this.combostatus.Location = new System.Drawing.Point(148, 88);
            this.combostatus.Name = "combostatus";
            this.combostatus.Size = new System.Drawing.Size(121, 24);
            this.combostatus.TabIndex = 2;
            this.combostatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(428, 88);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(116, 23);
            this.btnrefresh.TabIndex = 3;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // dgvreportmanagement
            // 
            this.dgvreportmanagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvreportmanagement.Location = new System.Drawing.Point(46, 147);
            this.dgvreportmanagement.Name = "dgvreportmanagement";
            this.dgvreportmanagement.RowHeadersWidth = 51;
            this.dgvreportmanagement.RowTemplate.Height = 24;
            this.dgvreportmanagement.Size = new System.Drawing.Size(677, 202);
            this.dgvreportmanagement.TabIndex = 4;
            this.dgvreportmanagement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnviewdetails
            // 
            this.btnviewdetails.Location = new System.Drawing.Point(177, 376);
            this.btnviewdetails.Name = "btnviewdetails";
            this.btnviewdetails.Size = new System.Drawing.Size(122, 30);
            this.btnviewdetails.TabIndex = 5;
            this.btnviewdetails.Text = "View Details";
            this.btnviewdetails.UseVisualStyleBackColor = true;
            this.btnviewdetails.Click += new System.EventHandler(this.btnviewdetails_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(372, 376);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(109, 30);
            this.btnback.TabIndex = 6;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // ReportManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnviewdetails);
            this.Controls.Add(this.dgvreportmanagement);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.combostatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReportManagementForm";
            this.Text = "ReportManagementForm";
            this.Load += new System.EventHandler(this.ReportManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvreportmanagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combostatus;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.DataGridView dgvreportmanagement;
        private System.Windows.Forms.Button btnviewdetails;
        private System.Windows.Forms.Button btnback;
    }
}