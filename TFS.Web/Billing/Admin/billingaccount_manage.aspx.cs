using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace TFS.Intranet.Web.Billing.Admin
{
    public partial class billingaccount_manage : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExpenseAccount_Created(object sender, EventArgs e)
        {
            BillingAccountDropDown.Items.Clear();
            BillingAccountDropDown.DataBind();
            if (String.IsNullOrEmpty(SelectedBillingAccountID.Value))
                BillingAccountDropDown.SelectedValue = BillingAccountDropDown.Items[0].Value;
            else
                BillingAccountDropDown.SelectedValue = SelectedBillingAccountID.Value;
        }

        protected void Change_AccountName(object sender, EventArgs e)
        {   
            Int32 id = Int32.Parse(SelectedBillingAccountID.Value);
            (new TFS.Intranet.Data.Billing.BillingAccountController()).Update(id, BillingAccountNameChanger.Text);

            BillingAccountDropDown.Items.Clear();
            BillingAccountDropDown.DataBind();

            BillingAccountDropDown.SelectedValue = SelectedBillingAccountID.Value;
            SelectedBillingAccountName.Text = BillingAccountDropDown.SelectedItem.Text;
        }

        protected void BillingAccountSelected(object sender, EventArgs e)
        {            
            SelectedBillingAccountID.Value = BillingAccountDropDown.SelectedValue;
            SelectedBillingAccountName.Text = BillingAccountDropDown.SelectedItem.Text;
            BillingAccountNameChanger.Text = BillingAccountDropDown.SelectedItem.Text;

            DefaultBillingRatesRepeater.DataBind();

            PerDiem_Textbox.Text = GetDefaultPerDiemRate().ToString();
            PerDiemStatus.Text = "";
            Mileage_Textbox.Text = GetDefaultMileageRate().ToString();
            MileageStatus.Text = "";
            EditPeriodBillingPanel.Visible = true;
        }

        protected void DefaultBillingRatesCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SetRate")
            {
                if (SelectedBillingAccountID.Value.Equals(""))
                    return;
                int BillingAccountID = Int32.Parse(SelectedBillingAccountID.Value);
                int GroupID = Int32.Parse(e.CommandArgument.ToString());
                double Rate = double.Parse(((TextBox)e.Item.FindControl("DefaultRate")).Text);

                (new TFS.Intranet.Data.Billing.DefaultBillingRateController()).UpdateRate(BillingAccountID, GroupID, Rate);
                
                ((Label)e.Item.FindControl("Status")).Text = "Rate set to $" + Rate.ToString();
            }
        }

        protected double GetDefaultBillingRate(int GroupID)
        {
            if (SelectedBillingAccountID.Value.Equals(""))
                return -1;

            Int32 BillingAccountID = Int32.Parse(SelectedBillingAccountID.Value);

            return (new TFS.Intranet.Data.Billing.DefaultBillingRateController()).FetchRate(BillingAccountID, GroupID);
        }

        protected void SetDefaultPerDiemRate(Object sender, EventArgs e)
        {
            if (SelectedBillingAccountID.Value.Equals(""))
                return;
            int BillingAccountID = Int32.Parse(SelectedBillingAccountID.Value);
            double Rate = double.Parse(PerDiem_Textbox.Text);

            (new TFS.Intranet.Data.Billing.BillingAccountController()).UpdateDefaultPerDiemRate(BillingAccountID, Rate);
            
            PerDiemStatus.Text = "Rate set to $" + Rate.ToString();
        }

        protected void SetDefaultMileageRate(Object sender, EventArgs e)
        {
            if (SelectedBillingAccountID.Value.Equals(""))
                return;
            int BillingAccountID = Int32.Parse(SelectedBillingAccountID.Value);
            double Rate = double.Parse(Mileage_Textbox.Text);

            (new TFS.Intranet.Data.Billing.BillingAccountController()).UpdateDefaultMileageRate(BillingAccountID, Rate);

            MileageStatus.Text = "Rate set to $" + Rate.ToString();
        }

        protected double GetDefaultPerDiemRate()
        {
            if (SelectedBillingAccountID.Value.Equals(""))
                return -1;

            int BillingAccountID = Int32.Parse(SelectedBillingAccountID.Value);
            
            return (new TFS.Intranet.Data.Billing.BillingAccountController()).FetchDefaultPerDiemRateByID(BillingAccountID);
        }

        protected double GetDefaultMileageRate()
        {
            if (SelectedBillingAccountID.Value.Equals(""))
                return -1;

            int BillingAccountID = Int32.Parse(SelectedBillingAccountID.Value);

            return (new TFS.Intranet.Data.Billing.BillingAccountController()).FetchDefaultMileageRateByID(BillingAccountID);
        }
    }
}
