using Domain.Entities.Users;

namespace Infrastructure.Identity;

public class StudentUser : AppUser
{
    public string Group { get; set; } = null!;
    public string DirectionOfStudy { get; set; } = null!;
    public string ServiceNumber { get; set; } = null!;
    
    public StudentUser() {}
    public StudentUser(AppUser appUser) : base(appUser) { }
    
    public new Student ToEntity()
    {
        return new Student(base.ToEntity())
        {
            Group = Group,
            DirectionOfStudy = DirectionOfStudy,
            ServiceNumber = ServiceNumber
        };
    }
    
}
