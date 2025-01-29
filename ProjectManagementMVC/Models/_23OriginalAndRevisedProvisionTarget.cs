namespace ProjectCompletionReport.Models
{
    public class _23OriginalAndRevisedProvisionTarget
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? FinancialYear { get; set; }
        public string? TotalOriginal { get; set; }
        public string? GOBOriginal { get; set; }
        public string? PAOriginal { get; set; }
        public string? SelfFinanceOriginal { get; set; }
        public string? OthersOriginal { get; set; }
        public string? PhysicalPercentageOriginal { get; set; }
        public string? TotalRevised { get; set; }
        public string? GOBRevised { get; set; }
        public string? PARevised { get; set; }
        public string? SelfFinanceRevised { get; set; }
        public string? OthersRevised { get; set; }
        public string? PhysicalPercentageRevised { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
