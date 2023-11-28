using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;
using AttendanceManagementSystem.Domain.Interfaces;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace AttendanceManagementSystem.Api.Controllers;
public class UsersController : BaseController
{
    private readonly IUsersRepository _repo;

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _repo = unitOfWork.Users;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsersAsync()
    {

        var users = await _repo.GetAllAsync();
        var response = _mapper.Map<IEnumerable<UserReadDto>>(users);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(response);
    }
}