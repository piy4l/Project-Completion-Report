namespace ProjectCompletionReport.Models
{
    public class _30_2ExternalAudit
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? SubmissionDate { get; set; }
        public string? MajorFindings { get; set; }
        public string? WhetherObjectionsResolved { get; set; }

    }
}
