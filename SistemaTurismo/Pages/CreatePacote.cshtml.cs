using SistemaTurismo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaTurismo.Pages
{
    public class CreatePacote : PageModel
    {
        private readonly ILogger<CreatePacote> _logger;

        public CreatePacote(ILogger<CreatePacote> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public PacoteInput Input { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var novoPacote = new PacoteTuristico
            {
                Titulo = Input.Titulo,
                DataInicio = Input.DataInicio,
                CapacidadeMaxima = Input.CapacidadeMaxima,
                Preco = Input.Preco
            };

            _logger.LogInformation("Pacote Turístico '{Titulo}' criado com sucesso.", novoPacote.Titulo);

            TempData["SuccessMessage"] = $"Pacote '{novoPacote.Titulo}' criado com sucesso!";
            return RedirectToPage("./Index"); 
        }
    }
}
