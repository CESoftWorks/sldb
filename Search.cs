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
    public partial class Search : Form
    {
        ///<summary>
        /// This form provides the Search faculty of the application.
        /// The user can locate a patient record in the patient archive using the patient's ID and/or name
        /// and/or surname.
        /// The search parameters are sent through a linq query, and the query results are returned and
        /// fill the datagrid. Once the datagrid is filled, the user can then select a patient and launch
        /// the patient's Patient Form to manipulate his data. Note that editing is disabled for the 
        /// datagrid and the datagrid's selection mode is full row selection.
        /// </summary>
        
        // DataMethodsPatients class object is declared, as it contains the search faculty. It is instantiated in
        // the form's constructor
        DataMethodsPatients dataPatients = null;
        // PatientReturn object as IEnumerable to hold search results declared here and filled during every search
        IEnumerable<PatientReturn> searchResults = null;

        public Search()
        {
            InitializeComponent();
            // DataMethodsPatients object is now instantiated
            dataPatients = new DataMethodsPatients();
        }

        public Boolean checkIfBlank()
        {
            // This function returns a boolean after checking whether the search parameter text boxes are empty
            // If they are empty it returns true, if they contain data it returns false
            if ((txtPatientID.Text == "") && (txtName.Text == "") && (txtSurname.Text == ""))
            {
                // Show an error message if empty
                MessageBox.Show("Please fill at least one of the search parameters to continue", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public int grabSelectedPatientID()
        {
            // This function returns the selected patient ID
            if (dataGridResultsView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the patient's ID
                int selectedRowIndex = dataGridResultsView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridResultsView.Rows[selectedRowIndex];
                // Grab selected Patient ID as a string
                string selectedPatientID = Convert.ToString(selectedRow.Cells["PatientID"].Value);
                // Return the Patient ID parsed as an integer
                return int.Parse(selectedPatientID);
            }
            // If nothing is selected, it returns 0 to be filtered out later
            return 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Right. So once this button is checked, the program first checks whether there are any parameters
            if (checkIfBlank() == false)
            {
                // Make sure searchResults object is empty
                searchResults = null;
                // Enclose it all in a try catch statement to catch errors
                try
                {
                    // Then, the nature of the search is determined, and the relevant function is called
                    if ((txtPatientID.Text != "") && (txtName.Text == "") && (txtSurname.Text == ""))
                    {
                        // If only patient ID is filled
                        int patientID = int.Parse(txtPatientID.Text);
                        searchResults = dataPatients.SearchByID(patientID);
                    }
                    else if ((txtPatientID.Text != "") && (txtName.Text != "") && (txtSurname.Text == ""))
                    {
                        // If only patient ID and name are filled
                        int patientID = int.Parse(txtPatientID.Text);
                        string patientName = txtName.Text;
                        searchResults = dataPatients.SearchByIDandName(patientID, patientName);
                    }
                    else if ((txtPatientID.Text != "") && (txtName.Text != "") && (txtSurname.Text != ""))
                    {
                        // If all fields are filled 
                        int patientID = int.Parse(txtPatientID.Text);
                        string patientName = txtName.Text;
                        string patientSurname = txtSurname.Text;
                        searchResults = dataPatients.SearchByAll(patientID, patientName, patientSurname);
                    }
                    else if ((txtPatientID.Text == "") && (txtName.Text != "") && (txtSurname.Text != ""))
                    {
                        // If name and surname are filled
                        string patientName = txtName.Text;
                        string patientSurname = txtSurname.Text;
                        searchResults = dataPatients.SearchByNameandSurname(patientName, patientSurname);
                    }
                    else if ((txtPatientID.Text == "") && (txtName.Text != "") && (txtSurname.Text == ""))
                    {
                        // If only name is filled
                        string patientName = txtName.Text;
                        searchResults = dataPatients.SearchByName(patientName);
                    }
                    else if ((txtPatientID.Text == "") && (txtName.Text == "") && (txtSurname.Text != ""))
                    {
                        // If only surname if filled
                        string patientSurname = txtSurname.Text;
                        searchResults = dataPatients.SearchBySurname(patientSurname);
                    }

                    // Once the search is completed, the returned results are displayed on the datagrid.
                    // BindingSource used to handle data for datagrid
                    BindingSource dataBind = new BindingSource();
                    dataBind.DataSource = searchResults;
                    // Display on datagrid
                    dataGridResultsView.DataSource = dataBind;
                    // If there are no results, an error message pops up
                    if (searchResults == null)
                        MessageBox.Show("No matching records found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch
                {
                    // If an exception occurs show error message
                    MessageBox.Show("An error has occured while searching for matching data. \nAre parameters in the correct format?",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Button to clear textboxes that accept search parameters. Note that this also clears the datagrid
            txtPatientID.Clear(); // Why not use this for a change
            txtName.Clear();
            txtSurname.Clear();
            dataGridResultsView.DataSource = null;
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

        private void btnSelectedPatientForm_Click(object sender, EventArgs e)
        {
            // This button opens the PatientForm for the patient selected in the datagrid
            // First grab the patient's ID from the datagrid
            int selectedPatientID = grabSelectedPatientID();
            // If it is not invalid (i.e. 0) proceed with opening the patient's PatientForm
            if (selectedPatientID != 0)
            {
                PatientForm formPatientForm = new PatientForm(selectedPatientID);
                formPatientForm.Show();
                // Since the patient is assumed to be found, this form is closed
                this.Close();
            }
            // Else show an error message
            else
                MessageBox.Show("No patient selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
