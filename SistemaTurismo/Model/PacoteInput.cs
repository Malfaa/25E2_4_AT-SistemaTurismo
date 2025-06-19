using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTurismo.Model
{
    public class PacoteInput
    {
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O Título deve ter entre 10 e 150 caracteres.")]
        [Display(Name = "Título do Pacote")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Início é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "A Capacidade Máxima é obrigatória.")]
        [Range(1, 100, ErrorMessage = "A capacidade deve ser entre 1 e 100 pessoas.")]
        [Display(Name = "Capacidade Máxima")]
        public int CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}