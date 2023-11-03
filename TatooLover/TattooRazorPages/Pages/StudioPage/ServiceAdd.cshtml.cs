using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class ServiceAddModel : PageModel
    {
        StudioRepository studioRepository = new StudioRepository();
        ArtistRepository artistRepository = new ArtistRepository();
        public List<Artist> artists;
        public Service service;
        public int studioId;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;
            artists = artistRepository.GetArtistByStudioId(studioId);
            return Page();
        }
        public IActionResult OnPost(String code, String name, String description, int time, String price, int staffId)
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }

            int studioId = HttpContext.Session.GetInt32("id").Value;

            Service service = new Service(); // Initialize the service object

            service.StudioId = studioId;
            service.Code = code;
            service.Name = name;
            service.Description = description;
            service.Time = time;
            service.Price = float.Parse(price.Trim());
            service.Status = 1;

            studioRepository.AddService(service, staffId);
            return RedirectToPage("Service");
        }
    }
}
