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
                Context._06LocationOfTheProjects.AddRange(payload); // Bulk insert
                Context.SaveChanges(); // Save once

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
                Context._07EstimatedCostPeriodApprovals.AddRange(payload); // Bulk insert
                Context.SaveChanges(); // Save once

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
        public ActionResult SaveLoanGrantForeignFinancing([FromBody] _12_1aStatusOfLoanGrantForeignFinancing[] data)
        {
            try
            {
                Context._12_1aStatusOfLoanGrantForeignFinancings.AddRange(data); // Bulk insert
                Context.SaveChanges(); // Save once

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
