﻿namespace ProjectCompletionReport.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; } // 0 = Finalized, 1 = Draft at PD, 2 = Draft at AH, 3 = Draft at Sec
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
    }
}
