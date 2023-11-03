using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class EditScheduleModel : PageModel
    {
        private readonly IScheduleRepository _sch;
        private readonly IArtistRepository _art;

        public EditScheduleModel(IScheduleRepository sch, IArtistRepository art)
        {
            _art = art;
            _sch = sch;
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null || _sch.GetSchedules == null)
            {
                return NotFound();
            }

            var schedule =  _sch.GetSchedulesById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            Schedule = schedule;
           ViewData["ArtistId"] = new SelectList(_art.GetArtists(), "ArtistId", "Code");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _sch.UpdateSchedule(Schedule);


            return RedirectToPage("/Schedule");
        }

        private bool ScheduleExists(int? id)
        {
          return (_sch.GetSchedules()?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
