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
    public class ScheduleModel : PageModel
    {
        private readonly IScheduleRepository _context;

        public ScheduleModel(IScheduleRepository context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; } = default!;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            if (_context.GetSchedules() != null)
            {
                Schedule = _context.GetSchedulesByArtistId(artistId);
            }
            return Page();
        }
    }
}
