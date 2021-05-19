USE [master]
GO
CREATE DATABASE [EvalBD]
 ON  PRIMARY 
( NAME = N'EvalBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EvalBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EvalBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EvalBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
use EvalBD
CREATE TABLE [dbo].[Personne]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NOT NULL,
	[Prenom] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO
CREATE TABLE [dbo].Ville
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Ville] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

