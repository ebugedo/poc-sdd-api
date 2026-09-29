namespace PocSddApi.src.Clients.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}