using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;

namespace ProjectCompletionReport.Controllers
{
    using ProjectCompletionReport.Models;
    public class ProjectsController : Controller
    {
        public ApplicationDBContext Context { get; } 
        public ProjectsController(ApplicationDBContext context)
        {
            Context = context;
        }
   
        public IActionResult Index()
        {
            return View("Index");
        }


        [Route("/Projects/SaveProject")]
        [HttpPost]
        public IActionResult SaveProject([FromBody] Project payload)
        {
            try
            {
                if (payload == null)
                {
                    throw new ArgumentNullException(); 
                }
                Context.Projects.Add(payload);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}, StackTrace: {ex.StackTrace}");
                return Problem($"Failed to insert: {ex.Message}");
            }
            return Ok(new { message = "success", projectId = payload.ProjectId });
        }


        [Route("/Projects/SaveLocationOfTheProject")]
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


        [Route("/Projects/SaveEstimatedCostPeriodApproval")]
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


        [Route("/Projects/SaveLoanGrantForeignFinancing")]
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


        [Route("/Projects/SaveLoanGrantGOB")]
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


        [Route("/Projects/SaveLoanGrantSelfFinanceEquity")]
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


        [Route("/Projects/SaveUtilizationOfProjectAid")]
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


        [Route("/Projects/SaveReimbursableProjectAid")]
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


        [Route("/Projects/SaveImplementationPeriod")]
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



        [Route("/Projects/SaveCostOfTheProject")]
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


        [Route("/Projects/SaveInfoProjectDirector")]
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


        [Route("/Projects/SavePersonnelOfPIU")]
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


        [Route("/Projects/SavePersonnelRequiredAfterCompletion")]
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


        [Route("/Projects/SavePersonnel")]
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


        [Route("/Projects/SaveTrainingForeignLocal")]
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


        [Route("/Projects/SaveComponentWiseProgress")]
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


        [Route("/Projects/Save_17_18Total")]
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


        [Route("/Projects/SaveProcurementOfTransport")]
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


        [Route("/Projects/SaveProjectConsultant")]
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


        [Route("/Projects/SaveInfrastructureErectionInstalation")]
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


        [Route("/Projects/SaveInfoOnPackage")]
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


        [Route("/Projects/SaveOriginalAndRevisedProvisionTarget")]
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


        [Route("/Projects/SaveRevisedADPAllocationAndProgress")]
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


        [Route("/Projects/SaveObjectiveAchievement")]
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


        [Route("/Projects/SaveAnnualOutput")]
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


        [Route("/Projects/SaveCostBenefit")]
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


        [Route("/Projects/SaveMonitoring")]
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


        [Route("/Projects/SaveInternalAudit")]
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


        [Route("/Projects/SaveExternalAudit")]
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


        [Route("/Projects/SaveAuditing")]
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


        [Route("/Projects/SavePostProjectRemark")]
        [HttpPost]
        public ActionResult SavePostProjectRemark([FromBody] _G_PostProjectRemark payload)
        {
            try
            {
                Context._G_PostProjectRemarks.Add(payload);
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

        // ... Add similar controller actions for the other models ...



    }
}
