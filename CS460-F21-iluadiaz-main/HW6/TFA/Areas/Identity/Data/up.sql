CREATE TABLE [Athlete] (
  [ID]                  INT            PRIMARY KEY IDENTITY(1, 1),
  [FullName]            NVARCHAR(40)   NOT NULL,	
  [TeamID]              Int            NOT NULL	
)

CREATE TABLE [Coach] (
  [ID]                INT              PRIMARY KEY IDENTITY(1, 1),
  [FullName]          NVARCHAR(30)     NOT NULL
)

CREATE TABLE [TrackEvent] (
  [ID]               INT               PRIMARY KEY IDENTITY(1, 1),
  [Title]            NVARCHAR(30)      NOT NULL
)

CREATE TABLE [Location](
  [ID]                INT              PRIMARY KEY IDENTITY(1, 1),
  [MeetDate]          Date             NOT NULL,
  [Title]             NVARCHAR(50)     NOT NULL
)

CREATE TABLE [Classification](
  [ID]                INT              PRIMARY KEY IDENTITY(1, 1),
  [Name]              NVARCHAR(20)     NOT NULL
)

CREATE TABLE [Team](
  [ID]                INT              PRIMARY KEY IDENTITY(1, 1),
  [Name]              NVARCHAR(20)     NOT NULL,
  [CoachID]           INT              NOT NULL
)


CREATE TABLE [RaceResult] (
  [ID]                INT              PRIMARY KEY IDENTITY(1, 1),
  [Time]              FLOAT            NOT NULL,
  [AthleteID]         INT              NOT NULL,
  [ClassificationID]  INT              NOT NULL,
  [LocationID]        INT              NOT NULL,
  [EventID]           INT              NOT NULL
)
ALTER TABLE [RaceResult]    ADD CONSTRAINT  [RaceResults_FK_Athlete]            FOREIGN KEY ([AthleteID])           REFERENCES [Athlete]              ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [RaceResult]    ADD CONSTRAINT  [RaceResult_FK_Classification]      FOREIGN KEY ([ClassificationID])    REFERENCES [Classification]       ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [RaceResult]    ADD CONSTRAINT  [RaceResult_FK_TrackEvent]          FOREIGN KEY ([EventID])             REFERENCES [TrackEvent]           ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [RaceResult]    ADD CONSTRAINT  [RaceResult_FK_Location]            FOREIGN KEY ([LocationID])          REFERENCES [Location]             ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Team]          ADD CONSTRAINT  [Team_FK_Coach]                     FOREIGN KEY ([CoachID])             REFERENCES [Coach]                ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Athlete]       ADD CONSTRAINT  [Athlete_FK_Team]                   FOREIGN KEY ([TeamID])              REFERENCES [Team]                 ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

