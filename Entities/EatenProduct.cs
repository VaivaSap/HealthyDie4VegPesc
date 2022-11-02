using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


