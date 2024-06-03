namespace Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string NormalizedName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool OnPublic { get; set; }
    public ServiceType Type { get; set; } = ServiceType.Certificate;
}

public enum ServiceType
{
    Certificate,
    StudentStatement,
    EmployeeStatement,
    TransferAndReinstatement
}


public static class ServiceDir
{
    public static readonly Dictionary<ServiceType, string> Dict = new()
    {
        [ServiceType.Certificate] = "certificates",
        [ServiceType.StudentStatement] = "student_statements",
        [ServiceType.EmployeeStatement] = "employee_statements",
        [ServiceType.TransferAndReinstatement] = "transfers_and_reinstatement",
    };
}
