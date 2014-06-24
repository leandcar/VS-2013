
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/20/2014 10:05:51
-- Generated from EDMX file: C:\Users\leandro.freitas\Downloads\WebApplicationMVC5Teste\WebApplicationMVC5Teste\Models\EntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [teste];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Carro_Modelo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carro] DROP CONSTRAINT [FK_Carro_Modelo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Carro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carro];
GO
IF OBJECT_ID(N'[dbo].[Modelo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modelo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Carro'
CREATE TABLE [dbo].[Carro] (
    [IDcarro] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NULL,
    [Ano] datetime  NULL,
    [IDmodelo] int  NOT NULL
);
GO

-- Creating table 'Modelo'
CREATE TABLE [dbo].[Modelo] (
    [IDmodelo] int IDENTITY(1,1) NOT NULL,
    [NomeModelo] varchar(50)  NULL,
    [Descricao] varchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDcarro] in table 'Carro'
ALTER TABLE [dbo].[Carro]
ADD CONSTRAINT [PK_Carro]
    PRIMARY KEY CLUSTERED ([IDcarro] ASC);
GO

-- Creating primary key on [IDmodelo] in table 'Modelo'
ALTER TABLE [dbo].[Modelo]
ADD CONSTRAINT [PK_Modelo]
    PRIMARY KEY CLUSTERED ([IDmodelo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDmodelo] in table 'Carro'
ALTER TABLE [dbo].[Carro]
ADD CONSTRAINT [FK_Carro_Modelo]
    FOREIGN KEY ([IDmodelo])
    REFERENCES [dbo].[Modelo]
        ([IDmodelo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Carro_Modelo'
CREATE INDEX [IX_FK_Carro_Modelo]
ON [dbo].[Carro]
    ([IDmodelo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------