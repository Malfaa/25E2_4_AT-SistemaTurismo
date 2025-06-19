using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaTurismo.Data;
using SistemaTurismo.Model;

namespace SistemaTurismo.Pages.Clientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SistemaTurismoContext _context;

        public IndexModel(SistemaTurismoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes.ToListAsync();
        }
    }
}
