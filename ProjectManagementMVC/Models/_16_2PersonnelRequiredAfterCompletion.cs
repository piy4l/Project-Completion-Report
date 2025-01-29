namespace ProjectCompletionReport.Models
{
    public class _16_2PersonnelRequiredAfterCompletion
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? NameOfPost { get; set; }
        public string? Number { get; set; }
        public string? Recruited { get; set; }
        public string? ReasonForNotRecruited { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
