using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;
using System.DirectoryServices;

namespace TFS.OpCenter.People
{
    public class SyncEnabledPerson
    {

        /// <summary>
        /// Creates a SyncEnabledPerson using the active directory DirectoryEntry object
        /// </summary>
        internal SyncEnabledPerson(DirectoryEntry directoryEntry)
        {
            this.directoryEntry = directoryEntry;

            ///Extract information from the directory entry
            this.EncapsulateDirectoryEntry();
            ///Attempt to encapsulate a person database entity
            this.EncapsulateDatabaseEntity();
        }

        private DirectoryEntry directoryEntry;

        /// <summary>
        /// Helper method to extra property information from the DirectoryEntry object.
        /// </summary>
        private void EncapsulateDirectoryEntry()
        {
            this.Username = this.directoryEntry.Properties["sAMAccountName"].Value.ToString();
        }

        /// <summary>
        /// Attempts to encapsulate a Database Person entity object based on information from the DirectoryEntry
        /// </summary>
        private void EncapsulateDatabaseEntity()
        {
            Person person = Person.FetchByUsername(this.Username);
            if (!person.IsNew)
                this.EncapsulatedPerson = person;
        }

        /// <summary>
        /// This person has an entity in the database, via the data access layer.
        /// </summary>
        public bool HasDatabaseEntity
        {
            get
            {
                return this.EncapsulatedPerson != null;
            }
        }

        /// <summary>
        /// The encapsulated Person from the Data Access Layer.
        /// </summary>
        public Person EncapsulatedPerson { get; private set; }

        /// <summary>
        /// Gets the Username of the person.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the display name of the person.
        /// </summary>
        public string DisplayName
        {
            get
            {
                return this.directoryEntry.Properties["displayName"].Value.ToString();
            }
        }

        /// <summary>
        /// Gets the E-mail address of the person.
        /// </summary>
        public string Email
        {
            get
            {
                return this.directoryEntry.Properties["mail"].Value.ToString();
            }
        }

        /// <summary>
        /// Gets the first name (given name) of the person.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.directoryEntry.Properties["givenName"].Value.ToString();
            }
        }

        /// <summary>
        /// Gets the last name (surname) of the person.
        /// </summary>
        public string LastName
        {
            get
            {
                return this.directoryEntry.Properties["sn"].Value.ToString();
            }
        }

        /// <summary>
        /// Gets the Title of the person.
        /// </summary>
        public string Title
        {
            get
            {
                return this.directoryEntry.Properties["title"].Value.ToString();
            }
        }
        
        /// <summary>
        /// Syncs the Directory Entry represented by this person to the database.
        /// </summary>
        /// <remarks>
        /// It will create a new record if necessary, or update the existing one.
        /// </remarks>
        public void SyncToDatabase()
        {
            Person person = null;
            if (this.HasDatabaseEntity)
            {
                ///Use the existing person.
                person = this.EncapsulatedPerson;
            }
            else
            {
                ///Create a new person object
                person = new Person(true);
                person.Username = this.Username;
            }

            person.Displayname = this.DisplayName;
            person.Firstname = this.FirstName;
            person.Lastname = this.LastName;
            person.Email = this.Email;
            person.Deleted = false;

            person.Save(Utility.GetActiveUsername());
        }

    }
}
