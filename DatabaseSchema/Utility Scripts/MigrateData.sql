USE tfs2_billing

/*first delete all data*/

DELETE FROM [TimeEntries];
DELETE FROM [ExpenseEntries];
DELETE FROM [Timesheets];
DELETE FROM [BillingRates];
DELETE FROM [BillingPeriodAccounts];
DELETE FROM [BillingPeriods];
DELETE FROM [DefaultBillingRates];
DELETE FROM [BillingAccounts];
DELETE FROM [RateGroups];

/*first table, RateGroups*/

SET IDENTITY_INSERT RateGroups ON
GO
INSERT INTO RateGroups ([id], [name])
	SELECT * FROM [tfs2_payroll]..[PayrollGroups]
GO
SET IDENTITY_INSERT RateGroups OFF
GO

/*second table, BillingAccounts */

SET IDENTITY_INSERT BillingAccounts ON
GO
INSERT INTO BillingAccounts ([id], [name], [defaultperdiemrate])
	SELECT AccountID AS id, AccountName AS name, ISNULL(PerDiemRate, 0) AS defaultperdiemrate 
	FROM (SELECT * FROM [tfs2_payroll]..[BillingAccounts]
		LEFT OUTER JOIN [tfs2_payroll]..[DefaultPerDiemRates]
			ON BillingAccountID=AccountID) AS t1;
GO
SET IDENTITY_INSERT BillingAccounts OFF
GO

/*third table, DefaultBillingRates */

INSERT INTO DefaultBillingRates ([accountid], [groupid], [rate])
	SELECT BillingAccountID AS accountid, GroupID AS groupid, BillingRate AS rate
	FROM [tfs2_payroll]..[DefaultBillingRates];
GO

/* fourth table, [BillingPeriods] */

SET IDENTITY_INSERT [BillingPeriods] ON
GO
INSERT INTO [BillingPeriods] ([id], [month], [year], [openuntil]) 
	SELECT PeriodID AS ID, Month AS month, Year AS year, OpenUntilDate as openuntil
	FROM [tfs2_payroll]..[PayrollPeriods];
GO
SET IDENTITY_INSERT [BillingPeriods] OFF
GO


/* fifth table [BillingPeriodAccounts] */

INSERT INTO [BillingPeriodAccounts] ([periodid], [accountid], [perdiemrate])
	SELECT [tfs2_payroll]..[PersonalPayrollEntries].[PeriodID] AS periodid, [tfs2_payroll]..[PersonalPayrollEntries].[BillingAccountID] AS accountid, ISNULL([tfs2_payroll]..[PerDiemRates].[PerDiemRate],0) AS perdiemrate
	FROM [tfs2_payroll]..[PersonalPayrollEntries] 
		LEFT OUTER JOIN [tfs2_payroll]..[PerDiemRates] 
			ON [tfs2_payroll]..[PerDiemRates].[PeriodID]=[tfs2_payroll]..[PersonalPayrollEntries].[PeriodID] 
			AND [tfs2_payroll]..[PerDiemRates].[BillingAccountID]=[tfs2_payroll]..[PersonalPayrollEntries].[BillingAccountID]	
	GROUP BY [tfs2_payroll]..[PersonalPayrollEntries].[PeriodID], [tfs2_payroll]..[PersonalPayrollEntries].[BillingAccountID], [tfs2_payroll]..[PerDiemRates].[PerDiemRate];

INSERT INTO [BillingPeriodAccounts] ([periodid], [accountid], [perdiemrate])
	SELECT [tfs2_payroll]..[BillingRates].[PeriodID], [tfs2_payroll]..[BillingRates].[BillingAccountID], ISNULL([tfs2_payroll]..[PerDiemRates].[PerDiemRate],0) AS perdiemrate
	FROM [tfs2_payroll]..[BillingRates]
		LEFT OUTER JOIN [tfs2_payroll]..[PerDiemRates] 
				ON [tfs2_payroll]..[PerDiemRates].[PeriodID]=[tfs2_payroll]..[BillingRates].[PeriodID] 
				AND [tfs2_payroll]..[PerDiemRates].[BillingAccountID]=[tfs2_payroll]..[BillingRates].[BillingAccountID]	
	WHERE NOT EXISTS (	SELECT *
						FROM [BillingPeriodAccounts]
						WHERE [BillingPeriodAccounts].[PeriodID] = [tfs2_payroll]..[BillingRates].[PeriodID]
							AND [BillingPeriodAccounts].[accountid] = [tfs2_payroll]..[BillingRates].[BillingAccountID])
	GROUP BY [tfs2_payroll]..[BillingRates].[PeriodID], [tfs2_payroll]..[BillingRates].[BillingAccountID], [tfs2_payroll]..[PerDiemRates].[PerDiemRate];			
GO

/* sixth table [BillingRates] */

INSERT INTO [BillingRates] ([periodaccountid], [groupid], [rate])
	SELECT [BillingPeriodAccounts].id as periodaccountid, GroupID AS groupid, BillingRate AS rate
	FROM [tfs2_payroll]..[BillingRates]
		LEFT OUTER JOIN [BillingPeriodAccounts]
			ON [tfs2_payroll]..[BillingRates].[PeriodID] = [BillingPeriodAccounts].[PeriodID]
			AND [tfs2_payroll]..[BillingRates].[BillingAccountID] = accountid;
GO

/* seventh table [Timesheets] */

INSERT INTO [Timesheets] ([username], [periodaccountid], [perdiemcount])
	SELECT [tfs2_payroll]..[PersonalPayrollEntries].[username], [BillingPeriodAccounts].[id] AS periodaccountid, perdiemcount
	FROM [tfs2_payroll]..[PersonalPayrollEntries] 
		LEFT OUTER JOIN [tfs2_payroll]..[PerDiemCounts]
			ON [tfs2_payroll]..[PerDiemCounts].[Username] = [tfs2_payroll]..[PersonalPayrollEntries].[Username]
			AND [tfs2_payroll]..[PerDiemCounts].[PeriodID] = [tfs2_payroll]..[PersonalPayrollEntries].[PeriodID]
			AND [tfs2_payroll]..[PerDiemCounts].[BillingAccountID] = [tfs2_payroll]..[PersonalPayrollEntries].[BillingAccountID]
		LEFT OUTER JOIN [BillingPeriodAccounts] 
			ON [tfs2_payroll]..[PersonalPayrollEntries].[PeriodID] = [BillingPeriodAccounts].[PeriodID] 
			AND [tfs2_payroll]..[PersonalPayrollEntries].[BillingAccountID] = accountid;
GO

/* eighth table [ExpenseEntries] */

INSERT INTO [ExpenseEntries] ([timesheetid], [expensedate], [cost], [expensedesc])
	SELECT [Timesheets].[id] AS timesheetid, [expensedate], [cost], [expensedesc]
	FROM [tfs2_payroll]..[ExpenseEntries] 
		JOIN [BillingPeriodAccounts] 
			ON [tfs2_payroll]..[ExpenseEntries].[PeriodID] = [BillingPeriodAccounts].[PeriodID] 
			AND [tfs2_payroll]..[ExpenseEntries].[BillingAccountID] = [BillingPeriodAccounts].[accountid]
		JOIN [Timesheets]
			ON [tfs2_payroll]..[ExpenseEntries].[Username] = [Timesheets].[Username]
			AND [BillingPeriodAccounts].[id] = [Timesheets].[periodaccountid];
GO

/* ninth table [TimeEntries] */

INSERT INTO [TimeEntries] ([timesheetid], [day], [timein], [timeout], [notes])
	SELECT [Timesheets].[id] AS timesheetid, [day], [timein], [timeout], [notes]
	FROM [tfs2_payroll]..[DailyEntries] 
		JOIN [BillingPeriodAccounts] 
			ON [tfs2_payroll]..[DailyEntries].[PeriodID] = [BillingPeriodAccounts].[PeriodID] 
			AND [tfs2_payroll]..[DailyEntries].[BillingAccountID] = [BillingPeriodAccounts].[accountid]
		JOIN [Timesheets]
			ON [tfs2_payroll]..[DailyEntries].[Username] = [Timesheets].[Username]
			AND [BillingPeriodAccounts].[id] = [Timesheets].[periodaccountid];