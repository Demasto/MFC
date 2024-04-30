using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class SchemaRepository(MfcContext context) : ISchemaRepository
{
    
    public void CreateSchema(StatementSchema schema)
    {
        context.StatementSchemas.Add(schema);
        context.SaveChanges();
    }
    
    public async Task<StatementSchema> ReadSchemaAsync(int schemaId)
    {
        var schema = await context.StatementSchemas.FindAsync(schemaId);
        if (schema == null) throw new Exception($"Не найдено схемы с id {schemaId}");
        return schema;
    }
    
    public void UpdateSchema(StatementSchema schema)
    {
        context.StatementSchemas.Update(schema);
        context.SaveChanges();
    }
    
    public void DeleteSchema(int schemaId)
    {
        var schema = context.StatementSchemas.Find(schemaId);
        if (schema == null) throw new Exception($"Не найдено схемы с id {schemaId}");
        context.Remove(schema);
        context.SaveChanges();
    }
    
    public Task<List<StatementSchema>> GetFromStatementAsync(int statementId)
    {
        return context.StatementSchemas.Where(schema => schema.FileId == statementId).ToListAsync();
    }
    
    public async Task DeleteFromStatementAsync(int statementId)
    {
        var fileSchemas = await context.StatementSchemas.Where(schema => schema.FileId == statementId).ToListAsync();
        context.StatementSchemas.RemoveRange(fileSchemas);
        await context.SaveChangesAsync();
    }

}