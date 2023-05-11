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

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;
        // Second sorting technique with a SelectList
        public SelectList SortList {get; set;} = default!;

        public async Task OnGetAsync()
        {
            if (_context.WoWClass != null)
            {
                WoWClass = await _context.WoWClass.ToListAsync();
                Character = await _context.Character.ToListAsync();
             
                //FILTER BY: (Armor Type: PLATE, MAIL, LEATHER, CLOTH), (Role: DPS, HEALER, TANK)
                var query = _context.WoWClass.Include(c=>c.Characters).Select(p => p);
                // var query_char = _context.WoWClass.SelectMany(wowClass => wowClass.Characters);
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    // by armor type
                    new SelectListItem { Text = "Armor: PLATE", Value = "plate_sort" },
                    new SelectListItem { Text = "Armor: MAIL", Value = "mail_sort"},
                    new SelectListItem { Text = "Armor: LEATHER", Value = "leather_sort" },
                    new SelectListItem { Text = "Armor: CLOTH", Value = "cloth_sort"},

                    // by role
                    new SelectListItem { Text = "Role: HEALER", Value = "healer_sort" },
                    new SelectListItem { Text = "Role: DPS", Value = "dps_sort"},
                    new SelectListItem { Text = "Role: TANK", Value = "tank_sort"},

                    // // by name/realm/class/spec a-z
                    // new SelectListItem { Text = "Realm A-Z", Value = "realm_asc" },
                    // new SelectListItem { Text = "Realm Z-A", Value = "realm_desc"},

                    // new SelectListItem { Text = "Name A-Z", Value = "name_asc" },
                    // new SelectListItem { Text = "Name Z-A", Value = "name_desc"},

                    // new SelectListItem { Text = "Class A-Z", Value = "class_asc" },
                    // new SelectListItem { Text = "Class Z-A", Value = "class_desc"},

                    // new SelectListItem { Text = "Spec A-Z", Value = "spec_asc" },
                    // new SelectListItem { Text = "Spec Z-A", Value = "spec_desc"},

                    // // by ilvl,  arena/mythic scores
                    // new SelectListItem { Text = "2v2 Ascending", Value = "arena2v2_asc" },
                    // new SelectListItem { Text = "2v2 Descending", Value = "arena2v2_desc"},

                    // new SelectListItem { Text = "3v3 Ascending", Value = "arena3v3_asc" },
                    // new SelectListItem { Text = "3v3 Descending", Value = "arena3v3_desc"},
                    
                    // new SelectListItem { Text = "Mythic Ascending", Value = "mythic_asc" },
                    // new SelectListItem { Text = "Mythic Descending", Value = "mythic_desc"}
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

                switch (CurrentSort)
                {
                    // ALPHABETICAL SORTING
                    // case "name_asc":
                    //     query_char = query_char.OrderBy(p => p.charName);
                    //     break;
                    // case "name_desc":
                    //     query_char = query_char.OrderByDescending(p => p.charName);
                    //     break;

                    // case "realm_asc":
                    //     query_char = query_char.OrderBy(p => p.Realm);
                    //     break;
                    // case "realm_desc":
                    //     query_char = query_char.OrderByDescending(p => p.Realm);
                    //     break;

                    // case "class_asc":
                    //     query = query.OrderBy(p => p.className);
                    //     break;
                    // case "class_desc":
                    //     query = query.OrderByDescending(p => p.className);
                    //     break;

                    // case "spec_asc":
                    //     query = query.OrderBy(p => p.classSpec);
                    //     break;
                    // case "spec_desc":
                    //     query = query.OrderByDescending(p => p.classSpec);
                    //     break;

                    // // FOR SCORES SORTING
                    // case "ilvl_asc":
                    //     query_char = query_char.OrderBy(p => p.iLVL);
                    //     break;
                    // case "ilvl_desc":
                    //     query_char = query_char.OrderByDescending(p => p.iLVL);
                    //     break;

                    // case "arena2v2_asc":
                    //     query_char = query_char.OrderBy(p => p.Arena2v2);
                    //     break;
                    // case "arena2v2_desc":
                    //     query_char = query_char.OrderByDescending(p => p.Arena2v2);
                    //     break;

                    // case "arena3v3_asc":
                    //     query_char = query_char.OrderBy(p => p.Arena3v3);
                    //     break;
                    // case "arena3v3_desc":
                    //     query_char = query_char.OrderByDescending(p => p.Arena3v3);
                    //     break;

                    // case "mythic_asc":
                    //     query_char = query_char.OrderBy(p => p.MythicScore);
                    //     break;
                    // case "mythic_desc":
                    //     query_char = query_char.OrderByDescending(p => p.MythicScore);
                    //     break;

                    // for filtering
                    case "plate_sort":
                        query = query.Select(s=>s).Where(c => c.classArmor.Contains("Plate"));
                        break;
                    case "mail_sort":
                        query = query.Where(c => c.classArmor.Contains("Mail"));  
                        break;
                    case "leather_sort":
                        query = query.Where(c => c.classArmor.Contains("Leather"));
                        break;
                    case "cloth_sort":
                        query = query.Where(c => c.classArmor.Contains("Cloth"));
                        break;

                    case "healer_sort":
                        query = query.Where(c => c.classRole.Contains("Healer"));
                        break;
                    case "dps_sort":
                        query = query.Where(c => c.classRole.Contains("DPS"));
                        break;
                    case "tank_sort":
                        query = query.Where(c => c.classRole.Contains("Tank"));
                        break;
                }

                WoWClass = await query.ToListAsync();
                
            }

        }

    }
}
