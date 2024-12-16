namespace SuperApp.Domain.Entities;

public class Deck: EntityBase
{
    public Deck(string name, string owner)
    {
        Name = name;
        Owner = owner;
    }
    
    public void UpdateDetails(string name, string owner)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Name and owner cannot be empty.");
        Name = name;
        Owner = owner;
    }
    
    public string Name { get; private set; }
    public string Owner { get; private set; }
}