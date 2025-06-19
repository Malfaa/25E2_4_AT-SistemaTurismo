using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTurismo.Model;


public class PacoteTuristico
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataInicio { get; set; }
    
    [Range(1, 20, ErrorMessage = "A capacidade máxima deve ser entre 1 e 20 pessoas.")]
    public int CapacidadeMaxima { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }
    
    [DataType(DataType.Date)] 
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public List<Destino> Destinos { get; set; }
}