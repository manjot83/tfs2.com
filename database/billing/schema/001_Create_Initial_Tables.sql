CREATE TABLE [dbo].[BillingAccounts] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [defaultperdiemrate] [float] NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [defaultmileagerate] [float] NOT NULL DEFAULT (((0)))
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BillingPeriodAccounts] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [periodid] [int] NOT NULL,
  [accountid] [int] NOT NULL,
  [perdiemrate] [float] NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [mileagerate] [float] NOT NULL DEFAULT (((0)))
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BillingPeriods] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [month] [int] NOT NULL,
  [year] [int] NOT NULL,
  [openuntil] [datetime] NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BillingRates] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [periodaccountid] [int] NOT NULL,
  [groupid] [int] NOT NULL,
  [rate] [float] NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DefaultBillingRates] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [accountid] [int] NOT NULL,
  [groupid] [int] NOT NULL,
  [rate] [float] NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ExpenseEntries] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [timesheetid] [int] NOT NULL,
  [expensedate] [datetime] NOT NULL,
  [cost] [float] NOT NULL,
  [expensedesc] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[RateGroups] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[TimeEntries] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [timesheetid] [int] NOT NULL,
  [day] [int] NOT NULL,
  [timein] [char] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [timeout] [char] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Timesheets] (
  [id] [int] IDENTITY (1,1) NOT NULL,
  [username] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [periodaccountid] [int] NOT NULL,
  [perdiemcount] [int] NOT NULL,
  [IsDeleted] [bit] NOT NULL DEFAULT (((0))),
  [CreatedOn] [datetime] NULL,
  [CreatedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ModifiedOn] [datetime] NULL,
  [ModifiedBy] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [mileageclaimed] [float] NOT NULL DEFAULT (((0)))
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tmp_Users] (

  [id] [int] IDENTITY (1,1) NOT NULL,
  [username] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [firstname] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [lastname] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [title] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [rategroup] [int] NOT NULL
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[BillingAccounts] WITH NOCHECK ADD
  CONSTRAINT [PK_BillingAccounts] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillingPeriodAccounts] WITH NOCHECK ADD
  CONSTRAINT [PK_BillingPeriodAccounts] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillingPeriods] WITH NOCHECK ADD
  CONSTRAINT [PK_BillingPeriods] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillingRates] WITH NOCHECK ADD
  CONSTRAINT [PK_BillingRates] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[DefaultBillingRates] WITH NOCHECK ADD
  CONSTRAINT [PK_DefaultBillingRates] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExpenseEntries] WITH NOCHECK ADD
  CONSTRAINT [PK_ExpenseEntries] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[RateGroups] WITH NOCHECK ADD
  CONSTRAINT [PK_RateGroups] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[TimeEntries] WITH NOCHECK ADD
  CONSTRAINT [PK_TimeEntries] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[Timesheets] WITH NOCHECK ADD
  CONSTRAINT [PK_Timesheets] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tmp_Users] WITH NOCHECK ADD
  CONSTRAINT [PK_Tmp_Users] PRIMARY KEY CLUSTERED ([id]) WITH FILLFACTOR = 90 ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillingPeriodAccounts] ADD
  CONSTRAINT [FK_BillingPeriodAccounts_BillingAccounts] FOREIGN KEY ([accountid]) REFERENCES [dbo].[BillingAccounts] ([id]),
  CONSTRAINT [FK_BillingPeriodAccounts_BillingPeriods] FOREIGN KEY ([periodid]) REFERENCES [dbo].[BillingPeriods] ([id])
GO
ALTER TABLE [dbo].[BillingRates] ADD
  CONSTRAINT [FK_BillingRates_BillingPeriodAccounts] FOREIGN KEY ([periodaccountid]) REFERENCES [dbo].[BillingPeriodAccounts] ([id]),
  CONSTRAINT [FK_BillingRates_RateGroups] FOREIGN KEY ([groupid]) REFERENCES [dbo].[RateGroups] ([id])
GO
ALTER TABLE [dbo].[DefaultBillingRates] ADD
  CONSTRAINT [FK_DefaultBillingRates_BillingAccounts] FOREIGN KEY ([accountid]) REFERENCES [dbo].[BillingAccounts] ([id]),
  CONSTRAINT [FK_DefaultBillingRates_RateGroups] FOREIGN KEY ([groupid]) REFERENCES [dbo].[RateGroups] ([id])
GO
ALTER TABLE [dbo].[ExpenseEntries] ADD
  CONSTRAINT [FK_ExpenseEntries_Timesheets] FOREIGN KEY ([timesheetid]) REFERENCES [dbo].[Timesheets] ([id])
GO
ALTER TABLE [dbo].[TimeEntries] ADD
  CONSTRAINT [FK_TimeEntries_Timesheets] FOREIGN KEY ([timesheetid]) REFERENCES [dbo].[Timesheets] ([id])
GO
ALTER TABLE [dbo].[Timesheets] ADD
  CONSTRAINT [FK_Timesheets_BillingPeriodAccounts] FOREIGN KEY ([periodaccountid]) REFERENCES [dbo].[BillingPeriodAccounts] ([id])
GO