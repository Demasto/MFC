using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class SchemaService(ISchemaRepository repository) : ISchemaService
{
    public void CreateSchema(StatementSchema schema)
    {
        repository.CreateSchema(schema);
    }
    
    public Task<StatementSchema> ReadSchemaAsync(int schemaId)
    {
        return repository.ReadSchemaAsync(schemaId);
    }
    
    public void UpdateSchema(StatementSchema schema)
    {
        repository.UpdateSchema(schema);
    }
    
    public void DeleteSchema(int schemaId)
    {
        repository.DeleteSchema(schemaId);
    }
    
    public Task<List<StatementSchema>> GetFromStatementAsync(int statementId)
    {
        return repository.GetFromStatementAsync(statementId);
    }
    
    public Task DeleteFromStatementAsync(int statementId)
    {
        return repository.DeleteFromStatementAsync(statementId);
    }
}