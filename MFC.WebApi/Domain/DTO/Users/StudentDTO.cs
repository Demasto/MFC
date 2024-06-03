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
    public FormOfStudy FormOfStudy { get; set; } = FormOfStudy.Bachelor;
    [Required]
    public DateOnly DateOfEnrollment  { get; set; }
    [Required]
    public int GapYearsCount { get; set; }
    
    public int Course()
    {
        return DateTime.Now.Year - DateOfEnrollment.Year - GapYearsCount;
    }
    public StudentDTO() {}
    public StudentDTO(AppUserDTO user) : base(user) { }

    public new StudentUser ToIdentityUser()
    {
        return new StudentUser(base.ToIdentityUser())
        {
            ServiceNumber = ServiceNumber,
            Group = Group,
            DirectionOfStudy = DirectionOfStudy,
            FormOfStudy = FormOfStudy,
            DateOfEnrollment = DateOfEnrollment,
            GapYearsCount = GapYearsCount
        };
    }
}

public enum FormOfStudy
{
    Bachelor,
    Specialty,
    Magistracy
}

