using SistemaTurismo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaTurismo.Pages;

public class CreateCliente : PageModel
{
    private readonly ILogger<CreateCliente> _logger;
        
    public CreateCliente(ILogger<CreateCliente> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public ClienteInputModel Input { get; set; } = new();

   
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var novoCliente = new Cliente
        {
            Nome = Input.Nome,
            Email = Input.Email
        };
        
        _logger.LogInformation("Cliente '{ClienteNome}' com e-mail '{ClienteEmail}' foi criado com sucesso.", novoCliente.Nome, novoCliente.Email);

        TempData["SuccessMessage"] = $"Cliente '{novoCliente.Nome}' criado com sucesso!";

        return RedirectToPage("./Index");
    }
}