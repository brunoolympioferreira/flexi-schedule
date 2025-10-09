namespace FlexiSchedule.Application.Models.InputModels.Availability;
public record CreateAvailabilityInputModel(
    string WeekDay, 
    DateTime StartTime,
    DateTime EndTime,
    DateTime DateRangeStart,
    DateTime DateRangeEnd,
    bool IsClosed,
    Guid ProfessionalId)
{
}
