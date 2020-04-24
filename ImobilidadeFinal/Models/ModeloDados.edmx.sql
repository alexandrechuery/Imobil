
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/24/2019 22:28:41
-- Generated from EDMX file: C:\Users\Davi Fernandes\Documents\ImobilidadeFinalV3\ImobilidadeFinal\ImobilidadeFinal\Models\ModeloDados.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ImovelBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Imovel__IdBairro__398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imovel] DROP CONSTRAINT [FK__Imovel__IdBairro__398D8EEE];
GO
IF OBJECT_ID(N'[dbo].[FK__Imovel__IdPropri__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imovel] DROP CONSTRAINT [FK__Imovel__IdPropri__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__Imovel__IdTipoIm__38996AB5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imovel] DROP CONSTRAINT [FK__Imovel__IdTipoIm__38996AB5];
GO
IF OBJECT_ID(N'[dbo].[FK__Negocio__IdImove__3E52440B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Negocio] DROP CONSTRAINT [FK__Negocio__IdImove__3E52440B];
GO
IF OBJECT_ID(N'[dbo].[FK__Negocio__IdTipoN__3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Negocio] DROP CONSTRAINT [FK__Negocio__IdTipoN__3F466844];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bairro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bairro];
GO
IF OBJECT_ID(N'[dbo].[Imovel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imovel];
GO
IF OBJECT_ID(N'[dbo].[Negocio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Negocio];
GO
IF OBJECT_ID(N'[dbo].[Proprietario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proprietario];
GO
IF OBJECT_ID(N'[dbo].[TipoImovel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoImovel];
GO
IF OBJECT_ID(N'[dbo].[TipoNegocio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoNegocio];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bairro'
CREATE TABLE [dbo].[Bairro] (
    [IdBairro] int IDENTITY(1,1) NOT NULL,
    [NomeBairro] varchar(30)  NOT NULL
);
GO

-- Creating table 'Imovel'
CREATE TABLE [dbo].[Imovel] (
    [IdImovel] int IDENTITY(1,1) NOT NULL,
    [Vagas] varchar(2)  NOT NULL,
    [Quartos] varchar(2)  NOT NULL,
    [Suite] varchar(2)  NOT NULL,
    [Area] varchar(10)  NOT NULL,
    [ValorTotal] varchar(15)  NOT NULL,
    [IdProprietario] int  NOT NULL,
    [IdBairro] int  NOT NULL,
    [IdTipoImovel] int  NOT NULL
);
GO

-- Creating table 'Negocio'
CREATE TABLE [dbo].[Negocio] (
    [Valor] varchar(30)  NOT NULL,
    [IdImovel] int  NOT NULL,
    [IdTipoNegocio] int  NOT NULL
);
GO

-- Creating table 'Proprietario'
CREATE TABLE [dbo].[Proprietario] (
    [IdProprietario] int IDENTITY(1,1) NOT NULL,
    [NomeProprietario] varchar(60)  NOT NULL,
    [Telefone] varchar(15)  NOT NULL,
    [N_Casa] varchar(4)  NOT NULL,
    [CEP] varchar(9)  NOT NULL
);
GO

-- Creating table 'TipoImovel'
CREATE TABLE [dbo].[TipoImovel] (
    [IdTipoImovel] int IDENTITY(1,1) NOT NULL,
    [NomeTipoImovel] varchar(30)  NOT NULL
);
GO

-- Creating table 'TipoNegocio'
CREATE TABLE [dbo].[TipoNegocio] (
    [IdTipoNegocio] int IDENTITY(1,1) NOT NULL,
    [NomeTipoNegocio] varchar(15)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdBairro] in table 'Bairro'
ALTER TABLE [dbo].[Bairro]
ADD CONSTRAINT [PK_Bairro]
    PRIMARY KEY CLUSTERED ([IdBairro] ASC);
GO

-- Creating primary key on [IdImovel] in table 'Imovel'
ALTER TABLE [dbo].[Imovel]
ADD CONSTRAINT [PK_Imovel]
    PRIMARY KEY CLUSTERED ([IdImovel] ASC);
GO

-- Creating primary key on [IdImovel], [IdTipoNegocio] in table 'Negocio'
ALTER TABLE [dbo].[Negocio]
ADD CONSTRAINT [PK_Negocio]
    PRIMARY KEY CLUSTERED ([IdImovel], [IdTipoNegocio] ASC);
GO

-- Creating primary key on [IdProprietario] in table 'Proprietario'
ALTER TABLE [dbo].[Proprietario]
ADD CONSTRAINT [PK_Proprietario]
    PRIMARY KEY CLUSTERED ([IdProprietario] ASC);
GO

-- Creating primary key on [IdTipoImovel] in table 'TipoImovel'
ALTER TABLE [dbo].[TipoImovel]
ADD CONSTRAINT [PK_TipoImovel]
    PRIMARY KEY CLUSTERED ([IdTipoImovel] ASC);
GO

-- Creating primary key on [IdTipoNegocio] in table 'TipoNegocio'
ALTER TABLE [dbo].[TipoNegocio]
ADD CONSTRAINT [PK_TipoNegocio]
    PRIMARY KEY CLUSTERED ([IdTipoNegocio] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdBairro] in table 'Imovel'
ALTER TABLE [dbo].[Imovel]
ADD CONSTRAINT [FK__Imovel__IdBairro__398D8EEE]
    FOREIGN KEY ([IdBairro])
    REFERENCES [dbo].[Bairro]
        ([IdBairro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Imovel__IdBairro__398D8EEE'
CREATE INDEX [IX_FK__Imovel__IdBairro__398D8EEE]
ON [dbo].[Imovel]
    ([IdBairro]);
GO

-- Creating foreign key on [IdProprietario] in table 'Imovel'
ALTER TABLE [dbo].[Imovel]
ADD CONSTRAINT [FK__Imovel__IdPropri__3A81B327]
    FOREIGN KEY ([IdProprietario])
    REFERENCES [dbo].[Proprietario]
        ([IdProprietario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Imovel__IdPropri__3A81B327'
CREATE INDEX [IX_FK__Imovel__IdPropri__3A81B327]
ON [dbo].[Imovel]
    ([IdProprietario]);
GO

-- Creating foreign key on [IdTipoImovel] in table 'Imovel'
ALTER TABLE [dbo].[Imovel]
ADD CONSTRAINT [FK__Imovel__IdTipoIm__38996AB5]
    FOREIGN KEY ([IdTipoImovel])
    REFERENCES [dbo].[TipoImovel]
        ([IdTipoImovel])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Imovel__IdTipoIm__38996AB5'
CREATE INDEX [IX_FK__Imovel__IdTipoIm__38996AB5]
ON [dbo].[Imovel]
    ([IdTipoImovel]);
GO

-- Creating foreign key on [IdImovel] in table 'Negocio'
ALTER TABLE [dbo].[Negocio]
ADD CONSTRAINT [FK__Negocio__IdImove__3E52440B]
    FOREIGN KEY ([IdImovel])
    REFERENCES [dbo].[Imovel]
        ([IdImovel])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdTipoNegocio] in table 'Negocio'
ALTER TABLE [dbo].[Negocio]
ADD CONSTRAINT [FK__Negocio__IdTipoN__3F466844]
    FOREIGN KEY ([IdTipoNegocio])
    REFERENCES [dbo].[TipoNegocio]
        ([IdTipoNegocio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Negocio__IdTipoN__3F466844'
CREATE INDEX [IX_FK__Negocio__IdTipoN__3F466844]
ON [dbo].[Negocio]
    ([IdTipoNegocio]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------