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
    public partial class PSGDetails : Form
    {
        ///<summary>
        /// The function of this form is to edit (or add) the details of a supplied test slot.
        /// As such, the form's constructor takes a parameter of integer TestSlotID in order
        /// to locate the test slot in question so that its data can be altered.
        /// Functionality of this form includes folder dialogs which the user can use to
        /// specify the path in which the relevant patient files are stored, as well as 
        /// functionality to open that folder and from there navigate to the files in question.
        /// </summary>


        // Create an object for manipulating the test slot. To be instantiated in the constructor
        DataMethodsTestSlots dataTestSlots = null;
        // Create folder dialog objects to navigate to containing folders. Instantiate in constructor.
        FolderBrowserDialog psgPathDialog = null;
        FolderBrowserDialog doctorPathDialog = null;
        // Create variables to contain the folder paths
        string psgReportPath = "";
        string doctorReportPath = "";
        // Variable to contain the test slot ID
        int TestSlotID;
        // Object to contain test slot data
        TestSlot currentTestSlot = null;

        public PSGDetails(int testSlotID)
        {
            InitializeComponent();
            // Instantiate data manipulation object
            dataTestSlots = new DataMethodsTestSlots();
            // Instantiate folder dialog objects
            psgPathDialog = new FolderBrowserDialog();
            doctorPathDialog = new FolderBrowserDialog();
            // Assign the constructor parameter to the wider-scoped variable for the TestSlot ID
            TestSlotID = testSlotID;
            // Retrieve test slot data
            retrieveTestSlotData();
        }

        private void retrieveTestSlotData()
        {
            // Method to retrieve data and store it in the Test Slot object 
            currentTestSlot = dataTestSlots.ReturnSlot(TestSlotID);
            // Also set the values of the textboxes
            txtAppointmentID.Text = currentTestSlot.AppointmentID.ToString();
            txtTestSlotID.Text = currentTestSlot.TestSlotID.ToString();
            txtPSGReportPath.Text = currentTestSlot.PSGReportPath;
            txtDoctorReportPath.Text = currentTestSlot.DoctorReportPath;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Submit changes to database
            // First assign changed values to the object
            currentTestSlot.PSGReportPath = txtPSGReportPath.Text;
            currentTestSlot.DoctorReportPath = txtDoctorReportPath.Text;
            // Now make the changes to the object
            try
            {
                dataTestSlots.EditSlot(currentTestSlot);
                // Show success message
                MessageBox.Show("Submit successful!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Close this form
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error submitting data. \nPlease restart the application or contact administrator", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPSGFindReportFolder_Click(object sender, EventArgs e)
        {
            // Open folder dialog to select the folder that contains the polysomnographer's report
            psgPathDialog.ShowDialog();
            // Assign the polysomnographer's report path to be that of the folder selected by the user
            psgReportPath = psgPathDialog.SelectedPath;
            // Also display it on the textbox
            txtPSGReportPath.Text = psgReportPath;
        }

        private void btnDoctorFindReportFolder_Click(object sender, EventArgs e)
        {
            // Open folder dialog to select the folder that contains the doctor's report
            // Procedure same as that of the polysomnographer's report
            doctorPathDialog.ShowDialog();
            doctorReportPath = doctorPathDialog.SelectedPath;
            txtDoctorReportPath.Text = doctorReportPath;
        }
        private void btnOpenPSGReport_Click(object sender, EventArgs e)
        {
            // Open folder at the assigned path for the polysomnographer's report
            psgReportPath = txtPSGReportPath.Text;
            try
            {
                // Dialog to display the relevant folder 
                OpenFileDialog openPSGReport = new OpenFileDialog();
                // Opens in the defined folder path
                openPSGReport.InitialDirectory = psgReportPath;
                openPSGReport.ShowDialog();
                // Open the file selected
                System.Diagnostics.Process.Start(openPSGReport.FileName); 
            }
            catch (Exception)
            {
                // If an exception occurs show error message
                MessageBox.Show("Could not open selected file! \nAre you sure it exists?", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void btnOpenDoctorReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Same as that of the polysomnographer's report (above)
                OpenFileDialog openDoctorReport = new OpenFileDialog();
                openDoctorReport.InitialDirectory = doctorReportPath;
                openDoctorReport.ShowDialog();
                System.Diagnostics.Process.Start(openDoctorReport.FileName); //Probably not ideal, but does the job ey?
            }
            catch (Exception)
            {
                // If an exception occurs show error message
                MessageBox.Show("Could not open selected file! \nAre you sure it exists?", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
