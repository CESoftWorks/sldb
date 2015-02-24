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
    public partial class NewAppointment : Form
    {
        ///<summary>
        /// The purpose of this form is to create a new appointment for a selected patient.
        /// This form shows an example of constructor overloading. 
        /// Consider the two constuctors for this form (named public NewAppointment({parameters}))
        /// The first constructor accepts two parameters, one integer PatientID and one string CurrentFormName.
        /// If a new instance of this form is created with those parameters, the appointment will clearly be a
        /// follow-up appointment, as no PSG test slot is assigned/mapped to it. The flow of the application will
        /// allow the user to dictate which type of appointment is to be created. If an appointment is created with
        /// a PSG test slot assigned to it, this same form will be instantiated with an extra constuctor parameter
        /// integer TestSlotID (see second constuctor), and thus this will become a form for a new test slot appointment.
        /// In this event the "Add polysomnography test details" button remains enabled, and allows the user to open
        /// a form to edit details for the PSG test slot assigned to this appointment.
        /// As the test slot is actually not assigned to the appointment until this form is "submitted", i.e. 
        /// the AppointmentID is not stored in the test slot table, opening the form to edit the PSG test slot 
        /// details will show no AppointmentID value; however this is not a problem as when this form is eventually
        /// submitted the Appointment-TestSlot relationship between the two records is established. The reason of only
        /// establishing this relationship AFTER the appointment is submitted is so that the test slot remains free in 
        /// case the appointment entry is cancelled.
        /// Finally note that the parameter CurrentFormName is inputted in order to determine whether the originating
        /// form has an updatable datagrid that should be updated to accomodate for the new appointment changes
        /// after they are made.
        /// </summary>

        // Declare an integer variable for patient's ID that is assigned to this new Appointment
        int PatientID;
        // Create an Appointment object for adding the new appointment
        Appointment newAppointment = null;
        // Booleans to indicate if parse and submit were successful
        Boolean parseSuccess;
        Boolean submitSuccess;
        // String value to determine previous form's name, in order to determine whether to call a method to update its datagrid
        string previousFormName;
        // TestSlot object to store selected Test Slot details
        TestSlot SelectedTestSlot = null;
        // For manipulating test slot data
        DataMethodsTestSlots dataTestSlots = null;

        public NewAppointment(int patientID, string currentFormName)
        {
            // ---Follow-up Appointment---
            // Not assigned a TestSlotID value
            InitializeComponent();
            // Change the title label accordingly
            lblTitleLabel.Text = "New Follow-Up Appointment";
            // Assign constructor's argument patientID to this form's PatientID variable
            PatientID = patientID;
            // Disable PatientID field so that it is not changed by accident
            txtPatientID.Enabled = false;
            // Also show the patient's ID on the txtPatientID label
            txtPatientID.Text = patientID.ToString();
            // Set default values of success booleans to false
            parseSuccess = false;
            submitSuccess = false;
            // Grab the calling form's name
            previousFormName = currentFormName;
            // Create a new instance of the newAppointment object for adding a new appointment
            newAppointment = new Appointment();
            // Hide the "Add polysomnography details" button since it is not applicable here
            btnPSGDetails.Hide();
        }

        public NewAppointment(int patientID, string currentFormName, int selectedTestSlotID)
        {
            // Overloaded constructor for adding a new appointment but this time with a TestSlotID value
            // ---PSG Assigned Appointment---
            InitializeComponent();
            // Again, set the proper text for the title label
            lblTitleLabel.Text = "New Polysomnography Appointment";
            // Assign constructor's argument patientID to this form's PatientID variable
            PatientID = patientID;
            // Disable PatientID field so that it is not changed by accident
            txtPatientID.Enabled = false;
            // Also show the patient's ID on the txtPatientID label
            txtPatientID.Text = patientID.ToString();
            // Set default values of success booleans to false
            parseSuccess = false;
            submitSuccess = false;
            // Grab the calling form's name
            previousFormName = currentFormName;
            // Create a new instance of the newAppointment object for adding a new appointment
            newAppointment = new Appointment();
            // Now add the TestSlotID value to this new instance of the newAppointment object
            newAppointment.TestSlotID = selectedTestSlotID;
            // Instantiate class for test slot data manipulation
            dataTestSlots = new DataMethodsTestSlots();
            // Call method to set the Appointment Date to match that of the test slot
            matchTestSlotDate(selectedTestSlotID);
            // Disable the Appointment date selector to avoid accidental mismatch of dates
            dateAppointmentDate.Enabled = false;
        }

        private void matchTestSlotDate(int testSlotID)
        {
            // Method to match the date of the appointment with that of the Test Slot
            // SelectedTestSlot to contain the test slot data
            SelectedTestSlot = dataTestSlots.ReturnSelectedTestSlot(testSlotID);
            // Assign the object's date to the Appointment Date selector
            dateAppointmentDate.Text = SelectedTestSlot.TestDate.ToString();
        }

        private Boolean checkIfBlank()
        {
            // This function checks if required information has not been entered (is blank)
            // If not blank, return false so whatever method is calling this can carry on
            if (dateAppointmentDate.Text != "")
            {
                return false;
            }
            // If blank, show error message and return true
            MessageBox.Show("Please enter an Appointment Date to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }

        private void parseAllFields()
        {
            // Parses all values from the textboxes and assigns them as Appointment object properties
            try
            {
                // New appointment's PatientID is assigned as the assigned PatientID for this form
                newAppointment.PatientID = PatientID;
                // Parse fields to the correct format and assign them as Appointment properties
                newAppointment.AppointmentDate = DateTime.Parse(dateAppointmentDate.Text);
                newAppointment.Diagnosis = txtDiagnosis.Text;
                newAppointment.AHI = int.Parse(txtAHI.Text);
                newAppointment.Treatment = txtTreatment.Text;
                newAppointment.Notes = txtNotes.Text;
                // Set success boolean to true
                parseSuccess = true;
            } 
            catch (Exception)
            {
                // If something cannot be parsed, show error message
                MessageBox.Show("Error! \n One or more fields seem to contain "
                    + "data that is of the wrong format \n Please review entered data and try again",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitNewAppointment()
        {
            // Method to submit new appointment to database
            // This method assumes that newAppointment object has already been parsed and has data
            
            // Try... catch statement to catch exceptions that may occur
            try
            {
                // Use DataMethodsAppointments to add new appointment
                DataMethodsAppointments dataAppointments = new DataMethodsAppointments(); // Instantiate class with relevant functionality
                dataAppointments.NewAppointment(newAppointment); // Use NewAppointment method to add appointment to database
                // At this point, since no exceptions occured, commit the TestSlot if one maps to this 
                // new appointment
                commitTestSlot();
                // Give user some kind of indication that this has been successful i.e. no exceptions occured
                MessageBox.Show("Successfully created new Appointment!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Set success boolean to true
                submitSuccess = true;
            }
            catch
            {
                // If an exception occurs, show error message
                MessageBox.Show("Error! \n Could not create new Appointment! \n If error insists contact administrator", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void commitTestSlot()
        {
            // This method commits the test slot to the new appointment, if a test slot is mapped to this 
            // appointment
            if (SelectedTestSlot != null) // In other words, execute if there is a selected test slot
            {
                SelectedTestSlot.AppointmentID = newAppointment.AppointmentID;
                // Submit the change to the TestSlot table using DataMethodsTestSlots
                DataMethodsTestSlots dataTestSlots = new DataMethodsTestSlots();
                dataTestSlots.EditSlot(SelectedTestSlot);
            }
        }

        private void updatableOpenFormUpdate()
        {
            // This method determines whether the previous form contains an updatable datagrid and updates it accordingly
            if (previousFormName == "PatientForm") // PatientForm has an updatable datagrid
            {
                // Update PatientForm's Datagrid
                try
                {
                    // Refer to opened form
                    PatientForm formPatientForm = (PatientForm)Application.OpenForms["PatientForm"];
                    // Call form's RefreshDataGrid method to refresh data grid
                    formPatientForm.RefreshPatientAppointments();
                }
                catch
                {
                    // If exception occurs, display a warning message or something, this isn't a critical error
                    MessageBox.Show("Could not update datagrid on Patient Form. Perhaps you have closed this window?", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (previousFormName == "WaitingListView") // WaitingListView also has an updatable datagrid
            {
                try
                {
                    // Refer to open form
                    WaitingListView formWaitingListView = (WaitingListView)Application.OpenForms["WaitingListView"];
                    // Call method to refresh its datagrid
                    formWaitingListView.RefreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs again display a warning message, this is not critical
                    MessageBox.Show("Could not update datagrid on Waiting List Form. Perhaps you have closed this window?",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (previousFormName == "UpcomingAppointments")
            {
                try
                {
                    // Refer to open form
                    UpcomingAppointments formUpcomingAppointments = (UpcomingAppointments)Application.OpenForms["UpcomingAppointments"];
                    // Call method to refresh its datagrid
                    formUpcomingAppointments.RefreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs again display a warning message, this is not critical
                    MessageBox.Show("Could not update datagrid on Upcoming Appointments Form. Perhaps you have closed this window?",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Submit new appointment to database
            // Run checkIfBlank and check if required fields are blank
            // If not blank then carry on
            if (checkIfBlank() == false)
            {
                parseAllFields();
                // If parsing was successful, submit appointment
                if (parseSuccess == true)
                {
                    submitNewAppointment();
                    if (submitSuccess == true)
                    {
                        // Refresh datagrid on updatable open form if appicable
                        updatableOpenFormUpdate();
                        this.Close();
                    }
                } 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Button to clear all textboxes
            // Exception to this is PatientID and Date selector for appointment date
            txtAHI.Text = "";
            txtDiagnosis.Text = "";
            txtNotes.Text = "";
            txtTreatment.Text = "";
        }

        private void NewAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If for any reason this form is closed before changes were submitted
            // remove the waiting list and test slot mappings if they exist
            if ((SelectedTestSlot != null) && (submitSuccess == false))
                clearWaitingListMapping(SelectedTestSlot.TestSlotID);
        }

        private void clearWaitingListMapping(int testSlotID)
        {
            try
            {
                // The waiting list record mapping to the test slot selected for this appointment is cleared
                // if the appointment is cancelled so that the waiting list entry shows up unassigned
                TestSlot selectedTestSlot = dataTestSlots.ReturnSlot(testSlotID);
                // First put the waiting list ID in a variable to use a little later
                int mappedWaitingListID = int.Parse(selectedTestSlot.WaitingListID.ToString());
                // Now set it to null
                selectedTestSlot.WaitingListID = null;
                //Submit change
                dataTestSlots.EditSlot(selectedTestSlot);
                // Clear on other side as well
                DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
                WaitingListEntry mappedWaitingListEntry = dataWaitingList.ReturnEntry(mappedWaitingListID);
                mappedWaitingListEntry.TestSlotID = null;
                // Submit change
                dataWaitingList.EditEntry(mappedWaitingListEntry);
            }
            catch
            {
                // At least notify the user that it wasn't cleared
                MessageBox.Show("Warning! \nMarking the waiting list entry as Unassigned was unsuccessful!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPSGDetails_Click(object sender, EventArgs e)
        {
            // Open form to add/attach the polysomnography report files
            PSGDetails formPSGDetails = new PSGDetails(SelectedTestSlot.TestSlotID);
            formPSGDetails.Show();
        }
    }
}
