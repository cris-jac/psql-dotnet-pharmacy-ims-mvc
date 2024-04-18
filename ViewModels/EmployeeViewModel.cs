namespace PharmaMVC.ViewModels;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Position { get; set; }
    public DateTime? StartingDate { get; set; }
    public string? PictureUrl { get; set; }
    public bool? IsActive { get; set; }
}