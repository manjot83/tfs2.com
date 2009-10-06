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
    public partial class Formfile
    {

        /// <summary>
        /// Returns a Personnelfile by a user
        /// </summary>
        /// <returns></returns>
        public static Formfile FetchByPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            FormfileCollection candidateFiles = person.Formfiles();
            if (candidateFiles.Count > 0)
                return candidateFiles[0];
            return null;
        }


        /// <summary>
        /// Returns the ModifiedBy string if it isn't empty, otherwise returns the CreatedBy
        /// </summary>
        public string ModifiedOrCreatedBy
        {
            get
            {
                if (string.IsNullOrEmpty(this.Modifiedby))
                    return this.Createdby;
                return this.Modifiedby;
            }
        }

    }
    
}