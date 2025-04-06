namespace TaskOmatic.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public bool IsDeleted { get; set; } = false;
}