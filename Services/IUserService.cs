// Services/IUserService.cs
using MyWebApp.Models;

namespace MyWebApp.Services;

public interface IUserService
{
    Task<List<UserViewDto>> GetAllAsync();
    Task<UserViewDto?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task<UserViewDto> CreateAsync(UserCreateDto dto);
    Task<bool> UpdateAsync(int id, UserUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}