using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.FlightLogs
{
    public enum DutyCode : int
    {
        Unspecified = 0,
        PIC = 1, // Pilot In Command
        SIC = 2, // Second In Command
        MFE = 3, // Mission Flight Engineer
        MLM = 4, // Mission Load Master
        MN = 5, // Mission Navigator
        IP = 6, // Instructor Pilot
        IFE = 7, // Instructor Flight Engineer        
        ILM = 8, // Instructor Load Master        
        IN = 9, // Instructor Navigator        
        EP = 10, // Evaluator Pilot
        EFE = 11, // Evaluator Flight Engineer
    }
}
