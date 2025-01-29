namespace ProjectCompletionReport.Models
{
    public class _21InfrastructureErectionInstallation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Description { get; set; }
        public string? QuantityAsPerProjectDocument { get; set; }
        public string? QuantityProcured { get; set; }
        public DateTime? QuantityProcuredDate { get; set; }
        public string? TransferredToOM { get; set; }
        public DateTime? TransferredToOMDate { get; set; }
        public string? DisposedOff { get; set; }
        public DateTime? DisposedOffDate { get; set; }
        public string? Balance { get; set; }
        public string? Remarks { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
