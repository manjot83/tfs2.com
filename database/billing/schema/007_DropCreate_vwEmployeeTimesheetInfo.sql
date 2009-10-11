IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_EmployeeTimesheetInfo]'))
DROP VIEW [dbo].[vw_EmployeeTimesheetInfo]
GO

CREATE VIEW [dbo].[vw_EmployeeTimesheetInfo]
AS
SELECT     Timesheets.id AS timesheetid, 
           Timesheets.username, 
           Timesheets.perdiemcount, 
           Timesheets.mileageclaimed, 
           BillingPeriods.month, 
           BillingPeriods.year, 
           BillingPeriods.openuntil, 
           BillingAccounts.name AS accountname, 
           BillingPeriods.id AS billingperiodid, 
           BillingAccounts.id AS billingaccountid, 
           RateGroups.id AS rategroupid, 
           RateGroups.name as rategroupname,
           Timesheets.IsDeleted
FROM       Timesheets 
                INNER JOIN BillingPeriodAccounts ON Timesheets.periodaccountid = BillingPeriodAccounts.id 
                INNER JOIN BillingPeriods ON BillingPeriodAccounts.periodid = BillingPeriods.id 
                INNER JOIN BillingAccounts ON BillingPeriodAccounts.accountid = BillingAccounts.id 
                INNER JOIN RateGroups ON Timesheets.rategroupid = RateGroups.id
                LEFT OUTER JOIN vw_Users ON Timesheets.username = vw_Users.username
GO
