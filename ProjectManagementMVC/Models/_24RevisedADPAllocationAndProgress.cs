namespace ProjectCompletionReport.Models
{
    public class _24RevisedADPAllocationAndProgress
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? FinancialYear { get; set; }
        public string? TotalAllocation { get; set; }
        public string? GOBAllocation { get; set; }
        public string? PAAllocation { get; set; }
        public string? SelfFinanceAllocation { get; set; }
        public string? OthersAllocation { get; set; }
        public string? PhysicalPercentageAllocation { get; set; }
        public string? GOBRelease { get; set; }
        public string? TotalProgress { get; set; }
        public string? GOBProgress { get; set; }
        public string? PAProgress { get; set; }
        public string? SelfFinanceProgress { get; set; }
        public string? OthersProgress { get; set; }
        public string? PhysicalPercentageProgress { get; set; }
        public string? UnspentGOBReleased { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
