
using System.Text.Json;
using Domain.DTO;
using Domain.DTO.Users;
using Domain.Entities.Users;

namespace Domain.Entities;

public class Task
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string UserFullName { get; set; }
    public string ServiceName { get; set; }
    public string Time { get; set; } = DateTime.UtcNow.ToLocalTime().ToString();
    public ProcessState State { get; set; } = ProcessState.Created;

    public Task() { }

    public Task(AppUser user, string serviceName)
    {
        UserId = user.Id;
        UserFullName = user.Name;
        ServiceName = serviceName;
    }

    public TaskDTO ToDTO()
    {
        return new TaskDTO()
        {
            Id = Id,
            UserId = UserId,
            Name = JsonSerializer.Deserialize<NameDTO>(UserFullName)!,
            ServiceName = ServiceName,
            DateTime = Time,
            State = State
        };
    }
}

public enum ProcessState
{
    Created,
    InProcess,
    Ready,
    Cancelled,
    Received
}