using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;
using AttendanceManagementSystem.Domain.Interfaces;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace AttendanceManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUsersRepository _repo;

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

        _repo = _unitOfWork.Users;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsersAsync()
    {

        var users = await _repo.GetAllAsync();
        var response = _mapper.Map<UserReadDto>(users);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(response);
    }
}