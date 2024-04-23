using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StatementRepository(MfcContext context) : IStatementRepository
{
    public Task<List<Statement>> GetAllStatementsAsync()
    {
        return context.Statements.ToListAsync();
    }

    public Task<Statement> GetStatementByFileNameAsync(string fileName)
    {
        return context.Statements.SingleAsync(statement => statement.Name == fileName);;
    }

    public void SaveFile(string fileName, string pathToFile)
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
}