namespace Domain.Entities.Users;

public class User
{
    private string _userName = "";
    private string _email  = "";
    private string _phoneNumber = "";
    private string _gender = "";
    private string _inn = "";
    private string _snils = "";

    public User() {}

    protected User(User user)
    {
        UserName = user.UserName;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Gender = user.Gender;
        INN = user.INN;
        SNILS = user.SNILS;
        Name = user.Name;
        Passport = user.Passport;
    }
    
    
    public string UserName
    {
        get => _userName;
        set => _userName = Valid.StringProperty(value);
    }
    public string Email
    {
        get => _email;
        set => _email = Valid.StringProperty(value);
    }
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = Valid.StringProperty(value);
    }
    public string Gender
    {
        get => _gender;
        set => _gender = Valid.StringProperty(value);
    }
    public string INN
    {
        get => _inn;
        set => _inn = Valid.StringProperty(value);
    }
    public string SNILS
    {
        get => _snils;
        set => _snils = Valid.StringProperty(value);
    }
    
    public Name Name { get; set; } = new Name();
    public Passport Passport { get; set; } = new Passport();
    
    
    
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