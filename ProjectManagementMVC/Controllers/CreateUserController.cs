using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCRMS.Models;
using ProjectCompletionReport.Services;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ProjectCompletionReport.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict to Admins
    public class CreateUserController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CreateUserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/CreateUser")]
        public IActionResult Index()
        {
            // Pass a new User object with empty fields
            return View(new User
            {
                Username = string.Empty,
                PasswordHash = string.Empty,
                Name = string.Empty,
                Designation = string.Empty,
                Email = string.Empty,
                Role = string.Empty
            });
        }

        [HttpPost]
        [Route("/CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user)
        {
            // Remove fields not in the form to avoid validation issues
            ModelState.Remove("UserId");
            ModelState.Remove("Signature");
            ModelState.Remove("Seal");
            ModelState.Remove("CreatedDate");
            ModelState.Remove("IsActive");

            // Validate password length
            if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash.Length < 6)
            {
                ModelState.AddModelError("PasswordHash", "Password must be at least 6 characters long.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                if (errors.Any())
                {
                    TempData["ErrorMessage"] = "Validation failed: " + string.Join(", ", errors);
                }
                else
                {
                    TempData["ErrorMessage"] = "Validation failed with no specific errors.";
                }
                return View("Index", user);
            }

            // Set default values
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash); // Hash the password

            // Add to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "User created successfully!";
            return RedirectToAction("Index");
        }
    }
}