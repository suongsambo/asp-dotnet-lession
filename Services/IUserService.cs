using UserManagementAPI.DTOs;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(CreateUserDto dto);
    Task<bool> DeleteAsync(int id);
}