﻿namespace ProjectCompletionReport.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } // 'Completed', 'DraftSec', 'DraftED', 'DraftPD'
        public string? Budget { get; set; }
        public string? Duration { get; set; }
        public string? AdministrativeMinistryDivision { get; set; }
        public string? ExecutingAgency { get; set; }
        public string? PlanningCommissionSectorDivision { get; set; }
        public string? Type { get; set; }
        public string? OverallObjective { get; set; }
        public string? SpecificObjectives { get; set; }
        public string? Background { get; set; }
        public string? MajorActivities { get; set; }
        public string? ReasonsForRevision { get; set; }
        public string? ReasonsForNoCostTimeExtension { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public byte[]? Attachment { get; set; }
    }
}
