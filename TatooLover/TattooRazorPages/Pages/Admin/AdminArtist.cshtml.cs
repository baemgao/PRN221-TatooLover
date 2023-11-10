using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminArtistModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchText { get; set; }

        public IArtistRepository artistRepository = new ArtistRepository();
        public List<Artist> artistList = new List<Artist>();
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToPage("/Login");
            }
            artistList = artistRepository.GetArtists();
            artistList = artistRepository.GetArtistByName(SearchText);
            return Page();
        }
    }
}
