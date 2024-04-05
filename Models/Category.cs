using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.Models;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(30, MinimumLength = 4, ErrorMessage = "Categoria debe contener entre 4 y 20 caracteres")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(80, MinimumLength = 4, ErrorMessage = "La descripcion debe contener entre 4 y 80 caracteres")]
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}