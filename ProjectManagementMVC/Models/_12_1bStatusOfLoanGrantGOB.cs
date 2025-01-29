namespace ProjectCompletionReport.Models
{
    public class _12_1bStatusOfLoanGrantGOB
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? TotalAmount { get; set; }
        public string? Loan { get; set; }
        public string? Grant { get; set; }
        public string? CashForeignExchange { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
