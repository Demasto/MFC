using System.Text.Json;
using Domain.Entities;
using Infrastructure.Identity;
using WebApi.DTO;

namespace WebApi;

public static class Hal
{
    public static Student ToStudent(this StudentUser appUser)
    {
         return new Student(
            appUser.UserName,
            appUser.Group, 
            appUser.DirectionOfStudy, 
            appUser.ServiceNumber, 
            appUser.Email, 
            appUser.PhoneNumber,
            appUser.Gender, 
            appUser.INN, 
            appUser.SNILS,
            JsonSerializer.Deserialize<Name>(appUser.Name),
            JsonSerializer.Deserialize<Passport>(appUser.Passport));
    }
    
    public static StudentUser ToIdentityUser(this StudentDTO student)
    {
        return new StudentUser() {
            UserName = student.UserName,
            Group = student.Group,
            DirectionOfStudy = student.DirectionOfStudy,
            ServiceNumber = student.ServiceNumber,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
            Gender = student.Gender,
            INN = student.INN,
            SNILS = student.SNILS,
            Name = JsonSerializer.Serialize(student.Name),
            Passport = JsonSerializer.Serialize(student.Passport)
        };
    }
    
    public static EmployeeUser ToIdentityUser(this EmployeeDTO employee)
    {
        return new EmployeeUser() {
            UserName = employee.UserName,
            Post = employee.Post,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            Gender = employee.Gender,
            INN = employee.INN,
            SNILS = employee.SNILS,
            Name = JsonSerializer.Serialize(employee.Name),
            Passport = JsonSerializer.Serialize(employee.Passport)
        };
    }
}