using System.ComponentModel.DataAnnotations;

using Infrastructure.Identity;

namespace Infrastructure.DTO;


public class StudentDTO : AppUserDTO
{
    [Required]
    public string Group { get; set; } = "";
    [Required]
    public string DirectionOfStudy { get; set; } = "";
    [Required]
    public string ServiceNumber { get; set; } = "";
    
    public StudentDTO() {}
    public StudentDTO(AppUserDTO user) : base(user) { }

    public new StudentUser ToIdentityUser()
    {
        return new StudentUser(base.ToIdentityUser())
        {
            Group = Group,
            DirectionOfStudy = DirectionOfStudy,
            ServiceNumber = ServiceNumber,
        };
    }
}

