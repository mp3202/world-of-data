using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using world_of_data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace world_of_data.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly world_of_data.Models.WoWClassDbContext _context;
        public IList<WoWClass> WoWClass { get;set; } = default!;
        public IList<Character> Character { get;set; } = default!;
        public IndexModel(world_of_data.Models.WoWClassDbContext context)
        {
            _context = context;
            // _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;
        // Second sorting technique with a SelectList
        public SelectList SortList {get; set;} = default!;

        public async Task OnGetAsync()
        {
            if (_context.WoWClass != null)
            {
                // WoWClass = await _context.WoWClass.ToListAsync();
                WoWClass = await _context.WoWClass.Include(w => w.Characters).ToListAsync();
                Character = await _context.Character.ToListAsync();
                // Character = _context.Character.ToList();
             
                // Sorting support
                // var query = _context.WoWClass.Include(p => p.Characters).Select(p => p);
                var query = _context.WoWClass.Select(p => p);
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    new SelectListItem { Text = "iLVL Ascending", Value = "ilvl_asc" },
                    new SelectListItem { Text = "iLVL Descending", Value = "ilvl_desc"},

                    new SelectListItem { Text = "2v2 Ascending", Value = "arena2v2_asc" },
                    new SelectListItem { Text = "2v2 Descending", Value = "arena2v2_desc"},

                    new SelectListItem { Text = "3v3 Ascending", Value = "arena3v3_asc" },
                    new SelectListItem { Text = "3v3 Descending", Value = "arena3v3_desc"},
                    
                    new SelectListItem { Text = "Mythic Ascending", Value = "mythic_asc" },
                    new SelectListItem { Text = "Mythic Descending", Value = "mythic_desc"}
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

                switch (CurrentSort)
                { // asc/desc for ilvl, arena scores, mythic scores
                    case "ilvl_asc":
                        query = query.OrderBy(p => p.Characters.Min(c => c.iLVL));
                        break;
                    case "ilvl_desc":
                        WoWClass = WoWClass.OrderByDescending(w => w.Characters.Min(c => c.iLVL)).ToList();
                        // query = query.OrderByDescending(p => p.Characters.Min(c => c.iLVL));
                        // query = query.OrderByDescending(p => p.Characters.Select(c => c.iLVL).Min());
                        break;

                    case "arena2v2_asc":
                        query = query.OrderBy(p => p.Characters.Min(c => c.Arena2v2));
                        break;
                    case "arena2v2_desc":
                        query = query.OrderByDescending(p => p.Characters.Min(c => c.Arena2v2));
                        break;
                    case "arena3v3_asc":
                        query = query.OrderBy(p => p.Characters.Min(c => c.Arena3v3));
                        break;
                    case "arena3v3_desc":
                        query = query.OrderByDescending(p => p.Characters.Min(c => c.Arena3v3));
                        break;
                    case "mythic_asc":
                        query = query.OrderBy(p => p.Characters.Min(c => c.MythicScore));
                        break;
                    case "mythic_desc":
                        query = query.OrderByDescending(p => p.Characters.Min(c => c.MythicScore));
                        break;
                }

                WoWClass = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            }

        }

    }
}
