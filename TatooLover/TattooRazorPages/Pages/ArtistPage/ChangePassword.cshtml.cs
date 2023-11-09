using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IArtistRepository _art;
        public ChangePasswordModel(IArtistRepository art)
        {
            _art = art;
        }
        public Artist a { get; set; } = default!;
        [BindProperty]
        [Required(ErrorMessage = "The old password is a required field.")]
        public string OldPassword { get; set; } = default!;
        [BindProperty]
        [Required(ErrorMessage = "The new password is a required field.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "The new password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$", ErrorMessage = "The new password must include at least one uppercase letter, one number, and one special character.")]
        public string NewPassword { get; set; } = default!;
        [BindProperty]
        [Required(ErrorMessage = "The confirm password is a required field.")]
        public string ConfirmPassword { get; set; } = default!;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            string? newPassword = NewPassword;
            string confirmPassword = ConfirmPassword;
            if (ModelState.IsValid)
            {                
                var old = _art.GetArtists().FirstOrDefault(a => a.Password.Equals(OldPassword));
                if (old == null)
                {
                    TempData["Message"] = "The old password is incorrect, please re-enter it";
                } else if (newPassword != null && confirmPassword != null && !newPassword.Equals(ConfirmPassword))
                {
                    TempData["ErrorMessage"] = "New password and password confirmation mismatch."; ;
                }
                else
                {
                    _art.ChangePassword(artistId, newPassword);
                    TempData["SuccessMessage"] = "Change password successfully.";
                    return RedirectToPage("EditAccount");
                }
            }
            return Page();
        }
    }
}
