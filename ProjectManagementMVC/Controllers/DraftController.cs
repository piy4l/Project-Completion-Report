using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectCompletionReport.Controllers
{
    [Authorize]
    public class DraftController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DraftController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id = null)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!id.HasValue)
            {
                return RedirectToAction("Drafts", "ViewProject");
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == id.Value && (p.CreatedByUserId == userId || User.IsInRole("ED") || User.IsInRole("Sec")));

            if (project == null)
            {
                Console.WriteLine($"Project not found for ID: {id}");
                return NotFound();
            }         

            // Load related data into ProjectModel
            var projectModel = await _context.Projects
                .Where(p => p.ProjectId == id)
                .Select(p => new ProjectModel
                {
                    Project = p,
                    _06LocationOfTheProjects = _context._06LocationOfTheProjects.Where(l => l.ProjectId == p.ProjectId).ToList(),
                    _07EstimatedCostPeriodApprovals = _context._07EstimatedCostPeriodApprovals.Where(c => c.ProjectId == p.ProjectId).ToList(),
                    _12_1aStatusOfLoanGrantForeignFinancings = _context._12_1aStatusOfLoanGrantForeignFinancings.Where(f => f.ProjectId == p.ProjectId).ToList(),
                    _12_1bStatusOfLoanGrantGOBs = _context._12_1bStatusOfLoanGrantGOBs.Where(g => g.ProjectId == p.ProjectId).ToList(),
                    _12_1cStatusOfLoanGrantSelfFinanceEquities = _context._12_1cStatusOfLoanGrantSelfFinanceEquities.Where(s => s.ProjectId == p.ProjectId).ToList(),
                    _12_2UtilizationOfProjectAids = _context._12_2UtilizationOfProjectAids.Where(u => u.ProjectId == p.ProjectId).ToList(),
                    _12_3ReimbursableProjectAids = _context._12_3ReimbursableProjectAids.Where(r => r.ProjectId == p.ProjectId).ToList(),
                    _13ImplementationPeriods = _context._13ImplementationPeriods.Where(i => i.ProjectId == p.ProjectId).ToList(),
                    _14CostOfTheProjects = _context._14CostOfTheProjects.Where(c => c.ProjectId == p.ProjectId).ToList(),
                    _15InfoProjectDirectors = _context._15InfoProjectDirectors.Where(d => d.ProjectId == p.ProjectId).ToList(),
                    _16_1PersonnelOfPIUs = _context._16_1PersonnelOfPIUs.Where(p => p.ProjectId == p.ProjectId).ToList(),
                    _16_2PersonnelRequiredAfterCompletions = _context._16_2PersonnelRequiredAfterCompletions.Where(p => p.ProjectId == p.ProjectId).ToList(),
                    _16Personnels = _context._16Personnels.Where(p => p.ProjectId == p.ProjectId).ToList(),
                    _17TrainingForeignLocals = _context._17TrainingForeignLocals.Where(t => t.ProjectId == p.ProjectId).ToList(),
                    _18ComponentWiseProgresses = _context._18ComponentWiseProgresses.Where(c => c.ProjectId == p.ProjectId).ToList(),
                    _17_18Totals = _context._17_18Totals.Where(t => t.ProjectId == p.ProjectId).ToList(),
                    _19ProcurementOfTransports = _context._19ProcurementOfTransports.Where(p => p.ProjectId == p.ProjectId).ToList(),
                    _20ProjectConsultants = _context._20ProjectConsultants.Where(p => p.ProjectId == p.ProjectId).ToList(),
                    _21InfrastructureErectionInstallations = _context._21InfrastructureErectionInstallations.Where(i => i.ProjectId == p.ProjectId).ToList(),
                    _22_1InfoOnPackages = _context._22_1InfoOnPackages.Where(i => i.ProjectId == p.ProjectId).ToList(),
                    _23OriginalAndRevisedProvisionTargets = _context._23OriginalAndRevisedProvisionTargets.Where(o => o.ProjectId == p.ProjectId).ToList(),
                    _24RevisedADPAllocationAndProgresses = _context._24RevisedADPAllocationAndProgresses.Where(r => r.ProjectId == p.ProjectId).ToList(),
                    _25ObjectiveAchievements = _context._25ObjectiveAchievements.Where(o => o.ProjectId == p.ProjectId).ToList(),
                    _26AnnualOutputs = _context._26AnnualOutputs.Where(a => a.ProjectId == p.ProjectId).ToList(),
                    _27CostBenefits = _context._27CostBenefits.Where(c => c.ProjectId == p.ProjectId).ToList(),
                    _29Monitorings = _context._29Monitorings.Where(m => m.ProjectId == p.ProjectId).ToList(),
                    _30_1InternalAudits = _context._30_1InternalAudits.Where(i => i.ProjectId == p.ProjectId).ToList(),
                    _30_2ExternalAudits = _context._30_2ExternalAudits.Where(e => e.ProjectId == p.ProjectId).ToList(),
                    _30Auditings = _context._30Auditings.Where(a => a.ProjectId == p.ProjectId).ToList(),
                    _G_PostProjectRemark = _context._G_PostProjectRemarks.Where(r => r.ProjectId == p.ProjectId).FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            return View("Index", projectModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsDraft([FromForm] ProjectModel model, IFormFile Attachment)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data submitted." });
            }

            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var project = await _context.Projects.FindAsync(model.Project.ProjectId);

            if (project == null)
            {
                return Json(new { success = false, message = "Project not found." });
            }

            // Validate role-based access
            if (!User.IsInRole("PD") && !User.IsInRole("ED") && !User.IsInRole("Sec"))
            {
                return Json(new { success = false, message = "Unauthorized access." });
            }

            // Update Project entity
            project.Name = model.Project.Name;
            project.AdministrativeMinistryDivision = model.Project.AdministrativeMinistryDivision;
            project.ExecutingAgency = model.Project.ExecutingAgency;
            project.PlanningCommissionSectorDivision = model.Project.PlanningCommissionSectorDivision;
            project.Type = model.Project.Type;
            project.OverallObjective = model.Project.OverallObjective;
            project.SpecificObjectives = model.Project.SpecificObjectives;
            project.Background = model.Project.Background;
            project.MajorActivities = model.Project.MajorActivities;
            project.ReasonsForRevision = model.Project.ReasonsForRevision;
            project.ReasonsForNoCostTimeExtension = model.Project.ReasonsForNoCostTimeExtension;
            project.CreatedDate = DateTime.UtcNow;

            // Handle file upload
            if (Attachment != null && Attachment.Length > 0)
            {
                if (Attachment.Length > 20 * 1024 * 1024) // 20MB limit
                {
                    return Json(new { success = false, message = "File size exceeds 20MB limit." });
                }

                if (Path.GetExtension(Attachment.FileName).ToLower() != ".pdf")
                {
                    return Json(new { success = false, message = "Only PDF files are allowed." });
                }

                var fileName = $"Attachment_{project.ProjectId}_{DateTime.UtcNow.Ticks}.pdf";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Attachment.CopyToAsync(stream);
                }

                // project.AttachmentPath = $"/Uploads/{fileName}";
            }

            // Update related data
            await UpdateRelatedData(project.ProjectId, model);

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Draft saved successfully." });
        }

        private async Task UpdateRelatedData(int projectId, ProjectModel model)
        {
            // Remove existing related data
            _context._06LocationOfTheProjects.RemoveRange(_context._06LocationOfTheProjects.Where(l => l.ProjectId == projectId));
            _context._07EstimatedCostPeriodApprovals.RemoveRange(_context._07EstimatedCostPeriodApprovals.Where(e => e.ProjectId == projectId));
            _context._13ImplementationPeriods.RemoveRange(_context._13ImplementationPeriods.Where(i => i.ProjectId == projectId));
            _context._14CostOfTheProjects.RemoveRange(_context._14CostOfTheProjects.Where(c => c.ProjectId == projectId));
            _context._15InfoProjectDirectors.RemoveRange(_context._15InfoProjectDirectors.Where(d => d.ProjectId == projectId));
            _context._27CostBenefits.RemoveRange(_context._27CostBenefits.Where(c => c.ProjectId == projectId));
            _context._G_PostProjectRemarks.RemoveRange(_context._G_PostProjectRemarks.Where(r => r.ProjectId == projectId));
            _context._Annex1A_ProcurementOfGoods.RemoveRange(_context._Annex1A_ProcurementOfGoods.Where(g => g.ProjectId == projectId));
            _context._Annex1B_ProcurementOfWorks.RemoveRange(_context._Annex1B_ProcurementOfWorks.Where(w => w.ProjectId == projectId));
            _context._Annex1C_ProcurementOfServices.RemoveRange(_context._Annex1C_ProcurementOfServices.Where(s => s.ProjectId == projectId));

            // Add updated related data
            if (model._06LocationOfTheProjects != null)
            {
                foreach (var location in model._06LocationOfTheProjects)
                {
                    location.ProjectId = projectId;
                    _context._06LocationOfTheProjects.Add(location);
                }
            }

            if (model._07EstimatedCostPeriodApprovals != null)
            {
                foreach (var cost in model._07EstimatedCostPeriodApprovals)
                {
                    cost.ProjectId = projectId;
                    _context._07EstimatedCostPeriodApprovals.Add(cost);
                }
            }

            if (model._13ImplementationPeriods != null)
            {
                foreach (var period in model._13ImplementationPeriods)
                {
                    period.ProjectId = projectId;
                    _context._13ImplementationPeriods.Add(period);
                }
            }

            if (model._14CostOfTheProjects != null)
            {
                foreach (var cost in model._14CostOfTheProjects)
                {
                    cost.ProjectId = projectId;
                    _context._14CostOfTheProjects.Add(cost);
                }
            }

            if (model._15InfoProjectDirectors != null)
            {
                foreach (var director in model._15InfoProjectDirectors)
                {
                    director.ProjectId = projectId;
                    _context._15InfoProjectDirectors.Add(director);
                }
            }

            if (model._27CostBenefits != null)
            {
                foreach (var benefit in model._27CostBenefits)
                {
                    benefit.ProjectId = projectId;
                    _context._27CostBenefits.Add(benefit);
                }
            }

            if (model._G_PostProjectRemark != null)
            {
                model._G_PostProjectRemark.ProjectId = projectId;
                _context._G_PostProjectRemarks.Add(model._G_PostProjectRemark);
            }

            if (model._Annex1A_ProcurementOfGoods != null)
            {
                foreach (var good in model._Annex1A_ProcurementOfGoods)
                {
                    good.ProjectId = projectId;
                    _context._Annex1A_ProcurementOfGoods.Add(good);
                }
            }

            if (model._Annex1B_ProcurementOfWorks != null)
            {
                foreach (var work in model._Annex1B_ProcurementOfWorks)
                {
                    work.ProjectId = projectId;
                    _context._Annex1B_ProcurementOfWorks.Add(work);
                }
            }

            if (model._Annex1C_ProcurementOfServices != null)
            {
                foreach (var service in model._Annex1C_ProcurementOfServices)
                {
                    service.ProjectId = projectId;
                    _context._Annex1C_ProcurementOfServices.Add(service);
                }
            }
        }
    }
}