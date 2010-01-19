/* Persons Table */

ALTER TABLE dbo.Persons
	DROP CONSTRAINT FK_Persons_Positions
GO

ALTER TABLE dbo.Persons
	DROP CONSTRAINT FK_Persons_Users
GO

CREATE TABLE dbo.Tmp_Persons
	(
	PersonId UNIQUEIDENTIFIER NOT NULL,
	StreetAddress nvarchar(100) NULL,
	City nvarchar(50) NULL,
	State nvarchar(2) NULL,
	ZipCode nvarchar(5) NULL,
	LastName nvarchar(50) NULL,
	FirstName nvarchar(50) NULL,
	MiddleInitial nvarchar(50) NULL,
	DateOfBirth datetime2(7) NULL,
	Gender int NULL,
	SocialSecurityLastFour nvarchar(4) NULL,
	PrimaryPhoneNumber nvarchar(10) NULL,
	AlternatePhoneNumber nvarchar(10) NULL,
	EmergencyContactName nvarchar(50) NULL,
	EmergencyContactPhoneNumber nvarchar(50) NULL,
	ShirtSize int NULL,
	FlightSuitSize int NULL,
	HirePositionId UNIQUEIDENTIFIER NULL,
	AlternateEmail nvarchar(254) NULL
	)  ON [PRIMARY]
GO

IF EXISTS(SELECT * FROM dbo.Persons)
	 EXEC('INSERT INTO dbo.Tmp_Persons (PersonId, StreetAddress, City, State, ZipCode, LastName, FirstName, MiddleInitial, DateOfBirth, Gender, SocialSecurityLastFour, PrimaryPhoneNumber, AlternatePhoneNumber, EmergencyContactName, EmergencyContactPhoneNumber, ShirtSize, FlightSuitSize, HirePositionId, AlternateEmail)
		SELECT PersonId, StreetAddress, City, State, ZipCode, LastName, FirstName, MiddleInitial, CONVERT(datetime2(7), DateOfBirth), Gender, SocialSecurityLastFour, PrimaryPhoneNumber, AlternatePhoneNumber, EmergencyContactName, EmergencyContactPhoneNumber, ShirtSize, FlightSuitSize, HirePositionId, AlternateEmail FROM dbo.Persons WITH (HOLDLOCK TABLOCKX)')
GO

ALTER TABLE dbo.Qualifications
	DROP CONSTRAINT FK_Qualifications_Person
GO

ALTER TABLE dbo.SquadronLogs
	DROP CONSTRAINT FK_SquadronLogs_Persons
GO

DROP TABLE dbo.Persons
GO

EXECUTE sp_rename N'dbo.Tmp_Persons', N'Persons', 'OBJECT' 
GO

ALTER TABLE dbo.Persons ADD CONSTRAINT
	PK_Persons PRIMARY KEY CLUSTERED 
	(PersonId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.Persons ADD CONSTRAINT FK_Persons_Users
    FOREIGN KEY (PersonId) 
    REFERENCES dbo.Users (Id)
	
GO

ALTER TABLE dbo.Persons ADD CONSTRAINT FK_Persons_Positions
    FOREIGN KEY (HirePositionId)
    REFERENCES dbo.Positions (Id)
GO

ALTER TABLE dbo.SquadronLogs ADD CONSTRAINT FK_SquadronLogs_Persons
    FOREIGN KEY (PersonId)
    REFERENCES dbo.Persons (PersonId)
GO

ALTER TABLE dbo.Qualifications ADD CONSTRAINT FK_Qualifications_Person 
	FOREIGN KEY (PersonId)
	REFERENCES dbo.Persons(PersonId)
GO

/* Qualifications Table */

ALTER TABLE dbo.Qualifications
	DROP CONSTRAINT FK_Qualifications_Person
GO

CREATE TABLE dbo.Tmp_Qualifications
	(
	PersonId UNIQUEIDENTIFIER NOT NULL,
	BranchOfService int NULL,
	MilitaryFCFQualification int NULL,
	LastAltitudeChamber datetime2(7) NULL,
	LastBFR datetime2(7) NULL,
	LastCRM datetime2(7) NULL,
	LastEgreesTraining datetime2(7) NULL,
	LastFlight datetime2(7) NULL,
	LastLifeSupportTraining datetime2(7) NULL,
	LastMilitaryFlightPhysical datetime2(7) NULL,
	LastSimulatorRefresher datetime2(7) NULL
	)  ON [PRIMARY]
GO

IF EXISTS(SELECT * FROM dbo.Qualifications)
	 EXEC('INSERT INTO dbo.Tmp_Qualifications (PersonId, BranchOfService, MilitaryFCFQualification, LastAltitudeChamber, LastBFR, LastCRM, LastEgreesTraining, LastFlight, LastLifeSupportTraining, LastMilitaryFlightPhysical, LastSimulatorRefresher)
		SELECT PersonId, BranchOfService, MilitaryFCFQualification, CONVERT(datetime2(7), LastAltitudeChamber), CONVERT(datetime2(7), LastBFR), CONVERT(datetime2(7), LastCRM), CONVERT(datetime2(7), LastEgreesTraining), CONVERT(datetime2(7), LastFlight), CONVERT(datetime2(7), LastLifeSupportTraining), CONVERT(datetime2(7), LastMilitaryFlightPhysical), CONVERT(datetime2(7), LastSimulatorRefresher) FROM dbo.Qualifications WITH (HOLDLOCK TABLOCKX)')
GO

ALTER TABLE dbo.QualificationsCertificates
	DROP CONSTRAINT FK_QualificationsCertificates_Qualifications
GO

DROP TABLE dbo.Qualifications
GO

EXECUTE sp_rename N'dbo.Tmp_Qualifications', N'Qualifications', 'OBJECT' 
GO

ALTER TABLE dbo.Qualifications ADD CONSTRAINT
	PK_Qualifications PRIMARY KEY CLUSTERED 
	(
	PersonId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.Qualifications ADD CONSTRAINT
	FK_Qualifications_Person FOREIGN KEY
	(
	PersonId
	) REFERENCES dbo.Persons
	(
	PersonId
	) 	
GO

ALTER TABLE dbo.QualificationsCertificates ADD CONSTRAINT
	FK_QualificationsCertificates_Qualifications FOREIGN KEY
	(
	PersonId
	) REFERENCES dbo.Qualifications
	(
	PersonId
	) 	
GO

/* Missions Table */

ALTER TABLE dbo.Missions
	DROP CONSTRAINT FK_Missions_MissionLogs
GO

CREATE TABLE dbo.Tmp_Missions
	(
	Id UNIQUEIDENTIFIER NOT NULL,
	Name nvarchar(50) NOT NULL,
	AdditionalInfo nvarchar(100) NULL,
	FromICAO nvarchar(4) NOT NULL,
	ToICAO nvarchar(4) NOT NULL,
	TakeOffTime datetime2(7) NOT NULL,
	LandTime datetime2(7) NOT NULL,
	TouchAndGos int NOT NULL,
	FullStops int NOT NULL,
	Sorties int NOT NULL,
	Totals int NOT NULL,
	MissionLogId UNIQUEIDENTIFIER NOT NULL,
	)  ON [PRIMARY]
GO

IF EXISTS(SELECT * FROM dbo.Missions)
	 EXEC('INSERT INTO dbo.Tmp_Missions (Id, Name, AdditionalInfo, FromICAO, ToICAO, TakeOffTime, LandTime, TouchAndGos, FullStops, Sorties, Totals, MissionLogId)
		SELECT Id, Name, AdditionalInfo, FromICAO, ToICAO, CONVERT(datetime2(7), TakeOffTime), CONVERT(datetime2(7), LandTime), TouchAndGos, FullStops, Sorties, Totals, MissionLogId FROM dbo.Missions WITH (HOLDLOCK TABLOCKX)')
GO

DROP TABLE dbo.Missions
GO

EXECUTE sp_rename N'dbo.Tmp_Missions', N'Missions', 'OBJECT' 
GO

ALTER TABLE dbo.Missions ADD CONSTRAINT
	PK_Missions PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.Missions ADD CONSTRAINT
	FK_Missions_MissionLogs FOREIGN KEY
	(
	MissionLogId
	) REFERENCES dbo.MissionLogs
	(
	Id
	) 	
GO

/* MissionLogs Table */

CREATE TABLE dbo.Tmp_MissionLogs
	(
	Id UNIQUEIDENTIFIER NOT NULL,
	CreatedDate datetime2(7) NOT NULL,
	LastModifiedDate datetime2(7) NOT NULL,
	Location nvarchar(100) NOT NULL,
	AircraftModel nvarchar(50) NOT NULL,
	AircraftSerialNumber nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO

IF EXISTS(SELECT * FROM dbo.MissionLogs)
	 EXEC('INSERT INTO dbo.Tmp_MissionLogs (Id, CreatedDate, LastModifiedDate, Location, AircraftModel, AircraftSerialNumber)
		SELECT Id, CONVERT(datetime2(7), CreatedDate), CONVERT(datetime2(7), LastModifiedDate), Location, AircraftModel, AircraftSerialNumber FROM dbo.MissionLogs WITH (HOLDLOCK TABLOCKX)')
GO

ALTER TABLE dbo.Missions
	DROP CONSTRAINT FK_Missions_MissionLogs
GO

ALTER TABLE dbo.SquadronLogs
	DROP CONSTRAINT FK_SquadronLogs_MissionLogs
GO

DROP TABLE dbo.MissionLogs
GO

EXECUTE sp_rename N'dbo.Tmp_MissionLogs', N'MissionLogs', 'OBJECT' 
GO

ALTER TABLE dbo.MissionLogs ADD CONSTRAINT
	PK_MissionLogs PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.SquadronLogs ADD CONSTRAINT
	FK_SquadronLogs_MissionLogs FOREIGN KEY
	(
	MissionLogId
	) REFERENCES dbo.MissionLogs
	(
	Id
	)
GO

ALTER TABLE dbo.Missions ADD CONSTRAINT
	FK_Missions_MissionLogs FOREIGN KEY
	(
	MissionLogId
	) REFERENCES dbo.MissionLogs
	(
	Id
	)
GO
