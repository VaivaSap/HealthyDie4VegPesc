using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VegApp.Areas.Identity.Data;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp.Pages
{
    public class CompareEatenRecommendedModel : PageModel
    {

        private readonly VegAppContext _vegAppContext;

        private readonly PersonalizedRecommendation _personalizedRecommendation;

        [BindProperty]
        public decimal DailyProteins { get; set; }
        [BindProperty]
        public decimal DailyCarbs { get; set; }
        [BindProperty]
        public decimal DailyFats { get; set; }
        [BindProperty]
        public decimal DailyCalories { get; set; }
        [BindProperty]
        public Recommendation Recommendation { get; set; }
     
        [BindProperty]
        public VegAppUser VegAppUser { get; set; }

        public CompareEatenRecommendedModel(VegAppContext vegAppContext, PersonalizedRecommendation personalizedRecommendation)
        {

            _vegAppContext = vegAppContext;
            _personalizedRecommendation = personalizedRecommendation;

        }

        public void OnGet()
        {

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid id);


            DailyProteins = _vegAppContext.EatenProducts.Where(u => u.VegAppUserId == id).Sum(e => e.Product.ProteinsIn100g * e.Amount / 100);
            DailyCarbs = _vegAppContext.EatenProducts.Where(u => u.VegAppUserId == id).Sum(e => e.Product.CarbsIn100g * e.Amount / 100);
            DailyFats = _vegAppContext.EatenProducts.Where(u => u.VegAppUserId == id).Sum(e => e.Product.FatsIn100g * e.Amount / 100);
            DailyCalories = _vegAppContext.EatenProducts.Where(u => u.VegAppUserId == id).Sum(e => e.Product.CaloriesIn100g * e.Amount / 100);


            Recommendation = _personalizedRecommendation.CategorizePerson();


        }

    }


}
