namespace ProjectCompletionReport.Models
{
    public class _12_2UtilizationOfProjectAid
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Source { get; set; }
        public string? TotalAmountInUSD { get; set; }
        public string? TotalAmountInLocalCurrency { get; set; }
        public string? ActualExpenditureInUSD { get; set; }
        public string? ActualExpenditureInLocalCurrency { get; set; }
        public string? UnutilizedAmountInUSD { get; set; }
        public string? UnutilizedAmountInLocalCurrency { get; set; }
    }
}
