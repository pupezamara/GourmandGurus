using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GourmandGurus.Data; // Adjust the namespace as per your project structure
using GourmandGurus.Models;
using Microsoft.AspNetCore.Mvc;

namespace GourmandGurus.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly GourmandGurusContext _context; // Replace GourmandGurusContext with your actual DbContext

        public IndexModel(GourmandGurusContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get; set; }
        public IList<Category> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCategory { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Recipe> query = _context.Recipe
                .Include(r => r.Category)
                .Include(r => r.Cuisine);

            // Fetch available categories for the dropdown list
            Categories = await _context.Category.ToListAsync();

            // Apply search filters
            if (!string.IsNullOrEmpty(SearchTitle))
            {
                query = query.Where(r => r.RecipeName.Contains(SearchTitle));
            }

            if (!string.IsNullOrEmpty(SearchCategory))
            {
                query = query.Where(r => r.Category.CategoryName.Contains(SearchCategory));
            }

            Recipe = await query.ToListAsync();
        }
    }
}
