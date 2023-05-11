using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using world_of_data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace world_of_data.Pages.Professors
{
    public class IndexModel : PageModel
    {
        private readonly world_of_data.Models.WoWClassDbContext _context;
        // private readonly ILogger<IndexModel> _logger;
        public IList<WoWClass> WoWClasses { get;set; } = default!;
        public IList<Character> Characters { get;set; } = default!;
        public IndexModel(world_of_data.Models.WoWClassDbContext context)
        {
            _context = context;
            // _logger = logger;
        }


        // Paging support
        // PageNum is the current page number we are on
        // PageSize is how many records will be displayed per page. 
        // PageNum needs BindProperty because the user decides which page we are on.
        // The user selects the page number
        // SupportsGet = true allows us to pass the PageNum through the URL with an HTTP Get Parameter 
        // This is necessary, because page numbers are not passed through normal forms
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
                //Professor = await _context.Professor.ToListAsync();
                // Sorting support
                // Break up query. Do basic query first that just selects all professors
                var query = _context.WoWClass.Select(p => p);
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    new SelectListItem { Text = "FirstName Ascending", Value = "first_asc" },
                    new SelectListItem { Text = "FirstName Descending", Value = "first_desc"}
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

                // switch (CurrentSort)
                // {
                //     // If user selected "first_asc", modify query to sort by first name ascending order
                //     case "first_asc": 
                //         query = query.OrderBy(p => p.FirstName);
                //         break;
                //     // If user selected "first_desc", modify query to sort by first name descending
                //     case "first_desc":
                //         query = query.OrderByDescending(p => p.FirstName);
                //         break;
                //     // Add more sorting cases as needed
                // }

                // Retrieve just the professors for the page we are on
                // Use .Skip() and .Take() to select them
                WoWClasses = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            }
        }
    }
}
