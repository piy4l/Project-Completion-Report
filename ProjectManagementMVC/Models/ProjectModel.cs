using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProjectCompletionReport.Models
{
    public class ProjectModel
    {
        public Project Project { get; set; }
        public List<_06LocationOfTheProject>? _06LocationOfTheProjects { get; set; }
        public List<_07EstimatedCostPeriodApproval>? _07EstimatedCostPeriodApprovals { get; set; }
        public List<_12_1aStatusOfLoanGrantForeignFinancing>? _12_1aStatusOfLoanGrantForeignFinancings { get; set; }
        public List<_12_1bStatusOfLoanGrantGOB>? _12_1bStatusOfLoanGrantGOBs { get; set; }
        public List<_12_1cStatusOfLoanGrantSelfFinanceEquity>? _12_1cStatusOfLoanGrantSelfFinanceEquities { get; set; }
        public List<_12_2UtilizationOfProjectAid>? _12_2UtilizationOfProjectAids { get; set; }
        public List<_12_3ReimbursableProjectAid>? _12_3ReimbursableProjectAids { get; set; }
        public List<_13ImplementationPeriod>? _13ImplementationPeriods { get; set; }
        public List<_14CostOfTheProject>? _14CostOfTheProjects { get; set; }
        public List<_15InfoProjectDirector>? _15InfoProjectDirectors { get; set; }
        public List<_16_1PersonnelOfPIU>? _16_1PersonnelOfPIUs { get; set; }
        public List<_16_2PersonnelRequiredAfterCompletion>? _16_2PersonnelRequiredAfterCompletions { get; set; }
        public List<_16Personnel>? _16Personnels { get; set; }
        public List<_17TrainingForeignLocal>? _17TrainingForeignLocals { get; set; }
        public List<_18ComponentWiseProgress>? _18ComponentWiseProgresses { get; set; }
        public List<_17_18Total>? _17_18Totals { get; set; }
        public List<_19ProcurementOfTransport>? _19ProcurementOfTransports { get; set; }
        public List<_20ProjectConsultant>? _20ProjectConsultants { get; set; }
        public List<_21InfrastructureErectionInstallation>? _21InfrastructureErectionInstallations { get; set; }
        public List<_22_1InfoOnPackage>? _22_1InfoOnPackages { get; set; }
        public List<_23OriginalAndRevisedProvisionTarget>? _23OriginalAndRevisedProvisionTargets { get; set; }
        public List<_24RevisedADPAllocationAndProgress>? _24RevisedADPAllocationAndProgresses { get; set; }
        public List<_25ObjectiveAchievement>? _25ObjectiveAchievements { get; set; }
        public List<_26AnnualOutput>? _26AnnualOutputs { get; set; }
        public List<_27CostBenefit>? _27CostBenefits { get; set; }
        public List<_29Monitoring>? _29Monitorings { get; set; }
        public List<_30_1InternalAudit>? _30_1InternalAudits { get; set; }
        public List<_30_2ExternalAudit>? _30_2ExternalAudits { get; set; }
        public List<_30Auditing>? _30Auditings { get; set; }
        public _G_PostProjectRemark? _G_PostProjectRemark { get; set; }
        public List<_Annex1A_ProcurementOfGood>? _Annex1A_ProcurementOfGoods { get; set; }
        public List<_Annex1B_ProcurementOfWork>? _Annex1B_ProcurementOfWorks { get; set; }
        public List<_Annex1C_ProcurementOfService>? _Annex1C_ProcurementOfServices { get; set; }
    }
}
