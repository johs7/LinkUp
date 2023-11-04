
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2023 19:20:48
-- Generated from EDMX file: C:\Users\Johan R\Desktop\LinkUp\LinkupEDM\AppModel\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Linkup];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Cuenta__IdClient__74AE54BC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuenta] DROP CONSTRAINT [FK__Cuenta__IdClient__74AE54BC];
GO
IF OBJECT_ID(N'[dbo].[FK__Envio__ClientesI__778AC167]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Envio] DROP CONSTRAINT [FK__Envio__ClientesI__778AC167];
GO
IF OBJECT_ID(N'[dbo].[FK__Envio__EstadoEnv__787EE5A0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Envio] DROP CONSTRAINT [FK__Envio__EstadoEnv__787EE5A0];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoCambi__Moned__7F2BE32F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoCambio] DROP CONSTRAINT [FK__TipoCambi__Moned__7F2BE32F];
GO
IF OBJECT_ID(N'[dbo].[FK_MonedaEnvio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Envio] DROP CONSTRAINT [FK_MonedaEnvio];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Cuenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuenta];
GO
IF OBJECT_ID(N'[dbo].[Envio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Envio];
GO
IF OBJECT_ID(N'[dbo].[EstadoEnvio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoEnvio];
GO
IF OBJECT_ID(N'[dbo].[Moneda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Moneda];
GO
IF OBJECT_ID(N'[dbo].[TipoCambio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCambio];
GO
IF OBJECT_ID(N'[Model1StoreContainer].[Admin]', 'U') IS NOT NULL
    DROP TABLE [Model1StoreContainer].[Admin];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Telefono] int  NOT NULL,
    [Cedula] nvarchar(16)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [Clave] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cuenta'
CREATE TABLE [dbo].[Cuenta] (
    [Id_Cuenta] int IDENTITY(1,1) NOT NULL,
    [NumeroCuenta] bigint  NOT NULL,
    [SaldoCuenta] decimal(7,2)  NOT NULL,
    [IdCliente] int  NOT NULL,
    [Predeterminada] bit  NOT NULL
);
GO

-- Creating table 'Envio'
CREATE TABLE [dbo].[Envio] (
    [Id_Envio] varchar(7)  NOT NULL,
    [Monto] decimal(7,2)  NOT NULL,
    [FechaEnvio] datetime  NOT NULL,
    [CodigoRemitente] varchar(7)  NOT NULL,
    [ClientesId] int  NOT NULL,
    [EstadoEnvio] int  NOT NULL,
    [MonedaId_Moneda] int  NOT NULL
);
GO

-- Creating table 'EstadoEnvio'
CREATE TABLE [dbo].[EstadoEnvio] (
    [Id_Estado] int IDENTITY(1,1) NOT NULL,
    [Estado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Moneda'
CREATE TABLE [dbo].[Moneda] (
    [Id_Moneda] int IDENTITY(1,1) NOT NULL,
    [TipoMoneda] varchar(15)  NOT NULL
);
GO

-- Creating table 'TipoCambio'
CREATE TABLE [dbo].[TipoCambio] (
    [Id_Cambio] int IDENTITY(1,1) NOT NULL,
    [CambioDia] decimal(7,2)  NOT NULL,
    [FechaCambio] datetime  NOT NULL,
    [MonedaId] int  NOT NULL
);
GO

-- Creating table 'Admin'
CREATE TABLE [dbo].[Admin] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [Contraseña] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id_Cuenta] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [PK_Cuenta]
    PRIMARY KEY CLUSTERED ([Id_Cuenta] ASC);
GO

-- Creating primary key on [Id_Envio] in table 'Envio'
ALTER TABLE [dbo].[Envio]
ADD CONSTRAINT [PK_Envio]
    PRIMARY KEY CLUSTERED ([Id_Envio] ASC);
GO

-- Creating primary key on [Id_Estado] in table 'EstadoEnvio'
ALTER TABLE [dbo].[EstadoEnvio]
ADD CONSTRAINT [PK_EstadoEnvio]
    PRIMARY KEY CLUSTERED ([Id_Estado] ASC);
GO

-- Creating primary key on [Id_Moneda] in table 'Moneda'
ALTER TABLE [dbo].[Moneda]
ADD CONSTRAINT [PK_Moneda]
    PRIMARY KEY CLUSTERED ([Id_Moneda] ASC);
GO

-- Creating primary key on [Id_Cambio] in table 'TipoCambio'
ALTER TABLE [dbo].[TipoCambio]
ADD CONSTRAINT [PK_TipoCambio]
    PRIMARY KEY CLUSTERED ([Id_Cambio] ASC);
GO

-- Creating primary key on [Id] in table 'Admin'
ALTER TABLE [dbo].[Admin]
ADD CONSTRAINT [PK_Admin]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCliente] in table 'Cuenta'
ALTER TABLE [dbo].[Cuenta]
ADD CONSTRAINT [FK__Cuenta__IdClient__74AE54BC]
    FOREIGN KEY ([IdCliente])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Cuenta__IdClient__74AE54BC'
CREATE INDEX [IX_FK__Cuenta__IdClient__74AE54BC]
ON [dbo].[Cuenta]
    ([IdCliente]);
GO

-- Creating foreign key on [ClientesId] in table 'Envio'
ALTER TABLE [dbo].[Envio]
ADD CONSTRAINT [FK__Envio__ClientesI__778AC167]
    FOREIGN KEY ([ClientesId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Envio__ClientesI__778AC167'
CREATE INDEX [IX_FK__Envio__ClientesI__778AC167]
ON [dbo].[Envio]
    ([ClientesId]);
GO

-- Creating foreign key on [EstadoEnvio] in table 'Envio'
ALTER TABLE [dbo].[Envio]
ADD CONSTRAINT [FK__Envio__EstadoEnv__787EE5A0]
    FOREIGN KEY ([EstadoEnvio])
    REFERENCES [dbo].[EstadoEnvio]
        ([Id_Estado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Envio__EstadoEnv__787EE5A0'
CREATE INDEX [IX_FK__Envio__EstadoEnv__787EE5A0]
ON [dbo].[Envio]
    ([EstadoEnvio]);
GO

-- Creating foreign key on [MonedaId] in table 'TipoCambio'
ALTER TABLE [dbo].[TipoCambio]
ADD CONSTRAINT [FK__TipoCambi__Moned__7F2BE32F]
    FOREIGN KEY ([MonedaId])
    REFERENCES [dbo].[Moneda]
        ([Id_Moneda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoCambi__Moned__7F2BE32F'
CREATE INDEX [IX_FK__TipoCambi__Moned__7F2BE32F]
ON [dbo].[TipoCambio]
    ([MonedaId]);
GO

-- Creating foreign key on [MonedaId_Moneda] in table 'Envio'
ALTER TABLE [dbo].[Envio]
ADD CONSTRAINT [FK_MonedaEnvio]
    FOREIGN KEY ([MonedaId_Moneda])
    REFERENCES [dbo].[Moneda]
        ([Id_Moneda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonedaEnvio'
CREATE INDEX [IX_FK_MonedaEnvio]
ON [dbo].[Envio]
    ([MonedaId_Moneda]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------