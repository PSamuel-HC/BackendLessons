using MyStore.Service.DTOs.Authentication;

namespace MyStore.Service.AuthService.cs
{
    public interface IAuthService
    {
        public LoginResponseDto? Login(LoginRequestDto request);
    }
}
