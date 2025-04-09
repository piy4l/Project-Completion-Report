//Author:
//Souvik Das
//Assistant Programmer, BCC
//BSc in CSE, BUET
//PhD Student, Department of CSCE, Texas A&M University 

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCRMS.Models;
using ProjectCompletionReport.Services;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Security.Claims;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ProjectCompletionReport.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDBContext _context;
        private const int ImageWidth = 300;
        private const int ImageHeight = 80;
        private const long MaxFileSize = 1024 * 1024; // 1MB in bytes

        public ProfileController(ApplicationDBContext context)
        {
            _context = context;
        }

        [Route("/Profile")]
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.SignatureLength = user.Signature != null ? user.Signature.Length : 0;
            ViewBag.SealLength = user.Seal != null ? user.Seal.Length : 0;

            return View(user);
        }

        [HttpPost]
        [Route("/Profile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(User updatedUser, IFormFile? signatureFile, IFormFile? sealFile, string newPassword)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Remove optional fields from ModelState
            ModelState.Remove("newPassword");
            ModelState.Remove("signatureFile");
            ModelState.Remove("sealFile");
            // Remove User properties not in the form to avoid validation errors
            ModelState.Remove("UserId");
            ModelState.Remove("Username");
            ModelState.Remove("PasswordHash");
            ModelState.Remove("Role");
            ModelState.Remove("CreatedDate");
            ModelState.Remove("IsActive");

            if (!ModelState.IsValid)
            {
                // Debug: Log ModelState errors
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                if (errors.Any())
                {
                    TempData["ErrorMessage"] = "Validation failed: " + string.Join(", ", errors);
                }
                else
                {
                    TempData["ErrorMessage"] = "Validation failed with no specific errors.";
                }

                ViewBag.SignatureLength = user.Signature != null ? user.Signature.Length : 0;
                ViewBag.SealLength = user.Seal != null ? user.Seal.Length : 0;
                return View("Index", user);
            }

            // Update editable fields
            user.Name = updatedUser.Name;
            user.Designation = updatedUser.Designation;
            user.Email = updatedUser.Email;

            // Handle file uploads (optional)
            if (signatureFile != null && signatureFile.Length > 0)
            {
                if (!IsImageFile(signatureFile))
                {
                    ModelState.AddModelError("signatureFile", "Please upload a valid image file (PNG, JPG, JPEG, max 1MB).");
                    ViewBag.SignatureLength = user.Signature != null ? user.Signature.Length : 0;
                    ViewBag.SealLength = user.Seal != null ? user.Seal.Length : 0;
                    return View("Index", user);
                }
                user.Signature = await ResizeImage(signatureFile, ImageWidth, ImageHeight);
            }

            if (sealFile != null && sealFile.Length > 0)
            {
                if (!IsImageFile(sealFile))
                {
                    ModelState.AddModelError("sealFile", "Please upload a valid image file (PNG, JPG, JPEG, max 1MB).");
                    ViewBag.SignatureLength = user.Signature != null ? user.Signature.Length : 0;
                    ViewBag.SealLength = user.Seal != null ? user.Seal.Length : 0;
                    return View("Index", user);
                }
                user.Seal = await ResizeImage(sealFile, ImageWidth, ImageHeight);
            }

            // Update password if provided
            if (!string.IsNullOrEmpty(newPassword))
            {
                if (newPassword.Length < 6)
                {
                    ModelState.AddModelError("newPassword", "Password must be at least 6 characters long.");
                    ViewBag.SignatureLength = user.Signature != null ? user.Signature.Length : 0;
                    ViewBag.SealLength = user.Seal != null ? user.Seal.Length : 0;
                    return View("Index", user);
                }
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Index");
        }

        private bool IsImageFile(IFormFile file)
        {
            var allowedTypes = new[] { "image/png", "image/jpeg", "image/jpg" };
            if (!allowedTypes.Contains(file.ContentType))
            {
                return false;
            }
            if (file.Length > MaxFileSize)
            {
                return false;
            }
            return true;
        }

        private async Task<byte[]> ResizeImage(IFormFile file, int width, int height)
        {
            using (var inputStream = file.OpenReadStream())
            using (var image = await Image.LoadAsync(inputStream))
            {
                image.Mutate(x => x.Resize(width, height));
                using (var outputStream = new MemoryStream())
                {
                    await image.SaveAsPngAsync(outputStream);
                    return outputStream.ToArray();
                }
            }
        }
    }
}