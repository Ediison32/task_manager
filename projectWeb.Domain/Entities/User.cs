namespace projectWeb.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Propiedad de navegación: Un usuario tiene muchas tareas
    public List<Task> Tasks { get; set; } = new();
}