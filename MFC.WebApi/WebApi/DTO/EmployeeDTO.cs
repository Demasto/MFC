using System.ComponentModel.DataAnnotations;
using Infrastructure.Identity.Users;

namespace WebApi.DTO;


public class EmployeeDTO : AppUserDTO
{
    [Required]
    public string Post { get; set; } = "";
    

    public new EmployeeUser ToIdentityUser()
    {
         return new EmployeeUser(base.ToIdentityUser())
         {
             Post = Post
         };
    }
  
}