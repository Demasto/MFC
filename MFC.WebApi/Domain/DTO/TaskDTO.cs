using Domain.DTO.Users;
using Domain.Entities;

namespace Domain.DTO;

public class TaskDTO
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string UserFullName { get; set; }
    public string? UserEmail { get; set; }
    public Service Service { get; set; }
    public string DateTime { get; set; }
    public ProcessState State { get; set; }
    public ServiceType ServiceType { get; set; }
}