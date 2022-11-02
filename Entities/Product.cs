using System.Data.Entity;
using VegApp.Areas.Identity.Data;

namespace VegApp.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public decimal ProteinsIn100g { get; set; }
        public decimal CarbsIn100g { get; set; }
        public decimal FatsIn100g { get; set; }

        public decimal CaloriesIn100g { get; set; }

        public VegAppUser VegAppUser { get; set; }

        public List<EatenProduct> EatenProducts { get; set; }




    }
}
