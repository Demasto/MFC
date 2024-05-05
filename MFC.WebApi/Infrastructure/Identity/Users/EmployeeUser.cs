using Domain.Entities.Users;

namespace Infrastructure.Identity.Users;

public class EmployeeUser : AppUser
{
    public string Post { get; set; } = "";
    
    public EmployeeUser() {}
    public EmployeeUser(AppUser appUser) : base(appUser) { }

    public new Employee ToEntity()
    {
        return new Employee(base.ToEntity())
        {
            Post = Post
        };
    }
}