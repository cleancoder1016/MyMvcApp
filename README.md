# User Management System

This project is developed using .NET Core MVC and is a User Management System. It allows you to create, read, update, and delete user information. The application is coded using asynchronous methods to make use of multi-threaded processes for better performance.

## Features

- Create new users
- Read user information
- Update existing user information
- Delete users
- Asynchronous operations for improved performance

## Technologies Used

- .NET Core MVC
- Entity Framework Core
- SQLite3 (or your preferred database)
- Bootstrap (for front-end styling)

## Getting Started

### Prerequisites

- .NET Core SDK
- Visual Studio or Visual Studio Code
- SQLite3 (or your preferred database)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/cleancoder1016/MyMvcApp.git
    ```
2. Navigate to the project directory:
    ```sh
    cd MyMvcApp
    ```
3. Install the required packages:
    ```sh
    dotnet restore
    ```
4. Apply the database migrations:
    ```sh
    dotnet ef database update
    ```
5. Run the application:
    ```sh
    dotnet run
    ```

## Usage

1. Open your browser and navigate to `http://localhost:5079`.
2. Use the provided interface to manage users.

## Project Structure

- [Controllers]: Contains the MVC controllers.
    - [Api]: 
        -[UsersController.cs]: Contains an API controller for managing user-related operations. It uses dependency injection to access the IUserRepo repository for user data. The controller is decorated with [Route("api/[controller]")] and [ApiController] attributes, indicating it handles API requests at the (http://localhost:5079/api/Users) endpoint. This give you a JSON output.
    - [HomeController.cs]: Handles requests for the home and privacy pages, utilizing logging and returning views for these actions.
    - [UsersController.cs]: Manages CRUD operations for user entities via endpoint (http://localhost:5079/Users)
- [Models]: Contains the data models.
- [Views]: Contains the Razor views.
- [Data]: Contains Classes related to data access and data context
- [wwwroot]: Contains static files like CSS and JavaScript.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.