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
    public partial class ReportSelector : Form
    {
        /// <summary>
        /// This form prompts the user to select which type of report he wishes to produce.
        /// </summary>
        public ReportSelector()
        {
            InitializeComponent();
        }

        private void btnSynopticPatientReport_Click(object sender, EventArgs e)
        {
            // The system will produce a synoptic appointment report for a selected patient
            repfPatientSynoptic formPatientSynoptic = new repfPatientSynoptic();
            formPatientSynoptic.Show();
        }

        private void btnMonthlyAppointmentReport_Click(object sender, EventArgs e)
        {
            // The system will produce a report of all the appointments in a given month
            repfMonthlyAppointmentsReport formMonthlyAppointments = new repfMonthlyAppointmentsReport();
            formMonthlyAppointments.Show();
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
            // Closes this form
            this.Close();
        }


    }
}
