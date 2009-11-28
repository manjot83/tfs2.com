CREATE TABLE AircraftMDS (
   Id INT IDENTITY NOT NULL,
   Name NVARCHAR(50) NOT NULL,
   CONSTRAINT [PK_AircraftMDS] PRIMARY KEY CLUSTERED ([Id])
)

CREATE TABLE ProgramLocations (
   Id INT IDENTITY NOT NULL,
   Name NVARCHAR(100) NOT NULL,
   FlightProgramId INT NOT NULL,
   CONSTRAINT [PK_ProgramLocations] PRIMARY KEY CLUSTERED ([Id])
)

CREATE TABLE FlightPrograms (
   Id INT IDENTITY NOT NULL,
   Name NVARCHAR(50) NOT NULL,
   AccountName NVARCHAR(50) NOT NULL,
   Active BIT NOT NULL,
   CONSTRAINT [PK_FlightPrograms] PRIMARY KEY CLUSTERED ([Id])
)

ALTER TABLE ProgramLocations 
    ADD CONSTRAINT FK_ProgramLocations_FlightPrograms 
    FOREIGN KEY (FlightProgramId)
    REFERENCES FlightPrograms
GO

EXEC sys.sp_bindefault @defname=N'[dbo].[df_true]', @objname=N'[dbo].[FlightPrograms].[Active]' , @futureonly='futureonly'