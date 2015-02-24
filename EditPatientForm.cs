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
    public partial class EditPatientForm : Form
    {
        /// <summary>
        /// This form's purpose is to edit a selected patient record. 
        /// The form's constructor takes an integer argument for the Patient's ID,
        /// which is to be determined from the previous form that is calling it.
        /// It then retrieves the data regarding the selected patient and fills the 
        /// relevant textboxes. The user is then expected to make changes. When submitting
        /// the changes, all the data from the textboxes are read and assigned to a Patient object
        /// that is then sent through to overwrite the patient record being editted.
        /// Options also exist to add the patient to the waiting list or create a new follow up appointment.
        /// </summary>


        // Create a new instance of a Patient object, originally assigned as null, to capture altered data
        Patient alteredPatientData = new Patient();
        // Create another Patient object to capture existing data about patient
        Patient existingPatientData = new Patient();
        // Boolean value to indicate successful parsing of data when it is to be submitted
        Boolean parseSuccess = false;
        // Boolean to indicate whether editing data has been accomplished
        Boolean submitSuccess = false;

        public EditPatientForm(int patientID) // Get PatientID to retrieve patient's data
        {
            InitializeComponent();
            // Disable PatientID textbox, as it's not for editing
            txtPatientID.Enabled = false;
            // Retrieve data about the selected record
            retrievePatientData(patientID);
            // Fill textboxes with fetched data
            fillTextBoxes();
        }

        private void retrievePatientData(int patientID)
        {
            // Instantiate class DataMethodsPatients that contains methods to retrieve patient details
            DataMethodsPatients dataPatients = new DataMethodsPatients();
            // Retrieve patient data and capture it using existingPatientData Patient object
            existingPatientData = dataPatients.ReturnSinglePatient(patientID);
        }

        private void fillTextBoxes()
        {
            // Fills all textboxes with data from the existingPatientData Patient object
            txtPatientID.Text = existingPatientData.PatientID.ToString(); // If string is not default type
            txtName.Text = existingPatientData.Name;                        // attach .ToString()
            txtSurname.Text = existingPatientData.Surname;
            cbxSex.Text = existingPatientData.Sex.ToString();
            dateDateOfBirth.Text = existingPatientData.DateOfBirth.ToString();
            txtPhoneNumber.Text = existingPatientData.PhoneNumber;
            txtHeight.Text = existingPatientData.Height.ToString();
            txtWeight.Text = existingPatientData.Weight.ToString();
            txtBMI.Text = existingPatientData.BMI.ToString();
            txtEpsworthScale.Text = existingPatientData.EpsworthScale.ToString();
            txtBriefAssessment.Text = existingPatientData.BriefAssessment;
        }

        private void parseDataFromTextboxes()
        {
            // Assigns data inputted to the textboxes to the alteredPatientData Patient object
            // Try...catch statement catches exceptions if they occur, particularly during parsing of data
            // to the correct type
            try
            {
                // PatientID remains constant, so assign that of the existingPatientData object
                alteredPatientData.PatientID = existingPatientData.PatientID;
                // Now assign textbox values as object properties
                alteredPatientData.Name = txtName.Text;
                alteredPatientData.Surname = txtSurname.Text;
                alteredPatientData.Sex = char.Parse(cbxSex.Text);
                alteredPatientData.DateOfBirth = DateTime.Parse(dateDateOfBirth.Text);
                alteredPatientData.PhoneNumber = txtPhoneNumber.Text;
                alteredPatientData.Height = double.Parse(txtHeight.Text);
                alteredPatientData.Weight = double.Parse(txtWeight.Text);
                alteredPatientData.BMI = double.Parse(txtBMI.Text);
                alteredPatientData.EpsworthScale = int.Parse(txtEpsworthScale.Text);
                alteredPatientData.BriefAssessment = txtBriefAssessment.Text;
                parseSuccess = true; // Indicate that values have been parsed successfully with no 
                                        // exceptions thrown
            }
            catch (Exception)
            {
                 // Show error message prompring correct use of data types
                MessageBox.Show("Error parsing data values! \nPlease ensure that data is in the correct"
                    + " format!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitChanges()
        {
            // Submits changes to database using DataMethodsPatients functionality
            try
            {
                // Instantiate relevant class 
                DataMethodsPatients dataPatients = new DataMethodsPatients();
                // Call the EditPatient method, passig the altered Patient object for submission
                dataPatients.EditPatient(alteredPatientData);
                submitSuccess = true; // Indicate that no errors have occured
            }
            catch (Exception)
            {
                // Show error message indicating that exception occured when editing data
                MessageBox.Show("An error has occured when editing the patient record \nPlease try again"
                    + "\nIf problem persists, contact administrator!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBMICalculate_Click(object sender, EventArgs e)
        {
            // As in New Patient Form, this button calculated the BMI from data about height and weight
            // First checks to make sure the textboxes are not 0
            if ((txtHeight.Text == "0") || (txtWeight.Text == "0"))
            {
                MessageBox.Show("Please enter Height and Weight values before calculating BMI");
            }
            else
            {
                // Parse Height and Weight inputs as doubles. This is the tricky bit
                try
                {
                    // Parse Height and Weight. Try...catch statement should catch any errors that pop up
                    double parsedHeight = double.Parse(txtHeight.Text);
                    double parsedWeight = double.Parse(txtWeight.Text);

                    // Instantiate Calculations class that contains calculation for BMI
                    Calculations calc = new Calculations();
                    double BMI = calc.CalculateBMI(parsedHeight, parsedWeight);
                    // Return value of calculation to the BMI text box
                    txtBMI.Text = BMI.ToString();
                }
                catch (Exception)
                {
                    // If an exception occurs, which should be due to value parsing,
                    // error message pops up
                    MessageBox.Show("Error calculating BMI! \n Please ensure that "
                        + "Weight and Height values are in the correct format!", "Warning!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void refreshActiveFormAndClose()
        {
            // Method to Refresh Patient Archive form if open to update any changes made to the database
            // Try...catch statement, if Patient Archive form is closed just close this form to avoid exceptions
            try
            {
                // Refer to opened form
                PatientArchive formPatientArchive = (PatientArchive)Application.OpenForms["PatientArchive"];
                // Call form's RefreshDataGrid method to refresh data grid
                formPatientArchive.RefreshDataGrid();
                // Close this form, work here is done
                this.Close();
            }
            catch (Exception)
            {
                // If exception occurs, just close the thing, no need for error messages
                this.Close();
            }
        }

        private void addPatientToWaitingList()
        {
            // Adds patient to Waiting list
            // Same as New Patient form's functionality
            // First, a dialog popup picks up whether the patient's entry will receive priority or not
            DialogResult priorityResult = MessageBox.Show("Does the patient receive priority? \nDoes the patient"
                + " require a polysomnography test urgently?", "Priority", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            // Convert dialog answer to boolean (Yes => Priority = true, No => Priority = false)
            Boolean patientHasPriority;
            if (priorityResult == DialogResult.Yes)
                patientHasPriority = true;
            else
                patientHasPriority = false;
            // Try...catch statement surrounds code to catch any exceptions that may occur
            try
            {
                // Create a new instance of a WaitingList entry
                WaitingListEntry newWaitingListEntry = new WaitingListEntry();
                // Instantiate DataMethodsWaitingList, which contains the functionality
                // to interact with the WaitingList table
                DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
                //Assign date registered as today
                newWaitingListEntry.DateRegistered = DateTime.Today;
                // Assign PatientID to the altered patient's ID
                newWaitingListEntry.PatientID = alteredPatientData.PatientID;
                // Assign result of dialog to priority boolean
                newWaitingListEntry.Priority = patientHasPriority;
                // Add the new waiting list entry to the table, using the newWaitingListEntry object created
                dataWaitingList.NewEntry(newWaitingListEntry);
            }
            catch (Exception)
            {
                // If exception occurs, return error message to user
                MessageBox.Show("Error creating new waiting list entry. Please try again or \ncontact "
                    + "administrator if system persists", "Error Creating a new Waiting List Entry!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Submit amended data to database
            // First assign data from textboxes to alteredPatientData object
            parseDataFromTextboxes();
            // If assigning was successful, submit the alteredPatientData object
            if (parseSuccess == true)
                submitChanges();
            // If submission was successful, display success message and exit form after refreshing 
            // PatientArchive's datagrid
            if (submitSuccess == true)
            {
                MessageBox.Show("Successfully updated patient data!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                refreshActiveFormAndClose();
            }
        }

        private void btnSubmitAddToWaitingList_Click(object sender, EventArgs e)
        {
            // Submit amended data to database and add patient to waiting list
            // First assign data from textboxes to alteredPatientData object
            parseDataFromTextboxes();
            // If assigning was successful, submit the alteredPatientData object
            if (parseSuccess == true)
                submitChanges();
            // If submission was successful, display success message, add patient to waiting list
            // and refresh datagrid on PatientArchive form, then exit
            if (submitSuccess == true)
            {
                MessageBox.Show("Successfully updated patient data!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                // Call method to add patient to waiting list
                addPatientToWaitingList();
                refreshActiveFormAndClose();
            }
        }

        private void btnSubmitAssignAppointment_Click(object sender, EventArgs e)
        {
            // Submit changes and assign a new follow-up appointment for the patient 
            NewAppointment formNewAppointment = new NewAppointment(existingPatientData.PatientID, "EditPatientForm");
            formNewAppointment.Show();

        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form, navigating to previous windows
            this.Close();
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
