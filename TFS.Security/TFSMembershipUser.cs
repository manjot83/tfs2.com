using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using TFS.OpCenter.Data;

namespace TFS.Security
{
    public class TFSMembershipUser : MembershipUser
    {       
        public string LastName { get; private set; }

        public string FirstName { get; private set; }
        
        public TFSMembershipUser(string providerName, Person person)
            : this(providerName, person.Username, person.Email, person.Firstname, person.Lastname)
        {

        }

        public TFSMembershipUser(string providerName,
                                string username,
                                string email,
                                string firstName,
                                string lastName)
            : base(providerName,
                   username, email, 
                   email, String.Empty,
                   String.Empty, true,
                   false, DateTime.MinValue,
                   DateTime.MinValue, DateTime.MinValue,
                   DateTime.MinValue, DateTime.MinValue)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }
    }
}
