namespace TodoApi.Models;

public record UserDto(

    string UserName,
    string Email
);

public class UserLoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
