namespace AgriCare
{
    partial class ReportProblemForm
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
            this.txtanimalname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboanimaltype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtproblemdescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboservicetype = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfarmaddress = new System.Windows.Forms.TextBox();
            this.btnselectdoctor = new System.Windows.Forms.Button();
            this.btncancelselectdoctor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Problem Form";
            // 
            // txtanimalname
            // 
            this.txtanimalname.Location = new System.Drawing.Point(359, 126);
            this.txtanimalname.Name = "txtanimalname";
            this.txtanimalname.Size = new System.Drawing.Size(176, 22);
            this.txtanimalname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(216, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Animal Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(219, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Animal Type";
            // 
            // comboanimaltype
            // 
            this.comboanimaltype.FormattingEnabled = true;
            this.comboanimaltype.Items.AddRange(new object[] {
            "Cow",
            "Goat",
            "Buffalo",
            "Sheep",
            "Chicken",
            "Duck",
            "Other"});
            this.comboanimaltype.Location = new System.Drawing.Point(359, 172);
            this.comboanimaltype.Name = "comboanimaltype";
            this.comboanimaltype.Size = new System.Drawing.Size(176, 24);
            this.comboanimaltype.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(219, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Problem Description";
            // 
            // txtproblemdescription
            // 
            this.txtproblemdescription.Location = new System.Drawing.Point(359, 220);
            this.txtproblemdescription.Name = "txtproblemdescription";
            this.txtproblemdescription.Size = new System.Drawing.Size(176, 22);
            this.txtproblemdescription.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(219, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Service Type";
            // 
            // comboservicetype
            // 
            this.comboservicetype.FormattingEnabled = true;
            this.comboservicetype.Items.AddRange(new object[] {
            "Advice",
            "Farm Visit"});
            this.comboservicetype.Location = new System.Drawing.Point(359, 268);
            this.comboservicetype.Name = "comboservicetype";
            this.comboservicetype.Size = new System.Drawing.Size(180, 24);
            this.comboservicetype.TabIndex = 8;
            this.comboservicetype.SelectedIndexChanged += new System.EventHandler(this.comboservicetype_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(222, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Farm Address";
            // 
            // txtfarmaddress
            // 
            this.txtfarmaddress.Location = new System.Drawing.Point(359, 319);
            this.txtfarmaddress.Name = "txtfarmaddress";
            this.txtfarmaddress.Size = new System.Drawing.Size(180, 22);
            this.txtfarmaddress.TabIndex = 10;
            // 
            // btnselectdoctor
            // 
            this.btnselectdoctor.Location = new System.Drawing.Point(201, 383);
            this.btnselectdoctor.Name = "btnselectdoctor";
            this.btnselectdoctor.Size = new System.Drawing.Size(161, 23);
            this.btnselectdoctor.TabIndex = 11;
            this.btnselectdoctor.Text = "Select Doctor";
            this.btnselectdoctor.UseVisualStyleBackColor = true;
            this.btnselectdoctor.Click += new System.EventHandler(this.btnselectdoctor_Click);
            // 
            // btncancelselectdoctor
            // 
            this.btncancelselectdoctor.Location = new System.Drawing.Point(434, 383);
            this.btncancelselectdoctor.Name = "btncancelselectdoctor";
            this.btncancelselectdoctor.Size = new System.Drawing.Size(170, 23);
            this.btncancelselectdoctor.TabIndex = 12;
            this.btncancelselectdoctor.Text = "Cancel";
            this.btncancelselectdoctor.UseVisualStyleBackColor = true;
            this.btncancelselectdoctor.Click += new System.EventHandler(this.btncancelselectdoctor_Click);
            // 
            // ReportProblemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::AgriCare.Properties.Resources.Farmer_deshboard_deshboard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncancelselectdoctor);
            this.Controls.Add(this.btnselectdoctor);
            this.Controls.Add(this.txtfarmaddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboservicetype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtproblemdescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboanimaltype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtanimalname);
            this.Controls.Add(this.label1);
            this.Name = "ReportProblemForm";
            this.Text = "ReportProblemForm";
            this.Load += new System.EventHandler(this.ReportProblemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtanimalname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboanimaltype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtproblemdescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboservicetype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtfarmaddress;
        private System.Windows.Forms.Button btnselectdoctor;
        private System.Windows.Forms.Button btncancelselectdoctor;
    }
}