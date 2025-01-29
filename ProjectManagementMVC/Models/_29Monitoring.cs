namespace ProjectCompletionReport.Models
{
    public class _29Monitoring
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Category { get; set; }
        public string? NameAndDesignation { get; set; }
        public DateTime? Date { get; set; }
        public string? IdentifiedProblems { get; set; }
        public string? Recommendations { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
