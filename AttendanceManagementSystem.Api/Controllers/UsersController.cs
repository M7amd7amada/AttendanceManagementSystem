using AttendanceManagementSystem.DataAccess.Repositories;
using AttendanceManagementSystem.Domain.Interfaces;
using AttendanceManagementSystem.Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace AttendanceManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _repo;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repo = _unitOfWork.Users;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
    {
        return Ok(await _repo.GetAllAsync());
    }
}