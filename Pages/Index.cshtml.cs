using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using world_of_data.Models;

namespace world_of_data.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WoWClassDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<WoWClass> WoWClasses {get; set;} = default!;
        public List<Character> Characters {get; set;} = default!;

        public WoWClass WoWClass {get; set;}
        public Character Character {get; set;} = default!;

        public IndexModel(WoWClassDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        // public async Task<IActionResult> OnGetAsync(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     // Round 3: Add .Include() to bring in courses
        //     WoWClass = await _context.WoWClass.Include(c => c.Characters).FirstOrDefaultAsync(m => m.WoWClassID == id);
            
        //     if (WoWClass == null)
        //     {
        //         return NotFound();
        //     }
        //     return Page();
        // }
        public void OnGet()
        {
            WoWClasses = _context.WoWClass.ToList();
            Characters = _context.Character.ToList();
        }
    }
}