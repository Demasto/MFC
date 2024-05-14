using Domain.DTO.Users;
using Domain.Entities;

namespace Domain.DTO;

public class TaskDTO
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public NameDTO Name { get; set; }
    public string ServiceName { get; set; }
    public string DateTime { get; set; }
    public ProcessState State { get; set; }
}