using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.Models;

public class Brand
{
    public int Id { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Este campo debe tener entre 3 y 30 caracteres")]
    public string Name { get; set; } = string.Empty;
    public bool IsNational { get; set; }
}