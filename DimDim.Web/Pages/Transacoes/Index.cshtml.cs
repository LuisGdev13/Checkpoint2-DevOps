using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Transacoes;

public class IndexModel : PageModel
{
    private readonly DimDimDbContext _context;

    public IndexModel(DimDimDbContext context)
    {
        _context = context;
    }

    public IList<Transacao> Transacoes { get; set; } = new List<Transacao>();

    public async Task OnGetAsync()
    {
        Transacoes = await _context.Transacoes
            .Include(t => t.Cliente)
            .AsNoTracking()
            .OrderByDescending(t => t.Data)
            .ToListAsync();
    }
}