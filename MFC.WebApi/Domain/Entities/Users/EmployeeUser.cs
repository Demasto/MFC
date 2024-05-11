using Domain.DTO.Users;
namespace Domain.Entities.Users;

public sealed class EmployeeUser : AppUser
{
    public string Post { get; set; } = "";
    public string Institute { get; set; } = "";
    
    public EmployeeUser() {}
    public EmployeeUser(AppUser appUser) : base(appUser) { }

    public override EmployeeDTO ToDTO()
    {
        return new EmployeeDTO(base.ToDTO())
        {
            Post = Post,
            Institute = Institute
        };
    }
    
    public override string UserRole { get; } = Role.Employee;
}