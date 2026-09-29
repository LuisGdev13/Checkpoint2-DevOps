using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Transacoes;

public class CreateModel : PageModel
{
    private readonly DimDimDbContext _context;

    public CreateModel(DimDimDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Transacao Transacao { get; set; } = new();

    public SelectList Clientes { get; set; } = default!;

    public async Task OnGetAsync()
    {
        await CarregarClientesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await CarregarClientesAsync();
            return Page();
        }

        _context.Transacoes.Add(Transacao);

        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }

    private async Task CarregarClientesAsync()
    {
        var clientes = await _context.Clientes
            .AsNoTracking()
            .OrderBy(c => c.Nome)
            .ToListAsync();

        Clientes = new SelectList(
            clientes,
            nameof(Cliente.Id),
            nameof(Cliente.Nome));
    }
}