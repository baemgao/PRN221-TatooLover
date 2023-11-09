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
        public Schedule s { get; set; } = default!;

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
            Schedule = new ScheduleModel
            {
                Date = s.Date,
                TimeFrom = s.TimeFrom,
                TimeTo = s.TimeTo
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            
            var validationResults = Schedule.Validate(new ValidationContext(Schedule));
            foreach (var validationResult in validationResults)
            {
                ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Schedule schedule = new Schedule
            {
                Date = Schedule.Date,
                TimeFrom = Schedule.TimeFrom,
                TimeTo = Schedule.TimeTo,
            };
            _sch.UpdateSchedule(s);
            TempData["SuccessMessage"] = "Change schedule successfully.";
            return RedirectToPage("Schedule");
        }

        private bool ScheduleExists(int? id)
        {
          return (_sch.GetSchedules()?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }

        public class ScheduleModel : IValidatableObject
        {
            [Required(ErrorMessage = "Date is required")]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "TimeFrom is required")]
            [DataType(DataType.Time)]
            public TimeSpan TimeFrom { get; set; }

            [Required(ErrorMessage = "TimeTo is required")]
            [DataType(DataType.Time)]
            public TimeSpan TimeTo { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Date < DateTime.Now.Date)
                {
                    yield return new ValidationResult("Do not import past!", new[] { nameof(Date) });
                }

                if (TimeTo < TimeFrom)
                {
                    yield return new ValidationResult("TimeTo must not be earlier than TimeFrom.", new[] { nameof(TimeTo) });
                }

                TimeSpan minTime = new TimeSpan(8, 0, 0);
                TimeSpan maxTime = new TimeSpan(17, 0, 0);
                if (TimeFrom < minTime || TimeTo > maxTime)
                {
                    yield return new ValidationResult("Hours must be from 8:00 AM to 5:00 PM.", new[] { nameof(TimeFrom), nameof(TimeTo) });
                }
            }
        }


    }
}
