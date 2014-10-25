using System.Collections.Generic;
using System.Data;
using TFS.Models.Users;

namespace TFS.Models.Reports
{
    public class PersonnelFileReport : ICsvReport
    {
        private IEnumerable<User> users;

        public PersonnelFileReport(IEnumerable<User> users)
        {
            this.users = users;
        }

        public DataTable ConvertToTable()
        {
            var table = new DataTable();
            // Create columns
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Initital");
            table.Columns.Add("DoB");
            table.Columns.Add("Gender");
            table.Columns.Add("SSN");
            table.Columns.Add("Pri Phone");
            table.Columns.Add("Alt Phone");
            table.Columns.Add("Alt Email");
            table.Columns.Add("Emg Contact");
            table.Columns.Add("Emg Phone");
            table.Columns.Add("Street Address");
            table.Columns.Add("City");
            table.Columns.Add("State");
            table.Columns.Add("Zip");
            table.Columns.Add("Position");
            table.Columns.Add("Shirt Size");
            table.Columns.Add("Flight Suit Size");
            // Create rows
            foreach (var user in users)
            {
                var row = table.NewRow();
                row[0] = user.FirstName;
                row[1] = user.LastName;
                row[2] = user.Person != null ? user.Person.MiddleInitial : string.Empty;
                row[3] = user.Person != null && user.Person.DateOfBirth.HasValue ? user.Person.DateOfBirth.Value.ToShortDateString() : string.Empty;
                row[4] = user.Person != null ? user.Person.Gender.ToString() : string.Empty;
                row[5] = user.Person != null ? "=\"" + user.Person.SocialSecurityLastFour + "\"" : string.Empty;
                row[6] = user.Person != null ? "=\"" + user.Person.PrimaryPhoneNumber + "\"" : string.Empty;
                row[7] = user.Person != null ? "=\"" + user.Person.AlternatePhoneNumber + "\"" : string.Empty;
                row[8] = user.Person != null ? user.Person.AlternateEmail : string.Empty;
                row[9] = user.Person != null ? user.Person.EmergencyContactName : string.Empty;
                row[10] = user.Person != null ? "=\"" + user.Person.EmergencyContactPhoneNumber + "\"" : string.Empty;
                row[11] = user.Person != null && user.Person.Address != null ? user.Person.Address.StreetAddress : string.Empty;
                row[12] = user.Person != null && user.Person.Address != null ? user.Person.Address.City : string.Empty;
                row[13] = user.Person != null && user.Person.Address != null && user.Person.Address.State != null ? user.Person.Address.State.Abbreviation : string.Empty;
                row[14] = user.Person != null && user.Person.Address != null ? "=\"" + user.Person.Address.ZipCode + "\"" : string.Empty;
                row[15] = user.Person != null && user.Person.HirePosition != null ? user.Person.HirePosition.Title : string.Empty;
                row[16] = user.Person != null ? user.Person.ShirtSize.ToString() : string.Empty;
                row[17] = user.Person != null ? user.Person.FlightSuitSize.ToString() : string.Empty;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
