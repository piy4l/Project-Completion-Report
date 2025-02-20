namespace ProjectCompletionReport.Models
{
    public class _20ProjectConsultant
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? LocalForeign { get; set; }
        public string? NameOfTheField { get; set; }
        public string? ApprovedManMonthAsPerPD { get; set; }
        public string? ApprovedManMonthAsPerContract { get; set; }
        public string? ActualManMonthUtilized { get; set; }
        public string? NumberOfDeliverablesAsPerPD { get; set; }
        public string? NumberOfDeliverablesActual { get; set; }
        public string? Remarks { get; set; }

    }
}
