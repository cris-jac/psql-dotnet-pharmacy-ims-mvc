using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.Models;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Categoria debe contener entre 4 y 20 caracteres")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripcion debe contener entre 10 y 50 caracteres")]
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}