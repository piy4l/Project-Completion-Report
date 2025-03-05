IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [PersonalInfos] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_PersonalInfos] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250119085838_FirstMigration', N'9.0.1');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250120082615_Second-Migration', N'9.0.1');

DROP TABLE [PersonalInfos];

CREATE TABLE [_06LocationOfTheProjects] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Division] nvarchar(max) NULL,
    [District] nvarchar(max) NULL,
    [CityCorpMunicipalityUpazila] nvarchar(max) NULL,
    CONSTRAINT [PK__06LocationOfTheProjects] PRIMARY KEY ([Id])
);

CREATE TABLE [Projects] (
    [ProjectId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [AdministrativeMinistryDivision] nvarchar(max) NULL,
    [ExecutingAgency] nvarchar(max) NULL,
    [PlanningCommissionSectorDivision] nvarchar(max) NULL,
    [Type] nvarchar(max) NULL,
    [OverallObjective] nvarchar(max) NULL,
    [SpecificObjectives] nvarchar(max) NULL,
    [Background] nvarchar(max) NULL,
    [MajorActivities] nvarchar(max) NULL,
    [ReasonsForRevision] nvarchar(max) NULL,
    [ReasonsForNoCostTimeExtension] nvarchar(max) NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([ProjectId])
);

CREATE TABLE [_07EstimatedCostPeriodApprovals] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Subject] nvarchar(max) NULL,
    [Total] nvarchar(max) NULL,
    [GOB] nvarchar(max) NULL,
    [PA] nvarchar(max) NULL,
    [SelfFinance] nvarchar(max) NULL,
    [ImplementationPeriod] nvarchar(max) NULL,
    [DateOfApproval] nvarchar(max) NULL,
    [ApprovedBy] nvarchar(max) NULL,
    CONSTRAINT [PK__07EstimatedCostPeriodApprovals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__07EstimatedCostPeriodApprovals_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_12_1aStatusOfLoanGrantForeignFinancings] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Source] nvarchar(max) NULL,
    [CurrencyAsPerAgreement] nvarchar(max) NULL,
    [AmountInUSD] nvarchar(max) NULL,
    [Nature] nvarchar(max) NULL,
    [DateOfAgreement] nvarchar(max) NULL,
    [DateOfEffectiveness] nvarchar(max) NULL,
    [OriginalDateOfClosing] nvarchar(max) NULL,
    [RevisedDateOfClosing] nvarchar(max) NULL,
    CONSTRAINT [PK__12_1aStatusOfLoanGrantForeignFinancings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__12_1aStatusOfLoanGrantForeignFinancings_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_12_1bStatusOfLoanGrantGOBs] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [TotalAmount] nvarchar(max) NULL,
    [Loan] nvarchar(max) NULL,
    [Grant] nvarchar(max) NULL,
    [CashForeignExchange] nvarchar(max) NULL,
    CONSTRAINT [PK__12_1bStatusOfLoanGrantGOBs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__12_1bStatusOfLoanGrantGOBs_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_12_1cStatusOfLoanGrantSelfFinanceEquities] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [TotalAmount] nvarchar(max) NULL,
    [SelfFinance] nvarchar(max) NULL,
    [Equity] nvarchar(max) NULL,
    [CashForeignExchange] nvarchar(max) NULL,
    CONSTRAINT [PK__12_1cStatusOfLoanGrantSelfFinanceEquities] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__12_1cStatusOfLoanGrantSelfFinanceEquities_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_12_2UtilizationOfProjectAids] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Source] nvarchar(max) NULL,
    [TotalAmountInUSD] nvarchar(max) NULL,
    [TotalAmountInLocalCurrency] nvarchar(max) NULL,
    [ActualExpenditureInUSD] nvarchar(max) NULL,
    [ActualExpenditureInLocalCurrency] nvarchar(max) NULL,
    [UnutilizedAmountInUSD] nvarchar(max) NULL,
    [UnutilizedAmountInLocalCurrency] nvarchar(max) NULL,
    CONSTRAINT [PK__12_2UtilizationOfProjectAids] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__12_2UtilizationOfProjectAids_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_12_3ReimbursableProjectAids] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Source] nvarchar(max) NULL,
    [RPAAmountAsPerPD] nvarchar(max) NULL,
    [RPAAmountAsPerAgreement] nvarchar(max) NULL,
    [AmountSpent] nvarchar(max) NULL,
    [AmountClaimed] nvarchar(max) NULL,
    [AmountReimbursed] nvarchar(max) NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__12_3ReimbursableProjectAids] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__12_3ReimbursableProjectAids_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_13ImplementationPeriods] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Original] nvarchar(max) NULL,
    [LatestRevised] nvarchar(max) NULL,
    [ActualImplementation] nvarchar(max) NULL,
    [TimeOverRun] nvarchar(max) NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__13ImplementationPeriods] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__13ImplementationPeriods_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_14CostOfTheProjects] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [OriginalEstimatedCost] nvarchar(max) NULL,
    [LatestRevisedEstimatedCost] nvarchar(max) NULL,
    [ActualExpenditure] nvarchar(max) NULL,
    [CostOverRun] nvarchar(max) NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__14CostOfTheProjects] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__14CostOfTheProjects_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_15InfoProjectDirectors] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [NameAndDetails] nvarchar(max) NULL,
    [FullTime] nvarchar(max) NULL,
    [PartTime] nvarchar(max) NULL,
    [ResponsibleForMoreThanOneProject] nvarchar(max) NULL,
    [Joining] datetime2 NULL,
    [Transfer] datetime2 NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__15InfoProjectDirectors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__15InfoProjectDirectors_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_16_1PersonnelOfPIUs] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [NameOfPost] nvarchar(max) NULL,
    [ApprovedStrength] nvarchar(max) NULL,
    [EmployedDuringImplementation] nvarchar(max) NULL,
    CONSTRAINT [PK__16_1PersonnelOfPIUs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__16_1PersonnelOfPIUs_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_16_2PersonnelRequiredAfterCompletions] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [NameOfPost] nvarchar(max) NULL,
    [Number] nvarchar(max) NULL,
    [Recruited] nvarchar(max) NULL,
    [ReasonForNotRecruited] nvarchar(max) NULL,
    CONSTRAINT [PK__16_2PersonnelRequiredAfterCompletions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__16_2PersonnelRequiredAfterCompletions_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_16Personnels] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [TotalNameOfPostGrade] nvarchar(max) NULL,
    [TotalApprovedStrength] nvarchar(max) NULL,
    [TotalEmployedDuringImplementation] nvarchar(max) NULL,
    [TotalNameOfPost] nvarchar(max) NULL,
    [TotalNumber] nvarchar(max) NULL,
    [TotalRecruited] nvarchar(max) NULL,
    [TotalReasonForNotRecruited] nvarchar(max) NULL,
    CONSTRAINT [PK__16Personnels] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__16Personnels_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_17TrainingForeignLocals] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Category] nvarchar(max) NULL,
    [SlNo] nvarchar(max) NULL,
    [DWMAsInPD] nvarchar(max) NULL,
    [BatchAsInPD] nvarchar(max) NULL,
    [ParticipantAsInPD] nvarchar(max) NULL,
    [DWMAchievement] nvarchar(max) NULL,
    [BatchAchievement] nvarchar(max) NULL,
    [ParticipantAchievement] nvarchar(max) NULL,
    CONSTRAINT [PK__17TrainingForeignLocals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__17TrainingForeignLocals_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_18ComponentWiseProgresses] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [NameOfComponent] nvarchar(max) NULL,
    [Unit] nvarchar(max) NULL,
    [Quantity] nvarchar(max) NULL,
    [EstimatedTotal] nvarchar(max) NULL,
    [EstimatedGOB] nvarchar(max) NULL,
    [EstimatedPA] nvarchar(max) NULL,
    [EstimatedSelfFinance] nvarchar(max) NULL,
    [EstimatedOthers] nvarchar(max) NULL,
    [ActualTotal] nvarchar(max) NULL,
    [ActualGOB] nvarchar(max) NULL,
    [ActualPA] nvarchar(max) NULL,
    [ActualSelfFinance] nvarchar(max) NULL,
    [ActualOthers] nvarchar(max) NULL,
    CONSTRAINT [PK__18ComponentWiseProgresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__18ComponentWiseProgresses_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_19ProcurementOfTransports] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [TypeOfTransport] nvarchar(max) NULL,
    [NumberAsPerProjectDocument] nvarchar(max) NULL,
    [NumberProcured] nvarchar(max) NULL,
    [NumberProcuredDate] datetime2 NULL,
    [TransferredToTransferPool] nvarchar(max) NULL,
    [TransferredToTransferPoolDate] datetime2 NULL,
    [TransferredToOM] nvarchar(max) NULL,
    [TransferredToOMDate] datetime2 NULL,
    [CondemnedDamaged] nvarchar(max) NULL,
    [CondemnedDamagedDate] datetime2 NULL,
    [ReturnedToFollowingProject] nvarchar(max) NULL,
    [ReturnedToFollowingProjectDate] datetime2 NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__19ProcurementOfTransports] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__19ProcurementOfTransports_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_20ProjectConsultants] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [LocalForeign] nvarchar(max) NULL,
    [NameOfTheField] nvarchar(max) NULL,
    [ApprovedManMonthAsPerPD] nvarchar(max) NULL,
    [ApprovedManMonthAsPerContract] nvarchar(max) NULL,
    [ActualManMonthUtilized] nvarchar(max) NULL,
    [NumberOfDeliverablesAsPerPD] nvarchar(max) NULL,
    [NumberOfDeliverablesActual] nvarchar(max) NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__20ProjectConsultants] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__20ProjectConsultants_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_21InfrastructureErectionInstallations] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [QuantityAsPerProjectDocument] nvarchar(max) NULL,
    [QuantityProcured] nvarchar(max) NULL,
    [QuantityProcuredDate] datetime2 NULL,
    [TransferredToOM] nvarchar(max) NULL,
    [TransferredToOMDate] datetime2 NULL,
    [DisposedOff] nvarchar(max) NULL,
    [DisposedOffDate] datetime2 NULL,
    [Balance] nvarchar(max) NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK__21InfrastructureErectionInstallations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__21InfrastructureErectionInstallations_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_222_1InfoOnPackages] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [TotalPackagesAsPerPD] nvarchar(max) NULL,
    [GoodsAsPerPD] nvarchar(max) NULL,
    [WorksAsPerPD] nvarchar(max) NULL,
    [ServicesAsPerPD] nvarchar(max) NULL,
    [TotalPackagesProcured] nvarchar(max) NULL,
    [GoodsProcured] nvarchar(max) NULL,
    [WorksProcured] nvarchar(max) NULL,
    [ServicesProcured] nvarchar(max) NULL,
    [ReasonForNotProcuring] nvarchar(max) NULL,
    [TotalPackagesMoreThanOnePct] nvarchar(max) NULL,
    [GoodsMoreThanOnePct] nvarchar(max) NULL,
    [WorksMoreThanOnePct] nvarchar(max) NULL,
    [ServicesMoreThanOnePct] nvarchar(max) NULL,
    CONSTRAINT [PK__222_1InfoOnPackages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__222_1InfoOnPackages_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_23OriginalAndRevisedProvisionTargets] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [FinancialYear] nvarchar(max) NULL,
    [TotalOriginal] nvarchar(max) NULL,
    [GOBOriginal] nvarchar(max) NULL,
    [PAOriginal] nvarchar(max) NULL,
    [SelfFinanceOriginal] nvarchar(max) NULL,
    [OthersOriginal] nvarchar(max) NULL,
    [PhysicalPercentageOriginal] nvarchar(max) NULL,
    [TotalRevised] nvarchar(max) NULL,
    [GOBRevised] nvarchar(max) NULL,
    [PARevised] nvarchar(max) NULL,
    [SelfFinanceRevised] nvarchar(max) NULL,
    [OthersRevised] nvarchar(max) NULL,
    [PhysicalPercentageRevised] nvarchar(max) NULL,
    CONSTRAINT [PK__23OriginalAndRevisedProvisionTargets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__23OriginalAndRevisedProvisionTargets_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_24RevisedADPAllocationAndProgresses] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [FinancialYear] nvarchar(max) NULL,
    [TotalAllocation] nvarchar(max) NULL,
    [GOBAllocation] nvarchar(max) NULL,
    [PAAllocation] nvarchar(max) NULL,
    [SelfFinanceAllocation] nvarchar(max) NULL,
    [OthersAllocation] nvarchar(max) NULL,
    [PhysicalPercentageAllocation] nvarchar(max) NULL,
    [GOBRelease] nvarchar(max) NULL,
    [TotalProgress] nvarchar(max) NULL,
    [GOBProgress] nvarchar(max) NULL,
    [PAProgress] nvarchar(max) NULL,
    [SelfFinanceProgress] nvarchar(max) NULL,
    [OthersProgress] nvarchar(max) NULL,
    [PhysicalPercentageProgress] nvarchar(max) NULL,
    [UnspentGOBReleased] nvarchar(max) NULL,
    CONSTRAINT [PK__24RevisedADPAllocationAndProgresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__24RevisedADPAllocationAndProgresses_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_25ObjectiveAchievements] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Objective] nvarchar(max) NULL,
    [Achievement] nvarchar(max) NULL,
    [ReasonsForShortfall] nvarchar(max) NULL,
    CONSTRAINT [PK__25ObjectiveAchievements] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__25ObjectiveAchievements_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_26AnnualOutputs] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Item] nvarchar(max) NULL,
    [Unit] nvarchar(max) NULL,
    [EstimatedQuantity] nvarchar(max) NULL,
    [ActualQuantity] nvarchar(max) NULL,
    CONSTRAINT [PK__26AnnualOutputs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__26AnnualOutputs_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_27CostBenefits] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Category] nvarchar(max) NULL,
    [Item] nvarchar(max) NULL,
    [Estimated] nvarchar(max) NULL,
    [Actual] nvarchar(max) NULL,
    CONSTRAINT [PK__27CostBenefits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__27CostBenefits_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_29Monitorings] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Category] nvarchar(max) NULL,
    [NameAndDesignation] nvarchar(max) NULL,
    [Date] datetime2 NULL,
    [IdentifiedProblems] nvarchar(max) NULL,
    [Recommendations] nvarchar(max) NULL,
    CONSTRAINT [PK__29Monitorings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__29Monitorings_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_30_1InternalAudits] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [StartDate] datetime2 NULL,
    [EndDate] datetime2 NULL,
    [SubmissionDate] datetime2 NULL,
    [MajorFindings] nvarchar(max) NULL,
    [WhetherObjectionsResolved] nvarchar(max) NULL,
    CONSTRAINT [PK__30_1InternalAudits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__30_1InternalAudits_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_30_2ExternalAudits] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [StartDate] datetime2 NULL,
    [EndDate] datetime2 NULL,
    [SubmissionDate] datetime2 NULL,
    [MajorFindings] nvarchar(max) NULL,
    [WhetherObjectionsResolved] nvarchar(max) NULL,
    CONSTRAINT [PK__30_2ExternalAudits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__30_2ExternalAudits_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE TABLE [_G_PostProjectRemarks] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Background] nvarchar(max) NULL,
    [JustificationAdequacy] nvarchar(max) NULL,
    [Objectives] nvarchar(max) NULL,
    [ProjectRevisionWithReasons] nvarchar(max) NULL,
    [Concept] nvarchar(max) NULL,
    [Design] nvarchar(max) NULL,
    [Location] nvarchar(max) NULL,
    [Timing] nvarchar(max) NULL,
    [ProjectIdentification] nvarchar(max) NULL,
    [ProjectPreparation] nvarchar(max) NULL,
    [Appraisal] nvarchar(max) NULL,
    [CreditNegotiation] nvarchar(max) NULL,
    [CreditAgreement] nvarchar(max) NULL,
    [CreditEffectiveness] nvarchar(max) NULL,
    [LoanDisbursement] nvarchar(max) NULL,
    [LoanConditions] nvarchar(max) NULL,
    [ProjectApproval] nvarchar(max) NULL,
    [OthersSpecify] nvarchar(max) NULL,
    [_34_1] nvarchar(max) NULL,
    [_34_2] nvarchar(max) NULL,
    [_34_3] nvarchar(max) NULL,
    [_34_4] nvarchar(max) NULL,
    [_34_5] nvarchar(max) NULL,
    [_34_6] nvarchar(max) NULL,
    [_34_7] nvarchar(max) NULL,
    [_34_8] nvarchar(max) NULL,
    [_34_9] nvarchar(max) NULL,
    [_34_10] nvarchar(max) NULL,
    [_34_11] nvarchar(max) NULL,
    [_34_12] nvarchar(max) NULL,
    [_34_13] nvarchar(max) NULL,
    [_34_14] nvarchar(max) NULL,
    [_34_15] nvarchar(max) NULL,
    [_35_1] nvarchar(max) NULL,
    [_35_2] nvarchar(max) NULL,
    [_35_3] nvarchar(max) NULL,
    [_35_4] nvarchar(max) NULL,
    [_35_5] nvarchar(max) NULL,
    [_35_6] nvarchar(max) NULL,
    [_35_7] nvarchar(max) NULL,
    [_35_8] nvarchar(max) NULL,
    [_35_9] nvarchar(max) NULL,
    [_35_10] nvarchar(max) NULL,
    [_35_11] nvarchar(max) NULL,
    [_35_12] nvarchar(max) NULL,
    [_35_13] nvarchar(max) NULL,
    [_35_14] nvarchar(max) NULL,
    [_35_15] nvarchar(max) NULL,
    [_35_16] nvarchar(max) NULL,
    [_35_17] nvarchar(max) NULL,
    [_35_18] nvarchar(max) NULL,
    [_35_19] nvarchar(max) NULL,
    [_36] nvarchar(max) NULL,
    [_28ReasonsForShortFall] nvarchar(max) NULL,
    CONSTRAINT [PK__G_PostProjectRemarks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__G_PostProjectRemarks_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE INDEX [IX__07EstimatedCostPeriodApprovals_ProjectId] ON [_07EstimatedCostPeriodApprovals] ([ProjectId]);

CREATE INDEX [IX__12_1aStatusOfLoanGrantForeignFinancings_ProjectId] ON [_12_1aStatusOfLoanGrantForeignFinancings] ([ProjectId]);

CREATE INDEX [IX__12_1bStatusOfLoanGrantGOBs_ProjectId] ON [_12_1bStatusOfLoanGrantGOBs] ([ProjectId]);

CREATE INDEX [IX__12_1cStatusOfLoanGrantSelfFinanceEquities_ProjectId] ON [_12_1cStatusOfLoanGrantSelfFinanceEquities] ([ProjectId]);

CREATE INDEX [IX__12_2UtilizationOfProjectAids_ProjectId] ON [_12_2UtilizationOfProjectAids] ([ProjectId]);

CREATE INDEX [IX__12_3ReimbursableProjectAids_ProjectId] ON [_12_3ReimbursableProjectAids] ([ProjectId]);

CREATE INDEX [IX__13ImplementationPeriods_ProjectId] ON [_13ImplementationPeriods] ([ProjectId]);

CREATE INDEX [IX__14CostOfTheProjects_ProjectId] ON [_14CostOfTheProjects] ([ProjectId]);

CREATE INDEX [IX__15InfoProjectDirectors_ProjectId] ON [_15InfoProjectDirectors] ([ProjectId]);

CREATE INDEX [IX__16_1PersonnelOfPIUs_ProjectId] ON [_16_1PersonnelOfPIUs] ([ProjectId]);

CREATE INDEX [IX__16_2PersonnelRequiredAfterCompletions_ProjectId] ON [_16_2PersonnelRequiredAfterCompletions] ([ProjectId]);

CREATE INDEX [IX__16Personnels_ProjectId] ON [_16Personnels] ([ProjectId]);

CREATE INDEX [IX__17TrainingForeignLocals_ProjectId] ON [_17TrainingForeignLocals] ([ProjectId]);

CREATE INDEX [IX__18ComponentWiseProgresses_ProjectId] ON [_18ComponentWiseProgresses] ([ProjectId]);

CREATE INDEX [IX__19ProcurementOfTransports_ProjectId] ON [_19ProcurementOfTransports] ([ProjectId]);

CREATE INDEX [IX__20ProjectConsultants_ProjectId] ON [_20ProjectConsultants] ([ProjectId]);

CREATE INDEX [IX__21InfrastructureErectionInstallations_ProjectId] ON [_21InfrastructureErectionInstallations] ([ProjectId]);

CREATE INDEX [IX__222_1InfoOnPackages_ProjectId] ON [_222_1InfoOnPackages] ([ProjectId]);

CREATE INDEX [IX__23OriginalAndRevisedProvisionTargets_ProjectId] ON [_23OriginalAndRevisedProvisionTargets] ([ProjectId]);

CREATE INDEX [IX__24RevisedADPAllocationAndProgresses_ProjectId] ON [_24RevisedADPAllocationAndProgresses] ([ProjectId]);

CREATE INDEX [IX__25ObjectiveAchievements_ProjectId] ON [_25ObjectiveAchievements] ([ProjectId]);

CREATE INDEX [IX__26AnnualOutputs_ProjectId] ON [_26AnnualOutputs] ([ProjectId]);

CREATE INDEX [IX__27CostBenefits_ProjectId] ON [_27CostBenefits] ([ProjectId]);

CREATE INDEX [IX__29Monitorings_ProjectId] ON [_29Monitorings] ([ProjectId]);

CREATE INDEX [IX__30_1InternalAudits_ProjectId] ON [_30_1InternalAudits] ([ProjectId]);

CREATE INDEX [IX__30_2ExternalAudits_ProjectId] ON [_30_2ExternalAudits] ([ProjectId]);

CREATE INDEX [IX__G_PostProjectRemarks_ProjectId] ON [_G_PostProjectRemarks] ([ProjectId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250211071249_ThirdMigration', N'9.0.1');

COMMIT;
GO

