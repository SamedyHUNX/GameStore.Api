# GameStore API

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)

A RESTful API built with **ASP.NET Core Minimal APIs** and **Entity Framework Core** for managing a video game store catalog. This project demonstrates modern .NET development practices including simplified endpoint mapping, DTO patterns, and SQLite integration.

## 🚀 Features

*   **Game Management**: Complete CRUD operations (Create, Read, Update, Delete) for video games.
*   **Genre Filtering**: Retrieve games with their associated genres.
*   **Data Validation**: Built-in request validation for required fields and data constraints.
*   **Database Integration**: Uses Entity Framework Core with SQLite for persistent storage.
*   **Automatic Migrations**: Applies database migrations automatically on application startup.

## 🛠️ Tech Stack

*   **Framework**: [.NET 10](https://dotnet.microsoft.com/)
*   **Language**: [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
*   **Database**: [SQLite](https://www.sqlite.org/index.html)
*   **ORM**: [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## 🏁 Getting Started

### Prerequisites

*   [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet) installed on your machine.

### Installation

1.  Clone the repository:
    ```bash
    git clone https://github.com/yourusername/gamestore-api.git
    ```
2.  Navigate to the project directory:
    ```bash
    cd GameStore.Api
    ```
3.  Restore dependencies:
    ```bash
    dotnet restore
    ```

### Running the Application

Run the application using the .NET CLI:

```bash
dotnet run
```

The API will be available at `http://localhost:5033`.

## 📡 API Endpoints

### Games

| Method | Endpoint      | Description           |
| :----- | :------------ | :-------------------- |
| GET    | `/games`      | Get all games         |
| GET    | `/games/{id}` | Get a game by ID      |
| POST   | `/games`      | Create a new game     |
| PUT    | `/games/{id}` | Update an existing game |
| DELETE | `/games/{id}` | Delete a game         |

### Genres

| Method | Endpoint | Description    |
| :----- | :------- | :------------- |
| GET    | `/genres`| Get all genres |

## 📂 Project Structure

*   **`Data/`**: Contains the Database Context (`GameStoreContext`) and data usage logic.
*   **`Dtos/`**: Data Transfer Objects for API requests and responses.
*   **`Endpoints/`**: Minimal API route handlers (`GamesEndpoint`, `GenresEndPoints`).
*   **`Models/`**: Domain entities (`Game`, `Genre`).
*   **`games.http`**: HTTP file for testing API endpoints directly in VS Code or Visual Studio.

## 🧪 Testing

You can use the included `games.http` file to test the API endpoints if you are using Visual Studio or VS Code with the REST Client extension.
