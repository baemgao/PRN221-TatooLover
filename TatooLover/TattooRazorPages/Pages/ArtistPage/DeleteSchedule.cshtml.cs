using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class DeleteScheduleModel : PageModel
    {
        private readonly IScheduleRepository _context;

        public DeleteScheduleModel(IScheduleRepository context)
        {
            _context = context;
        }

        [BindProperty]
      public Schedule Schedule { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
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

        public IActionResult OnPost(int? id)
        {
            if (id == null || _context.GetSchedules() == null)
            {
                return NotFound();
            }
            var schedule = _context.GetSchedulesById(id);

            if (schedule != null)
            {
                Schedule = schedule;
                _context.DeleteSchedule(Schedule);              
            }
            return RedirectToPage("./Index");
        }
    }
}
