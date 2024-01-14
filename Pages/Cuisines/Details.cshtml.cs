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
    public class DetailsModel : PageModel
    {
        private readonly GourmandGurus.Data.GourmandGurusContext _context;

        public DetailsModel(GourmandGurus.Data.GourmandGurusContext context)
        {
            _context = context;
        }

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
    }
}
