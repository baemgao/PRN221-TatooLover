using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class ArtistAddModel : PageModel
    {
        ArtistRepository artistRepository = new ArtistRepository();
        public Artist artist;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;
            return Page();
        }

        public IActionResult OnPost(String code, String name, String phone, String address, String certLink, String email)
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            artist = new Artist();
            int studioId = HttpContext.Session.GetInt32("id").Value;
            artist.Code = code.Trim();
            artist.Name = name.Trim();
            artist.Phone = phone.Trim();
            artist.Address = address.Trim();
            artist.Email = email.Trim();
            artist.Certificate = certLink.Trim();
            artist.StudioId = studioId;
            artistRepository.AddArtist(artist);

            return RedirectToPage("Artist");
        }
    }
}
