using System.Text.Json;
using Domain.Entities.Users;
using Infrastructure.Identity;

namespace WebApi;

public static class ToEntity
{
    public static User ToUser(this AppUser appUser)
    {
        return new User
        {
            UserName = appUser.UserName!,
            Name = JsonSerializer.Deserialize<Name>(appUser.Name)!,
            Passport = JsonSerializer.Deserialize<Passport>(appUser.Passport)!,
            Email = appUser.Email!, 
            PhoneNumber = appUser.PhoneNumber!,
            Gender = appUser.Gender, 
            INN = appUser.INN, 
            SNILS = appUser.SNILS,
        };
    }
    public static Student ToStudent(this StudentUser appUser)
    {
        return new Student(appUser.ToUser())
        {
            Group = appUser.Group, 
            DirectionOfStudy = appUser.DirectionOfStudy,
            ServiceNumber = appUser.ServiceNumber, 
        };
    }
    public static Employee ToEmployee(this EmployeeUser appUser)
    {
        return new Employee(appUser.ToUser())
        {
            Post = appUser.Post
        };
    }
}