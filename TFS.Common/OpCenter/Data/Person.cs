using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;

using SubSonic;

namespace TFS.OpCenter.Data
{
    public partial class Person : IComparable<Person>
    {

        /// <summary>
        /// Returns a Person fetched by their Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Person FetchByUsername(string username)
        {
            Person person = new Person();
            person.LoadByParam(Person.Columns.Username, username);
            return person;
        }


        public static class Comparers
        {
            public class EqualityComparer : IEqualityComparer<Person>
            {
                public bool Equals(Person x, Person y)
                {
                    return x.Id.Equals(y.Id);
                }

                public int GetHashCode(Person obj)
                {
                    return obj.Id;
                }
            }
        }
        
        public int CompareTo(Person other)
        {
            return this.Id.CompareTo(other.Id);
        }

    }
    
}