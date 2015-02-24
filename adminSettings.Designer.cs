namespace Sleep_Laboratory_DataBase
{
    partial class adminSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenConnectionString = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnCurrentConnection = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Application Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database Connection String:";
            // 
            // btnOpenConnectionString
            // 
            this.btnOpenConnectionString.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenConnectionString.Image")));
            this.btnOpenConnectionString.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenConnectionString.Location = new System.Drawing.Point(164, 49);
            this.btnOpenConnectionString.Name = "btnOpenConnectionString";
            this.btnOpenConnectionString.Size = new System.Drawing.Size(163, 33);
            this.btnOpenConnectionString.TabIndex = 4;
            this.btnOpenConnectionString.Text = "Open Connection File";
            this.btnOpenConnectionString.UseVisualStyleBackColor = true;
            this.btnOpenConnectionString.Click += new System.EventHandler(this.btnOpenConnectionString_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(378, 288);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(105, 31);
            this.btnGoBack.TabIndex = 5;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(267, 288);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(105, 31);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnCurrentConnection
            // 
            this.btnCurrentConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnCurrentConnection.Image")));
            this.btnCurrentConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentConnection.Location = new System.Drawing.Point(164, 88);
            this.btnCurrentConnection.Name = "btnCurrentConnection";
            this.btnCurrentConnection.Size = new System.Drawing.Size(163, 50);
            this.btnCurrentConnection.TabIndex = 4;
            this.btnCurrentConnection.Text = "Show the current \r\nconnection string";
            this.btnCurrentConnection.UseVisualStyleBackColor = true;
            this.btnCurrentConnection.Click += new System.EventHandler(this.btnCurrentConnection_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(389, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // adminSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 331);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnCurrentConnection);
            this.Controls.Add(this.btnOpenConnectionString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "adminSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenConnectionString;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnCurrentConnection;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}