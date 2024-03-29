using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Commerces.Models;

namespace E_Commerces.Pages_Categories
{
    public class IndexModel : PageModel
    {
        private readonly E_Commerces.Models.ApplicationDbContext _context;

        public IndexModel(E_Commerces.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
