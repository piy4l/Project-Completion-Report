//Author:
//Souvik Das
//Assistant Programmer, BCC
//BSc in CSE, BUET
//PhD Student, Department of CSCE, Texas A&M University 

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Models;
using X.PagedList;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using ProjectCompletionReport.Services;

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
        [HttpGet]
        public async Task<IActionResult> Index(string searchString = "", int? page = null, int? pageSize = null)
        {
            int currentPageSize = pageSize ?? 10;
            int pageNumber = page ?? 1;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var projectsQuery = _context.Projects.AsQueryable();

            // Filter based on role
            if (User.IsInRole("PD"))
            {
                projectsQuery = projectsQuery.Where(p => p.CreatedByUserId == userId); // Only PD's projects
            }
            // ED and Sec see all projects, no additional filter

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

            // Fetch paginated results, ordered by CreatedDate descending
            var projects = totalCount > 0
                ? await projectsQuery
                    .OrderByDescending(p => p.CreatedDate) // Sort by creation date, latest first
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
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var draftsQuery = _context.Projects
                .Where(p => p.Status == "DraftPD" || p.Status == "DraftED" || p.Status == "DraftSec")
                .AsQueryable();

            // Filter based on role
            if (User.IsInRole("PD"))
            {
                draftsQuery = draftsQuery.Where(p => p.Status == "DraftPD" && p.CreatedByUserId == userId);
            }
            else if (User.IsInRole("ED"))
            {
                draftsQuery = draftsQuery.Where(p => p.Status == "DraftED");
            }
            else if (User.IsInRole("Sec"))
            {
                draftsQuery = draftsQuery.Where(p => p.Status == "DraftSec");
            }

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                draftsQuery = draftsQuery.Where(p => p.Name.ToLower().Contains(searchString));
            }

            // Get total count after filtering
            var totalCount = await draftsQuery.CountAsync();
            int totalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)currentPageSize) : 0;

            // Adjust page number
            pageNumber = pageNumber < 1 ? 1 : totalPages == 0 ? 1 : pageNumber > totalPages ? totalPages : pageNumber;

            // Fetch paginated results, ordered by CreatedDate descending
            var drafts = totalCount > 0
                ? await draftsQuery
                    .OrderByDescending(p => p.CreatedDate) // Sort by creation date, latest first
                    .Skip((pageNumber - 1) * currentPageSize)
                    .Take(currentPageSize)
                    .ToListAsync()
                : new List<Project>();

            var pagedDrafts = new StaticPagedList<Project>(drafts, pageNumber, currentPageSize, totalCount);

            ViewBag.PageSize = currentPageSize;
            ViewBag.SearchString = searchString;
            ViewData["IsDraftsView"] = true;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProjectsTable", pagedDrafts);
            }

            return View("Drafts", pagedDrafts);
        }

        // Other actions (Details, Attachment, Delete, Action, ForwardToED, etc.) remain unchanged
        // ...
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


        public async Task<IActionResult> Attachment(int? id)
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

                    })
                    .FirstOrDefaultAsync();

                if (projectModel == null)
                {
                    return NotFound();
                }
                var attachment = projectModel.Project.Attachment;

                // Since we don't have ContentType, we'll try to detect it or use a default
                const string contentType = "application/pdf";
                string fileName = $"attachment_{id}.dat"; // Default filename

                // If it's a PDF, adjust the filename
                if (contentType == "application/pdf")
                {
                    fileName = $"attachment_{id}.pdf";
                }

                return File(attachment, contentType, fileName);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the project details.");
            }
        }


        [HttpPost]
        [Authorize] // Ensure user is authenticated
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var project = await _context.Projects.FindAsync(id);
                if (project == null)
                {
                    return Json(new { success = false, message = "Project not found" });
                }

                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var isAdmin = User.IsInRole("Admin");
                var isPD = User.IsInRole("PD");

                // Authorization logic
                if (!isAdmin && !(isPD && project.CreatedByUserId == userId))
                {
                    return Json(new { success = false, message = "Unauthorized: You do not have permission to delete this project" });
                }

                // Optional: Restrict deletion to draft status if needed
                if (project.Status != "DraftPD" && project.Status != "DraftED" && project.Status != "DraftSec")
                {
                    return Json(new { success = false, message = "Only draft projects can be deleted" });
                }

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
            if (!id.HasValue)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id.Value);
            if (project == null)
            {
                return NotFound();
            }

            var currentRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if ((currentRole == "PD" && project.Status != "DraftPD") ||
                (currentRole == "ED" && project.Status != "DraftED") ||
                (currentRole == "Sec" && project.Status != "DraftSec"))
            {
                return RedirectToAction("Drafts"); // Redirect if project isn’t in user’s draft status
            }

            ViewData["ProjectName"] = project.Name;
            return View("Action", id);
        }



        [Authorize(Roles = "PD")]
        [HttpPost]
        [Route("/ForwardToED")]
        public async Task<IActionResult> ForwardToED(
            [FromForm] int ProjectId,
            [FromForm] string Status,
            [FromForm] string _36RemarksPD,
            [FromForm] string _36DatePD,
            [FromForm] IFormFile _36SignPD,
            [FromForm] IFormFile _36SealPD)
        {
            return await ProcessForward(ProjectId, Status, "_36RemarksPD", "_36SignPD", "_36SealPD", "_36DatePD", _36RemarksPD, _36SignPD, _36SealPD, _36DatePD);
        }

        [Authorize(Roles = "ED")]
        [HttpPost]
        [Route("/ForwardToSecretary")]
        public async Task<IActionResult> ForwardToSecretary(
            [FromForm] int ProjectId,
            [FromForm] string Status,
            [FromForm] string _36RemarksED,
            [FromForm] string _36DateED,
            [FromForm] IFormFile _36SignED,
            [FromForm] IFormFile _36SealED)
        {
            return await ProcessForward(ProjectId, Status, "_36RemarksED", "_36SignED", "_36SealED", "_36DateED", _36RemarksED, _36SignED, _36SealED, _36DateED);
        }

        [Authorize(Roles = "Sec")]
        [HttpPost]
        [Route("/SendBackToED")]
        public async Task<IActionResult> SendBackToED(
            [FromForm] int ProjectId,
            [FromForm] string Status,
            [FromForm] string _36RemarksSec,
            [FromForm] string _36DateSec,
            [FromForm] IFormFile _36SignSec,
            [FromForm] IFormFile _36SealSec)
        {
            return await ProcessForward(ProjectId, Status, "_36RemarksSec", "_36SignSec", "_36SealSec", "_36DateSec", _36RemarksSec, _36SignSec, _36SealSec, _36DateSec);
        }

        [Authorize(Roles = "ED")]
        [HttpPost]
        [Route("/SendBackToPD")]
        public async Task<IActionResult> SendBackToPD(
            [FromForm] int ProjectId,
            [FromForm] string Status,
            [FromForm] string _36RemarksED,
            [FromForm] string _36DateED,
            [FromForm] IFormFile _36SignED,
            [FromForm] IFormFile _36SealED)
        {
            return await ProcessForward(ProjectId, Status, "_36RemarksED", "_36SignED", "_36SealED", "_36DateED", _36RemarksED, _36SignED, _36SealED, _36DateED);
        }

        [Authorize(Roles = "Sec")]
        [HttpPost]
        [Route("/MarkAsComplete")]
        public async Task<IActionResult> MarkAsComplete(
            [FromForm] int ProjectId,
            [FromForm] string Status,
            [FromForm] string _36RemarksSec,
            [FromForm] string _36DateSec,
            [FromForm] IFormFile _36SignSec,
            [FromForm] IFormFile _36SealSec)
        {
            return await ProcessForward(ProjectId, Status, "_36RemarksSec", "_36SignSec", "_36SealSec", "_36DateSec", _36RemarksSec, _36SignSec, _36SealSec, _36DateSec);
        }

        private async Task<IActionResult> ProcessForward(
            int projectId,
            string status,
            string remarksField,
            string signField,
            string sealField,
            string dateField,
            string remarks,
            IFormFile signature,
            IFormFile seal,
            string date)
        {
            try
            {
                var project = _context.Projects.Find(projectId);
                if (project == null) return NotFound();

                var remark = _context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == projectId) ?? new _G_PostProjectRemark { ProjectId = projectId };

                project.Status = status;

                typeof(_G_PostProjectRemark).GetProperty(remarksField)?.SetValue(remark, remarks);
                typeof(_G_PostProjectRemark).GetProperty(dateField)?.SetValue(remark, date);

                if (signature != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await signature.CopyToAsync(ms);
                        typeof(_G_PostProjectRemark).GetProperty(signField)?.SetValue(remark, ms.ToArray());
                    }
                }
                if (seal != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await seal.CopyToAsync(ms);
                        typeof(_G_PostProjectRemark).GetProperty(sealField)?.SetValue(remark, ms.ToArray());
                    }
                }

                if (remark.Id == 0)
                    _context._G_PostProjectRemarks.Add(remark);
                else
                    _context._G_PostProjectRemarks.Update(remark);

                _context.Projects.Update(project);
                await _context.SaveChangesAsync();

                return Ok(new { projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("/User/GetSignature")]
        public IActionResult GetSignature()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user?.Signature == null) return NotFound("Signature not found in profile.");
            return File(user.Signature, "image/png", "signature.png");
        }

        [HttpGet]
        [Route("/User/GetSeal")]
        public IActionResult GetSeal()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user?.Seal == null) return NotFound("Seal not found in profile.");
            return File(user.Seal, "image/png", "seal.png");
        }

        // Other actions (Details, Attachment, Delete, Action) remain unchanged
        // ...
    }
}