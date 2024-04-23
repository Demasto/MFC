using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StatementRepository(MfcContext context) : IStatementRepository
{
    public Task<List<Statement>> ReadAllFilesAsync()
    {
        return context.Statements.ToListAsync();
    }

    public Statement? ReadFile(string fileName)
    {
        return context.Statements.FirstOrDefault(statement => statement.Name == fileName);
    }

    public bool FileIsExist(string fileName)
    {
        var file = context.Statements.FirstOrDefault(statement => statement.Name == fileName);

        return file != null;
    }

    public void CreateFile(string fileName, string pathToFile)
    {
        context.Statements.Add(new Statement()
        {
            Name = fileName,
            Path = pathToFile
        });

        context.SaveChanges();
    }
    
    public void UpdateFile(string fileName, string pathToFile)
    {
        context.Statements.Update(new Statement()
        {
            Name = fileName,
            Path = pathToFile
        });

        context.SaveChanges();
    }
    
    public void DeleteFile(int id)
    {
        var statement = context.Statements.Find(id);
        
        if (statement == null)
        {
            throw new NullReferenceException($"Statement with id = {id} doesnt exist");
        }
        context.Statements.Remove(statement);

        context.SaveChanges();
    }
    
    public void DeleteFile(string name)
    {
        var statement = context.Statements.First(statement => statement.Name == name);
        
        if (statement == null)
        {
            throw new NullReferenceException($"Statement with name = {name} doesnt exist");
        }
        context.Statements.Remove(statement);

        context.SaveChanges();
    }
}