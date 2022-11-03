using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VegApp;
using VegApp.Data;

namespace VegApp.Pages
{
    public class EditProductsModel : PageModel
    {
        private readonly VegApp.Data.VegAppContext _context;

        
        public EditProductsModel(VegApp.Data.VegAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EatenProduct EatenProduct { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.EatenProducts == null)
            {
                return NotFound();
            }

            var eatenproduct =  await _context.EatenProducts.FirstOrDefaultAsync(m => m.EatenProductId == id);
            if (eatenproduct == null)
            {
                return NotFound();
            }
            EatenProduct = eatenproduct;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EatenProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EatenProductExists(EatenProduct.EatenProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EatenProductExists(Guid id)
        {
          return _context.EatenProducts.Any(e => e.EatenProductId == id);
        }
    }
}
