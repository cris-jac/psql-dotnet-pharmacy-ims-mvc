using Microsoft.AspNetCore.Identity;

namespace PharmaMVC.Models;

public class AppUser : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DocumentType { get; set; }
    public int DocumentNumber { get; set; }
    public DateTime StartingDate { get; set; }
    public string? Position { get; set; }
    public string? PictureUrl { get; set; }
    public bool IsActive { get; set; }
}