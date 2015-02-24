namespace Sleep_Laboratory_DataBase
{
    partial class ReportSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSelector));
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSynopticPatientReport = new System.Windows.Forms.Button();
            this.btnMonthlyAppointmentReport = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(12, 38);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(368, 23);
            this.lblTitleLabel.TabIndex = 18;
            this.lblTitleLabel.Text = "Please select the type of report to be produced";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Sleep Laboratory DataBase";
            // 
            // btnSynopticPatientReport
            // 
            this.btnSynopticPatientReport.Image = ((System.Drawing.Image)(resources.GetObject("btnSynopticPatientReport.Image")));
            this.btnSynopticPatientReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSynopticPatientReport.Location = new System.Drawing.Point(16, 83);
            this.btnSynopticPatientReport.Name = "btnSynopticPatientReport";
            this.btnSynopticPatientReport.Size = new System.Drawing.Size(175, 109);
            this.btnSynopticPatientReport.TabIndex = 19;
            this.btnSynopticPatientReport.Text = "Synoptic Patient Report";
            this.btnSynopticPatientReport.UseVisualStyleBackColor = true;
            this.btnSynopticPatientReport.Click += new System.EventHandler(this.btnSynopticPatientReport_Click);
            // 
            // btnMonthlyAppointmentReport
            // 
            this.btnMonthlyAppointmentReport.Image = ((System.Drawing.Image)(resources.GetObject("btnMonthlyAppointmentReport.Image")));
            this.btnMonthlyAppointmentReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonthlyAppointmentReport.Location = new System.Drawing.Point(228, 83);
            this.btnMonthlyAppointmentReport.Name = "btnMonthlyAppointmentReport";
            this.btnMonthlyAppointmentReport.Size = new System.Drawing.Size(175, 109);
            this.btnMonthlyAppointmentReport.TabIndex = 20;
            this.btnMonthlyAppointmentReport.Text = "Monthly Appointment \r\nOverview Report";
            this.btnMonthlyAppointmentReport.UseVisualStyleBackColor = true;
            this.btnMonthlyAppointmentReport.Click += new System.EventHandler(this.btnMonthlyAppointmentReport_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(317, 232);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(102, 32);
            this.btnGoBack.TabIndex = 21;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(217, 232);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(94, 32);
            this.btnHelp.TabIndex = 22;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // ReportSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 276);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnMonthlyAppointmentReport);
            this.Controls.Add(this.btnSynopticPatientReport);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSynopticPatientReport;
        private System.Windows.Forms.Button btnMonthlyAppointmentReport;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnHelp;
    }
}