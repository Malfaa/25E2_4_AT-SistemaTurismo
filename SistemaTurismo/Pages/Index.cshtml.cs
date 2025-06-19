using SistemaTurismo.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaTurismo.Pages;

public class IndexModel : PageModel
{

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
        
    public List<Cliente> Clientes { get; private set; } = new();
    
    private readonly List<Cliente> _clientesMocks = new()
    {
        new Cliente { Id = 1, Nome = "Ana Silva", Email = "ana.silva@email.com" },
        new Cliente { Id = 2, Nome = "Bruno Costa", Email = "bruno.costa@email.com" },
        new Cliente { Id = 123, Nome = "Carlos Pereira", Email = "carlos.pereira@email.com" }
    };

    public void OnGet()
    {
        Clientes = _clientesMocks;
    }

}