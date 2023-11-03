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
                    // G?i hàm CreateStudio ?? thêm Studio vào c? s? d? li?u
                    await studioRepository.CreateStudio(studio);

                    // Redirect ??n trang danh sách Studio sau khi thêm thành công
                    return RedirectToPage("AdminStudio");
                }
                catch (Exception ex)
                {
                    // X? lý l?i (ví d?: hi?n th? thông báo l?i cho ng??i dùng)
                    ModelState.AddModelError(string.Empty, "L?i khi thêm Studio: " + ex.Message);
                    return Page();
                }
            }

            // N?u ModelState không h?p l?, hi?n th? l?i trang v?i thông báo l?i
            return Page();
        }
    }
}
