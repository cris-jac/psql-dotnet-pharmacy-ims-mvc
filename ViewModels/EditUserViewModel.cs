namespace PharmaMVC.ViewModels;

public class EditUserViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentType { get; set; }
    public int DocumentNumber { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? PictureUrl { get; set; }
}
