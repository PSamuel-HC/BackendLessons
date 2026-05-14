using MyStore.Service.DTOs.AuthDTOs;

namespace MyStore.Service.AuthService.cs
{
    public interface IAuthService
    {
        public LoginResponseDto? Login(LoginRequestDto request);
    }
}
