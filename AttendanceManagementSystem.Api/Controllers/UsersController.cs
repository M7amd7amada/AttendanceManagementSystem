using AttendanceManagementSystem.DataAccess.Repositories;
using AttendanceManagementSystem.Domain.Interfaces;
using AttendanceManagementSystem.Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace AttendanceManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
    {
        return Ok(await _unitOfWork.Users.GetAllAsync());
    }
}