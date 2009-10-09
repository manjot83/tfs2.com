IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_EmployeeSummary]'))
DROP VIEW [dbo].[vw_EmployeeSummary]
GO


CREATE VIEW [dbo].[vw_EmployeeSummary]
AS
SELECT     Timesheets.id AS timesheetid, 
           Timesheets.username, 
           Timesheets.periodaccountid, 
           BillingPeriodAccounts.periodid, 
           BillingPeriodAccounts.accountid, 
           BillingAccounts.name AS accountname,            
           BillingPeriodAccounts.perdiemrate, 
           Timesheets.perdiemcount, 
           BillingPeriodAccounts.mileagerate, 
           Timesheets.mileageclaimed,
           BillingRates.rate, 
           Timesheets.IsDeleted,
           RateGroups.id AS rategroupid, 
           RateGroups.name as rategroupname
FROM       BillingAccounts 
                INNER JOIN BillingPeriodAccounts ON BillingAccounts.id = BillingPeriodAccounts.accountid
                INNER JOIN BillingRates ON BillingPeriodAccounts.id = BillingRates.periodaccountid
                INNER JOIN Timesheets ON BillingPeriodAccounts.id = Timesheets.periodaccountid
                INNER JOIN RateGroups ON BillingRates.groupid = RateGroups.id AND  Timesheets.rategroupid = RateGroups.id
                      
GO