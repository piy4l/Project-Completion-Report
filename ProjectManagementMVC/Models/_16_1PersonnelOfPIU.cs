namespace ProjectCompletionReport.Models
{
    public class _16_1PersonnelOfPIU
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? NameOfPost { get; set; }
        public string? ApprovedStrength { get; set; }
        public string? EmployedDuringImplementation { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
