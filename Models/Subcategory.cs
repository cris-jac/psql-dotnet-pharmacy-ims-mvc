using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.Models;

public class Subcategory
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Categoria debe contener entre 4 y 20 caracteres")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Category")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    // public List<Product> Products { get; set; } = new List<Product>();
}