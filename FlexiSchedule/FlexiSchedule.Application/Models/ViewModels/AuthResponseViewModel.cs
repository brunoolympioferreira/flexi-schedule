namespace FlexiSchedule.Application.Models.ViewModels;
public record AuthResponseViewModel(
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiry,
    DateTime RefreshTokenExpiry,
    ProfessionalInfoDTO ProfessionalInfoDTO)
{
}
