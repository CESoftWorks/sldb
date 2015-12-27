namespace Sleep_Laboratory_DataBase
{
    partial class UpcomingAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpcomingAppointments));
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnOpenPatientForm = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnCancelSelectedAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(12, 38);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(201, 23);
            this.lblTitleLabel.TabIndex = 16;
            this.lblTitleLabel.Text = "Upcoming Appointments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sleep Laboratory DataBase";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOpenPatientForm);
            this.splitContainer1.Panel2.Controls.Add(this.btnHelp);
            this.splitContainer1.Panel2.Controls.Add(this.btnGoBack);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelSelectedAppointment);
            this.splitContainer1.Size = new System.Drawing.Size(917, 394);
            this.splitContainer1.SplitterDistance = 720;
            this.splitContainer1.TabIndex = 17;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(720, 394);
            this.dataGridView.TabIndex = 0;
            // 
            // btnOpenPatientForm
            // 
            this.btnOpenPatientForm.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenPatientForm.Image")));
            this.btnOpenPatientForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenPatientForm.Location = new System.Drawing.Point(3, 3);
            this.btnOpenPatientForm.Name = "btnOpenPatientForm";
            this.btnOpenPatientForm.Size = new System.Drawing.Size(186, 72);
            this.btnOpenPatientForm.TabIndex = 4;
            this.btnOpenPatientForm.Text = "Open Selected \r\nPatient Form";
            this.btnOpenPatientForm.UseVisualStyleBackColor = true;
            this.btnOpenPatientForm.Click += new System.EventHandler(this.btnOpenPatientForm_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(3, 352);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(80, 39);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(89, 352);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(101, 39);
            this.btnGoBack.TabIndex = 2;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnCancelSelectedAppointment
            // 
            this.btnCancelSelectedAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelSelectedAppointment.Image")));
            this.btnCancelSelectedAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelSelectedAppointment.Location = new System.Drawing.Point(3, 95);
            this.btnCancelSelectedAppointment.Name = "btnCancelSelectedAppointment";
            this.btnCancelSelectedAppointment.Size = new System.Drawing.Size(186, 72);
            this.btnCancelSelectedAppointment.TabIndex = 1;
            this.btnCancelSelectedAppointment.Text = "Cancel Selected \r\nAppointment";
            this.btnCancelSelectedAppointment.UseVisualStyleBackColor = true;
            this.btnCancelSelectedAppointment.Click += new System.EventHandler(this.btnCancelSelectedAppointment_Click);
            // 
            // UpcomingAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 470);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpcomingAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpcomingAppointments";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnCancelSelectedAppointment;
        private System.Windows.Forms.Button btnOpenPatientForm;
    }
}