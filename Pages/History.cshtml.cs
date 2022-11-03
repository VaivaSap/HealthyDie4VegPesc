using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VegApp;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly VegApp.Data.VegAppContext _context;

        public HistoryModel(VegApp.Data.VegAppContext context)
        {
            _context = context;
        }

        public IList<EatenProduct> EatenProduct { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EatenProducts != null)
            {
                EatenProduct = await _context.EatenProducts.Include(j => j.Product).ToListAsync();
            }
        }
    }
}
