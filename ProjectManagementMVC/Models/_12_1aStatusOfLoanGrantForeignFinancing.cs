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
        public DateTime? DateOfAgreement { get; set; }
        public DateTime? DateOfEffectiveness { get; set; }
        public DateTime? OriginalDateOfClosing { get; set; }
        public DateTime? RevisedDateOfClosing { get; set; }
    }
}
