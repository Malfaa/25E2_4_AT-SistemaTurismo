using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaTurismo.Data;
using SistemaTurismo.Model;

namespace SistemaTurismo.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaTurismoContext _context;

        public DeleteModel(SistemaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente is not null)
            {
                Cliente = cliente;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (cliente != null)
            {
                cliente.DeletedAt = DateTime.UtcNow; 
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
