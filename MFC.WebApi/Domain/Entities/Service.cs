namespace Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public ServiceType Type { get; set; }
}

public enum ServiceType
{ 
    Certificate,
    StudentStatement,
    EmployeeStatement,
    Transfer,
    Reinstatement
}