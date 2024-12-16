namespace SuperApp.Domain.Entities;

public abstract class EntityBase
{
    public DateTime CreationDate { get; set;} = DateTime.Now;
    public Guid Id { get; set; } = Guid.NewGuid();
    public Boolean IsDeleted { get; set;} = false;
}