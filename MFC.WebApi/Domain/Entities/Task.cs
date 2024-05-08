
using Domain.Entities.Users;

namespace Domain.Entities;

public class Task
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string ServiceName { get; set; } = null!;
    public ProcessState State { get; set; } = ProcessState.Created;

    
    public Task() {}

    public Task(string serviceName)
    {
        ServiceName = serviceName;
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