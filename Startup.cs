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
    public partial class Startup : Form
    {
        /// <summary>
        /// This is the initial form that loads when the application is launched, and is considered
        /// to be the main form of the application, as the application exits/terminates when this form 
        /// is closed (or this form's "exit" button is clicked).
        /// It directs the user to select the appropriate user type, which will determine which form
        /// and will come up, and what functionality will be included (see other form definitions).
        /// </summary>
        public Startup() // Startup form constructor
        {
            InitializeComponent(); 
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            // Code to run on startup form load, reduntant
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Application exits 
            Application.Exit();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // Navigates to Administrator Menu, eventually
            // Administrator is required to login first, so navigate to AdminLogin form
            AdminLogin adminlogin = new AdminLogin(); // Instantiates AdminLogin form
            adminlogin.Show(); 
            this.Hide(); // Hides startup form rather than closing it.
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            // Navigates to Doctor Menu 
            MainMenuGeneric mainMenu = new MainMenuGeneric("doctor");
            mainMenu.Show();
            this.Hide();
        }

        private void btnNurse_Click(object sender, EventArgs e)
        {
            // Navigates to Nurse Menu
            MainMenuGeneric mainMenu = new MainMenuGeneric("nurse");
            mainMenu.Show();
            this.Hide();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Show About dialog
            AboutBox About = new AboutBox(); // Instantiates About box
            About.Show(); 
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

        private void Startup_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When startup form is closed, in any instance, application exits altogether
            Application.Exit();
        }
    }
}
