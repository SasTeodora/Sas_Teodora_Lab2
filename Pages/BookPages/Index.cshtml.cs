using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sas_Teodora_Lab2.Models;

namespace Sas_Teodora_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Sas_Teodora_Lab2Context _context;

    public IndexModel(Sas_Teodora_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public SelectList AuthorList { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .ToListAsync();

        var authors = await _context.Authors
            .Select(a => new
            {
                a.ID,
                FullName = a.FirstName + " " + a.LastName
            })
            .ToListAsync();

        AuthorList = new SelectList(authors, "ID", "FullName");
    }
}