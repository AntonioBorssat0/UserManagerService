
# User Manager Service

## Overview
This is a RESTful API built with ASP.NET Core. The API utilizes a local SQLite database.

## Development Environment Setup

### Prerequisites
- .NET 8 SDK or later.
- SQLite for local database beacuse is light.
- I used Visual Studio 2022 as my IDE.

### Initial Setup
Clone this repository to your local machine.
Navigate to the project folder using terminal.
Run `dotnet restore` to install project dependencies.

### Database Configuration
Ensure the SQLite connection string in `appsettings.json` is correctly set:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=user_management.db"
   }
   ```
On terminal, apply database migrations with `dotnet ef database update` to set up the database schema.

## Running the Project
First, recompile the solution. Then, inside the project folder, execute `dotnet run` to start the service or use the run button in Visual Studio with https marked.
Visit the url according the launchSettings.json urls. For https, to view the Swagger UI and interact with the API endpoints, the url is probably `https://localhost:7167/swagger/index.html`.

## API Endpoints

### Create User
- **POST /users**
  - Creates a new user by providing name and birthdate (yyyy-mm-dd) in the Request Body.
  - Request Body example:
    ```json
    {
      "name": "Antonio Victor",
      "birthdate": "1998-04-06"
    }
    ```
  - Success Response: `HTTP 201 Created` with details of the created user.

### Update Active Status
- **PUT /users**
  - Updates the `Active` status of an user by providing the id and the boolean active status.
  - Request Body:
    ```json
    {
      "id": 1,
      "active": false
    }
    ```
  - Success Response: `HTTP 204 No Content`.

### Delete User
- **DELETE /users/{id}**
  - Deletes a user based on the provided id.
  - URL Parameter: `id` (ID of the user to delete).
  - Success Response: `HTTP 204 No Content`.

### List Active Users
- **GET /users/active**
  - Returns a list of all active users.
  - Success Response: `HTTP 200 OK` with a list of active users.

## Data

### AppDbContext
- It handles the database interaction using Entity Framework Core.
- This class includes a DbSet<User> which corresponds to the users' table in the database.

## Models

### User
- Model used to represent users and create the database schema.
- Properties: `Id`, `Name`, `Birthdate`, `Active`.

### CreatingUser
- Used to structure the request body when creating a new user.
- Properties: `Name`, `Birthdate`.

### UpdateActive
- Used to structure the request body when updating a user's active status.
- Properties: `Id`, `Active`.

## Testing
The application can be tested using the Swagger UI interface, which provides an interactive way to execute requests against the API.
