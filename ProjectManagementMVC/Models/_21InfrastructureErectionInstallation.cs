namespace ProjectCompletionReport.Models
{
    public class _21InfrastructureErectionInstallation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Description { get; set; }
        public string? QuantityAsPerProjectDocument { get; set; }
        public string? QuantityProcured { get; set; }
        public string? QuantityProcuredDate { get; set; }
        public string? TransferredToOM { get; set; }
        public string? TransferredToOMDate { get; set; }
        public string? DisposedOff { get; set; }
        public string? DisposedOffDate { get; set; }
        public string? Balance { get; set; }
        public string? Remarks { get; set; }

    }
}
