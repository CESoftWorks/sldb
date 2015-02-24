namespace Sleep_Laboratory_DataBase
{
    partial class repfMonthlyAppointmentsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repfMonthlyAppointmentsReport));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(12, 38);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(244, 23);
            this.lblTitleLabel.TabIndex = 22;
            this.lblTitleLabel.Text = "Monthly Appointments Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Sleep Laboratory DataBase";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Select a Month:";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateReport.Image")));
            this.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReport.Location = new System.Drawing.Point(285, 80);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(188, 58);
            this.btnGenerateReport.TabIndex = 24;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // cbxMonth
            // 
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxMonth.Location = new System.Drawing.Point(100, 100);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(121, 21);
            this.cbxMonth.TabIndex = 25;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(745, 103);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(123, 35);
            this.btnGoBack.TabIndex = 26;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DataSet";
            reportDataSource2.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sleep_Laboratory_DataBase.reportMonthlyAppointments.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 144);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(868, 396);
            this.reportViewer1.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(820, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // repfMonthlyAppointmentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 552);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.cbxMonth);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.label2);
            this.Name = "repfMonthlyAppointmentsReport";
            this.Text = "Monthly Appointments Report";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ComboBox cbxMonth;
        private System.Windows.Forms.Button btnGoBack;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}