CREATE DATABASE [Racing];
GO

USE [Racing];
GO

CREATE TABLE [Tournament] (
    [TournamentId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Tournament] PRIMARY KEY ([TournamentId])
);
GO

CREATE TABLE [City] (
    [CityId] int NOT NULL IDENTITY,
    [TournamentId] int NOT NULL,
    [Name] nvarchar(max),
    [Description] nvarchar(max),
    CONSTRAINT [PK_City] PRIMARY KEY ([CityId]),
    CONSTRAINT [FK_City_Tournament_TournamentId] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament] ([TournamentId]) ON DELETE CASCADE
);
GO

INSERT INTO [Tournament] (Title) VALUES
('AVUS Berlin'),
('Silverstone Circuit'),
('Autodromo Nazionale Monza'),
('Autódromo Internacional Nelson Piquet Rio de Janeiro'),
('Bugatti Circuit Le Mans')
GO