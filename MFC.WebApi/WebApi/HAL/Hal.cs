using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text.Json;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using WebApi.DTO;

namespace WebApi;

public static class Hal
{
    public static Student ToStudent(this AppUser appUser)
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
    
    public static AppUser ToIdentityUser(this StudentDTO student)
    {
        return new AppUser() {
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
    
    public static Dictionary<string, string> GetDisplayNameList<T>()
    {
        var info = TypeDescriptor.GetProperties(typeof(T))
            .Cast<PropertyDescriptor>()
            .Where(p => p.Attributes.Cast<Attribute>().Any(a => a.GetType() == typeof(RequiredAttribute)))
            .ToDictionary(p => p.Name, p => p.DisplayName);
        return info;
    }
}