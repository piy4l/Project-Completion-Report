namespace ProjectCompletionReport.Models
{
    public class _30_2ExternalAudit
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? MajorFindings { get; set; }
        public string? WhetherObjectionsResolved { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
