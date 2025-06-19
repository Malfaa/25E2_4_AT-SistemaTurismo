using SistemaTurismo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaTurismo.Pages;

public class ClienteDetails : PageModel
{
    public Cliente? Cliente { get; private set; }
    
    private readonly List<Cliente> _clientesFicticios = new()
    {
        new Cliente { Id = 1, Nome = "Ana Silva", Email = "ana.silva@email.com" },
        new Cliente { Id = 2, Nome = "Bruno Costa", Email = "bruno.costa@email.com" },
        new Cliente { Id = 123, Nome = "Carlos Pereira", Email = "carlos.pereira@email.com" }
    };
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Cliente = _clientesFicticios.FirstOrDefault(c => c.Id == id);
        
        if (Cliente == null)
        {
            return NotFound();
        }

        return Page();
    }
}