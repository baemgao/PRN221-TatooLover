using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class CreateNewStudioModel : PageModel
    {
        [BindProperty]
        public Studio studio { get; set; } = new Studio();

        public IStudioRepository studioRepository = new StudioRepository();
        public List<Studio> studioList = new List<Studio>();
        public void OnGet() {}
        public IActionResult OnPost(String code, String name, String address, String phone, TimeSpan openHour, TimeSpan closeHour) {
            if(HttpContext.Session.GetString("Email") == null || HttpContext.Session.GetString("Email").IsNullOrEmpty()) {
                RedirectToPage("Login");
            }
            Studio studio = new Studio()
            {
                Code = code,
                Name = name,
                Address = address,
                Phone = phone,
                OpenHour = openHour,
                CloseHour = closeHour,
                Status = 1,
                Password = "Password@1",
            };
            studioRepository.CreateStudio(studio);
            return RedirectToPage("AdminStudio");
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
