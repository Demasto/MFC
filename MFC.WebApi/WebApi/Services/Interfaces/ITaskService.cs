using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace WebApi.Services.Interfaces;

public interface ITaskService
{
    public IQueryable<Domain.DTO.TaskDTO> GetAll();
    public IQueryable<Domain.DTO.TaskDTO> GetFromUser(string userId);
    public Task Add(string serviceName, AppUser user);

    public Task<Domain.Entities.Task> GetTaskById(long taskId);
    public Task ChangeStateAsync(long taskId, ProcessState newState, UserManager<AppUser> userManager);

    public Task RemoveAsync(long taskId);
    public void Clear();
}