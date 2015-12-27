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
    public partial class NewWaitingListEntrySelector : Form
    {
        /// <summary>
        /// This form carries a rather simple task. 
        /// Its purpose is to navigate the user to a suitable facility so he can either add (or re-add) an existing
        /// patient to the waiting list via another facility, or add a new patient and then add the new patient
        /// to the waiting list.
        /// </summary>

        public NewWaitingListEntrySelector()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Launch the search facility
            Search formSearch = new Search();
            formSearch.Show();
        }

        private void btnPatientArchive_Click(object sender, EventArgs e)
        {
            // Open the patient Archive
            PatientArchive formPatientArchive = new PatientArchive();
            formPatientArchive.Show();
            // Close this form
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // Open form to add a new patient
            NewPatientForm formNewPatient = new NewPatientForm();
            formNewPatient.Show();
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

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
