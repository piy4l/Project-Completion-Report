using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;

namespace ProjectCompletionReport.Controllers
{
    using System.Security.Claims;
    using Microsoft.EntityFrameworkCore;
    using ProjectCompletionReport.Models;
    public class CreateProjectController : Controller
    {
        public ApplicationDBContext Context { get; } 
        public CreateProjectController(ApplicationDBContext context)
        {
            Context = context;
        }

        [Authorize(Roles = "PD,ED,Sec")]
        public IActionResult Index(int? projectId)
        {
            Project project;
            _G_PostProjectRemark remark;

            if (projectId.HasValue)
            {
                project = Context.Projects.FirstOrDefault(p => p.ProjectId == projectId.Value);
                if (project == null) return NotFound();
                remark = Context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == projectId.Value) ?? new _G_PostProjectRemark { ProjectId = projectId.Value };
            }
            else
            {
                project = new Project { Status = "DraftPD" }; // Initial status is DraftPD
                remark = new _G_PostProjectRemark();
            }

            ViewData["Remark"] = remark;
            return View("Index", project);
        }

        [Authorize(Roles = "PD")]
        [HttpPost]
        [Route("/SaveProject")]
        public IActionResult SaveProject([FromBody] Project payload)
        {
            try
            {
                if (payload == null) throw new ArgumentNullException(nameof(payload), "Project payload cannot be null");

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int userId)) return Unauthorized(new { message = "User not authenticated" });

                payload.CreatedByUserId = userId;
                payload.Status ??= "DraftPD"; // Default to DraftPD if not set

                if (payload.ProjectId == 0)
                {
                    Context.Projects.Add(payload);
                }
                else
                {
                    Context.Projects.Update(payload);
                }
                Context.SaveChanges();

                return Ok(new { message = "success", projectId = payload.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

        [Authorize(Roles = "PD")]
        [HttpPost]
        [Route("/SaveAsDraft")]
        public async Task<IActionResult> SaveAsDraft([FromBody] Project payload) // Changed to [FromBody]
        {
            try
            {
                if (payload == null) throw new ArgumentNullException(nameof(payload), "Project payload cannot be null");

                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var project = payload.ProjectId == 0 ? new Project { CreatedByUserId = userId, Status = "DraftPD" } : Context.Projects.Find(payload.ProjectId);
                if (project == null) return NotFound();

                UpdateProjectFields(project, payload);
                project.Status = "DraftPD"; // PD saves as draft

                if (payload.ProjectId == 0)
                {
                    Context.Projects.Add(project);
                }
                else
                {
                    Context.Projects.Update(project);
                }
                await Context.SaveChangesAsync();

                return Ok(new { message = "Draft saved", projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

        [Authorize(Roles = "PD")]
        [HttpPost]
        [Route("/ForwardToED")]
        public async Task<IActionResult> ForwardToED([FromForm] Project payload, [FromForm] _G_PostProjectRemark remarkPayload, IFormFile _36SignPD, IFormFile _36SealPD)
        {
            try
            {
                var project = Context.Projects.Find(payload.ProjectId);
                if (project == null) return NotFound();

                if (_36SignPD == null || _36SealPD == null) return BadRequest("PD signature and seal are required");

                UpdateProjectFields(project, payload);
                project.Status = "DraftED"; // Forward to ED

                var remark = Context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == project.ProjectId) ?? new _G_PostProjectRemark { ProjectId = project.ProjectId };
                UpdateRemarkFields(remark, remarkPayload);
                remark._36SignPD = FileToByteArray(_36SignPD);
                remark._36SealPD = FileToByteArray(_36SealPD);
                remark._36RemarksPD = remarkPayload._36RemarksPD;
                remark._36DatePD = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

                Context.Projects.Update(project);
                if (remark.Id == 0) Context._G_PostProjectRemarks.Add(remark);
                else Context._G_PostProjectRemarks.Update(remark);
                await Context.SaveChangesAsync();

                return Ok(new { message = "Forwarded to ED", projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

        [Authorize(Roles = "ED")]
        [HttpPost]
        [Route("/ForwardToSecretary")]
        public async Task<IActionResult> ForwardToSecretary([FromForm] _G_PostProjectRemark remarkPayload, IFormFile _36SignAH, IFormFile _36SealAH)
        {
            try
            {
                var project = Context.Projects.Find(remarkPayload.ProjectId);
                if (project == null || project.Status != "DraftED") return NotFound();

                if (_36SignAH == null || _36SealAH == null) return BadRequest("ED signature and seal are required");

                project.Status = "DraftSec"; // Forward to Sec

                var remark = Context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == project.ProjectId) ?? new _G_PostProjectRemark { ProjectId = project.ProjectId };
                UpdateRemarkFields(remark, remarkPayload);
                remark._36SignAH = FileToByteArray(_36SignAH);
                remark._36SealAH = FileToByteArray(_36SealAH);
                remark._36RemarksAH = remarkPayload._36RemarksAH;
                remark._36DateAH = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

                Context.Projects.Update(project);
                if (remark.Id == 0) Context._G_PostProjectRemarks.Add(remark);
                else Context._G_PostProjectRemarks.Update(remark);
                await Context.SaveChangesAsync();

                return Ok(new { message = "Forwarded to Secretary", projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

        [Authorize(Roles = "ED")]
        [HttpPost]
        [Route("/SendBackToPD")]
        public async Task<IActionResult> SendBackToPD([FromForm] _G_PostProjectRemark remarkPayload)
        {
            try
            {
                var project = Context.Projects.Find(remarkPayload.ProjectId);
                if (project == null || project.Status != "DraftED") return NotFound();

                project.Status = "DraftPD"; // Send back to PD

                var remark = Context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == project.ProjectId) ?? new _G_PostProjectRemark { ProjectId = project.ProjectId };
                UpdateRemarkFields(remark, remarkPayload);
                remark._36RemarksAH = remarkPayload._36RemarksAH;
                remark._36DateAH = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

                Context.Projects.Update(project);
                if (remark.Id == 0) Context._G_PostProjectRemarks.Add(remark);
                else Context._G_PostProjectRemarks.Update(remark);
                await Context.SaveChangesAsync();

                return Ok(new { message = "Sent back to PD", projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

        [Authorize(Roles = "Sec")]
        [HttpPost]
        [Route("/MarkAsComplete")]
        public async Task<IActionResult> MarkAsComplete([FromForm] _G_PostProjectRemark remarkPayload, IFormFile _36SignSec, IFormFile _36SealSec)
        {
            try
            {
                var project = Context.Projects.Find(remarkPayload.ProjectId);
                if (project == null || project.Status != "DraftSec") return NotFound();

                if (_36SignSec == null || _36SealSec == null) return BadRequest("Secretary signature and seal are required");

                project.Status = "Complete"; // Mark as complete

                var remark = Context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == project.ProjectId) ?? new _G_PostProjectRemark { ProjectId = project.ProjectId };
                UpdateRemarkFields(remark, remarkPayload);
                remark._36SignSec = FileToByteArray(_36SignSec);
                remark._36SealSec = FileToByteArray(_36SealSec);
                remark._36RemarksSec = remarkPayload._36RemarksSec;
                remark._36DateSec = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

                Context.Projects.Update(project);
                if (remark.Id == 0) Context._G_PostProjectRemarks.Add(remark);
                else Context._G_PostProjectRemarks.Update(remark);
                await Context.SaveChangesAsync();

                return Ok(new { message = "Marked as Complete", projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

        [Authorize(Roles = "Sec")]
        [HttpPost]
        [Route("/SendBackToED")]
        public async Task<IActionResult> SendBackToED([FromForm] _G_PostProjectRemark remarkPayload)
        {
            try
            {
                var project = Context.Projects.Find(remarkPayload.ProjectId);
                if (project == null || project.Status != "DraftSec") return NotFound();

                project.Status = "DraftED"; // Send back to ED

                var remark = Context._G_PostProjectRemarks.FirstOrDefault(r => r.ProjectId == project.ProjectId) ?? new _G_PostProjectRemark { ProjectId = project.ProjectId };
                UpdateRemarkFields(remark, remarkPayload);
                remark._36RemarksSec = remarkPayload._36RemarksSec;
                remark._36DateSec = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

                Context.Projects.Update(project);
                if (remark.Id == 0) Context._G_PostProjectRemarks.Add(remark);
                else Context._G_PostProjectRemarks.Update(remark);
                await Context.SaveChangesAsync();

                return Ok(new { message = "Sent back to ED", projectId = project.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message ?? "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }






        private byte[] FileToByteArray(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }

        private void UpdateProjectFields(Project target, Project source)
        {
            target.Name = source.Name;
            target.Budget = source.Budget;
            target.Duration = source.Duration;
            target.AdministrativeMinistryDivision = source.AdministrativeMinistryDivision;
            target.ExecutingAgency = source.ExecutingAgency;
            target.PlanningCommissionSectorDivision = source.PlanningCommissionSectorDivision;
            target.Type = source.Type;
            target.OverallObjective = source.OverallObjective;
            target.SpecificObjectives = source.SpecificObjectives;
            target.Background = source.Background;
            target.MajorActivities = source.MajorActivities;
            target.ReasonsForRevision = source.ReasonsForRevision;
            target.ReasonsForNoCostTimeExtension = source.ReasonsForNoCostTimeExtension;
            target.Attachment = source.Attachment;
        }

        private void UpdateRemarkFields(_G_PostProjectRemark target, _G_PostProjectRemark source)
        {
            target.Background = source.Background;
            target.JustificationAdequacy = source.JustificationAdequacy;
            target.Objectives = source.Objectives;
            target.ProjectRevisionWithReasons = source.ProjectRevisionWithReasons;
            target.Concept = source.Concept;
            target.Design = source.Design;
            target.Location = source.Location;
            target.Timing = source.Timing;
            target.ProjectIdentification = source.ProjectIdentification;
            target.ProjectPreparation = source.ProjectPreparation;
            target.Appraisal = source.Appraisal;
            target.CreditNegotiation = source.CreditNegotiation;
            target.CreditAgreement = source.CreditAgreement;
            target.CreditEffectiveness = source.CreditEffectiveness;
            target.LoanDisbursement = source.LoanDisbursement;
            target.LoanConditions = source.LoanConditions;
            target.ProjectApproval = source.ProjectApproval;
            target.OthersSpecify = source.OthersSpecify;
            target._34_1 = source._34_1;
            target._34_2 = source._34_2;
            target._34_3 = source._34_3;
            target._34_4 = source._34_4;
            target._34_5 = source._34_5;
            target._34_6 = source._34_6;
            target._34_7 = source._34_7;
            target._34_8 = source._34_8;
            target._34_9 = source._34_9;
            target._34_10 = source._34_10;
            target._34_11 = source._34_11;
            target._34_12 = source._34_12;
            target._34_13 = source._34_13;
            target._34_14 = source._34_14;
            target._34_15 = source._34_15;
            target._35_1 = source._35_1;
            target._35_2 = source._35_2;
            target._35_3 = source._35_3;
            target._35_4 = source._35_4;
            target._35_5 = source._35_5;
            target._35_6 = source._35_6;
            target._35_7 = source._35_7;
            target._35_8 = source._35_8;
            target._35_9 = source._35_9;
            target._35_10 = source._35_10;
            target._35_11 = source._35_11;
            target._35_12 = source._35_12;
            target._35_13 = source._35_13;
            target._35_14 = source._35_14;
            target._35_15 = source._35_15;
            target._35_16 = source._35_16;
            target._35_17 = source._35_17;
            target._35_18 = source._35_18;
            target._35_19 = source._35_19;
            target._28ReasonsForShortFall = source._28ReasonsForShortFall;
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveLocationOfTheProject")]
        [HttpPost]
        public ActionResult SaveLocationOfTheProject([FromBody] _06LocationOfTheProject[] payload)
        {
            try
            {
                Context._06LocationOfTheProjects.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveEstimatedCostPeriodApproval")]
        [HttpPost]
        public ActionResult SaveEstimatedCostPeriodApproval([FromBody] _07EstimatedCostPeriodApproval[] payload)
        {
            try
            {
                Context._07EstimatedCostPeriodApprovals.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveLoanGrantForeignFinancing")]
        [HttpPost]
        public ActionResult SaveLoanGrantForeignFinancing([FromBody] _12_1aStatusOfLoanGrantForeignFinancing[] payload)
        {
            try
            {
                Context._12_1aStatusOfLoanGrantForeignFinancings.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveLoanGrantGOB")]
        [HttpPost]
        public ActionResult SaveLoanGrantGOB([FromBody] _12_1bStatusOfLoanGrantGOB[] payload)
        {
            try
            {
                Context._12_1bStatusOfLoanGrantGOBs.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveLoanGrantSelfFinanceEquity")]
        [HttpPost]
        public ActionResult SaveLoanGrantSelfFinanceEquity([FromBody] _12_1cStatusOfLoanGrantSelfFinanceEquity[] payload)
        {
            try
            {
                Context._12_1cStatusOfLoanGrantSelfFinanceEquities.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveUtilizationOfProjectAid")]
        [HttpPost]
        public ActionResult SaveUtilizationOfProjectAid([FromBody] _12_2UtilizationOfProjectAid[] payload)
        {
            try
            {
                Context._12_2UtilizationOfProjectAids.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveReimbursableProjectAid")]
        [HttpPost]
        public ActionResult SaveReimbursableProjectAid([FromBody] _12_3ReimbursableProjectAid[] payload)
        {
            try
            {
                Context._12_3ReimbursableProjectAids.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveImplementationPeriod")]
        [HttpPost]
        public ActionResult SaveImplementationPeriod([FromBody] _13ImplementationPeriod[] payload)
        {
            try
            {
                Context._13ImplementationPeriods.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveCostOfTheProject")]
        [HttpPost]
        public ActionResult SaveCostOfTheProject([FromBody] _14CostOfTheProject[] payload)
        {
            try
            {
                Context._14CostOfTheProjects.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveInfoProjectDirector")]
        [HttpPost]
        public ActionResult SaveInfoProjectDirector([FromBody] _15InfoProjectDirector[] payload)
        {
            try
            {
                Context._15InfoProjectDirectors.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SavePersonnelOfPIU")]
        [HttpPost]
        public ActionResult SavePersonnelOfPIU([FromBody] _16_1PersonnelOfPIU[] payload)
        {
            try
            {
                Context._16_1PersonnelOfPIUs.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SavePersonnelRequiredAfterCompletion")]
        [HttpPost]
        public ActionResult SavePersonnelRequiredAfterCompletion([FromBody] _16_2PersonnelRequiredAfterCompletion[] payload)
        {
            try
            {
                Context._16_2PersonnelRequiredAfterCompletions.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SavePersonnel")]
        [HttpPost]
        public ActionResult SavePersonnel([FromBody] _16Personnel payload)
        {
            try
            {
                Context._16Personnels.Add(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveTrainingForeignLocal")]
        [HttpPost]
        public ActionResult SaveTrainingForeignLocal([FromBody] _17TrainingForeignLocal[] payload)
        {
            try
            {
                Context._17TrainingForeignLocals.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveComponentWiseProgress")]
        [HttpPost]
        public ActionResult SaveComponentWiseProgress([FromBody] _18ComponentWiseProgress[] payload)
        {
            try
            {
                Context._18ComponentWiseProgresses.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/Save_17_18Total")]
        [HttpPost]
        public ActionResult Save_17_18Total([FromBody] _17_18Total payload)
        {
            try
            {
                Context._17_18Totals.Add(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveProcurementOfTransport")]
        [HttpPost]
        public ActionResult SaveProcurementOfTransport([FromBody] _19ProcurementOfTransport[] payload)
        {
            try
            {
                Context._19ProcurementOfTransports.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveProjectConsultant")]
        [HttpPost]
        public ActionResult SaveProjectConsultant([FromBody] _20ProjectConsultant[] payload)
        {
            try
            {
                Context._20ProjectConsultants.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveInfrastructureErectionInstalation")]
        [HttpPost]
        public ActionResult SaveInfrastructureErectionInstalation([FromBody] _21InfrastructureErectionInstallation[] payload)
        {
            try
            {
                Context._21InfrastructureErectionInstallations.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveInfoOnPackage")]
        [HttpPost]
        public ActionResult SaveInfoOnPackage([FromBody] _22_1InfoOnPackage payload)
        {
            try
            {
                Context._22_1InfoOnPackages.Add(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveOriginalAndRevisedProvisionTarget")]
        [HttpPost]
        public ActionResult SaveOriginalAndRevisedProvisionTarget([FromBody] _23OriginalAndRevisedProvisionTarget[] payload)
        {
            try
            {
                Context._23OriginalAndRevisedProvisionTargets.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveRevisedADPAllocationAndProgress")]
        [HttpPost]
        public ActionResult SaveRevisedADPAllocationAndProgress([FromBody] _24RevisedADPAllocationAndProgress[] payload)
        {
            try
            {
                Context._24RevisedADPAllocationAndProgresses.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveObjectiveAchievement")]
        [HttpPost]
        public ActionResult SaveObjectiveAchievement([FromBody] _25ObjectiveAchievement[] payload)
        {
            try
            {
                Context._25ObjectiveAchievements.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveAnnualOutput")]
        [HttpPost]
        public ActionResult SaveAnnualOutput([FromBody] _26AnnualOutput[] payload)
        {
            try
            {
                Context._26AnnualOutputs.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveCostBenefit")]
        [HttpPost]
        public ActionResult SaveCostBenefit([FromBody] _27CostBenefit[] payload)
        {
            try
            {
                Context._27CostBenefits.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveMonitoring")]
        [HttpPost]
        public ActionResult SaveMonitoring([FromBody] _29Monitoring[] payload)
        {
            try
            {
                Context._29Monitorings.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveInternalAudit")]
        [HttpPost]
        public ActionResult SaveInternalAudit([FromBody] _30_1InternalAudit[] payload)
        {
            try
            {
                Context._30_1InternalAudits.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveExternalAudit")]
        [HttpPost]
        public ActionResult SaveExternalAudit([FromBody] _30_2ExternalAudit[] payload)
        {
            try
            {
                Context._30_2ExternalAudits.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveAuditing")]
        [HttpPost]
        public ActionResult SaveAuditing([FromBody] _30Auditing payload)
        {
            try
            {
                Context._30Auditings.Add(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SavePostProjectRemark")]
        [HttpPost]
        public async Task<ActionResult> SavePostProjectRemark([FromForm] _G_PostProjectRemark payload)
        {
            try
            {
                // Handle file uploads
                if (Request.Form.Files.Count > 0)
                {
                    var signPDFile = Request.Form.Files["_36SignPD"];
                    if (signPDFile != null && signPDFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await signPDFile.CopyToAsync(ms);
                            payload._36SignPD = ms.ToArray();
                        }
                    }

                    var sealPDFile = Request.Form.Files["_36SealPD"];
                    if (sealPDFile != null && sealPDFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await sealPDFile.CopyToAsync(ms);
                            payload._36SealPD = ms.ToArray();
                        }
                    }

                    var signAHFile = Request.Form.Files["_36SignAH"];
                    if (signAHFile != null && signAHFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await signAHFile.CopyToAsync(ms);
                            payload._36SignAH = ms.ToArray();
                        }
                    }

                    var sealAHFile = Request.Form.Files["_36SealAH"];
                    if (sealAHFile != null && sealAHFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await sealAHFile.CopyToAsync(ms);
                            payload._36SealAH = ms.ToArray();
                        }
                    }

                    var signSecFile = Request.Form.Files["_36SignSec"];
                    if (signSecFile != null && signSecFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await signSecFile.CopyToAsync(ms);
                            payload._36SignSec = ms.ToArray();
                        }
                    }

                    var sealSecFile = Request.Form.Files["_36SealSec"];
                    if (sealSecFile != null && sealSecFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await sealSecFile.CopyToAsync(ms);
                            payload._36SealSec = ms.ToArray();
                        }
                    }
                }

                Context._G_PostProjectRemarks.Add(payload);
                await Context.SaveChangesAsync(); // Use async for better performance

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveProcurementGood")]
        [HttpPost]
        public ActionResult SaveProcurementGood([FromBody] _Annex1A_ProcurementOfGood[] payload)
        {
            try
            {
                Context._Annex1A_ProcurementOfGoods.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveProcurementWork")]
        [HttpPost]
        public ActionResult SaveProcurementWork([FromBody] _Annex1B_ProcurementOfWork[] payload)
        {
            try
            {
                Context._Annex1B_ProcurementOfWorks.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveProcurementService")]
        [HttpPost]
        public ActionResult SaveProcurementService([FromBody] _Annex1C_ProcurementOfService[] payload)
        {
            try
            {
                Context._Annex1C_ProcurementOfServices.AddRange(payload);
                Context.SaveChanges();

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }

    }
}
