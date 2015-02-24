using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sleep_Laboratory_DataBase
{
    public partial class adminSettings : Form
    {
        public adminSettings()
        {
            InitializeComponent();
        }

        private void btnOpenConnectionString_Click(object sender, EventArgs e)
        {
            // Open the dbConnectionString text file to manipulate the database connection string
            try
            {
                System.Diagnostics.Process.Start("dbConnectionString.txt"); 
            }
            catch (Exception)
            {
                // If exception occurs show error message
                MessageBox.Show("Could not open dbConnectionString.txt \nAre you sure it exists? \nConsider creating "
                    + "a new dbConnectionString.txt file in the application folder \nif the problem insists", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCurrentConnection_Click(object sender, EventArgs e)
        {
            // Show the connection string in use by the system in a popup dialog
            DataMethodsPatients dataConnection = new DataMethodsPatients(); // Use a random DataMethods class to 
            // determine its connection
            MessageBox.Show(dataConnection.connString.ToString(), "Current connection string");
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Show the AboutBox
            AboutBox aboutInfo = new AboutBox();
            aboutInfo.Show();
        }
    }
}
