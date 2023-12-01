using System.ComponentModel;

using AttendanceManagementSystem.Domain.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace AttendanceManagementSystem.Api.Controllers.Version_1.Users;
// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public partial class UsersController : BaseController
{
    private readonly IUsersRepository _users;

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _users = unitOfWork.Users;
    }

    [HttpGet]
    [Route("GetUser")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<UserReadDto>> GetByIdAsync(Guid id)
    {
        var user = await _users.GetByIdAsync(id);

        if (user is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<UserReadDto>(user);

        return Ok(response);
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllAsync()
    {

        var users = await _users.GetAllAsync();

        if (users is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<IEnumerable<UserReadDto>>(users);

        return Ok(response);
    }

    [HttpGet]
    [Route("CountUsers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<int>> Count()
    {
        return Ok(await _users.CountAsync());
    }
}