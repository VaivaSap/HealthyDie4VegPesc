using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VegApp.Pages
{
    [Authorize]
    public class AddNewProductModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
