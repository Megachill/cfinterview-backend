namespace Context.Entities.Library;

public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? ISBN { get; set; }
}