namespace Domain.Entities;

public class Statement
{
    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int FileId { get; set; }

    public virtual ICollection<FileSchema> FileSchemas { get; set; } = new List<FileSchema>();
}
