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
using System.ComponentModel.DataAnnotations;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class EditScheduleModel : PageModel
    {
        private readonly IScheduleRepository _sch;

        public EditScheduleModel(IScheduleRepository sch)
        {
            _sch = sch;
        }

        [BindProperty]
        public ScheduleModel Schedule { get; set; } = default!;
        public Schedule s { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            if (id == null || _sch.GetSchedules == null)
            {
                return NotFound();
            }

            var schedule =  _sch.GetSchedulesById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            s = schedule;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DateTime today = DateTime.Now;
            if (Schedule.Date < today.Date)
            {
                ModelState.AddModelError("ScheduleModel.Date", "Do not import past!");
                return Page();
            }
            TimeSpan minTime = new TimeSpan(8, 0, 0);
            TimeSpan maxTime = new TimeSpan(17, 0, 0);
            if (Schedule.TimeFrom < minTime | Schedule.TimeTo > maxTime)
            {
                ModelState.AddModelError("ScheduleModel.TimeFrom", "Hours must be from 8:00 AM to 5:00 PM.");
                ModelState.AddModelError("ScheduleModel.TimeTo", "Hours must be from 8:00 AM to 5:00 PM.");
                return Page();
            }
            Schedule schedule = new Schedule
            {
                Date = Schedule.Date,
                TimeFrom = Schedule.TimeFrom,
                TimeTo = Schedule.TimeTo,
                Status = Schedule.Status
            };
            _sch.UpdateSchedule(s);


            return RedirectToPage("/Schedule");
        }

        private bool ScheduleExists(int? id)
        {
          return (_sch.GetSchedules()?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }

        public class ScheduleModel
        {   
            public int ScheduleId { get; set; }
            [Required(ErrorMessage = "Date is required")]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "TimeFrom is required")]
            [DataType(DataType.Time)]
            public TimeSpan TimeFrom { get; set; }

            [Required(ErrorMessage = "TimeTo is required")]
            [DataType(DataType.Time)]
            public TimeSpan TimeTo { get; set; }

            [Required(ErrorMessage = "Status is required")]
            public int Status { get; set; }
        }
    }
}
