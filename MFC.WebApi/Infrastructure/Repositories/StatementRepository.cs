using Domain.Models;
using Infrastructure.Context;
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
        return context.Statements.SingleAsync(statement => statement.FileName == fileName);;
    }

    public void SaveFile(string fileName, string pathToFile)
    {
        context.Statements.Add(new Statement()
        {
            FileName = fileName,
            FilePath = pathToFile
        });

        context.SaveChanges();
    }
}