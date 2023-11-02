using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;

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
        public Artist Artist { get; set; } = default!;

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
            Artist = artist;
           ViewData["StudioId"] = new SelectList(_stu.GetStudios(), "StudioId", "Address");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _art.UpdateArtist(Artist);

            return RedirectToPage("./Index");
        }

        private bool ArtistExists(int id)
        {
          return (_art.GetArtists()?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
