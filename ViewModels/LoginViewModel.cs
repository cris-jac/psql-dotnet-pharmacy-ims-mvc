using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "El email es obligatorio")]
    public string Email { get; set; }
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}