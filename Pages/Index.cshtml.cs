using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly VegAppContext _vegAppContext;

        public Product SelectedProduct { get; set; }



        public List<Product> Products { get; set; } = new List<Product>();


        public IndexModel(ILogger<IndexModel> logger, VegAppContext vegAppContext)
        {
            _logger = logger;
            _vegAppContext = vegAppContext;
        }





        public void OnGet()
        {

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid id);
            Products = _vegAppContext.Products.Where(u => u.VegAppUser.Id == id).ToList();

        }


    }
}

