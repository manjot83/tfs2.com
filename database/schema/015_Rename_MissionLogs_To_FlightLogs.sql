ALTER TABLE Missions 
    DROP CONSTRAINT FK_Missions_MissionLogs
GO

ALTER TABLE SquadronLogs 
    DROP CONSTRAINT FK_SquadronLogs_MissionLogs
GO

ALTER TABLE FlightLogs
    DROP CONSTRAINT PK_MissionLogs
GO

EXEC sp_rename 'MissionLogs', 'FlightLogs';
GO

EXEC sp_rename '[Missions].[MissionLogId]', 'FlightLogId', 'COLUMN';
GO

EXEC sp_rename '[SquadronLogs].[MissionLogId]', 'FlightLogId', 'COLUMN';
GO

ALTER TABLE FlightLogs 
    ADD CONSTRAINT [PK_FlightLogs] 
    PRIMARY KEY CLUSTERED ([Id])
GO

ALTER TABLE Missions 
    ADD CONSTRAINT FK_Missions_FlightLogs
    FOREIGN KEY ([FlightLogId])
    REFERENCES FlightLogs
GO

ALTER TABLE SquadronLogs 
    ADD CONSTRAINT FK_SquadronLogs_FlightLogs
    FOREIGN KEY ([FlightLogId])
    REFERENCES FlightLogs
GO