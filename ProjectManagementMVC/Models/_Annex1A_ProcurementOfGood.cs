namespace ProjectCompletionReport.Models
{
    public class _Annex1A_ProcurementOfGood
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public string? PackageNo { get; set; }
        public string? DescriptionOfPackage { get; set; }
        public string? NameOfNewspaper { get; set; }
        public string? ContractPrice { get; set; }
        public string? ContractDate { get; set; }
        public string? ActualPayment { get; set; }
        public string? CompletionDateAsPerContract { get; set; }
        public string? CompletionDateActual { get; set; }

        public string? PlanEstimatedCost { get; set; }
        public string? PlanProcurementMethod { get; set; }
        public string? PlanApprovingAuthority { get; set; }
        public string? PlanDateOfTenderInvitation { get; set; }
        public string? PlanDateOfOpening { get; set; }
        public string? PlanDateOfApproval { get; set; }
        public string? PlanDateOfNOA { get; set; }

        public string? ActualEstimatedCost { get; set; }
        public string? ActualProcurementMethod { get; set; }
        public string? ActualApprovingAuthority { get; set; }
        public string? ActualDateOfTenderInvitation { get; set; }
        public string? ActualDateOfOpening { get; set; }
        public string? ActualDateOfApproval { get; set; }
        public string? ActualDateOfNOA { get; set; }

        public string? DeviationEstimatedCost { get; set; }
        public string? DeviationProcurementMethod { get; set; }
        public string? DeviationApprovingAuthority { get; set; }
        public string? DeviationDateOfTenderInvitation { get; set; }
        public string? DeviationDateOfOpening { get; set; }
        public string? DeviationDateOfApproval { get; set; }
        public string? DeviationDateOfNOA { get; set; }
    }
}
