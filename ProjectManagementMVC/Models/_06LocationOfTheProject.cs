namespace ProjectCompletionReport.Models
{
    public class _06LocationOfTheProject
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Division { get; set; }
        public string? District { get; set; }
        public string? CityCorpMunicipalityUpazila { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
