using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // G?i h�m CreateStudio ?? th�m Studio v�o c? s? d? li?u
                    await studioRepository.CreateStudio(studio);

                    // Redirect ??n trang danh s�ch Studio sau khi th�m th�nh c�ng
                    return RedirectToPage("AdminStudio");
                }
                catch (Exception ex)
                {
                    // X? l� l?i (v� d?: hi?n th? th�ng b�o l?i cho ng??i d�ng)
                    ModelState.AddModelError(string.Empty, "L?i khi th�m Studio: " + ex.Message);
                    return Page();
                }
            }

            // N?u ModelState kh�ng h?p l?, hi?n th? l?i trang v?i th�ng b�o l?i
            return Page();
        }
    }
}
