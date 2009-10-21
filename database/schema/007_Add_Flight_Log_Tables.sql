CREATE TABLE MissionLogs (
   Id INT IDENTITY NOT NULL,
   CreatedDate DATETIME NOT NULL,
   LastModifiedDate DATETIME NOT NULL,
   Location NVARCHAR(100) NOT NULL,
   AircraftModel NVARCHAR(50) NOT NULL,
   AircraftSerialNumber NVARCHAR(50) NOT NULL,
   CONSTRAINT [PK_MissionLogs] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TABLE Missions (
   Id INT IDENTITY NOT NULL,
   Name NVARCHAR(50) NOT NULL,
   AdditionalInfo NVARCHAR(100) NOT NULL,
   FromICAO NVARCHAR(4) NOT NULL,
   ToICAO NVARCHAR(4) NOT NULL,
   TakeOffTime DATETIME NOT NULL,
   LandTime DATETIME NOT NULL,
   TouchAndGos INT NOT NULL,
   FullStops INT NOT NULL,
   Sorties INT NOT NULL,
   Totals INT NOT NULL,
   MissionLogId INT NOT NULL,
   CONSTRAINT [PK_Missions] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TABLE SquadronLogs (
   Id INT IDENTITY NOT NULL,
   DutyCode INT NOT NULL,
   PrimaryHours DOUBLE PRECISION NOT NULL,
   SecondaryHours DOUBLE PRECISION NOT NULL,
   InstructorHours DOUBLE PRECISION NOT NULL,
   EvaluatorHours DOUBLE PRECISION NOT NULL,
   OtherHours DOUBLE PRECISION NOT NULL,
   Sorties INT NOT NULL,
   PrimaryNightHours DOUBLE PRECISION NOT NULL,
   PrimaryInstrumentHours DOUBLE PRECISION NOT NULL,
   SimulatedInstrumentHours DOUBLE PRECISION NOT NULL,
   MissionLogId INT NOT NULL,
   PersonId INT NOT NULL,
   CONSTRAINT [PK_SquadronLogs] PRIMARY KEY CLUSTERED ([Id])
)
GO

ALTER TABLE Missions 
    ADD CONSTRAINT FK_Missions_MissionLogs
    FOREIGN KEY (MissionLogId)
    REFERENCES MissionLogs
GO

ALTER TABLE SquadronLogs 
    ADD CONSTRAINT FK_SquadronLogs_MissionLogs
    FOREIGN KEY (MissionLogId)
    REFERENCES MissionLogs
GO

ALTER TABLE SquadronLogs 
    ADD CONSTRAINT FK_SquadronLogs_Persons
    FOREIGN KEY (PersonId)
    REFERENCES Persons
GO