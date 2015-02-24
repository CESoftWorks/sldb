namespace Sleep_Laboratory_DataBase
{
    partial class WaitingListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingListView));
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewWaitingList = new System.Windows.Forms.DataGridView();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNewEntry = new System.Windows.Forms.Button();
            this.btnMarkOrUnmarkEmergency = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAssignAppointment = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radEmergencies = new System.Windows.Forms.RadioButton();
            this.radShowAssigned = new System.Windows.Forms.RadioButton();
            this.radShowUnassigned = new System.Windows.Forms.RadioButton();
            this.radShowAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaitingList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(12, 38);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(99, 23);
            this.lblTitleLabel.TabIndex = 12;
            this.lblTitleLabel.Text = "Waiting List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sleep Laboratory DataBase";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewWaitingList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnGoBack);
            this.splitContainer1.Panel2.Controls.Add(this.btnHelp);
            this.splitContainer1.Panel2.Controls.Add(this.btnNewEntry);
            this.splitContainer1.Panel2.Controls.Add(this.btnMarkOrUnmarkEmergency);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnAssignAppointment);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(947, 475);
            this.splitContainer1.SplitterDistance = 739;
            this.splitContainer1.TabIndex = 13;
            // 
            // dataGridViewWaitingList
            // 
            this.dataGridViewWaitingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWaitingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWaitingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWaitingList.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWaitingList.Name = "dataGridViewWaitingList";
            this.dataGridViewWaitingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWaitingList.Size = new System.Drawing.Size(733, 469);
            this.dataGridViewWaitingList.TabIndex = 0;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(96, 398);
            this.btnGoBack.MaximumSize = new System.Drawing.Size(100, 58);
            this.btnGoBack.MinimumSize = new System.Drawing.Size(70, 58);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(100, 58);
            this.btnGoBack.TabIndex = 2;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(4, 398);
            this.btnHelp.MaximumSize = new System.Drawing.Size(100, 58);
            this.btnHelp.MinimumSize = new System.Drawing.Size(81, 58);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(86, 58);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnNewEntry.Image")));
            this.btnNewEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewEntry.Location = new System.Drawing.Point(4, 141);
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.Size = new System.Drawing.Size(197, 52);
            this.btnNewEntry.TabIndex = 1;
            this.btnNewEntry.Text = "Add a New Waiting List Entry";
            this.btnNewEntry.UseVisualStyleBackColor = true;
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // btnMarkOrUnmarkEmergency
            // 
            this.btnMarkOrUnmarkEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarkOrUnmarkEmergency.Image = ((System.Drawing.Image)(resources.GetObject("btnMarkOrUnmarkEmergency.Image")));
            this.btnMarkOrUnmarkEmergency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarkOrUnmarkEmergency.Location = new System.Drawing.Point(4, 199);
            this.btnMarkOrUnmarkEmergency.Name = "btnMarkOrUnmarkEmergency";
            this.btnMarkOrUnmarkEmergency.Size = new System.Drawing.Size(197, 52);
            this.btnMarkOrUnmarkEmergency.TabIndex = 1;
            this.btnMarkOrUnmarkEmergency.Text = "Mark/Unmark Entry as \r\nEmergency (Priority)";
            this.btnMarkOrUnmarkEmergency.UseVisualStyleBackColor = true;
            this.btnMarkOrUnmarkEmergency.Click += new System.EventHandler(this.btnMarkOrUnmarkEmergency_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(3, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(197, 52);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Send Entry to Recycle Bin";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAssignAppointment
            // 
            this.btnAssignAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignAppointment.Image")));
            this.btnAssignAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignAppointment.Location = new System.Drawing.Point(4, 257);
            this.btnAssignAppointment.Name = "btnAssignAppointment";
            this.btnAssignAppointment.Size = new System.Drawing.Size(197, 52);
            this.btnAssignAppointment.TabIndex = 1;
            this.btnAssignAppointment.Text = "Assign Appointment to \r\nEntry";
            this.btnAssignAppointment.UseVisualStyleBackColor = true;
            this.btnAssignAppointment.Click += new System.EventHandler(this.btnAssignAppointment_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radEmergencies);
            this.groupBox1.Controls.Add(this.radShowAssigned);
            this.groupBox1.Controls.Add(this.radShowUnassigned);
            this.groupBox1.Controls.Add(this.radShowAll);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table Filters";
            // 
            // radEmergencies
            // 
            this.radEmergencies.AutoSize = true;
            this.radEmergencies.ForeColor = System.Drawing.Color.DarkRed;
            this.radEmergencies.Location = new System.Drawing.Point(7, 92);
            this.radEmergencies.Name = "radEmergencies";
            this.radEmergencies.Size = new System.Drawing.Size(140, 17);
            this.radEmergencies.TabIndex = 3;
            this.radEmergencies.TabStop = true;
            this.radEmergencies.Text = "Show Only Emergencies";
            this.radEmergencies.UseVisualStyleBackColor = true;
            this.radEmergencies.CheckedChanged += new System.EventHandler(this.radEmergencies_CheckedChanged);
            // 
            // radShowAssigned
            // 
            this.radShowAssigned.AutoSize = true;
            this.radShowAssigned.Location = new System.Drawing.Point(7, 68);
            this.radShowAssigned.Name = "radShowAssigned";
            this.radShowAssigned.Size = new System.Drawing.Size(122, 17);
            this.radShowAssigned.TabIndex = 2;
            this.radShowAssigned.TabStop = true;
            this.radShowAssigned.Text = "Show Only Assigned";
            this.radShowAssigned.UseVisualStyleBackColor = true;
            this.radShowAssigned.CheckedChanged += new System.EventHandler(this.radShowAssigned_CheckedChanged);
            // 
            // radShowUnassigned
            // 
            this.radShowUnassigned.AutoSize = true;
            this.radShowUnassigned.Location = new System.Drawing.Point(7, 44);
            this.radShowUnassigned.Name = "radShowUnassigned";
            this.radShowUnassigned.Size = new System.Drawing.Size(135, 17);
            this.radShowUnassigned.TabIndex = 1;
            this.radShowUnassigned.TabStop = true;
            this.radShowUnassigned.Text = "Show Only Unassigned";
            this.radShowUnassigned.UseVisualStyleBackColor = true;
            this.radShowUnassigned.CheckedChanged += new System.EventHandler(this.radShowUnassigned_CheckedChanged);
            // 
            // radShowAll
            // 
            this.radShowAll.AutoSize = true;
            this.radShowAll.Location = new System.Drawing.Point(7, 20);
            this.radShowAll.Name = "radShowAll";
            this.radShowAll.Size = new System.Drawing.Size(101, 17);
            this.radShowAll.TabIndex = 0;
            this.radShowAll.TabStop = true;
            this.radShowAll.Text = "Show All Entries";
            this.radShowAll.UseVisualStyleBackColor = true;
            this.radShowAll.CheckedChanged += new System.EventHandler(this.radShowAll_CheckedChanged);
            // 
            // WaitingListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 551);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "WaitingListView";
            this.Text = "WaitingListView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaitingList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewWaitingList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radEmergencies;
        private System.Windows.Forms.RadioButton radShowAssigned;
        private System.Windows.Forms.RadioButton radShowUnassigned;
        private System.Windows.Forms.RadioButton radShowAll;
        private System.Windows.Forms.Button btnAssignAppointment;
        private System.Windows.Forms.Button btnNewEntry;
        private System.Windows.Forms.Button btnMarkOrUnmarkEmergency;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnHelp;
    }
}