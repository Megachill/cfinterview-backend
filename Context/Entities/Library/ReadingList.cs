using Context.Entities.Identity;

namespace Context.Entities.Library;

public class ReadingList
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = null!;
    public string Title { get; set; } = "My Reading List";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation property
    public User User { get; set; } = null!;
}