using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFS.OpCenter.Forms;
using TFS.OpCenter.Data;

namespace TFS.Web.Forms.Controls
{
    public partial class ViewableFileControl : System.Web.UI.UserControl
    {

        protected int fileId;

        public int FileId
        {
            get
            {
                return this.fileId;
            }
            set
            {
                this.fileId = value;
                this.ProcessFile();
            }
        }

        private ViewableFile File;

        private bool LoadFile()
        {
            this.File = ViewableFileCollection.GetFile(this.FileId);
            return this.File != null;
        }

        private void ProcessFile()
        {
            this.Controls.Clear();

            if (!this.LoadFile())
                return;

            this.Controls.Add(new LiteralControl("<table>"));

            foreach (ViewableField field in this.File.Fields)
            {

                this.Controls.Add(new LiteralControl("<tr>"));

                /// Header
                this.Controls.Add(new LiteralControl("<th align=\"left\">"));
                this.Controls.Add(new LiteralControl(field.FormField.Name));
                this.Controls.Add(new LiteralControl("</th>"));


                this.Controls.Add(new LiteralControl("</tr>"));
                this.Controls.Add(new LiteralControl("<tr>"));


                /// value                
                this.Controls.Add(new LiteralControl("<td style=\"padding: 2px; border: solid 1px black;\">"));

                if (field.Metadata.ControlType == FieldControlType.Checkbox)
                {
                    /// multiple values
                    string[] checkedTextValues = EditableField.ParseTextForCheckboxValue(field.CurrentValue);
                    string outputstring = string.Empty;
                    foreach (Formcode code in field.LookupCodes)
                    {
                        if (checkedTextValues.Contains(code.Id.ToString()))
                        {
                            outputstring += code.Label + ", ";
                        }
                    }
                    if (outputstring.Length > 0)
                        outputstring = outputstring.Remove(outputstring.Length - 2);
                    this.Controls.Add(new LiteralControl(outputstring + "&nbsp;"));
                }
                else
                {
                    this.Controls.Add(new LiteralControl(field.CurrentValue + "&nbsp;"));
                }
                this.Controls.Add(new LiteralControl("</td>"));

                this.Controls.Add(new LiteralControl("</tr>"));
            }


            this.Controls.Add(new LiteralControl("</table>"));
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.ProcessFile();
        }
    }
}