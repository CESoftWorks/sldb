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
    public partial class RecycleBin : Form
    {
        ///<summary>
        /// This is a generic Recycle Bin form.
        /// The exact data that will occupy this form's datagrid, as well as its operations, is determined
        /// by the constructor string parameter binSelection, which sets the table that is in use.
        /// The data filling the datagrid is that where the DELETED field of the record is set to TRUE,
        /// also known as recycled or deleted fields.
        /// "Clearing" the recycle bin permanently removes the displayed records from the database
        /// </summary>

        // String value to contain the table selection from the previous form to be used throughout this form
        string BinSelection = null;
        // DataMethods classes defined but set to null. Only required relevant class will be instantiated in the constructor
        // according to selection
        DataMethodsAppointments dataAppointments = null;
        DataMethodsPatients dataPatients = null;
        DataMethodsTestSlots dataTestSlots = null;
        DataMethodsWaitingList dataWaitingList = null;

        public RecycleBin(string binSelection)
        {
            InitializeComponent();
            // Set the bin selection to the higher scoped variable declared above
            BinSelection = binSelection;
            // If statement to modify form according to selection
            if (BinSelection == "Appointments")
            {
                // Change the title label accordingly
                lblTitleLabel.Text = "Recycle Bin for Appointments";
                // Instantiate the relevant DataMethods class form manipulation
                dataAppointments = new DataMethodsAppointments();
                // Refresh the datagrid accordingly 
                refreshDataGrid();
            }
            else if (BinSelection == "Patients")
            {
                // Change the title label accordingly
                lblTitleLabel.Text = "Recycle Bin for Patients";
                // Instantiate the relevant DataMethods class form manipulation
                dataPatients = new DataMethodsPatients();
                // Refresh the datagrid accordingly 
                refreshDataGrid();
            }
            else if (BinSelection == "TestSlots")
            {
                // Change the title label accordingly
                lblTitleLabel.Text = "Recycle Bin for Test Slots";
                // Instantiate the relevant DataMethods class form manipulation
                dataTestSlots = new DataMethodsTestSlots();
                // Refresh the datagrid accordingly 
                refreshDataGrid();
            }
            else if (BinSelection == "WaitingList")
            {
                // Change the title label accordingly
                lblTitleLabel.Text = "Recycle Bin for Waiting List Entries";
                // Instantiate the relevant DataMethods class form manipulation
                dataWaitingList = new DataMethodsWaitingList();
                // Refresh the datagrid accordingly 
                refreshDataGrid();
            }
            else
            {
                // If none of the above is defined, show error messsage
                MessageBox.Show("No valid table has been selected! \nContact Administrator", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void refreshDataGrid()
        {
            // Method to refresh the contents of the datagrid
            // Create a new instance of the BindingSource class to hold data for the datagrid
            BindingSource dataBind = new BindingSource();
            // Again, if statement sorts through which table has been chosen
            if (BinSelection == "Appointments")
            {
                // Return the deleted appointments
                var recycledAppointments = dataAppointments.ReturnDeletedAppointments();
                // Assign returned appointments as dataBind's datasource
                dataBind.DataSource = recycledAppointments;
                // Throw data to datagrid
                dataGridView.DataSource = dataBind;
            }
            else if (BinSelection == "Patients")
            {
                // Return deleted Patient records
                var recycledPatients = dataPatients.ReturnDeletedPatients();
                // Assign to dataBind
                dataBind.DataSource = recycledPatients;
                // Throw onto datagrid
                dataGridView.DataSource = dataBind;
            }
            else if (BinSelection == "TestSlots")
            {
                // Same drill, return deleted TestSlots
                var recycledTestSlots = dataTestSlots.ReturnDeletedSlots();
                // Assign to dataBind
                dataBind.DataSource = recycledTestSlots;
                // And display on datagrid
                dataGridView.DataSource = dataBind;
            }
            else if (BinSelection == "WaitingList")
            {
                // Last one for waiting list
                var recycledWaitingListEntries = dataWaitingList.ReturnDeletedEntries();
                // dataBind assignment
                dataBind.DataSource = recycledWaitingListEntries;
                // And display on datagrid
                dataGridView.DataSource = dataBind;
                // Right-o
            }
        }

        private int grabAppointmentID()
        {
            // This function is only called if the active table is Appointments
            // Grab the selected Appointment's ID
            if (dataGridView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, grab the selection's Appointment ID 
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
                // Grab selected Appointment ID as a string
                string selectedAppointmentID = Convert.ToString(selectedRow.Cells["AppointmentID"].Value);
                // Return the AppointmentID parsed as an integer
                return int.Parse(selectedAppointmentID);
            }
            return 0; // Else return 0, to be filtered out later
        }

        private int grabPatientID()
        {
            // This function is only called if the active table is Patients
            if (dataGridView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, grab the selection's Patient ID 
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
                // Grab selected Patient ID as a string
                string selectedPatientID = Convert.ToString(selectedRow.Cells["PatientID"].Value);
                // Return the AppointmentID parsed as an integer
                return int.Parse(selectedPatientID);
            }
            return 0; // This is filtered out later
        }

        private int grabTestSlotID()
        {
            // This function, for the love of everything holy, is only called if the active table is TestSlots
            if (dataGridView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, grab the selection's Test Slot ID 
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
                // Grab selected Test Slot ID as a string
                string selectedTestSlotID = Convert.ToString(selectedRow.Cells["TestSlotID"].Value);
                // Return the AppointmentID parsed as an integer
                return int.Parse(selectedTestSlotID);
            }
            return 0; // Again this is filtered out by the caller
        }

        private int grabWaitingListID()
        {
            // This function right here is only called if the active table is Waiting List
            if (dataGridView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, grab the selection's Waiting List ID 
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridView
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
                // Grab selected Waiting List ID as a string
                string selectedWaitingListID = Convert.ToString(selectedRow.Cells["WaitingListID"].Value);
                // Return the AppointmentID parsed as an integer
                return int.Parse(selectedWaitingListID);
            }
            return 0; // To be filtered out
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
           // Restore the selected record, according to which table is active 
            if (BinSelection == "Appointments")
            {
                // Call method to restore the selected appointment after grabbing its ID value
                // Variable to store the grabbed ID
                int selectedAppointmentID = grabAppointmentID();
                if (selectedAppointmentID != 0)
                {
                    // If the appointment ID is not returned as 0, which is invalid, proceed with restoring the 
                    // selected appointments
                    // Try..catch statement to catch exceptions
                    try
                    {
                        dataAppointments.RestoreDeletedAppointment(selectedAppointmentID);
                        // Display success message
                        MessageBox.Show("Successfully restored Appointment!", "Success!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        // Refresh contents of datagrid
                        refreshDataGrid();
                    }
                    catch (Exception)
                    {
                        // If error has occured display error message
                        MessageBox.Show("Could not restore appointment \nPlease restart the application and try again",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (BinSelection == "Patients")
            {
                // Call method to restore the selected patient record according to the patient's ID
                // Similar procedure to above
                int selectedPatientID = grabPatientID();
                // Check if it is 0 (invalid) before proceeding
                if (selectedPatientID != 0)
                {
                    try
                    {
                        // Restore the selected record
                        dataPatients.RestoreDeletedPatient(selectedPatientID);
                        // Show success message
                        MessageBox.Show("Successfully restored patient record!", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        // Refresh the data grid
                        refreshDataGrid();
                    }
                    catch (Exception)
                    {
                        // If exception occurs show error message
                        MessageBox.Show("Could not restore patient record \nPlease restart the application and try again",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (BinSelection == "TestSlots")
            {
                // Call method to restore the selected test slot
                // Same drill as above
                int selectedTestSlotID = grabTestSlotID();
                // Check if its invalid, if not proceed
                if (selectedTestSlotID != 0)
                {
                    try
                    {
                        // Restore the test slot
                        dataTestSlots.RestoreDeletedSlot(selectedTestSlotID);
                        // Show success message
                        MessageBox.Show("Successfully restored test slot!", "Success!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        // Refresh data grid
                        refreshDataGrid();
                    }
                    catch (Exception)
                    {
                        // If exception occurs show error message
                        MessageBox.Show("Could not restore the test slot \nPlease restart the application and try again",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (BinSelection == "WaitingList")
            {
                // Call method to restore the selected waiting list entry
                // Again, same procedure
                int selectedWaitingListID = grabWaitingListID();
                // Check if invalid and proceed
                if (selectedWaitingListID != 0)
                {
                    try
                    {
                        // Restore entry
                        dataWaitingList.RestoreDeletedEntry(selectedWaitingListID);
                        // Show success message
                        MessageBox.Show("Successfully restored selected entry!", "Success!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        // Refresh the datagrid
                        refreshDataGrid();
                    }
                    catch (Exception)
                    {
                        // If exception occurs show error message
                        MessageBox.Show("Could not restore the selected entry \nPlease restart the application and try again",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            // Clear all recycled records from the selected table -> delete them permanently
            if (BinSelection == "Appointments")
            {
                try
                {
                    dataAppointments.DeleteAllRecycledAppointmentsPermanently();
                    // Refresh datagrid
                    refreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs show error message
                    MessageBox.Show("Could not delete recycled appointments! \nPlease restart application and try again",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (BinSelection == "Patients")
            {
                try
                {
                    dataPatients.DeleteAllRecycledPatientsPermanenly();
                    // Refresh datagrid
                    refreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs show error message
                    MessageBox.Show("Could not delete recycled patients! \nPlease restart application and try again",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (BinSelection == "TestSlots")
            {
                try
                {
                    dataTestSlots.DeleteAllRecycledSlots();
                    // Refresh the datagrid
                    refreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs show error message
                    MessageBox.Show("Could not delete recycled test slots! \nPlease restart application and try again",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (BinSelection == "WaitingList")
            {
                try
                {
                    dataWaitingList.DeleteAllRecycledEntriesPermanently();
                    // Refresh that datagrid
                    refreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs show error message
                    MessageBox.Show("Could not delete recycled entries! \nPlease restart application and try again",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }

    }
}
