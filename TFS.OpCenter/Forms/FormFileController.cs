using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms.UI
{
    /// <summary>
    /// UI controller for viewing and editing a form file. It is light and designed for disconnected applications if necessary
    /// </summary>
    public class FormFileController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortName">The short name for the form that will be loaded.</param>
        public FormFileController(string shortName)
            : this(Form.FetchByShortName(shortName))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId">The ID of a form that files will be loaded for.</param>
        public FormFileController(int formId)
            :this(Form.FetchByID(formId))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form">The particular form that files will be loaded for.</param>
        public FormFileController(Form form)
        {
            this.Form = form;
            this.FileLoaded = false; //default state
        }


        /// <summary>
        /// The Form from which files will be created and loaded.
        /// </summary>
        public Form Form { get; private set; }

        /// <summary>
        /// Loads the file for the active user into memory.
        /// </summary>
        public void LoadFileForActiveUser()
        {
            this.LoadFile(Utility.GetActivePerson());
        }

        /// <summary>
        /// Loads a particular file for this form by it's ID
        /// </summary>
        /// <param name="id"></param>
        public void LoadFile(int id)
        {
            this.file = Formfile.FetchByID(id);            
            if (this.file.IsNew)
                this.file = null;
            if (this.file.Formid != this.Form.Id)
                this.file = null;
            if (this.file != null)
                this.FileLoaded = true;
        }

        /// <summary>
        /// Loads the file for the specified person
        /// </summary>
        public void LoadFile(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            FormfileCollection candidateFiles = person.Formfiles().Where(Formfile.Columns.Formid, this.Form.Id);
            if (candidateFiles.Count > 0)
                this.file = candidateFiles[0];
            if (this.file != null)
                this.FileLoaded = true;
        }

        /// <summary>
        /// Loads the file for the specified user
        /// </summary>
        public void LoadFile(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");
            this.LoadFile(Person.FetchByUsername(username));
        }

        /// <summary>
        /// The specified person has a file for this form
        /// </summary>
        public bool HasFile(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            FormfileCollection candidateFiles = person.Formfiles().Where(Formfile.Columns.Formid, this.Form.Id);
            if (candidateFiles.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// The specified username has a file for this form
        /// </summary>
        public bool HasFile(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");
            return this.HasFile(Person.FetchByUsername(username));
        }

        
        /// <summary>
        /// Creates a file record for the specified username.
        /// </summary>
        public Formfile CreateFile(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");
            return this.CreateFile(Person.FetchByUsername(username));
        }

        /// <summary>
        /// Creates a file record for the specified person.
        /// </summary>
        public Formfile CreateFile(Person person)
        {
            if (this.HasFile(person))
                throw new NotSupportedException("A file already exists for the person");
            Formfile file = new Formfile();
            file.Form = this.Form;
            file.Person = person;
            file.Save(Utility.GetActiveUsername());
            this.LoadFile(file.Id);
            return file;
        }

        /// <summary>
        /// Creates a new file frecords for this form without a specified person.
        /// </summary>
        public Formfile CreateFile()
        {
            Formfile file = new Formfile();
            file.Form = this.Form;
            file.Save(Utility.GetActiveUsername());
            this.LoadFile(file.Id);
            return file;
        }

        /// <summary>
        /// The file for this view has been loaded
        /// </summary>
        public bool FileLoaded { get; private set; }

        private Formfile file;

        /// <summary>
        /// The File associated with this form.
        /// </summary>
        public Formfile File
        {
            get { return this.file; }
        }

        private EditableFile editableForm;

        /// <summary>
        /// Instance of an editable form for the loaded file
        /// </summary>
        public EditableFile EditableForm
        {
            get
            {
                if (this.editableForm == null)
                {
                    if (!this.FileLoaded)
                        throw new NotSupportedException("Cannot create an editable form without a loaded file");
                    this.editableForm = new EditableFile(this.File);
                }
                return this.editableForm;
            }
        }

        private FormrecordCollection formRecords;

        /// <summary>
        /// All of the current records on the active file
        /// </summary>
        public FormrecordCollection FormRecords
        {
            get
            {
                if (formRecords != null)
                    return formRecords;
                if (this.file == null)
                    return null;
                this.formRecords = this.file.Formrecords();
                return this.formRecords;
            }
        }

        /// <summary>
        /// Number of records for this file
        /// </summary>
        public int RecordCount
        {
            get
            {
                return this.FormRecords.Count;
            }
        }

    }
}
