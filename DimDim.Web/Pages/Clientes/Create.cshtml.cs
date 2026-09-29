using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DimDim.Web.Pages.Clientes;

public class CreateModel : PageModel
{
    private readonly DimDimDbContext _context;

    public CreateModel(DimDimDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Clientes.Add(Cliente);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}