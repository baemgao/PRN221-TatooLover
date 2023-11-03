using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class ArtistModel : PageModel
    {
        ArtistRepository artistRepository = new ArtistRepository();
        public List<Artist> artists;
        //public IActionResult OnGet()
        //{
        //    if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
        //    {
        //        return RedirectToPage("/Login");
        //    }
        //    int studioId = HttpContext.Session.GetInt32("id").Value;
        //    artists = artistRepository.GetArtistsByStudioId(studioId);
        //    return Page();
        //}
    }
}
