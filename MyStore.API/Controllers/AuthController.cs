using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Service.AuthService.cs;
using MyStore.Service.DTOs.AuthDTOs;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDto request)
        {
            LoginResponseDto? result = authService.Login(request);

            return Ok(result);
        }
    }
}
