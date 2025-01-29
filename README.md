## Creating the Tables:

CREATE TABLE [dbo].[Projects] (
    [ProjectId]                        INT            IDENTITY (1, 1) NOT NULL,
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
    PRIMARY KEY CLUSTERED ([ProjectId] ASC)
);

CREATE TABLE [dbo].[_06LocationOfTheProject] (
    [Id]                          INT           NOT NULL,
    [ProjectId]                   INT           NOT NULL,
    [Division]                    VARCHAR (50)  NULL,
    [District]                    NVARCHAR (50) NULL,
    [CityCorpMunicipalityUpazila] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_06LocationOfTheProject] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_07EstimatedCostPeriodApproval] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_12_1aStatusOfLoanGrantForeignFinancing] (
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_12_1aStatusOfLoanGrantForeignFinancing] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_12_1bStatusOfLoanGrantGOB] (
    [Id]                  INT           NOT NULL,
    [ProjectId]           INT           NOT NULL,
    [TotalAmount]         NVARCHAR (50) NULL,
    [Loan]                NVARCHAR (50) NULL,
    [Grant]               NVARCHAR (50) NULL,
    [CashForeignExchange] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_12_1bStatusOfLoanGrantGOB] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_12_1cStatusOfLoanGrantSelfFinanceEquity] (
    [Id]                  INT           NOT NULL,
    [ProjectId]           INT           NOT NULL,
    [TotalAmount]         NVARCHAR (50) NULL,
    [SelfFinance]         NVARCHAR (50) NULL,
    [Equity]              NVARCHAR (50) NULL,
    [CashForeignExchange] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_12_1cStatusOfLoanGrantSelfFinanceEquity] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_12_2UtilizationOfProjectAid] (
    [Id]                               INT           NOT NULL,
    [ProjectId]                        INT           NOT NULL,
    [Source]                           NVARCHAR (50) NULL,
    [TotalAmountInUSD]                 NVARCHAR (50) NULL,
    [TotalAmountInLocalCurrency]       NVARCHAR (50) NULL,
    [ActualExpenditureInUSD]           NVARCHAR (50) NULL,
    [ActualExpenditureInLocalCurrency] NVARCHAR (50) NULL,
    [UnutilizedAmountInUSD]            NVARCHAR (50) NULL,
    [UnutilizedAmountInLocalCurrency]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_12_2UtilizationOfProjectAid] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_12_3ReimbursableProjectAid] (
    [Id]                      INT            NOT NULL,
    [ProjectId]               INT            NOT NULL,
    [Source]                  NVARCHAR (50)  NULL,
    [RPAAmountAsPerPD]        NVARCHAR (50)  NULL,
    [RPAAmountAsPerAgreement] NVARCHAR (50)  NULL,
    [AmountSpent]             NVARCHAR (50)  NULL,
    [AmountClaimed]           NVARCHAR (50)  NULL,
    [AmountReimbursed]        NVARCHAR (50)  NULL,
    [Remarks]                 NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_12_3ReimbursableProjectAid] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_13ImplementationPeriod] (
    [Id]                   INT            NOT NULL,
    [ProjectId]            INT            NOT NULL,
    [Original]             NVARCHAR (50)  NULL,
    [LatestRevised]        NVARCHAR (50)  NULL,
    [ActualImplementation] NVARCHAR (50)  NULL,
    [TimeOverRun]          NVARCHAR (50)  NULL,
    [Remarks]              NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_13ImplementationPeriod] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_14CostOfTheProject] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_15InfoProjectDirectors] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_16_1PersonnelOfPIU] (
    [Id]                           INT           NOT NULL,
    [ProjectId]                    INT           NOT NULL,
    [NameOfPost]                   NVARCHAR (50) NULL,
    [ApprovedStrength]             NVARCHAR (50) NULL,
    [EmployedDuringImplementation] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_16_1PersonnelOfPIU] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_16_2PersonnelRequiredAfterCompletion] (
    [Id]                    INT            NOT NULL,
    [ProjectId]             INT            NOT NULL,
    [NameOfPost]            NVARCHAR (50)  NULL,
    [Number]                NVARCHAR (50)  NULL,
    [Recruited]             NVARCHAR (50)  NULL,
    [ReasonForNotRecruited] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_16_2PersonnelRequiredAfterCompletion] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_16Personnel] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_17TrainingForeignLocal] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_18ComponentWiseProgress] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_19ProcurementOfTransport] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_20ProjectConsultants] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_21InfrastructureErectionInstallation] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_22_1InfoOnPackages] (
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_22_1InfoOnPackages] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_23OriginalAndRevisedProvisionTarget] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_24RevisedADPAllocationAndProgress] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_25ObjectiveAchievement] (
    [Id]                  INT            NOT NULL,
    [ProjectId]           INT            NOT NULL,
    [Objective]           NVARCHAR (MAX) NULL,
    [Achievement]         NVARCHAR (MAX) NULL,
    [ReasonsForShortfall] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_25ObjectiveAchievement] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_26AnnualOutput] (
    [Id]                INT            NOT NULL,
    [ProjectId]         INT            NOT NULL,
    [Item]              NVARCHAR (MAX) NULL,
    [Unit]              NVARCHAR (50)  NULL,
    [EstimatedQuantity] NVARCHAR (MAX) NULL,
    [ActualQuantity]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_26AnnualOutput] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_27CostBenefit] (
    [Id]        INT            NOT NULL,
    [ProjectId] INT            NOT NULL,
    [Category]  NVARCHAR (100) NULL,
    [Item]      NVARCHAR (50)  NULL,
    [Estimated] NVARCHAR (50)  NULL,
    [Actual]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_27CostBenefit] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_29Monitoring] (
    [Id]                 INT            NOT NULL,
    [ProjectId]          INT            NOT NULL,
    [Category]           NVARCHAR (50)  NULL,
    [NameAndDesignation] NVARCHAR (MAX) NULL,
    [Date]               DATE           NULL,
    [IdentifiedProblems] NVARCHAR (MAX) NULL,
    [Recommendations]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_29Monitoring] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_30_1InternalAudit] (
    [Id]                        INT            NOT NULL,
    [ProjectId]                 INT            NOT NULL,
    [StartDate]                 DATE           NULL,
    [EndDate]                   DATE           NULL,
    [SubmissionDate]            DATE           NULL,
    [MajorFindings]             NVARCHAR (MAX) NULL,
    [WhetherObjectionsResolved] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_30_1InternalAudit] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_30_2ExternalAudit] (
    [Id]                        INT            NOT NULL,
    [ProjectId]                 INT            NOT NULL,
    [StartDate]                 DATE           NULL,
    [EndDate]                   DATE           NULL,
    [SubmissionDate]            DATE           NULL,
    [MajorFindings]             NVARCHAR (MAX) NULL,
    [WhetherObjectionsResolved] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_30_2ExternalAudit] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[_G_PostProjectRemarks] (
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
    [_34_1]                  NVARCHAR (MAX) NULL,
    [_34_2]                  NVARCHAR (MAX) NULL,
    [_34_3]                  NVARCHAR (MAX) NULL,
    [_34_4]                  NVARCHAR (MAX) NULL,
    [_34_5]                  NVARCHAR (MAX) NULL,
    [_34_6]                  NVARCHAR (MAX) NULL,
    [_34_7]                  NVARCHAR (MAX) NULL,
    [_34_8]                  NVARCHAR (MAX) NULL,
    [_34_9]                  NVARCHAR (MAX) NULL,
    [_34_10]                 NVARCHAR (MAX) NULL,
    [_34_11]                 NVARCHAR (MAX) NULL,
    [_34_12]                 NVARCHAR (MAX) NULL,
    [_34_13]                 NVARCHAR (MAX) NULL,
    [_34_14]                 NVARCHAR (MAX) NULL,
    [_34_15]                 NVARCHAR (MAX) NULL,
    [_35_1]                  NVARCHAR (MAX) NULL,
    [_35_2]                  NVARCHAR (MAX) NULL,
    [_35_3]                  NVARCHAR (MAX) NULL,
    [_35_4]                  NVARCHAR (MAX) NULL,
    [_35_5]                  NVARCHAR (MAX) NULL,
    [_35_6]                  NVARCHAR (MAX) NULL,
    [_35_7]                  NVARCHAR (MAX) NULL,
    [_35_8]                  NVARCHAR (MAX) NULL,
    [_35_9]                  NVARCHAR (MAX) NULL,
    [_35_10]                 NVARCHAR (MAX) NULL,
    [_35_11]                 NVARCHAR (MAX) NULL,
    [_35_12]                 NVARCHAR (MAX) NULL,
    [_35_13]                 NVARCHAR (MAX) NULL,
    [_35_14]                 NVARCHAR (MAX) NULL,
    [_35_15]                 NVARCHAR (MAX) NULL,
    [_35_16]                 NVARCHAR (MAX) NULL,
    [_35_17]                 NVARCHAR (MAX) NULL,
    [_35_18]                 NVARCHAR (MAX) NULL,
    [_35_19]                 NVARCHAR (MAX) NULL,
    [_36]                    NVARCHAR (MAX) NULL,
    [_28ReasonsForShortFall] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_G_PostProjectRemarks] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId]) ON DELETE CASCADE
);



