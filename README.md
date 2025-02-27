# Task Management API

A RESTful API built with **ASP.NET Core** for managing tasks, featuring JWT-based authentication and CRUD operations. This project demonstrates backend development skills using modern .NET tools and practices.

![Swagger UI Preview]![image](https://github.com/user-attachments/assets/bf8d15c2-d6f2-48be-bded-17b7d7793e27)


## Features
- ✅ **JWT Authentication**: Register and log in to secure your tasks.
- ✅ **Task CRUD Operations**: Create, read, update, and delete tasks.
- 🔜 *Future Improvements*: Role-based access, email notifications, and user management.

## Technologies
- **Backend**: ASP.NET Core 7.0
- **Database**: Entity Framework Core (SQL Server)
- **Authentication**: JWT Bearer Tokens
- **Documentation**: Swagger/OpenAPI

## Live Demo
Test the API endpoints directly in your browser:  
🔗 **[Live Swagger Documentation](https://task-manager.nexthor.dev/swagger/index.html)**

## Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/task-management-api.git
   ```
2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
3. **Configure the database:**
* Update the connection string in appsettings.json
* Run migrations:
   ```bash
   dotnet ef database update
   ```
4. **Run the API:**
   ```bash
   dotnet run
   ```
