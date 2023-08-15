using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VegApp.Areas.Identity.Data;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly VegAppContext _vegAppContext;
        private readonly UserProvider _userProvider;

        [BindProperty]
        public Guid SelectedProductId { get; set; }
        [BindProperty]
        public DateTime DateWhenEaten { get; set; }
        [BindProperty]
        public int Amount { get; set; }


        public List<Product> Products { get; set; } = new List<Product>();



        //Dependency injection (constructor with parameters)
        public IndexModel(ILogger<IndexModel> logger, VegAppContext vegAppContext, UserProvider userProvider)
        {
            _logger = logger;
            _vegAppContext = vegAppContext;
            _userProvider = userProvider;
        }


        public void OnGet()
        {

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid id);
            Products = _vegAppContext.Products.Where(u => u.VegAppUser.Id == id || u.VegAppUser == null).ToList();
            DateWhenEaten = DateTime.Today;

        }




        public RedirectToPageResult OnPost()
        {
            var eatenProduct = new EatenProduct()
            {
                EatenProductId = Guid.NewGuid(),
                Product = _vegAppContext.Products.FirstOrDefault(s => s.Id == SelectedProductId),
                DateWhenEaten = DateWhenEaten,
                Amount = Amount,
                VegAppUserId = _userProvider.GetCurrentUserId(),


            };


            _vegAppContext.EatenProducts.Add(eatenProduct);

            _vegAppContext.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}


