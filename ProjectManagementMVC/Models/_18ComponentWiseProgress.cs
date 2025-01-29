namespace ProjectCompletionReport.Models
{
    public class _18ComponentWiseProgress
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? NameOfComponent { get; set; }
        public string? Unit { get; set; }
        public string? Quantity { get; set; }
        public string? EstimatedTotal { get; set; }
        public string? EstimatedGOB { get; set; }
        public string? EstimatedPA { get; set; }
        public string? EstimatedSelfFinance { get; set; }
        public string? EstimatedOthers { get; set; }
        public string? ActualTotal { get; set; }
        public string? ActualGOB { get; set; }
        public string? ActualPA { get; set; }
        public string? ActualSelfFinance { get; set; }
        public string? ActualOthers { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
