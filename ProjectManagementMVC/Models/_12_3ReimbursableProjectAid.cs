namespace ProjectCompletionReport.Models
{
    public class _12_3ReimbursableProjectAid
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Source { get; set; }
        public string? RPAAmountAsPerPD { get; set; }
        public string? RPAAmountAsPerAgreement { get; set; }
        public string? AmountSpent { get; set; }
        public string? AmountClaimed { get; set; }
        public string? AmountReimbursed { get; set; }
        public string? Remarks { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
