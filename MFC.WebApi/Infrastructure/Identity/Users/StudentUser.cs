using Infrastructure.DTO;

namespace Infrastructure.Identity;

public class StudentUser : AppUser
{
    public string Group { get; set; } = null!;
    public string DirectionOfStudy { get; set; } = null!;
    public string ServiceNumber { get; set; } = null!;
    
    public StudentUser() {}
    public StudentUser(AppUser appUser) : base(appUser) { }
    
    public override StudentDTO ToDTO()
    {
        return new StudentDTO(base.ToDTO())
        {
            Group = Group,
            DirectionOfStudy = DirectionOfStudy,
            ServiceNumber = ServiceNumber
        };
    }
    
}
