namespace AgriCare
{
    partial class UserManagementForm
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
            this.combousermangerule = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvuser = new System.Windows.Forms.DataGridView();
            this.btnapproveusermanage = new System.Windows.Forms.Button();
            this.btnblockusermanage = new System.Windows.Forms.Button();
            this.btnrefreshusermanage = new System.Windows.Forms.Button();
            this.btnbackusermanage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvuser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Management";
            // 
            // combousermangerule
            // 
            this.combousermangerule.FormattingEnabled = true;
            this.combousermangerule.Items.AddRange(new object[] {
            "Doctor",
            "Farmer"});
            this.combousermangerule.Location = new System.Drawing.Point(194, 89);
            this.combousermangerule.Name = "combousermangerule";
            this.combousermangerule.Size = new System.Drawing.Size(121, 24);
            this.combousermangerule.TabIndex = 1;
            this.combousermangerule.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "User";
            // 
            // dgvuser
            // 
            this.dgvuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvuser.Location = new System.Drawing.Point(71, 146);
            this.dgvuser.Name = "dgvuser";
            this.dgvuser.RowHeadersWidth = 51;
            this.dgvuser.RowTemplate.Height = 24;
            this.dgvuser.Size = new System.Drawing.Size(642, 176);
            this.dgvuser.TabIndex = 3;
            // 
            // btnapproveusermanage
            // 
            this.btnapproveusermanage.Location = new System.Drawing.Point(226, 349);
            this.btnapproveusermanage.Name = "btnapproveusermanage";
            this.btnapproveusermanage.Size = new System.Drawing.Size(75, 23);
            this.btnapproveusermanage.TabIndex = 4;
            this.btnapproveusermanage.Text = "Approve";
            this.btnapproveusermanage.UseVisualStyleBackColor = true;
            this.btnapproveusermanage.Click += new System.EventHandler(this.btnapproveusermanage_Click);
            // 
            // btnblockusermanage
            // 
            this.btnblockusermanage.Location = new System.Drawing.Point(418, 348);
            this.btnblockusermanage.Name = "btnblockusermanage";
            this.btnblockusermanage.Size = new System.Drawing.Size(75, 23);
            this.btnblockusermanage.TabIndex = 5;
            this.btnblockusermanage.Text = "Block";
            this.btnblockusermanage.UseVisualStyleBackColor = true;
            this.btnblockusermanage.Click += new System.EventHandler(this.btnblockusermanage_Click);
            // 
            // btnrefreshusermanage
            // 
            this.btnrefreshusermanage.Location = new System.Drawing.Point(242, 402);
            this.btnrefreshusermanage.Name = "btnrefreshusermanage";
            this.btnrefreshusermanage.Size = new System.Drawing.Size(75, 23);
            this.btnrefreshusermanage.TabIndex = 6;
            this.btnrefreshusermanage.Text = "Refresh";
            this.btnrefreshusermanage.UseVisualStyleBackColor = true;
            this.btnrefreshusermanage.Click += new System.EventHandler(this.btnrefreshusermanage_Click);
            // 
            // btnbackusermanage
            // 
            this.btnbackusermanage.Location = new System.Drawing.Point(373, 402);
            this.btnbackusermanage.Name = "btnbackusermanage";
            this.btnbackusermanage.Size = new System.Drawing.Size(75, 23);
            this.btnbackusermanage.TabIndex = 7;
            this.btnbackusermanage.Text = "Back";
            this.btnbackusermanage.UseVisualStyleBackColor = true;
            this.btnbackusermanage.Click += new System.EventHandler(this.btnbackusermanage_Click);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnbackusermanage);
            this.Controls.Add(this.btnrefreshusermanage);
            this.Controls.Add(this.btnblockusermanage);
            this.Controls.Add(this.btnapproveusermanage);
            this.Controls.Add(this.dgvuser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combousermangerule);
            this.Controls.Add(this.label1);
            this.Name = "UserManagementForm";
            this.Text = "UserManagementForm";
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvuser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combousermangerule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvuser;
        private System.Windows.Forms.Button btnapproveusermanage;
        private System.Windows.Forms.Button btnblockusermanage;
        private System.Windows.Forms.Button btnrefreshusermanage;
        private System.Windows.Forms.Button btnbackusermanage;
    }
}