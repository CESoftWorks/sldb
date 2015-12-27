using Microsoft.Reporting.WinForms;
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
    public partial class repfPatientSynoptic : Form
    {
        /// <summary>
        /// This form will generate a report regarding the appointments booked for a given patient.
        /// Such report will only include active appointments, ie not recycled/deleted.
        /// The patient for which the report is to be produced is defined by the user by inputting his
        /// ID number in a textbox in the form.
        /// The report is generated using Microsoft's RDLC reports
        /// </summary>
        public repfPatientSynoptic()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Clicking this button will generate a Synoptic Patient report for the input PatientID
            // First check that the textbox is not empty before proceeding
            if (txtPatientID.Text != string.Empty)
            {
                // Try catch statement will catch any exceptions that may occur
                try
                {
                    // The results for the report are returned by a LINQ query found in the DataMethods class
                    DataMethodsAppointments dataAppointments = new DataMethodsAppointments();
                    var results = dataAppointments.ReturnAppointments(int.Parse(txtPatientID.Text));
                    // The results of the query are defined as the source of data for the report
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", results));
                  
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.RefreshReport();
                    // The "Generate report" button is disabled; only one report is to be produced at a time
                    btnGenerateReport.Enabled = false;
                }
                catch
                {
                    // If exception occurs show error message
                    MessageBox.Show("Could not produce a report for the selected patient ID. \nAre you sure the "
                        + "patient exists in the system?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Else show message to prompt for input
            else
                MessageBox.Show("Please enter a patient ID to continue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
