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
        public void OnGet()
        {
            artistList = artistRepository.GetArtists();
            artistList = artistRepository.GetArtistByName(SearchText);
        }
    }
}
