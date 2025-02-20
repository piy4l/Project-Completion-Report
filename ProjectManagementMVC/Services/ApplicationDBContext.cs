using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Models;

namespace ProjectCompletionReport.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<_06LocationOfTheProject> _06LocationOfTheProjects { get; set; }
        public DbSet<_07EstimatedCostPeriodApproval> _07EstimatedCostPeriodApprovals { get; set; }
        public DbSet<_12_1aStatusOfLoanGrantForeignFinancing> _12_1aStatusOfLoanGrantForeignFinancings { get; set; }
        public DbSet<_12_1bStatusOfLoanGrantGOB> _12_1bStatusOfLoanGrantGOBs { get; set; }
        public DbSet<_12_1cStatusOfLoanGrantSelfFinanceEquity> _12_1cStatusOfLoanGrantSelfFinanceEquities { get; set; }
        public DbSet<_12_2UtilizationOfProjectAid> _12_2UtilizationOfProjectAids { get; set; }
        public DbSet<_12_3ReimbursableProjectAid> _12_3ReimbursableProjectAids { get; set; }
        public DbSet<_13ImplementationPeriod> _13ImplementationPeriods { get; set; }
        public DbSet<_14CostOfTheProject> _14CostOfTheProjects { get; set; }
        public DbSet<_15InfoProjectDirector> _15InfoProjectDirectors { get; set; }
        public DbSet<_16_1PersonnelOfPIU> _16_1PersonnelOfPIUs { get; set; }
        public DbSet<_16_2PersonnelRequiredAfterCompletion> _16_2PersonnelRequiredAfterCompletions { get; set; }
        public DbSet<_16Personnel> _16Personnels { get; set; }
        public DbSet<_17TrainingForeignLocal> _17TrainingForeignLocals { get; set; }
        public DbSet<_18ComponentWiseProgress> _18ComponentWiseProgresses { get; set; }
        public DbSet<_19ProcurementOfTransport> _19ProcurementOfTransports { get; set; }
        public DbSet<_20ProjectConsultant> _20ProjectConsultants { get; set; }
        public DbSet<_21InfrastructureErectionInstallation> _21InfrastructureErectionInstallations { get; set; }
        public DbSet<_22_1InfoOnPackage> _222_1InfoOnPackages { get; set; }
        public DbSet<_23OriginalAndRevisedProvisionTarget> _23OriginalAndRevisedProvisionTargets { get; set; }
        public DbSet<_24RevisedADPAllocationAndProgress> _24RevisedADPAllocationAndProgresses { get; set; }
        public DbSet<_25ObjectiveAchievement> _25ObjectiveAchievements { get; set; }
        public DbSet<_26AnnualOutput> _26AnnualOutputs { get; set; }
        public DbSet<_27CostBenefit> _27CostBenefits { get; set; }
        public DbSet<_29Monitoring> _29Monitorings { get; set; }
        public DbSet<_30_1InternalAudit> _30_1InternalAudits { get; set; }
        public DbSet<_30_2ExternalAudit> _30_2ExternalAudits { get; set; }
        public DbSet<_G_PostProjectRemark> _G_PostProjectRemarks { get; set; }

    }
}
