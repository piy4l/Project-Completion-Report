namespace ProjectCompletionReport.Models
{
    public class _22_1InfoOnPackages
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? TotalPackagesAsPerPD { get; set; }
        public string? GoodsAsPerPD { get; set; }
        public string? WorksAsPerPD { get; set; }
        public string? ServicesAsPerPD { get; set; }
        public string? TotalPackagesProcured { get; set; }
        public string? GoodsProcured { get; set; }
        public string? WorksProcured { get; set; }
        public string? ServicesProcured { get; set; }
        public string? ReasonForNotProcuring { get; set; }
        public string? TotalPackagesMoreThanOnePct { get; set; }
        public string? GoodsMoreThanOnePct { get; set; }
        public string? WorksMoreThanOnePct { get; set; }
        public string? ServicesMoreThanOnePct { get; set; }

        // Navigation property to the Project entity
        public Project? Project { get; set; }
    }
}
