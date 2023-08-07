using CsvHelper.Configuration;
using System;
using VegApp.Areas.Identity.Data;
using VegApp;
using VegApp.Entities;

namespace VegApp
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap() 
        {
            Map(p => p.Id).Convert(o => Guid.NewGuid());
            Map(p => p.ProductName).Index(0);
            Map(p => p.ProteinsIn100g).Index(1);
            Map(p => p.FatsIn100g).Index(2);
            Map(p => p.CarbsIn100g).Index(3);
            Map(p => p.CaloriesIn100g).Index(4);
            Map(p => p.VegAppUser).Convert(o => new VegAppUser());
            Map(p => p.EatenProducts).Convert(o => new List<EatenProduct>());
        }
    }
}
