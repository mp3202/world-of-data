using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using world_of_data.Models;

namespace world_of_data.Pages;

public class IndexModel : PageModel
{
    private readonly WoWClassDbContext _context; // Replaces the "db" variable from before
    private readonly ILogger<IndexModel> _logger;
    public List<WoWClass> WoWClasses {get; set;} = default!;
    public IndexModel(WoWClassDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        WoWClasses = _context.WoWClasses.ToList();
    }
}
