using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class ServiceModel : PageModel
    {
        private readonly IStudioRepository _context;
        private readonly IArtistRepository _art;


        public ServiceModel(IStudioRepository context, IArtistRepository art)
        {
            _context = context;
            _art = art;
        }

        public IList<Service> Service { get;set; } = default!;
        public string ArtistName { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            var artist = _art.GetArtistById(artistId);
            if (_context.GetServices() != null)
            {
                Service = _art.GetServiceByArtistId(artistId);
            }
            ArtistName = artist.Name;
            return Page();
        }
    }
}
