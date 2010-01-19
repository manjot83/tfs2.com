CREATE TABLE Positions (
    Id UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED ([Id])
    )
GO

CREATE TABLE Persons (
    PersonId UNIQUEIDENTIFIER NOT NULL,
    StreetAddress NVARCHAR(100) NULL,
    City NVARCHAR(50) NULL,
    [State] NVARCHAR(2) NULL,
    ZipCode NVARCHAR(5) NULL,
    LastName NVARCHAR(50) NULL,
    FirstName NVARCHAR(50) NULL,
    MiddleInitial NVARCHAR(50) NULL,
    DateOfBirth DATETIME NULL,
    Gender INT NULL,
    SocialSecurityNumberEnding NVARCHAR(4) NULL,
    PrimaryPhoneNumber NVARCHAR(10) NULL,
    AlternatePhoneNumber NVARCHAR(10) NULL,
    EmergencyContactName NVARCHAR(50) NULL,
    EmergencyContactPhoneNumber NVARCHAR(50) NULL,
    ShirtSize INT NULL,
    FlightSuitSize INT NULL,
    HirePositionId UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([PersonId])
    )
GO

CREATE TABLE Qualifications (
    PersonId UNIQUEIDENTIFIER NOT NULL,
    BranchOfService INT NULL,
    MilitaryFCFQualification INT NULL,
    LastAltitudeChamber DATETIME NULL,
    LastBFR DATETIME NULL,
    LastCRM DATETIME NULL,
    LastEgreesTraining DATETIME NULL,
    LastFlight DATETIME NULL,
    LastLifeSupportTraining DATETIME NULL,
    LastMilitaryFlightPhysical DATETIME NULL,
    LastSimulatorRefresher DATETIME NULL,
    CONSTRAINT [PK_Qualifications] PRIMARY KEY CLUSTERED ([PersonId])
    )
GO

CREATE TABLE [Certificates] (
    Id UNIQUEIDENTIFIER NOT NULL,
    [Type] INT NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Certificates] PRIMARY KEY CLUSTERED ([Id])
    )
GO

CREATE TABLE QualificationsCertificates (
    PersonId UNIQUEIDENTIFIER NOT NULL,
    CertificateId UNIQUEIDENTIFIER NOT NULL
    CONSTRAINT [PK_QualificationsCertificates] PRIMARY KEY CLUSTERED ([PersonId],[CertificateId])
    )
GO

ALTER TABLE Persons 
    ADD CONSTRAINT FK_Persons_Users
    FOREIGN KEY (PersonId)
    REFERENCES Users
GO

ALTER TABLE Persons 
    ADD CONSTRAINT FK_Persons_Positions
    FOREIGN KEY (HirePositionId)
    REFERENCES Positions
GO

ALTER TABLE Qualifications 
    ADD CONSTRAINT FK_Qualifications_Person
    FOREIGN KEY (PersonId)
    REFERENCES Persons
GO

ALTER TABLE QualificationsCertificates 
    ADD CONSTRAINT FK_QualificationsCertificates_Qualifications
    FOREIGN KEY (PersonId)
    REFERENCES Qualifications
GO

ALTER TABLE QualificationsCertificates 
    ADD CONSTRAINT FK_QualificationsCertificates_Certificates
    FOREIGN KEY (CertificateId)
    REFERENCES [Certificates]
GO
