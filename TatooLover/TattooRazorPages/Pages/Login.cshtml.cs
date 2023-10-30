using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomerRepository _cus;
        private readonly IStudioRepository _stu;
        private readonly IArtistRepository _art;

        public LoginModel(ICustomerRepository cus, IArtistRepository art, IStudioRepository stu)
        {
            _cus = cus;
            _stu = stu;
            _art = art;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public IActionResult OnPost()
        {
            var cus = _cus.GetCustomers().FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            var art = _art.GetArtists().FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            var stu = _stu.GetStudios().FirstOrDefault(a => a.Code.Equals(Email) && a.Password.Equals(Password));

            if (cus != null)
            {
                HttpContext.Session.SetString("email", cus.Email);
                return RedirectToPage("./Index");
            }
            if (art != null)
            {
                HttpContext.Session.SetString("email", art.Email);
                return RedirectToPage("./Artist/Index");
            }
            if (stu != null)
            {
                HttpContext.Session.SetString("email", stu.Code);
                return RedirectToPage("./Studio/Index");
            }
            ViewData["Message"] = "You do not have permission to do this function!";
            return Page();
        }
    }
}
