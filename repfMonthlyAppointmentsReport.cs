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
    public partial class repfMonthlyAppointmentsReport : Form
    {
        /// <summary>
        /// This form will generate a report regarding the appointments booked for a given month.
        /// Such report will only include active appointments, ie not recycled/deleted.
        /// The month for which the report is to be produced is selected by the user in a drop
        /// down box found in the form.
        /// The report is generated using Microsoft's RDLC reports
        /// </summary>
        public repfMonthlyAppointmentsReport()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Clicking this button will generate a Monthly Appointment report for the selected month
            // First check that the combobox is not empty before proceeding
            if (cbxMonth.Text != string.Empty)
            {
                // Try catch statement will catch any exceptions that may occur
                try
                {
                    // The data used for the report are extracted using a LINQ query in the DataMethodsAppointments class
                    DataMethodsAppointments dataAppointments = new DataMethodsAppointments();
                    var results = dataAppointments.ReturnAppointmentsByMonth(int.Parse(cbxMonth.Text));
                    // The results of the query are used as the report's data source
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", results));

                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.RefreshReport();
                    // Also disable this button. Only one report is to be produced at a time. 
                    // Done to avoid conflicts
                    btnGenerateReport.Enabled = false;
                }
                catch
                {
                    // If exception occurs show error message
                    MessageBox.Show("Could not produce a report for the selected month.",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Else show message to prompt for input
            else
                MessageBox.Show("Please enter a month to continue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
