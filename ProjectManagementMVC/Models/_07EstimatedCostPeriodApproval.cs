namespace ProjectCompletionReport.Models
{
    public class _07EstimatedCostPeriodApproval
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Subject { get; set; }
        public string? Total { get; set; }
        public string? GOB { get; set; }
        public string? PA { get; set; }
        public string? SelfFinance { get; set; }
        public string? ImplementationPeriod { get; set; }
        public string? DateOfApproval { get; set; }
        public string? ApprovedBy { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
