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
            HttpContext.Session.GetString("email");
            HttpContext.Session.GetString("password");
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Email))
            {
                ViewData["MessageEmail"] = "Please enter your email!";
            }
            if (string.IsNullOrEmpty(Password))
            {
                ViewData["MessagePassword"] = "Please enter your password!";
            }

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return Page();
            }
            HttpContext.Session.SetString("email", Email);
            HttpContext.Session.SetString("password", Password);

            var cus = _cus.GetCustomers().FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            var art = _art.GetArtists().FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            var stu = _stu.GetStudios().FirstOrDefault(a => a.Code.Equals(Email) && a.Password.Equals(Password));

            if (cus != null)
            {
                HttpContext.Session.SetString("email", cus.Email);
                return RedirectToPage("./Customer/Index");
            }
            if (art != null)
            {
                HttpContext.Session.SetString("art_email", art.Email);
                return RedirectToPage("./Artist/Index");
            }
            if (stu != null)
            {
                HttpContext.Session.SetString("code", stu.Code);
                return RedirectToPage("./Studio/Index");
            }
            ViewData["Message"] = "Your email or password is wrong!";
            return Page();
        }
    }
}
