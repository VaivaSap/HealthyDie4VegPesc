using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VegApp.Areas.Identity.Data;
using VegApp.Data;

namespace VegApp.Pages
{
    public class CompareEatenRecommendedModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private readonly VegAppContext _vegAppContext;

        [BindProperty]
        public decimal DailyProteins { get; set; }
        [BindProperty]
        public decimal DailyCarbs { get; set; }
        [BindProperty]
        public decimal DailyFats { get; set; }
        [BindProperty]
        public decimal DailyCalories { get; set; }
        [BindProperty]

        public decimal RecommendedDailyProteins { get; set; }
        [BindProperty]

        public decimal RecommendedDailyFats { get; set; }

        [BindProperty]
        public decimal RecommendedDailyCarbs { get; set; }
        [BindProperty]
        public decimal RecommendedDailyCalories { get; set; }
        [BindProperty]

        public VegAppUser VegAppUser { get; set; }

        public CompareEatenRecommendedModel(VegAppContext vegAppContext)
        {

            _vegAppContext = vegAppContext;

        }

        public void OnGet()
        {

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid id);


            DailyProteins = _vegAppContext.EatenProducts.Where(u => u.Product.VegAppUser.Id == id).Sum(e => e.Product.ProteinsIn100g * e.Amount / 100);
            DailyCarbs = _vegAppContext.EatenProducts.Where(u => u.Product.VegAppUser.Id == id).Sum(e => e.Product.CarbsIn100g * e.Amount / 100);
            DailyFats = _vegAppContext.EatenProducts.Where(u => u.Product.VegAppUser.Id == id).Sum(e => e.Product.FatsIn100g * e.Amount / 100);
            DailyCalories = _vegAppContext.EatenProducts.Where(u => u.Product.VegAppUser.Id == id).Sum(e => e.Product.CaloriesIn100g * e.Amount / 100);

            //Dummy data
            RecommendedDailyProteins = 10;
            RecommendedDailyFats = 15;
            RecommendedDailyCarbs = 20;
            RecommendedDailyCalories = 2200;



        }

    }


}
