using System.Globalization;
using System;
using VegApp.Entities;
using CsvHelper;
using System.Data.Entity;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;
using VegApp.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VegApp
{
    public class ProductImporter
    {
        private readonly VegAppContext _vegAppContext;

        public List<Product> ImportedProduct { get; set; }

        public ProductImporter(VegAppContext vegAppContext)
        {
            _vegAppContext = vegAppContext;
        }
        public void ImportProduct()
        {

            using (var reader = new StreamReader("Data/ProductsToImport.csv"))
            {

                var r = reader.ReadLine();
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ProductMap>();

                    var records = csv.GetRecords<Product>().ToList();

                    foreach (var record in records)
                    {
                        if(!_vegAppContext.Products.Any(o => o.ProductName == record.ProductName))
                        {
                            record.VegAppUser = null;
                            _vegAppContext.Products.Add(record);
                        }
                    }

                    _vegAppContext.SaveChanges();

                }
            }
        }
    }
}


