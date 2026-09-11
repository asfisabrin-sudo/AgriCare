namespace AgriCare
{
    partial class TarnsferProblemForm
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
            this.listBoxfortransfer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btntransferdone = new System.Windows.Forms.Button();
            this.btncanceltransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxfortransfer
            // 
            this.listBoxfortransfer.FormattingEnabled = true;
            this.listBoxfortransfer.ItemHeight = 16;
            this.listBoxfortransfer.Location = new System.Drawing.Point(53, 93);
            this.listBoxfortransfer.Name = "listBoxfortransfer";
            this.listBoxfortransfer.Size = new System.Drawing.Size(644, 228);
            this.listBoxfortransfer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transfer problem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select a Doctor";
            // 
            // btntransferdone
            // 
            this.btntransferdone.Location = new System.Drawing.Point(240, 375);
            this.btntransferdone.Name = "btntransferdone";
            this.btntransferdone.Size = new System.Drawing.Size(75, 23);
            this.btntransferdone.TabIndex = 3;
            this.btntransferdone.Text = "Done";
            this.btntransferdone.UseVisualStyleBackColor = true;
            this.btntransferdone.Click += new System.EventHandler(this.btntransferdone_Click);
            // 
            // btncanceltransfer
            // 
            this.btncanceltransfer.Location = new System.Drawing.Point(374, 374);
            this.btncanceltransfer.Name = "btncanceltransfer";
            this.btncanceltransfer.Size = new System.Drawing.Size(75, 23);
            this.btncanceltransfer.TabIndex = 4;
            this.btncanceltransfer.Text = "Cancel";
            this.btncanceltransfer.UseVisualStyleBackColor = true;
            this.btncanceltransfer.Click += new System.EventHandler(this.btncanceltransfer_Click);
            // 
            // TarnsferProblemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncanceltransfer);
            this.Controls.Add(this.btntransferdone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxfortransfer);
            this.Name = "TarnsferProblemForm";
            this.Text = "TarnsferProblemForm";
            this.Load += new System.EventHandler(this.TarnsferProblemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxfortransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btntransferdone;
        private System.Windows.Forms.Button btncanceltransfer;
    }
}