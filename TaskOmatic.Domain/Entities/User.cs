namespace TaskOmatic.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public ICollection<TaskEntry> Tasks { get; set; } = new List<TaskEntry>();
}