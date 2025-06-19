using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaTurismo.Data;
using SistemaTurismo.Model;

namespace SistemaTurismo.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly SistemaTurismoContext _context;

        public CreateModel(SistemaTurismoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClienteInputModel Input { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
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

            _context.Clientes.Add(novoCliente);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Cliente '{novoCliente.Nome}' criado com sucesso!";

            return RedirectToPage("./Index");
        }
    }
}
