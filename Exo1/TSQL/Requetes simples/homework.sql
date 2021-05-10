-- Création de base de données : Article - Stock
-- Proc stockées : Ajout Article - Supprimer article
-- Application console ADO.Net Ajouter - Supprimer
USE [master]
GO
-- Database ---------------------------------------------------
CREATE DATABASE Exo_Article 
ON PRIMARY
	( 
	NAME = N'[Exo_Article]', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\[Exo_Article].mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB 
	)
 LOG ON 
	( 
	NAME = N'[Exo_Article]_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\[Exo_Article]_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB 
	)
GO
use Exo_Article
go
-- Article --------------------------------------------------
CREATE TABLE [dbo].[Article]
(
	[Id] [uniqueidentifier] NOT NULL,
	[Nom] [nvarchar](max) NOT NULL,
	[Prix] [decimal](18, 2) NOT NULL,
	CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED (	[Id] ASC)
) 
GO
ALTER TABLE [dbo].[Article] ADD  CONSTRAINT [DF_Article_Id]  DEFAULT (newid()) FOR [Id]
GO
-- Stock --------------------------------------------------
CREATE TABLE [dbo].[Stock](
	[Id] [uniqueidentifier] NOT NULL,
	[Article] [uniqueidentifier] NOT NULL,
	[Qte] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED (	[Id] ASC)
) 
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF_Stock_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF_Stock_Qte]  DEFAULT ((0)) FOR [Qte]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Article] FOREIGN KEY([Article]) REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Article]
GO

-- Proc : Article_Insert --------------------------------------
CREATE PROC Article_Insert(@id uniqueidentifier, @nom nvarchar(MAX), @prix decimal)
AS
  insert Article (Id, Nom, Prix) values(@id, @nom, @prix)
GO

--EXEC Article_Insert 'Clavier', 15 
--EXEC Article_Insert 'Souris', 10

GO

-- Proc : Stock_Insert --------------------------------------
CREATE PROC Stock_Insert(@article uniqueidentifier, @qte int)
AS
  insert Stock (Article, Qte) values(@article, @qte)
GO
--EXEC Stock_Insert '89146476-06E9-4D39-9628-D30CC9136B11', 200 

-- Proc : Article_Delete  --------------------------------------
CREATE PROC Article_Delete(@id uniqueidentifier)
AS
	IF NOT EXISTS(Select Id from Stock where Article=@id) 
		delete Article where Id=@id
GO
--Exec Article_Delete '1DBBDF4B-5B59-4EA7-A69D-84F7F62E0B26'

-- Proc : Stock_Delete  --------------------------------------
CREATE PROC Stock_Delete(@id uniqueidentifier=NULL, @article uniqueidentifier=NULL)
AS
	delete Stock where (Id IS NULL or Id=@id) and (@article IS NULL or  Article=@article)
GO
--Exec Stock_Delete '2FE51047-EB4C-457C-B8D3-A11AA1F6FA0B'
--Exec Stock_Delete NULL, '89146476-06E9-4D39-9628-D30CC9136B11'


--select * from Article
--select * from Stock

--select a.Nom, ISNULL(s.Qte, 0) Qte
--from Article a left outer join Stock s on s.Article = a.Id
