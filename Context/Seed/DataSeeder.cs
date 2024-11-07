using Context.Entities.Identity;
using Context.Entities.Library;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Context.Seed;

public class DataSeeder
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        
        // Create test user if it doesn't exist
        var testUser = new User
        {
            UserName = "test@example.com",
            Email = "test@example.com",
            Name = "Test User",
            IsVerified = true,
            EmailConfirmed = true
        };

        var existingUser = await userManager.FindByEmailAsync(testUser.Email);
        if (existingUser == null)
        {
            var result = await userManager.CreateAsync(testUser, "Test@123");
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create test user");
            }
        }

        // Seed books if none exist
        if (!await context.Books.AnyAsync())
        {
            var books = new[]
            {
                new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Pragmatic Programmer",
                    Author = "David Thomas, Andrew Hunt",
                    ISBN = "9780135957059",
                    Description = "The Pragmatic Programmer is one of those rare tech books you'll read, re-read, and read again over the years."
                },
                new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "9780132350884",
                    Description = "Even bad code can function. But if code isn't clean, it can bring a development organization to its knees."
                },
                new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Design Patterns",
                    Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                    ISBN = "9780201633610",
                    Description = "Elements of Reusable Object-Oriented Software"
                }
            };

            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();

            // Create a sample reading list
            var userId = (existingUser ?? testUser).Id;
            var readingList = new ReadingList
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Title = "My Tech Books",
                CreatedAt = DateTime.UtcNow
            };

            await context.ReadingLists.AddAsync(readingList);
            await context.SaveChangesAsync();

            // Add books to the reading list using the junction table
            var readingListBooks = new[]
            {
                new ReadingListBook
                {
                    ReadingListId = readingList.Id,
                    BookId = books[0].Id,  // Pragmatic Programmer
                    AddedAt = DateTime.UtcNow
                },
                new ReadingListBook
                {
                    ReadingListId = readingList.Id,
                    BookId = books[1].Id,  // Clean Code
                    AddedAt = DateTime.UtcNow.AddMinutes(1)
                }
            };

            await context.ReadingListBooks.AddRangeAsync(readingListBooks);
            await context.SaveChangesAsync();
        }
    }
}
