using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp
{
    public class EatenProduct

    {
    
        public Guid EatenProductId { get; set; }

       
        public Product Product { get; set; }

 
        public DateTime DateWhenEaten { get; set; } 

        public int Amount { get; set; }


    }
}


