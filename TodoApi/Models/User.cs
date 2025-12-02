namespace TodoApi.Models;

public class User
{
    public int Id { get; set; }          // PK
    public string Nombre { get; set; } = string.Empty;
    public string Apellido1 { get; set; } = string.Empty;
    public string Apellido2 { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Role> Roles { get; set; } = new();
}