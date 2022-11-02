using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VegApp.Areas.Identity.Data;
using VegApp.Data;

namespace VegApp.Pages
{
    public class CompareEatenRecommendedModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private readonly VegAppContext _vegAppContext;


        public decimal DailyProteins { get; set; }
        public decimal DailyCarbs { get; set; }  
        public decimal DailyFats { get; set; }
        public decimal DailyCalories { get; set; }

        public VegAppUser VegAppUser { get; set; }

        public CompareEatenRecommendedModel(VegAppContext vegAppContext)
        {

            _vegAppContext = vegAppContext;

        }

        public void OnGet()
        {

            //Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid id);
            //Products = _vegAppContext.Products.Where(u => u.VegAppUser.Id == id).ToList();

        }

    }


}
