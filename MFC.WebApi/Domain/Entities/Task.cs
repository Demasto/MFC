
using System.Globalization;
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
    public string? UserEmail { get; set; }
    public string Service { get; set; }
    public string Time { get; set; } = DateTime.UtcNow.ToLocalTime().ToString(CultureInfo.CurrentCulture);
    public ProcessState State { get; set; } = ProcessState.Created;

    public Task() { }

    public Task(AppUser user, Service service)
    {
        var name = JsonSerializer.Deserialize<NameDTO>(user.Name);
        
        UserId = user.Id;
        UserFullName = $"{name?.Second} {name?.First}";
        UserEmail = user.Email;
        Service = JsonSerializer.Serialize(service);
    }

    public TaskDTO ToDTO()
    {
        return new TaskDTO()
        {
            Id = Id,
            UserId = UserId,
            UserFullName = UserFullName,
            UserEmail = UserEmail,
            Service = JsonSerializer.Deserialize<Service>(Service)!,
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