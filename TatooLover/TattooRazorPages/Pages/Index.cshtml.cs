using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TattooRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("email") == null)
            {
                return RedirectToPage("./Login");
            }
            return Page();
        }
    }
}