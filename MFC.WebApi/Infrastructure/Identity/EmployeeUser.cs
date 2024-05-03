using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class EmployeeUser : AppUser
{
    public string Post { get; set; } = "";

}