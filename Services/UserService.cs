// Services/UserService.cs
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db) => _db = db;

    public async Task<List<UserViewDto>> GetAllAsync() =>
        await _db.Users
            .Select(u => new UserViewDto(u.Id, u.Username, u.FirstName, u.LastName, u.Email, u.CreatedAt))
            .ToListAsync();

    public async Task<UserViewDto?> GetByIdAsync(int id)
    {
        var u = await _db.Users.FindAsync(id);
        return u is null ? null : new UserViewDto(u.Id, u.Username, u.FirstName, u.LastName, u.Email, u.CreatedAt);
    }

    public Task<User?> GetByUsernameAsync(string username) =>
        _db.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<UserViewDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return new UserViewDto(user.Id, user.Username, user.FirstName, user.LastName, user.Email, user.CreatedAt);
    }

    public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return false;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return false;

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return true;
    }
}