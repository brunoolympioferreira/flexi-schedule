using FlexiSchedule.Application.Models.InputModels.Auth;

namespace FlexiSchedule.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginInputModel model)
    {
        var response = await authService.LoginAsync(model);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenInputModel model)
    {
        var response = await authService.RefreshTokenAsync(model);
        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] RefreshTokenInputModel model)
    {
        await authService.RevokeRefreshTokenAsync(model.RefreshToken);
        return Ok(new { message = "Success in Logout" });
    }
}
