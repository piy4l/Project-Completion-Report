namespace ProjectCompletionReport.Models
{
    public class _19ProcurementOfTransport
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? TypeOfTransport { get; set; }
        public string? NumberAsPerProjectDocument { get; set; }
        public string? NumberProcured { get; set; }
        public DateTime? NumberProcuredDate { get; set; } // Using DateTime? for nullable dates
        public string? TransferredToTransferPool { get; set; }
        public DateTime? TransferredToTransferPoolDate { get; set; } // Using DateTime? for nullable dates
        public string? TransferredToOM { get; set; }
        public DateTime? TransferredToOMDate { get; set; } // Using DateTime? for nullable dates
        public string? CondemnedDamaged { get; set; }
        public DateTime? CondemnedDamagedDate { get; set; } // Using DateTime? for nullable dates
        public string? ReturnedToFollowingProject { get; set; }
        public DateTime? ReturnedToFollowingProjectDate { get; set; } // Using DateTime? for nullable dates
        public string? Remarks { get; set; }

    }
}
