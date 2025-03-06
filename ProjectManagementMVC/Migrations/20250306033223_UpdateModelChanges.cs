using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCompletionReport.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__07EstimatedCostPeriodApprovals_Projects_ProjectId",
                table: "_07EstimatedCostPeriodApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK__12_1aStatusOfLoanGrantForeignFinancings_Projects_ProjectId",
                table: "_12_1aStatusOfLoanGrantForeignFinancings");

            migrationBuilder.DropForeignKey(
                name: "FK__12_1bStatusOfLoanGrantGOBs_Projects_ProjectId",
                table: "_12_1bStatusOfLoanGrantGOBs");

            migrationBuilder.DropForeignKey(
                name: "FK__12_1cStatusOfLoanGrantSelfFinanceEquities_Projects_ProjectId",
                table: "_12_1cStatusOfLoanGrantSelfFinanceEquities");

            migrationBuilder.DropForeignKey(
                name: "FK__12_2UtilizationOfProjectAids_Projects_ProjectId",
                table: "_12_2UtilizationOfProjectAids");

            migrationBuilder.DropForeignKey(
                name: "FK__12_3ReimbursableProjectAids_Projects_ProjectId",
                table: "_12_3ReimbursableProjectAids");

            migrationBuilder.DropForeignKey(
                name: "FK__13ImplementationPeriods_Projects_ProjectId",
                table: "_13ImplementationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK__14CostOfTheProjects_Projects_ProjectId",
                table: "_14CostOfTheProjects");

            migrationBuilder.DropForeignKey(
                name: "FK__15InfoProjectDirectors_Projects_ProjectId",
                table: "_15InfoProjectDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK__16_1PersonnelOfPIUs_Projects_ProjectId",
                table: "_16_1PersonnelOfPIUs");

            migrationBuilder.DropForeignKey(
                name: "FK__16_2PersonnelRequiredAfterCompletions_Projects_ProjectId",
                table: "_16_2PersonnelRequiredAfterCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK__16Personnels_Projects_ProjectId",
                table: "_16Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK__17TrainingForeignLocals_Projects_ProjectId",
                table: "_17TrainingForeignLocals");

            migrationBuilder.DropForeignKey(
                name: "FK__18ComponentWiseProgresses_Projects_ProjectId",
                table: "_18ComponentWiseProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK__19ProcurementOfTransports_Projects_ProjectId",
                table: "_19ProcurementOfTransports");

            migrationBuilder.DropForeignKey(
                name: "FK__20ProjectConsultants_Projects_ProjectId",
                table: "_20ProjectConsultants");

            migrationBuilder.DropForeignKey(
                name: "FK__21InfrastructureErectionInstallations_Projects_ProjectId",
                table: "_21InfrastructureErectionInstallations");

            migrationBuilder.DropForeignKey(
                name: "FK__222_1InfoOnPackages_Projects_ProjectId",
                table: "_222_1InfoOnPackages");

            migrationBuilder.DropForeignKey(
                name: "FK__23OriginalAndRevisedProvisionTargets_Projects_ProjectId",
                table: "_23OriginalAndRevisedProvisionTargets");

            migrationBuilder.DropForeignKey(
                name: "FK__24RevisedADPAllocationAndProgresses_Projects_ProjectId",
                table: "_24RevisedADPAllocationAndProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK__25ObjectiveAchievements_Projects_ProjectId",
                table: "_25ObjectiveAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK__26AnnualOutputs_Projects_ProjectId",
                table: "_26AnnualOutputs");

            migrationBuilder.DropForeignKey(
                name: "FK__27CostBenefits_Projects_ProjectId",
                table: "_27CostBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK__29Monitorings_Projects_ProjectId",
                table: "_29Monitorings");

            migrationBuilder.DropForeignKey(
                name: "FK__30_1InternalAudits_Projects_ProjectId",
                table: "_30_1InternalAudits");

            migrationBuilder.DropForeignKey(
                name: "FK__30_2ExternalAudits_Projects_ProjectId",
                table: "_30_2ExternalAudits");

            migrationBuilder.DropForeignKey(
                name: "FK__G_PostProjectRemarks_Projects_ProjectId",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropIndex(
                name: "IX__G_PostProjectRemarks_ProjectId",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropIndex(
                name: "IX__30_2ExternalAudits_ProjectId",
                table: "_30_2ExternalAudits");

            migrationBuilder.DropIndex(
                name: "IX__30_1InternalAudits_ProjectId",
                table: "_30_1InternalAudits");

            migrationBuilder.DropIndex(
                name: "IX__29Monitorings_ProjectId",
                table: "_29Monitorings");

            migrationBuilder.DropIndex(
                name: "IX__27CostBenefits_ProjectId",
                table: "_27CostBenefits");

            migrationBuilder.DropIndex(
                name: "IX__26AnnualOutputs_ProjectId",
                table: "_26AnnualOutputs");

            migrationBuilder.DropIndex(
                name: "IX__25ObjectiveAchievements_ProjectId",
                table: "_25ObjectiveAchievements");

            migrationBuilder.DropIndex(
                name: "IX__24RevisedADPAllocationAndProgresses_ProjectId",
                table: "_24RevisedADPAllocationAndProgresses");

            migrationBuilder.DropIndex(
                name: "IX__23OriginalAndRevisedProvisionTargets_ProjectId",
                table: "_23OriginalAndRevisedProvisionTargets");

            migrationBuilder.DropIndex(
                name: "IX__21InfrastructureErectionInstallations_ProjectId",
                table: "_21InfrastructureErectionInstallations");

            migrationBuilder.DropIndex(
                name: "IX__20ProjectConsultants_ProjectId",
                table: "_20ProjectConsultants");

            migrationBuilder.DropIndex(
                name: "IX__19ProcurementOfTransports_ProjectId",
                table: "_19ProcurementOfTransports");

            migrationBuilder.DropIndex(
                name: "IX__18ComponentWiseProgresses_ProjectId",
                table: "_18ComponentWiseProgresses");

            migrationBuilder.DropIndex(
                name: "IX__17TrainingForeignLocals_ProjectId",
                table: "_17TrainingForeignLocals");

            migrationBuilder.DropIndex(
                name: "IX__16Personnels_ProjectId",
                table: "_16Personnels");

            migrationBuilder.DropIndex(
                name: "IX__16_2PersonnelRequiredAfterCompletions_ProjectId",
                table: "_16_2PersonnelRequiredAfterCompletions");

            migrationBuilder.DropIndex(
                name: "IX__16_1PersonnelOfPIUs_ProjectId",
                table: "_16_1PersonnelOfPIUs");

            migrationBuilder.DropIndex(
                name: "IX__15InfoProjectDirectors_ProjectId",
                table: "_15InfoProjectDirectors");

            migrationBuilder.DropIndex(
                name: "IX__14CostOfTheProjects_ProjectId",
                table: "_14CostOfTheProjects");

            migrationBuilder.DropIndex(
                name: "IX__13ImplementationPeriods_ProjectId",
                table: "_13ImplementationPeriods");

            migrationBuilder.DropIndex(
                name: "IX__12_3ReimbursableProjectAids_ProjectId",
                table: "_12_3ReimbursableProjectAids");

            migrationBuilder.DropIndex(
                name: "IX__12_2UtilizationOfProjectAids_ProjectId",
                table: "_12_2UtilizationOfProjectAids");

            migrationBuilder.DropIndex(
                name: "IX__12_1cStatusOfLoanGrantSelfFinanceEquities_ProjectId",
                table: "_12_1cStatusOfLoanGrantSelfFinanceEquities");

            migrationBuilder.DropIndex(
                name: "IX__12_1bStatusOfLoanGrantGOBs_ProjectId",
                table: "_12_1bStatusOfLoanGrantGOBs");

            migrationBuilder.DropIndex(
                name: "IX__12_1aStatusOfLoanGrantForeignFinancings_ProjectId",
                table: "_12_1aStatusOfLoanGrantForeignFinancings");

            migrationBuilder.DropIndex(
                name: "IX__07EstimatedCostPeriodApprovals_ProjectId",
                table: "_07EstimatedCostPeriodApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK__222_1InfoOnPackages",
                table: "_222_1InfoOnPackages");

            migrationBuilder.DropIndex(
                name: "IX__222_1InfoOnPackages_ProjectId",
                table: "_222_1InfoOnPackages");

            migrationBuilder.RenameTable(
                name: "_222_1InfoOnPackages",
                newName: "_22_1InfoOnPackages");

            migrationBuilder.RenameColumn(
                name: "_36",
                table: "_G_PostProjectRemarks",
                newName: "_36RemarksSec");

            migrationBuilder.RenameColumn(
                name: "LocalForeign",
                table: "_20ProjectConsultants",
                newName: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Budget",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "_36DateAH",
                table: "_G_PostProjectRemarks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_36DatePD",
                table: "_G_PostProjectRemarks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_36DateSec",
                table: "_G_PostProjectRemarks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_36RemarksAH",
                table: "_G_PostProjectRemarks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_36RemarksPD",
                table: "_G_PostProjectRemarks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "_36SealAH",
                table: "_G_PostProjectRemarks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "_36SealPD",
                table: "_G_PostProjectRemarks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "_36SealSec",
                table: "_G_PostProjectRemarks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "_36SignAH",
                table: "_G_PostProjectRemarks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "_36SignPD",
                table: "_G_PostProjectRemarks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "_36SignSec",
                table: "_G_PostProjectRemarks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubmissionDate",
                table: "_30_2ExternalAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "_30_2ExternalAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "_30_2ExternalAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubmissionDate",
                table: "_30_1InternalAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "_30_1InternalAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "_30_1InternalAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "_29Monitorings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransferredToOMDate",
                table: "_21InfrastructureErectionInstallations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuantityProcuredDate",
                table: "_21InfrastructureErectionInstallations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisposedOffDate",
                table: "_21InfrastructureErectionInstallations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransferredToTransferPoolDate",
                table: "_19ProcurementOfTransports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransferredToOMDate",
                table: "_19ProcurementOfTransports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnedToFollowingProjectDate",
                table: "_19ProcurementOfTransports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberProcuredDate",
                table: "_19ProcurementOfTransports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CondemnedDamagedDate",
                table: "_19ProcurementOfTransports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "_18ComponentWiseProgresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Transfer",
                table: "_15InfoProjectDirectors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Joining",
                table: "_15InfoProjectDirectors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__22_1InfoOnPackages",
                table: "_22_1InfoOnPackages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "_17_18Totals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SubTotalLocal_DWMAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalLocal_BatchAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalLocal_ParticipantAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalLocal_DWMAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalLocal_BatchAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalLocal_ParticipantAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalForeign_DWMAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalForeign_BatchAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalForeign_ParticipantAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalForeign_DWMAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalForeign_BatchAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalForeign_ParticipantAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLocalForeign_DWMAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLocalForeign_BatchAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLocalForeign_ParticipantAsInPD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLocalForeign_DWMAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLocalForeign_BatchAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLocalForeign_ParticipantAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_EstimatedTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_EstimatedGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_EstimatedPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_EstimatedSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_EstimatedOthers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_ActualTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_ActualGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_ActualPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_ActualSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalRevenue_ActualOthers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_EstimatedTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_EstimatedGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_EstimatedPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_EstimatedSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_EstimatedOthers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_ActualTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_ActualGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_ActualPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_ActualSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotalCapital_ActualOthers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_EstimatedTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_EstimatedGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_EstimatedPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_EstimatedSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_EstimatedOthers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_ActualTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_ActualGOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_ActualPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_ActualSelfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenueCapital_ActualOthers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__17_18Totals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_30Auditings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TotalInternalMajorFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInternalWhetherResolved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalExternalMajorFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalExternalWhetherResolved = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__30Auditings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Annex1A_ProcurementOfGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PackageNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfNewspaper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDateAsPerContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDateActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Annex1A_ProcurementOfGoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Annex1B_ProcurementOfWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PackageNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfNewspaper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDateAsPerContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDateActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Annex1B_ProcurementOfWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Annex1C_ProcurementOfServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PackageNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfNewspaper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDateAsPerContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionDateActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationEstimatedCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationApprovingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfTenderInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfOpening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationDateOfNOA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Annex1C_ProcurementOfServices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_17_18Totals");

            migrationBuilder.DropTable(
                name: "_30Auditings");

            migrationBuilder.DropTable(
                name: "_Annex1A_ProcurementOfGoods");

            migrationBuilder.DropTable(
                name: "_Annex1B_ProcurementOfWorks");

            migrationBuilder.DropTable(
                name: "_Annex1C_ProcurementOfServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK__22_1InfoOnPackages",
                table: "_22_1InfoOnPackages");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "_36DateAH",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36DatePD",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36DateSec",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36RemarksAH",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36RemarksPD",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36SealAH",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36SealPD",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36SealSec",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36SignAH",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36SignPD",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "_36SignSec",
                table: "_G_PostProjectRemarks");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "_18ComponentWiseProgresses");

            migrationBuilder.RenameTable(
                name: "_22_1InfoOnPackages",
                newName: "_222_1InfoOnPackages");

            migrationBuilder.RenameColumn(
                name: "_36RemarksSec",
                table: "_G_PostProjectRemarks",
                newName: "_36");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "_20ProjectConsultants",
                newName: "LocalForeign");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionDate",
                table: "_30_2ExternalAudits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "_30_2ExternalAudits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "_30_2ExternalAudits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionDate",
                table: "_30_1InternalAudits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "_30_1InternalAudits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "_30_1InternalAudits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "_29Monitorings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferredToOMDate",
                table: "_21InfrastructureErectionInstallations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "QuantityProcuredDate",
                table: "_21InfrastructureErectionInstallations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisposedOffDate",
                table: "_21InfrastructureErectionInstallations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferredToTransferPoolDate",
                table: "_19ProcurementOfTransports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferredToOMDate",
                table: "_19ProcurementOfTransports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedToFollowingProjectDate",
                table: "_19ProcurementOfTransports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NumberProcuredDate",
                table: "_19ProcurementOfTransports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CondemnedDamagedDate",
                table: "_19ProcurementOfTransports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Transfer",
                table: "_15InfoProjectDirectors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Joining",
                table: "_15InfoProjectDirectors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__222_1InfoOnPackages",
                table: "_222_1InfoOnPackages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX__G_PostProjectRemarks_ProjectId",
                table: "_G_PostProjectRemarks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__30_2ExternalAudits_ProjectId",
                table: "_30_2ExternalAudits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__30_1InternalAudits_ProjectId",
                table: "_30_1InternalAudits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__29Monitorings_ProjectId",
                table: "_29Monitorings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__27CostBenefits_ProjectId",
                table: "_27CostBenefits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__26AnnualOutputs_ProjectId",
                table: "_26AnnualOutputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__25ObjectiveAchievements_ProjectId",
                table: "_25ObjectiveAchievements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__24RevisedADPAllocationAndProgresses_ProjectId",
                table: "_24RevisedADPAllocationAndProgresses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__23OriginalAndRevisedProvisionTargets_ProjectId",
                table: "_23OriginalAndRevisedProvisionTargets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__21InfrastructureErectionInstallations_ProjectId",
                table: "_21InfrastructureErectionInstallations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__20ProjectConsultants_ProjectId",
                table: "_20ProjectConsultants",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__19ProcurementOfTransports_ProjectId",
                table: "_19ProcurementOfTransports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__18ComponentWiseProgresses_ProjectId",
                table: "_18ComponentWiseProgresses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__17TrainingForeignLocals_ProjectId",
                table: "_17TrainingForeignLocals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__16Personnels_ProjectId",
                table: "_16Personnels",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__16_2PersonnelRequiredAfterCompletions_ProjectId",
                table: "_16_2PersonnelRequiredAfterCompletions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__16_1PersonnelOfPIUs_ProjectId",
                table: "_16_1PersonnelOfPIUs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__15InfoProjectDirectors_ProjectId",
                table: "_15InfoProjectDirectors",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__14CostOfTheProjects_ProjectId",
                table: "_14CostOfTheProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__13ImplementationPeriods_ProjectId",
                table: "_13ImplementationPeriods",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_3ReimbursableProjectAids_ProjectId",
                table: "_12_3ReimbursableProjectAids",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_2UtilizationOfProjectAids_ProjectId",
                table: "_12_2UtilizationOfProjectAids",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_1cStatusOfLoanGrantSelfFinanceEquities_ProjectId",
                table: "_12_1cStatusOfLoanGrantSelfFinanceEquities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_1bStatusOfLoanGrantGOBs_ProjectId",
                table: "_12_1bStatusOfLoanGrantGOBs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__12_1aStatusOfLoanGrantForeignFinancings_ProjectId",
                table: "_12_1aStatusOfLoanGrantForeignFinancings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__07EstimatedCostPeriodApprovals_ProjectId",
                table: "_07EstimatedCostPeriodApprovals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX__222_1InfoOnPackages_ProjectId",
                table: "_222_1InfoOnPackages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK__07EstimatedCostPeriodApprovals_Projects_ProjectId",
                table: "_07EstimatedCostPeriodApprovals",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__12_1aStatusOfLoanGrantForeignFinancings_Projects_ProjectId",
                table: "_12_1aStatusOfLoanGrantForeignFinancings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__12_1bStatusOfLoanGrantGOBs_Projects_ProjectId",
                table: "_12_1bStatusOfLoanGrantGOBs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__12_1cStatusOfLoanGrantSelfFinanceEquities_Projects_ProjectId",
                table: "_12_1cStatusOfLoanGrantSelfFinanceEquities",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__12_2UtilizationOfProjectAids_Projects_ProjectId",
                table: "_12_2UtilizationOfProjectAids",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__12_3ReimbursableProjectAids_Projects_ProjectId",
                table: "_12_3ReimbursableProjectAids",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__13ImplementationPeriods_Projects_ProjectId",
                table: "_13ImplementationPeriods",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__14CostOfTheProjects_Projects_ProjectId",
                table: "_14CostOfTheProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__15InfoProjectDirectors_Projects_ProjectId",
                table: "_15InfoProjectDirectors",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__16_1PersonnelOfPIUs_Projects_ProjectId",
                table: "_16_1PersonnelOfPIUs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__16_2PersonnelRequiredAfterCompletions_Projects_ProjectId",
                table: "_16_2PersonnelRequiredAfterCompletions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__16Personnels_Projects_ProjectId",
                table: "_16Personnels",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__17TrainingForeignLocals_Projects_ProjectId",
                table: "_17TrainingForeignLocals",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__18ComponentWiseProgresses_Projects_ProjectId",
                table: "_18ComponentWiseProgresses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__19ProcurementOfTransports_Projects_ProjectId",
                table: "_19ProcurementOfTransports",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__20ProjectConsultants_Projects_ProjectId",
                table: "_20ProjectConsultants",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__21InfrastructureErectionInstallations_Projects_ProjectId",
                table: "_21InfrastructureErectionInstallations",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__222_1InfoOnPackages_Projects_ProjectId",
                table: "_222_1InfoOnPackages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__23OriginalAndRevisedProvisionTargets_Projects_ProjectId",
                table: "_23OriginalAndRevisedProvisionTargets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__24RevisedADPAllocationAndProgresses_Projects_ProjectId",
                table: "_24RevisedADPAllocationAndProgresses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__25ObjectiveAchievements_Projects_ProjectId",
                table: "_25ObjectiveAchievements",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__26AnnualOutputs_Projects_ProjectId",
                table: "_26AnnualOutputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__27CostBenefits_Projects_ProjectId",
                table: "_27CostBenefits",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__29Monitorings_Projects_ProjectId",
                table: "_29Monitorings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__30_1InternalAudits_Projects_ProjectId",
                table: "_30_1InternalAudits",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__30_2ExternalAudits_Projects_ProjectId",
                table: "_30_2ExternalAudits",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__G_PostProjectRemarks_Projects_ProjectId",
                table: "_G_PostProjectRemarks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
