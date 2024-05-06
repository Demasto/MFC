namespace Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public ServiceType Type { get; set; } = ServiceType.Certificate;
}

public enum ServiceType
{
    Certificate,
    StudentStatement,
    EmployeeStatement,
    Transfer,
    Reinstatement,
}

public static class ServiceDir
{
    public static readonly Dictionary<ServiceType, string> Dict = new()
    {
        [ServiceType.Certificate] = Certificate,
        [ServiceType.StudentStatement] = StudentStatement,
        [ServiceType.EmployeeStatement] = EmployeeStatement,
        [ServiceType.Transfer] = Transfer,
        [ServiceType.Reinstatement] = Reinstatement,
        
    };
    private const string Certificate = "certificates";
    private const string StudentStatement = "student_statements";
    private const string EmployeeStatement = "employee_statements";
    private const string Transfer = "transfers";
    private const string Reinstatement = "reinstatement";
}