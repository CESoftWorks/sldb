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
    public partial class adminViewAllData : Form
    {
        // Create DataMethods objects to retrieve data. To be instantiated in the form's constructor
        DataMethodsAppointments dataAppointments = null;
        DataMethodsPatients dataPatients = null;
        DataMethodsTestSlots dataTestSlots = null;
        DataMethodsWaitingList dataWaitingList = null;

        public adminViewAllData()
        {
            InitializeComponent();
            // Instantiate the data manipulation objects defined above
            dataAppointments = new DataMethodsAppointments();
            dataPatients = new DataMethodsPatients();
            dataTestSlots = new DataMethodsTestSlots();
            dataWaitingList = new DataMethodsWaitingList();
            // Call methods to retrieve data and fill the datagrids
            retrieveAppointmentData();
            retrievePatientData();
            retrieveTestSlotData();
            retrieveWaitingListData();
        }

        private void retrieveAppointmentData()
        {
            // Method to retrieve appointment data and fill the datagrid
            try
            {
                // Binding Source to hold data is instantiated
                BindingSource dataBind = new BindingSource();
                dataBind.DataSource = dataAppointments.ReturnAllAppointmentRecords();

                // Display onto datagrid
                dataGridViewAppointments.DataSource = dataBind;
            }
            catch
            {
                // If an exception occurs show an error message
                MessageBox.Show("Could not retrieve appointment data! \nCheck the database connection", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void retrievePatientData()
        {
            // Method to retrieve patient records and display them on the datagrid
            try
            {
                // BindingSource instantiated to hold data for datagrid
                BindingSource dataBind = new BindingSource();
                dataBind.DataSource = dataPatients.ReturnAllPatientRecords();

                // Fill the datagrid
                dataGridViewPatients.DataSource = dataBind;
            }
            catch (Exception)
            {
                // If exception occurs show an error message
                 MessageBox.Show("Could not retrieve patient data! \nCheck the database connection", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void retrieveTestSlotData()
        {
            // Method to retrieve data from the test slot table and fill the datagrid
            try
            {
                // BindingSource instantiated to hold data for datagird
                BindingSource dataBind = new BindingSource();
                dataBind.DataSource = dataTestSlots.ReturnAllTestSlotRecords();

                // Fill datagrid
                dataGridViewTestSlots.DataSource = dataBind;
            }
            catch (Exception)
            {
                // If an exception occurs show error message 
                MessageBox.Show("Could not retrieve test slot data! \nCheck the database connection", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void retrieveWaitingListData()
        {
            // Method to retrieve data from the waiting list table and fill the respective datagrid
            try
            {
                BindingSource dataBind = new BindingSource();
                dataBind.DataSource = dataWaitingList.ReturnAllWaitingListRecords();

                // Fill datagrid
                dataGridViewWaitingList.DataSource = dataBind;
            }
            catch (Exception)
            {
                // If an exception occurs show error message
                MessageBox.Show("Could not retrieve waiting list data! \nCheck the database connection", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
