using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp.Pages.products
{
    public class IndexModel : PageModel
    {
        private readonly VegApp.Data.VegAppContext _context;

        public IndexModel(VegApp.Data.VegAppContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
