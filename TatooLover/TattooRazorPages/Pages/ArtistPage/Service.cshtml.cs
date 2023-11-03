using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class ServiceModel : PageModel
    {
        private readonly BusinessObjects.Models.Prn221TatooLoverContext _context;

        public ServiceModel(BusinessObjects.Models.Prn221TatooLoverContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Services != null)
            {
                Service = await _context.Services
                .Include(s => s.Studio).ToListAsync();
            }
        }
    }
}
