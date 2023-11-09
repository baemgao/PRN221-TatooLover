using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class CreateScheduleModel : PageModel
    {
        private readonly IScheduleRepository _sch;

        public CreateScheduleModel(IScheduleRepository sch)
        {
            _sch = sch;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }
        [BindProperty]
        public ScheduleModel scheduleModel { get; set; }

        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _sch.GetSchedules() == null)
            {
                return Page();
            }
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            DateTime today = DateTime.Now;

            if (scheduleModel.Date < today.Date)
            {
                ModelState.AddModelError("ScheduleModel.Date", "Do not import past!");
                return Page();
            }
            TimeSpan minTime = new TimeSpan(8, 0, 0);
            TimeSpan maxTime = new TimeSpan(17, 0, 0);
            if (scheduleModel.TimeFrom < minTime | scheduleModel.TimeTo > maxTime)
            {
                ModelState.AddModelError("ScheduleModel.TimeFrom", "Hours must be from 8:00 AM to 5:00 PM.");
                ModelState.AddModelError("ScheduleModel.TimeTo", "Hours must be from 8:00 AM to 5:00 PM.");
                return Page();
            }
            Schedule schedule = new Schedule
            {
                Date = scheduleModel.Date,
                TimeFrom = scheduleModel.TimeFrom,
                TimeTo = scheduleModel.TimeTo,
                Status = scheduleModel.Status
            };
            _sch.CreateSchedule(schedule, artistId);
            TempData["SuccessMessage"] = "Register schedule successfully.";
            return RedirectToPage("./Schedule");
        }
        public class ScheduleModel
        {
            [Required(ErrorMessage = "Date is required")]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "TimeFrom is required")]
            [DataType(DataType.Time)]
            public TimeSpan TimeFrom { get; set; }

            [Required(ErrorMessage = "TimeTo is required")]
            [DataType(DataType.Time)]
            [TimeToGreaterThanTimeFrom]
            public TimeSpan TimeTo { get; set; }
            public int Status { get; set; }
        }
        public class TimeToGreaterThanTimeFromAttribute : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                var scheduleModel = (CreateScheduleModel.ScheduleModel)validationContext.ObjectInstance;

                if (scheduleModel.TimeTo <= scheduleModel.TimeFrom)
                {
                    return new ValidationResult("TimeTo must be greater than TimeFrom.");
                }

                return ValidationResult.Success;
            }
        }
    }
}
