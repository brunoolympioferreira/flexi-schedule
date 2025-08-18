namespace FlexiSchedule.Domain.Entities;
public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public BaseEntity()
    {
        Id = new Guid();
        CreatedAt = DateTime.Now;
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }
}
