using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCRMS.Models;
using ProjectCompletionReport.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ProjectCompletionReport.Controllers
{

    [Authorize(Roles = "Admin")] // Restrict to Admin role
    public class CreateUserController : Controller
    {
        private readonly ApplicationDBContext Context;

        public CreateUserController(ApplicationDBContext context)
        {
            Context = context;
        }

        [Route("/CreateUser")]
        public IActionResult Index()
        {
            return View(new User()); // Pass empty User object to view
        }

        [HttpPost]
        [Route("/CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            // Server-side validation
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash) || string.IsNullOrEmpty(user.Role))
            {
                ModelState.AddModelError("", "Username, Password, and Role are required.");
                return View("Index", user);
            }

            // Check for duplicate username or email
            if (await Context.Users.AnyAsync(u => u.Username == user.Username || (user.Email != null && u.Email == user.Email)))
            {
                ModelState.AddModelError("", "Username or Email already exists.");
                return View("Index", user);
            }

            // Hash the password (received as plain text from form)
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.Signature = user.Signature ?? new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }; // Placeholder if null
            user.CreatedDate = DateTime.Now; // Set manually, or rely on DB default
            user.IsActive = true; // Default to active

            Context.Users.Add(user);
            await Context.SaveChangesAsync();

            TempData["SuccessMessage"] = "User created successfully!";
            return RedirectToAction("Index");
        }
    }
    
}
