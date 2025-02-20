namespace ProjectCompletionReport.Models
{
    public class _19ProcurementOfTransport
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? TypeOfTransport { get; set; }
        public string? NumberAsPerProjectDocument { get; set; }
        public string? NumberProcured { get; set; }
        public string? NumberProcuredDate { get; set; }
        public string? TransferredToTransferPool { get; set; }
        public string? TransferredToTransferPoolDate { get; set; }
        public string? TransferredToOM { get; set; }
        public string? TransferredToOMDate { get; set; }
        public string? CondemnedDamaged { get; set; }
        public string? CondemnedDamagedDate { get; set; }
        public string? ReturnedToFollowingProject { get; set; }
        public string? ReturnedToFollowingProjectDate { get; set; }
        public string? Remarks { get; set; }

    }
}
