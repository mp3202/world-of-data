using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using world_of_data.Models;

namespace world_of_data.Pages
{
    public class IndexModel : PageModel
    {
        private readonly world_of_data.Models.WoWClassDbContext _context;

        public IndexModel(world_of_data.Models.WoWClassDbContext context)
        {
            _context = context;
        }

        public WoWClass WoWClass { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Round 3: Add .Include() to bring in courses
            WoWClass = await _context.WoWClass.Include(p => p.Characters).FirstOrDefaultAsync(m => m.WoWClassID == id);
            
            if (WoWClass == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}