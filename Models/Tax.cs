using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaMVC.Models;

public class Tax
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required(ErrorMessage = "La tasa de impuesto es obligatoria")]
    [Column(TypeName = "decimal(4, 1)")]
    public decimal Rate { get; set; }
}