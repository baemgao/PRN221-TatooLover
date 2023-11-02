using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace TattooRazorPages.Pages.Artist
{
    public class ScheduleModel : PageModel
    {
        private readonly BusinessObjects.Models.Prn221TatooLoverContext _context;

        public ScheduleModel(BusinessObjects.Models.Prn221TatooLoverContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Schedules != null)
            {
                Schedule = await _context.Schedules
                .Include(s => s.Artist).ToListAsync();
            }
        }
    }
}
