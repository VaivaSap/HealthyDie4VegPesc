using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VegApp;
using VegApp.Data;

namespace VegApp.Pages
{
    public class DeleteProductsModel : PageModel
    {
        private readonly VegApp.Data.VegAppContext _context;

        public DeleteProductsModel(VegApp.Data.VegAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EatenProduct EatenProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.EatenProducts == null)
            {
                return NotFound();
            }

            var eatenproduct = await _context.EatenProducts.FirstOrDefaultAsync(m => m.EatenProductId == id);

            if (eatenproduct == null)
            {
                return NotFound();
            }
            else 
            {
                EatenProduct = eatenproduct;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.EatenProducts == null)
            {
                return NotFound();
            }
            var eatenproduct = await _context.EatenProducts.FindAsync(id);

            if (eatenproduct != null)
            {
                EatenProduct = eatenproduct;
                _context.EatenProducts.Remove(EatenProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
