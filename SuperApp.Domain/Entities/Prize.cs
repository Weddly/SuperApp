namespace SuperApp.Domain.Entities;

public class Prize: EntityBase
{
    public Prize(int superId)
    {
        SuperId = superId;
    }
    public void UpdateDetails(int superId)
    {
        SuperId = superId;
    }
    public int SuperId { get; private set; }
}