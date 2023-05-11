using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using world_of_data.Models;

namespace world_of_data.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WoWClassDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<Character> Characters {get; set;} = default!;
        public IList<WoWClass> WoWClasses { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 9;
        public IndexModel(WoWClassDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task OnGetAsync()
        {
            if (_context.WoWClass != null)
            {
                WoWClasses = await _context.WoWClass.ToListAsync();

                var query = _context.WoWClass.Select(p => p);

                WoWClasses = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            }

            Characters = _context.Character.ToList();
        }
    }
}