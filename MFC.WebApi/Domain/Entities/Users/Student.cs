namespace Domain.Entities.Users;

public class Student : User
{
    private string _group = "";
    private string _directionOfStudy = "";
    private string _serviceNumber = "";
    
    public Student() {}
    public Student(User user) : base(user) { }

    public string Group
    {
        get => _group;
        set => _group = Valid.StringProperty(value);
    }
    public string DirectionOfStudy
    {
        get => _directionOfStudy;
        set => _directionOfStudy = Valid.StringProperty(value);
    }

    public string ServiceNumber
    {
        get => _serviceNumber;
        set => _serviceNumber = Valid.StringProperty(value);
    }
    
    
}

