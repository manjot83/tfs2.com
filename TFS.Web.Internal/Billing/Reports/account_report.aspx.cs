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
using System.Linq;

namespace TFS.Intranet.Web.Billing.Reports
{
    public partial class account_report : System.Web.UI.Page
    {
        protected DataTable summaryinfo;

        protected double GetTotalHours()
        {
            return summaryinfo.AsEnumerable().Select(x => Double.Parse(x["TotalHours"].ToString())).Sum();
        }

        protected double GetTotalLabor()
        {
            return summaryinfo.AsEnumerable().Select(x => Double.Parse(x["TotalHours"].ToString()) * Double.Parse(x["Rate"].ToString())).Sum();
        }

        protected double GetTotalPerDiem()
        {
            return Double.Parse(summaryinfo.Rows[0]["PerDiemTotal"].ToString()) * Double.Parse(summaryinfo.Rows[0]["PerDiemRate"].ToString());
        }

        protected double GetTotalMileage()
        {
            return Double.Parse(summaryinfo.Rows[0]["MileageTotal"].ToString()) * Double.Parse(summaryinfo.Rows[0]["MileageRate"].ToString());
        }

        protected double GetTotalBilled()
        {
            return GetTotalLabor() + GetTotalMileage() + GetTotalPerDiem() + Double.Parse(summaryinfo.Rows[0]["ExpenseTotal"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 PeriodID = Int32.Parse(Request.Params["id"]);
            Int32 BillingAccountID = Int32.Parse(Request.Params["accountid"]);

            summaryinfo = new TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController().GetAccountSummaryTotals(BillingAccountID, PeriodID);


            BillingGroupRepeater.DataSource = summaryinfo;
            BillingGroupRepeater.DataBind();
            /*fill in summary*/

            //report_TotalExpenses.Text = summaryinfo.Rows[0]["ExpenseTotal"].ToString();
            //report_TotalPerDiemCount.Text = summaryinfo.Rows[0]["PerDiemTotal"].ToString();
            //report_perdiemrate.Text = summaryinfo.Rows[0]["PerDiemRate"].ToString();
            //report_TotalMileage.Text = summaryinfo.Rows[0]["MileageTotal"].ToString();
            //report_mileagerate.Text = summaryinfo.Rows[0]["MileageRate"].ToString();

            //report_line_expensetotal.Text = report_TotalExpenses.Text;
            //report_line_perdiem.Text = (Double.Parse(report_perdiemrate.Text) * Double.Parse(report_TotalPerDiemCount.Text)) + "";
            //report_line_mileage.Text = (Double.Parse(report_mileagerate.Text) * Double.Parse(report_TotalMileage.Text)) + "";

            //report_Total1Hours.Text = summaryinfo.Rows[0]["TotalHours"].ToString();
            //report_1rate.Text = summaryinfo.Rows[0]["Rate"].ToString();
            //report_line_1.Text = (Double.Parse(report_Total1Hours.Text) * Double.Parse(report_1rate.Text)) + "";
            //report_ratename1.Text = summaryinfo.Rows[0]["RateGroupName"].ToString();

            //report_Total2Hours.Text = summaryinfo.Rows[1]["TotalHours"].ToString();
            //report_2rate.Text = summaryinfo.Rows[1]["Rate"].ToString();
            //report_line_2.Text = (Double.Parse(report_Total2Hours.Text) * Double.Parse(report_2rate.Text)) + "";
            //report_ratename2.Text = summaryinfo.Rows[1]["RateGroupName"].ToString();

            //report_Total3Hours.Text = summaryinfo.Rows[2]["TotalHours"].ToString();
            //report_3rate.Text = summaryinfo.Rows[2]["Rate"].ToString();
            //report_line_3.Text = (Double.Parse(report_Total3Hours.Text) * Double.Parse(report_3rate.Text)) + "";
            //report_ratename3.Text = summaryinfo.Rows[2]["RateGroupName"].ToString();

            //report_Total4Hours.Text = summaryinfo.Rows[3]["TotalHours"].ToString();
            //report_4rate.Text = summaryinfo.Rows[3]["Rate"].ToString();
            //report_line_4.Text = (Double.Parse(report_Total4Hours.Text) * Double.Parse(report_4rate.Text)) + "";
            //report_ratename4.Text = summaryinfo.Rows[3]["RateGroupName"].ToString();

            //report_TotalHours.Text = Double.Parse(report_Total1Hours.Text) +
            //                            Double.Parse(report_Total2Hours.Text) +
            //                            Double.Parse(report_Total3Hours.Text) +
            //                            Double.Parse(report_Total4Hours.Text) + "";

            //report_line_labor.Text = Double.Parse(report_line_1.Text) +
            //                            Double.Parse(report_line_2.Text) +
            //                            Double.Parse(report_line_3.Text) +
            //                            Double.Parse(report_line_4.Text) + "";

            //report_line_invoice.Text = Double.Parse(report_line_expensetotal.Text) + Double.Parse(report_line_labor.Text) + Double.Parse(report_line_perdiem.Text) + Double.Parse(report_line_mileage.Text) + "";
        }
    }
}
