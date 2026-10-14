using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sas_Teodora_Lab2.Models;

namespace Sas_Teodora_Lab2.Pages.PublisherPages;

public class DeleteModel : PageModel
{
    private readonly Sas_Teodora_Lab2Context _context;

    public DeleteModel(Sas_Teodora_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
        if (publisher is null)
        {
            return NotFound();
        }
        else
        {
            Publisher = publisher;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FindAsync(id);
        if (publisher != null)
        {
            Publisher = publisher;
            _context.Publisher.Remove(Publisher);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
