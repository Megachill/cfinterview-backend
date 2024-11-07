using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Entities.Library;
using Microsoft.AspNetCore.Identity;

namespace Context.Entities.Identity;

public class User : IdentityUser
{
    [Key, Column(TypeName = "varchar(36)")]
    public override string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Column(TypeName = "varchar(255)")]
    public string? Name { get; set; }
    public bool IsVerified { get; set; } = false;
    
    // Navigation property
    public ICollection<ReadingList> ReadingLists { get; set; } = new List<ReadingList>();
}