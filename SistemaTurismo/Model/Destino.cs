using System.ComponentModel.DataAnnotations;

namespace SistemaTurismo.Model;


public class Destino
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo Nome é obrigatório!")]
    [StringLength(100)]
    [MinLength(3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo País é obrigatório!")]
    [StringLength(50)]
    [MinLength(3, ErrorMessage = "O Nome deve ter entre 3 e 100 caracteres." )]
    public string Pais { get; set; }
}