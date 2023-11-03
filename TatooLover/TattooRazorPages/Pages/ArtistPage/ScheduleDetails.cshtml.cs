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
    public class ScheduleDetailsModel : PageModel
    {
        private readonly IScheduleRepository _context;

        public ScheduleDetailsModel(IScheduleRepository context)
        {
            _context = context;
        }

      public Schedule Schedule { get; set; } = default!; 

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int? id = HttpContext.Session.GetInt32("art_email").Value;
            if (id == null || _context.GetSchedules() == null)
            {
                return NotFound();
            }

            var schedule = _context.GetSchedulesById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            else 
            {
                Schedule = schedule;
            }
            return Page();
        }
    }
}
