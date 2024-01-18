using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E_Commerces.Models;

namespace E_Commreces.Data
{
    public class RazorPageDbContext : DbContext
    {
        public RazorPageDbContext (DbContextOptions<RazorPageDbContext> options)
            : base(options)
        {
        }

        public DbSet<E_Commerces.Models.Product> Product { get; set; } = default!;
    }
}
