using Domain.DTO.Users;
namespace Domain.Entities.Users;

public class StudentUser : AppUser
{
    public string ServiceNumber { get; set; } = null!;
    public string Group { get; set; } = null!;
    public string DirectionOfStudy { get; set; } = null!;
    public string FormOfStudy { get; set; } = null!;

    
    public StudentUser() {}
    public StudentUser(AppUser appUser) : base(appUser) { }
    
    public override StudentDTO ToDTO()
    {
        return new StudentDTO(base.ToDTO())
        {
            Group = Group,
            DirectionOfStudy = DirectionOfStudy,
            ServiceNumber = ServiceNumber,
            FormOfStudy = FormOfStudy
        };
    }

    public override string UserRole { get; } = Role.Student;
}
