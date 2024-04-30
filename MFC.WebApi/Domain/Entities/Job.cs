namespace Domain.Entities;

public class Job
{
    public long Id { get; set; }
    public string UserId { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    public ProcessState State { get; set; } = ProcessState.Created;
}

public enum ProcessState
{
    Created,
    Cancelled,
    Completed
}