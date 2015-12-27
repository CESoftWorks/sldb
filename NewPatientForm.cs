using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sleep_Laboratory_DataBase
{
    public partial class NewPatientForm : Form
    {
        // Declare a new Patient Field to be used later. No value assigned
        Patient newPatient;
        Boolean submitSuccessful = false; // To be used to verify a successful entry to the table, refer below

        public NewPatientForm()
        {
            InitializeComponent();
            newPatient = new Patient();
        }

        private void btnBMICalculate_Click(object sender, EventArgs e)
        {
            // Button to automatically calculate patient's Body Mass Index from provided
            // weight and height data
            
            // First check if height and weight boxes are filled in
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
                    txtHeight.Text = "0";
                    txtWeight.Text = "0";
                }
            }
        }

        private void parseAllFields()
        {
            // NOTE - When sumbitting, call this method FIRST
            // Method to Parse all fields to the correct format
            // Fields are assigned to a Patient object property
            try
            {
                // Fields parsed to the correct format
                newPatient.PatientID = int.Parse(txtPatientID.Text);
                newPatient.Name = txtName.Text;
                newPatient.Surname = txtSurname.Text;
                newPatient.Sex = char.Parse(cbxSex.Text);
                newPatient.DateOfBirth = DateTime.Parse(dateDateOfBirth.Text);
                newPatient.PhoneNumber = txtPhoneNumber.Text;
                newPatient.Height = double.Parse(txtHeight.Text);
                newPatient.Weight = double.Parse(txtWeight.Text);
                newPatient.BMI = double.Parse(txtBMI.Text);
                newPatient.EpsworthScale = int.Parse(txtEpsworthScale.Text);
                newPatient.BriefAssessment = txtBriefAssessment.Text;
            }
            catch (Exception)
            {
                // If something cannot be parsed, show error message
                MessageBox.Show("Error! \n One or more fields seem to contain "
                    + "data that is of the wrong format \n Please review entered data and try again",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Note that in the form's design, the values for all non-nullable properties (i.e. int & double)
                // have been given a default value of 0 to avoid invoking this error for no reason
            }
            
        }

        private void sumbitNewPatient()
        {
            // NOTE - When sumbitting a new Patient, call this method SECOND
            // When calling this method, newPatient properties should already be parsed!
            // Method to submit patient object to Patients table in the database
           
            // Try..catch statement to catch any exceptions that may occur
            try
            {
                // Instantiate DataMethodsPatients, which contains functionality to add new patient to database
                DataMethodsPatients dataPatients = new DataMethodsPatients(); // dataPatients - database, Patients table
                dataPatients.NewPatient(newPatient); // Sends Patient object for submission to database table
                // Give user some kind of indication that entry was a success
                MessageBox.Show("New Patient entry successful!", "Success!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // Change the boolean value of submitSuccessful as true to carry on with any methods 
                // that are supposed to follow a patient's successful entry to the table
                submitSuccessful = true;
            }
            catch (Exception)
            {
                // If an exception occurs, show error message
                MessageBox.Show("Error \n Could not add new Patient to database!"
                    + " \n Patient record already exists or it was sent to the recycle bin");
            }
        }

        private Boolean checkIfBlank()
        {
            if ((txtName.Text == "") || (txtSurname.Text == "") || (txtPatientID.Text == "")
                || (cbxSex.Text == "") || (dateDateOfBirth.Text == "")
                || (txtPhoneNumber.Text == ""))
            {
                // If any of those fields is empty, CheckIfBlank is true
                // The above properties are defined as the minimum number of information collected about the 
                // patient when first contact is made with the SRL
                // If blank, show error message
                MessageBox.Show("Some of the required fields are blank. Please fill them in to continue"
                        + "\n These include Patient ID, Name, Surname, Sex, Date of Birth and Phone Number",
                        "Please fill in all required fields!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                return true;
            }
            // If not then return false. No need for an "else", since return ends function
            return false;
        }

        private void refreshPatientArchiveFormAndClose()
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
                // Mind you, an exception will likely occur if this form is opened through another form that isn't PatientArchive
            }
        }

        private void addPatientToWaitingList()
        {
            // NOTE - Call this method AFTER submitting the patient to the Patients table to follow the correct
            // logic (patient is first added to patient archive THEN assigned a waiting list entry
            // This method assumes that all input fields have been parsed and values have been assigned
            // to the newPatient object

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
                // Assign PatientID to the new patient's ID
                newWaitingListEntry.PatientID = newPatient.PatientID;
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
            // "Submit New Patient" button event
            // This button is meant to simply add the patient to the Patients table of the database
             // First, make sure those fields ain't gonna be parsed empty! Call ChackIfBlank method
            // The if statement is present here instead of the parseAllFields method to aid with the logic
            // of the overall sequence of events
            if (checkIfBlank() == false) // So if vital properties are not blank, then execure the following
            {
                // Now, first call method to parse field data to the correct format
                parseAllFields();
                // Then, submit parsed properties, which have been assigned to Patient object properties, to database
                sumbitNewPatient();
                // Check if entry was successful before closing the form
                if (submitSuccessful == true)
                    // Then refresh the Patient Archive form if still open, and close this form
                    refreshPatientArchiveFormAndClose();
                // Nice and sleek
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form, navigating to previous window
            this.Close();
        }

        private void btnSubmitAddToWaitingList_Click(object sender, EventArgs e)
        {
            // "Submit new patient and Add to waiting list" button event
            // Well, as the name suggests, this button is meant to add the patient in the patient archive, and 
            // also add a new entry for him in the Waiting List
            // Check for blank fields using if statement
            if (checkIfBlank() == false)
            {
                // Again, first call method to parse field data to the correct format
                parseAllFields();
                // Then, submit parsed properties, which have been assigned to Patient object properties,
                // to the database
                sumbitNewPatient();
                // Check if the entry has been successful
                if (submitSuccessful == true)
                {
                    // Now create a new entry for this patient in the WaitingList table
                    addPatientToWaitingList();
                    // Refresh the Patient Archive form if still open, and close this form
                    refreshPatientArchiveFormAndClose();
                }
            }
        }

        private void btnSubmitAssignPSGTest_Click(object sender, EventArgs e)
        {
            if (checkIfBlank() == false)
            {
                // Show the TestSlotSelector form to select a suitable test slot for the test
                parseAllFields();
                // Then, submit parsed properties, which have been assigned to Patient object properties, to database
                sumbitNewPatient();
                // Check if entry was successful and show selector, then close the form
                if (submitSuccessful == true)
                {
                    TestSlotSelector formTestSlotSelector = new TestSlotSelector(newPatient.PatientID, "NewPatientForm");
                    formTestSlotSelector.Show();
                    refreshPatientArchiveFormAndClose();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // "Clear" button event to clear all data in the textboxes, or rather, restore them to their
            // default values. Pretty straight-forward.
            txtPatientID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            cbxSex.Text = "";
            dateDateOfBirth.ResetText();
            txtPhoneNumber.Text = "";
            txtHeight.Text = "0";
            txtWeight.Text = "0";
            txtBMI.Text = "0";
            txtEpsworthScale.Text = "0";
            txtBriefAssessment.Text = "";
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
