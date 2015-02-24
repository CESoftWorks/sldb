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
    public partial class SetTestSlots : Form
    {
        ///<summary>
        /// Via this form the user can add (or remove) test slots, which are translated to
        /// available test dates for a polysomnographer test.
        /// The user can select a date he deems available for a PSG test through the form's
        /// date picker, and then add this date to a new TestSlot record that is created when
        /// he submits this new date, done by the "Add new Test Slot" button event.
        /// The user can also view all the available (or other, as defined by the datagrid filters)
        /// test slots stored in the system in the datagrid found on the form, and may delete one
        /// by selecting it and clicking the "Delete" button, which will recycle the test slot.
        /// The datagrid has editing disabled and its selection mode is set to full row.
        /// </summary>
        
        // Create a DataMethodsTestSlot object for data manipulation to be instantiated in the form's constructor
        DataMethodsTestSlots dataTestSlots = null;
        // Create a TestSlot object for adding new test slots, to be instantiated every time it is needed
        TestSlot newTestSlot;

        public SetTestSlots()
        {
            InitializeComponent();
            // Instantiate the dataTestSlots object for data manipulation
            // This is done so only one connection is made to the database
            dataTestSlots = new DataMethodsTestSlots();
            // Set the default filter as "Show Available only" to show only unassigned/available test slots
            radAvailable.Checked = true;
            // Call method to retrieve/refresh the contents of the datagrid accordingly
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            // Method to refresh the contents of the datagrid according to the selected filters with contents of the 
            // TestSlots table
            // Create an IEnumerable<TestSlotReturn> object to hold all of the returned data
            IEnumerable<TestSlotReturn> selectedTestSlots = null;
            // Input data into the above object according to the selected
            if (radAvailable.Checked == true)
                selectedTestSlots = dataTestSlots.ReturnAvailableSlots();
            else if (radAssigned.Checked == true)
                selectedTestSlots = dataTestSlots.ReturnAssignedSlots();
            else 
                selectedTestSlots = dataTestSlots.ReturnSlots();

            // New BindingSource object holds data for the datagrid
            BindingSource dataBind = new BindingSource();
            // Assign the selected test slots to the binding source object's data source
            dataBind.DataSource = selectedTestSlots;
            // Throw it all onto the datagrid
            dataGridTestSlots.DataSource = dataBind;
        }

        private void submitNewTestSlot()
        {
            // Method to submit new test slot to TestSlots table. Assumes validation has occured.
            try
            {
                // Create a new instance of the newTestSlot object, to add a new record in the respective table
                newTestSlot = new TestSlot();
                // Assign date as newTestSlot object's property
                newTestSlot.TestDate = DateTime.Parse(dateSelectedTestDate.Text);
                // Call method to add new record from the DataMethodsTestSlots class, now dataTestSlots object
                dataTestSlots.NewSlot(newTestSlot);
            }
            catch (Exception)
            {
                // If exception has occured, display error message
                MessageBox.Show("An error has occured while trying to add a new Test Slot. \nPlease close this window "
                    + "and try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int grabSelectedTestSlotID()
        {
            // Function to return the selected test slot's ID, selected in the datagrid
            // Note that return 0 represents an invalid ID, that is returned in case no record is selected or
            // no record exists
            if (dataGridTestSlots.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, proceed
                int selectedRowIndex = dataGridTestSlots.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridTestSlots.Rows[selectedRowIndex];
                // Grab selected test slot's ID as a string
                string selectedTestSlotID = Convert.ToString(selectedRow.Cells["TestSlotID"].Value);
                // Return the test slot's ID parsed as an integer
                return int.Parse(selectedTestSlotID);
            }
            return 0; // As discussed above
        }

        private void btnAddTestSlot_Click(object sender, EventArgs e)
        {
            // Add a new test slot according to the selected date
            // Make sure the selected date is a future one, i.e today or later
            if (dateSelectedTestDate.Value >= DateTime.Today)
            {
                // If the date is today or later, carry on with adding it
                submitNewTestSlot();
                // Refresh the datagrid
                refreshDataGrid();
            }
            else
            {
                // Else, show an error message
                MessageBox.Show("Past date selected! \nPlease select a suitable date!", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            // Delete the test slot selected from the table/datagrid
            // Assign the value of the grabbed TestSlotID in a variable, using the grabSelectedTestSlotID function
            int selectedTestSlotID = grabSelectedTestSlotID();
            // Make sure a valid TestSlot ID is selected
            if (selectedTestSlotID != 0)
            {
                try
                {
                    // Call method to send the test slot to the recycle bin
                    dataTestSlots.DeleteSlotMark(selectedTestSlotID);
                    // Refresh data grid
                    refreshDataGrid();
                }
                catch (Exception)
                {
                    // If exception occurs, show error message
                    MessageBox.Show("Could not delete Test Slot. \nPlease try again", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                // Else display error message
                MessageBox.Show("Please select a TestSlot to continue", "Warning", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
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

        #region Filters
        // Call refreshDataGrid method every time a different filter is selected
        private void radAvailable_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void radAssigned_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }
        #endregion
    }
}
