using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Clientes;

public class EditModel : PageModel
{
    private readonly DimDimDbContext _context;

    public EditModel(DimDimDbContext context)
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

        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
        {
            return NotFound();
        }

        Cliente = cliente;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var cliente = await _context.Clientes.FindAsync(Cliente.Id);

        if (cliente is null)
        {
            return NotFound();
        }

        cliente.Nome = Cliente.Nome;
        cliente.Email = Cliente.Email;
        cliente.Telefone = Cliente.Telefone;

        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}