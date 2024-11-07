# Senior .NET Developer Test
Time: 30 minutes

## Context
You are working on a library management system where users can maintain their personal reading lists. The base project includes user authentication and the database structure. Your task is to implement the core reading list functionality.

## Database Structure
The database is already configured with the following structure:

**User** (Identity Framework)
- Id (string)
- Email (string)
- Name (string)
- IsVerified (bool)

**Book**
- Id (string)
- Title (string)
- Author (string, nullable)
- Description (string, nullable)
- ISBN (string, nullable)

**ReadingList**
- Id (string)
- UserId (string)
- Title (string)
- CreatedAt (DateTime)

**ReadingListBook**
- ReadingListId (string)
- BookId (string)
- AddedAt (DateTime)

## Requirements

### 1. Reading List Management
Create RESTful API endpoints that allow users to:

a) Get reading list details with books
- Endpoint: GET /api/readinglists/{id}
- Should return the reading list with all associated books
- Include relevant book details (title, author, etc.)

b) Add a book to a reading list
- Endpoint: POST /api/readinglists/{id}/books
- Must enforce the 5-book limit per list
- Prevent duplicate books in the same list
- Return appropriate error messages for validation failures

c) Remove a book from a reading list
- Endpoint: DELETE /api/readinglists/{id}/books/{bookId}
- Handle cases where book or list doesn't exist

### 2. Technical Requirements
- Use the provided DataContext and entity models
- Implement proper repository/service pattern
- Use dependency injection
- Handle errors appropriately
- Follow REST API best practices

## Bonus Features
Implement any of these for extra points:
- Pagination for book lists
- Sorting (by title, author, or date added)
- Filtering capabilities
- Unit tests using provided test project
- Request/response DTOs
- API documentation

## Test Data Available
The database is seeded with:
- Test user (test@example.com / Test@123)
- Sample books
- One reading list with two books

## Evaluation Criteria
1. Code organization and architecture
2. Error handling and input validation
3. API design and REST principles
4. Query efficiency
5. Edge case handling

## Getting Started
1. The project runs on .NET 8
2. Database runs in Docker (PostgreSQL)
3. User authentication is pre-configured
4. Entity Framework and base models are set up

## Note
Focus on implementing the core functionality first. Bonus features should only be attempted after the main requirements are complete and working correctly.