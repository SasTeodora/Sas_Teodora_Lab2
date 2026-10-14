using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sas_Teodora_Lab2.Models;

namespace Sas_Teodora_Lab2.Pages.BookPages;

public class CreateModel : PageModel
{
    private readonly Sas_Teodora_Lab2Context _context;

    public CreateModel(Sas_Teodora_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["PublisherID"] = new SelectList(
            _context.Publisher, "ID", "PublisherName");

        ViewData["AuthorID"] = new SelectList(
            _context.Authors
                .Select(a => new
                {
                    a.ID,
                    FullName = a.FirstName + " " + a.LastName
                }),
            "ID", "FullName");

        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["PublisherID"] = new SelectList(
                _context.Publisher, "ID", "PublisherName");

            ViewData["AuthorID"] = new SelectList(
                _context.Authors
                    .Select(a => new
                    {
                        a.ID,
                        FullName = a.FirstName + " " + a.LastName
                    }),
                "ID", "FullName");

            return Page();
        }
        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
