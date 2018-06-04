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
('Adelaide Street Circuit'),
('Ain-Diab Circuit'),
('Aintree Motor Racing Circuit'),
('Autódromo do Estoril'),
('Autodromo Enzo e Dino Ferrari'),
('Autódromo Internacional Nelson Piquet'),
('Autódromo Internacional Nelson Piquet Rio de Janeiro'),
('Autódromo Juan y Oscar Gálvez'),
('Autodromo Nazionale Monza'),
('AVUS'),
('Brands Hatch'),
('Buddh International Circuit'),
('Bugatti Circuit Le Mans'),
('Caesars Palace Grand Prix Circuit'),
('Charade Circuit'),
('Circuit Bremgarten'),
('Circuito de Monsanto'),
('Circuit de Nevers Magny-Cours'),
('Circuit Mont-Tremblant'),
('Circuit Park Zandvoort'),
('Circuit Zolder'),
('Circuito da Boavista'),
('Circuito de Jerez'),
('Circuito del Jarama'),
('AVUS Berlin'),
('Silverstone Circuit')
GO