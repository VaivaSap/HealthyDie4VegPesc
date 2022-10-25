using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp.Pages
{
    [Authorize]
    public class AddNewProductModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public decimal ProteinsIn100g { get; set; }
        [BindProperty]
        public decimal FatsIn100g { get; set; }
        [BindProperty]
        public decimal CarbsIn100g { get; set; }
        [BindProperty]
        public decimal CaloriesIn100g { get; set; }

        private readonly VegAppContext _vegAppContext;

        public AddNewProductModel(VegAppContext vegAppContext)
        {

            _vegAppContext = vegAppContext;

        }

        public void OnPost()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid id);

            var user = _vegAppContext.Users.FirstOrDefault(x => x.Id == id);

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = Title,
                ProteinsIn100g = ProteinsIn100g,
                CarbsIn100g = CarbsIn100g,
                FatsIn100g = CaloriesIn100g,
                CaloriesIn100g = CaloriesIn100g,
                VegAppUser = user

        };

            _vegAppContext.Products.Add(product);
         
            _vegAppContext.SaveChanges();
        }

    }
}
