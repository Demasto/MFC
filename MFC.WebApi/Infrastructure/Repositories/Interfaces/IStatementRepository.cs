using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IStatementRepository
{
    Task<List<Statement>> GetAllStatementsAsync();
    
    Task<Statement> GetStatementByFileNameAsync(string fileName);

    void SaveFile(string fileName, string pathToFile);

}