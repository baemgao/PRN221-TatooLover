using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class EditAccountModel : PageModel
    {
        private readonly IArtistRepository _art;

        public EditAccountModel(IArtistRepository art)
        {
            _art = art;
        }

        [BindProperty]
        public ArtistModel Art { get; set; } = default!;
        public Artist a { get; set; } = default!;
        public string Password { get; set; } = default!;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int? artistId = HttpContext.Session.GetInt32("art_email").Value;
            if (artistId == null || _art.GetArtists() == null)
            {
                return NotFound();
            }
            
            var artist = _art.GetArtistById(artistId);
            if (artist == null)
            {
                return NotFound();
            }           
            a = artist;
            Art = new ArtistModel
            {
                Name = a.Name,
                Email = a.Email,
                Phone = a.Phone,
                Address = a.Address,
                Avatar = a.Avatar,
                Certificate = a.Certificate
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please fix the errors and try again.");
                return Page();
            }
            var existingArtist = _art.GetArtistById(artistId);
            if (existingArtist == null)
            {
                return NotFound();
            }

            existingArtist.Name = Art.Name;
            existingArtist.Email = Art.Email;
            existingArtist.Phone = Art.Phone;
            existingArtist.Address = Art.Address;
            existingArtist.Avatar = Art.Avatar;
            existingArtist.Certificate = Art.Certificate;
            bool updateSuccess = _art.UpdateArtist(existingArtist);
            if (!updateSuccess)
            {
                TempData["ErrorMessage"] = "Failed to update profile. Please try again.";
                return Page();
            }
            a = existingArtist;
            TempData["SuccessMessage"] = "Change profile successfully.";

            return RedirectToPage("Account");
        }

        private bool ArtistExists(int id)
        {
          return (_art.GetArtists()?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
    public class ArtistModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [RegularExpression(@"^[^\d]{6,30}$", ErrorMessage = "The name must be between 6 and 30 characters and should not contain numbers.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^[0-9]{8,15}$", ErrorMessage = "Phone must be between 8 and 15 numbers, no letters must be entered.")]
        public string? Phone { get; set; }


        [Required(ErrorMessage = "The Address field is required.")]
        [MinLength(10, ErrorMessage = "Address must be at least 10 characters")]
        public string? Address { get; set; }
        [RegularExpression(@"^(|http(s)?://[\w./?=#-]*)$", ErrorMessage = "Avatar must be in link format.")]
        public string? Avatar { get; set; }
        [RegularExpression(@"^(|http(s)?://[\w./?=#-]*)$", ErrorMessage = "The certificate must be in the format of a link.")]
        public string? Certificate { get; set; }
    }

}
