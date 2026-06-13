using UserManagementAPI.Data;
using UserManagementAPI.DTOs;
using UserManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task<User> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);

        if (user == null)
            return false;

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();

        return true;
    }
}