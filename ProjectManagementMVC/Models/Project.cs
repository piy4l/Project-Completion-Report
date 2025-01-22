using System.ComponentModel.DataAnnotations;

namespace ProjectCompletionReport.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Administrative Ministry/Division")]
        [StringLength(100)]
        public string AdministrativeMinistryDivision { get; set; }

        [Display(Name = "Executing Agency")]
        [StringLength(100)]
        public string ExecutingAgency { get; set; }

        [Display(Name = "Planning Commission Sector/Division")]
        public int? PlanningCommissionSectorDivision { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [Display(Name = "Overall Objective")]
        public string OverallObjective { get; set; }

        [Display(Name = "Specific Objectives")]
        public string SpecificObjectives { get; set; }

        public string Background { get; set; }

        [Display(Name = "Major Activities")]
        public string MajorActivities { get; set; }

        [Display(Name = "Reasons For Revision")]
        public string ReasonsForRevision { get; set; }

        [Display(Name = "Reasons For No-Cost Time Extension")]
        public string ReasonsForNoCostTimeExtension { get; set; }
    }
}
