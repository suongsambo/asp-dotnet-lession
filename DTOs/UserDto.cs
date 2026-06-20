// Models/UserDtos.cs
namespace MyWebApp.Models;

public record UserCreateDto(string Username, string Password, string FirstName, string LastName, string Email);
public record UserUpdateDto(string FirstName, string LastName, string Email);
public record UserViewDto(int Id, string Username, string FirstName, string LastName, string Email, DateTime CreatedAt);
public record LoginDto(string Username, string Password);