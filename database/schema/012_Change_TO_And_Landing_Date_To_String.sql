ALTER TABLE dbo.Missions
	DROP CONSTRAINT FK_Missions_MissionLogs
GO

CREATE TABLE dbo.Tmp_Missions
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	AdditionalInfo nvarchar(100) NULL,
	FromICAO nvarchar(4) NOT NULL,
	ToICAO nvarchar(4) NOT NULL,
	TakeOffTime nvarchar(4) NOT NULL,
	LandingTime nvarchar(4) NOT NULL,
	TouchAndGos int NOT NULL,
	FullStops int NOT NULL,
	Sorties int NOT NULL,
	Totals int NOT NULL,
	MissionLogId int NOT NULL
	)  ON [PRIMARY]
GO

SET IDENTITY_INSERT dbo.Tmp_Missions ON
GO

IF EXISTS(SELECT * FROM dbo.Missions)
	 EXEC('INSERT INTO dbo.Tmp_Missions (Id, Name, AdditionalInfo, FromICAO, ToICAO, TakeOffTime, LandingTime, TouchAndGos, FullStops, Sorties, Totals, MissionLogId)
		SELECT Id, Name, AdditionalInfo, FromICAO, ToICAO, CONVERT(nvarchar(4), TakeOffTime), CONVERT(nvarchar(4), LandingTime), TouchAndGos, FullStops, Sorties, Totals, MissionLogId FROM dbo.Missions WITH (HOLDLOCK TABLOCKX)')
GO

SET IDENTITY_INSERT dbo.Tmp_Missions OFF
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
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
