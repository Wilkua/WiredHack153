
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/20/2015 17:51:50
-- Generated from EDMX file: C:\Users\Justin\Documents\GitHubVisualStudio\WiredHack153\WiredHack.DAL\WiredHackModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WiredHack];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CareerClusters'
CREATE TABLE [dbo].[CareerClusters] (
    [CCId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JobCCConnections'
CREATE TABLE [dbo].[JobCCConnections] (
    [ConID] int IDENTITY(1,1) NOT NULL,
    [JobID] int  NOT NULL,
    [CCID] int  NOT NULL,
    [CareerCluster_CCId] int  NOT NULL
);
GO

-- Creating table 'Employers'
CREATE TABLE [dbo].[Employers] (
    [EmployerID] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Address2] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Zip] int  NOT NULL,
    [County] nvarchar(max)  NOT NULL,
    [IndustryID] nvarchar(max)  NOT NULL,
    [AmtOfEmployees] int  NOT NULL,
    [Logo] nvarchar(max)  NOT NULL,
    [Job_JobID] int  NOT NULL,
    [Industry_IndustryId] int  NOT NULL
);
GO

-- Creating table 'PayTypes'
CREATE TABLE [dbo].[PayTypes] (
    [PayTypeID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Job_JobID] int  NOT NULL
);
GO

-- Creating table 'Jobs'
CREATE TABLE [dbo].[Jobs] (
    [JobID] int IDENTITY(1,1) NOT NULL,
    [EmployerID] int  NOT NULL,
    [BaseSalary] nvarchar(max)  NOT NULL,
    [PayTypeID] int  NOT NULL,
    [JobCCConnection_ConID] int  NOT NULL,
    [EmployeeJobConnection_ConID] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [JobID] int  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Zip] int  NOT NULL,
    [County] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [ProgramID] int  NOT NULL,
    [UniversityID] int  NOT NULL,
    [MajorID] int  NOT NULL,
    [EmployeeJobConnection_ConID] int  NOT NULL,
    [Program_ProgramID] int  NOT NULL,
    [University_Id] int  NOT NULL,
    [Major_Id] int  NOT NULL
);
GO

-- Creating table 'EmployeeJobConnections'
CREATE TABLE [dbo].[EmployeeJobConnections] (
    [ConID] int IDENTITY(1,1) NOT NULL,
    [JobId] int  NOT NULL,
    [EmployeeID] int  NOT NULL,
    [PayRate] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL
);
GO

-- Creating table 'Industries'
CREATE TABLE [dbo].[Industries] (
    [IndustryId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Programs'
CREATE TABLE [dbo].[Programs] (
    [ProgramID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [MajorID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Universities'
CREATE TABLE [dbo].[Universities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Zip] nvarchar(max)  NOT NULL,
    [County] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Logo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Majors'
CREATE TABLE [dbo].[Majors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Program_ProgramID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CCId] in table 'CareerClusters'
ALTER TABLE [dbo].[CareerClusters]
ADD CONSTRAINT [PK_CareerClusters]
    PRIMARY KEY CLUSTERED ([CCId] ASC);
GO

-- Creating primary key on [ConID] in table 'JobCCConnections'
ALTER TABLE [dbo].[JobCCConnections]
ADD CONSTRAINT [PK_JobCCConnections]
    PRIMARY KEY CLUSTERED ([ConID] ASC);
GO

-- Creating primary key on [EmployerID] in table 'Employers'
ALTER TABLE [dbo].[Employers]
ADD CONSTRAINT [PK_Employers]
    PRIMARY KEY CLUSTERED ([EmployerID] ASC);
GO

-- Creating primary key on [PayTypeID] in table 'PayTypes'
ALTER TABLE [dbo].[PayTypes]
ADD CONSTRAINT [PK_PayTypes]
    PRIMARY KEY CLUSTERED ([PayTypeID] ASC);
GO

-- Creating primary key on [JobID] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [PK_Jobs]
    PRIMARY KEY CLUSTERED ([JobID] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ConID] in table 'EmployeeJobConnections'
ALTER TABLE [dbo].[EmployeeJobConnections]
ADD CONSTRAINT [PK_EmployeeJobConnections]
    PRIMARY KEY CLUSTERED ([ConID] ASC);
GO

-- Creating primary key on [IndustryId] in table 'Industries'
ALTER TABLE [dbo].[Industries]
ADD CONSTRAINT [PK_Industries]
    PRIMARY KEY CLUSTERED ([IndustryId] ASC);
GO

-- Creating primary key on [ProgramID] in table 'Programs'
ALTER TABLE [dbo].[Programs]
ADD CONSTRAINT [PK_Programs]
    PRIMARY KEY CLUSTERED ([ProgramID] ASC);
GO

-- Creating primary key on [Id] in table 'Universities'
ALTER TABLE [dbo].[Universities]
ADD CONSTRAINT [PK_Universities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Majors'
ALTER TABLE [dbo].[Majors]
ADD CONSTRAINT [PK_Majors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Job_JobID] in table 'Employers'
ALTER TABLE [dbo].[Employers]
ADD CONSTRAINT [FK_JobEmployer]
    FOREIGN KEY ([Job_JobID])
    REFERENCES [dbo].[Jobs]
        ([JobID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobEmployer'
CREATE INDEX [IX_FK_JobEmployer]
ON [dbo].[Employers]
    ([Job_JobID]);
GO

-- Creating foreign key on [Job_JobID] in table 'PayTypes'
ALTER TABLE [dbo].[PayTypes]
ADD CONSTRAINT [FK_JobPayTypes]
    FOREIGN KEY ([Job_JobID])
    REFERENCES [dbo].[Jobs]
        ([JobID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobPayTypes'
CREATE INDEX [IX_FK_JobPayTypes]
ON [dbo].[PayTypes]
    ([Job_JobID]);
GO

-- Creating foreign key on [CareerCluster_CCId] in table 'JobCCConnections'
ALTER TABLE [dbo].[JobCCConnections]
ADD CONSTRAINT [FK_CareerClusterJobCCConnection]
    FOREIGN KEY ([CareerCluster_CCId])
    REFERENCES [dbo].[CareerClusters]
        ([CCId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CareerClusterJobCCConnection'
CREATE INDEX [IX_FK_CareerClusterJobCCConnection]
ON [dbo].[JobCCConnections]
    ([CareerCluster_CCId]);
GO

-- Creating foreign key on [JobCCConnection_ConID] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobCCConnectionJob]
    FOREIGN KEY ([JobCCConnection_ConID])
    REFERENCES [dbo].[JobCCConnections]
        ([ConID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobCCConnectionJob'
CREATE INDEX [IX_FK_JobCCConnectionJob]
ON [dbo].[Jobs]
    ([JobCCConnection_ConID]);
GO

-- Creating foreign key on [EmployeeJobConnection_ConID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeJobConnectionEmployee]
    FOREIGN KEY ([EmployeeJobConnection_ConID])
    REFERENCES [dbo].[EmployeeJobConnections]
        ([ConID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeJobConnectionEmployee'
CREATE INDEX [IX_FK_EmployeeJobConnectionEmployee]
ON [dbo].[Employees]
    ([EmployeeJobConnection_ConID]);
GO

-- Creating foreign key on [EmployeeJobConnection_ConID] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_EmployeeJobConnectionJob]
    FOREIGN KEY ([EmployeeJobConnection_ConID])
    REFERENCES [dbo].[EmployeeJobConnections]
        ([ConID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeJobConnectionJob'
CREATE INDEX [IX_FK_EmployeeJobConnectionJob]
ON [dbo].[Jobs]
    ([EmployeeJobConnection_ConID]);
GO

-- Creating foreign key on [Industry_IndustryId] in table 'Employers'
ALTER TABLE [dbo].[Employers]
ADD CONSTRAINT [FK_IndustryEmployer]
    FOREIGN KEY ([Industry_IndustryId])
    REFERENCES [dbo].[Industries]
        ([IndustryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustryEmployer'
CREATE INDEX [IX_FK_IndustryEmployer]
ON [dbo].[Employers]
    ([Industry_IndustryId]);
GO

-- Creating foreign key on [Program_ProgramID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_ProgramEmployee]
    FOREIGN KEY ([Program_ProgramID])
    REFERENCES [dbo].[Programs]
        ([ProgramID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramEmployee'
CREATE INDEX [IX_FK_ProgramEmployee]
ON [dbo].[Employees]
    ([Program_ProgramID]);
GO

-- Creating foreign key on [University_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_UniversityEmployee]
    FOREIGN KEY ([University_Id])
    REFERENCES [dbo].[Universities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UniversityEmployee'
CREATE INDEX [IX_FK_UniversityEmployee]
ON [dbo].[Employees]
    ([University_Id]);
GO

-- Creating foreign key on [Major_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_MajorEmployee]
    FOREIGN KEY ([Major_Id])
    REFERENCES [dbo].[Majors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MajorEmployee'
CREATE INDEX [IX_FK_MajorEmployee]
ON [dbo].[Employees]
    ([Major_Id]);
GO

-- Creating foreign key on [Program_ProgramID] in table 'Majors'
ALTER TABLE [dbo].[Majors]
ADD CONSTRAINT [FK_ProgramMajor]
    FOREIGN KEY ([Program_ProgramID])
    REFERENCES [dbo].[Programs]
        ([ProgramID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramMajor'
CREATE INDEX [IX_FK_ProgramMajor]
ON [dbo].[Majors]
    ([Program_ProgramID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------