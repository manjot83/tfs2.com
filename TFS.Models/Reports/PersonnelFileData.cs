using System.Collections.Generic;
using System.Data;

namespace TFS.Models.Reports
{
    public class PersonnelFileData : ICsvReport
    {
        private IEnumerable<User> users;

        public PersonnelFileData(IEnumerable<User> users)
        {
            this.users = users;
        }

        public DataTable ConvertToTable()
        {
            var table = new DataTable();
            // Create columns
            table.Columns.Add("FirstName");
            table.Columns.Add("LastName");
            // Create rows
            foreach (var user in users)
            {
                var row = table.NewRow();
                row[0] = user.FirstName;
                row[1] = user.LastName;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
