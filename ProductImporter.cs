using System.Globalization;
using System;
using VegApp.Entities;
using CsvHelper;

namespace VegApp
{
    public static class ProductImporter
    {
        public static void ImportProduct()
        {

            using (var reader = new StreamReader("Data/ProductsToImport.csv"))
            {

                var r = reader.ReadLine();
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ProductMap>();

                    var records = csv.GetRecords<Product>().ToList();
                }
            }
        }

    }
}

