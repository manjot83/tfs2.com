using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Cridion.Web.Controls;
using TFS.OpCenter.Scheduling;

namespace TFS.OpCenter.UI
{
    public class AvailabilityCalendar : MarkableCalendar
    {
        
        public String Username
        {
            get;
            set;
        }

        public AvailabilityCalendar() :base()
        {
            this.DaySelected +=new MarkableCalendarSelectedEventHandler(HandleDaySelected);
        }

        void HandleDaySelected(object sender, MarkableCalendarSelectedEventArgs args)
        {

            if (args.IsMarking)
                AvailabilityController.MarkAvailable(Username, args.Day, args.Month, args.Year);
            else
                AvailabilityController.MarkUnavailable(Username, args.Day, args.Month, args.Year);

            this.DataBind();
        }

        public override void DataBind()
        {
            Controls.Clear();
            CreateChildControls();
        }

        protected override void CreateDayContents(TableCell DayCell, int DayOfMonth, int DayOfWeek)
        {
            base.CreateDayContents(DayCell, DayOfMonth, DayOfWeek);
            

        }

        protected override bool DetermineDayMarked(int DayOfMonth, int DayOfWeek)
        {
            /*if (ViewState["MarkedState"] != null)
            {
                ((Boolean[])ViewState["MarkedState"])[DayOfMonth - 1] = TFS.Intranet.Scheduling.AvailabilityHandler.IsAvailable(_username, DayOfMonth, VisibleDate.Month, VisibleDate.Year);
                Boolean[] state = (Boolean[])ViewState["MarkedState"];
                return ((Boolean[])ViewState["MarkedState"])[DayOfMonth - 1];
            }*/
            return AvailabilityController.IsAvailable(Username, DayOfMonth, VisibleDate.Month, VisibleDate.Year);
        }
    }
}
