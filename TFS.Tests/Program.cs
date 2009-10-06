using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TFS.OpCenter.Scheduling;
using TFS.OpCenter.Data;
using TFS.OpCenter.Forms;

namespace TFS.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TestForms();
            Debugger.Break();
        }

        static void TestForms()
        {
            DesignableForm form = new DesignableForm(Form.FetchByID(101));
            
            Debugger.Break();
        }

        static void Assert(string value, string test)
        {
            Console.WriteLine(string.Format("Should be: {0}, is: {1}", value, test));            
        }

    }
}
