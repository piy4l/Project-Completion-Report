namespace ProjectCompletionReport.Models
{
    public class _26AnnualOutput
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Item { get; set; }
        public string? Unit { get; set; }
        public string? EstimatedQuantity { get; set; }
        public string? ActualQuantity { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
