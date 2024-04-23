using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IStatementRepository
{
    public Task<List<Statement>> GetAllStatementsAsync();
    
    public Task<Statement> GetStatementByFileNameAsync(string fileName);

    public void SaveFile(string fileName, string pathToFile);
    public void UpdateFile(string fileName, string pathToFile);

    public void DeleteFile(int id);

}