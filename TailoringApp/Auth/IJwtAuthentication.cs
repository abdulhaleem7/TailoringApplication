using TailoringApp.Dto;

namespace TailoringApp.Auth
{
    public interface IJwtAuthentication
    {
        string GenerateToken(UserDto user);
    }
}
