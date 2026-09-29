using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Transacoes;

public class EditModel : PageModel
{
    private readonly DimDimDbContext _context;

    public EditModel(DimDimDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Transacao Transacao { get; set; } = new();

    public SelectList Clientes { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var transacao = await _context.Transacoes
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transacao is null)
        {
            return NotFound();
        }

        Transacao = transacao;

        await CarregarClientesAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await CarregarClientesAsync();
            return Page();
        }

        var transacao = await _context.Transacoes
            .FirstOrDefaultAsync(t => t.Id == Transacao.Id);

        if (transacao is null)
        {
            return NotFound();
        }

        transacao.Descricao = Transacao.Descricao;
        transacao.Valor = Transacao.Valor;
        transacao.Tipo = Transacao.Tipo;
        transacao.Data = Transacao.Data;
        transacao.ClienteId = Transacao.ClienteId;

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
            nameof(Cliente.Nome),
            Transacao.ClienteId);
    }
}