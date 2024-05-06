using Infrastructure.DTO;

namespace Infrastructure.Identity;

public class EmployeeUser : AppUser
{
    public string Post { get; set; } = "";
    
    public EmployeeUser() {}
    public EmployeeUser(AppUser appUser) : base(appUser) { }

    public new EmployeeDTO ToDTO()
    {
        return new EmployeeDTO(base.ToDTO())
        {
            Post = Post
        };
    }
}