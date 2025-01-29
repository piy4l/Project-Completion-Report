namespace ProjectCompletionReport.Models
{
    public class _12_1cStatusOfLoanGrantSelfFinanceEquity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? TotalAmount { get; set; }
        public string? SelfFinance { get; set; }
        public string? Equity { get; set; }
        public string? CashForeignExchange { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
