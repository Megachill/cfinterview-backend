namespace Context.Entities.Library;

public class ReadingListBook
{
    public string ReadingListId { get; set; } = null!;
    public string BookId { get; set; } = null!;
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ReadingList ReadingList { get; set; } = null!;
    public Book Book { get; set; } = null!;
}