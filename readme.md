dotnet new mvc -n MyWebApp
cd MyWebApp
dotnet restore
dotnet build
dotnet run
dotnet watch run



mkdir Controllers
mkdir Data
mkdir Models
mkdir Services
mkdir DTOs

New-Item Controllers\AuthController.cs -ItemType File
New-Item Controllers\UsersController.cs -ItemType File

New-Item Data\ApplicationDbContext.cs -ItemType File

New-Item Models\User.cs -ItemType File
New-Item Models\LoginRequest.cs -ItemType File
New-Item Models\RegisterRequest.cs -ItemType File

New-Item Services\IUserService.cs -ItemType File
New-Item Services\UserService.cs -ItemType File

New-Item DTOs\UserDto.cs -ItemType File
New-Item DTOs\CreateUserDto.cs -ItemType File
New-Item DTOs\UpdateUserDto.cs -ItemType File



touch Controllers/AuthController.cs
touch Controllers/UsersController.cs

touch Data/ApplicationDbContext.cs

touch Models/User.cs
touch Models/LoginRequest.cs
touch Models/RegisterRequest.cs

touch Services/IUserService.cs
touch Services/UserService.cs

touch DTOs/UserDto.cs
touch DTOs/CreateUserDto.cs
touch DTOs/UpdateUserDto.cs



dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package BCrypt.Net-Next
dotnet add package Swashbuckle.AspNetCore

dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
dotnet remove package Microsoft.EntityFrameworkCore.Tools
dotnet remove package Microsoft.EntityFrameworkCore.Design
dotnet remove package Microsoft.EntityFrameworkCore


dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Relational --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0