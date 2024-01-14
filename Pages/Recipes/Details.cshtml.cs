using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmandGurus.Data;
using GourmandGurus.Models;

namespace GourmandGurus.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly GourmandGurus.Data.GourmandGurusContext _context;

        public DetailsModel(GourmandGurus.Data.GourmandGurusContext context)
        {
            _context = context;
        }

      public Recipe Recipe { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FirstOrDefaultAsync(m => m.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }
            else 
            {
                Recipe = recipe;
            }
            return Page();
        }
    }
}
