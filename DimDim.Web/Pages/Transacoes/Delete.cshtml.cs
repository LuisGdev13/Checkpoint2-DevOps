using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Transacoes;

public class DeleteModel : PageModel
{
    private readonly DimDimDbContext _context;

    public DeleteModel(DimDimDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Transacao Transacao { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var transacao = await _context.Transacoes
            .Include(t => t.Cliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transacao is null)
        {
            return NotFound();
        }

        Transacao = transacao;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var transacao = await _context.Transacoes
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transacao is null)
        {
            return NotFound();
        }

        _context.Transacoes.Remove(transacao);

        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}