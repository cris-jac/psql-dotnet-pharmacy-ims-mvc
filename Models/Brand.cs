using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.Models;

public class Brand
{
    public int Id { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Este campo debe tener entre 5 y 20 caracteres")]
    public string Name { get; set; } = string.Empty;
    public bool IsNational { get; set; }
}