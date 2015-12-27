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
    public partial class PatientArchive : Form
    {
        /// <summary>
        /// This is the Patient Archive, where all active (i.e. not recycled) patient records are
        /// displayed and can be accessed. 
        /// This form deals with adding patient records, editing existing
        /// records, deleting (or rather, recycling) records and accessing the PatientForm, which
        /// collates all information about a patient in one place, for a patient selected in the form's
        /// datagrid.
        /// Again, the functionality in this form is rather simple and deals a lot with which record is 
        /// selected in the datagrid. Note that the selection mode for the datagrid is defined as
        /// "Full Row Selection" and directly editing a record in the datagrid is disabled. Thus the only way 
        /// to add or edit a record is by launching the relevant forms. These are accessed by clicking the
        /// "Add New Patient" button to add a new patient and clicking the "Edit Patient" button after
        /// selecting a record from the datagrid. Selecting a record and clicking "Send Patient to Recycle Bin"
        /// will mark the patient record as DELETED = true, or in other words, send it to recycling.
        /// </summary>

        public PatientArchive()
        {
            InitializeComponent();
            // Retrieve data from Patients table and throw them onto the datagrid
            // using the RefreshDataGrid method
            RefreshDataGrid();
        }

        private void PatientArchive_Load(object sender, EventArgs e)
        {
            
        }

        public void RefreshDataGrid()
        {
            // Method to refresh datagrid data.
            // Made public so it can be accessed while different forms are open and 
            // this one is running in the background
            
            // Place in try-catch statement in order to catch runtime exceptions if they occur
            try
            {
                // Instantiate Patient Data Methods, class that contains methods to
                // interact with the Patients table
                DataMethodsPatients patientData = new DataMethodsPatients();

                // Instantiate a Binding Source as a frontend for interacting with DataGrid
                BindingSource dataBind = new BindingSource();

                // Call LINQ query to return all non-deleted patients
                var allPatients = patientData.ReturnPatients();
                // Assign as DataSource of binding source
                dataBind.DataSource = allPatients;
                // Finally, throw data into the datagrid
                dataGridView.DataSource = dataBind;
            }
            catch
            {
                // If exception occurs show an error message
                MessageBox.Show("Warning! \n An error has occured while accessing the database"
                    + "\n Please check the database connection or contact Administrator");
            }
        }

        private int grabSelectedPatientID()
        {
            // Retrieve patient ID from selected patient in datagrid
            if (dataGridView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the patient's ID
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
                // Grab selected Patient ID as a string
                string selectedPatientID = Convert.ToString(selectedRow.Cells["PatientID"].Value);
                // Return the Patient ID parsed as an integer
                return int.Parse(selectedPatientID);
            }
            else if (dataGridView.SelectedRows.Count > 1)
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

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this window, navigating back to the Main User Interface
            this.Close();
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            // Open form to add a new patient to the Patients table
            NewPatientForm newPatientForm = new NewPatientForm();
            newPatientForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Send patient to recycle bin by marking as DELETED = true
            // Check if selected record ID is not 0
            if (grabSelectedPatientID() != 0)
            {
                // Before proceeding, prompt user to confirm that he wants to send the patient record to the recycle bin
                DialogResult confirmRecycle = MessageBox.Show("Are you sure you want to send the patient record to the "
                    + "recycle bin?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmRecycle == DialogResult.Yes) // Proceed only if the user has answered with "Yes"
                {
                    // Instantiate the DataMethodsPatients so the DeletePatientMark can be called 
                    DataMethodsPatients dataPatients = new DataMethodsPatients();
                    dataPatients.DeletePatientMark(grabSelectedPatientID());
                    // Refresh data grid
                    RefreshDataGrid();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Open form to add patient details
            // Make sure a row has been selected
            if (grabSelectedPatientID() != 0)
            {
                // Create a new instance of the Edit Patient form, passing the selected patient's ID
                EditPatientForm editPatient = new EditPatientForm(grabSelectedPatientID());
                editPatient.Show(); // Show the form
            }
            else
            {
                // If nothing is selected, display error message
                MessageBox.Show("Please select a patient record to proceed", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnOpenPatientForm_Click(object sender, EventArgs e)
        {
            // Open PatientForm, and close this one
            // PatientForm is the main concentric view for a patient
            // Make sure selected patient is not 0, as PatientForm requires Patient's ID
            if (grabSelectedPatientID() != 0)
            {
                // Create a new instance of the patient form
                // Pass the selected patient's ID as constructor argument
                PatientForm patientForm = new PatientForm(grabSelectedPatientID());
                patientForm.Show();
                // Close this form
                this.Close();
            }
            else
            {
                // If nothing is selected, display error message
                MessageBox.Show("Please select a patient record to proceed", "Error", MessageBoxButtons.OK,
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
    }
}
