using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using TFS.OpCenter.Scheduling;
using TFS.OpCenter.Data;
using System.Collections.Generic;

namespace TFS.OpCenter.Scheduling
{
    public class AvailabilityController
    {

        public static void MarkAvailable(String username, int Day, int Month, int Year)
        {
            Person person = Person.FetchByUsername(username);
            if (person == null)
                return; //this shouldn't happen

            Availability availability = Availability.FetchByPersonAndDate(person.Id, Month, Year, Day);
            if (availability == null)
            {
                Availability.Insert(person.Id, Month, Year, Day, true);
            }
            else
            {
                availability.Isavailable = true;
                availability.Save();
            }
        }

        public static void MarkUnavailable(String username, int Day, int Month, int Year)
        {
            Person person = Person.FetchByUsername(username);
            if (person == null)
                return; //this shouldn't happen

            Availability availability = Availability.FetchByPersonAndDate(person.Id, Month, Year, Day);
            if (availability == null)
            {
                Availability.Insert(person.Id, Month, Year, Day, false);
            }
            else
            {
                availability.Isavailable = false;
                availability.Save();
            }
        }

        public static Boolean IsAvailable(String username, int Day, int Month, int Year)
        {
            Person person = Person.FetchByUsername(username);
            if (person == null)
                return false; //this shouldn't happen

            Availability availability = Availability.FetchByPersonAndDate(person.Id, Month, Year, Day);
            if (availability == null)
                return false;
            return availability.Isavailable;
        }

        public static List<Availability> GetAvailabilityRecords(int Month, int Year)
        {
            AvailabilityCollection availabilityRecords = new AvailabilityCollection();
            availabilityRecords.Where(Availability.Columns.Month, Month).Where(Availability.Columns.Year, Year).Load();
            return availabilityRecords.GetList();
        }

    }
}
