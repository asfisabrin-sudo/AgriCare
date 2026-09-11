namespace AgriCare
{
    partial class AgriCare
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsigninagri = new System.Windows.Forms.Button();
            this.btnloginagri = new System.Windows.Forms.Button();
            this.txtpassagri = new System.Windows.Forms.TextBox();
            this.txtuseridagri = new System.Windows.Forms.TextBox();
            this.lablpassagri = new System.Windows.Forms.Label();
            this.lbluseridagri = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnsigninagri);
            this.panel1.Controls.Add(this.btnloginagri);
            this.panel1.Controls.Add(this.txtpassagri);
            this.panel1.Controls.Add(this.txtuseridagri);
            this.panel1.Controls.Add(this.lablpassagri);
            this.panel1.Controls.Add(this.lbluseridagri);
            this.panel1.Location = new System.Drawing.Point(305, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 309);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnsigninagri
            // 
            this.btnsigninagri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnsigninagri.Location = new System.Drawing.Point(223, 244);
            this.btnsigninagri.Name = "btnsigninagri";
            this.btnsigninagri.Size = new System.Drawing.Size(75, 23);
            this.btnsigninagri.TabIndex = 5;
            this.btnsigninagri.Text = "Sign In";
            this.btnsigninagri.UseVisualStyleBackColor = false;
            this.btnsigninagri.Click += new System.EventHandler(this.btnsigninagri_Click);
            // 
            // btnloginagri
            // 
            this.btnloginagri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnloginagri.Location = new System.Drawing.Point(77, 244);
            this.btnloginagri.Name = "btnloginagri";
            this.btnloginagri.Size = new System.Drawing.Size(75, 23);
            this.btnloginagri.TabIndex = 4;
            this.btnloginagri.Text = "Log In";
            this.btnloginagri.UseVisualStyleBackColor = false;
            this.btnloginagri.Click += new System.EventHandler(this.btnloginagri_Click);
            // 
            // txtpassagri
            // 
            this.txtpassagri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtpassagri.Location = new System.Drawing.Point(153, 183);
            this.txtpassagri.Name = "txtpassagri";
            this.txtpassagri.Size = new System.Drawing.Size(189, 22);
            this.txtpassagri.TabIndex = 3;
            // 
            // txtuseridagri
            // 
            this.txtuseridagri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtuseridagri.Location = new System.Drawing.Point(153, 120);
            this.txtuseridagri.Name = "txtuseridagri";
            this.txtuseridagri.Size = new System.Drawing.Size(189, 22);
            this.txtuseridagri.TabIndex = 2;
            // 
            // lablpassagri
            // 
            this.lablpassagri.AutoSize = true;
            this.lablpassagri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lablpassagri.Location = new System.Drawing.Point(34, 183);
            this.lablpassagri.Name = "lablpassagri";
            this.lablpassagri.Size = new System.Drawing.Size(67, 16);
            this.lablpassagri.TabIndex = 1;
            this.lablpassagri.Text = "Password";
            // 
            // lbluseridagri
            // 
            this.lbluseridagri.AutoSize = true;
            this.lbluseridagri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbluseridagri.Location = new System.Drawing.Point(49, 126);
            this.lbluseridagri.Name = "lbluseridagri";
            this.lbluseridagri.Size = new System.Drawing.Size(52, 16);
            this.lbluseridagri.TabIndex = 0;
            this.lbluseridagri.Text = "User ID";
            // 
            // AgriCare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgriCare.Properties.Resources.agri_care_login_page_background_image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 549);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AgriCare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgriCare";
            this.Load += new System.EventHandler(this.AgriCare_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbluseridagri;
        private System.Windows.Forms.TextBox txtuseridagri;
        private System.Windows.Forms.Label lablpassagri;
        private System.Windows.Forms.TextBox txtpassagri;
        private System.Windows.Forms.Button btnsigninagri;
        private System.Windows.Forms.Button btnloginagri;
    }
}

