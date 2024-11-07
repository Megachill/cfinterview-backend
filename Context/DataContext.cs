using Context.Entities.Identity;
using Context.Entities.Library;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Context;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    /***
     * db sets
     */
    
    public DbSet<Book> Books { get; set; }
    public DbSet<ReadingList> ReadingLists { get; set; }
    public DbSet<ReadingListBook> ReadingListBooks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        /***
         * add relations and configurations as required
         */

        // Configure ReadingListBook (junction table)
        modelBuilder.Entity<ReadingListBook>(entity =>
        {
            entity.HasKey(e => new { e.ReadingListId, e.BookId });
            
            // Relationship with ReadingList
            entity.HasOne(rlb => rlb.ReadingList)
                .WithMany()
                .HasForeignKey(rlb => rlb.ReadingListId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Relationship with Book
            entity.HasOne(rlb => rlb.Book)
                .WithMany()
                .HasForeignKey(rlb => rlb.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure ReadingList
        modelBuilder.Entity<ReadingList>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.HasOne(rl => rl.User)
                .WithMany(u => u.ReadingLists)
                .HasForeignKey(rl => rl.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}