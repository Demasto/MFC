using Domain.Entities.Users;

namespace Domain.Entities;

public class Task
{
    public long Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public ProcessState State { get; set; } = ProcessState.Created;
    public List<AppUser> Users { get; set; } = new();
}

public enum ProcessState
{
    Created,
    InProcess,
    Ready,
    Cancelled,
    Received
}