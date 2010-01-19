CREATE TABLE dbo.Tmp_Users
	(
	Id UNIQUEIDENTIFIER NOT NULL,
	FirstName nvarchar(100) NOT NULL,
	LastName nvarchar(100) NOT NULL,
	DisplayName nvarchar(150) NOT NULL,
	Email nvarchar(254) NOT NULL,
	Username nvarchar(100) NOT NULL,
	[Disabled] bit NOT NULL,
	UserManagerRole bit NOT NULL,
	PersonnelManagerRole bit NOT NULL,
	ProgramManagerRole bit NOT NULL,
	FlightLogManagerRole bit NOT NULL
	) ON [PRIMARY]
GO

IF EXISTS(SELECT * FROM dbo.Users)
	 EXEC('INSERT INTO dbo.Tmp_Users (Id, FirstName, LastName, DisplayName, Email, Username, Disabled, UserManagerRole, PersonnelManagerRole, ProgramManagerRole, FlightLogManagerRole)
		SELECT Id, FirstName, LastName, DisplayName, Email, Username, Disabled, 0, 0, 0, 0 FROM dbo.Users WITH (HOLDLOCK TABLOCKX)')
GO

ALTER TABLE dbo.Persons
	DROP CONSTRAINT FK_Persons_Users
GO

DROP TABLE dbo.Users
GO

EXECUTE sp_rename N'dbo.Tmp_Users', N'Users', 'OBJECT' 
GO

ALTER TABLE dbo.Users ADD CONSTRAINT
	PK_Users PRIMARY KEY CLUSTERED (Id)
GO
ALTER TABLE dbo.Users ADD CONSTRAINT
	IX_Users_Username UNIQUE NONCLUSTERED (Username)
GO

ALTER TABLE dbo.Persons ADD CONSTRAINT
	FK_Persons_Users FOREIGN KEY (PersonId)
	REFERENCES dbo.Users (Id)
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[df_deleted]', @objname=N'[dbo].[Users].[Disabled]' , @futureonly='futureonly'
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[df_false]', @objname=N'[dbo].[Users].[UserManagerRole]' , @futureonly='futureonly'
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[df_false]', @objname=N'[dbo].[Users].[PersonnelManagerRole]' , @futureonly='futureonly'
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[df_false]', @objname=N'[dbo].[Users].[ProgramManagerRole]' , @futureonly='futureonly'
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[df_false]', @objname=N'[dbo].[Users].[FlightLogManagerRole]' , @futureonly='futureonly'
GO
