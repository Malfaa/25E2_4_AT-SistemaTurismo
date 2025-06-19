using System.ComponentModel.DataAnnotations;

namespace SistemaTurismo.Model;

public class Cliente
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
    public string Email { get; set; } = string.Empty;
    
    public List<Reserva>? Reservas { get; set; }
    
    public DateTime? DeletedAt { get; set; } 
}

public class ClienteInputModel
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
    public string Email { get; set; } = string.Empty;
}