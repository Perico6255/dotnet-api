
using TodoApi.Models;

public class Permiso
{
    public int Id { get; set; }
    public string Name { get; set; } = default!; // ej: "Products.Read"
    public string? Description { get; set; }

}