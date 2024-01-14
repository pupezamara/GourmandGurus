using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmandGurus.Data;
using GourmandGurus.Models;

namespace GourmandGurus.Pages.Cuisines
{
    public class DeleteModel : PageModel
    {
        private readonly GourmandGurus.Data.GourmandGurusContext _context;

        public DeleteModel(GourmandGurus.Data.GourmandGurusContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cuisine Cuisine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cuisine == null)
            {
                return NotFound();
            }

            var cuisine = await _context.Cuisine.FirstOrDefaultAsync(m => m.ID == id);

            if (cuisine == null)
            {
                return NotFound();
            }
            else 
            {
                Cuisine = cuisine;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cuisine == null)
            {
                return NotFound();
            }
            var cuisine = await _context.Cuisine.FindAsync(id);

            if (cuisine != null)
            {
                Cuisine = cuisine;
                _context.Cuisine.Remove(Cuisine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
