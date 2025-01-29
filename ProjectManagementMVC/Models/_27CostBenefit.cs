namespace ProjectCompletionReport.Models
{
    public class _27CostBenefit
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Category { get; set; }
        public string? Item { get; set; }
        public string? Estimated { get; set; }
        public string? Actual { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
