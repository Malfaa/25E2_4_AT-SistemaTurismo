using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaTurismo.Pages;

public class Nota
{
    [Required(ErrorMessage = "O nome do arquivo é obrigatório.")]
    [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "O nome do arquivo pode conter apenas letras, números, espaços, hífens e underscores.")]
    [Display(Name = "Nome do Arquivo")]
    public string NomeDoArquivo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O conteúdo da anotação é obrigatório.")]
    [Display(Name = "Conteúdo da Anotação")]
    public string Conteudo { get; set; } = string.Empty;
}

public class ViewNotes : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly string _filesPath;

    public ViewNotes(IWebHostEnvironment environment)
    {
        _environment = environment;
        _filesPath = Path.Combine(_environment.WebRootPath, "files");
    }

    [BindProperty]
    public Nota Input { get; set; } = new();

    public List<string> Arquivos { get; set; } = new();
    public string? ConteudoNota { get; private set; }
    public string? ArquivosSelecionados { get; private set; }
        
    public async Task<IActionResult> OnGetAsync(string? fileName)
    {
        Directory.CreateDirectory(_filesPath);

        Arquivos = Directory.GetFiles(_filesPath, "*.txt")
            .Select(Path.GetFileName)
            .ToList()!;

        if (!string.IsNullOrWhiteSpace(fileName))
        {
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return BadRequest("Nome de arquivo inválido.");
            }

            var filePath = Path.Combine(_filesPath, fileName);
            if (System.IO.File.Exists(filePath))
            {
                ArquivosSelecionados = fileName;
                ConteudoNota = await System.IO.File.ReadAllTextAsync(filePath);
            }
            else
            {
                TempData["ErrorMessage"] = $"O arquivo '{fileName}' não foi encontrado.";
            }
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(null); 
            return Page();
        }

        Directory.CreateDirectory(_filesPath);
            
        var arquivoComExtensao = $"{Input.NomeDoArquivo}.txt";
        var path = Path.Combine(_filesPath, arquivoComExtensao);

        if (System.IO.File.Exists(path))
        {
            ModelState.AddModelError("Input.FileName", "Um arquivo com este nome já existe. Escolha outro nome.");
            await OnGetAsync(null); 
            return Page();
        }

        await System.IO.File.WriteAllTextAsync(path, Input.Conteudo);

        TempData["SuccessMessage"] = $"Anotação '{arquivoComExtensao}' salva com sucesso!";

        return RedirectToPage();
    }
}