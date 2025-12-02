
namespace TodoApi.Models;

public class Role
{
    public int Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

}