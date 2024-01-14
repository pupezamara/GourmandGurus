using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GourmandGurus.Models;

namespace GourmandGurus.Data
{
    public class GourmandGurusContext : DbContext
    {
        public GourmandGurusContext (DbContextOptions<GourmandGurusContext> options)
            : base(options)
        {
        }

        public DbSet<GourmandGurus.Models.Recipe> Recipe { get; set; } = default!;

        public DbSet<GourmandGurus.Models.Cuisine>? Cuisine { get; set; }

        public DbSet<GourmandGurus.Models.Category>? Category { get; set; }

        public DbSet<GourmandGurus.Models.Member>? Member { get; set; }

        
    }
}
