using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Use this class to manipulate text file adminpass.txt

namespace Sleep_Laboratory_DataBase
{
    public partial class admChangeAdminPassword : Form
    {
        /// <summary>
        /// The function of this form is to change the Administrator's Password
        /// The password is retrieved from the adminpass.txt file, and is altered
        /// according to user demand.
        /// It should be noted that it was deemed fit by the programmer to modularise the
        /// form as much as possible, i.e. split the code into smaller, more managable components
        /// where possible. This is displayed in all the forms of this application.
        /// This is demonstrated by creating separate methods for blank checking, match checking
        /// and writing to file, as opposed to writing one massive nested if statement at the 
        /// btnSetPass_Click event. This makes bug and error handling easier and more specific, 
        /// and makes the code more readable.
        /// </summary>
        
        // Declare constant for file name adminpass.txt which contains Admin password
        const string passFile = "adminpass.txt";

        public admChangeAdminPassword()
        {
            InitializeComponent();
        }

        private void admChangeAdminPassword_Load(object sender, EventArgs e)
        {
            // Code to run on form's load
            // Basically the intended functionality here is to retrieve the current Administrator
            // password from the adminpass.txt file and display it in the topmost textbox
            // with the label "Current Password"
            // Done by calling showCurrentPassword function
            txtCurrentPass.Text = showCurrentPassword(passFile); // Display current password in textbox
        }

        private void btnSetPass_Click(object sender, EventArgs e)
        {
            // Handles event for when "Set New Password" button is clicked
            // Declaration of variables to store user input from the textboxes
            string passFirstEntry = txtNewPassFirst.Text; // First entry
            string passSecondEntry = txtNewPassSecond.Text; // Second entry

            if (checkIfBlank(passFirstEntry, passSecondEntry) == false) // Check for blanks
                // If not blank, check if match
                if (checkIfMatch(passFirstEntry, passSecondEntry) == true)
                    // If match, write to file
                    writeToFile(passFirstEntry); // Whichever entry, doesn't matter since match

            // Empty contents of textboxes and set focus to textbox one, regardless of outcome
            txtNewPassFirst.Text = "";
            txtNewPassSecond.Text = "";
            txtNewPassFirst.Focus();
            // Change contents of Current Password (txtCurrentPass textbox)
            txtCurrentPass.Text = showCurrentPassword(passFile);
        }

        private void writeToFile(string newPassword)
        {
            // This method is used to handle writing the new Password to the adminpass.txt file
            // and deleting the old one
            try
            {
                // Write new password to adminpass.txt file
                using (StreamWriter fileWriter = new StreamWriter(passFile, false))
                // StreamWriter constructor is false to replace file contents instead of appending
                {
                    fileWriter.Write(newPassword); // Write new password in file
                    fileWriter.Flush(); // Save contents
                }
            }
            catch (IOException e)
            {
                // Show an error message if an exception occurs. Differs if exception is IO
                MessageBox.Show("Could not overwrite adminpass.txt file. IO exception has occured"
                    + "\n Please contact Administrator.");
                MessageBox.Show(e.Message + '\n' + e.Source + "\n\t" + e.TargetSite);
            }
            catch (Exception)
            {
                // If another exception occurs, show a more generic error message
                MessageBox.Show("An error has occured when trying to change the administrator's password"
                    + "\n Try typing another password or exit application."
                    + "An unspecified exception has occured.");
            }
        }

        private bool checkIfBlank(string firstEntry, string secondEntry)
        {
            // Method that checks if the textboxes used for password entry are blank
            if ((firstEntry == String.Empty) && (secondEntry == String.Empty))
            {
                MessageBox.Show("Please enter a new password for administrator"
                    + "\n New password cannot be blank"); // Show message if both textboxes are blank
                return true;
            }
            return false;
        }

        private bool checkIfMatch(string firstEntry, string secondEntry)
        {
            // Method to check if the entries from the two textboxes match
            if (firstEntry == secondEntry)
                return true;
            //else
                // Includes scenario that one of the textboxes is blank
                
            MessageBox.Show("Password entries do not match. \n Please try again");

            return false;
        }

        private string showCurrentPassword(string file)
        {
            // Method to retrieve the current admin password saved in adminpass.txt
            using (StreamReader passReader = new StreamReader(passFile)) // Streamreader reads adminpass.txt text
            {
                string currentPassword = passReader.ReadLine(); // inputted in variable
                passReader.Close();
                return currentPassword; // returned to caller
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            txtNewPassFirst.Text = "";
            txtNewPassSecond.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
