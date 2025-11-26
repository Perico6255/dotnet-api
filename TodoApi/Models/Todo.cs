namespace TodoApi.Models;

public class Todo
{
    public int Id { get; set; }              // PK
    public string Title { get; set; } = "";  // Texto de la tarea
    public bool IsDone { get; set; }         // Completada o no
}
