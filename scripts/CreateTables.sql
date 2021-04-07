
--SUBJECT SCHEMA
CREATE TABLE [Subject].DOBSource
(
    SourceID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SourceName NVARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE [Subject].EthnicGroup
(
    EthnicGroupID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE [Subject].[Subject]
(
    SubjectID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    EthnicGroupID INT NOT NULL FOREIGN KEY
        REFERENCES [Subject].EthnicGroup(EthnicGroupID),
    OAHeLPID NVARCHAR(6) NOT NULL UNIQUE,
    DOB DATE NULL,
    DOBSourceID INT NULL FOREIGN KEY
        REFERENCES [Subject].DOBSource(SourceID),
    Sex CHAR(1) NOT NULL,
    ICNumber NVARCHAR(20) NULL, --UNIQUE
    PhotoFileName NVARCHAR(30) NULL, --UNIQUE
    MotherID INT NULL FOREIGN KEY 
        REFERENCES [Subject].[Subject](SubjectID),
    FatherID INT NULL FOREIGN KEY 
        REFERENCES [Subject].[Subject](SubjectID),
    
    CONSTRAINT CHK_Subject_Sex
        CHECK(Sex IN ('M','F'))
);

CREATE TABLE [Subject].Residence
(
    SubjectID INT NOT NULL FOREIGN KEY 
        REFERENCES [Subject].[Subject](SubjectID),
    [Date] DATE NOT NULL,
    VillageID INT NOT NULL

    CONSTRAINT PK_Residence
        PRIMARY KEY(SubjectID, Date)
);

CREATE TABLE [Subject].[Name]
(
    NameID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(15) NOT NULL,
    MiddleNames NVARCHAR(40) NOT NULL DEFAULT(''),
    LastName NVARCHAR(15) NOT NULL DEFAULT('')
);

CREATE TABLE [Subject].[SubjectName]
(
    SubjectID INT NOT NULL FOREIGN KEY
        REFERENCES [Subject].[Subject](SubjectID),
    NameID INT NOT NULL FOREIGN KEY
        REFERENCES [Subject].[Name](NameID)

    CONSTRAINT PK_SubjectName
        PRIMARY KEY(SubjectID, NameID)
);

CREATE TABLE [Subject].Marriage
(
    SubjectID INT NOT NULL FOREIGN KEY  
        REFERENCES [Subject].[Subject](SubjectID),
    [Date] DATE NOT NULL,
    SpouseID INT NOT NULL FOREIGN KEY
        REFERENCES [Subject].[Subject](SubjectID),
    YearsMarried INT NULL

    CONSTRAINT PK_Marriage
        PRIMARY KEY(SubjectID, [Date])
);

CREATE TABLE [Subject].Village
(
    VillageID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(20) NOT NULL UNIQUE,
    GPSLatitude DECIMAL(10,6) NOT NULL,
    GPSLongitude DECIMAL(10,6) NOT NULL,
    EthnicGroup INT NOT NULL FOREIGN KEY
        REFERENCES [Subject].EthnicGroup(EthnicGroupID),
    HasRunningWater BIT NULL,
    HasElectricity BIT NULL,
    HasSchool BIT NULL,
    DistanceToMarket INT NULL

    UNIQUE(
        GPSLatitude,
        GPSLongitude
    )
);

--CLINIC SCHEMA
CREATE TABLE Clinic.Clinician(
    ClinicianID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(20) NULL,
    LastName NVARCHAR(20) NOT NULL,
    Code NVARCHAR(4) NOT NULL UNIQUE
);

CREATE TABLE Clinic.Medication(
    MedID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(30)
);

CREATE TABLE Clinic.SubstanceUse(
    SubstanceUseID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Description] NVARCHAR(20) UNIQUE 
);

CREATE TABLE Clinic.Clinic
(
    ClinicID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SiteName NVARCHAR(20) NOT NULL,
    DateStarted DATE NOT NULL,
    DateCompleted DATE NOT NULL

    UNIQUE(
        SiteName,
        DateStarted,
        DateCompleted
    )
);

CREATE TABLE Clinic.VillageSite(
    SiteName NVARCHAR(25) NOT NULL,
    VillageID INT NOT NULL FOREIGN KEY 
        REFERENCES [Subject].Village(VillageID),
    
    CONSTRAINT PK_VillageSite
        PRIMARY KEY(SiteName, VillageID)
);

CREATE TABLE Clinic.ClinicVisit(
    ClinicVisitID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Date] DATE NOT NULL,
    ClinicID INT NOT NULL FOREIGN KEY   
        REFERENCES Clinic.Clinic(ClinicID),
    RecordID INT NOT NULL,
    SubjectID INT NOT NULL FOREIGN KEY  
        REFERENCES [Subject].[Subject](SubjectID),
    ClinicianID INT NOT NULL FOREIGN KEY    
        REFERENCES Clinic.Clinician(ClinicianID),
    BodyTempDegC DECIMAL(4,2) NOT NULL,
    WeightKG DECIMAL(4,2) NOT NULL,
    PercentBodyFat DECIMAL(4,2) NULL,
    HeightCM DECIMAL(4,2) NOT NULL,
    WaistCircumferenceCM DECIMAL(4,2) NULL,
    LegLengthCM DECIMAL(4,2) NULL,
    Pulse INT NULL,
    BloodPressureSystolic INT NULL,
    BloodPressureDiastolic INT NULL,
    VisualAcuity INT NULL,
    WBCCount INT NULL,
    IsPregnant BIT NOT NULL,
    TobaccoUse INT NULL FOREIGN KEY 
        REFERENCES Clinic.SubstanceUse(SubstanceUseID),
    AlcoholUse INT NULL FOREIGN KEY 
        REFERENCES Clinic.SubstanceUse(SubstanceUseID),
    NumberLivingChildren INT NOT NULL,
    NumberDeceasedChildren INT NULL,
    NumberMiscarriages INT NULL,
    IsFatherAlive BIT NULL,
    IsMotherAlive BIT NULL,
    XRayImageFile NVARCHAR(30) NULL UNIQUE,
    HandImageFile NVARCHAR(30) NULL UNIQUE, 

    UNIQUE(
        [Date],
        RecordID
    ),
    UNIQUE(
        [Date],
        SubjectID
    )
);

CREATE TABLE Clinic.Diagnosis(
    ClinicVisitID INT NOT NULL FOREIGN KEY  
        REFERENCES Clinic.ClinicVisit(ClinicVisitID),
    ICD10Code NVARCHAR(10) NOT NULL

    CONSTRAINT PK_Diagnosis
        PRIMARY KEY(ClinicVisitID, ICD10Code)
);

CREATE TABLE Clinic.Prescription(
    MedID INT NOT NULL FOREIGN KEY 
        REFERENCES Clinic.Medication(MedID),
    ClinicVisitID INT NOT NULL FOREIGN KEY 
        REFERENCES Clinic.ClinicVisit(ClinicVisitID),
    Amount INT NOT NULL,
    Units NVARCHAR(10)
);