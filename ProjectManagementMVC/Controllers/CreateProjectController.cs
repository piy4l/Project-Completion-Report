using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;

namespace ProjectCompletionReport.Controllers
{
    using System.Security.Claims;
    using ProjectCompletionReport.Models;
    public class CreateProjectController : Controller
    {
        public ApplicationDBContext Context { get; } 
        public CreateProjectController(ApplicationDBContext context)
        {
            Context = context;
        }
   
        public IActionResult Index()
        {
            return View("Index");
        }


        [Authorize(Roles = "PD")]
        [Route("/SaveProject")]
        [HttpPost]
        public IActionResult SaveProject([FromBody] Project payload)
        {
            try
            {
                if (payload == null)
                {
                    throw new ArgumentNullException(nameof(payload), "Project payload cannot be null");
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "User not authenticated" });
                }
                payload.CreatedByUserId = userId;

                // CreatedDate is handled by the database's DEFAULT GETDATE(), no need to set it

                Context.Projects.Add(payload);
                Context.SaveChanges();

                return Ok(new { message = "success", projectId = payload.ProjectId });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Error: {ex.Message}, Inner Exception: {innerException}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message} | Inner Exception: {innerException}");
            }
        }


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
