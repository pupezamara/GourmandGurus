using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GourmandGurus.Data;
using GourmandGurus.Models;
using System.Security.Policy;

namespace GourmandGurus.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly GourmandGurus.Data.GourmandGurusContext _context;

        public CreateModel(GourmandGurus.Data.GourmandGurusContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CuisineID"] = new SelectList(_context.Set<Cuisine>(), "ID",
"CuisineName");

            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID",
"CategoryName");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Recipe == null || Recipe == null)
            {
                return Page();
            }

            _context.Recipe.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
