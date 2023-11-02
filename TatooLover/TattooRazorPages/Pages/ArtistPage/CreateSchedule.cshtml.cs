using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class CreateScheduleModel : PageModel
    {
        private readonly IScheduleRepository _sch;
        private readonly IArtistRepository _art;

        public CreateScheduleModel(IScheduleRepository sch, IArtistRepository art)
        {
            _art = art;
            _sch = sch;
        }

        public IActionResult OnGet()
        {
        ViewData["ArtistId"] = new SelectList(_art.GetArtists(), "ArtistId", "Code");
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _sch.GetSchedules() == null || Schedule == null)
            {
                return Page();
            }

            _sch.CreateSchedule(Schedule);

            return RedirectToPage("./Schedule");
        }
    }
}
