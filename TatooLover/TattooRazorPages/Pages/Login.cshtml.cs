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

        private readonly IConfiguration _config;

        public LoginModel(ICustomerRepository cus, IArtistRepository art, IStudioRepository stu, IConfiguration config)
        {
            _cus = cus;
            _stu = stu;
            _art = art;
            _config = config;
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

            var cus = _cus.GetCustomers().FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            var art = _art.GetArtists().FirstOrDefault(a => a.Email.Equals(Email) && a.Password.Equals(Password));
            var stu = _stu.GetStudios().FirstOrDefault(a => a.Code.Equals(Email) && a.Password.Equals(Password));


            var adminEmail = _config["AdminAccount:Email"];
            var adminPass = _config["AdminAccount:Password"];

            if (adminEmail == Email && adminPass == Password)
            {
                return RedirectToPage("./Admin/AdminHome");
            } else
            {
                if (cus != null)
                {
                    HttpContext.Session.SetInt32("customerId", cus.CustomerId);
                    return RedirectToPage("./CustomerPage/CustomerDetail");
                }
                if (art != null)
                {
                    HttpContext.Session.SetInt32("art_email", art.ArtistId);
                    return RedirectToPage("./ArtistPage/Index");
                }
                if (stu != null)
                {
                    HttpContext.Session.SetInt32("id", stu.StudioId);
                    return RedirectToPage("./StudioPage/Index");
                }
                ViewData["Message"] = "Your email or password is wrong!";
                return Page();
            }
        }
    }
}

