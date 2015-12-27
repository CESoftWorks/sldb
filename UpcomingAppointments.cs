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
    public partial class UpcomingAppointments : Form
    {
        ///<summary> 
        /// This form displays the upcoming appointments, ie appointments that have a date equal to or 
        /// greater than today's date.
        ///  It allows the user to quickly navigate to an upcoming appointment, usually at the time which
        ///  the appointment is to be serviced, and open the Patient Form for the patient mapped to 
        ///  this appointment.
        ///  It also allows the user to cancel an appointment and send it to the recycle bin.
        /// </summary>

        // Create a DataMethodsAppointments object to be instantiated later. This will be used to return appointment data
        DataMethodsAppointments dataAppointments = null;

        public UpcomingAppointments()
        {
            InitializeComponent();
            // Instantiate the DataMethodsAppointments object
            dataAppointments = new DataMethodsAppointments();
            // Call method to fill datagrid with data
            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            // Method to refresh the contents of the datagrid
            try
            {
                // BindingSource holds data for datagrid
                BindingSource dataBind = new BindingSource();
                dataBind.DataSource = dataAppointments.ReturnUpcomingAppointments();
                // Display data onto the datagrid
                dataGridView.DataSource = dataBind;
            }
            catch (Exception)
            {
                // If exception occurs show an error message
                MessageBox.Show("Could not retrieve appointment data \nPlease restart the application or contact the "
                    + "administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int grabSelectedPatientID()
        {
            // Function that returns the selected patient's ID from the datagrid
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
            // Returns 0 as an invalid value if nothing is selected
            return 0;
        }

        private int grabSelectedAppointmentID()
        {
            // Function to return the appointmentID of the appointment selected in the datagrid
            if (dataGridView.SelectedRows.Count == 1)
            {
                // If there's only one cell selected, as it should be, grab the patient's ID
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                // Grab the selected row from the array-like DataGridViewRow
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
                // Grab selected Appointment ID as a string
                string selectedAppointmentID = Convert.ToString(selectedRow.Cells["AppointmentID"].Value);
                // Return the Appointment ID parsed as an integer
                return int.Parse(selectedAppointmentID);
            }
            // If nothing is selected return the invalid 0
            return 0;
        }

        private void btnOpenPatientForm_Click(object sender, EventArgs e)
        {
            // Open the selected patient form according to the patient selected in the datagrid
            int selectedPatientID = grabSelectedPatientID();
            if (selectedPatientID != 0)
            {
                PatientForm formPatientForm = new PatientForm(selectedPatientID);
                formPatientForm.Show();
            }
            else
            {
                // If zero has been return, show an error message
                MessageBox.Show("You must select a patient to proceed", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCancelSelectedAppointment_Click(object sender, EventArgs e)
        {
            // Cancels the appointment selected in the datagrid by recycling it (deleting but not permanently)
            int selectedAppointmentID = grabSelectedAppointmentID();
            // Check if an appointment has been selected (i.e. not returned 0)
            if (selectedAppointmentID != 0)
            {
                // If valid proceed with recycling the appointment
                dataAppointments.DeleteAppointmentMark(selectedAppointmentID);
                // Refresh the datagrid
                RefreshDataGrid();
            }
            // Else show an error message
            else
                MessageBox.Show("You must select an appointment to proceed!", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
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
