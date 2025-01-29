namespace ProjectCompletionReport.Models
{
    public class _12_1aStatusOfLoanGrantForeignFinancing
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Source { get; set; }
        public string? CurrencyAsPerAgreement { get; set; }
        public string? AmountInUSD { get; set; }
        public string? Nature { get; set; }
        public string? DateOfAgreement { get; set; }
        public string? DateOfEffectiveness { get; set; }
        public string? OriginalDateOfClosing { get; set; }
        public string? RevisedDateOfClosing { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
