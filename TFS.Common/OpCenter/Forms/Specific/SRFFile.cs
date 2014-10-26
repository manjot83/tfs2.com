//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TFS.OpCenter.Forms;
//using TFS.OpCenter.Data;

//namespace TFS.OpCenter.Forms.Specific
//{
//    public class SRFFile : File
//    {

//        public SRFFile(Formfile encapsulatedFormFile)
//            : base(encapsulatedFormFile)
//        {

//        }

//        public string Subject
//        {
//            get
//            {
//                return this.GetStoredValue("SUBJECT");
//            }
//        }

//        public string Number
//        {
//            get
//            {
//                return this.GetStoredValue("SRF NUMBER");
//            }
//        }

//        public string Narrative
//        {
//            get
//            {
//                return this.GetStoredValue("NARRATIVE");
//            }
//        }

//        public string Authority
//        {
//            get
//            {
//                return this.GetStoredValue("AUTHORITY");
//            }
//        }

//        public string DesignAircraft
//        {
//            get
//            {
//                return this.GetStoredValue("DESIGN AIRCRAFT");
//            }
//        }

//        public DateTime PostingDate
//        {
//            get
//            {
//                DateTime postingDate = DateTime.MinValue;
//                DateTime.TryParse(this.GetStoredValue("POSTING DATE"), out postingDate);
//                return postingDate;
//            }
//        }

//        public string CrewPosition
//        {
//            get
//            {
//                return this.GetStoredValue("CREW POSITION");
//            }
//        }

//        public string Implementation
//        {
//            get
//            {
//                return this.GetStoredValue("Implementation");
//            }
//        }


//    }
//}
