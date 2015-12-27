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
    public partial class MainMenuGeneric : Form
    {

        /// <summary>
        /// Once the application has started and the user has selected the user type, if the user
        /// type selected is that of "Doctor" or "Nurse", this is the form that is launched.
        /// This is a generic form that changes its functionality according to the selected user type,
        /// that being "Doctor" or "Nurse".
        /// As one may observe, that distiction is made in the form's constuctor.
        /// When the form is instantiated, it accepts a parameter of type string called "UserType".
        /// This parameter then undergoes an if statement to determine which functionality is appropriate 
        /// for each user. This is done by hiding certain buttons from the inferior to the application user
        /// "Nurse".
        /// The purpose of this form is straightforward; it is there to provide access to the various 
        /// facilities of the application according to the user that is using it.
        /// </summary>
        /// <param name="UserType"></param>

        public MainMenuGeneric(string UserType)
        {
            InitializeComponent(); // Initialize form components
            if (UserType == "nurse") // Condition if "nurse" is  constructor input
            {
                btnResearch.Hide(); // This button is not restricted in the nurse interface
                btnSetTestSlots.Hide(); // Same here
                lblWelcome.Text = "Welcome, Nurse!"; // Welcome label
            }
            else // The only other possible user for this interface is Doctor
                lblWelcome.Text = "Welcome, Doctor!"; // Welcome label
            
        }

        private void MainMenuGeneric_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Go back to Startup form
            Startup startup = new Startup();
            startup.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Call the FormClosed event to go back to startup form
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show(); // Show About Box
        }

        private void btnPatientArchive_Click(object sender, EventArgs e)
        {
            // Opens the Patient Archive
            PatientArchive patientArchive = new PatientArchive();
            patientArchive.Show();
        }

        private void btnWaitingList_Click(object sender, EventArgs e)
        {
            // Opens WaitingListView form to show waiting list entries
            WaitingListView formWaitingListView = new WaitingListView();
            formWaitingListView.Show();
        }

        private void btnSetTestSlots_Click(object sender, EventArgs e)
        {
            // Open dialog to set PSG test slots/dates
            SetTestSlots formSetTestSlots = new SetTestSlots();
            formSetTestSlots.Show();
        }

        private void btnRecycleBin_Click(object sender, EventArgs e)
        {
            // Launch the Recycle Bin Selector to select which recycle bin to access
            RecycleBinSelector formRecycleBinSelector = new RecycleBinSelector();
            formRecycleBinSelector.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Launch search facility to search for patient records
            Search formSearch = new Search();
            formSearch.Show();
        }

        private void btnUpcoming_Click(object sender, EventArgs e)
        {
            // Opens the UpcomingAppointments form to view the upcoming appointments
            UpcomingAppointments formUpcomingAppointments = new UpcomingAppointments();
            formUpcomingAppointments.Show();
        }

        private void btnResearch_Click(object sender, EventArgs e)
        {
            // Open the report generation facility. The report selector, to select the type of report to be produced,
            // is launched
            ReportSelector formReportSelector = new ReportSelector();
            formReportSelector.Show();
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
