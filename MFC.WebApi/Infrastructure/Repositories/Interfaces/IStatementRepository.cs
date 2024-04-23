using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IStatementRepository
{
    public Task<List<Statement>> ReadAllFilesAsync();
    public bool FileIsExist(string fileName);
    
    public void CreateFile(string fileName, string pathToFile);
    public Statement? ReadFile(string fileName);
    public void UpdateFile(string fileName, string pathToFile);

    public void DeleteFile(int id);
    
    public void DeleteFile(string name);

}