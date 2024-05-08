using System.ComponentModel.DataAnnotations;

using Domain.Entities.Users;

namespace Domain.DTO.Users;


public class StudentDTO : AppUserDTO
{
    [Required]
    public string ServiceNumber { get; set; } = "";
    [Required]
    public string Group { get; set; } = "";
    [Required]
    public string DirectionOfStudy { get; set; } = "";
    [Required]
    public string FormOfStudy { get; set; } = "";
    
    public StudentDTO() {}
    public StudentDTO(AppUserDTO user) : base(user) { }

    public new StudentUser ToIdentityUser()
    {
        return new StudentUser(base.ToIdentityUser())
        {
            ServiceNumber = ServiceNumber,
            Group = Group,
            DirectionOfStudy = DirectionOfStudy,
            FormOfStudy = FormOfStudy
        };
    }
}

