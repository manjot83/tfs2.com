using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;

namespace TFS.OpCenter.Data
{
    public partial class Availability
    {

        /// <summary>
        /// Fetches by the person id and the date to lookup
        /// </summary>
        public static Availability FetchByPersonAndDate(int personId, int month, int year, int day)
        {
            return OpCenter.Data.DB.SelectAllColumnsFrom<Availability>().Where(Availability.Columns.Personid).IsEqualTo(personId)
                                                                        .And(Availability.Columns.Month).IsEqualTo(month)
                                                                        .And(Availability.Columns.Year).IsEqualTo(year)
                                                                        .And(Availability.Columns.Day).IsEqualTo(day)
                                                                        .ExecuteSingle<Availability>();
        }
    }
}
