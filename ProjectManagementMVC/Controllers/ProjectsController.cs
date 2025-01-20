using Microsoft.AspNetCore.Mvc;
using ProjectManagementMVC.Services;

namespace ProjectManagementMVC.Controllers
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
            var personalInfos = Context.PersonalInfos.ToList();
            return View(personalInfos);
        }
    }
}
