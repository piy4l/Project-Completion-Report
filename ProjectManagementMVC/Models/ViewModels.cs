namespace ProjectCompletionReport.Models
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
    }

    public class LocationViewModel
    {
        public List<_06LocationOfTheProject> _06LocationOfTheProject { get; set; }
    }

    public class EstimatedCostViewModel
    {
        public List<_07EstimatedCostPeriodApproval> _07EstimatedCostPeriodApproval { get; set; }
    }
    // ... ViewModels for other models
}
