namespace ProjectCompletionReport.Models
{
    public class _25ObjectiveAchievement
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Objective { get; set; }
        public string? Achievement { get; set; }
        public string? ReasonsForShortfall { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
