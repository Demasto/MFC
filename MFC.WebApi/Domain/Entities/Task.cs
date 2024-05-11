
using Domain.Entities.Users;

namespace Domain.Entities;

public class Task(string userId, string serviceName)
{
    public long Id { get; set; }
    public string UserId { get; set; } = userId;
    public string ServiceName { get; set; } = serviceName;
    public ProcessState State { get; set; } = ProcessState.Created;
}

public enum ProcessState
{
    Created,
    InProcess,
    Ready,
    Cancelled,
    Received
}