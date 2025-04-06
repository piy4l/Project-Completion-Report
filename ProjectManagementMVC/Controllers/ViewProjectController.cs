using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Models;
using X.PagedList;
using Rotativa.AspNetCore;
using ProjectCompletionReport.Services;
using Microsoft.AspNetCore.Authorization;

namespace ProjectCompletionReport.Controllers
{
    public class ViewProjectController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ViewProjectController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Index action for all projects
        public async Task<IActionResult> Index(string searchString = "", int? page = null, int? pageSize = null)
        {
            int currentPageSize = pageSize ?? 10;
            int pageNumber = page ?? 1;

            var projectsQuery = _context.Projects.AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                projectsQuery = projectsQuery.Where(p => p.Name.ToLower().Contains(searchString));
            }

            // Get total count after filtering
            var totalCount = await projectsQuery.CountAsync();
            int totalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)currentPageSize) : 0;

            // Adjust page number
            pageNumber = pageNumber < 1 ? 1 : totalPages == 0 ? 1 : pageNumber > totalPages ? totalPages : pageNumber;

            // Fetch paginated results (only if there are results)
            var projects = totalCount > 0
                ? await projectsQuery
                    .OrderBy(p => p.ProjectId)
                    .Skip((pageNumber - 1) * currentPageSize)
                    .Take(currentPageSize)
                    .ToListAsync()
                : new List<Project>();

            var pagedProjects = new StaticPagedList<Project>(projects, pageNumber, currentPageSize, totalCount);

            ViewBag.PageSize = currentPageSize;
            ViewBag.SearchString = searchString;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProjectsTable", pagedProjects);
            }

            return View(pagedProjects);
        }

        // Drafts action for draft projects only
        [HttpGet]
        public async Task<IActionResult> Drafts(string searchString = "", int? page = null, int? pageSize = null)
        {
            int currentPageSize = pageSize ?? 10;
            int pageNumber = page ?? 1;

            var draftsQuery = _context.Projects
                .Where(p => p.Status == "DraftPD" || p.Status == "DraftED" || p.Status == "DraftSec")
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                draftsQuery = draftsQuery.Where(p => p.Name.ToLower().Contains(searchString));
            }

            var totalCount = await draftsQuery.CountAsync();
            int totalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)currentPageSize) : 0;

            pageNumber = pageNumber < 1 ? 1 : totalPages == 0 ? 1 : pageNumber > totalPages ? totalPages : pageNumber;

            var drafts = totalCount > 0
                ? await draftsQuery
                    .OrderBy(p => p.ProjectId)
                    .Skip((pageNumber - 1) * currentPageSize)
                    .Take(currentPageSize)
                    .ToListAsync()
                : new List<Project>();

            var pagedDrafts = new StaticPagedList<Project>(drafts, pageNumber, currentPageSize, totalCount);

            ViewBag.PageSize = currentPageSize;
            ViewBag.SearchString = searchString;
            ViewData["IsDraftsView"] = true; // Set flag for drafts view

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProjectsTable", pagedDrafts);
            }

            return View("Drafts", pagedDrafts);
        }

        // Details action (unchanged)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
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

                if (projectModel == null)
                {
                    return NotFound();
                }
                // return View(projectModel);

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
                return StatusCode(500, "An error occurred while retrieving the project details.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var project = await _context.Projects.FindAsync(id);
                if (project == null)
                {
                    return Json(new { success = false, message = "Project not found" });
                }

                // Optional: Restrict deletion to DraftPD status or specific roles if needed
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Project deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Action(int? id)
        {
            return View("Action", id);
        }

    }
}