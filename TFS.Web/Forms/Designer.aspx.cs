using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using TFS.OpCenter.Forms;
using System.Collections.Generic;

namespace TFS.Web.Forms
{
    public partial class Designer : System.Web.UI.Page
    {


        protected FormDesignerController controller;

        protected void HandleFieldItemSorting(object sender, ListViewSortEventArgs args)
        {
            List<DesignableField> fields = this.controller.DesignableForm.RelatedFields;
            ///sort the fields
            var sortedFields = fields;
            if (args.SortDirection == SortDirection.Ascending)
                sortedFields = fields.OrderBy(field => field.Name).ToList();
            else
                sortedFields = fields.OrderByDescending(field => field.Name).ToList();
            this.FieldsListView.DataSource = sortedFields;
            this.FieldsListView.DataBind();
        }

        protected void HandleFormInfoTextboxTextChanged(object sender, EventArgs args)
        {
            if (sender == this.FormNameTextbox)
            {
                this.SetFormNameTextbox.Visible = true;
            }
            else if (sender == this.ShortNameTextbox)
            {
                this.SetShortNameButton.Visible = true;
            }
            else if (sender == this.TFSFNumberTextbox)
            {
                this.SetTFSFNumberButton.Visible = true;
            }
            else if (sender == this.CreatedDateTextbox)
            {
                this.SetCreatedDateButton.Visible = true;
            }
        }

        protected void HandleFormInfoSetButton(object sender, EventArgs args)
        {
            string commandArgument = (sender as LinkButton).CommandArgument;
            if (commandArgument.Equals("FormName", StringComparison.InvariantCultureIgnoreCase))
            {
                this.controller.DesignableForm.Name = this.FormNameTextbox.Text;
                this.controller.DesignableForm.Store();
                this.FormInfoStatusLabel.Visible = true;
                this.FormInfoStatusLabel.Text = "Form Name Set";
            }
            else if (commandArgument.Equals("ShortName", StringComparison.InvariantCultureIgnoreCase))
            {
                this.controller.DesignableForm.ShortName = this.ShortNameTextbox.Text;
                this.controller.DesignableForm.Store();
                this.FormInfoStatusLabel.Visible = true;
                this.FormInfoStatusLabel.Text = "Form Short Name Set";
            }
            else if (commandArgument.Equals("TFSFNumber", StringComparison.InvariantCultureIgnoreCase))
            {
                this.controller.DesignableForm.TFSFNumber = this.TFSFNumberTextbox.Text;
                this.controller.DesignableForm.Store();
                this.FormInfoStatusLabel.Visible = true;
                this.FormInfoStatusLabel.Text = "Form TFSF Number Set";
            }
            else if (commandArgument.Equals("CreatedDate", StringComparison.InvariantCultureIgnoreCase))
            {
                this.controller.DesignableForm.CreatedDate = DateTime.Parse(this.CreatedDateTextbox.Text);
                this.controller.DesignableForm.Store();
                this.FormInfoStatusLabel.Visible = true;
                this.FormInfoStatusLabel.Text = "Form Created Date Set";
            }
            this.BindInfo();
        }       

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            this.BindInfo();
            this.BindFieldList();
        }

        protected void HandleFieldItemCommand(object sender, ListViewCommandEventArgs args)
        {
            if (args.CommandName.Equals("EditField", StringComparison.InvariantCultureIgnoreCase))
            {
                int fieldid = int.Parse(args.CommandArgument.ToString());
                this.EditField(fieldid);
            }
            else if (args.CommandName.Equals("MoveFieldUp", StringComparison.InvariantCultureIgnoreCase))
            {
                int fieldid = int.Parse(args.CommandArgument.ToString());
                DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);
                field.MoveUp();
                this.BindFieldList();
            }
            else if (args.CommandName.Equals("MoveFieldDown", StringComparison.InvariantCultureIgnoreCase))
            {
                int fieldid = int.Parse(args.CommandArgument.ToString());
                DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);
                field.MoveDown();
                this.BindFieldList();
            }
        }

        private void EditField(int fieldid)
        {            
            ///put the file id into the session state
            this.Session["FORMDESIGNER:FIELDID"] = fieldid;
            this.BindFieldEditor();
            this.BindFieldLookupCodeList();
        }

        protected void BindFieldEditor()
        {
            int fieldid = (int)this.Session["FORMDESIGNER:FIELDID"];
            DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);
            this.FieldNameTextbox.Text = field.Name;
            this.FieldControlTypeList.SelectedValue = field.Metadata.ControlType.ToString();

            this.FieldUpdateStatusLabel.Text = string.Empty;
            this.FieldUpdateStatusLabel.Visible = false;
            this.FieldEditorPanel.Visible = true;

            this.FieldIsKeyFieldCheckbox.Checked = field.IsKeyField();
        }

        protected void HandleFieldUpdateButtonClicked(object sender, EventArgs e)
        {           
            int fieldid = (int)this.Session["FORMDESIGNER:FIELDID"];
            DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);

            /// Update the name
            string newFieldName = this.FieldNameTextbox.Text;            
            if (!string.IsNullOrEmpty(newFieldName))
                field.Name = newFieldName;

            /// Update the control type
            FieldControlType controlType = (FieldControlType)Enum.Parse(typeof(FieldControlType), this.FieldControlTypeList.SelectedValue, true);
            field.Metadata.ControlType = controlType;

            if (field.IsKeyField() == false && this.FieldIsKeyFieldCheckbox.Checked)
            {
                field.SetAsKeyField();
            }

            /// Store
            field.Store();

            this.BindFieldList();

            this.FieldUpdateStatusLabel.Text = "Field Updated";
            this.FieldUpdateStatusLabel.Visible = true;
        }

        protected void HandleFieldNameUpdateButtonClicked(object sender, EventArgs e)
        {
            string newFieldName = this.FieldNameTextbox.Text;
            if (string.IsNullOrEmpty(newFieldName))
                return;

            int fieldid = (int)this.Session["FORMDESIGNER:FIELDID"];
            DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);
            field.Name = newFieldName;
            field.Store();

            this.BindFieldList();

            this.FieldUpdateStatusLabel.Text = "Field Name Updated";
            this.FieldUpdateStatusLabel.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int formid = int.Parse(this.Request.Params["form"]);
            this.controller = new FormDesignerController(formid);

            this.FormInfoStatusLabel.Visible = false;

            if (!this.IsPostBack)
                this.DataBind(true);
        }

        private void BindInfo()
        {
            this.IDLiteral.Text = this.controller.DesignableForm.Form.Id.ToString();
            this.FormNameTextbox.Text = this.controller.DesignableForm.Name;
            this.ShortNameTextbox.Text = this.controller.DesignableForm.ShortName;
            this.TFSFNumberTextbox.Text = this.controller.DesignableForm.TFSFNumber;
            this.CreatedDateTextbox.Text = this.controller.DesignableForm.CreatedDate.ToShortDateString();

            this.SetFormNameTextbox.Visible = false;
            this.SetShortNameButton.Visible = false;
            this.SetTFSFNumberButton.Visible = false;
            this.SetCreatedDateButton.Visible = false;
        }

        private void BindFieldList()
        {
            this.FieldsListView.DataSource = this.controller.DesignableForm.RelatedFields;
            this.FieldsListView.DataBind();
        }


        protected void HandleAddNewFieldButtonClicked(object sender, EventArgs e)
        {
            string newFieldName = this.NewFieldNameTextbox.Text;
            if (string.IsNullOrEmpty(newFieldName))
                return;
            this.NewFieldNameTextbox.Text = string.Empty;
            DesignableField newField = this.controller.DesignableForm.AddField(newFieldName);
            this.controller.DesignableForm.Store();
            this.BindFieldList();
            this.EditField(newField.FormField.Id);
        }

        protected void HandleAddNewFieldCodeButtonClicked(object sender, EventArgs e)
        {
            string newFieldCodeName = this.NewFieldCodeTextbox.Text;
            if (string.IsNullOrEmpty(newFieldCodeName))
                return;
            this.NewFieldCodeTextbox.Text = string.Empty;
            int fieldid = (int)this.Session["FORMDESIGNER:FIELDID"];
            DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);
            field.AddLookupCode(newFieldCodeName);
            field.Store();
            this.BindFieldLookupCodeList();
        }

        private void BindFieldLookupCodeList()
        {
            int fieldid = (int)this.Session["FORMDESIGNER:FIELDID"];
            DesignableField field = this.controller.DesignableForm.GetFieldByID(fieldid);
            this.FieldCodesRepeater.DataSource = field.LookupCodes;
            this.FieldCodesRepeater.DataBind();
        }

    }
}
