namespace TaskOmatic.Domain.Entities;

public class TaskEntry : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    
    public int? UserID { get; set; } 
    public User? User { get; set; }
}