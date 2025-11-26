namespace TodoApi.Models;

public class User
{
    public int Id { get; set; }          // PK
    public string Nombre { get; set; } = string.Empty;
    public string Apellido1 { get; set; } = string.Empty;
    public string Apellido2 { get; set; } = string.Empty;
    public string HashPassword { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<UserRole> Roles { get; set; } = new();
}
public class UserRole
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public Role Role { get; set; }
}
