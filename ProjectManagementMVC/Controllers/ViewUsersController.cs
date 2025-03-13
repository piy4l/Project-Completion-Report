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
    [Authorize(Roles = "Admin")]
    public class ViewUsersController : Controller
    {
        private readonly ApplicationDBContext _context;
        private const int DefaultPageSize = 5;

        public ViewUsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [Route("/ViewUsers")]
        public async Task<IActionResult> Index(string searchString = "", int pageSize = DefaultPageSize, int page = 1)
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

            // Ensure pageSize is valid
            pageSize = pageSize switch
            {
                5 => 5,
                10 => 10,
                25 => 25,
                50 => 50,
                _ => DefaultPageSize
            };

            // Get total count after filtering
            int totalUsers = await usersQuery.CountAsync();
            int totalPages = totalUsers > 0 ? (int)Math.Ceiling(totalUsers / (double)pageSize) : 0;

            // Adjust page number
            page = page < 1 ? 1 : totalPages == 0 ? 1 : page > totalPages ? totalPages : page;

            // Fetch paginated results (only if there are results)
            var users = totalUsers > 0
                ? await usersQuery
                    .OrderBy(u => u.Username)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync()
                : new List<User>();

            // Pass data to view
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(users);
        }

        [HttpPost]
        [Route("/ViewUsers/ToggleActive/{id}")]
        [ValidateAntiForgeryToken]
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