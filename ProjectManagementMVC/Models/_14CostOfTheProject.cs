namespace ProjectCompletionReport.Models
{
    public class _14CostOfTheProject
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Description { get; set; }
        public string? OriginalEstimatedCost { get; set; }
        public string? LatestRevisedEstimatedCost { get; set; }
        public string? ActualExpenditure { get; set; }
        public string? CostOverRun { get; set; }
        public string? Remarks { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
