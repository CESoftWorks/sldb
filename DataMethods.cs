using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data;
using System.IO; // For LINQtoSQL classes mapping to entities

namespace Sleep_Laboratory_DataBase
{
    /// <summary>
    /// This is where all the methods that relate to the database are stored.
    /// This includes database queries, functionality to insert and remove rows,
    /// as well as functions to count records and return records as LINQ objects.
    /// LINQ-Related classes are stored in a separate file (LINQRelatedClasses.cs).
    /// </summary>

    class DataMethods
    {
        /// Generic class to give some functionality to derived classes
        /// Its main function is to define the database connection
        
        // Define database connection string default value
        public string connString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename="
                + "\"|DataDirectory|\\dbSLDataBase.mdf"
                + "\";Integrated Security=True"; // Modified to account for escape sequences "\"

        // Declare database connection but do not instantiate; do so in the class constructor
        public dbSLDatabase db = null; // Uses custom DataContext
        
        protected DataMethods() // Protected - Give only to derived classes
        {
            // Class constructor. It is called every time a derived class is instantiated
            // Read the assigned database connection string from a text file
            // Try..catch statement used to catch any exceptions that may occur and respond accordingly
            try
            {
                // Streamreader is used to read data from the textfile that contains the connection string
                StreamReader textFileReader = new StreamReader("dbConnectionString.txt");
                string customDatabaseConnection = textFileReader.ReadLine();
                // Assign the read value as the connection string (connString)
                connString = customDatabaseConnection;
                // Close the reader
                textFileReader.Close();
            }
            catch (Exception)
            {
                // If exception occurs, follow the default database path
                connString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename="
                    + "\"|DataDirectory|\\dbSLDataBase.mdf"
                    + "\";Integrated Security=True";
            }
            // Instantiate database connection according to the assigned connection string
            db = new dbSLDatabase(connString);
        }
    }


    class DataMethodsPatients : DataMethods
    {
        /// This is where all methods relating to the database table "Patients" are stored
        /// Includes queries and functions to add, remove and edit rows.
        #region Count
        // COUNT Functionality
        // Functionality to count database records for this table
        public int CountAllPatients()
        {
            /// Function that counts all patients from Patients table
            /// Excludes recycled

            // LINQ query to database
            var q = // Query variable
                from p in db.Patients // Select the Patients table
                where p.DELETED == false // Where DELETED is marked as false
                select p.PatientID; // Return a single field for counting

            int patientCount = q.Count(); // Count returned fields, use .NET's count founction

            return patientCount; // Return number of patients to caller
        }

        public int CountAllPatientsPlusDeleted()
        {
            /// Function that counts all patients from Patients table
            /// Includes recycled records this time

            // LINQ query to database
            var q =
                from p in db.Patients
                select p.PatientID; // This query selects all patients

            int patientCount = q.Count(); // Counts the selected fields

            return patientCount;
        }
        #endregion

        #region Search
        // SEARCH functionality
        // Contains all methods required for searching through the Patients table

        // There are 6 variations for the Search function
        // Input criteria can be PatientID, Name and Surname

        public IEnumerable<PatientReturn> SearchByID(int patientID)
        {
            /// Search by patient ID number
            // Uses linq query
            var matchingPatients = // Anonymous type var means that the compiler determines the LINQ query's type
                from p in db.Patients   // at compilation time, making its enumeration to a PatientReturn object possible
                where p.DELETED == false //Do not display deleted records
                where p.PatientID == patientID // Match with the input patient ID number
                select new PatientReturn // For every matching record, assing record values to the return object's properties
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment
                };

            return matchingPatients;
        }

        public IEnumerable<PatientReturn> SearchByName(string patientName)
        {
            /// Search by patient name
            /// Include partial matches
            // LINQ query to search for patients that match the criteria
            var matchingPatients =
                from p in db.Patients // From the Patients table in the database
                where p.DELETED == false // Return fields that are not marked as deleted = true (recycled)
                where p.Name.ToLower().Contains(patientName.ToLower()) // Case insensitive search
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                };

            return matchingPatients;
        }

        public IEnumerable<PatientReturn> SearchBySurname(string patientSurname)
        {
            /// Search by patient surname
            /// Include partial matches
            // LINQ query, similar to above
            var matchingPatients =
                from p in db.Patients
                where p.DELETED == false
                where p.Surname.ToLower().Contains(patientSurname.ToLower()) // Case insensitive search
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                };

            return matchingPatients;
        }

        public IEnumerable<PatientReturn> SearchByIDandName(int patientID, string patientName)
        {
            /// Search by patient ID and name
            /// Include partial matches
            var matchingPatients =
                from p in db.Patients
                where p.DELETED == false
                where p.PatientID == patientID
                where p.Name.ToLower().Contains(patientName.ToLower()) // Case insensitive search
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                };

            return matchingPatients;
        }

        public IEnumerable<PatientReturn> SearchByIDandSurname(int patientID, string patientSurname)
        {
            /// Search by patient ID and surname
            /// Includes partial matches
            var matchingPatients =
                from p in db.Patients
                where p.DELETED == false
                where p.PatientID == patientID
                where p.Surname.ToLower().Contains(patientSurname.ToLower()) // Case insensitive search
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                };

            return matchingPatients;
        }

        public IEnumerable<PatientReturn> SearchByNameandSurname(string patientName, string patientSurname)
        {
            /// Search by patient name and surname
            /// Include partial matches
            var matchingPatients =
                from p in db.Patients
                where p.DELETED == false
                where p.Name.ToLower().Contains(patientName.ToLower())
                where p.Surname.ToLower().Contains(patientSurname.ToLower())
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                };

            return matchingPatients;
        }

        public IEnumerable<PatientReturn> SearchByAll(int patientID, string patientName, string patientSurname)
        {
            /// Search by ID, name and surname
            /// Include Partial matches 
            // Search by all search parameter fields form matching
            var matchingPatients =
                from p in db.Patients
                where p.DELETED == false
                where p.PatientID == patientID
                where p.Name.ToLower().Contains(patientName.ToLower())
                where p.Surname.ToLower().Contains(patientSurname.ToLower())
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                };

            return matchingPatients;
        }

        #endregion

        #region Return
        // RETURN Functionality
        // Functionality to return data from table
        public IEnumerable<PatientReturn> ReturnPatients()
        {
            /// Method to return all patients that have not been marked as deleted
            var q = // LINQ query to database
                from p in db.Patients
                where p.DELETED == false // Return those not marked as deleted
                select new PatientReturn // Assign values to the return object's properties
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    Height = p.Height,
                    Weight = p.Weight,
                    BMI = p.BMI,
                    EpsworthScale = p.EpsworthScale,
                    BriefAssessment = p.BriefAssessment,
                    WaitingListEntries = p.WaitingListEntries,
                    Appointments = p.Appointments
                };

            return q; // Return query
        }

        public IEnumerable<PatientReturn> ReturnDeletedPatients()
        {
            /// Method to return patients marked as deleted
            var q =
                from p in db.Patients
                where p.DELETED == true // Patients that are marked as deleted 
                select new PatientReturn
                { // Return only required fields for this purpose
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    Sex = p.Sex,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                    BriefAssessment = p.BriefAssessment,
                    WaitingListEntries = p.WaitingListEntries,
                    Appointments = p.Appointments
                };

            return q; // Return query results
        }

        public Patient ReturnSinglePatient(int patientID)
        {
            /// Return data about a single patient according to his ID
            // Find patient in question using a linq query
            Patient selectedPatient = // Because only a single patient is returned, the query's results can take the 
                (from p in db.Patients // form of a Patient object, as there is no need for enumeration
                 where p.PatientID == patientID
                 select p).First();

            return selectedPatient;
        }

        public IEnumerable<PatientReturn> ReturnAllPatientRecords()
        {
            /// Returns all patient records in the Patients table regardless of DELETED status
            var q =
                from p in db.Patients
                select new PatientReturn
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    Surname = p.Surname,
                    DateOfBirth = p.DateOfBirth
                };

            return q;
        }
        #endregion

        #region Manipulate
        // MANIPULATE Functionality
        // Functionality required to manipulate database data
        public void NewPatient(Patient newPatient)
        {
            /// Method to add a new patient to the database
            
            /// NOTE - Caller must create a new instance of the Patient class to send in for adding
            // Mark object for submission in database
            db.Patients.InsertOnSubmit(newPatient);
            // Sumbit changes to database, adding new record
            db.SubmitChanges();
        }

        public void EditPatient(Patient editPatient)
        {
            /// Method to edit patient details per user input
            // First find the selected patient
            var selectedPatient =
                (from p in db.Patients
                 where p.PatientID == editPatient.PatientID
                 select p).Single();

            // Make changes according to user input Patient object          
            // Now this is where things get a bit messy. .NET's "Attach" method did not respond to the requirements
            // of this task's implementation, and assigning the old object as the new object does not
            // update the database. So the alternative here is, assign every old property to the editted one
            selectedPatient.Name = editPatient.Name;
            selectedPatient.Surname = editPatient.Surname;
            selectedPatient.Sex = editPatient.Sex;
            selectedPatient.DateOfBirth = editPatient.DateOfBirth;
            selectedPatient.PhoneNumber = editPatient.PhoneNumber;
            selectedPatient.Height = editPatient.Height;
            selectedPatient.Weight = editPatient.Weight;
            selectedPatient.BMI = editPatient.BMI;
            selectedPatient.EpsworthScale = editPatient.EpsworthScale;
            selectedPatient.BriefAssessment = editPatient.BriefAssessment;
            // Submit changes to database
            db.SubmitChanges();
        }

        public void DeletePatientMark(int patientID)
        {
            /// Mark patient as deleted
            // First locate the patient according to his unique ID
            var selectedPatient =
                (from p in db.Patients
                 where p.PatientID == patientID
                 select p).First();

            // Mark patient as deleted
            selectedPatient.DELETED = true;

            // Make sure that appointments and waiting list entries mapping to this patient are also marked as deleted
            // First handle appointments
            DataMethodsAppointments dataAppointments = new DataMethodsAppointments();
            foreach (var appointment in db.Appointments)
            {
                if (appointment.PatientID == patientID)
                    dataAppointments.DeleteAppointmentMark(appointment.AppointmentID);
            }
            // Now handle waiting list entries
            DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
            foreach (var waitingListEntry in db.WaitingList)
            {
                if (waitingListEntry.PatientID == patientID)
                    dataWaitingList.DeleteEntryMark(waitingListEntry.WaitingListID);
            }
            // Submit changes to database
            db.SubmitChanges();
            /* PatientID was supposed to be changed to a randomly hashed ID. However, this was considered
            to be bad practice, and ended up being very impractical to implement.
             * So instead, whenever a new patient is added that already exists, error pops up saying 
             * yo, patient probably exists, go find him in the recycle bin
             */
        }

        public void DeletePatientPermanent(int patientID)
        {
            /// Permanently delete patient record
            /// WARNING-Field will be deleted with this method
            // First locate selected patient
            var selectedPatient =
                (from p in db.Patients
                 where p.PatientID == patientID
                 where p.DELETED == true // Make sure it's already been marked as DELETED
                 select p).First();

            // Mark object for deletion on submission
            db.Patients.DeleteOnSubmit(selectedPatient);

            // Submit changes to database
            db.SubmitChanges();
        }

        public void DeleteAllRecycledPatientsPermanenly()
        {
            /// Method to clear all recycled patients
            // First find all patients that are marked as recycled
            var recycledPatients =
                from p in db.Patients
                where p.DELETED == true
                select p;

            // Iterate through each of those records and delete it
            foreach (var patient in recycledPatients)
            {
                db.Patients.DeleteOnSubmit(patient);
            }
            // Submit changes
            db.SubmitChanges();
        }

        public void ResetPatientsTable()
        {
            /// WARNING - THIS METHOD WILL DELETE ALL PATIENT RECORDS PERMANENTLY!
            foreach (var patient in db.Patients) // Foreach loop iterates through every patient record and deletes it permanently
            {
                db.Patients.DeleteOnSubmit(patient);
            }
            db.SubmitChanges();
        }

        public void RestoreDeletedPatient(int patientID)
        {
            /// Restores patient previously marked as DELETED = true
            // Find selected patient to be restored
            var selectedPatient =
                (from p in db.Patients
                 where p.PatientID == patientID
                 select p).First();
            
            // Change DELETED field from true to false
            selectedPatient.DELETED = false;
            // Foreach loops to restore mapped appointments and waiting list entries
            // Appointments restore
            DataMethodsAppointments dataAppointments = new DataMethodsAppointments();
            foreach (var appointment in db.Appointments)
            {
                if (appointment.PatientID == patientID)
                    dataAppointments.RestoreDeletedAppointment(appointment.AppointmentID); 
            }
            // Waiting list entries restore
            DataMethodsWaitingList dataWaitingList = new DataMethodsWaitingList();
            foreach (var waitingListEntry in db.WaitingList)
            {
                if (waitingListEntry.PatientID == patientID)
                    dataWaitingList.RestoreDeletedEntry(waitingListEntry.WaitingListID);
            }
            // Submit changes to database
            db.SubmitChanges();
        }
        #endregion
    }

    class DataMethodsWaitingList : DataMethods
    {
        /// This is where all methods relating to the database table "WaitingList" are stored
        /// Includes queries and functions to add, remove and edit rows.

        #region Count
        // COUNT Functionality
        // Functionality to count database records for this table
        public int CountAllEntries()
        {
            /// Function that counts all waiting list entries in the WaitingList table
            /// Excludes recycled

            // LINQ query to database
            var q = // Query variable
                from w in db.WaitingList // Select the WaitingList table
                where w.DELETED == false // Where DELETED is marked as false
                select w.WaitingListID; // Return a single field for counting

            int entryCount = q.Count(); // Count returned fields, use .NET's count founction

            return entryCount; // Return number of Waiting List entries to caller
        }

        public int CountAllEntriesPlusDeleted()
        {
            /// Function that counts all waiting list entries in WaitingList table
            /// Includes recycled records this time

            // LINQ query to database
            var q =
                from w in db.WaitingList
                select w.WaitingListID; // This query selects all entries, does not exclude DELETED = true

            int entryCount = q.Count(); // Counts the selected fields

            return entryCount;
        }
        #endregion
        
        #region Return
        // RETURN Functionality for this table
        public WaitingListEntry ReturnEntry(int waitingListID)
        {
            // Method to return single entry according to WaitingListID
            WaitingListEntry selectedEntry =
                (from w in db.WaitingList
                 where w.WaitingListID == waitingListID
                 select w).First();
            return selectedEntry;
        }

        public IEnumerable<WaitingListReturn> ReturnEntries()
        {
            /// Method to return all waiting list entries that have not been marked as deleted
            var q = // LINQ query to database
                from w in db.WaitingList
                where w.DELETED == false
                select new WaitingListReturn // Enumerate to WaitingListReturn
                {
                    WaitingListID = w.WaitingListID,
                    DateRegistered = w.DateRegistered,
                    Priority = w.Priority,
                    PatientID = w.PatientID,
                    TestSlotID = w.TestSlotID
                };

            return q; // Return query
        }

        public IEnumerable<WaitingListReturn> ReturnAssignedEntries()
        {
            var q =
                from w in db.WaitingList
                where w.DELETED == false
                where w.TestSlotID != null
                select new WaitingListReturn
                {
                    WaitingListID = w.WaitingListID,
                    DateRegistered = w.DateRegistered,
                    Priority = w.Priority,
                    PatientID = w.PatientID,
                    TestSlotID = w.TestSlotID
                };

            return q;
        }

        public IEnumerable<WaitingListReturn> ReturnUnAssignedEntries()
        {
            var q =
                from w in db.WaitingList
                where w.DELETED == false
                where w.TestSlotID == null
                select new WaitingListReturn
                {
                    WaitingListID = w.WaitingListID,
                    DateRegistered = w.DateRegistered,
                    Priority = w.Priority,
                    TestSlotID = w.TestSlotID,
                    PatientID = w.PatientID
                };

            return q;
        }

        public IEnumerable<WaitingListReturn> ReturnEmergencyEntries()
        {
            var q =
               from w in db.WaitingList
               where w.DELETED == false
               where w.Priority == true
               where w.TestSlotID == null // Make sure they haven't been assigned already!
               select new WaitingListReturn
               {
                   WaitingListID = w.WaitingListID,
                   DateRegistered = w.DateRegistered,
                   Priority = w.Priority,
                   TestSlotID = w.TestSlotID,
                   PatientID = w.PatientID
               };

            return q;
        }

        public IEnumerable<WaitingListReturn> ReturnDeletedEntries()
        {
            /// Return Waiting List entries that have been marked as deleted
            var q =
                from w in db.WaitingList
                where w.DELETED == true
                select new WaitingListReturn
                {
                    WaitingListID = w.WaitingListID,
                    DateRegistered = w.DateRegistered,
                    Priority = w.Priority,
                    TestSlotID = w.TestSlotID,
                    PatientID = w.PatientID
                };

            return q;
        }

        public IEnumerable<WaitingListReturn> ReturnAllWaitingListRecords()
        {
            /// Returns all records stored in the WaitingList table regardless of DELETED status
            var q =
                from w in db.WaitingList
                select new WaitingListReturn
                {
                    WaitingListID = w.WaitingListID,
                    DateRegistered = w.DateRegistered,
                    PatientID = w.PatientID,
                    TestSlotID = w.TestSlotID
                };

            return q;
        }
        #endregion

        #region Manipulate
        // MANIPULATE Functionality
        // Functionality required to manipulate database data
        public void NewEntry(WaitingListEntry newWaitingListEntry)
        {
            /// Insert a new Waiting List Entry to the WaitingList table
            /// NOTE - Caller must instantiate a new WaitingListEntry object
            /// BUT does not need to create an ID for it
            newWaitingListEntry.WaitingListID = autoIncrementedID();
            // Mark object for submission
            db.WaitingList.InsertOnSubmit(newWaitingListEntry);
            // Submit object
            db.SubmitChanges();
        }

        public void EditEntry(WaitingListEntry editWaitingListEntry)
        {
            /// Method to edit an existing Waiting List Entry
            /// NOTE - Caller must instantiate a new WaitingListEntry object
            // First find record to be edited using a LINQ query
            var selectedEntry =
                (from w in db.WaitingList
                 where w.DELETED == false
                 where w.WaitingListID == editWaitingListEntry.WaitingListID
                 select w).First();

            // Write changes to selected entry object
            selectedEntry.DateRegistered = editWaitingListEntry.DateRegistered;
            selectedEntry.Priority = editWaitingListEntry.Priority;
            //Submit changes to database
            db.SubmitChanges();
        }

        public void EntryPriority(int waitingListID, Boolean priority)
        {
            /// Assigns or removes priority from entry, by manipulating the "Priority" field according to
            /// caller's input
            // Find entry in question using a LINQ query
            var selectedEntry =
                (from w in db.WaitingList
                 where w.WaitingListID == waitingListID
                 select w).First();

            // Use an if statement to decide whether user has opted to assign or remove priority
            // If user set the method's "priority" boolean argument as true, then entry receives priority
            if (priority == true)
                selectedEntry.Priority = true;
            // If the "priority" boolean is false, entry is unassigned the priority
            else
                selectedEntry.Priority = false;

            db.SubmitChanges();
        }

        public void DeleteEntryMark(int waitingListID)
        {
            /// Mark entry as deleted
            // First, find entry to be deleted using a LINQ query
            var selectedEntry =
                (from w in db.WaitingList
                where w.WaitingListID == waitingListID
                select w).First();
            
            // Change the selected object's DELETED field to true
            selectedEntry.DELETED = true;
            
            // Remove TestSlot mapping
            // Make sure it is removed on both sides
            if (selectedEntry.TestSlotID != null)
            {
                var mappedTestSlot =
                    (from t in db.TestSlots
                     where t.WaitingListID == selectedEntry.WaitingListID
                     select t).First();

                mappedTestSlot.WaitingListID = null;

                selectedEntry.TestSlotID = null;
            }
            // Submit changes to database
            db.SubmitChanges();
        }

        public void DeleteEntryPermanent(int waitingListID)
        {
            /// Permanently delete entry
            /// WARNING - This action will result to a permanent loss of the entry!
            // Find entry to be deleted
            var selectedEntry =
                (from w in db.WaitingList
                 where w.WaitingListID == waitingListID
                 where w.DELETED == true // Make sure it's marked as true to begin with
                 select w).First();

            // Mark object for delete on submission
            db.WaitingList.DeleteOnSubmit(selectedEntry);
            //Submit changes
            db.SubmitChanges();
        }

        public void DeleteAllRecycledEntriesPermanently()
        {
            /// Method to clear all recycled waiting list entries (marked as deleted = true)
            // Find all entries that are marked as deleted
            var recycledEntries =
                from w in db.WaitingList
                where w.DELETED == true
                select w;

            // Iterate through each one and delete it
            foreach (var entry in recycledEntries)
            {
                db.WaitingList.DeleteOnSubmit(entry);
            }
            // Submit changes
            db.SubmitChanges();
        }

        public void ResetWaitingListTable()
        {
            /// WARNING - THIS METHOD WILL PERMANENTLY ERASE ALL DATA IN THE WAITING LIST TABLE!
            // Iterate through each record and delete it
            foreach (var entry in db.WaitingList)
            {
                db.WaitingList.DeleteOnSubmit(entry);
            }
            // Submit changes 
            db.SubmitChanges();
        }

        public void RestoreDeletedEntry(int waitingListID)
        {
            /// Restores Entry previously marked as DELETED = true
            // Find selected entry to be restored
            var selectedEntry =
                (from w in db.WaitingList
                 where w.WaitingListID == waitingListID
                 select w).First();

            // Mark DELETED as false to restore entry
            selectedEntry.DELETED = false;
            //Foreach loops restore mapped appointments and waiting list entries

            // Submit changes to database
            db.SubmitChanges();
        }
        #endregion

        #region Other
        // OTHER Functionality 
        // Autoincrement ID programatically, etc to help with the smooth flow of the application
        // Do not need to be accessed outside this class
        private int autoIncrementedID()
        {
            /// Returns autoincremented ID value to be assigned as new entry's WaitingListID
            // Count all records including those marked as deleted 
            int entryCount = CountAllEntriesPlusDeleted(); 
            // If there are no entries, return the autoID as 1
            if (entryCount == 0)
                return 1;
            // If there are entries in the table, grab the last WaitingListID using the method lastRecordID
            // and increment it by 1
            int autoIncID = lastRecordID() + 1;
            // Return the autoincremented value to the caller
            return autoIncID;
        }

        private int lastRecordID()
        {
            // Method to return the ID of the last record for autoincrementing
            // Locate the last record ID using a linq query
            var lastRecord =
                (from w in db.WaitingList
                 orderby w.WaitingListID descending
                 select w).First();
            int lastID = lastRecord.WaitingListID;
            return lastID;
        }
        #endregion
    }

    class DataMethodsAppointments : DataMethods
    {
        /// This is where all methods relating to the database table "Appointments" are stored
        /// Includes queries and functions to add, remove and edit rows.

        #region Count
        // COUNT Functionality
        // Functionality to count database records for this table
        public int CountAllAppointments()
        {
            /// Function that counts all appointments in the Appointments table, excluding recycled 
            
            // LINQ Query to database
            var q =
                from a in db.Appointments // Set to query the Appointments table
                where a.DELETED == false // Don't include recycled fields
                select a.AppointmentID; // Single field for counting
            int appointmentCount = q.Count(); // Count fields returned by the query

            return appointmentCount; // Return number of appointments to caller
        }

        public int CountAllAppointmentsPlusDeleted()
        {
            /// Function to count all appointment entries, including recycled appointments
            
            // LINQ query to database 
            var q =
                from a in db.Appointments
                select a.AppointmentID; // Select all fields, indiscriminant of recycling status
            int appointmentCount = q.Count(); // Count returned records

            return appointmentCount; // Return to caller
        }
        #endregion

        #region Return
        // RETURN Functionality
        public IEnumerable<AppointmentReturn> ReturnAppointments()
        {
            /// Returns all appointments that have not been marked as deleted
            
            // LINQ Query to database
            var q =
                from a in db.Appointments
                where a.DELETED == false
                select new AppointmentReturn // Enumerate fields to conform to the AppointmentReturn object
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }

        public IEnumerable<AppointmentReturn> ReturnAppointments(int patientID)
        {
            /// Overloaded version of ReturnAppointments returns all the appointments for a single
            /// patient according to his Patient ID
            var selectedPatientAppointments =
                from a in db.Appointments
                where a.DELETED == false
                where a.PatientID == patientID
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return selectedPatientAppointments;
        }

        public IEnumerable<AppointmentReturn> ReturnPSGAppointments()
        {
            /// Returns all appointments that are polysomnography appointments, ie have been assigned a test
            /// slot
            
            // LINQ query to find appointments that have been assigned a test slot
            var q =
                from a in db.Appointments
                where a.DELETED == false // Make sure appointments are not recycled
                where a.TestSlotID != null // Where the testslot is not null, thus assigned
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q; // Return selected records
        }

        public IEnumerable<AppointmentReturn> ReturnPSGAppointments(int patientID)
        {
            /// Overloaded version returns PSG appointments for a single patient according to his ID

            // LINQ query to find appointments that have been assigned a test slot for a certain patient
            var q =
                from a in db.Appointments
                where a.DELETED == false // Make sure appointments are not recycled
                where a.TestSlotID != null // Where the testslot is not null, thus assigned
                where a.PatientID == patientID // Where PatientID matches the ID of the selected patient
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q; // Return selected records
        }

        public IEnumerable<AppointmentReturn> ReturnFollowUpAppointments()
        {
            /// Returns follow up appointments, ie appointments that have not been assigned a test slot
            
            // LINQ query to grab records that match criteria
            var q =
                from a in db.Appointments
                where a.DELETED == false // Make sure they ain't deleted
                where a.TestSlotID == null // TestSlot is null, since it has not been assigned
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q; // Return results of query
        }

        public IEnumerable<AppointmentReturn> ReturnFollowUpAppointments(int patientID)
        {
            /// Overloaded version returns follow-up appointments for a single patient according to the
            /// patient's ID
            // LINQ query to grab records that match criteria
            var q =
                from a in db.Appointments
                where a.PatientID == patientID // Where the PatientID matches that of the selected patient
                where a.DELETED == false // Make sure they ain't deleted
                where a.TestSlotID == null // TestSlot is null, since it has not been assigned
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q; // Return results of query
        }

        public IEnumerable<AppointmentReturn> ReturnUpcomingAppointments()
        {
            /// Returns future appointments

            // LINQ Query to database
            var q =
                from a in db.Appointments
                where a.DELETED == false
                where a.AppointmentDate >= DateTime.Today // Where the date is greater than today's date or today
                select new AppointmentReturn // Enumerate fields to conform to the AppointmentReturn object
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }

        public IEnumerable<AppointmentReturn> ReturnUpcomingAppointments(int patientID)
        {
            /// Returns future appointments, overload returns for a single patient

            // LINQ Query to database
            var q =
                from a in db.Appointments
                where a.PatientID == patientID
                where a.DELETED == false
                where a.AppointmentDate >= DateTime.Today // Where the date is greater than today's date or today
                select new AppointmentReturn // Enumerate fields to conform to the AppointmentReturn object
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }

        public IEnumerable<AppointmentReturn> ReturnPreviousAppointments()
        {
            /// Returns appointments that have passed

            // LINQ Query to database
            var q =
                from a in db.Appointments
                where a.DELETED == false
                where a.AppointmentDate < DateTime.Today // Dates before today
                select new AppointmentReturn // Enumerate fields to conform to the AppointmentReturn object
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }

        public IEnumerable<AppointmentReturn> ReturnPreviousAppointments(int patientID)
        {
            /// Returns appointments that have passed, overload returns for single patient

            // LINQ Query to database
            var q =
                from a in db.Appointments
                where a.DELETED == false
                where a.PatientID == patientID
                where a.AppointmentDate < DateTime.Today // Dates before today
                select new AppointmentReturn // Enumerate fields to conform to the AppointmentReturn object
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    AHI = a.AHI,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }

        public IEnumerable<AppointmentReturn> ReturnDeletedAppointments()
        {
            /// Returns appointments that have been marked as DELETED=true
            
            // LINQ Query to locate these records
            var q =
                from a in db.Appointments
                where a.DELETED == true
                select new AppointmentReturn 
                { //Return only required fields for this purpose
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    PatientID = a.PatientID
                };

            return q; // Return results to caller
        }

        public IEnumerable<AppointmentReturn> ReturnAppointmentsByMonth(int monthNumber)
        {
            /// Returns appointments for a selected month
            // LINQ query finds these appointments
            var q =
                from a in db.Appointments
                where a.DELETED == false
                where a.AppointmentDate.Month == monthNumber
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    Diagnosis = a.Diagnosis,
                    Treatment = a.Treatment,
                    Notes = a.Notes,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }

        public Appointment ReturnSingleAppointment(int appointmentID)
        {
            /// Returns an Appointment object for an appointment of the passed ID
            Appointment selectedAppointment =
                (from a in db.Appointments
                 where a.AppointmentID == appointmentID
                 select a).First();

            return selectedAppointment;
        }

        public Appointment ReturnFirstAppointment(int patientID)
        {
            /// Returns patient's first appointment
            Appointment firstAppointment =
                (from a in db.Appointments
                 where a.DELETED == false //Should not be a deleted field
                 where a.PatientID == patientID
                 orderby a.AppointmentID ascending // Latest in order by date
                 select a).First();

            return firstAppointment;
        }

        public IEnumerable<AppointmentReturn> ReturnAllAppointmentRecords()
        {
            /// Returns all appointment records stored in the Appointments table regardless of DELETED status
            var q =
                from a in db.Appointments
                select new AppointmentReturn
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    PatientID = a.PatientID,
                    TestSlotID = a.TestSlotID
                };

            return q;
        }
        #endregion

        #region Manipulate
        // MANIPULATE Functionality
        public void NewAppointment(Appointment newAppointment)
        {
            /// Instert a new Appointment record in the Appointments table
            /// NOTE - Caller must create a new instance of the Appointment class to pass all required input
            /// parameters, with the exception of AppointmentID which is autoincremented in this class
            // Assign autoincremented ID
            newAppointment.AppointmentID = autoIncrementedID();
            // Mark object for submission
            db.Appointments.InsertOnSubmit(newAppointment);
            // Submit changes
            db.SubmitChanges();
        }

        public void EditAppointment(Appointment editAppointment)
        {
            /// Method to edit an existing Appointment
            /// NOTE - Caller must create a new instance of the Appointment class
            
            // Find record to be edited using a LINQ query
            var selectedAppointment =
                (from a in db.Appointments
                 where a.DELETED == false
                 where a.AppointmentID == editAppointment.AppointmentID
                 select a).First();

            // Write changes to selected Appointment object
            selectedAppointment.AppointmentDate = editAppointment.AppointmentDate;
            selectedAppointment.Diagnosis = editAppointment.Diagnosis;
            selectedAppointment.AHI = editAppointment.AHI;
            selectedAppointment.Treatment = editAppointment.Treatment;
            selectedAppointment.Notes = editAppointment.Notes;
            // Submit changes
            db.SubmitChanges();
        }

        public void DeleteAppointmentMark(int appointmentID)
        {
            /// Mark appointment as deleted
            // Find appointment to be deleted using a LINQ query
            var selectedAppointment =
                (from a in db.Appointments
                 where a.AppointmentID == appointmentID
                 select a).First();
            // Change selected object's DELETED to true
            selectedAppointment.DELETED = true;
            // Remove test slot mapping
            // Remove the mapping from the other side as well before setting it to null on this side
            if (selectedAppointment.TestSlotID != null)
            {
                var mappedTestSlot =
                    (from t in db.TestSlots
                     where t.AppointmentID == appointmentID
                     select t).First();
                mappedTestSlot.AppointmentID = null;
                selectedAppointment.TestSlotID = null;
            }
            // Submit changes to database
            db.SubmitChanges();
        }

        public void DeleteAppointmentPermanent(int appointmentID)
        {
            /// Permanently delete appointment
            /// WARNING - This action will result to a permanent loss of the appointment record!
            // LINQ query to find appointment to be deleted
            var selectedAppointment =
                (from a in db.Appointments
                 where a.AppointmentID == appointmentID
                 where a.DELETED == true // Make sure it's been marked for deletion
                 select a).First();

            // Mark object for delete on submit
            db.Appointments.DeleteOnSubmit(selectedAppointment);
            // Submit changes
            db.SubmitChanges();
        }

        public void DeleteAllRecycledAppointmentsPermanently()
        {
            /// Method to clear all recycled appointments
            // First find all appointments marked as recycled
            var recycledAppointments =
                from a in db.Appointments
                where a.DELETED == true
                select a;

            // Iterate through these appointments and delete them
            foreach (var appointment in recycledAppointments)
            {
                db.Appointments.DeleteOnSubmit(appointment);
            }
            // Submit changes
            db.SubmitChanges();
        }

        public void ResetAppointmentsTable()
        {
            /// WARNING - THIS METHOD WILL DELETE ALL APPOINTMENTS IN THE APPOINTMENT TABLE!
            foreach (var appointment in db.Appointments)
            {
                db.Appointments.DeleteOnSubmit(appointment);
            }
            // Submit changes to database
            db.SubmitChanges();
        }

        public void RestoreDeletedAppointment(int appointmentID)
        {
            /// Restores appointment previously marked as DELETED = true
            // Find appointment to be restored using a LINQ query
            var selectedAppointment =
                (from a in db.Appointments
                 where a.AppointmentID == appointmentID
                 select a).First();

            // Restore appointment by marking DELETED as false
            selectedAppointment.DELETED = false;
            // Submit changes
            db.SubmitChanges();
        }
        #endregion

        #region Other
        // OTHER Functionality
        // Autoincrementing ID, etc
        private int autoIncrementedID()
        {
            /// Returns autoincremented ID value to be assigned to a new appointment record as AppointmentID
            // First count all records, including those marked as recycled
            int appointmentCount = CountAllAppointmentsPlusDeleted();
            // If no entries, assign ID as 1
            if (appointmentCount == 0)
                return 1;
            // If there are entries in the table, grab the last record's AppointmentID
            int autoIncID = lastRecordID() + 1;
            // Return incremented value to caller
            return autoIncID;
        }

        private int lastRecordID()
        {
            /// Returns last record's AppointmentID
            // Locate the last Appointment record using a linq query
            var lastRecord =
                (from a in db.Appointments
                 orderby a.AppointmentID descending
                 select a).First();
            int lastID = lastRecord.AppointmentID; // Grab last record's AppointmentID
            return lastID; // return the value of the last record's ID
        }
        #endregion
    }

    class DataMethodsTestSlots : DataMethods
    {
        /// This is where all the methods relating to the database table "TestSlots" are stored
        /// Includes queries and functions to add, remove and edit rows

        #region Count
        // COUNT Functionality
        public int CountAllSlots()
        {
            /// Function that counts all test slot entries in the TestSlots table
            /// Excludes recycled
            // LINQ Query to database
            var q = // Query variable
                from t in db.TestSlots // Select TestSlots table to query
                where t.DELETED == false // Not deleted/recycled
                select t.TestSlotID; // Single field for counting
            
            // Count returned fields using .NET's count function
            int slotCount = q.Count();

            // Return number of test slots to caller
            return slotCount;
        }

        public int CountAllSlotsPlusDeleted()
        {
            /// Function to count all slots in TestSlots table
            /// Includes recycled
            
            // LINQ query to database
            var q =
                from t in db.TestSlots
                select t.TestSlotID; // No criteria, just return everything
            
            // Count selected fields
            int slotCount = q.Count();

            return slotCount; // Return value to caller
        }
        #endregion

        #region Return
        // RETURN Functionality
        public TestSlot ReturnSlot(int testSlotID)
        {
            TestSlot selectedSlot =
                (from t in db.TestSlots
                 where t.TestSlotID == testSlotID
                 select t).First();
            return selectedSlot;
        }

        public IEnumerable<TestSlotReturn> ReturnSlots()
        {
            /// Returns all test slots that have not been marked as deleted
            var q =
                from t in db.TestSlots
                where t.DELETED == false
                select new TestSlotReturn // Enumerate to TestSlotReturn object for returning
                {
                    TestSlotID = t.TestSlotID,
                    TestDate = t.TestDate,
                    PSGReportPath = t.PSGReportPath,
                    DoctorReportPath = t.DoctorReportPath,
                    Appointment = t.Appointment,
                    WaitingListEntry = t.WaitingListEntry
                };

            return q; // Return query results
        }

        public IEnumerable<TestSlotReturn> ReturnAssignedSlots()
        {
            /// Return test slots that have been assigned to an appointment and waiting list entry

            var q =
                from t in db.TestSlots
                where t.DELETED == false
                where t.AppointmentID != null
                // where t.WaitingListID != null //TODO - consider revision
                select new TestSlotReturn
                {
                    TestSlotID = t.TestSlotID,
                    TestDate = t.TestDate,
                    PSGReportPath = t.PSGReportPath,
                    DoctorReportPath = t.DoctorReportPath,
                    Appointment = t.Appointment,
                    WaitingListEntry = t.WaitingListEntry
                };

            // Return results to caller
            return q;
        }

        public IEnumerable<TestSlotReturn> ReturnAvailableSlots()
        {
            /// Returns test slots that are yet to be assigned to an appointment, thus available
            var q =
                from t in db.TestSlots
                where t.DELETED == false
                where t.AppointmentID == null
                where t.WaitingListID == null
                where t.TestDate >= DateTime.Today // Make sure no past slots show up
                select new TestSlotReturn
                {
                    TestSlotID = t.TestSlotID,
                    TestDate = t.TestDate,
                    PSGReportPath = t.PSGReportPath,
                    DoctorReportPath = t.DoctorReportPath,
                    Appointment = t.Appointment,
                    WaitingListEntry = t.WaitingListEntry
                };

            // Return results to caller
            return q;
        }

        public IEnumerable<TestSlotReturn> ReturnDeletedSlots()
        {
            /// Return test slots that have been marked as DELETED
            var q =
                from t in db.TestSlots
                where t.DELETED == true
                select new TestSlotReturn
                {
                    TestSlotID = t.TestSlotID,
                    TestDate = t.TestDate,
                    PSGReportPath = t.PSGReportPath,
                    DoctorReportPath = t.DoctorReportPath
                };
            // Return query results to caller
            return q;
        }

        public TestSlot ReturnSelectedTestSlot(int testSlotID)
        {
            /// Method to return a single test slot according to TestSlotID
            TestSlot selectedTestSlot =
                (from t in db.TestSlots
                 where t.TestSlotID == testSlotID
                 select t).First();

            return selectedTestSlot;
        }

        public IEnumerable<TestSlotReturn> ReturnAllTestSlotRecords()
        {
            /// Returns all test slot records from the TestSlots table regardles of DELETED status
            var q =
                from t in db.TestSlots
                select new TestSlotReturn
                {
                    TestSlotID = t.TestSlotID,
                    TestDate = t.TestDate,
                    DoctorReportPath = t.DoctorReportPath,
                    PSGReportPath = t.PSGReportPath
                };

            return q;
        }
        #endregion

        #region Manipulate
        // MANIPULATE Functionality
        public void NewSlot(TestSlot newTestSlot)
        {
            /// Insert a new test slot in the TestSlot table
            /// NOTE - Caller must instantiate a new TestSlot object
            /// BUT does not need to assign as ID, as it will be automatically generated
            newTestSlot.TestSlotID = autoIncrementedID();
            // Mark for insertion
            db.TestSlots.InsertOnSubmit(newTestSlot);
            // Submit object
            db.SubmitChanges();
        }

        public void EditSlot(TestSlot editTestSlot)
        {
            /// Edits an existing test slot
            /// NOTE - Caller must instantiate a new TestSlot object
            
            // Find record to be edited
            var selectedSlot =
                (from t in db.TestSlots
                 where t.TestSlotID == editTestSlot.TestSlotID
                 where t.DELETED == false
                 select t).First();

            // Write changes to selected slot
            selectedSlot.TestDate = editTestSlot.TestDate;
            selectedSlot.PSGReportPath = editTestSlot.PSGReportPath;
            selectedSlot.DoctorReportPath = editTestSlot.DoctorReportPath;
            selectedSlot.AppointmentID = editTestSlot.AppointmentID;
            selectedSlot.WaitingListID = editTestSlot.WaitingListID;
            // Submit changes
            db.SubmitChanges();
        }

        public void DeleteSlotMark(int slotID)
        {
            /// Mark test slot as deleted/recycled
            // Find slot to be deleted
            var selectedSlot =
                (from t in db.TestSlots
                 where t.TestSlotID == slotID
                 select t).First();

            // Change DELETED field to true
            selectedSlot.DELETED = true;
            // Remove Appointment if one is created for this test slot
            if (selectedSlot.AppointmentID != null)
            {
                var mappedAppointment =
                    (from a in db.Appointments
                     where a.AppointmentID == selectedSlot.AppointmentID
                     select a).First();

                mappedAppointment.DELETED = true;
            }
            // Also remove WaitingListEntry mapping
            if (selectedSlot.WaitingListID != null)
            {
                var mappedWaitingListEntry =
                    (from w in db.WaitingList
                     where w.WaitingListID == selectedSlot.WaitingListID
                     select w).First();

                mappedWaitingListEntry.TestSlotID = null;

                selectedSlot.WaitingListID = null;
            }
            // Submit changes
            db.SubmitChanges();
        }

        public void DeleteSlotPermanent(int slotID)
        {
            /// Permanently delete slot
            /// WARNING - This will result to permanent loss of data!
            // Find slot to be deleted
            var selectedSlot =
                (from t in db.TestSlots
                 where t.TestSlotID == slotID
                 where t.DELETED == true // make sure its deleted
                 select t).First();

            // Mark for delete on submission
            db.TestSlots.DeleteOnSubmit(selectedSlot);
            // Submit changes 
            db.SubmitChanges();
        }

        public void DeleteAllRecycledSlots()
        {
            /// Method to delete all recycled test slots
            // First find them all
            var recycledSlots =
                from t in db.TestSlots
                where t.DELETED == true
                select t;

            // Iterate through each one and delete it
            foreach (var slot in recycledSlots)
            {
                db.TestSlots.DeleteOnSubmit(slot);
            }
            // Submit changes
            db.SubmitChanges();
        }

        public void ResetTestSlotsTable()
        {
            /// WARNING - THIS METHOD WILL DELETE ALL RECORDS IN THE TEST SLOTS TABLE
            foreach (var slot in db.TestSlots)
            {
                db.TestSlots.DeleteOnSubmit(slot);
            }
            // Submit changes to database 
            db.SubmitChanges();
        }

        public void RestoreDeletedSlot(int slotID)
        {
            /// Restores slot previously marked as DELETED = true
            // Find slot to be restored
            var selectedSlot =
                (from t in db.TestSlots
                 where t.TestSlotID == slotID
                 select t).First();

            // Mark DELETED = false to restore slot
            selectedSlot.DELETED = false;
            // Submit changes
            db.SubmitChanges();
        }
        #endregion

        #region Other
        // OTHER Functionality
        private int lastSlotID()
        {
            // Returns the ID of the last record, used for autoincrementing
            // LINQ query to find last slot's ID
            var lastSlot =
                (from t in db.TestSlots
                 orderby t.TestSlotID descending
                 select t).First();
            int lastID = lastSlot.TestSlotID;
            return lastID;
        }

        private int autoIncrementedID()
        {
            /// Returns auto incremended ID value to be assigned as new entry's TestSlotID
            // First count all records, including those marked as deleted
            int slotCount = CountAllSlotsPlusDeleted();
            // If there are no slots in the table, the ID should be 1
            if (slotCount == 0)
                return 1;
            // If there are slots, autoincrement last slot's ID by 1
            int autoIncID = lastSlotID() + 1;
            // Return auto incremented value
            return autoIncID;
        }
        #endregion
    }
}
