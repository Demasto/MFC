using Domain.Entities;

namespace WebApi.Services.Interfaces;

public interface ISchemaService
{
    public void CreateSchema(StatementSchema schema);

    public Task<StatementSchema> ReadSchemaAsync(int schemaId);

    public void UpdateSchema(StatementSchema schema);

    public void DeleteSchema(int schemaId);

    public Task<List<StatementSchema>> GetFromStatementAsync(int statementId);
    
    public Task DeleteFromStatementAsync(int statementId);
}