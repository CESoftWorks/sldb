using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping; // For LINQtoSQL classes mapping to entities

namespace Sleep_Laboratory_DataBase
{
    /// <summary>
    /// This file stores all LINQ-related object classes to connect and manipulate the SQL Server file
    /// All of these classes have been created by the developer without the use of an O/R designer.
    /// By doing this, developing the application becomes a better learning experience, and it's also
    /// more of a challenge. Also, "easy" usually translates to "disfuctional code that will give
    /// me all sorts of exceptions I'll have to fix later using really inefficient methods and it'll 
    /// end up being more difficult than coding the LINQ classes myself," so this was thought to be 
    /// a more appropriate approach.
    /// </summary>

    public partial class dbSLDatabase : DataContext // Class inherits from the DataContext class
    {
        // Custom DataContext class for database connection.
        // The DataContext class is the main entry point for the LINQtoSQL framework
        // It maps all the entities that are included in the database connection
        // Creating a custom DataContext class provides more control over the database connection
        // LINQtoSQL classes are found below this class.

        // Entities are declared below
        public Table<Appointment> Appointments;
        public Table<Patient> Patients;
        public Table<TestSlot> TestSlots;
        public Table<WaitingListEntry> WaitingList;

        // Database DataContext connection 
        public dbSLDatabase(string connection) : base(connection) { }
    }

    // All LINQtoSQL entity classes are declared below and are mapped to Database entities

    [Table(Name = "Appointments")] // Mapping for Appointments table
    public class Appointment
    {
        // LINQ to Object class
        // Entity is imported as object. Each record is a new instance of this object
        [Column(IsPrimaryKey = true)] // This column is Primary Key
        public int AppointmentID { get; set; } // Each field is declared as a property
        [Column]
        public DateTime AppointmentDate { get; set; }
        [Column]
        public string Diagnosis { get; set; }
        [Column]
        public int AHI { get; set; }
        [Column]
        public string Treatment { get; set; }
        [Column]
        public string Notes { get; set; }
        [Column] // Recycle bin field
        public Boolean DELETED { get; set; } // There should be an explanation somewhere
        // Relationship fields
        [Column]
        public int PatientID { get; set; }
        [Column]
        public int? TestSlotID { get; set; } // int? notation means that the field is nullable, ie it can be null
                                                    // This is useful as this field is not assigned when a new record/
                                                    // object is created
        // LINQ-defined relationships
        // Relationship with Patients --> Many to One (Many appointments for one patient)
        private EntityRef<Patient> _Patient;
        [Association(Storage = "_Patient", ThisKey = "PatientID")]
        public Patient Patient
        {
            get { return this._Patient.Entity; }
            set { this._Patient.Entity = value; }
        }

        // Relationship with TestSlots --> One to One or Zero (An appointment may or may not be assigned to
        // a test slot
        private EntitySet<TestSlot> _TestSlot = new EntitySet<TestSlot>();
        [Association(Storage="_TestSlot", OtherKey="AppointmentID", ThisKey="TestSlotID")]
        public EntitySet<TestSlot> TestSlot
        {
            get { return this._TestSlot; }
            set {this._TestSlot.Assign(value); } 
        }
    }
    //TODO - Fix Return object for AppointmentReturn
    public class AppointmentReturn // Return object for Appointment records
    {
        // Appointment details to return to Datagrid
        // Fields match those of the table, excluding recycle bin field
        // This is done to provide further control to returned data
        // for datagrid input.
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Diagnosis { get; set; }
        public int AHI { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }

        // Relationship fields
        public int? PatientID { get; set; } // Type int? means that the integer value is nullable, ie can be null
        public int? TestSlotID { get; set; }    // This is useful as these records are not immedietly assigned when
        public EntitySet<TestSlot> TestSlot { get; set; } // the object is created
    }

    [Table(Name = "Patients")] // Mapping for Patients table
    public class Patient
    {
        // LINQ to Object class
        // Patients entity is imported as an object, each instance of which represents a record
        [Column(IsPrimaryKey = true)]
        public int PatientID { get; set; }
        [Column]
        public string Name { get; set; } // varchar is imported as string
        [Column]
        public string Surname { get; set; }
        [Column]
        public char Sex { get; set; }
        [Column]
        public DateTime DateOfBirth { get; set; }
        [Column]
        public string PhoneNumber { get; set; }
        [Column]
        public double Height { get; set; }
        [Column]
        public double Weight { get; set; }
        [Column]
        public double BMI { get; set; }
        [Column]
        public int EpsworthScale { get; set; }
        [Column]
        public string BriefAssessment { get; set; }
        [Column] // Recycle bin field
        public Boolean DELETED { get; set; }

        // LINQ-defined relationships
       
        // Relationship with WaitingList --> One to Many (Many waitiling list entries for a patient)
        private EntitySet<WaitingListEntry> _WaitingListEntries = new EntitySet<WaitingListEntry>();
        [Association(Storage = "_WaitingListEntries", OtherKey = "PatientID")]
        public EntitySet<WaitingListEntry> WaitingListEntries
        {
            get { return this._WaitingListEntries; }
            set { this._WaitingListEntries.Assign(value); }
        }

        // Relationship with Appointments --> One to Many (Many appointments for a patient)
        private EntitySet<Appointment> _Appointments = new EntitySet<Appointment>();
        public EntitySet<Appointment> Appointments
        {
            get { return this._Appointments; }
            set { this._Appointments.Assign(value); }
        }
    }

    public class PatientReturn // Return object for Patient records
    {
        // Patient details to return to Datagrid
        // Fields match those of the table, excluding recycle bin field
        // This is done to provide further control to returned data
        // for datagrid input.
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public char Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        public int EpsworthScale { get; set; }
        public string BriefAssessment { get; set; }

        // Relationship objects
        public EntitySet<Appointment> Appointments { get; set; }
        public EntitySet<WaitingListEntry> WaitingListEntries { get; set; }
    }

    [Table(Name = "TestSlots")] // Mapping for TestSlots table
    public class TestSlot
    {
        // LINQ to Object class
        // TestSlots entity is imported as an object, each instance of which represents a test slot
        [Column(IsPrimaryKey = true)]
        public int TestSlotID { get; set; }
        [Column]
        public DateTime TestDate { get; set; }
        [Column]
        public string PSGReportPath { get; set; }
        [Column]
        public string DoctorReportPath { get; set; }
        [Column] // Recycle bin field
        public Boolean DELETED { get; set; }
        [Column]
        public int? AppointmentID { get; set; } // Use of ? allows null
        [Column]
        public int? WaitingListID { get; set; }
        
        // LINQ-defined relationships
        // Relationship with Appointments --> One to One (One test slot to one appointment)
        private EntitySet<Appointment> _Appointment = new EntitySet<Appointment>();
        [Association(Storage = "_Appointment", OtherKey = "TestSlotID", ThisKey = "AppointmentID")]
        public EntitySet<Appointment> Appointment
        {
            get { return this._Appointment; }
            set { this._Appointment.Assign(value); }
        }

        // Relationship with WaitingList --> One to One (One test slot to one waiting list entry)
        private EntitySet<WaitingListEntry> _WaitingListEntry = new EntitySet<WaitingListEntry>();
        [Association(Storage = "_WaitingListEntry", OtherKey = "TestSlotID", ThisKey = "WaitingListID")]
        public EntitySet<WaitingListEntry> WaitingListEntry
        {
            get { return this._WaitingListEntry; }
            set { this._WaitingListEntry.Assign(value); }
        }
    }

    public class TestSlotReturn //Return object for TestSlot records
    {
        // Patient details to return to Datagrid
        // Fields match those of the table, excluding recycle bin field
        // This is done to provide further control to returned data
        // for datagrid input.
        public int TestSlotID { get; set; }
        public DateTime TestDate { get; set; }
        public string PSGReportPath { get; set; }
        public string DoctorReportPath { get; set; }

        // Relationship fields
        public EntitySet<WaitingListEntry> WaitingListEntry { get; set; }
        public EntitySet<Appointment> Appointment { get; set; }
    }

    [Table(Name = "WaitingList")] // Mapping for WaitingList table
    public class WaitingListEntry
    {
        // LINQ to Object class
        // WaitingList entity is imported as an object, each instance of which represents an entry
        [Column(IsPrimaryKey = true)]
        public int WaitingListID { get; set; }
        [Column]
        public DateTime DateRegistered { get; set; }
        [Column]
        public Boolean Priority { get; set; }
        [Column] // Recycle bin field
        public Boolean DELETED { get; set; }
        [Column]
        public int PatientID { get; set; }
        [Column]
        public int? TestSlotID { get; set; }

        // LINQ-defined relationships
        // Relationship with Patients --> Many to One (Many entries to one patient)
        private EntityRef<Patient> _Patient;
        [Association(Storage = "_Patient", ThisKey = "PatientID")]
        public Patient Patient
        {
            get { return this._Patient.Entity; }
            set { this._Patient.Entity = value; }
        }

        // Relationship with TestSlots --> One to One or Zero (A waiting list entry may be assigned a test slot
        // If not immedietly, it will be assigned one at a later stage (as is the app's data flow)
        private EntitySet<TestSlot> _TestSlot = new EntitySet<TestSlot>();
        [Association(Storage = "_TestSlot", OtherKey = "WaitingListID", ThisKey = "TestSlotID")]
        public EntitySet<TestSlot> TestSlot
        {
            get { return this._TestSlot; }
            set { this._TestSlot.Assign(value); }
        }
    }

    public class WaitingListReturn // Return object for WaitingList records
    {
        // Patient details to return to Datagrid
        // Fields match those of the table, excluding recycle bin field
        // This is done to provide further control to returned data
        // for datagrid input.
        public int WaitingListID { get; set; }
        public DateTime DateRegistered { get; set; }
        public Boolean Priority { get; set; }
        public int PatientID { get; set; }
        public int? TestSlotID { get; set; }
        
        // Relationship objects
        public Patient Patient { get; set; }
        public EntitySet<TestSlot> TestSlot { get; set; }
    }
}