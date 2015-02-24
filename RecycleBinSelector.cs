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
    public partial class RecycleBinSelector : Form
    {
        ///<summary>
        ///This form is for the user to select which table's recycled fields he wish to view.
        /// </summary>

        // Create a RecycleBin form object to be instantiated later
        RecycleBin formRecycleBin = null;

        public RecycleBinSelector()
        {
            InitializeComponent();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            // Open the recycle bin form, declaring that the selected table is Appointments
            formRecycleBin = new RecycleBin("Appointments");
            formRecycleBin.Show();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            // Open the recycle bin form, declaring that the selected table is Patients 
            formRecycleBin = new RecycleBin("Patients");
            formRecycleBin.Show();
        }

        private void btnTestSlots_Click(object sender, EventArgs e)
        {
            // Open the recycle bin form, declaring that the selected table is TestSlots
            formRecycleBin = new RecycleBin("TestSlots");
            formRecycleBin.Show();
        }

        private void btnWaitingList_Click(object sender, EventArgs e)
        {
            // Open the recycle bin form, declaring that the selected table is Waiting List
            formRecycleBin = new RecycleBin("WaitingList");
            formRecycleBin.Show();
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
