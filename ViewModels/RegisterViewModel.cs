using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "El email es obligatorio")]
    public string Email { get; set; }
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required(ErrorMessage = "La contraseña debe ser confirmada")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
    public string ConfirmPassword { get; set; }
}