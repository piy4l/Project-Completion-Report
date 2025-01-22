using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;

namespace ProjectCompletionReport.Controllers
{
    
    public class ProjectsController : Controller
    {
        public ProjectsController(ApplicationDBContext context)
        {
            Context = context;
        }

        public ApplicationDBContext Context { get; }

        
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
            catch
            {
                // Log.Error("API call failed. URL: {url} User: {UserName}", HttpContext.Request.Path, HttpContext.Request.Cookies["UserName"]);
                return Problem("Failed to insert");
            }
            return Ok(new { message = "success" });

            
        }
    }
}
