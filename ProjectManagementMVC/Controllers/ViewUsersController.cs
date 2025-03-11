using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCRMS.Models;
using ProjectCompletionReport.Services;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ProjectCompletionReport.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict to Admin role
    public class ViewUsersController : Controller
    {
        private readonly ApplicationDBContext _context;
        private const int PageSize = 5; // Number of users per page

        public ViewUsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [Route("/ViewUsers")]
        public async Task<IActionResult> Index(string searchString = "", int page = 1)
        {
            var usersQuery = _context.Users.AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                usersQuery = usersQuery.Where(u => u.Username.ToLower().Contains(searchString) ||
                                                  (u.Name != null && u.Name.ToLower().Contains(searchString)) ||
                                                  (u.Email != null && u.Email.ToLower().Contains(searchString)));
            }

            // Get total count for pagination
            int totalUsers = await usersQuery.CountAsync();
            int totalPages = (int)Math.Ceiling(totalUsers / (double)PageSize);

            // Ensure page is within bounds
            page = page < 1 ? 1 : page > totalPages ? totalPages : page;

            // Apply pagination
            var users = await usersQuery
                .OrderBy(u => u.Username)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            // Pass data to view via ViewBag
            ViewBag.SearchString = searchString;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(users);
        }

        [HttpPost]
        [Route("/ViewUsers/ToggleActive/{id}")]
        public async Task<IActionResult> ToggleActive(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"User '{user.Username}' status updated to {(user.IsActive ? "Active" : "Inactive")}.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/ViewUsers/UpdatePassword/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(int id, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6)
            {
                TempData["ErrorMessage"] = "Password must be at least 6 characters long.";
                return RedirectToAction("Index");
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Password updated for user '{user.Username}'.";
            return RedirectToAction("Index");
        }
    }
}