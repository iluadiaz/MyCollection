
ALTER TABLE [RaceResult] DROP CONSTRAINT [RaceResult_FK_Athlete];
ALTER TABLE [RaceResult] DROP CONSTRAINT [RaceResult_FK_Classification];
ALTER TABLE [RaceResult] DROP CONSTRAINT [RaceResult_FK_TrackEvent];
ALTER TABLE [RaceResult] DROP CONSTRAINT [RaceResult_FK_Location];
ALTER TABLE [Team]       DROP CONSTRAINT [Team_FK_Coach];
ALTER TABLE [Athlete]    DROP CONSTRAINT [Athelte_FK_Team];

DROP TABLE [Athlete];
DROP TABLE [Coach];
DROP TABLE [TrackEvents];
DROP TABLE [Location];
DROP TABLE [Classification];
DROP TABLE [Team];
DROP TABLE [RaceResult];