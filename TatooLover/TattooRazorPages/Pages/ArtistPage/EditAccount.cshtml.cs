using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class EditAccountModel : PageModel
    {
        private readonly IArtistRepository _art;
        private readonly IStudioRepository _stu;

        public EditAccountModel(IArtistRepository art, IStudioRepository stu)
        {
            _art = art;
            _stu = stu;
        }

        [BindProperty]
        public ArtistModel artist { get; set; } = default!;
        public Artist a { get; set; } = default!;
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
           ViewData["StudioId"] = new SelectList(_stu.GetStudios(), "StudioId", "Address");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _art.UpdateArtist(a);

            return RedirectToPage("/Schedule");
        }

        private bool ArtistExists(int id)
        {
          return (_art.GetArtists()?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
    public class ArtistModel
    {
        public string? ArtistId { get; set; }
        public string? StudioId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [RegularExpression(@"^[^\d]{6,30}$", ErrorMessage = "The name must be between 6 and 30 characters and should not contain numbers.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        public string? Password { get; set; }

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
        public string? Status { get; set; }
    }
}
