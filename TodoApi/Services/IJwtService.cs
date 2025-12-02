namespace TodoApi.Services;

public interface IJwtTokenService
{
    string GenerateToken(int userId, string email, IEnumerable<string> roles);
}
