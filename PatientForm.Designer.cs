namespace Sleep_Laboratory_DataBase
{
    partial class PatientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientForm));
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtBriefAssessment = new System.Windows.Forms.TextBox();
            this.txtEpsworthScale = new System.Windows.Forms.TextBox();
            this.txtBMI = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.dateDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.btnBMICalculate = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridViewAppointments = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSubmitChangesAppointment = new System.Windows.Forms.Button();
            this.btnDeleteSelectedAppointment = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnPSGDetails = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtTreatment = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAHI = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblPSGAppointmentIndicator = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dateAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblLabel17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radShowFollowUp = new System.Windows.Forms.RadioButton();
            this.radShowPSG = new System.Windows.Forms.RadioButton();
            this.radShowPreviousOnly = new System.Windows.Forms.RadioButton();
            this.radShowUpcomingOnly = new System.Windows.Forms.RadioButton();
            this.radShowAll = new System.Windows.Forms.RadioButton();
            this.btnAddToWaitingList = new System.Windows.Forms.Button();
            this.btnPSGNewAppointment = new System.Windows.Forms.Button();
            this.btnFollowUpNewAppointment = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSubmitChangesPatient = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(12, 38);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(110, 23);
            this.lblTitleLabel.TabIndex = 10;
            this.lblTitleLabel.Text = "Patient Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sleep Laboratory DataBase";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtBriefAssessment);
            this.splitContainer1.Panel1.Controls.Add(this.txtEpsworthScale);
            this.splitContainer1.Panel1.Controls.Add(this.txtBMI);
            this.splitContainer1.Panel1.Controls.Add(this.txtWeight);
            this.splitContainer1.Panel1.Controls.Add(this.txtHeight);
            this.splitContainer1.Panel1.Controls.Add(this.txtPhoneNumber);
            this.splitContainer1.Panel1.Controls.Add(this.dateDateOfBirth);
            this.splitContainer1.Panel1.Controls.Add(this.cbxSex);
            this.splitContainer1.Panel1.Controls.Add(this.txtSurname);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.txtPatientID);
            this.splitContainer1.Panel1.Controls.Add(this.btnBMICalculate);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewAppointments);
            this.splitContainer1.Size = new System.Drawing.Size(1170, 295);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 11;
            // 
            // txtBriefAssessment
            // 
            this.txtBriefAssessment.Location = new System.Drawing.Point(94, 203);
            this.txtBriefAssessment.Multiline = true;
            this.txtBriefAssessment.Name = "txtBriefAssessment";
            this.txtBriefAssessment.Size = new System.Drawing.Size(227, 89);
            this.txtBriefAssessment.TabIndex = 74;
            // 
            // txtEpsworthScale
            // 
            this.txtEpsworthScale.Location = new System.Drawing.Point(391, 42);
            this.txtEpsworthScale.Name = "txtEpsworthScale";
            this.txtEpsworthScale.Size = new System.Drawing.Size(82, 20);
            this.txtEpsworthScale.TabIndex = 73;
            this.txtEpsworthScale.Text = "0";
            // 
            // txtBMI
            // 
            this.txtBMI.Location = new System.Drawing.Point(391, 128);
            this.txtBMI.Name = "txtBMI";
            this.txtBMI.Size = new System.Drawing.Size(82, 20);
            this.txtBMI.TabIndex = 72;
            this.txtBMI.Text = "0";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(391, 102);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(82, 20);
            this.txtWeight.TabIndex = 71;
            this.txtWeight.Text = "0";
            // 
            // txtHeight
            // 
            this.txtHeight.AccessibleDescription = "Height in cm";
            this.txtHeight.Location = new System.Drawing.Point(391, 76);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(82, 20);
            this.txtHeight.TabIndex = 70;
            this.txtHeight.Text = "0";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(94, 170);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(134, 20);
            this.txtPhoneNumber.TabIndex = 69;
            // 
            // dateDateOfBirth
            // 
            this.dateDateOfBirth.Location = new System.Drawing.Point(94, 125);
            this.dateDateOfBirth.Name = "dateDateOfBirth";
            this.dateDateOfBirth.Size = new System.Drawing.Size(155, 20);
            this.dateDateOfBirth.TabIndex = 68;
            // 
            // cbxSex
            // 
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbxSex.Location = new System.Drawing.Point(247, 95);
            this.cbxSex.MaxDropDownItems = 2;
            this.cbxSex.MaxLength = 1;
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(50, 21);
            this.cbxSex.TabIndex = 67;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(94, 99);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(134, 20);
            this.txtSurname.TabIndex = 66;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(94, 73);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(134, 20);
            this.txtName.TabIndex = 65;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(79, 41);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(77, 20);
            this.txtPatientID.TabIndex = 64;
            // 
            // btnBMICalculate
            // 
            this.btnBMICalculate.Location = new System.Drawing.Point(374, 158);
            this.btnBMICalculate.Name = "btnBMICalculate";
            this.btnBMICalculate.Size = new System.Drawing.Size(99, 54);
            this.btnBMICalculate.TabIndex = 63;
            this.btnBMICalculate.Text = "Calculate\r\na new BMI";
            this.btnBMICalculate.UseVisualStyleBackColor = true;
            this.btnBMICalculate.Click += new System.EventHandler(this.btnBMICalculate_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 48);
            this.label12.TabIndex = 62;
            this.label12.Text = "Brief\r\nClinical \r\nAssessment:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(322, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 32);
            this.label11.TabIndex = 59;
            this.label11.Text = "Epsworth\r\nScale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(351, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 61;
            this.label10.Text = "BMI:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(335, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 60;
            this.label9.Text = "Weight:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(335, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 58;
            this.label8.Text = "Height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 32);
            this.label7.TabIndex = 56;
            this.label7.Text = "Phone\r\nNumber:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "Date of Birth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "Sex:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Surname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.TabIndex = 52;
            this.label13.Text = "Patient ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Patient Details";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(397, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 284);
            this.panel1.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 22);
            this.label14.TabIndex = 14;
            this.label14.Text = "Appointments";
            // 
            // dataGridViewAppointments
            // 
            this.dataGridViewAppointments.AllowUserToAddRows = false;
            this.dataGridViewAppointments.AllowUserToDeleteRows = false;
            this.dataGridViewAppointments.AllowUserToResizeRows = false;
            this.dataGridViewAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppointments.Location = new System.Drawing.Point(3, 30);
            this.dataGridViewAppointments.MultiSelect = false;
            this.dataGridViewAppointments.Name = "dataGridViewAppointments";
            this.dataGridViewAppointments.ReadOnly = true;
            this.dataGridViewAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAppointments.Size = new System.Drawing.Size(679, 262);
            this.dataGridViewAppointments.TabIndex = 0;
            this.dataGridViewAppointments.SelectionChanged += new System.EventHandler(this.dataGridViewAppointments_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSubmitChangesAppointment);
            this.panel2.Controls.Add(this.btnDeleteSelectedAppointment);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.btnPSGDetails);
            this.panel2.Controls.Add(this.txtNotes);
            this.panel2.Controls.Add(this.txtTreatment);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtAHI);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtDiagnosis);
            this.panel2.Controls.Add(this.lblPSGAppointmentIndicator);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.dateAppointmentDate);
            this.panel2.Controls.Add(this.lblLabel17);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(409, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 280);
            this.panel2.TabIndex = 12;
            // 
            // btnSubmitChangesAppointment
            // 
            this.btnSubmitChangesAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmitChangesAppointment.Image")));
            this.btnSubmitChangesAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmitChangesAppointment.Location = new System.Drawing.Point(249, 32);
            this.btnSubmitChangesAppointment.Name = "btnSubmitChangesAppointment";
            this.btnSubmitChangesAppointment.Size = new System.Drawing.Size(133, 61);
            this.btnSubmitChangesAppointment.TabIndex = 19;
            this.btnSubmitChangesAppointment.Text = "Submit Changes\r\nto Appointment\r\nDetails";
            this.btnSubmitChangesAppointment.UseVisualStyleBackColor = true;
            this.btnSubmitChangesAppointment.Click += new System.EventHandler(this.btnSubmitChangesAppointment_Click);
            // 
            // btnDeleteSelectedAppointment
            // 
            this.btnDeleteSelectedAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSelectedAppointment.Image")));
            this.btnDeleteSelectedAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSelectedAppointment.Location = new System.Drawing.Point(530, 30);
            this.btnDeleteSelectedAppointment.Name = "btnDeleteSelectedAppointment";
            this.btnDeleteSelectedAppointment.Size = new System.Drawing.Size(89, 63);
            this.btnDeleteSelectedAppointment.TabIndex = 26;
            this.btnDeleteSelectedAppointment.Text = "Delete";
            this.btnDeleteSelectedAppointment.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedAppointment.Click += new System.EventHandler(this.btnDeleteSelectedAppointment_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(275, 175);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Additional Notes:";
            // 
            // btnPSGDetails
            // 
            this.btnPSGDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnPSGDetails.Image")));
            this.btnPSGDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPSGDetails.Location = new System.Drawing.Point(388, 30);
            this.btnPSGDetails.Name = "btnPSGDetails";
            this.btnPSGDetails.Size = new System.Drawing.Size(136, 63);
            this.btnPSGDetails.TabIndex = 24;
            this.btnPSGDetails.Text = "Open \r\nPolysomnography\r\nDetails";
            this.btnPSGDetails.UseVisualStyleBackColor = true;
            this.btnPSGDetails.Click += new System.EventHandler(this.btnPSGDetails_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(278, 191);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(246, 80);
            this.txtNotes.TabIndex = 23;
            // 
            // txtTreatment
            // 
            this.txtTreatment.Location = new System.Drawing.Point(278, 129);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.Size = new System.Drawing.Size(246, 40);
            this.txtTreatment.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(275, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Treatment:";
            // 
            // txtAHI
            // 
            this.txtAHI.Location = new System.Drawing.Point(7, 221);
            this.txtAHI.Name = "txtAHI";
            this.txtAHI.Size = new System.Drawing.Size(100, 20);
            this.txtAHI.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 205);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "A/H Index (AHI):";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(7, 130);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(228, 69);
            this.txtDiagnosis.TabIndex = 19;
            // 
            // lblPSGAppointmentIndicator
            // 
            this.lblPSGAppointmentIndicator.AutoSize = true;
            this.lblPSGAppointmentIndicator.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPSGAppointmentIndicator.Location = new System.Drawing.Point(3, 30);
            this.lblPSGAppointmentIndicator.Name = "lblPSGAppointmentIndicator";
            this.lblPSGAppointmentIndicator.Size = new System.Drawing.Size(161, 21);
            this.lblPSGAppointmentIndicator.TabIndex = 18;
            this.lblPSGAppointmentIndicator.Text = "No Appointments found!";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Diagnosis:";
            // 
            // dateAppointmentDate
            // 
            this.dateAppointmentDate.Location = new System.Drawing.Point(7, 76);
            this.dateAppointmentDate.Name = "dateAppointmentDate";
            this.dateAppointmentDate.Size = new System.Drawing.Size(200, 20);
            this.dateAppointmentDate.TabIndex = 16;
            // 
            // lblLabel17
            // 
            this.lblLabel17.AutoSize = true;
            this.lblLabel17.Location = new System.Drawing.Point(4, 60);
            this.lblLabel17.Name = "lblLabel17";
            this.lblLabel17.Size = new System.Drawing.Size(95, 13);
            this.lblLabel17.TabIndex = 15;
            this.lblLabel17.Text = "Appointment Date:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 22);
            this.label15.TabIndex = 14;
            this.label15.Text = "Selected Appointment Details";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btnAddToWaitingList);
            this.panel3.Controls.Add(this.btnPSGNewAppointment);
            this.panel3.Controls.Add(this.btnFollowUpNewAppointment);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.btnSubmitChangesPatient);
            this.panel3.Location = new System.Drawing.Point(12, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 281);
            this.panel3.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radShowFollowUp);
            this.groupBox1.Controls.Add(this.radShowPSG);
            this.groupBox1.Controls.Add(this.radShowPreviousOnly);
            this.groupBox1.Controls.Add(this.radShowUpcomingOnly);
            this.groupBox1.Controls.Add(this.radShowAll);
            this.groupBox1.Location = new System.Drawing.Point(11, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 96);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointments Table Filters";
            // 
            // radShowFollowUp
            // 
            this.radShowFollowUp.AutoSize = true;
            this.radShowFollowUp.Location = new System.Drawing.Point(207, 65);
            this.radShowFollowUp.Name = "radShowFollowUp";
            this.radShowFollowUp.Size = new System.Drawing.Size(124, 17);
            this.radShowFollowUp.TabIndex = 2;
            this.radShowFollowUp.TabStop = true;
            this.radShowFollowUp.Text = "Show Only Follow-up";
            this.radShowFollowUp.UseVisualStyleBackColor = true;
            this.radShowFollowUp.CheckedChanged += new System.EventHandler(this.radShowFollowUp_CheckedChanged);
            // 
            // radShowPSG
            // 
            this.radShowPSG.AutoSize = true;
            this.radShowPSG.Location = new System.Drawing.Point(206, 42);
            this.radShowPSG.Name = "radShowPSG";
            this.radShowPSG.Size = new System.Drawing.Size(168, 17);
            this.radShowPSG.TabIndex = 2;
            this.radShowPSG.TabStop = true;
            this.radShowPSG.Text = "Show Only PSG Appointments";
            this.radShowPSG.UseVisualStyleBackColor = true;
            this.radShowPSG.CheckedChanged += new System.EventHandler(this.radShowPSG_CheckedChanged);
            // 
            // radShowPreviousOnly
            // 
            this.radShowPreviousOnly.AutoSize = true;
            this.radShowPreviousOnly.Location = new System.Drawing.Point(6, 65);
            this.radShowPreviousOnly.Name = "radShowPreviousOnly";
            this.radShowPreviousOnly.Size = new System.Drawing.Size(187, 17);
            this.radShowPreviousOnly.TabIndex = 1;
            this.radShowPreviousOnly.TabStop = true;
            this.radShowPreviousOnly.Text = "Show Only Previous Appointments";
            this.radShowPreviousOnly.UseVisualStyleBackColor = true;
            this.radShowPreviousOnly.CheckedChanged += new System.EventHandler(this.radShowPreviousOnly_CheckedChanged);
            // 
            // radShowUpcomingOnly
            // 
            this.radShowUpcomingOnly.AutoSize = true;
            this.radShowUpcomingOnly.Location = new System.Drawing.Point(6, 42);
            this.radShowUpcomingOnly.Name = "radShowUpcomingOnly";
            this.radShowUpcomingOnly.Size = new System.Drawing.Size(194, 17);
            this.radShowUpcomingOnly.TabIndex = 0;
            this.radShowUpcomingOnly.TabStop = true;
            this.radShowUpcomingOnly.Text = "Show Only Upcoming Appointments\r\n";
            this.radShowUpcomingOnly.UseVisualStyleBackColor = true;
            this.radShowUpcomingOnly.CheckedChanged += new System.EventHandler(this.radShowUpcomingOnly_CheckedChanged);
            // 
            // radShowAll
            // 
            this.radShowAll.AutoSize = true;
            this.radShowAll.Location = new System.Drawing.Point(6, 19);
            this.radShowAll.Name = "radShowAll";
            this.radShowAll.Size = new System.Drawing.Size(133, 17);
            this.radShowAll.TabIndex = 0;
            this.radShowAll.TabStop = true;
            this.radShowAll.Text = "Show All Appointments";
            this.radShowAll.UseVisualStyleBackColor = true;
            this.radShowAll.CheckedChanged += new System.EventHandler(this.radShowAll_CheckedChanged);
            // 
            // btnAddToWaitingList
            // 
            this.btnAddToWaitingList.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToWaitingList.Image")));
            this.btnAddToWaitingList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddToWaitingList.Location = new System.Drawing.Point(146, 40);
            this.btnAddToWaitingList.Name = "btnAddToWaitingList";
            this.btnAddToWaitingList.Size = new System.Drawing.Size(132, 61);
            this.btnAddToWaitingList.TabIndex = 17;
            this.btnAddToWaitingList.Text = "Add to \r\nWaiting List";
            this.btnAddToWaitingList.UseVisualStyleBackColor = true;
            this.btnAddToWaitingList.Click += new System.EventHandler(this.btnAddToWaitingList_Click);
            // 
            // btnPSGNewAppointment
            // 
            this.btnPSGNewAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnPSGNewAppointment.Image")));
            this.btnPSGNewAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPSGNewAppointment.Location = new System.Drawing.Point(146, 110);
            this.btnPSGNewAppointment.Name = "btnPSGNewAppointment";
            this.btnPSGNewAppointment.Size = new System.Drawing.Size(151, 61);
            this.btnPSGNewAppointment.TabIndex = 16;
            this.btnPSGNewAppointment.Text = "New \r\nPolysomnography\r\nAppointment\r\n";
            this.btnPSGNewAppointment.UseVisualStyleBackColor = true;
            this.btnPSGNewAppointment.Click += new System.EventHandler(this.btnPSGNewAppointment_Click);
            // 
            // btnFollowUpNewAppointment
            // 
            this.btnFollowUpNewAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnFollowUpNewAppointment.Image")));
            this.btnFollowUpNewAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFollowUpNewAppointment.Location = new System.Drawing.Point(6, 110);
            this.btnFollowUpNewAppointment.Name = "btnFollowUpNewAppointment";
            this.btnFollowUpNewAppointment.Size = new System.Drawing.Size(134, 61);
            this.btnFollowUpNewAppointment.TabIndex = 16;
            this.btnFollowUpNewAppointment.Text = "New \r\nFollow-Up \r\nAppointment\r\n";
            this.btnFollowUpNewAppointment.UseVisualStyleBackColor = true;
            this.btnFollowUpNewAppointment.Click += new System.EventHandler(this.btnFollowUpNewAppointment_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 22);
            this.label16.TabIndex = 15;
            this.label16.Text = "Options";
            // 
            // btnSubmitChangesPatient
            // 
            this.btnSubmitChangesPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmitChangesPatient.Image")));
            this.btnSubmitChangesPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmitChangesPatient.Location = new System.Drawing.Point(6, 40);
            this.btnSubmitChangesPatient.Name = "btnSubmitChangesPatient";
            this.btnSubmitChangesPatient.Size = new System.Drawing.Size(134, 61);
            this.btnSubmitChangesPatient.TabIndex = 0;
            this.btnSubmitChangesPatient.Text = "Submit Changes\r\nto Patient \r\nDetails";
            this.btnSubmitChangesPatient.UseVisualStyleBackColor = true;
            this.btnSubmitChangesPatient.Click += new System.EventHandler(this.btnSubmitChangesPatient_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnHelp);
            this.panel4.Controls.Add(this.btnGoBack);
            this.panel4.Location = new System.Drawing.Point(1049, 365);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(131, 281);
            this.panel4.TabIndex = 14;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(3, 135);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(120, 66);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(3, 207);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(120, 66);
            this.btnGoBack.TabIndex = 3;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1108, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1184, 650);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.label1);
            this.Name = "PatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PatientForm_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBriefAssessment;
        private System.Windows.Forms.TextBox txtEpsworthScale;
        private System.Windows.Forms.TextBox txtBMI;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.DateTimePicker dateDateOfBirth;
        private System.Windows.Forms.ComboBox cbxSex;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Button btnBMICalculate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridViewAppointments;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSubmitChangesPatient;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DateTimePicker dateAppointmentDate;
        private System.Windows.Forms.Label lblLabel17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radShowPreviousOnly;
        private System.Windows.Forms.RadioButton radShowUpcomingOnly;
        private System.Windows.Forms.RadioButton radShowAll;
        private System.Windows.Forms.Button btnAddToWaitingList;
        private System.Windows.Forms.Button btnFollowUpNewAppointment;
        private System.Windows.Forms.TextBox txtTreatment;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAHI;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblPSGAppointmentIndicator;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSubmitChangesAppointment;
        private System.Windows.Forms.Button btnPSGDetails;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.RadioButton radShowFollowUp;
        private System.Windows.Forms.RadioButton radShowPSG;
        private System.Windows.Forms.Button btnDeleteSelectedAppointment;
        private System.Windows.Forms.Button btnPSGNewAppointment;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}