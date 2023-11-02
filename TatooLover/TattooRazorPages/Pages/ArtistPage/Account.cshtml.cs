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
    public class AccountModel : PageModel
    {
        private readonly IArtistRepository _context;

        public AccountModel(IArtistRepository context)
        {
            _context = context;
        }

      public Artist Artist { get; set; } = default!; 

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int? artistId = HttpContext.Session.GetInt32("art_email").Value;
            if (artistId == null || _context.GetArtists() == null)
            {
                return NotFound();
            }

            var artist = _context.GetArtistById(artistId);
            if (artist == null)
            {
                return NotFound();
            }
            else 
            {
                Artist = artist;
            }
            return Page();
        }
    }
}
