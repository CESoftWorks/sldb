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
    public partial class WaitingListView : Form
    {
        ///<summary>
        /// This form displays the waiting list of the system, presenting the active (not recycled) 
        /// Waiting List records from the WaitingList table to the datagrid, which has editing disabled
        /// and is set to full row selection.
        /// The datagrid includes several filters to display relevant data to the user.
        /// It includes functionality to add a new entry to the WaitingList table, using the WaitingListEntrySelector
        /// form, mark or unmark an entry as emergency, assign an appointment to a selected entry and send
        /// a selected entry to the recycle bin.
        /// </summary>

        // Create a DataMethodsWaitingList object to be instantiated in form's constuctor
        DataMethodsWaitingList dataWaitingList = null;

        public WaitingListView()
        {
            InitializeComponent();
            // Instantiate dataWaitingList
            dataWaitingList = new DataMethodsWaitingList();
            // Set default filter
            radShowUnassigned.Checked = true;
            // Call method to refresh data grid, placing values in it
            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            /// This refreshes the DataGrid contents
            /// Made public so it can be called when form is running in the background, so changes automatically
            /// show up
            // Create an IEnumerable<WaitingListReturn> object for assigning the entries retrieved from the 
            // database to before dropping them onto the datagrid
            IEnumerable<WaitingListReturn> selectedWaitingListEntries = null;
            // Nested if statement decides which query is suitable for filling object with data
            if (radShowAll.Checked == true)
            {
                selectedWaitingListEntries = dataWaitingList.ReturnEntries();
            }
            else if (radShowAssigned.Checked == true)
            {
                selectedWaitingListEntries = dataWaitingList.ReturnAssignedEntries(); 
            }
            else if (radShowUnassigned.Checked == true)
            {
                selectedWaitingListEntries = dataWaitingList.ReturnUnAssignedEntries();
            }
            else if (radEmergencies.Checked == true)
            {
                selectedWaitingListEntries = dataWaitingList.ReturnEmergencyEntries();
            }
            else
            {
                selectedWaitingListEntries = dataWaitingList.ReturnEntries();
            }
            // Drop results onto DataGrid
            // Instantiate a BindingSource for the datagrid
            BindingSource dataBind = new BindingSource();
            // Assign resulting object as the BindingSource's source
            dataBind.DataSource = selectedWaitingListEntries;
            // Place data on datagrid
            dataGridViewWaitingList.DataSource = dataBind;
        }

        private int grabWaitingListEntryID()
        {
            // Retrieve Waiting List entry ID from selected entry in datagrid
            if (dataGridViewWaitingList.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the entry's ID
                int selectedRowIndex = dataGridViewWaitingList.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridViewWaitingList.Rows[selectedRowIndex];
                // Grab selected entry ID as a string
                string selectedWaitingListID = Convert.ToString(selectedRow.Cells["WaitingListID"].Value);
                // Return the entry's ID parsed as an integer
                return int.Parse(selectedWaitingListID);
            }
            else if (dataGridViewWaitingList.SelectedRows.Count > 1)
            {
                // If more than one is selected, show error message
                MessageBox.Show("Please select no more than one row!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                // If no cell is selected, show different error message
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            return 0;
        }

        private int grabWaitingListEntryPatientID()
        {
            // Another "grab" method, this time to grab the selected entry's PatientID
            if (dataGridViewWaitingList.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the entry's ID
                int selectedRowIndex = dataGridViewWaitingList.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridViewWaitingList.Rows[selectedRowIndex];
                // Grab selected Patient ID as a string
                string selectedWaitingListPatientID = Convert.ToString(selectedRow.Cells["PatientID"].Value);
                // Return the entry's Patient ID parsed as an integer
                return int.Parse(selectedWaitingListPatientID);
            }
            else if (dataGridViewWaitingList.SelectedRows.Count > 1)
            {
                // If more than one is selected, show error message
                MessageBox.Show("Please select no more than one row!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                // If no cell is selected, show different error message
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            return 0;
        }

        private Boolean grabWaitingListEntryPriority()
        {
            // Retrieve Waiting List entry Priority value from selected entry in datagrid
            if (dataGridViewWaitingList.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the entry's index
                int selectedRowIndex = dataGridViewWaitingList.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridViewWaitingList.Rows[selectedRowIndex];
                // Grab selected entry Priority value as a string
                string selectedWaitingListPriority = Convert.ToString(selectedRow.Cells["Priority"].Value);
                // Return the entry's ID parsed as an integer
                return Boolean.Parse(selectedWaitingListPriority);
            }
            else if (dataGridViewWaitingList.SelectedRows.Count > 1)
            {
                // If more than one is selected, show error message
                MessageBox.Show("Please select no more than one row!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                // If no cell is selected, show different error message
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            return false;
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            // Open form to add a new or existing patient to the waiting list   
            NewWaitingListEntrySelector formNewWaitingListEntrySelector = new NewWaitingListEntrySelector();
            formNewWaitingListEntrySelector.Show();
        }

        private void btnMarkOrUnmarkEmergency_Click(object sender, EventArgs e)
        {
            // Decides whether the Entry is marked or unmarked as emergency/priority and changes it to 
            // the opposite value, using an if statement and the grabWaitingListEntryPriority function
            // If the waiting list entry is assigned priority,call method to remove it
            if (grabWaitingListEntryPriority() == true)
                dataWaitingList.EntryPriority(grabWaitingListEntryID(), false);
            // If not, then assign priority
            else
                dataWaitingList.EntryPriority(grabWaitingListEntryID(), true);
            // Refresh DataGrid to show that changes took effect
            RefreshDataGrid();
        }

        private void btnAssignAppointment_Click(object sender, EventArgs e)
        {
            // Opens form to assign a new PSG appointment for the entry
            // First, put the selected PatientID in a variable
            int selectedPatientID = grabWaitingListEntryPatientID();

            // If a valid (not 0) patient ID has been retured, proceed with the new appointment form
            if (selectedPatientID != 0)
            {
                // User must first select a test slot before proceeding to adding a new appointment
                TestSlotSelector formTestSlotSelector = new TestSlotSelector(selectedPatientID, "WaitingListView", 
                    grabWaitingListEntryID());
                formTestSlotSelector.Show();
            }
            else
            {
                // Show error message
                MessageBox.Show("Please select a Waiting List Entry to proceed", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Sends selected entry to the recycle bin
            // Check if the number of rows is not 0 as defined by the grabWaitingListEntryID function
            if (grabWaitingListEntryID() != 0)
            {
                // Call method to mark the entry as deleted
                try
                {
                    dataWaitingList.DeleteEntryMark(grabWaitingListEntryID());
                }
                catch (Exception)
                {
                    // If exception occurs, show error message
                    MessageBox.Show("Could not send entry to recycle bin! \nThis has likely occured due to corrupt data" +
                        "\n To resolve issue, reset database or contact administrator", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                // Refresh DataGrid
                RefreshDataGrid();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Closes form
            this.Close();
        }

        #region Filters
        // Whenever the "checked" properly of a filter text box changes, the datagrid is refreshed to 
        // match that filter
        private void radShowAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void radShowUnassigned_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void radShowAssigned_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void radEmergencies_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
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
