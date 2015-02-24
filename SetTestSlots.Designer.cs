namespace Sleep_Laboratory_DataBase
{
    partial class SetTestSlots
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetTestSlots));
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridTestSlots = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radAssigned = new System.Windows.Forms.RadioButton();
            this.radAvailable = new System.Windows.Forms.RadioButton();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.dateSelectedTestDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddTestSlot = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTestSlots)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLabel.Location = new System.Drawing.Point(12, 38);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(260, 23);
            this.lblTitleLabel.TabIndex = 14;
            this.lblTitleLabel.Text = "Set Polysomnography Test Dates\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sleep Laboratory DataBase";
            // 
            // dataGridTestSlots
            // 
            this.dataGridTestSlots.AllowUserToAddRows = false;
            this.dataGridTestSlots.AllowUserToDeleteRows = false;
            this.dataGridTestSlots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTestSlots.Location = new System.Drawing.Point(12, 167);
            this.dataGridTestSlots.Name = "dataGridTestSlots";
            this.dataGridTestSlots.ReadOnly = true;
            this.dataGridTestSlots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTestSlots.Size = new System.Drawing.Size(310, 150);
            this.dataGridTestSlots.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Controls.Add(this.radAssigned);
            this.groupBox1.Controls.Add(this.radAvailable);
            this.groupBox1.Location = new System.Drawing.Point(335, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 88);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table Filters";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(7, 66);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(36, 17);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // radAssigned
            // 
            this.radAssigned.AutoSize = true;
            this.radAssigned.Location = new System.Drawing.Point(7, 43);
            this.radAssigned.Name = "radAssigned";
            this.radAssigned.Size = new System.Drawing.Size(92, 17);
            this.radAssigned.TabIndex = 0;
            this.radAssigned.TabStop = true;
            this.radAssigned.Text = "Assigned Only";
            this.radAssigned.UseVisualStyleBackColor = true;
            this.radAssigned.CheckedChanged += new System.EventHandler(this.radAssigned_CheckedChanged);
            // 
            // radAvailable
            // 
            this.radAvailable.AutoSize = true;
            this.radAvailable.Location = new System.Drawing.Point(7, 20);
            this.radAvailable.Name = "radAvailable";
            this.radAvailable.Size = new System.Drawing.Size(92, 17);
            this.radAvailable.TabIndex = 0;
            this.radAvailable.TabStop = true;
            this.radAvailable.Text = "Available Only";
            this.radAvailable.UseVisualStyleBackColor = true;
            this.radAvailable.CheckedChanged += new System.EventHandler(this.radAvailable_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(335, 288);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(99, 29);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(440, 288);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(107, 29);
            this.btnGoBack.TabIndex = 17;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // dateSelectedTestDate
            // 
            this.dateSelectedTestDate.Location = new System.Drawing.Point(16, 118);
            this.dateSelectedTestDate.Name = "dateSelectedTestDate";
            this.dateSelectedTestDate.Size = new System.Drawing.Size(200, 20);
            this.dateSelectedTestDate.TabIndex = 18;
            // 
            // btnAddTestSlot
            // 
            this.btnAddTestSlot.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTestSlot.Image")));
            this.btnAddTestSlot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTestSlot.Location = new System.Drawing.Point(222, 104);
            this.btnAddTestSlot.Name = "btnAddTestSlot";
            this.btnAddTestSlot.Size = new System.Drawing.Size(100, 52);
            this.btnAddTestSlot.TabIndex = 19;
            this.btnAddTestSlot.Text = "Add \r\nTest Slot";
            this.btnAddTestSlot.UseVisualStyleBackColor = true;
            this.btnAddTestSlot.Click += new System.EventHandler(this.btnAddTestSlot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 26);
            this.label2.TabIndex = 20;
            this.label2.Text = "Please select a new\r\navailable PSG Test Date:";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSelected.Image")));
            this.btnDeleteSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSelected.Location = new System.Drawing.Point(335, 243);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(99, 39);
            this.btnDeleteSelected.TabIndex = 21;
            this.btnDeleteSelected.Text = "Delete \r\nSelection";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(478, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // SetTestSlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 329);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddTestSlot);
            this.Controls.Add(this.dateSelectedTestDate);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridTestSlots);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetTestSlots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetTestSlots";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTestSlots)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridTestSlots;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radAssigned;
        private System.Windows.Forms.RadioButton radAvailable;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.DateTimePicker dateSelectedTestDate;
        private System.Windows.Forms.Button btnAddTestSlot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}