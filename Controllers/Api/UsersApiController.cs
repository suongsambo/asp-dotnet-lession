// Controllers/Api/UsersApiController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace MyWebApp.Controllers.Api;

[ApiController]
[Route("api/users")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]public class UsersApiController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersApiController(IUserService userService) => _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [AllowAnonymous] // registration is public; remove if only admins can create users
    public async Task<IActionResult> Create(UserCreateDto dto) =>
        Ok(await _userService.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserUpdateDto dto) =>
        await _userService.UpdateAsync(id, dto) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _userService.DeleteAsync(id) ? NoContent() : NotFound();
}