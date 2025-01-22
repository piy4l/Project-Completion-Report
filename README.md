CREATE TABLE [dbo].[Projects] (
    [Id]                               INT            IDENTITY (1, 1) NOT NULL,
    [Name]                             NVARCHAR (MAX) NOT NULL,
    [AdministrativeMinistryDivision]   NVARCHAR (100) NULL,
    [ExecutingAgency]                  NVARCHAR (100) NULL,
    [PlanningCommissionSectorDivision] INT            NULL,
    [Type]                             NVARCHAR (50)  NULL,
    [OverallObjective]                 NVARCHAR (MAX) NULL,
    [SpecificObjectives]               NVARCHAR (MAX) NULL,
    [Background]                       NVARCHAR (MAX) NULL,
    [MajorActivities]                  NVARCHAR (MAX) NULL,
    [ReasonsForRevision]               NVARCHAR (MAX) NULL,
    [ReasonsForNoCostTimeExtension]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

