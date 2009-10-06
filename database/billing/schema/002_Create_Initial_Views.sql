IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Users]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_Users]
AS
SELECT	0 AS id,
		sAMAccountName AS username,
		givenName as firstname,
		sn AS lastname,
		title as title,
		department as rategroup,
		[RateGroups].[name] as [rategroupname]
 FROM 
OpenQuery(ADSI, 
		''SELECT title, sn, givenName, sAMAccountName, department FROM ''''LDAP://DC=TFS2,DC=LOCAL'''' where objectClass = ''''User'''' and memberOf = ''''CN=payrollUsers,OU=Security Groups,DC=tfs2,DC=local'''' '')
  INNER JOIN [RateGroups] ON [RateGroups].[id] = department	
' 
GO


CREATE VIEW [dbo].[vw_BillingPeriodAccounts_Join]
AS
SELECT    BillingPeriodAccounts.id, BillingPeriodAccounts.periodid, BillingPeriods.month, BillingPeriods.year, BillingPeriods.openuntil, BillingPeriodAccounts.accountid, 
                      BillingAccounts.name AS accountname, BillingPeriodAccounts.perdiemrate, BillingPeriodAccounts.mileagerate, BillingPeriodAccounts.IsDeleted
FROM         BillingAccounts INNER JOIN
                      BillingPeriodAccounts ON BillingAccounts.id = BillingPeriodAccounts.accountid INNER JOIN
                      BillingPeriods ON BillingPeriodAccounts.periodid = BillingPeriods.id

GO

CREATE VIEW [dbo].[vw_BillingRates_Join]
AS
SELECT     BillingRates.id, BillingRates.periodaccountid, BillingPeriodAccounts.periodid, BillingPeriodAccounts.accountid, BillingAccounts.name AS accountname, 
                      BillingRates.groupid, RateGroups.name AS rategroupname, BillingRates.rate, BillingRates.IsDeleted
FROM         BillingAccounts INNER JOIN
                      BillingPeriodAccounts ON BillingAccounts.id = BillingPeriodAccounts.accountid INNER JOIN
                      BillingPeriods ON BillingPeriodAccounts.periodid = BillingPeriods.id INNER JOIN
                      BillingRates ON BillingPeriodAccounts.id = BillingRates.periodaccountid INNER JOIN
                      RateGroups ON BillingRates.groupid = RateGroups.id

GO

CREATE VIEW [dbo].[vw_EmployeeSummary]
AS
SELECT     Timesheets.id AS timesheetid, Timesheets.username, Timesheets.periodaccountid, BillingPeriodAccounts.periodid, BillingPeriodAccounts.accountid, 
                      BillingAccounts.name AS accountname, vw_Users.rategroup AS rategroupid, vw_Users.rategroupname, BillingPeriodAccounts.perdiemrate, Timesheets.perdiemcount, 
                      BillingPeriodAccounts.mileagerate, Timesheets.mileageclaimed,
                      BillingRates.rate, Timesheets.IsDeleted
FROM         BillingAccounts INNER JOIN
                      BillingPeriodAccounts ON BillingAccounts.id = BillingPeriodAccounts.accountid INNER JOIN
                      BillingRates ON BillingPeriodAccounts.id = BillingRates.periodaccountid INNER JOIN
                      Timesheets ON BillingPeriodAccounts.id = Timesheets.periodaccountid INNER JOIN
                      vw_Users ON BillingRates.groupid = vw_Users.rategroup AND Timesheets.username = vw_Users.username

GO


CREATE VIEW [dbo].[vw_EmployeeTimesheetInfo]
AS
SELECT     Timesheets.id AS timesheetid, Timesheets.username, Timesheets.perdiemcount, Timesheets.mileageclaimed, BillingPeriods.month, BillingPeriods.year, BillingPeriods.openuntil, 
                      BillingAccounts.name AS accountname, BillingPeriods.id AS billingperiodid, BillingAccounts.id AS billingaccountid, vw_Users.rategroup AS rategroupid, 
                      vw_Users.rategroupname, Timesheets.IsDeleted
FROM         Timesheets INNER JOIN
                      BillingPeriodAccounts ON Timesheets.periodaccountid = BillingPeriodAccounts.id INNER JOIN
                      BillingPeriods ON BillingPeriodAccounts.periodid = BillingPeriods.id INNER JOIN
                      BillingAccounts ON BillingPeriodAccounts.accountid = BillingAccounts.id LEFT OUTER JOIN
                      vw_Users ON Timesheets.username = vw_Users.username

GO


CREATE VIEW [dbo].[vw_PeriodAccountInfo]
AS
SELECT     dbo.BillingPeriodAccounts.id as billingperiodaccountid, dbo.BillingPeriodAccounts.periodid, dbo.BillingPeriodAccounts.accountid, dbo.BillingAccounts.name, dbo.BillingPeriods.month, 
                      dbo.BillingPeriods.year, dbo.BillingPeriods.openuntil, dbo.BillingPeriodAccounts.IsDeleted
FROM         dbo.BillingAccounts INNER JOIN
                      dbo.BillingPeriodAccounts ON dbo.BillingAccounts.id = dbo.BillingPeriodAccounts.accountid INNER JOIN
                      dbo.BillingPeriods ON dbo.BillingPeriodAccounts.periodid = dbo.BillingPeriods.id 

GO

CREATE VIEW [dbo].[vw_TimeEntriesTotal]
AS
SELECT *, (CAST ( DATEDIFF(minute, timein, timeout) as float ) / 60) as totalhours FROM TimeEntries

GO

