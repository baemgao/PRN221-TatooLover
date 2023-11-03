using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class ServiceModel : PageModel
    {
        private readonly IStudioRepository _context;

        public ServiceModel(IStudioRepository context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            if (_context.GetServices() != null)
            {
                Service = _context.GetServices();
            }
            return Page();
        }
    }
}
