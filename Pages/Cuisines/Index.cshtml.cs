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
    public class IndexModel : PageModel
    {
        private readonly GourmandGurus.Data.GourmandGurusContext _context;

        public IndexModel(GourmandGurus.Data.GourmandGurusContext context)
        {
            _context = context;
        }

        public IList<Cuisine> Cuisine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cuisine != null)
            {
                Cuisine = await _context.Cuisine.ToListAsync();
            }
        }
    }
}
