using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

using TFS.OpCenter.Data;
using TFS.OpCenter.Forms;
using AjaxControlToolkit;

namespace TFS.OpCenter.UI
{
    internal class EditableFileFormField : CompositeControl,  IPostBackDataHandler
    {

		#region Constructors 

        public EditableFileFormField()
            : base()
        {

        }

		#endregion Constructors 

		#region Public Properties 

        /// <summary>
        /// The field to bind to
        /// </summary>
        [Bindable(true, BindingDirection.OneWay)]
        public EditableField EditableField
        {
            get
            {
                object o = HttpContext.Current.Session[this.UniqueID + "EditableField"];
                return o as EditableField;
            }
            set
            {
                HttpContext.Current.Session[this.UniqueID + "EditableField"] = value;
                this.OnEditableFieldSet();
            }
        }

        /// <summary>
        /// Called when the EditableField property has been set. Updates child control and rendering information.
        /// </summary>
        private void OnEditableFieldSet()
        {
        }


		#endregion Public Properties 

		#region Private Methods 

        bool IPostBackDataHandler.LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {            
            //string postData = postCollection[postDataKey];
            //if (postData != null)
            //{
            //    this.EditableField.SetValue(postData);
            //    return true;
            //}
            //return false;
            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            //this.OnFormValueChanged();
        }

        /// <summary>
        /// Called when the form value has been changed.
        /// </summary>
        private void OnFormValueChanged()
        {
            if (this.FormValueChanged != null)
                this.FormValueChanged(this, EventArgs.Empty);
        }


		#endregion Private Methods 

		#region Protected Methods 


        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderChildren(writer);
        }

        

		#endregion Protected Methods 

        /// <summary>
        /// Fires when the form value is changed;
        /// </summary>
        public event EventHandler FormValueChanged;

        
        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            /// Add the header control
            this.Controls.Add(new LiteralControl("<h2>" + this.EditableField.FormField.Name + "</h2>"));


            /// Add the field control
            switch (this.EditableField.Metadata.ControlType)
            {
                case FieldControlType.DatePicker:
                    {
                        TextBox textbox = new TextBox();
                        textbox.ID = this.ID + "Textbox";
                        textbox.Text = this.EditableField.TextValue;
                        textbox.TextChanged += new EventHandler(HandleTextboxTextChanged);
                        textbox.Width = new Unit(100, UnitType.Pixel);
                        CalendarExtender calExender = new CalendarExtender();
                        calExender.PopupButtonID = "Image1";
                        calExender.TargetControlID = textbox.ID;
                        this.Controls.Add(textbox);
                        this.Controls.Add(calExender);
                        break;
                    }
                case FieldControlType.Textbox:
                    {
                        TextBox textbox = new TextBox();
                        textbox.ID = this.ID + "Textbox";
                        textbox.Text = this.EditableField.TextValue;
                        textbox.TextChanged += new EventHandler(HandleTextboxTextChanged);
                        textbox.Width = new Unit(250, UnitType.Pixel);
                        this.Controls.Add(textbox);
                        break;
                    }
                case FieldControlType.RichTextarea:
                case FieldControlType.Textarea:
                    {
                        TextBox textbox = new TextBox();
                        textbox.ID = this.ID + "Textbox";
                        textbox.Text = this.EditableField.TextValue;
                        textbox.TextMode = TextBoxMode.MultiLine;
                        textbox.Columns = 80;
                        textbox.Rows = 10;
                        textbox.TextChanged += new EventHandler(HandleTextboxTextChanged);
                        this.Controls.Add(textbox);
                        break;
                    }
                case FieldControlType.Dropdownbox:
                    {
                        DropDownList selectList = new DropDownList();
                        selectList.ID = this.ID + "DropDownList";
                        selectList.SelectedIndexChanged += new EventHandler(HandleDropDownListSelectedIndexChanged);
                        foreach (Formcode code in this.EditableField.LookupCodes)
                        {                            
                            selectList.Items.Add(new ListItem(code.Label, code.Id.ToString()));
                        }
                        if (this.EditableField.CodeValue.HasValue)
                            selectList.SelectedValue = this.EditableField.CodeValue.Value.ToString();
                        this.Controls.Add(selectList);
                        break;
                    }
                case FieldControlType.Checkbox:
                    {
                        CheckBoxList checkboxList = new CheckBoxList();
                        checkboxList.ID = this.ID + "CheckBoxList";
                        checkboxList.SelectedIndexChanged += new EventHandler(HandleCheckboxListSelectedIndexChanged);
                        /// Now parse the values for the values which are selected
                        string[] checkedTextValues = EditableField.ParseTextForCheckboxValue(this.EditableField.TextValue);
                        foreach (Formcode code in this.EditableField.LookupCodes)
                        {
                            ListItem listItem = new ListItem(code.Label, code.Id.ToString());
                            if (checkedTextValues.Contains(code.Id.ToString()))
                                listItem.Selected = true;
                            checkboxList.Items.Add(listItem);
                        }                        
                        this.Controls.Add(checkboxList);
                        break;
                    }
                case FieldControlType.Unknown:
                    {
                        TextBox textbox = new TextBox();
                        textbox.ID = this.ID + "Textbox";
                        textbox.Text = this.EditableField.TextValue;
                        textbox.TextChanged += new EventHandler(HandleTextboxTextChanged);
                        this.Controls.Add(textbox);
                        break;
                    }
            }        
        }

        /// <summary>
        /// Handles data change for postback for a CheckboxList control, sets the value
        /// </summary>
        private void HandleCheckboxListSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBoxList != null))
            {
                ///We need to extract out which checkboxes are selected, and store their values into the field
                CheckBoxList checkboxlist = sender as CheckBoxList;
                List<string> selectedValues = new List<string>();
                foreach (ListItem listItem in checkboxlist.Items)
                {
                    if (listItem.Selected)
                        selectedValues.Add(listItem.Value);
                }
                this.EditableField.SetMultipleValues(selectedValues.ToArray());
            }
            this.OnFormValueChanged();
        }

        /// <summary>
        /// Handles data change for postback for a dropdownlist control, sets the value
        /// </summary>
        private void HandleDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {            
            if ((sender as DropDownList) != null)
                this.EditableField.SetValue((sender as DropDownList).SelectedValue);
            this.OnFormValueChanged();
        }

        /// <summary>
        /// Handles data change for postback for a textbox control, sets the value
        /// </summary>
        private void HandleTextboxTextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox) != null)
                this.EditableField.SetValue((sender as TextBox).Text);
            this.OnFormValueChanged();
        }

        

        

    }
}
