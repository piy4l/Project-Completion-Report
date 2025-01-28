## Creating the Tables:

CREATE TABLE [dbo].[_06LocationOfTheProject] (
    [Id]                          INT           NOT NULL,
    [ProjectId]                   INT           NOT NULL,
    [Division]                    VARCHAR (50)  NULL,
    [District]                    NVARCHAR (50) NULL,
    [CityCorpMunicipalityUpazila] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_07EstimatedCostPeriodApproval] (
    [Id]                   INT           NOT NULL,
    [ProjectId]            INT           NOT NULL,
    [Subject]              NVARCHAR (50) NULL,
    [Total]                NVARCHAR (50) NULL,
    [GOB]                  NVARCHAR (50) NULL,
    [PA]                   NVARCHAR (50) NULL,
    [SelfFinance]          NVARCHAR (50) NULL,
    [ImplementationPeriod] NVARCHAR (50) NULL,
    [DateOfApproval]       NVARCHAR (50) NULL,
    [ApprovedBy]           NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_12.1aStatusOfLoanGrantForeignFinancing] (
    [Id]                     INT           NOT NULL,
    [ProjectId]              INT           NOT NULL,
    [Source]                 NVARCHAR (50) NULL,
    [CurrencyAsPerAgreement] NVARCHAR (50) NULL,
    [AmountInUSD]            NVARCHAR (50) NULL,
    [Nature]                 NVARCHAR (50) NULL,
    [DateOfAgreement]        NVARCHAR (50) NULL,
    [DateOfEffectiveness]    NVARCHAR (50) NULL,
    [OriginalDateOfClosing]  NVARCHAR (50) NULL,
    [RevisedDateOfClosing]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_12.1bStatusOfLoanGrantGOB] (
    [Id]                  INT           NOT NULL,
    [ProjectId]           INT           NOT NULL,
    [TotalAmount]         NVARCHAR (50) NULL,
    [Loan]                NVARCHAR (50) NULL,
    [Grant]               NVARCHAR (50) NULL,
    [CashForeignExchange] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_12.1cStatusOfLoanGrantSelfFinanceEquity] (
    [Id]                  INT           NOT NULL,
    [ProjectId]           INT           NOT NULL,
    [TotalAmount]         NVARCHAR (50) NULL,
    [SelfFinance]         NVARCHAR (50) NULL,
    [Equity]              NVARCHAR (50) NULL,
    [CashForeignExchange] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_12.2UtilizationOfProjectAid] (
    [Id]                               INT           NOT NULL,
    [ProjectId]                        INT           NOT NULL,
    [Source]                           NVARCHAR (50) NULL,
    [TotalAmountInUSD]                 NVARCHAR (50) NULL,
    [TotalAmountInLocalCurrency]       NVARCHAR (50) NULL,
    [ActualExpenditureInUSD]           NVARCHAR (50) NULL,
    [ActualExpenditureInLocalCurrency] NVARCHAR (50) NULL,
    [UnutilizedAmountInUSD]            NVARCHAR (50) NULL,
    [UnutilizedAmountInLocalCurrency]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_12.3ReimbursableProjectAid] (
    [Id]                      INT            NOT NULL,
    [ProjectId]               INT            NOT NULL,
    [Source]                  NVARCHAR (50)  NULL,
    [RPAAmountAsPerPD]        NVARCHAR (50)  NULL,
    [RPAAmountAsPerAgreement] NVARCHAR (50)  NULL,
    [AmountSpent]             NVARCHAR (50)  NULL,
    [AmountClaimed]           NVARCHAR (50)  NULL,
    [AmountReimbursed]        NVARCHAR (50)  NULL,
    [Remarks]                 NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_13ImplementationPeriod] (
    [Id]                   INT            NOT NULL,
    [ProjectId]            INT            NOT NULL,
    [Original]             NVARCHAR (50)  NULL,
    [LatestRevised]        NVARCHAR (50)  NULL,
    [ActualImplementation] NVARCHAR (50)  NULL,
    [TimeOverRun]          NVARCHAR (50)  NULL,
    [Remarks]              NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_14CostOfTheProject] (
    [Id]                         INT            NOT NULL,
    [ProjectId]                  INT            NOT NULL,
    [Description]                NVARCHAR (MAX) NULL,
    [OriginalEstimatedCost]      NVARCHAR (50)  NULL,
    [LatestRevisedEstimatedCost] NVARCHAR (50)  NULL,
    [ActualExpenditure]          NVARCHAR (50)  NULL,
    [CostOverRun]                NVARCHAR (50)  NULL,
    [Remarks]                    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_15InfoProjectDirectors] (
    [Id]                               INT            NOT NULL,
    [ProjectId]                        INT            NOT NULL,
    [NameAndDetails]                   NVARCHAR (MAX) NULL,
    [FullTime]                         NVARCHAR (50)  NULL,
    [PartTime]                         NVARCHAR (50)  NULL,
    [ResponsibleForMoreThanOneProject] NVARCHAR (50)  NULL,
    [Joining]                          DATE           NULL,
    [Transfer]                         DATE           NULL,
    [Remarks]                          NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_16.1PersonnelOfPIU] (
    [Id]                           INT           NOT NULL,
    [ProjectId]                    INT           NOT NULL,
    [NameOfPost]                   NVARCHAR (50) NULL,
    [ApprovedStrength]             NVARCHAR (50) NULL,
    [EmployedDuringImplementation] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_16.2PersonnelRequiredAfterCompletion] (
    [Id]                    INT            NOT NULL,
    [ProjectId]             INT            NOT NULL,
    [NameOfPost]            NVARCHAR (50)  NULL,
    [Number]                NVARCHAR (50)  NULL,
    [Recruited]             NVARCHAR (50)  NULL,
    [ReasonForNotRecruited] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_16Personnel] (
    [Id]                                INT           NOT NULL,
    [ProjectId]                         INT           NOT NULL,
    [TotalNameOfPostGrade]              NVARCHAR (50) NULL,
    [TotalApprovedStrength]             NVARCHAR (50) NULL,
    [TotalEmployedDuringImplementation] NVARCHAR (50) NULL,
    [TotalNameOfPost]                   NVARCHAR (50) NULL,
    [TotalNumber]                       NVARCHAR (50) NULL,
    [TotalRecruited]                    NVARCHAR (50) NULL,
    [TotalReasonForNotRecruited]        NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_17TrainingForeignLocal] (
    [Id]                     INT           NOT NULL,
    [ProjectId]              INT           NOT NULL,
    [Category]               NVARCHAR (50) NULL,
    [SlNo]                   NVARCHAR (50) NULL,
    [DWMAsInPD]              NVARCHAR (50) NULL,
    [BatchAsInPD]            NVARCHAR (50) NULL,
    [ParticipantAsInPD]      NVARCHAR (50) NULL,
    [DWMAchievement]         NVARCHAR (50) NULL,
    [BatchAchievement]       NVARCHAR (50) NULL,
    [ParticipantAchievement] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_18ComponentWiseProgress] (
    [Id]                   INT            NOT NULL,
    [ProjectId]            INT            NOT NULL,
    [NameOfComponent]      NVARCHAR (MAX) NULL,
    [Unit]                 NVARCHAR (50)  NULL,
    [Quantity]             NVARCHAR (50)  NULL,
    [EstimatedTotal]       NVARCHAR (50)  NULL,
    [EstimatedGOB]         NVARCHAR (50)  NULL,
    [EstimatedPA]          NVARCHAR (50)  NULL,
    [EstimatedSelfFinance] NVARCHAR (50)  NULL,
    [EstimatedOthers]      NVARCHAR (50)  NULL,
    [ActualTotal]          NVARCHAR (50)  NULL,
    [ActualGOB]            NVARCHAR (50)  NULL,
    [ActualPA]             NVARCHAR (50)  NULL,
    [ActualSelfFinance]    NVARCHAR (50)  NULL,
    [ActualOthers]         NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_19ProcurementOfTransport] (
    [Id]                             INT            NOT NULL,
    [ProjectId]                      INT            NOT NULL,
    [TypeOfTransport]                NVARCHAR (50)  NULL,
    [NumberAsPerProjectDocument]     NVARCHAR (50)  NULL,
    [NumberProcured]                 NVARCHAR (50)  NULL,
    [NumberProcuredDate]             DATE           NULL,
    [TransferredToTransferPool]      NVARCHAR (50)  NULL,
    [TransferredToTransferPoolDate]  DATE           NULL,
    [TransferredToOM]                NVARCHAR (50)  NULL,
    [TransferredToOMDate]            DATE           NULL,
    [CondemnedDamaged]               NVARCHAR (50)  NULL,
    [CondemnedDamagedDate]           DATE           NULL,
    [ReturnedToFollowingProject]     NVARCHAR (50)  NULL,
    [ReturnedToFollowingProjectDate] DATE           NULL,
    [Remarks]                        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_20ProjectConsultants] (
    [Id]                            INT            NOT NULL,
    [ProjectId]                     INT            NOT NULL,
    [LocalForeign]                  NVARCHAR (50)  NULL,
    [NameOfTheField]                NVARCHAR (50)  NULL,
    [ApprovedManMonthAsPerPD]       NVARCHAR (50)  NULL,
    [ApprovedManMonthAsPerContract] NVARCHAR (50)  NULL,
    [ActualManMonthUtilized]        NVARCHAR (50)  NULL,
    [NumberOfDeliverablesAsPerPD]   NVARCHAR (50)  NULL,
    [NumberOfDeliverablesActual]    NVARCHAR (50)  NULL,
    [Remarks]                       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_21InfrastructureErectionInstallation] (
    [Id]                           INT            NOT NULL,
    [ProjectId]                    INT            NOT NULL,
    [Description]                  NVARCHAR (MAX) NULL,
    [QuantityAsPerProjectDocument] NVARCHAR (50)  NULL,
    [QuantityProcured]             NVARCHAR (50)  NULL,
    [QuantityProcuredDate]         DATE           NULL,
    [TransferredToOM]              NVARCHAR (50)  NULL,
    [TransferredToOMDate]          DATE           NULL,
    [DisposedOff]                  NVARCHAR (50)  NULL,
    [DisposedOffDate]              DATE           NULL,
    [Balance]                      NVARCHAR (50)  NULL,
    [Remarks]                      NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_22.1InfoOnPackages] (
    [Id]                          INT            NOT NULL,
    [ProjectId]                   INT            NOT NULL,
    [TotalPackagesAsPerPD]        NVARCHAR (50)  NULL,
    [GoodsAsPerPD]                NVARCHAR (50)  NULL,
    [WorksAsPerPD]                NVARCHAR (50)  NULL,
    [ServicesAsPerPD]             NVARCHAR (50)  NULL,
    [TotalPackagesProcured]       NVARCHAR (50)  NULL,
    [GoodsProcured]               NVARCHAR (50)  NULL,
    [WorksProcured]               NVARCHAR (50)  NULL,
    [ServicesProcured]            NVARCHAR (50)  NULL,
    [ReasonForNotProcuring]       NVARCHAR (MAX) NULL,
    [TotalPackagesMoreThanOnePct] NVARCHAR (50)  NULL,
    [GoodsMoreThanOnePct]         NVARCHAR (50)  NULL,
    [WorksMoreThanOnePct]         NVARCHAR (50)  NULL,
    [ServicesMoreThanOnePct]      NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_23OriginalAndRevisedProvisionTarget] (
    [Id]                         INT           NOT NULL,
    [ProjectId]                  INT           NOT NULL,
    [FinancialYear]              NVARCHAR (50) NULL,
    [TotalOriginal]              NVARCHAR (50) NULL,
    [GOBOriginal]                NVARCHAR (50) NULL,
    [PAOriginal]                 NVARCHAR (50) NULL,
    [SelfFinanceOriginal]        NVARCHAR (50) NULL,
    [OthersOriginal]             NVARCHAR (50) NULL,
    [PhysicalPercentageOriginal] NVARCHAR (50) NULL,
    [TotalRevised]               NVARCHAR (50) NULL,
    [GOBRevised]                 NVARCHAR (50) NULL,
    [PARevised]                  NVARCHAR (50) NULL,
    [SelfFinanceRevised]         NVARCHAR (50) NULL,
    [OthersRevised]              NVARCHAR (50) NULL,
    [PhysicalPercentageRevised]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_24RevisedADPAllocationAndProgress] (
    [Id]                           INT           NOT NULL,
    [ProjectId]                    INT           NOT NULL,
    [FinancialYear]                NVARCHAR (50) NULL,
    [TotalAllocation]              NVARCHAR (50) NULL,
    [GOBAllocation]                NVARCHAR (50) NULL,
    [PAAllocation]                 NVARCHAR (50) NULL,
    [SelfFinanceAllocation]        NVARCHAR (50) NULL,
    [OthersAllocation]             NVARCHAR (50) NULL,
    [PhysicalPercentageAllocation] NVARCHAR (50) NULL,
    [GOBRelease]                   NVARCHAR (50) NULL,
    [TotalProgress]                NVARCHAR (50) NULL,
    [GOBProgress]                  NVARCHAR (50) NULL,
    [PAProgress]                   NVARCHAR (50) NULL,
    [SelfFinanceProgress]          NVARCHAR (50) NULL,
    [OthersProgress]               NVARCHAR (50) NULL,
    [PhysicalPercentageProgress]   NVARCHAR (50) NULL,
    [UnspentGOBReleased]           NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_25ObjectiveAchievement] (
    [Id]                  INT            NOT NULL,
    [ProjectId]           INT            NOT NULL,
    [Objective]           NVARCHAR (MAX) NULL,
    [Achievement]         NVARCHAR (MAX) NULL,
    [ReasonsForShortfall] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_26AnnualOutput] (
    [Id]                INT            NOT NULL,
    [ProjectId]         INT            NOT NULL,
    [Item]              NVARCHAR (MAX) NULL,
    [Unit]              NVARCHAR (50)  NULL,
    [EstimatedQuantity] NVARCHAR (MAX) NULL,
    [ActualQuantity]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_27CostBenefit] (
    [Id]        INT            NOT NULL,
    [ProjectId] INT            NOT NULL,
    [Category]  NVARCHAR (100) NULL,
    [Item]      NVARCHAR (50)  NULL,
    [Estimated] NVARCHAR (50)  NULL,
    [Actual]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_29Monitoring] (
    [Id]                 INT            NOT NULL,
    [ProjectId]          INT            NOT NULL,
    [Category]           NVARCHAR (50)  NULL,
    [NameAndDesignation] NVARCHAR (MAX) NULL,
    [Date]               DATE           NULL,
    [IdentifiedProblems] NVARCHAR (MAX) NULL,
    [Recommendations]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_30.1InternalAudit] (
    [Id]                        INT            NOT NULL,
    [ProjectId]                 INT            NOT NULL,
    [StartDate]                 DATE           NULL,
    [EndDate]                   DATE           NULL,
    [SubmissionDate]            DATE           NULL,
    [MajorFindings]             NVARCHAR (MAX) NULL,
    [WhetherObjectionsResolved] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_30.2ExternalAudit] (
    [Id]                        INT            NOT NULL,
    [ProjectId]                 INT            NOT NULL,
    [StartDate]                 DATE           NULL,
    [EndDate]                   DATE           NULL,
    [SubmissionDate]            DATE           NULL,
    [MajorFindings]             NVARCHAR (MAX) NULL,
    [WhetherObjectionsResolved] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[_A.ProjectDescription] (
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

CREATE TABLE [dbo].[_G.PostProjectRemarks] (
    [Id]                         INT            NOT NULL,
    [ProjectId]                  INT            NOT NULL,
    [Background]                 NVARCHAR (MAX) NULL,
    [JustificationAdequacy]      NVARCHAR (MAX) NULL,
    [Objectives]                 NVARCHAR (MAX) NULL,
    [ProjectRevisionWithReasons] NVARCHAR (MAX) NULL,
    [Concept]                    NVARCHAR (MAX) NULL,
    [Design]                     NVARCHAR (MAX) NULL,
    [Location]                   NVARCHAR (MAX) NULL,
    [Timing]                     NVARCHAR (MAX) NULL,
    [ProjectIdentification]      NVARCHAR (MAX) NULL,
    [ProjectPreparation]         NVARCHAR (MAX) NULL,
    [Appraisal]                  NVARCHAR (MAX) NULL,
    [CreditNegotiation]          NVARCHAR (MAX) NULL,
    [CreditAgreement]            NVARCHAR (MAX) NULL,
    [CreditEffectiveness]        NVARCHAR (MAX) NULL,
    [LoanDisbursement]           NVARCHAR (MAX) NULL,
    [Loan Conditions]            NVARCHAR (MAX) NULL,
    [ProjectApproval]            NVARCHAR (MAX) NULL,
    [Others(specify)]            NVARCHAR (MAX) NULL,
    [Field34.1]                       NVARCHAR (MAX) NULL,
    [Field34.2]                       NVARCHAR (MAX) NULL,
    [Field34.3]                       NVARCHAR (MAX) NULL,
    [Field34.4]                       NVARCHAR (MAX) NULL,
    [Field34.5]                       NVARCHAR (MAX) NULL,
    [Field34.6]                       NVARCHAR (MAX) NULL,
    [Field34.7]                       NVARCHAR (MAX) NULL,
    [Field34.8]                       NVARCHAR (MAX) NULL,
    [Field34.9]                       NVARCHAR (MAX) NULL,
    [Field34.10]                      NVARCHAR (MAX) NULL,
    [Field34.11]                      NVARCHAR (MAX) NULL,
    [Field34.12]                      NVARCHAR (MAX) NULL,
    [Field34.13]                      NVARCHAR (MAX) NULL,
    [Field34.14]                      NVARCHAR (MAX) NULL,
    [Field34.15]                      NVARCHAR (MAX) NULL,
    [Field35.1]                       NVARCHAR (MAX) NULL,
    [Field35.2]                       NVARCHAR (MAX) NULL,
    [Field35.3]                       NVARCHAR (MAX) NULL,
    [Field35.4]                       NVARCHAR (MAX) NULL,
    [Field35.5]                       NVARCHAR (MAX) NULL,
    [Field35.6]                       NVARCHAR (MAX) NULL,
    [Field35.7]                       NVARCHAR (MAX) NULL,
    [Field35.8]                       NVARCHAR (MAX) NULL,
    [Field35.9]                       NVARCHAR (MAX) NULL,
    [Field35.10]                      NVARCHAR (MAX) NULL,
    [Field35.11]                      NVARCHAR (MAX) NULL,
    [Field35.12]                      NVARCHAR (MAX) NULL,
    [Field35.13]                      NVARCHAR (MAX) NULL,
    [Field35.14]                      NVARCHAR (MAX) NULL,
    [Field35.15]                      NVARCHAR (MAX) NULL,
    [Field35.16]                      NVARCHAR (MAX) NULL,
    [Field35.17]                      NVARCHAR (MAX) NULL,
    [Field35.18]                      NVARCHAR (MAX) NULL,
    [Field35.19]                      NVARCHAR (MAX) NULL,
    [Field36]                         NVARCHAR (MAX) NULL,
    [Field28ReasonsForShortFall]      NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

