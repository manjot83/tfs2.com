BEGIN TRANSACTION

--SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON

--ALTER TABLE dbo.RateGroups SET (LOCK_ESCALATION = TABLE)
--GO

ALTER TABLE dbo.Timesheets DROP
    CONSTRAINT  FK_Timesheets_BillingPeriodAccounts
GO

ALTER TABLE [dbo].[ExpenseEntries] DROP 
    CONSTRAINT [FK_ExpenseEntries_Timesheets]
GO

ALTER TABLE dbo.TimeEntries DROP
     CONSTRAINT FK_TimeEntries_Timesheets
GO

--ALTER TABLE dbo.BillingPeriodAccounts SET (LOCK_ESCALATION = TABLE)
--GO

CREATE TABLE dbo.Tmp_Timesheets
	(
	id int NOT NULL IDENTITY (1, 1),
	username varchar(100) NOT NULL,
	periodaccountid int NOT NULL,
	perdiemcount int NOT NULL,
	IsDeleted bit NOT NULL DEFAULT (((0))),
	CreatedOn datetime NULL,
	CreatedBy nvarchar(50) NULL,
	ModifiedOn datetime NULL,
	ModifiedBy nvarchar(50) NULL,
	mileageclaimed float(53) NOT NULL DEFAULT (((0))),
	rategroupid int NOT NULL
	)  ON [PRIMARY]
GO

--ALTER TABLE dbo.Tmp_Timesheets SET (LOCK_ESCALATION = TABLE)
--GO

SET IDENTITY_INSERT dbo.Tmp_Timesheets ON
GO

IF EXISTS(SELECT * FROM dbo.Timesheets)
	 EXEC('INSERT INTO dbo.Tmp_Timesheets (id, username, periodaccountid, perdiemcount, IsDeleted, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, mileageclaimed,rategroupid)
		   SELECT Timesheets.id, Timesheets.username, periodaccountid, perdiemcount, IsDeleted, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, mileageclaimed, ISNULL(vw_Users.rategroup,4) as rategroupid
		   FROM dbo.Timesheets
		   LEFT OUTER JOIN vw_Users ON vw_Users.username = Timesheets.username')
GO

SET IDENTITY_INSERT dbo.Tmp_Timesheets OFF
GO

DROP TABLE dbo.Timesheets
GO

EXECUTE sp_rename N'dbo.Tmp_Timesheets', N'Timesheets', 'OBJECT' 
GO

ALTER TABLE dbo.Timesheets ADD 
    CONSTRAINT PK_Timesheets PRIMARY KEY CLUSTERED ( id ),
    CONSTRAINT FK_Timesheets_BillingPeriodAccounts FOREIGN KEY (periodaccountid) REFERENCES dbo.BillingPeriodAccounts (id),
    CONSTRAINT FK_Timesheets_RateGroups FOREIGN KEY (rategroupid) REFERENCES dbo.RateGroups (id)
GO

ALTER TABLE dbo.TimeEntries ADD CONSTRAINT
	FK_TimeEntries_Timesheets FOREIGN KEY (timesheetid) REFERENCES dbo.Timesheets (id)
GO

--ALTER TABLE dbo.TimeEntries SET (LOCK_ESCALATION = TABLE)
--GO

ALTER TABLE dbo.ExpenseEntries ADD 
    CONSTRAINT FK_ExpenseEntries_Timesheets FOREIGN KEY (timesheetid) REFERENCES dbo.Timesheets (id)	
GO

--ALTER TABLE dbo.ExpenseEntries SET (LOCK_ESCALATION = TABLE)
--GO

IF @@ERROR <> 0
 BEGIN
    ROLLBACK
    RETURN
 END

COMMIT
