using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class StudentUser : AppUser
{
    public string Group { get; set; } = null!;
    public string DirectionOfStudy { get; set; } = null!;
    public string ServiceNumber { get; set; } = null!;
    
}
