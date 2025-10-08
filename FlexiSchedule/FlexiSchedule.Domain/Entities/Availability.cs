namespace FlexiSchedule.Domain.Entities;
public class Availability : BaseEntity
{
    public WeekDayEnum WeekDay { get; private set; }
    public TimeOnly StartTime { get; private set; } = default;
    public TimeOnly EndTime { get; private set; } = default;
    public DateOnly DateRangeStart { get; private set; } = default;
    public DateOnly DateRangeEnd { get; private set; } = default;
    public bool IsClosed { get; private set; } = false;

    public Guid ProfessionalId { get; private set; }
}
