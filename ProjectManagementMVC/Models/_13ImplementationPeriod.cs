namespace ProjectCompletionReport.Models
{
    public class _13ImplementationPeriod
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Original { get; set; }
        public string? LatestRevised { get; set; }
        public string? ActualImplementation { get; set; }
        public string? TimeOverRun { get; set; }
        public string? Remarks { get; set; }
    }
}
