# Senior .NET Developer Test
Time: 30 minutes

## Task Description
Create a Reading List API that allows users to manage their book collections. The database structure is already set up with the following tables:
- Books (Id, Title, Author, Description, ISBN)
- ReadingLists (Id, UserId, Title, CreatedAt)
- ReadingListBooks (ReadingListId, BookId, AddedAt)

## Requirements
1. Create an API endpoint to get a user's reading list with all books
2. Create an endpoint to add a book to a reading list
    - A reading list cannot have more than 5 books
    - The same book cannot be added twice to the same list
3. Create an endpoint to remove a book from a reading list

## Bonus Points
- Implement proper error handling
- Add input validation
- Add pagination for the reading list
- Add sorting options (by title, author, or date added)
- Add unit tests

## Expected Solution Should
- Use dependency injection
- Follow REST API best practices
- Include appropriate HTTP status codes
- Handle edge cases appropriately

## Example Endpoints Structure
```
GET /api/readinglists/{readingListId}/books
POST /api/readinglists/{readingListId}/books
DELETE /api/readinglists/{readingListId}/books/{bookId}
```
