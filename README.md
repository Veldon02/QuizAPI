
# QuizAPI

QuizAPI is a CRUD RESTful Web API that allows you to create and manage quizzes and marks for them. It provides endpoints for creating, retrieving, updating, and deleting quizzes and marks.

## Technologies Used

- ASP.NET Core 6
- Entity Framework Core
- SQL Server

## Architecture

QuizAPI is built using Clean Architecture principles, all application sepereted into 4 layers: Presentation, Application, Infrastrucutre and Domain. API aslo uses CQRS design pattern

## Authentication

QuizAPI uses JSON Web Tokens (JWT) for authentication. To access the protected endpoints, you will need to include a valid JWT in the Authorization header of your HTTP requests.




