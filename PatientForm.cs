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
    public partial class PatientForm : Form
    {
        /// <summary>
        /// This form acts as the one-stop access point for all the information stored in the 
        /// database regarding a single patient record.
        /// That, of course, means that each instance of the PatientForm is unique to the patient
        /// record, thus the parameter integer PatientID is required by the forms constructor
        /// in order for the form to load all the data concerning that single patient record.
        /// The form is divided into 4 sections: Patient Details, Options, Appointments & Selected Appointment
        /// Details. 
        /// The Patient Details section provides functionality identical to that of the "Edit Patient"
        /// form, and any changes are submitted through a button in the "Options" section
        /// The Options section provides functionality to submit any changes made to the Patient details,
        /// and also allows the user to add the patient to the waiting list (with a prompt to determine
        /// whether the patient will receive priority), as well as add new appointments for the patient,
        /// both follow-up and PSG. Finally this section contains filters for the data displayed in the
        /// Appointments section's datagrid.
        /// The Appointments section contains a datagrid that displays all the active (not recycled) appointments 
        /// mapped to this patient. The datagrid is again in disabled editing mode and in "Full row selection" mode.
        /// Once an appointment is selected, this very event of selecting the appointment will cause the 
        /// program to retrieve data regarding that selected appointment according to its AppointmentID and
        /// fill the Selected Appointment Details section, which acts as means to edit (or delete/recycle)
        /// the appointment record details.
        /// Overall this is expected to be one of the application's "busiest" forms, as it is expected to run during
        /// each of a patient's appointment for the doctor to fill data.
        /// </summary>

        // Create Patient object for existing Patient data
        Patient existingPatientData = null;
        // Create Patient object for amended Patient data
        Patient alteredPatientData = null; 
        // Create an Appointment object for existing Appointment data
        Appointment existingAppointmentData = null;
        // Create another Appointment object for altered Appointment data
        Appointment alteredAppointmentData = null;
        // Booleans to indicate if parsing and submitting were successful
        Boolean parseSuccessful = false;
        Boolean submitSuccessful = false;
        // Create a DataMethodsAppointments object to eliminate creating one every time it is required
        DataMethodsAppointments dataAppointments = null;
        // Same as above for the DataMethodsPatients class
        DataMethodsPatients dataPatients = null;
        // Create an integer variable for the patient's ID
        int PatientID;

        public PatientForm(int patientID)
        {
            InitializeComponent();
            dataAppointments = new DataMethodsAppointments(); // Create a new instance of the DataMethods
                                                                // Appointments class
            dataPatients = new DataMethodsPatients(); // Instantiate DataMethodsPatients class
            // Disable Read-Only textboxes
            txtPatientID.Enabled = false;
            //dateAppointmentDate.Enabled = false; // NOTICE - Does it need to be read only?
            // Viewing All Appointments is current selected filter
            radShowAll.Checked = true;
            // Assign the global variable PatientID as the patient's ID
            PatientID = patientID;
            // Fill in Patient details textboxes
            retrievePatientData();
            // Fill datagrid with data regarding patient's appointments
            RefreshPatientAppointments();
            retrieveFirstAppointmentDetails();
        }

        private void retrievePatientData()
        {
            // Retrieve patient data based on PatientID and fill textboxes
            // Retrieve Patient object for Patient in question
            existingPatientData = dataPatients.ReturnSinglePatient(PatientID);
            // Fill textboxes with data from the retrieved object
            txtPatientID.Text = PatientID.ToString(); // It's the same as the object's ID
            txtName.Text = existingPatientData.Name;
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

        public void RefreshPatientAppointments()
        {
            // Retrieve patient appointments according to patient's ID and selected filters
            // Declare variable to take appointment data as enumerable AppointmentReturn object
            IEnumerable<AppointmentReturn> selectedPatientAppointments = null;
            // Use the Return Appoinntments for a signle patient method
            // Nested if statement checks form's filters to return relevant data to datagrid
            if (radShowAll.Checked == true)
            {
                selectedPatientAppointments = dataAppointments.ReturnAppointments(PatientID);
            }
            else if (radShowFollowUp.Checked == true)
            {
                selectedPatientAppointments = dataAppointments.ReturnFollowUpAppointments(PatientID);
            }
            else if (radShowPSG.Checked == true)
            {
                selectedPatientAppointments = dataAppointments.ReturnPSGAppointments(PatientID);
            }
            else if (radShowUpcomingOnly.Checked == true)
            {
                selectedPatientAppointments = dataAppointments.ReturnUpcomingAppointments(PatientID);
            }
            else if (radShowPreviousOnly.Checked == true)
            {
                selectedPatientAppointments = dataAppointments.ReturnPreviousAppointments(PatientID);
            }
            else
            {
                selectedPatientAppointments = dataAppointments.ReturnAppointments(PatientID);
            }
            // Drop them all in the datagrid
            // Instantiate a Binding Source as a frontend for interacting with DataGrid
            BindingSource dataBind = new BindingSource();
            // Assign as DataSource of binding source
            dataBind.DataSource = selectedPatientAppointments;
            // Finally, throw data into the datagrid
            dataGridViewAppointments.DataSource = dataBind;
        }

        private void retrieveSelectedAppointmentDetails()
        {
            // Retrieves data relating to appointment selected in the datagrid and fills relevant
            // textboxes under the "Selected Appointment Details" secton of the form
            // First grab the ID of the selected Appointment
            int selectedAppointmentID = grabSelectedAppointmentID();
            // Retrieve appointment record mapped to the selected ID
            // First check if returned row is 0 before carrying out such task
            if (selectedAppointmentID != 0)
            {
                // Use DataMethodsAppointments class for such operation
                // Assign returned object to the existingAppointmentData object
                existingAppointmentData = dataAppointments.ReturnSingleAppointment(selectedAppointmentID);
                // Now fill textboxes with grabbed data
                dateAppointmentDate.Text = existingAppointmentData.AppointmentDate.ToString();
                txtDiagnosis.Text = existingAppointmentData.Diagnosis;
                txtAHI.Text = existingAppointmentData.AHI.ToString();
                txtTreatment.Text = existingAppointmentData.Treatment;
                txtNotes.Text = existingAppointmentData.Notes;
                // If the appointment is a polysomnography appointment, relevant label displays that info
                if (existingAppointmentData.TestSlotID != null)
                {
                    lblPSGAppointmentIndicator.Text = "Polysomnography Test Appointment";
                    // Enable View Polysomnography Details button
                    btnPSGDetails.Enabled = true;
                }
                else
                {
                    // If appointment is not PSG, relevant label is updated
                    lblPSGAppointmentIndicator.Text = "Follow-up Appointment / Non-PSG";
                    btnPSGDetails.Enabled = false;
                }
            }
        }

        private void retrieveFirstAppointmentDetails()
        {
            // Retrieves data regarding the patient's first appointment/visit
            // Confirms that there are rows in the table before attempting to retrieve data,
            // in order to avoid exceptions
            if (dataGridViewAppointments.RowCount != 0)
            {
                // Retrieve first appointment data 
                existingAppointmentData = dataAppointments.ReturnFirstAppointment(PatientID);
                // Fill textboxes in Selected Appointment Data section
                dateAppointmentDate.Text = existingAppointmentData.AppointmentDate.ToString();
                txtDiagnosis.Text = existingAppointmentData.Diagnosis;
                txtAHI.Text = existingAppointmentData.AHI.ToString();
                txtTreatment.Text = existingAppointmentData.Treatment;
                txtNotes.Text = existingAppointmentData.Notes;
                // If the appointment is a polysomnography appointment, relevant label displays that info
                if (existingAppointmentData.TestSlotID != null)
                {
                    lblPSGAppointmentIndicator.Text = "Polysomnography Test WAS conducted!";
                    // Enable View Polysomnography Details button
                    btnPSGDetails.Enabled = true;
                }
                else
                {
                    // If appointment is not PSG, relevant label is updated
                    lblPSGAppointmentIndicator.Text = "Follow-up Appointment / Non-PSG";
                    btnPSGDetails.Enabled = false;
                }
            }
        }

        private int grabSelectedAppointmentID()
        {
            // Grabs the ID of the appointment selected in the datagrid
            if (dataGridViewAppointments.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the appointment's ID
                int selectedRowIndex = dataGridViewAppointments.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridViewAppointments.Rows[selectedRowIndex];
                // Grab selected Appointment ID as a string
                string selectedAppointmentID = Convert.ToString(selectedRow.Cells["AppointmentID"].Value);
                // Return the Appointment ID parsed as an integer
                return int.Parse(selectedAppointmentID);
            }
            // If nothing is selected, return 0 to be filtered out in a later method
            return 0;
        }

        private int grabSelectedAppointmentTestSlotID()
        {
            // Grabs the ID of the test slot for the appointment selected in the datagrid
            if (dataGridViewAppointments.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, continue
                int selectedRowIndex = dataGridViewAppointments.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridViewAppointments.Rows[selectedRowIndex];
                // Grab selected Test Slot ID as a string
                string selectedTestSlotID = Convert.ToString(selectedRow.Cells["TestSlotID"].Value);
                // Return the Appointment ID parsed as an integer
                return int.Parse(selectedTestSlotID);
            }
            // If nothing is selected, return 0 to be filtered out in a later method
            return 0;
        }

        private void parsePatientDetails()
        {
            // Parse textbox items to suitable Patient object properties
            // Also assign them to the suitable Patient object, which is alteredPatientData
            try
            {
                // Create a new instance for the alteredPatientData of the Patient object
                alteredPatientData = new Patient();
                // Parsing and assigning to object
                alteredPatientData.PatientID = PatientID;
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
                // Set Success boolean to true
                parseSuccessful = true;
            }
            catch (Exception)
            {
                // If error has occured during parsing of data, probably due to inconsistent format, 
                // show error message
                MessageBox.Show("Error! \n One or more fields seem to contain "
                    + "data that is of the wrong format \n Please review entered data and try again",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitPatientChanges()
        {
            // Submits changes made to the patient record
            try
            {
                // Uses DataMethodsPatients class
                dataPatients.EditPatient(alteredPatientData);
                // If successful set Success Boolean to true
                submitSuccessful = true;
            }
            catch (Exception)
            {
                // Show error message indicating that exception occured when editing data
                MessageBox.Show("An error has occured when editing the patient record \nPlease try again"
                    + "\nIf problem persists, contact administrator!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void parseAppointmentDetails()
        {
            // Parse appointment details to suitable Appointment object format
            // Assign parsed values as alteredAppointmentData object properties
            try
            {
                // Create a new instance of the alteredAppointmentData object
                alteredAppointmentData = new Appointment();
                // Parse and assign to object
                alteredAppointmentData.AppointmentID = existingAppointmentData.AppointmentID;
                alteredAppointmentData.AppointmentDate = DateTime.Parse(dateAppointmentDate.Text.ToString());
                alteredAppointmentData.Diagnosis = txtDiagnosis.Text;
                alteredAppointmentData.Treatment = txtTreatment.Text;
                alteredAppointmentData.Notes = txtNotes.Text;
                alteredAppointmentData.AHI = int.Parse(txtAHI.Text);
                // Use parseSuccessful boolean value to mark successful parsing
                parseSuccessful = true;
            }
            catch (Exception)
            {
                // If error has occured during parsing of data, probably due to inconsistent format, 
                // show error message
                MessageBox.Show("Error! \n One or more fields seem to contain "
                    + "data that is of the wrong format \n Please review entered data and try again",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitAppointmentChanges()
        {
            // Submit changes made to appointment details
            try
            {
                // Use DataMethodsAppointments class
                dataAppointments.EditAppointment(alteredAppointmentData);
                // If successful set boolean to true
                submitSuccessful = true;
            }
            catch (Exception)
            {
                // Show error message indicating that exception occured when editing data
                MessageBox.Show("An error has occured when editing the patient record \nPlease try again"
                    + "\nIf problem persists, contact administrator!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSubmitChangesPatient_Click(object sender, EventArgs e)
        {
            // Event to submit changes made to patient details
            // First, parse all textbox items to suitable Patient object properties
            parsePatientDetails();
            // If parsing was successful, proceed with submitting
            if (parseSuccessful == true)
            {
                submitPatientChanges();
                // If successful, show success message
                if (submitSuccessful == true)
                {
                    MessageBox.Show("Successfully updated patient data!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                    // Assign boolean values as false for reusing 
                    parseSuccessful = false;
                    submitSuccessful = false;
                }
            }
        }

        private void btnSubmitChangesAppointment_Click(object sender, EventArgs e)
        {
            // Event to submit changes made to appointment
            // Parse textbox data and assign them to alteredAppointmentDetails object
            parseAppointmentDetails();
            if (parseSuccessful == true)
            {
                submitAppointmentChanges();
                // If successful, show success message
                if (submitSuccessful == true)
                {
                    MessageBox.Show("Successfully updated appointment data!", "Success", MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk);
                    // Assign boolean values as false for reusing 
                    parseSuccessful = false;
                    submitSuccessful = false;
                    // Refresh the Appointments DataGrid
                    RefreshPatientAppointments();
                }
            }
        }

        private void dataGridViewAppointments_SelectionChanged(object sender, EventArgs e)
        {
            // Update appointment delails section when selecting a new row in the datagrid
            retrieveSelectedAppointmentDetails();
        }

        private void btnAddToWaitingList_Click(object sender, EventArgs e)
        {
            // Adds patient to Waiting List
            // Dialog popup picks up whether the patient's entry will receive priority or not
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
                // Instantiate DataMethodsWaitingList
                DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
                //Assign date registered as today
                newWaitingListEntry.DateRegistered = DateTime.Today;
                // Assign PatientID to the altered patient's ID
                newWaitingListEntry.PatientID = PatientID;
                // Assign result of dialog to priority boolean
                newWaitingListEntry.Priority = patientHasPriority;
                // Add the new waiting list entry to the table, using the newWaitingListEntry object created
                dataWaitingList.NewEntry(newWaitingListEntry);
                // Show success message to confirm entry was successful
                MessageBox.Show("Successfully added patient to Waiting List!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                // If exception occurs, return error message to user
                MessageBox.Show("Error creating new waiting list entry. Please try again or \ncontact "
                    + "administrator if system persists", "Error Creating a new Waiting List Entry!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // By the way, if patient has no appointments this exception will occur if the button is clicked
            }
        }

        private void btnBMICalculate_Click(object sender, EventArgs e)
        {
            // Button to calculate patient's Body Mass Index
            // Checks to make sure the textboxes are not 0
            if ((txtHeight.Text == "0") || (txtWeight.Text == "0"))
            {
                MessageBox.Show("Please enter Height and Weight values before calculating BMI");
            }
            else
            {
                // Parse Height and Weight inputs as doubles. Try...catch to catch exceptions/errors
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

        private void btnGoBack_Click(object sender, EventArgs e)
        { 
            // Call the form's Close event, which should open the PatientArchive form 
            this.Close();
        }

        private void PatientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When form is closed, navigate to the previous form, which is PatientArchive
            // Since it was closed, it must be instantiated again
            PatientArchive formPatientArchive = new PatientArchive();
            formPatientArchive.Show();
        }

        private void btnFollowUpNewAppointment_Click(object sender, EventArgs e)
        {
            // Opens form to create a new follow-up appointment for the patient
            NewAppointment newAppointmentForm = new NewAppointment(PatientID, "PatientForm");
            newAppointmentForm.Show();
        }

        private void btnPSGNewAppointment_Click(object sender, EventArgs e)
        {
            // Opens form to create a new PSG appointment for the patient
            // User must first select an available test slot
            TestSlotSelector formTestSlotSelector = new TestSlotSelector(PatientID, "PatientForm");
            formTestSlotSelector.Show();
        }

        private void btnPSGDetails_Click(object sender, EventArgs e)
        {
            // Opens form with polysomnography details
            int selectedTestSlotID = grabSelectedAppointmentTestSlotID();
            // Make sure it's not 0 before proceeding
            if (selectedTestSlotID != 0)
            {
                PSGDetails formPSGDetails = new PSGDetails(selectedTestSlotID);
                formPSGDetails.Show();
            }
            // Else show error message
            else
                MessageBox.Show("This is not a polysomnography appointment!", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void btnDeleteSelectedAppointment_Click(object sender, EventArgs e)
        {
            // Send the selected appointment to the recycle bin
            try
            {
                dataAppointments.DeleteAppointmentMark(grabSelectedAppointmentID());
                RefreshPatientAppointments();
            }
            catch (Exception)
            {
                // If exception occurs, show error message
                MessageBox.Show("Could not delete appointment! Are you sure an appointment is selected?", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Region groups all the datagrid filter implementations
        #region DataGrid Filters 
        private void radShowAll_CheckedChanged(object sender, EventArgs e)
        {
            // Show all appointments
            // Call method that contains nested if statements for filtering
            RefreshPatientAppointments();
        }

        private void radShowUpcomingOnly_CheckedChanged(object sender, EventArgs e)
        {
            // Show only upcoming appointments
            // Call method that contains nested if statements for filtering
            RefreshPatientAppointments();
        }

        private void radShowPreviousOnly_CheckedChanged(object sender, EventArgs e)
        {
            // Show only Previous appointments
            // Call method that contains nested if statements for filtering
            RefreshPatientAppointments();
        }

        private void radShowPSG_CheckedChanged(object sender, EventArgs e)
        {
            // Show only PSG appointments
            // Call method that contains nested if statements for filtering
            RefreshPatientAppointments();
        }

        private void radShowFollowUp_CheckedChanged(object sender, EventArgs e)
        {
            // Show only follow-up appointments
            // Call method that contains nested if statements for filtering
            RefreshPatientAppointments();
        }
        #endregion

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
