using System.Dynamic;
using System.Text.Json;
using Domain.Entities;

namespace WebApi;

public static class Hal
{
    public static ExpandoObject ToResponse(this Student student)
    {
        dynamic info = new ExpandoObject();
            
        var name = JsonSerializer.Deserialize<Name>(student.Name);
        var passport = JsonSerializer.Deserialize<Passport>(student.Passport);
        
        info.UserName = student.UserName ?? "";
        info.Name = name ?? new Name();
        info.Passport = passport ?? new Passport();
        info.DirectionOfStudy = student.DirectionOfStudy;
        info.Group = student.Group;
        info.Email = student.Email ?? "";
        info.ServiceNumber = student.ServiceNumber;
        info.INN = student.INN;
        info.SNILS = student.SNILS;
        info.Gender = student.Gender;
        return info;
    }
}