using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using world_of_data.Models;

namespace world_of_data.Pages
{
    public class ClassesModel : PageModel
    {
        private readonly WoWClassDbContext _context; // Replaces the "db" variable from before
        private readonly ILogger<ClassesModel> _logger;
        public List<WoWClass> WoWClasses {get; set;} = default!;
        // public List<Character> Characters {get; set;} = default!;
        public SelectList ClassDropDown {get; set;}
        // public SelectList CharacterDropDown {get; set;}
        [BindProperty]
        public WoWClass WoWClass {get; set;}

        public ClassesModel(WoWClassDbContext context, ILogger<ClassesModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            WoWClasses = _context.WoWClass.ToList();
            // Characters = _context.Characters.ToList();
            ClassDropDown = new SelectList(WoWClasses, "WoWClassID", "classSpec");
        }

        public void OnPost()
        {
            // Extra Credit Step 2: OnPost() is called when user hits submit
            // Refresh SelectList and find selected professor in database
            WoWClass = _context.WoWClass.Find(WoWClass.WoWClassID);
            WoWClasses = _context.WoWClass.ToList();
            ClassDropDown = new SelectList(WoWClasses, "WoWClassID", "classSpec");
        }
    }
}