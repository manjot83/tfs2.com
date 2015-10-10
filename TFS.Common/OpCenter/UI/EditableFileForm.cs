﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using NHibernate.Criterion;
using org.apache.avalon.framework;
using TFS.OpCenter.Data;
using TFS.OpCenter.Forms;
using System.ComponentModel;
using System.Web.UI;

namespace TFS.OpCenter.UI
{
    public class EditableFileForm : CompositeControl
    {
        /// <summary>
        /// Fires when field values have been changed
        /// </summary>
        private event EventHandler FieldValuesChanged;
        /// <summary>
        /// The cancel button was pressed and field values have been reset to their original values
        /// </summary>
        public event EventHandler CancelButtonPressed;
        /// <summary>
        /// The save button was pressed and field values have been saved.
        /// </summary>
        public event EventHandler SaveButtonPressed;
        /// <summary>
        /// The save button was pressed and field values have been saved.
        /// </summary>
        public event EventHandler DeleteButtonPressed;

		#region Public Properties 

        /// <summary>
        /// The form to bind to
        /// </summary>
        [Bindable(true, BindingDirection.OneWay)]
        public EditableFile EditableForm
        {
            get
            {
                object o = this.Page.Session[this.UniqueID + "EditableForm"];
                return o as EditableFile;
            }
            set
            {
                this.Page.Session[this.UniqueID + "EditableForm"] = value;
            }
        }

		#endregion Public Properties 

		#region Private Methods 

        private void FieldFormValueChanged(object sender, EventArgs e)
        {
            if (this.FieldValuesChanged != null)
                this.FieldValuesChanged(this, e);
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            foreach (EditableField field in this.EditableForm.Fields)
            {
                field.Reset();
            }


            /// Recreate all the child controls.
            this.CreateChildControls();

            if (this.CancelButtonPressed != null)
                this.CancelButtonPressed(this, EventArgs.Empty);
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            //var allFields = new FormfieldCollection().Where(Formfield.Columns.Formid, this.EditableForm.FormFile.Formid).Load();
            var catController = new ArticlecategoryController();
            var category = catController.FetchAll().SingleOrDefault(item => item.Name.ToLower() == "general");
            var categoryId = 5; //general category id;
            string subject = null;
            string content = null;

            if (category != null)
            {
                categoryId = category.Id;
            }

          //(DateTime Createdon, string personName, int Categoryid, string Subject, string Content, bool Isurgent)
            foreach (EditableField field in this.EditableForm.Fields)
            {
                //var fieldInfo = allFields.SingleOrDefault(item => item.Id == field.FormField.Id)

                //if(fieldInfo != null)
                //{
                //    switch fieldInfo.Name
                //}

                switch(field.FormField.Name.ToLower())
                {
                    case "subject":
                        subject = field.TextValue;
                        break;
                    case "narrative":
                        content = field.TextValue;
                        break;
                    default:
                        break;
                }

                field.Store();
            }

            if (subject != null && content != null)
            {
                var newPostController = new NewspostController();
                newPostController.Insert(DateTime.Now, HttpContext.Current.User.Identity.Name, categoryId, subject, content, true);
            }

            if (this.SaveButtonPressed != null)
                this.SaveButtonPressed(this, EventArgs.Empty);
        }

		#endregion Private Methods 

		#region Protected Methods 

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            ///Setup the field controls
            int count = 0;
            foreach (EditableField field in this.EditableForm.Fields)
            {
                ///wrap each field in a DIV
                this.Controls.Add(new LiteralControl("<div>"));

                EditableFileFormField fieldControl = new EditableFileFormField();
                fieldControl.ID = "Field" + count++;
                this.Controls.Add(fieldControl);
                fieldControl.EditableField = field;
                fieldControl.FormValueChanged += new EventHandler(FieldFormValueChanged);
         
                //end the div
                this.Controls.Add(new LiteralControl("</div>"));
            }


            ///put some space in between
            this.Controls.Add(new LiteralControl("<br />"));

            ///break between the fields and buttons
            this.Controls.Add(new LiteralControl("<div>"));

            //save and cancel buttons
            Button saveButton = new Button();
            saveButton.ID = "SaveButton";
            saveButton.Text = "Save Changes";
            saveButton.ToolTip = "Save your changes";
            saveButton.Attributes.Add("onclick", "return confirm('Are you sure you want to save your changes?')");
            saveButton.Click += new EventHandler(HandleSaveButtonClick);
            this.Controls.Add(saveButton);

            Button cancelButton = new Button();
            cancelButton.ID = "CancelButton";
            cancelButton.Text = "Cancel Changes";
            cancelButton.Attributes.Add("onclick", "return confirm('Are you sure you want to cancel your changes?')");
            cancelButton.ToolTip = "Cancel and changes you made since the last save";
            cancelButton.Click += new EventHandler(HandleCancelButtonClick);
            this.Controls.Add(cancelButton);

            Button deleteButton = new Button();
            deleteButton.ID = "DeleteButton";
            deleteButton.Text = "Delete File";
            deleteButton.ToolTip = "Delete this file";
            deleteButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this file?')");
            deleteButton.Click += new EventHandler(HandleDeleteButtonClicked);
            this.Controls.Add(deleteButton);

            //end the div
            this.Controls.Add(new LiteralControl("</div>"));

            base.CreateChildControls();
        }

        private void HandleDeleteButtonClicked(object sender, EventArgs e)
        {
            // Delete the file. But don't destroy it.
            this.EditableForm.DeleteFile(false);

            if (this.DeleteButtonPressed != null)
            {
                //end process, let control owner handle next action - Brian Ogden - 10-9-2015
                this.DeleteButtonPressed(this, EventArgs.Empty);
                return;
            }

            //crappy redirect to page the does not logically apply to all Web Forms 
            //that are using EditableFileForm custom control - Brian Ogden - 10-9-2015
            // Redirect back to the form admin page
            this.Page.Response.Redirect("~/Forms/Admin.aspx");
        }

		#endregion Protected Methods 

    }
}
