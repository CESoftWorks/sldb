using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // In order to use StreamReader & StreamWriter for password file

namespace Sleep_Laboratory_DataBase
{
    public partial class AdminLogin : Form
    {
        /// <summary>
        /// It should be noted here that this form is to solely prevent accidental login
        /// to administrator form, and it is by no means a security measure implemented 
        /// by the application.
        /// The idea is that a password prompt will discourage the user from proceeding if
        /// he is unsure of what he's doing.
        /// The administrator password required by this form to proceed to AdminMenu can 
        /// be found in the adminpass.txt file, which is part of this solution.
        /// </summary>
        
        // Declare variable to establish if login has been successful later in the program
        // Used for closing form
        bool passed = false; // false by default

        // Declare constants 
        const string fileName = "adminpass.txt"; // Default file name
        const string defaultPassword = "1234"; // Default password

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            // Nothing needs to be run on form load yet
        }

        private void AdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Go back to startup form
            // When closing form, only show startup if login is false
            // If this was omitted, when form is closed later in the program when password
            // check is passed and AdminMenu is shown, both AdminMenu and Startup would pop up
            if (passed == false)
            {
                Startup initialForm = new Startup(); // Instantiate Startup form
                initialForm.Show(); // Show instance of Startup form
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // StreamReader has plenty of room for exceptions to occur, best put in try catch
            // to catch any exception that may occur.
            // Remember to refer to ExceptionCodeKey.txt for error code interpretation!!
            try
            {
                // StreamReader from System.IO 
                // Used to read admin password from adminpass.txt file
                StreamReader passReader = new StreamReader(fileName);

                // Variable Declaration
                string passFromFile = passReader.ReadLine(); // Reads password value from adminpass.txt
                string passFromUser = txtPassword.Text; // Takes user inputted value
                passReader.Close();
                // Check if password from file matches user input
                if (passFromFile == passFromUser)
                {
                    // If passwords match, proceed to AdminMenu form
                    AdminMenu admin = new AdminMenu();
                    admin.Show();

                    passed = true; // Passed is now true since login is successful
                    this.Close(); // Close login form
                }
                else
                {
                    // Show message box to declare login as unsucessful
                    MessageBox.Show("Login unsuccessful. Please try again");
                    // Clear password box and set focus on it so user can try again
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch (FileNotFoundException)
            {
                // Handle exception if adminpass.txt does not exist
                // Show a little more comprehensive message
                MessageBox.Show(
                    "Warning!!\n Administrator password file adminpass.txt not found!"
                    + "\n A new adminpass.txt file has been created with the Default Password set"
                    + "\n Please try logging in again. \n \n If problem insists, contact Administrator"
                    + "\n Error code 201");
                // Create a new adminpass.txt file with the default password
                using (StreamWriter fileWrite = new StreamWriter(fileName, false)) // Create the new adminpass.txt file
                {
                    fileWrite.Write(defaultPassword); // Write the default password in it
                    fileWrite.Flush(); // Save the new password
                }
                // User should now try again
            }
            catch (Exception)
            {
                // Handle any other kind of exception
                MessageBox.Show(
                    "Warning!! \n A problem has been encountered when trying to access the adminpass.txt file"
                    + "\n Please contact Administrator! An undefined exception has occured."
                    + "\n Application will now exit."
                    + "\n Error code 204");
                // Program exits, perhaps can be further investigated by administrator?
                Application.Exit(); 
                // In this event, an exception other than FileNotFound may cause serious problems 
                // in the application as a whole, since it shouldn't really be occuring
                // Perhaps its best to just exit the application altogether
            }
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Go back to startup form
            this.Close(); // Do so by calling the FormClosed event, no need to repeat code
        }
    }
}
