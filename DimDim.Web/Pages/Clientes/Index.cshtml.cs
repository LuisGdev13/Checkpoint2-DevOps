using DimDim.Web.Data;
using DimDim.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Pages.Clientes;

public class IndexModel : PageModel
{
    private readonly DimDimDbContext _context;

    public IndexModel(DimDimDbContext context)
    {
        _context = context;
    }

    public IList<Cliente> Clientes { get; set; } = new List<Cliente>();

    public async Task OnGetAsync()
    {
        Clientes = await _context.Clientes
            .AsNoTracking()
            .OrderBy(c => c.Nome)
            .ToListAsync();
    }
}