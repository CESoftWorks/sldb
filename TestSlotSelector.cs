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
    public partial class TestSlotSelector : Form
    {
        ///<summary>
        /// This form prompts the patient to select an available test slot to assign to the new 
        /// polysomnography/PSG appointment that is being created. 
        /// The available/unassigned test slots are displayed on the form's datagrid, which has
        /// editing disabled and is in full row selection mode. The user can select one of the 
        /// test slots (if one exists) and proceed by clicking the "Select Test Slot" button, which
        /// will then call the NewAppointment form with the selected test slot ID passed as one of 
        /// its parameters.
        /// Once submitted, it also maps the selected test slot ID to the selected waiting list 
        /// entry, if this form originates from the WaitingListView form, so that to show that the
        /// waiting list entry has been serviced/assigned and is no longer pending.
        /// </summary>
        
        // Variable to store selected patient's ID
        int PatientID;
        // Also one to store the form this was opened from for refreshing (See NewAppointment definition)
        string PreviousForm;
        // And one for the waiting list ID if one exists
        int WaitingListID = 0;
        // DataMethodsTestSlots class to retrieve table data etc
        DataMethodsTestSlots dataTestSlots = null;

        public TestSlotSelector(int patientID, string callingForm)
        {
            InitializeComponent();
            // Instantiate data methods class
            dataTestSlots = new DataMethodsTestSlots();
            // Call method to fill datagrid with all the available / unassigned test slots
            retrieveAvailableTestSlots();
            // Patient selected from previous form is assigned to the higher-scope variable PatientID
            PatientID = patientID;
            // Same with PreviousForm
            PreviousForm = callingForm;
        }

        public TestSlotSelector(int patientID, string callingForm, int waitingListID)
        {
            // Overloaded contructor to be called from waiting list in order to map the selected test slot to the ID
            InitializeComponent();
            // Instantiate data methods class
            dataTestSlots = new DataMethodsTestSlots();
            // Call method to fill datagrid with all the available / unassigned test slots
            retrieveAvailableTestSlots();
            // Patient selected from previous form is assigned to the higher-scope variable PatientID
            PatientID = patientID;
            // Same with PreviousForm and WaitingListID this time
            PreviousForm = callingForm;
            WaitingListID = waitingListID;
        }

        private void retrieveAvailableTestSlots()
        {
            // Create an IEnumerable<TestSlotReturn> object to hold all retrieved data before throwing on datagrid
            IEnumerable<TestSlotReturn> availableTestSlots = dataTestSlots.ReturnAvailableSlots();
            // Binding source holds datagrid data, which is then thrown onto the datagrid itself
            BindingSource dataBind = new BindingSource();
            dataBind.DataSource = availableTestSlots;
            dataGridView1.DataSource = dataBind;
        }

        private int grabSelectedTestSlotID()
        {
            // Function to return the TestSlotID of the test slot selected on the datagrid
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // If there's only one cell selected grab the test slot ID
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                // Grab selected test slot ID as a string
                string selectedTestSlotID = Convert.ToString(selectedRow.Cells["TestSlotID"].Value);
                // Return the test slot ID parsed as an integer
                return int.Parse(selectedTestSlotID);
            }
            // If nothing is selected, return 0 to be filtered out in a later method
            return 0;
        }

        private void commitWaitingListEntry(int selectedTestSlotID)
        {
            // Commits waiting list entry to this test slot
            if (WaitingListID != 0)
            {
                DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
                WaitingListEntry selectedWaitingListEntry = dataWaitingList.ReturnEntry(WaitingListID);
                selectedWaitingListEntry.TestSlotID = selectedTestSlotID;
                dataWaitingList.EditEntry(selectedWaitingListEntry);
                // Commit the other way as well (on test slot record)
                TestSlot selectedTestSlot = dataTestSlots.ReturnSlot(selectedTestSlotID);
                selectedTestSlot.WaitingListID = WaitingListID;
                dataTestSlots.EditSlot(selectedTestSlot);
            }
        }
        
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // When the "Select Test Slot" button is clicked, grab the selected TestSlotID and open the 
            // overloaded NewAppointment form to create a new PSG test appointment
            // Assign the grabbed TestSlotID  to a variable
            int selectedTestSlotID = grabSelectedTestSlotID();
            // First check if a proper (not 0) TestSlotID is grabbed
            if (selectedTestSlotID != 0)
            {
                // Commit WaitingListEntry to test slot
                commitWaitingListEntry(selectedTestSlotID);
                // Now open the new appointment
                NewAppointment newAppointmentForm = new NewAppointment(PatientID, PreviousForm, selectedTestSlotID);
                newAppointmentForm.Show();
                this.Close();
            }
            // If no proper TestSlotID is grabbed, return error message
            else
            {
                MessageBox.Show("Please select an available Test Slot from the table. \nIf no available test "
                    + "slot exists, you can insert one using the main menu option \"Set PSG Test Dates \"", 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close this windows
            this.Close();
        }
    }
}
