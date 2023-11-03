using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class ServiceModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchText { get; set; }

        StudioRepository studioRepository = new StudioRepository();
        public List<Service> services = new List<Service>();
        public void OnGet()
        {
            var id = HttpContext.Session.GetInt32("id") != null ?
                    (int)HttpContext.Session.GetInt32("id")! : -1;

            if (id < 0)
            {
                NotFound(); return;
            }
            else
            {
                try
                {
                    services = studioRepository.GetServiceByStudioId(id);
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "Error getting data";
                }
            }
        }

        public IActionResult OnPost(int serviceId)
        {
            var id = HttpContext.Session.GetInt32("id") != null ?
                    (int)HttpContext.Session.GetInt32("id")! : -1;

            if (id < 0)
            {
                NotFound(); 
                return Page();
            }
            else
            {
                try
                {
                    studioRepository.UpdateServiceStatus(serviceId);
                    services = studioRepository.GetServiceByStudioId(id);
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "Error getting data";
                }
            }
            return Page();
        }
    }
}
