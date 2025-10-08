namespace FlexiSchedule.Domain.Entities;
public class Availability : BaseEntity
{
    public WeekDayEnum WeekDay { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public DateOnly DateRangeStart { get; private set; }
    public DateOnly DateRangeEnd { get; private set; }
    public bool IsClosed { get; private set; }

    public Guid ProfessionalId { get; private set; }

    // EF Core
    protected Availability() { }

    public Availability(WeekDayEnum weekDay, TimeOnly startTime, TimeOnly endTime, DateOnly dateRangeStart, DateOnly dateRangeEnd,
        bool isClosed, Guid professionalId)
    {
        WeekDay = weekDay;
        StartTime = startTime;
        EndTime = endTime;
        DateRangeStart = dateRangeStart;
        DateRangeEnd = dateRangeEnd;
        IsClosed = isClosed;
        ProfessionalId = professionalId;
    }


    public static Availability Add(WeekDayEnum weekDay, TimeOnly startTime, TimeOnly endTime, DateOnly dateRangeStart, DateOnly dateRangeEnd, 
        bool isClosed, Guid professionalId)
    {
        if (startTime >= endTime)
            throw new ProfessionalDomainException("The start time must be less than the end time.");

        if (dateRangeEnd < dateRangeStart)
            throw new ProfessionalDomainException("The end date must be greater than or equal to the start date.");

        Availability availability = new(weekDay, startTime, endTime, dateRangeStart, dateRangeEnd, isClosed, professionalId);

        return availability;
    }
}
