using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCompletionReport.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInfos");

            migrationBuilder.CreateTable(
                name: "_06LocationOfTheProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCorpMunicipalityUpazila = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__06LocationOfTheProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeMinistryDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanningCommissionSectorDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificObjectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorActivities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonsForRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonsForNoCostTimeExtension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "_07EstimatedCostPeriodApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImplementationPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__07EstimatedCostPeriodApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK__07EstimatedCostPeriodApprovals_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_12_1aStatusOfLoanGrantForeignFinancings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyAsPerAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountInUSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfEffectiveness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalDateOfClosing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisedDateOfClosing = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__12_1aStatusOfLoanGrantForeignFinancings", x => x.Id);
                    table.ForeignKey(
                        name: "FK__12_1aStatusOfLoanGrantForeignFinancings_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_12_1bStatusOfLoanGrantGOBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashForeignExchange = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__12_1bStatusOfLoanGrantGOBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__12_1bStatusOfLoanGrantGOBs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_12_1cStatusOfLoanGrantSelfFinanceEquities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashForeignExchange = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__12_1cStatusOfLoanGrantSelfFinanceEquities", x => x.Id);
                    table.ForeignKey(
                        name: "FK__12_1cStatusOfLoanGrantSelfFinanceEquities_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_12_2UtilizationOfProjectAids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmountInUSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmountInLocalCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualExpenditureInUSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualExpenditureInLocalCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnutilizedAmountInUSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnutilizedAmountInLocalCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__12_2UtilizationOfProjectAids", x => x.Id);
                    table.ForeignKey(
                        name: "FK__12_2UtilizationOfProjectAids_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_12_3ReimbursableProjectAids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPAAmountAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPAAmountAsPerAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountSpent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountClaimed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountReimbursed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__12_3ReimbursableProjectAids", x => x.Id);
                    table.ForeignKey(
                        name: "FK__12_3ReimbursableProjectAids_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_13ImplementationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestRevised = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualImplementation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOverRun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__13ImplementationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK__13ImplementationPeriods_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_14CostOfTheProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestRevisedEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualExpenditure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostOverRun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__14CostOfTheProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK__14CostOfTheProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_15InfoProjectDirectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    NameAndDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibleForMoreThanOneProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Joining = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Transfer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__15InfoProjectDirectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK__15InfoProjectDirectors_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_16_1PersonnelOfPIUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    NameOfPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployedDuringImplementation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__16_1PersonnelOfPIUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__16_1PersonnelOfPIUs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_16_2PersonnelRequiredAfterCompletions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    NameOfPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recruited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForNotRecruited = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__16_2PersonnelRequiredAfterCompletions", x => x.Id);
                    table.ForeignKey(
                        name: "FK__16_2PersonnelRequiredAfterCompletions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_16Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TotalNameOfPostGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalApprovedStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalEmployedDuringImplementation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNameOfPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRecruited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalReasonForNotRecruited = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__16Personnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK__16Personnels_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_17TrainingForeignLocals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DWMAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParticipantAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DWMAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParticipantAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__17TrainingForeignLocals", x => x.Id);
                    table.ForeignKey(
                        name: "FK__17TrainingForeignLocals_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_18ComponentWiseProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    NameOfComponent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedOthers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualOthers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__18ComponentWiseProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__18ComponentWiseProgresses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_19ProcurementOfTransports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TypeOfTransport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberAsPerProjectDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberProcured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberProcuredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransferredToTransferPool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferredToTransferPoolDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransferredToOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferredToOMDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CondemnedDamaged = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondemnedDamagedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnedToFollowingProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnedToFollowingProjectDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__19ProcurementOfTransports", x => x.Id);
                    table.ForeignKey(
                        name: "FK__19ProcurementOfTransports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_20ProjectConsultants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    LocalForeign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfTheField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedManMonthAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedManMonthAsPerContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualManMonthUtilized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDeliverablesAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDeliverablesActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__20ProjectConsultants", x => x.Id);
                    table.ForeignKey(
                        name: "FK__20ProjectConsultants_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_21InfrastructureErectionInstallations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityAsPerProjectDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityProcured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityProcuredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransferredToOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferredToOMDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisposedOff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisposedOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__21InfrastructureErectionInstallations", x => x.Id);
                    table.ForeignKey(
                        name: "FK__21InfrastructureErectionInstallations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_222_1InfoOnPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TotalPackagesAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorksAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesAsPerPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPackagesProcured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsProcured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorksProcured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesProcured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForNotProcuring = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPackagesMoreThanOnePct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsMoreThanOnePct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorksMoreThanOnePct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesMoreThanOnePct = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__222_1InfoOnPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK__222_1InfoOnPackages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_23OriginalAndRevisedProvisionTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOBOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfFinanceOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalPercentageOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevised = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOBRevised = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PARevised = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfFinanceRevised = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersRevised = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalPercentageRevised = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__23OriginalAndRevisedProvisionTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK__23OriginalAndRevisedProvisionTargets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_24RevisedADPAllocationAndProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOBAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfFinanceAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalPercentageAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOBRelease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOBProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfFinanceProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalPercentageProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnspentGOBReleased = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__24RevisedADPAllocationAndProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__24RevisedADPAllocationAndProgresses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_25ObjectiveAchievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonsForShortfall = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__25ObjectiveAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK__25ObjectiveAchievements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_26AnnualOutputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__26AnnualOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__26AnnualOutputs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_27CostBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estimated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actual = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__27CostBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK__27CostBenefits_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_29Monitorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAndDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentifiedProblems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__29Monitorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK__29Monitorings_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_30_1InternalAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MajorFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhetherObjectionsResolved = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__30_1InternalAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK__30_1InternalAudits_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_30_2ExternalAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MajorFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhetherObjectionsResolved = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__30_2ExternalAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK__30_2ExternalAudits_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_G_PostProjectRemarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JustificationAdequacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Objectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectRevisionWithReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Design = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPreparation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appraisal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditNegotiation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditEffectiveness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanDisbursement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersSpecify = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _34_15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _35_19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _28ReasonsForShortFall = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__G_PostProjectRemarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK__G_PostProjectRemarks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__07EstimatedCostPeriodApprovals_ProjectId",
                table: "_07EstimatedCostPeriodApprovals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_1aStatusOfLoanGrantForeignFinancings_ProjectId",
                table: "_12_1aStatusOfLoanGrantForeignFinancings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_1bStatusOfLoanGrantGOBs_ProjectId",
                table: "_12_1bStatusOfLoanGrantGOBs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_1cStatusOfLoanGrantSelfFinanceEquities_ProjectId",
                table: "_12_1cStatusOfLoanGrantSelfFinanceEquities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_2UtilizationOfProjectAids_ProjectId",
                table: "_12_2UtilizationOfProjectAids",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_3ReimbursableProjectAids_ProjectId",
                table: "_12_3ReimbursableProjectAids",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__13ImplementationPeriods_ProjectId",
                table: "_13ImplementationPeriods",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__14CostOfTheProjects_ProjectId",
                table: "_14CostOfTheProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__15InfoProjectDirectors_ProjectId",
                table: "_15InfoProjectDirectors",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__16_1PersonnelOfPIUs_ProjectId",
                table: "_16_1PersonnelOfPIUs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__16_2PersonnelRequiredAfterCompletions_ProjectId",
                table: "_16_2PersonnelRequiredAfterCompletions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__16Personnels_ProjectId",
                table: "_16Personnels",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__17TrainingForeignLocals_ProjectId",
                table: "_17TrainingForeignLocals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__18ComponentWiseProgresses_ProjectId",
                table: "_18ComponentWiseProgresses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__19ProcurementOfTransports_ProjectId",
                table: "_19ProcurementOfTransports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__20ProjectConsultants_ProjectId",
                table: "_20ProjectConsultants",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__21InfrastructureErectionInstallations_ProjectId",
                table: "_21InfrastructureErectionInstallations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__222_1InfoOnPackages_ProjectId",
                table: "_222_1InfoOnPackages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__23OriginalAndRevisedProvisionTargets_ProjectId",
                table: "_23OriginalAndRevisedProvisionTargets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__24RevisedADPAllocationAndProgresses_ProjectId",
                table: "_24RevisedADPAllocationAndProgresses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__25ObjectiveAchievements_ProjectId",
                table: "_25ObjectiveAchievements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__26AnnualOutputs_ProjectId",
                table: "_26AnnualOutputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__27CostBenefits_ProjectId",
                table: "_27CostBenefits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__29Monitorings_ProjectId",
                table: "_29Monitorings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__30_1InternalAudits_ProjectId",
                table: "_30_1InternalAudits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__30_2ExternalAudits_ProjectId",
                table: "_30_2ExternalAudits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__G_PostProjectRemarks_ProjectId",
                table: "_G_PostProjectRemarks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_06LocationOfTheProjects");

            migrationBuilder.DropTable(
                name: "_07EstimatedCostPeriodApprovals");

            migrationBuilder.DropTable(
                name: "_12_1aStatusOfLoanGrantForeignFinancings");

            migrationBuilder.DropTable(
                name: "_12_1bStatusOfLoanGrantGOBs");

            migrationBuilder.DropTable(
                name: "_12_1cStatusOfLoanGrantSelfFinanceEquities");

            migrationBuilder.DropTable(
                name: "_12_2UtilizationOfProjectAids");

            migrationBuilder.DropTable(
                name: "_12_3ReimbursableProjectAids");

            migrationBuilder.DropTable(
                name: "_13ImplementationPeriods");

            migrationBuilder.DropTable(
                name: "_14CostOfTheProjects");

            migrationBuilder.DropTable(
                name: "_15InfoProjectDirectors");

            migrationBuilder.DropTable(
                name: "_16_1PersonnelOfPIUs");

            migrationBuilder.DropTable(
                name: "_16_2PersonnelRequiredAfterCompletions");

            migrationBuilder.DropTable(
                name: "_16Personnels");

            migrationBuilder.DropTable(
                name: "_17TrainingForeignLocals");

            migrationBuilder.DropTable(
                name: "_18ComponentWiseProgresses");

            migrationBuilder.DropTable(
                name: "_19ProcurementOfTransports");

            migrationBuilder.DropTable(
                name: "_20ProjectConsultants");

            migrationBuilder.DropTable(
                name: "_21InfrastructureErectionInstallations");

            migrationBuilder.DropTable(
                name: "_222_1InfoOnPackages");

            migrationBuilder.DropTable(
                name: "_23OriginalAndRevisedProvisionTargets");

            migrationBuilder.DropTable(
                name: "_24RevisedADPAllocationAndProgresses");

            migrationBuilder.DropTable(
                name: "_25ObjectiveAchievements");

            migrationBuilder.DropTable(
                name: "_26AnnualOutputs");

            migrationBuilder.DropTable(
                name: "_27CostBenefits");

            migrationBuilder.DropTable(
                name: "_29Monitorings");

            migrationBuilder.DropTable(
                name: "_30_1InternalAudits");

            migrationBuilder.DropTable(
                name: "_30_2ExternalAudits");

            migrationBuilder.DropTable(
                name: "_G_PostProjectRemarks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.CreateTable(
                name: "PersonalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfos", x => x.Id);
                });
        }
    }
}
