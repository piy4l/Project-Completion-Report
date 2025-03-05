using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Models;
using X.PagedList;
using Rotativa.AspNetCore;
using ProjectCompletionReport.Services;

namespace ProjectCompletionReport.Controllers
{
    public class ViewProjectController : Controller
    {
        public ApplicationDBContext Context { get; }

        public ViewProjectController(ApplicationDBContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> Index(int? page, int? pageSize)
        {
            int currentPageSize = pageSize ?? 10; // Default to 10 if not specified
            int pageNumber = (page ?? 1); // Default to page 1 if not specified

            // Get total count for accurate pagination
            var totalCount = await Context.Projects.CountAsync();

            // Fetch only the required page of data
            var projects = await Context.Projects
                .OrderBy(p => p.ProjectId)
                .Skip((pageNumber - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToListAsync();

            // Create a paged list with the total count
            var pagedProjects = new StaticPagedList<Project>(projects, pageNumber, currentPageSize, totalCount);

            // Pass pageSize to view
            ViewBag.PageSize = currentPageSize;

            // Check if the request is an AJAX request
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Return partial view for AJAX requests
                return PartialView("_ProjectsTable", pagedProjects);
            }

            // Return full view for regular requests
            return View(pagedProjects);
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // ... (unchanged Details action remains as is)
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var projectModel = await Context.Projects
                    .Where(p => p.ProjectId == id)
                    .Select(p => new ProjectModel
                    {
                        Project = p,
                        _06LocationOfTheProjects = Context._06LocationOfTheProjects
                            .Where(l => l.ProjectId == p.ProjectId)
                            .ToList(),
                        _07EstimatedCostPeriodApprovals = Context._07EstimatedCostPeriodApprovals
                            .Where(c => c.ProjectId == p.ProjectId)
                            .ToList(),
                        _12_1aStatusOfLoanGrantForeignFinancings = Context._12_1aStatusOfLoanGrantForeignFinancings
                            .Where(f => f.ProjectId == p.ProjectId)
                            .ToList(),
                        _12_1bStatusOfLoanGrantGOBs = Context._12_1bStatusOfLoanGrantGOBs
                            .Where(g => g.ProjectId == p.ProjectId)
                            .ToList(),
                        _12_1cStatusOfLoanGrantSelfFinanceEquities = Context._12_1cStatusOfLoanGrantSelfFinanceEquities
                            .Where(s => s.ProjectId == p.ProjectId)
                            .ToList(),
                        _12_2UtilizationOfProjectAids = Context._12_2UtilizationOfProjectAids
                            .Where(u => u.ProjectId == p.ProjectId)
                            .ToList(),
                        _12_3ReimbursableProjectAids = Context._12_3ReimbursableProjectAids
                            .Where(r => r.ProjectId == p.ProjectId)
                            .ToList(),
                        _13ImplementationPeriods = Context._13ImplementationPeriods
                            .Where(i => i.ProjectId == p.ProjectId)
                            .ToList(),
                        _14CostOfTheProjects = Context._14CostOfTheProjects
                            .Where(c => c.ProjectId == p.ProjectId)
                            .ToList(),
                        _15InfoProjectDirectors = Context._15InfoProjectDirectors
                            .Where(d => d.ProjectId == p.ProjectId)
                            .ToList(),
                        _16_1PersonnelOfPIUs = Context._16_1PersonnelOfPIUs
                            .Where(p => p.ProjectId == p.ProjectId)
                            .ToList(),
                        _16_2PersonnelRequiredAfterCompletions = Context._16_2PersonnelRequiredAfterCompletions
                            .Where(p => p.ProjectId == p.ProjectId)
                            .ToList(),
                        _16Personnels = Context._16Personnels
                            .Where(p => p.ProjectId == p.ProjectId)
                            .ToList(),
                        _17TrainingForeignLocals = Context._17TrainingForeignLocals
                            .Where(t => t.ProjectId == p.ProjectId)
                            .ToList(),
                        _18ComponentWiseProgresses = Context._18ComponentWiseProgresses
                            .Where(c => c.ProjectId == p.ProjectId)
                            .ToList(),
                        _17_18Totals = Context._17_18Totals
                            .Where(t => t.ProjectId == p.ProjectId)
                            .ToList(),
                        _19ProcurementOfTransports = Context._19ProcurementOfTransports
                            .Where(p => p.ProjectId == p.ProjectId)
                            .ToList(),
                        _20ProjectConsultants = Context._20ProjectConsultants
                            .Where(p => p.ProjectId == p.ProjectId)
                            .ToList(),
                        _21InfrastructureErectionInstallations = Context._21InfrastructureErectionInstallations
                            .Where(i => i.ProjectId == p.ProjectId)
                            .ToList(),
                        _22_1InfoOnPackages = Context._22_1InfoOnPackages
                            .Where(i => i.ProjectId == p.ProjectId)
                            .ToList(),
                        _23OriginalAndRevisedProvisionTargets = Context._23OriginalAndRevisedProvisionTargets
                            .Where(o => o.ProjectId == p.ProjectId)
                            .ToList(),
                        _24RevisedADPAllocationAndProgresses = Context._24RevisedADPAllocationAndProgresses
                            .Where(r => r.ProjectId == p.ProjectId)
                            .ToList(),
                        _25ObjectiveAchievements = Context._25ObjectiveAchievements
                            .Where(o => o.ProjectId == p.ProjectId)
                            .ToList(),
                        _26AnnualOutputs = Context._26AnnualOutputs
                            .Where(a => a.ProjectId == p.ProjectId)
                            .ToList(),
                        _27CostBenefits = Context._27CostBenefits
                            .Where(c => c.ProjectId == p.ProjectId)
                            .ToList(),
                        _29Monitorings = Context._29Monitorings
                            .Where(m => m.ProjectId == p.ProjectId)
                            .ToList(),
                        _30_1InternalAudits = Context._30_1InternalAudits
                            .Where(i => i.ProjectId == p.ProjectId)
                            .ToList(),
                        _30_2ExternalAudits = Context._30_2ExternalAudits
                            .Where(e => e.ProjectId == p.ProjectId)
                            .ToList(),
                        _30Auditings = Context._30Auditings
                            .Where(a => a.ProjectId == p.ProjectId)
                            .ToList(),
                        _G_PostProjectRemark = Context._G_PostProjectRemarks
                            .Where(r => r.ProjectId == p.ProjectId)
                            .FirstOrDefault()
                    })
                    .FirstOrDefaultAsync();

                if (projectModel == null)
                {
                    return NotFound();
                }

                var pdf = new ViewAsPdf("Details", projectModel)
                {
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageMargins = new Rotativa.AspNetCore.Options.Margins(10, 10, 10, 10)
                };

                byte[] pdfBytes = await pdf.BuildFile(ControllerContext);

                var result = new FileContentResult(pdfBytes, "application/pdf");
                Response.Headers["Content-Disposition"] = "inline";
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while retrieving the project details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var project = await Context.Projects.FindAsync(id);
                if (project == null)
                {
                    return Json(new { success = false, message = "Project not found" });
                }

                Context.Projects.Remove(project);
                await Context.SaveChangesAsync();
                return Json(new { success = true, message = "Project deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}