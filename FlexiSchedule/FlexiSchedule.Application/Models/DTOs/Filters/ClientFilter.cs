namespace FlexiSchedule.Application.Models.DTOs.Filters;
public record ClientFilter(
    string? Name, 
    string? Email, 
    string? PhoneNumber
    )
{
}
