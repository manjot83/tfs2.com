/* First make sure at least 1 ProgramLocation Exists */

DECLARE @flightProgramId UNIQUEIDENTIFIER

IF NOT EXISTS(SELECT * FROM [ProgramLocations])
    BEGIN
        INSERT INTO [FlightPrograms] ([Id],[Name],[AccountName],[Active])
               VALUES (NEWID(), 'Dummy Program', 'Dummy Program', 1)
        SET @flightProgramId = (SELECT TOP 1 [Id] FROM [FlightPrograms])
        INSERT INTO [ProgramLocations] ([Id], [Name],[FlightProgramId])
               VALUES (NEWID(), 'Dummy Location', @flightProgramId)
    END

/* Tmp Table */
CREATE TABLE [Tmp_FlightLogs](
	Id UNIQUEIDENTIFIER NOT NULL,
	[LogDate] [datetime2](7) NOT NULL,
	[LastModifiedDate] [datetime2](7) NOT NULL,
	[AircraftMDS] [nvarchar](50) NOT NULL,
	[AircraftSerialNumber] [nvarchar](50) NOT NULL,
	ProgramLocationId UNIQUEIDENTIFIER NOT NULL,
	)
GO


IF EXISTS(SELECT * FROM dbo.FlightLogs)
	 EXEC('INSERT INTO [Tmp_FlightLogs] (Id, LogDate, LastModifiedDate, AircraftMDS, AircraftSerialNumber, ProgramLocationId)
		SELECT Id, LogDate, LastModifiedDate, AircraftMDS, AircraftSerialNumber, 1 FROM [FlightLogs]')
GO


ALTER TABLE dbo.Missions
	DROP CONSTRAINT FK_Missions_FlightLogs
GO

ALTER TABLE dbo.SquadronLogs
	DROP CONSTRAINT FK_SquadronLogs_FlightLogs
GO

DROP TABLE dbo.FlightLogs
GO

EXECUTE sp_rename N'dbo.Tmp_FlightLogs', N'FlightLogs', 'OBJECT' 
GO

ALTER TABLE dbo.FlightLogs
    ADD CONSTRAINT PK_FlightLogs 
        PRIMARY KEY CLUSTERED (Id)
GO

ALTER TABLE dbo.SquadronLogs 
    ADD CONSTRAINT FK_SquadronLogs_FlightLogs
        FOREIGN KEY (FlightLogId)
        REFERENCES dbo.FlightLogs (Id)
GO

ALTER TABLE dbo.Missions 
    ADD CONSTRAINT FK_Missions_FlightLogs
        FOREIGN KEY (FlightLogId)
        REFERENCES dbo.FlightLogs (Id)
GO

ALTER TABLE FlightLogs 
        ADD CONSTRAINT FK_FlightLogs_ProgramLocations 
        FOREIGN KEY (ProgramLocationId) 
        REFERENCES ProgramLocations
GO