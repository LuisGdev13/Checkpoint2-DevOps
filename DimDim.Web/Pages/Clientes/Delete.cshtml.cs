using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Clientes;

public class DeleteModel : PageModel
{
    private readonly DimDimDbContext _context;

    public DeleteModel(DimDimDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var cliente = await _context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente is null)
        {
            return NotFound();
        }

        Cliente = cliente;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
        {
            return NotFound();
        }

        try
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            TempData["DeleteError"] =
                "Não é possível excluir este cliente porque existem transações relacionadas a ele.";

            return RedirectToPage("Index");
        }

        return RedirectToPage("Index");
    }
}