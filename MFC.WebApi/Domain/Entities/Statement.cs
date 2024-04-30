using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Statement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Path { get; set; } = null!;

    public virtual ICollection<StatementSchema> StatementSchemas { get; set; } = new List<StatementSchema>();
}
