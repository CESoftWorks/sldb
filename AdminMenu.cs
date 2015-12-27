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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void AdminMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Go back to the beginning of the application
            Startup initialForm = new Startup();
            initialForm.Show();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e) // This is the "Go Back" button
            //Rushed into writing code before actually naming it
        {
            // Close this form, go back to Startup form
            this.Close(); // Call FormClosed event
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Show About dialog
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void btnChangeAdminPass_Click(object sender, EventArgs e)
        {
            // Show form to change the administrator password
            admChangeAdminPassword changePassword = new admChangeAdminPassword();
            changePassword.Show();
        }

        private void btnCalendarSettings_Click(object sender, EventArgs e)
        {
            // Opens the Settings form
            adminSettings formSettings = new adminSettings();
            formSettings.Show();
        }

        private void btnViewDatabase_Click(object sender, EventArgs e)
        {
            // Opens form to view all data from database
            adminViewAllData formViewAllData = new adminViewAllData();
            formViewAllData.Show();
        }

        private void btnTechnicalDoc_Click(object sender, EventArgs e)
        {
            //TODO - Attach technical documentation here
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // WARNING - THIS WILL WIPE ALL DATABASE DATA
            // Method to erase all data from all the tables in the database, thus "resetting" the database
            // Once this is clicked, first show a dialog box to confirm such action
            DialogResult confirmResult = MessageBox.Show("THIS ACTION WILL ERASE ALL DATA! \nTHIS IS AN IRREVERSIBLE ACTION"
                + "\n Are you sure you wish to proceed?", "Warning - Permanent loss of data!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                // If confirmed, erase all database data
                // Erase data one table at a time
                try
                {
                    // Instantiate all data manipulation classes
                    DataMethodsAppointments dataAppointments = new DataMethodsAppointments();
                    DataMethodsPatients dataPatients = new DataMethodsPatients();
                    DataMethodsTestSlots dataTestSlots = new DataMethodsTestSlots();
                    DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
                    // Wipe data one table at a time
                    dataAppointments.ResetAppointmentsTable();
                    dataPatients.ResetPatientsTable();
                    dataTestSlots.ResetTestSlotsTable();
                    dataWaitingList.ResetWaitingListTable();
                    // Display a success message
                    MessageBox.Show("Successfully reset database!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    // If an exception occurs show an error message
                    MessageBox.Show("Database reset was unsuccessful! \nThis may be due to a database connection error"
                        + "\nCheck database connection and try again", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Open the Help file / User manual
            try
            {
                System.Diagnostics.Process.Start("HELP.pdf");
            }
            catch (Exception)
            {
                // If exception occurs show error message
                MessageBox.Show("Could not open help file \nContact Administrator", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
