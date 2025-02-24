namespace ProjectCompletionReport.Models
{
    public class _30Auditing
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? TotalInternalMajorFindings { get; set; }
        public string? TotalInternalWhetherResolved { get; set; }
        public string? TotalExternalMajorFindings { get; set; }
        public string? TotalExternalWhetherResolved { get; set; }
    }
}
