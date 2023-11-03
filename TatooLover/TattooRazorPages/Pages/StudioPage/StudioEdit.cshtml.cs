using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace TattooRazorPages.Pages.StudioPage
{
    public class StudioEditModel : PageModel
    {
        StudioRepository studioRepository = new StudioRepository();
        public Studio studio;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;
            studio = studioRepository.GetStudioById(studioId);
            return Page();
        }
        public IActionResult OnPost(String name, String address, String phone, TimeSpan openHour, TimeSpan closeHour)
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;
            studio = studioRepository.GetStudioById(studioId);

            if (!Validation.isPhoneValid(phone))
            {
                ModelState.AddModelError("phone", "Invalid phone number.");
            }

            if (!Validation.isOpenHourValid(openHour))
            {
                ModelState.AddModelError("openHour", "Invalid open hour.");
            }

            if (!Validation.isCloseHourValid(closeHour))
            {
                ModelState.AddModelError("closeHour", "Invalid close hour.");
            }
            studio.Name = name;
            studio.Address = address;
            studio.Phone = phone;
            studio.OpenHour = openHour;
            studio.CloseHour = closeHour;
            studioRepository.UpdateStudio(studio);
            return Page();
        }
    }

    internal static class Validation
    {

        public static bool isPhoneValid(String phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return false;
            }

            if (phone.Length != 10 && phone.Length != 11)
            {
                return false;
            }

            if (!phone.StartsWith("0"))
            {
                return false;
            }

            if (!phone.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        public static bool isOpenHourValid(TimeSpan openHour)
        {
            if (string.IsNullOrEmpty(openHour.ToString()))
            {
                return false;
            }

            return openHour >= TimeSpan.Zero && openHour <= TimeSpan.FromHours(23).Add(TimeSpan.FromMinutes(59));
        }

        public static bool isCloseHourValid(TimeSpan closeHour)
        {
            if (string.IsNullOrEmpty(closeHour.ToString()))
            {
                return false;
            }
            return closeHour >= TimeSpan.Zero && closeHour <= TimeSpan.FromHours(23).Add(TimeSpan.FromMinutes(59));
        }
    }
}
