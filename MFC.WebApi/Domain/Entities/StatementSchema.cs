

namespace Domain.Entities;

public class StatementSchema
{
    public int Id { get; set; }

    public int FileId { get; set; }

    public decimal X { get; set; }

    public decimal Y { get; set; }

    public int? FontSize { get; set; }

    public string? DataId { get; set; }

    public virtual Statement File { get; set; } = null!;
}
