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
using SubSonic.Utilities;

namespace TFS.Intranet.Data.Billing
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string BillingAccount = @"BillingAccounts";
        
		public static string BillingPeriodAccount = @"BillingPeriodAccounts";
        
		public static string BillingPeriod = @"BillingPeriods";
        
		public static string BillingRate = @"BillingRates";
        
		public static string DefaultBillingRate = @"DefaultBillingRates";
        
		public static string ExpenseEntry = @"ExpenseEntries";
        
		public static string RateGroup = @"RateGroups";
        
		public static string TimeEntry = @"TimeEntries";
        
		public static string Timesheet = @"Timesheets";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static string BillingPeriodAccountsJoin = @"vw_BillingPeriodAccounts_Join";
        
		public static string BillingRatesJoin = @"vw_BillingRates_Join";
        
		public static string EmployeeSummary = @"vw_EmployeeSummary";
        
		public static string EmployeeTimesheetInfo = @"vw_EmployeeTimesheetInfo";
        
		public static string PeriodAccountInfo = @"vw_PeriodAccountInfo";
        
		public static string TimeEntriesTotal = @"vw_TimeEntriesTotal";
        
		public static string User = @"vw_Users";
        
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	
	public static string Billing = @"Billing";
    
}

#endregion
