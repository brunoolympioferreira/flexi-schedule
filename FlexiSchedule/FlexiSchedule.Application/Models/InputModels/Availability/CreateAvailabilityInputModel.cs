namespace FlexiSchedule.Application.Models.InputModels.Availability;
public record CreateAvailabilityInputModel(
    string WeekDay, 
    DateTime StartTime,
    DateTime EndTime,
    DateTime DateRangeStart,
    DateTime DateRangeEnd,
    bool IsClosed)
{
    public Domain.Entities.Availability ToEntity(
        WeekDayEnum weekDay, 
        TimeOnly startTime, 
        TimeOnly endTime, 
        DateOnly dateRangeStart, 
        DateOnly DateRangeEnd,
        Guid professionalId) => 
        new(weekDay, startTime, endTime, dateRangeStart, DateRangeEnd, IsClosed, professionalId);
}
