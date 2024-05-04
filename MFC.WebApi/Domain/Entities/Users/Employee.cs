namespace Domain.Entities.Users;

public class Employee : User
{
    private string _post = "";
    
    public Employee() {}
    public Employee(User user) : base(user) { }

    public string Post
    {
        get => _post;
        set => _post = Valid.StringProperty(value);
    }
}