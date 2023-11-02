using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminStudioModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchText { get; set; }

        public IStudioRepository studioRepository = new StudioRepository();
        public List<Studio> studioList = new List<Studio>();
        public void OnGet()
        {
            studioList = studioRepository.GetStudios();
            studioList = studioRepository.GetStudioByName(SearchText);
        }
    }
}
