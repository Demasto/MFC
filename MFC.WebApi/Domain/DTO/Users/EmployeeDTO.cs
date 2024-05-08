using System.ComponentModel.DataAnnotations;

using Domain.Entities.Users;

namespace Domain.DTO.Users;


public class EmployeeDTO : AppUserDTO
{
    [Required]
    public string Post { get; set; } = "";
    [Required]
    public string Institute { get; set; } = "";
    public EmployeeDTO() {}
    public EmployeeDTO(AppUserDTO user) : base(user) { }

    public new EmployeeUser ToIdentityUser()
    {
         return new EmployeeUser(base.ToIdentityUser())
         {
             Post = Post,
             Institute = Institute
         };
    }
  
}