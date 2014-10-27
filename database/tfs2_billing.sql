SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingAccounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillingAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[defaultperdiemrate] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[defaultmileagerate] [float] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_BillingAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillingPeriodAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[periodid] [int] NOT NULL,
	[accountid] [int] NOT NULL,
	[perdiemrate] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[mileagerate] [float] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_BillingPeriodAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingPeriods]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillingPeriods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[openuntil] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_BillingPeriods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingRates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillingRates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[periodaccountid] [int] NOT NULL,
	[groupid] [int] NOT NULL,
	[rate] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_BillingRates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DefaultBillingRates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[accountid] [int] NOT NULL,
	[groupid] [int] NOT NULL,
	[rate] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_DefaultBillingRates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpenseEntries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpenseEntries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timesheetid] [int] NOT NULL,
	[expensedate] [datetime] NOT NULL,
	[cost] [float] NOT NULL,
	[expensedesc] [text] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_ExpenseEntries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RateGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RateGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_RateGroups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeEntries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TimeEntries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timesheetid] [int] NOT NULL,
	[day] [int] NOT NULL,
	[timein] [char](8) NOT NULL,
	[timeout] [char](8) NOT NULL,
	[notes] [text] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_TimeEntries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Timesheets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Timesheets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[periodaccountid] [int] NOT NULL,
	[perdiemcount] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[mileageclaimed] [float] NOT NULL DEFAULT ((0)),
	[rategroupid] [int] NOT NULL,
 CONSTRAINT [PK_Timesheets] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tmp_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tmp_Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NULL,
	[firstname] [nvarchar](255) NULL,
	[lastname] [nvarchar](255) NULL,
	[title] [nvarchar](255) NULL,
	[rategroup] [nvarchar](255) NULL,
 CONSTRAINT [PK_Tmp_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Users]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_Users]
AS
SELECT	tmp_users.*,
		[RateGroups].[name] as [rategroupname]
 FROM tmp_users
  INNER JOIN [RateGroups] ON [RateGroups].[id] = tmp_users.[rategroup]	
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_EmployeeTimesheetInfo]'))
EXEC dbo.sp_executesql @statement = N'

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
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_BillingPeriodAccounts_Join]'))
EXEC dbo.sp_executesql @statement = N'

/* [vw_BillingPeriodAccounts_Join] */
CREATE VIEW [dbo].[vw_BillingPeriodAccounts_Join]
AS
SELECT     BillingPeriodAccounts.id, BillingPeriodAccounts.periodid, BillingPeriods.month, BillingPeriods.year, BillingPeriods.openuntil, BillingPeriodAccounts.accountid, 
                      BillingAccounts.name AS accountname, BillingPeriodAccounts.perdiemrate, BillingPeriodAccounts.mileagerate, BillingPeriodAccounts.IsDeleted
FROM         BillingAccounts INNER JOIN
                      BillingPeriodAccounts ON BillingAccounts.id = BillingPeriodAccounts.accountid INNER JOIN
                      BillingPeriods ON BillingPeriodAccounts.periodid = BillingPeriods.id
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_BillingRates_Join]'))
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW [dbo].[vw_BillingRates_Join]
AS
SELECT     BillingRates.id, BillingRates.periodaccountid, BillingPeriodAccounts.periodid, BillingPeriodAccounts.accountid, BillingAccounts.name AS accountname, 
                      BillingRates.groupid, RateGroups.name AS rategroupname, BillingRates.rate, BillingRates.IsDeleted
FROM         BillingAccounts INNER JOIN
                      BillingPeriodAccounts ON BillingAccounts.id = BillingPeriodAccounts.accountid INNER JOIN
                      BillingPeriods ON BillingPeriodAccounts.periodid = BillingPeriods.id INNER JOIN
                      BillingRates ON BillingPeriodAccounts.id = BillingRates.periodaccountid INNER JOIN
                      RateGroups ON BillingRates.groupid = RateGroups.id
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_EmployeeSummary]'))
EXEC dbo.sp_executesql @statement = N'


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
                      
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_PeriodAccountInfo]'))
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW [dbo].[vw_PeriodAccountInfo]
AS
SELECT     dbo.BillingPeriodAccounts.id as billingperiodaccountid, dbo.BillingPeriodAccounts.periodid, dbo.BillingPeriodAccounts.accountid, dbo.BillingAccounts.name, dbo.BillingPeriods.month, 
                      dbo.BillingPeriods.year, dbo.BillingPeriods.openuntil, dbo.BillingPeriodAccounts.IsDeleted
FROM         dbo.BillingAccounts INNER JOIN
                      dbo.BillingPeriodAccounts ON dbo.BillingAccounts.id = dbo.BillingPeriodAccounts.accountid INNER JOIN
                      dbo.BillingPeriods ON dbo.BillingPeriodAccounts.periodid = dbo.BillingPeriods.id 
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_TimeEntriesTotal]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_TimeEntriesTotal]
AS
SELECT *, (CAST ( DATEDIFF(minute, timein, timeout) as float ) / 60) as totalhours FROM TimeEntries
' 
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]') AND name = N'ix_accountid')
CREATE NONCLUSTERED INDEX [ix_accountid] ON [dbo].[BillingPeriodAccounts]
(
	[accountid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]') AND name = N'ix_periodid')
CREATE NONCLUSTERED INDEX [ix_periodid] ON [dbo].[BillingPeriodAccounts]
(
	[periodid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BillingRates]') AND name = N'ix_groupid')
CREATE NONCLUSTERED INDEX [ix_groupid] ON [dbo].[BillingRates]
(
	[groupid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BillingRates]') AND name = N'ix_periodaccountid')
CREATE NONCLUSTERED INDEX [ix_periodaccountid] ON [dbo].[BillingRates]
(
	[periodaccountid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]') AND name = N'ix_accountid')
CREATE NONCLUSTERED INDEX [ix_accountid] ON [dbo].[DefaultBillingRates]
(
	[accountid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]') AND name = N'ix_groupid')
CREATE NONCLUSTERED INDEX [ix_groupid] ON [dbo].[DefaultBillingRates]
(
	[groupid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExpenseEntries]') AND name = N'ix_timesheetid')
CREATE NONCLUSTERED INDEX [ix_timesheetid] ON [dbo].[ExpenseEntries]
(
	[timesheetid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TimeEntries]') AND name = N'IX_timesheetid')
CREATE NONCLUSTERED INDEX [IX_timesheetid] ON [dbo].[TimeEntries]
(
	[timesheetid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Timesheets]') AND name = N'ix_periodaccountid')
CREATE NONCLUSTERED INDEX [ix_periodaccountid] ON [dbo].[Timesheets]
(
	[periodaccountid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Timesheets]') AND name = N'ix_rategroupid')
CREATE NONCLUSTERED INDEX [ix_rategroupid] ON [dbo].[Timesheets]
(
	[rategroupid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingPeriodAccounts_BillingAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]'))
ALTER TABLE [dbo].[BillingPeriodAccounts]  WITH CHECK ADD  CONSTRAINT [FK_BillingPeriodAccounts_BillingAccounts] FOREIGN KEY([accountid])
REFERENCES [dbo].[BillingAccounts] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingPeriodAccounts_BillingAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]'))
ALTER TABLE [dbo].[BillingPeriodAccounts] CHECK CONSTRAINT [FK_BillingPeriodAccounts_BillingAccounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingPeriodAccounts_BillingPeriods]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]'))
ALTER TABLE [dbo].[BillingPeriodAccounts]  WITH CHECK ADD  CONSTRAINT [FK_BillingPeriodAccounts_BillingPeriods] FOREIGN KEY([periodid])
REFERENCES [dbo].[BillingPeriods] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingPeriodAccounts_BillingPeriods]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingPeriodAccounts]'))
ALTER TABLE [dbo].[BillingPeriodAccounts] CHECK CONSTRAINT [FK_BillingPeriodAccounts_BillingPeriods]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingRates_BillingPeriodAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingRates]'))
ALTER TABLE [dbo].[BillingRates]  WITH CHECK ADD  CONSTRAINT [FK_BillingRates_BillingPeriodAccounts] FOREIGN KEY([periodaccountid])
REFERENCES [dbo].[BillingPeriodAccounts] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingRates_BillingPeriodAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingRates]'))
ALTER TABLE [dbo].[BillingRates] CHECK CONSTRAINT [FK_BillingRates_BillingPeriodAccounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingRates_RateGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingRates]'))
ALTER TABLE [dbo].[BillingRates]  WITH CHECK ADD  CONSTRAINT [FK_BillingRates_RateGroups] FOREIGN KEY([groupid])
REFERENCES [dbo].[RateGroups] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingRates_RateGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingRates]'))
ALTER TABLE [dbo].[BillingRates] CHECK CONSTRAINT [FK_BillingRates_RateGroups]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DefaultBillingRates_BillingAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]'))
ALTER TABLE [dbo].[DefaultBillingRates]  WITH CHECK ADD  CONSTRAINT [FK_DefaultBillingRates_BillingAccounts] FOREIGN KEY([accountid])
REFERENCES [dbo].[BillingAccounts] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DefaultBillingRates_BillingAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]'))
ALTER TABLE [dbo].[DefaultBillingRates] CHECK CONSTRAINT [FK_DefaultBillingRates_BillingAccounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DefaultBillingRates_RateGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]'))
ALTER TABLE [dbo].[DefaultBillingRates]  WITH CHECK ADD  CONSTRAINT [FK_DefaultBillingRates_RateGroups] FOREIGN KEY([groupid])
REFERENCES [dbo].[RateGroups] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DefaultBillingRates_RateGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[DefaultBillingRates]'))
ALTER TABLE [dbo].[DefaultBillingRates] CHECK CONSTRAINT [FK_DefaultBillingRates_RateGroups]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExpenseEntries_Timesheets]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExpenseEntries]'))
ALTER TABLE [dbo].[ExpenseEntries]  WITH CHECK ADD  CONSTRAINT [FK_ExpenseEntries_Timesheets] FOREIGN KEY([timesheetid])
REFERENCES [dbo].[Timesheets] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExpenseEntries_Timesheets]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExpenseEntries]'))
ALTER TABLE [dbo].[ExpenseEntries] CHECK CONSTRAINT [FK_ExpenseEntries_Timesheets]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TimeEntries_Timesheets]') AND parent_object_id = OBJECT_ID(N'[dbo].[TimeEntries]'))
ALTER TABLE [dbo].[TimeEntries]  WITH CHECK ADD  CONSTRAINT [FK_TimeEntries_Timesheets] FOREIGN KEY([timesheetid])
REFERENCES [dbo].[Timesheets] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TimeEntries_Timesheets]') AND parent_object_id = OBJECT_ID(N'[dbo].[TimeEntries]'))
ALTER TABLE [dbo].[TimeEntries] CHECK CONSTRAINT [FK_TimeEntries_Timesheets]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Timesheets_BillingPeriodAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Timesheets]'))
ALTER TABLE [dbo].[Timesheets]  WITH CHECK ADD  CONSTRAINT [FK_Timesheets_BillingPeriodAccounts] FOREIGN KEY([periodaccountid])
REFERENCES [dbo].[BillingPeriodAccounts] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Timesheets_BillingPeriodAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Timesheets]'))
ALTER TABLE [dbo].[Timesheets] CHECK CONSTRAINT [FK_Timesheets_BillingPeriodAccounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Timesheets_RateGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Timesheets]'))
ALTER TABLE [dbo].[Timesheets]  WITH CHECK ADD  CONSTRAINT [FK_Timesheets_RateGroups] FOREIGN KEY([rategroupid])
REFERENCES [dbo].[RateGroups] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Timesheets_RateGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Timesheets]'))
ALTER TABLE [dbo].[Timesheets] CHECK CONSTRAINT [FK_Timesheets_RateGroups]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_FixPeriodBillingRates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_FixPeriodBillingRates] AS' 
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_FixPeriodBillingRates]
	@PeriodID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @GroupID int;
	DECLARE @BillingPeriodAccountID int;
	DECLARE @AccountID int;

	DECLARE billingPeriodAccounts CURSOR READ_ONLY FOR
	SELECT id, accountid FROM BillingPeriodAccounts WHERE periodid=@PeriodID
	OPEN billingPeriodAccounts
	FETCH NEXT FROM billingPeriodAccounts INTO @BillingPeriodAccountID, @AccountID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		/*inner loop*/
		DECLARE rateGroupIDs CURSOR READ_ONLY FOR
		SELECT id FROM RateGroups
		OPEN rateGroupIDs
		FETCH NEXT FROM rateGroupIDs INTO @GroupID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			DECLARE @DefaultRate int;
			SET @DefaultRate = 0;
			IF ((SELECT COUNT(rate) FROM DefaultBillingRates WHERE accountid=@AccountID AND groupid=@GroupID)>0)
				SET @DefaultRate = (SELECT rate FROM DefaultBillingRates WHERE accountid=@AccountID AND groupid=@GroupID)
						
			
			IF NOT EXISTS (SELECT id FROM BillingRates WHERE periodaccountid=@BillingPeriodAccountID AND groupid=@GroupID)
				INSERT INTO BillingRates (periodaccountid, groupid, rate, isDeleted, CreatedOn, CreatedBy) VALUES (@BillingPeriodAccountID, @GroupID, @DefaultRate, 0, GetDate(), 'Server Process');

			FETCH NEXT FROM rateGroupIDs INTO @GroupID	
		END
		CLOSE rateGroupIDs
		DEALLOCATE rateGroupIDs
		/* end inner loop*/
		FETCH NEXT FROM billingPeriodAccounts INTO @BillingPeriodAccountID, @AccountID
	END
	CLOSE billingPeriodAccounts
	DEALLOCATE billingPeriodAccounts

END

GO
