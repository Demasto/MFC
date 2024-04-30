namespace Domain.Entities;

public class Student(
    string? userName,
    string? group,
    string? directionOfStudy,
    string? serviceNumber,
    string? email,
    string? phoneNumber,
    string? gender,
    string? inn,
    string? snils,
    Name? name = null,
    Passport? passport = null)
{
    public string UserName { get; set; } = Valid.StringProperty(userName);
    public Name Name { get; set; } = name ?? new Name();
    public Passport Passport { get; set; } = passport ?? new Passport();
    public string Group { get; set; } = Valid.StringProperty(group);
    public string DirectionOfStudy { get; set; } = Valid.StringProperty(directionOfStudy);
    public string ServiceNumber { get; set; } = Valid.StringProperty(serviceNumber);
    public string Email { get; set; } = Valid.StringProperty(email);
    public string PhoneNumber { get; set; } = Valid.StringProperty(phoneNumber);
    public string Gender { get; set; } = Valid.StringProperty(gender);
    public string INN { get; set; } = Valid.StringProperty(inn);
    public string SNILS { get; set; } = Valid.StringProperty(snils);

    public Dictionary<string, object?> ToDictionary()
    {
        var info = new Dictionary<string, object?>();
        var obj = GetType();
        var props = obj.GetProperties();
        foreach (var property in props)
        {
            Console.WriteLine("property.GetValue(this)");
            Console.WriteLine(property.GetValue(this));
            info[property.Name] = property.GetValue(this);
        }

        return info;
    }
}

public static class Valid
{
    public static string StringProperty(string? prop)
    {
        return prop ?? string.Empty;
    }
}

public class Passport
{
    public string Series { get; set; } = "";
    public string Number { get; set; } = "";
    public string UnitCode { get; set; } = "";
    public string PlaceOfBrith { get; set; } = "";
    public DateOnly DateOfBrith { get; set; }
    public DateOnly DateOfIssue { get; set; }
    public string Citizenship { get; set; } = "";

}

public class Name()
{
    public string First { get; set; } = "";
    public string Second { get; set; } = "";
    public string Middle { get; set; } = "";
}